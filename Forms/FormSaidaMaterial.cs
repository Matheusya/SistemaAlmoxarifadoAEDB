using SistemaAlmoxarifado.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaAlmoxarifado.Forms
{
    /// <summary>
    /// RF04 - Registrar Saída de Material (Requisição por Setor)
    /// </summary>
    public partial class FormSaidaMaterial : Form
    {
        public FormSaidaMaterial()
        {
            InitializeComponent();
            this.Load += FormSaidaMaterial_Load;
        }

        private void FormSaidaMaterial_Load(object? sender, EventArgs e)
        {
            CarregarMateriais();
            PreencherComboSetores();
            dtpDataSaida.Value = DateTime.Now;
        }

        // Carregar materiais
        private void CarregarMateriais()
        {
            try
            {
                using var context = new AlmoxarifadoDbContext();
                var materiais = context.Materiais
                    .Where(m => m.EstoqueAtual > 0)
                    .OrderBy(m => m.Nome)
                    .Select(m => new
                    {
                        m.Id,
                        Descricao = $"{m.Codigo} - {m.Nome} (Estoque: {m.EstoqueAtual})"
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

        // Preencher combo de setores
        private void PreencherComboSetores()
        {
            cboSetor.Items.Clear();
            cboSetor.Items.AddRange(new string[] 
            { 
                "Serviços Gerais", "Lab. Química", "Lab. Física", "Lab. Biologia", 
                "Lab. Informática", "Secretaria", "Coordenação", "Biblioteca", 
                "Manutenção", "Segurança", "Almoxarifado", "Diretoria" 
            });
        }

        // Botão Registrar Saída
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

            if (cboSetor.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o setor solicitante.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSetor.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtResponsavel.Text))
            {
                MessageBox.Show("Informe o responsável.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtResponsavel.Focus();
                return;
            }

            if (!int.TryParse(txtQuantidade.Text, out int quantidade) || quantidade <= 0)
            {
                MessageBox.Show("Informe uma quantidade válida (maior que zero).", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantidade.Focus();
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

                // Verificar se há estoque suficiente
                if (material.EstoqueAtual < quantidade)
                {
                    MessageBox.Show($"Estoque insuficiente!\n\nEstoque Atual: {material.EstoqueAtual}\nQuantidade Solicitada: {quantidade}", 
                        "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Criar registro de saída
                var saida = new SaidaMaterial
                {
                    MaterialId = materialId,
                    SetorSolicitante = cboSetor.SelectedItem.ToString()!,
                    Responsavel = txtResponsavel.Text.Trim(),
                    Quantidade = quantidade,
                    DataSaida = dtpDataSaida.Value
                };

                context.SaidasMateriais.Add(saida);

                // Decrementar estoque
                material.EstoqueAtual -= quantidade;

                context.SaveChanges();

                var mensagem = $"Saída registrada com sucesso!\n\nMaterial: {material.Nome}\nSetor: {saida.SetorSolicitante}\nQuantidade: {quantidade}\nNovo Estoque: {material.EstoqueAtual}";
                
                // Alerta se estoque ficou crítico
                if (material.EstoqueAtual <= material.EstoqueMinimo)
                {
                    mensagem += $"\n\n?? ATENÇÃO: Estoque está no ponto de pedido!\nEstoque Mínimo: {material.EstoqueMinimo}";
                }

                MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparCampos();
                CarregarHistoricoSaidas();
                CarregarMateriais(); // Atualizar lista com novos estoques
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar saída: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Carregar histórico de saídas
        private void CarregarHistoricoSaidas()
        {
            try
            {
                using var context = new AlmoxarifadoDbContext();
                var saidas = context.SaidasMateriais
                    .Include(s => s.Material)
                    .OrderByDescending(s => s.DataSaida)
                    .Take(50)
                    .Select(s => new
                    {
                        Data = s.DataSaida,
                        Material = s.Material!.Nome,
                        s.SetorSolicitante,
                        s.Responsavel,
                        s.Quantidade,
                        Unidade = s.Material.UnidadeMedida
                    })
                    .ToList();

                dgvHistorico.DataSource = saidas;

                if (dgvHistorico.Columns.Count > 0)
                {
                    dgvHistorico.Columns["Data"].HeaderText = "Data/Hora";
                    dgvHistorico.Columns["Data"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvHistorico.Columns["Material"].HeaderText = "Material";
                    dgvHistorico.Columns["SetorSolicitante"].HeaderText = "Setor";
                    dgvHistorico.Columns["Responsavel"].HeaderText = "Responsável";
                    dgvHistorico.Columns["Quantidade"].HeaderText = "Qtd";
                    dgvHistorico.Columns["Unidade"].HeaderText = "Un";
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
            cboSetor.SelectedIndex = -1;
            txtResponsavel.Clear();
            txtQuantidade.Clear();
            dtpDataSaida.Value = DateTime.Now;
            lblInfoMaterial.Text = "";
            cboMaterial.Focus();
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
                        var cor = material.EstoqueAtual <= material.EstoqueMinimo ? "vermelho" : "verde";
                        lblInfoMaterial.Text = $"Unidade: {material.UnidadeMedida} | Estoque Atual: {material.EstoqueAtual} | Estoque Mínimo: {material.EstoqueMinimo}";
                        lblInfoMaterial.ForeColor = material.EstoqueAtual <= material.EstoqueMinimo ? Color.Red : Color.DarkBlue;
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
