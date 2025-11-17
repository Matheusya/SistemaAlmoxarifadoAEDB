using SistemaAlmoxarifado.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaAlmoxarifado.Forms
{
    /// <summary>
    /// RF02 - Gerar Relatório de Ponto de Pedido (Estoque Crítico)
    /// </summary>
    public partial class FormRelatorioPontoPedido : Form
    {
        public FormRelatorioPontoPedido()
        {
            InitializeComponent();
            this.Load += FormRelatorioPontoPedido_Load;
        }

        private void FormRelatorioPontoPedido_Load(object? sender, EventArgs e)
        {
            GerarRelatorio();
        }

        // Gerar relatório de materiais com estoque crítico
        private void GerarRelatorio()
        {
            try
            {
                using var context = new AlmoxarifadoDbContext();
                
                // Buscar materiais onde EstoqueAtual <= EstoqueMinimo
                var materiaisCriticos = context.Materiais
                    .Where(m => m.EstoqueAtual <= m.EstoqueMinimo)
                    .OrderBy(m => m.Classificacao)
                    .ThenBy(m => m.Nome)
                    .Select(m => new
                    {
                        m.Codigo,
                        m.Nome,
                        m.UnidadeMedida,
                        m.Classificacao,
                        m.EstoqueMinimo,
                        m.EstoqueAtual,
                        Diferenca = m.EstoqueMinimo - m.EstoqueAtual,
                        Status = m.EstoqueAtual == 0 ? "ZERADO" : 
                                 m.EstoqueAtual < m.EstoqueMinimo ? "CRÍTICO" : "ATENÇÃO"
                    })
                    .ToList();

                dgvPontoPedido.DataSource = materiaisCriticos;

                // Configurar colunas
                if (dgvPontoPedido.Columns.Count > 0)
                {
                    dgvPontoPedido.Columns["Codigo"].HeaderText = "Código";
                    dgvPontoPedido.Columns["Nome"].HeaderText = "Nome do Material";
                    dgvPontoPedido.Columns["UnidadeMedida"].HeaderText = "Unidade";
                    dgvPontoPedido.Columns["Classificacao"].HeaderText = "Classificação";
                    dgvPontoPedido.Columns["EstoqueMinimo"].HeaderText = "Est. Mínimo";
                    dgvPontoPedido.Columns["EstoqueAtual"].HeaderText = "Est. Atual";
                    dgvPontoPedido.Columns["Diferenca"].HeaderText = "Diferença";
                    dgvPontoPedido.Columns["Status"].HeaderText = "Status";
                }

                // Atualizar label de total
                lblTotal.Text = $"Total de materiais em ponto de pedido: {materiaisCriticos.Count}";

                // Colorir linhas conforme criticidade
                foreach (DataGridViewRow row in dgvPontoPedido.Rows)
                {
                    var status = row.Cells["Status"].Value?.ToString();
                    if (status == "ZERADO")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200); // Vermelho claro
                        row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    }
                    else if (status == "CRÍTICO")
                    {
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 200); // Laranja claro
                        row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botão Atualizar
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            GerarRelatorio();
        }

        // Botão Imprimir
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                // Criar relatório em texto para impressão ou exportação
                using var context = new AlmoxarifadoDbContext();
                
                var materiaisCriticos = context.Materiais
                    .Where(m => m.EstoqueAtual <= m.EstoqueMinimo)
                    .OrderBy(m => m.Classificacao)
                    .ThenBy(m => m.Nome)
                    .ToList();

                if (materiaisCriticos.Count == 0)
                {
                    MessageBox.Show("Não há materiais em ponto de pedido para imprimir.", "Informação", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Montar texto do relatório
                var relatorio = new System.Text.StringBuilder();
                relatorio.AppendLine("========================================");
                relatorio.AppendLine("RELATÓRIO DE PONTO DE PEDIDO");
                relatorio.AppendLine($"Data: {DateTime.Now:dd/MM/yyyy HH:mm}");
                relatorio.AppendLine("========================================");
                relatorio.AppendLine();

                var classificacaoAtual = "";
                foreach (var material in materiaisCriticos)
                {
                    if (classificacaoAtual != material.Classificacao)
                    {
                        classificacaoAtual = material.Classificacao;
                        relatorio.AppendLine($"\n[{classificacaoAtual}]");
                        relatorio.AppendLine("----------------------------------------");
                    }

                    var status = material.EstoqueAtual == 0 ? "ZERADO" : "CRÍTICO";
                    relatorio.AppendLine($"Código: {material.Codigo}");
                    relatorio.AppendLine($"Material: {material.Nome}");
                    relatorio.AppendLine($"Unidade: {material.UnidadeMedida}");
                    relatorio.AppendLine($"Estoque Mínimo: {material.EstoqueMinimo}");
                    relatorio.AppendLine($"Estoque Atual: {material.EstoqueAtual}");
                    relatorio.AppendLine($"Status: {status}");
                    relatorio.AppendLine($"Diferença: {material.EstoqueMinimo - material.EstoqueAtual}");
                    relatorio.AppendLine();
                }

                relatorio.AppendLine("========================================");
                relatorio.AppendLine($"Total de materiais: {materiaisCriticos.Count}");
                relatorio.AppendLine("========================================");

                // Exibir relatório em uma nova janela
                var formRelatorio = new Form
                {
                    Text = "Relatório de Ponto de Pedido - Impressão",
                    Size = new Size(700, 600),
                    StartPosition = FormStartPosition.CenterScreen
                };

                var txtRelatorio = new TextBox
                {
                    Multiline = true,
                    ScrollBars = ScrollBars.Both,
                    Dock = DockStyle.Fill,
                    Font = new Font("Courier New", 9F),
                    Text = relatorio.ToString(),
                    ReadOnly = true
                };

                formRelatorio.Controls.Add(txtRelatorio);
                formRelatorio.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório para impressão: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
