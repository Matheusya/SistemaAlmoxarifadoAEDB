using SistemaAlmoxarifado.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaAlmoxarifado.Forms
{
    /// <summary>
    /// RF06 - Realizar Ajuste de Estoque (Inventário)
    /// </summary>
    public partial class FormAjusteEstoque : Form
    {
        public FormAjusteEstoque()
        {
            InitializeComponent();
            this.Load += FormAjusteEstoque_Load;
        }

        private void FormAjusteEstoque_Load(object? sender, EventArgs e)
        {
            CarregarMateriais();
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
                        Descricao = $"{m.Codigo} - {m.Nome} (Estoque Atual: {m.EstoqueAtual})"
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

        // Quando selecionar material
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
                        txtEstoqueAtual.Text = material.EstoqueAtual.ToString();
                        lblInfoMaterial.Text = $"Unidade: {material.UnidadeMedida} | Estoque Mínimo: {material.EstoqueMinimo}";
                    }
                }
                catch
                {
                    txtEstoqueAtual.Clear();
                    lblInfoMaterial.Text = "";
                }
            }
            else
            {
                txtEstoqueAtual.Clear();
                lblInfoMaterial.Text = "";
            }
        }

        // Botão Realizar Ajuste
        private void btnAjustar_Click(object sender, EventArgs e)
        {
            // Validações
            if (cboMaterial.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um material.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaterial.Focus();
                return;
            }

            if (!int.TryParse(txtNovaQuantidade.Text, out int novaQuantidade) || novaQuantidade < 0)
            {
                MessageBox.Show("Informe uma nova quantidade válida (maior ou igual a zero).", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNovaQuantidade.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtJustificativa.Text))
            {
                MessageBox.Show("A justificativa é obrigatória para realizar o ajuste de estoque.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtJustificativa.Focus();
                return;
            }

            try
            {
                using var context = new AlmoxarifadoDbContext();
                var materialId = Convert.ToInt32(cboMaterial.SelectedValue);
                var material = context.Materiais.Find(materialId);

                if (material == null)
                {
                    MessageBox.Show("Material não encontrado.", "Erro", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var quantidadeAnterior = material.EstoqueAtual;

                // Confirmação
                var resultado = MessageBox.Show(
                    $"Confirma o ajuste de estoque?\n\n" +
                    $"Material: {material.Nome}\n" +
                    $"Estoque Atual: {quantidadeAnterior}\n" +
                    $"Nova Quantidade: {novaQuantidade}\n" +
                    $"Diferença: {novaQuantidade - quantidadeAnterior}\n\n" +
                    $"Justificativa: {txtJustificativa.Text}",
                    "Confirmar Ajuste",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    return;
                }

                // Criar registro de ajuste
                var ajuste = new AjusteEstoque
                {
                    MaterialId = materialId,
                    QuantidadeAnterior = quantidadeAnterior,
                    NovaQuantidade = novaQuantidade,
                    Justificativa = txtJustificativa.Text.Trim(),
                    DataAjuste = DateTime.Now
                };

                context.AjustesEstoque.Add(ajuste);

                // Atualizar estoque do material
                material.EstoqueAtual = novaQuantidade;

                context.SaveChanges();

                MessageBox.Show("Ajuste de estoque realizado com sucesso!", "Sucesso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                CarregarHistoricoAjustes();
                CarregarMateriais(); // Atualizar lista com novos estoques
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao realizar ajuste: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carregar histórico de ajustes
        private void CarregarHistoricoAjustes()
        {
            try
            {
                using var context = new AlmoxarifadoDbContext();
                var ajustes = context.AjustesEstoque
                    .Include(a => a.Material)
                    .OrderByDescending(a => a.DataAjuste)
                    .Take(50)
                    .Select(a => new
                    {
                        Data = a.DataAjuste,
                        Material = a.Material!.Nome,
                        EstoqueAnterior = a.QuantidadeAnterior,
                        NovoEstoque = a.NovaQuantidade,
                        Diferenca = a.NovaQuantidade - a.QuantidadeAnterior,
                        a.Justificativa
                    })
                    .ToList();

                dgvHistorico.DataSource = ajustes;

                if (dgvHistorico.Columns.Count > 0)
                {
                    dgvHistorico.Columns["Data"].HeaderText = "Data/Hora";
                    dgvHistorico.Columns["Data"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvHistorico.Columns["Material"].HeaderText = "Material";
                    dgvHistorico.Columns["EstoqueAnterior"].HeaderText = "Estoque Anterior";
                    dgvHistorico.Columns["NovoEstoque"].HeaderText = "Novo Estoque";
                    dgvHistorico.Columns["Diferenca"].HeaderText = "Diferença";
                    dgvHistorico.Columns["Justificativa"].HeaderText = "Justificativa";
                    dgvHistorico.Columns["Justificativa"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Colorir diferença
                foreach (DataGridViewRow row in dgvHistorico.Rows)
                {
                    var diferenca = Convert.ToInt32(row.Cells["Diferenca"].Value);
                    if (diferenca > 0)
                    {
                        row.Cells["Diferenca"].Style.ForeColor = Color.Green;
                    }
                    else if (diferenca < 0)
                    {
                        row.Cells["Diferenca"].Style.ForeColor = Color.Red;
                    }
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
            txtEstoqueAtual.Clear();
            txtNovaQuantidade.Clear();
            txtJustificativa.Clear();
            lblInfoMaterial.Text = "";
            cboMaterial.Focus();
        }
    }
}
