using SistemaAlmoxarifado.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaAlmoxarifado.Forms
{
    /// <summary>
    /// Consultar Histórico de Movimentações
    /// </summary>
    public partial class FormHistoricoMovimentacoes : Form
    {
        // Classe auxiliar para representar uma movimentação
        private class MovimentacaoView
        {
            public DateTime Data { get; set; }
            public string Tipo { get; set; } = string.Empty;
            public int Quantidade { get; set; }
            public string Observacao { get; set; } = string.Empty;
        }

        public FormHistoricoMovimentacoes()
        {
            InitializeComponent();
            this.Load += FormHistoricoMovimentacoes_Load;
        }

        private void FormHistoricoMovimentacoes_Load(object? sender, EventArgs e)
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

        // Botão Consultar
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (cboMaterial.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um material para consultar o histórico.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaterial.Focus();
                return;
            }

            ConsultarHistorico();
        }

        // Consultar histórico de movimentações
        private void ConsultarHistorico()
        {
            try
            {
                using var context = new AlmoxarifadoDbContext();
                var materialId = Convert.ToInt32(cboMaterial.SelectedValue);

                // Buscar material
                var material = context.Materiais.Find(materialId);
                if (material == null)
                {
                    MessageBox.Show("Material não encontrado.", "Erro", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Exibir informações do material
                lblInfoMaterial.Text = $"Material: {material.Nome} | Código: {material.Codigo} | Estoque Atual: {material.EstoqueAtual} | Estoque Mínimo: {material.EstoqueMinimo}";

                var todasMovimentacoes = new System.ComponentModel.BindingList<MovimentacaoView>();

                // Buscar entradas
                var entradas = context.EntradasMateriais
                    .Where(e => e.MaterialId == materialId)
                    .ToList();

                foreach (var entrada in entradas)
                {
                    todasMovimentacoes.Add(new MovimentacaoView
                    {
                        Data = entrada.DataEntrada,
                        Tipo = "ENTRADA",
                        Quantidade = entrada.Quantidade,
                        Observacao = $"Fornecedor: {entrada.Fornecedor}" + 
                                   (string.IsNullOrEmpty(entrada.NumeroLote) ? "" : $" | Lote: {entrada.NumeroLote}")
                    });
                }

                // Buscar saídas
                var saidas = context.SaidasMateriais
                    .Where(s => s.MaterialId == materialId)
                    .ToList();

                foreach (var saida in saidas)
                {
                    todasMovimentacoes.Add(new MovimentacaoView
                    {
                        Data = saida.DataSaida,
                        Tipo = "SAÍDA",
                        Quantidade = saida.Quantidade,
                        Observacao = $"Setor: {saida.SetorSolicitante} | Responsável: {saida.Responsavel}"
                    });
                }

                // Buscar ajustes
                var ajustes = context.AjustesEstoque
                    .Where(a => a.MaterialId == materialId)
                    .ToList();

                foreach (var ajuste in ajustes)
                {
                    todasMovimentacoes.Add(new MovimentacaoView
                    {
                        Data = ajuste.DataAjuste,
                        Tipo = "AJUSTE",
                        Quantidade = ajuste.NovaQuantidade - ajuste.QuantidadeAnterior,
                        Observacao = $"De {ajuste.QuantidadeAnterior} para {ajuste.NovaQuantidade} | Justificativa: {ajuste.Justificativa}"
                    });
                }

                // Ordenar por data
                var movimentacoesOrdenadas = todasMovimentacoes
                    .OrderByDescending(m => m.Data)
                    .ToList();

                dgvHistorico.DataSource = null;
                dgvHistorico.DataSource = movimentacoesOrdenadas;

                // Configurar colunas
                if (dgvHistorico.Columns.Count > 0)
                {
                    dgvHistorico.Columns["Data"].HeaderText = "Data/Hora";
                    dgvHistorico.Columns["Data"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvHistorico.Columns["Data"].Width = 150;
                    dgvHistorico.Columns["Tipo"].HeaderText = "Tipo";
                    dgvHistorico.Columns["Tipo"].Width = 80;
                    dgvHistorico.Columns["Quantidade"].HeaderText = "Qtd";
                    dgvHistorico.Columns["Quantidade"].Width = 70;
                    dgvHistorico.Columns["Observacao"].HeaderText = "Observação";
                    dgvHistorico.Columns["Observacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Colorir linhas conforme tipo
                foreach (DataGridViewRow row in dgvHistorico.Rows)
                {
                    var tipo = row.Cells["Tipo"].Value?.ToString();
                    if (tipo == "ENTRADA")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(200, 255, 200); // Verde claro
                    }
                    else if (tipo == "SAÍDA")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 200); // Laranja claro
                    }
                    else if (tipo == "AJUSTE")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 255); // Azul claro
                    }
                }

                lblTotal.Text = $"Total de movimentações: {movimentacoesOrdenadas.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao consultar histórico: {ex.Message}\n\nDetalhes: {ex.InnerException?.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Quando selecionar material
        private void cboMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMaterial.SelectedIndex != -1)
            {
                ConsultarHistorico();
            }
            else
            {
                lblInfoMaterial.Text = "";
                dgvHistorico.DataSource = null;
                lblTotal.Text = "";
            }
        }
    }
}
