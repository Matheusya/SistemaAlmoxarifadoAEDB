using SistemaAlmoxarifado.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaAlmoxarifado.Forms
{
    /// <summary>
    /// RF03 - Registrar Entrada de Material (Nota Fiscal)
    /// </summary>
    public partial class FormEntradaMaterial : Form
    {
        public FormEntradaMaterial()
        {
            InitializeComponent();
            this.Load += FormEntradaMaterial_Load;
        }

        private void FormEntradaMaterial_Load(object? sender, EventArgs e)
        {
            CarregarMateriais();
            dtpDataEntrada.Value = DateTime.Now;
        }

        // Carregar materiais no ComboBox
        private void CarregarMateriais()
        {
            try
            {
                using var context = new AlmoxarifadoDbContext();
                var materiais = context.Materiais
                    .OrderBy(m => m.Nome)
                    .Select(m => new
                    {
                        m.Id,
                        Descricao = $"{m.Codigo} - {m.Nome}"
                    })
                    .ToList();

                cboMaterial.DataSource = materiais;
                cboMaterial.DisplayMember = "Descricao";
                cboMaterial.ValueMember = "Id";
                cboMaterial.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar materiais: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botão Registrar Entrada
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Validações
            if (cboMaterial.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um material.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaterial.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFornecedor.Text))
            {
                MessageBox.Show("Informe o fornecedor.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFornecedor.Focus();
                return;
            }

            if (!int.TryParse(txtQuantidade.Text, out int quantidade) || quantidade <= 0)
            {
                MessageBox.Show("Informe uma quantidade válida (maior que zero).", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantidade.Focus();
                return;
            }

            if (!decimal.TryParse(txtCustoUnitario.Text, out decimal custoUnitario) || custoUnitario < 0)
            {
                MessageBox.Show("Informe um custo unitário válido.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustoUnitario.Focus();
                return;
            }

            try
            {
                using var context = new AlmoxarifadoDbContext();
                var materialId = Convert.ToInt32(cboMaterial.SelectedValue);

                // Criar registro de entrada
                var entrada = new EntradaMaterial
                {
                    MaterialId = materialId,
                    Fornecedor = txtFornecedor.Text.Trim(),
                    Quantidade = quantidade,
                    CustoUnitario = custoUnitario,
                    NumeroLote = string.IsNullOrWhiteSpace(txtLote.Text) ? null : txtLote.Text.Trim(),
                    DataValidade = string.IsNullOrWhiteSpace(txtValidade.Text) ? null : txtValidade.Text.Trim(),
                    DataEntrada = dtpDataEntrada.Value
                };

                context.EntradasMateriais.Add(entrada);

                // Incrementar estoque atual do material
                var material = context.Materiais.Find(materialId);
                if (material != null)
                {
                    material.EstoqueAtual += quantidade;
                }

                context.SaveChanges();

                MessageBox.Show($"Entrada registrada com sucesso!\n\nMaterial: {cboMaterial.Text}\nQuantidade: {quantidade}\nNovo Estoque: {material?.EstoqueAtual}", 
                    "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                CarregarHistoricoEntradas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar entrada: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carregar histórico de entradas recentes
        private void CarregarHistoricoEntradas()
        {
            try
            {
                using var context = new AlmoxarifadoDbContext();
                var entradas = context.EntradasMateriais
                    .Include(e => e.Material)
                    .OrderByDescending(e => e.DataEntrada)
                    .Take(50)
                    .Select(e => new
                    {
                        Data = e.DataEntrada,
                        Material = e.Material!.Nome,
                        e.Fornecedor,
                        e.Quantidade,
                        CustoUnitario = e.CustoUnitario,
                        CustoTotal = e.Quantidade * e.CustoUnitario,
                        e.NumeroLote,
                        e.DataValidade
                    })
                    .ToList();

                dgvHistorico.DataSource = entradas;

                if (dgvHistorico.Columns.Count > 0)
                {
                    dgvHistorico.Columns["Data"].HeaderText = "Data/Hora";
                    dgvHistorico.Columns["Data"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvHistorico.Columns["Material"].HeaderText = "Material";
                    dgvHistorico.Columns["Fornecedor"].HeaderText = "Fornecedor";
                    dgvHistorico.Columns["Quantidade"].HeaderText = "Qtd";
                    dgvHistorico.Columns["CustoUnitario"].HeaderText = "Custo Unit.";
                    dgvHistorico.Columns["CustoUnitario"].DefaultCellStyle.Format = "C2";
                    dgvHistorico.Columns["CustoTotal"].HeaderText = "Custo Total";
                    dgvHistorico.Columns["CustoTotal"].DefaultCellStyle.Format = "C2";
                    dgvHistorico.Columns["NumeroLote"].HeaderText = "Lote";
                    dgvHistorico.Columns["DataValidade"].HeaderText = "Validade";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar histórico: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botão Limpar
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        // Limpar campos
        private void LimparCampos()
        {
            cboMaterial.SelectedIndex = -1;
            txtFornecedor.Clear();
            txtQuantidade.Clear();
            txtCustoUnitario.Clear();
            txtLote.Clear();
            txtValidade.Clear();
            dtpDataEntrada.Value = DateTime.Now;
            cboMaterial.Focus();
        }

        // Quando selecionar um material, mostrar informações
        private void cboMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaterial.SelectedIndex != -1)
            {
                try
                {
                    using var context = new AlmoxarifadoDbContext();
                    var materialId = Convert.ToInt32(cboMaterial.SelectedValue);
                    var material = context.Materiais.Find(materialId);

                    if (material != null)
                    {
                        lblInfoMaterial.Text = $"Unidade: {material.UnidadeMedida} | Estoque Atual: {material.EstoqueAtual} | Estoque Mínimo: {material.EstoqueMinimo}";
                    }
                }
                catch
                {
                    lblInfoMaterial.Text = "";
                }
            }
            else
            {
                lblInfoMaterial.Text = "";
            }
        }
    }
}
