using SistemaAlmoxarifado.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaAlmoxarifado.Forms
{
    /// <summary>
    /// RF01 - Gerenciamento de Cadastro de Material (CRUD)
    /// </summary>
    public partial class FormCadastroMateriais : Form
    {
        private int? materialIdSelecionado = null;

        public FormCadastroMateriais()
        {
            InitializeComponent();
            this.Load += FormCadastroMateriais_Load;
        }

        private void FormCadastroMateriais_Load(object? sender, EventArgs e)
        {
            CarregarMateriais();
            PreencherComboUnidadeMedida();
            PreencherComboClassificacao();
        }

        // Carregar lista de materiais no DataGridView
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
                        m.Codigo,
                        m.Nome,
                        m.UnidadeMedida,
                        m.Classificacao,
                        m.EstoqueMinimo,
                        m.EstoqueAtual
                    })
                    .ToList();

                dgvMateriais.DataSource = materiais;
                dgvMateriais.Columns["Id"].Visible = false;
                dgvMateriais.Columns["Codigo"].HeaderText = "Código";
                dgvMateriais.Columns["Nome"].HeaderText = "Nome do Material";
                dgvMateriais.Columns["UnidadeMedida"].HeaderText = "Unidade";
                dgvMateriais.Columns["Classificacao"].HeaderText = "Classificação";
                dgvMateriais.Columns["EstoqueMinimo"].HeaderText = "Estoque Mínimo";
                dgvMateriais.Columns["EstoqueAtual"].HeaderText = "Estoque Atual";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar materiais: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Preencher combo de unidade de medida
        private void PreencherComboUnidadeMedida()
        {
            cboUnidadeMedida.Items.Clear();
            cboUnidadeMedida.Items.AddRange(new string[] 
            { 
                "UN", "CX", "PC", "KG", "L", "ML", "M", "CM", 
                "Galão", "Pacote", "Caixa", "Fardo", "Resma" 
            });
        }

        // Preencher combo de classificação
        private void PreencherComboClassificacao()
        {
            cboClassificacao.Items.Clear();
            cboClassificacao.Items.AddRange(new string[] 
            { 
                "Limpeza", "Laboratório", "Escritório", "Informática", 
                "Manutenção", "Segurança", "Higiene" 
            });
        }

        // Botão Novo
        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
            txtCodigo.Focus();
        }

        // Botão Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validações
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                MessageBox.Show("Informe o código do material.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCodigo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome do material.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }

            if (cboUnidadeMedida.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione a unidade de medida.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboUnidadeMedida.Focus();
                return;
            }

            if (cboClassificacao.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione a classificação.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboClassificacao.Focus();
                return;
            }

            if (!int.TryParse(txtEstoqueMinimo.Text, out int estoqueMinimo) || estoqueMinimo < 0)
            {
                MessageBox.Show("Informe um estoque mínimo válido.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEstoqueMinimo.Focus();
                return;
            }

            try
            {
                using var context = new AlmoxarifadoDbContext();

                if (materialIdSelecionado == null) // Novo material
                {
                    // Verificar se código já existe
                    if (context.Materiais.Any(m => m.Codigo == txtCodigo.Text.Trim()))
                    {
                        MessageBox.Show("Já existe um material com este código.", "Atenção", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCodigo.Focus();
                        return;
                    }

                    var novoMaterial = new Material
                    {
                        Codigo = txtCodigo.Text.Trim(),
                        Nome = txtNome.Text.Trim(),
                        UnidadeMedida = cboUnidadeMedida.SelectedItem.ToString()!,
                        Classificacao = cboClassificacao.SelectedItem.ToString()!,
                        EstoqueMinimo = estoqueMinimo,
                        EstoqueAtual = 0,
                        DataCadastro = DateTime.Now
                    };

                    context.Materiais.Add(novoMaterial);
                    context.SaveChanges();

                    MessageBox.Show("Material cadastrado com sucesso!", "Sucesso", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // Editar material existente
                {
                    var material = context.Materiais.Find(materialIdSelecionado);
                    if (material != null)
                    {
                        // Verificar se código já existe em outro material
                        if (context.Materiais.Any(m => m.Codigo == txtCodigo.Text.Trim() && m.Id != materialIdSelecionado))
                        {
                            MessageBox.Show("Já existe outro material com este código.", "Atenção", 
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCodigo.Focus();
                            return;
                        }

                        material.Codigo = txtCodigo.Text.Trim();
                        material.Nome = txtNome.Text.Trim();
                        material.UnidadeMedida = cboUnidadeMedida.SelectedItem.ToString()!;
                        material.Classificacao = cboClassificacao.SelectedItem.ToString()!;
                        material.EstoqueMinimo = estoqueMinimo;

                        context.SaveChanges();

                        MessageBox.Show("Material atualizado com sucesso!", "Sucesso", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                LimparCampos();
                CarregarMateriais();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar material: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Botão Excluir
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (materialIdSelecionado == null)
            {
                MessageBox.Show("Selecione um material para excluir.", "Atenção", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                "Deseja realmente excluir este material?", 
                "Confirmar Exclusão", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    using var context = new AlmoxarifadoDbContext();
                    var material = context.Materiais.Find(materialIdSelecionado);
                    
                    if (material != null)
                    {
                        context.Materiais.Remove(material);
                        context.SaveChanges();

                        MessageBox.Show("Material excluído com sucesso!", "Sucesso", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimparCampos();
                        CarregarMateriais();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao excluir material: {ex.Message}", "Erro", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Quando clicar em uma linha do grid
        private void dgvMateriais_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvMateriais.Rows[e.RowIndex];
                materialIdSelecionado = Convert.ToInt32(row.Cells["Id"].Value);

                txtCodigo.Text = row.Cells["Codigo"].Value.ToString();
                txtNome.Text = row.Cells["Nome"].Value.ToString();
                cboUnidadeMedida.SelectedItem = row.Cells["UnidadeMedida"].Value.ToString();
                cboClassificacao.SelectedItem = row.Cells["Classificacao"].Value.ToString();
                txtEstoqueMinimo.Text = row.Cells["EstoqueMinimo"].Value.ToString();
            }
        }

        // Buscar materiais
        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using var context = new AlmoxarifadoDbContext();
                var busca = txtBusca.Text.Trim().ToLower();

                var materiais = context.Materiais
                    .Where(m => m.Codigo.ToLower().Contains(busca) || 
                                m.Nome.ToLower().Contains(busca) ||
                                m.Classificacao.ToLower().Contains(busca))
                    .OrderBy(m => m.Nome)
                    .Select(m => new
                    {
                        m.Id,
                        m.Codigo,
                        m.Nome,
                        m.UnidadeMedida,
                        m.Classificacao,
                        m.EstoqueMinimo,
                        m.EstoqueAtual
                    })
                    .ToList();

                dgvMateriais.DataSource = materiais;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar materiais: {ex.Message}", "Erro", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Limpar campos do formulário
        private void LimparCampos()
        {
            materialIdSelecionado = null;
            txtCodigo.Clear();
            txtNome.Clear();
            cboUnidadeMedida.SelectedIndex = -1;
            cboClassificacao.SelectedIndex = -1;
            txtEstoqueMinimo.Clear();
            txtBusca.Clear();
        }
    }
}
