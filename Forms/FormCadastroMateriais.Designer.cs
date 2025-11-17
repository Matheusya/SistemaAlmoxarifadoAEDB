namespace SistemaAlmoxarifado.Forms
{
    partial class FormCadastroMateriais
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            panelCadastro = new Panel();
            txtEstoqueMinimo = new TextBox();
            lblEstoqueMinimo = new Label();
            cboClassificacao = new ComboBox();
            lblClassificacao = new Label();
            cboUnidadeMedida = new ComboBox();
            lblUnidadeMedida = new Label();
            txtNome = new TextBox();
            lblNome = new Label();
            txtCodigo = new TextBox();
            lblCodigo = new Label();
            panelBotoes = new Panel();
            btnExcluir = new Button();
            btnSalvar = new Button();
            btnNovo = new Button();
            panelGrid = new Panel();
            dgvMateriais = new DataGridView();
            txtBusca = new TextBox();
            lblBusca = new Label();
            panelCadastro.SuspendLayout();
            panelBotoes.SuspendLayout();
            panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMateriais).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(0, 121, 214);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1000, 60);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Cadastro de Materiais";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCadastro
            // 
            panelCadastro.BackColor = Color.White;
            panelCadastro.Controls.Add(txtEstoqueMinimo);
            panelCadastro.Controls.Add(lblEstoqueMinimo);
            panelCadastro.Controls.Add(cboClassificacao);
            panelCadastro.Controls.Add(lblClassificacao);
            panelCadastro.Controls.Add(cboUnidadeMedida);
            panelCadastro.Controls.Add(lblUnidadeMedida);
            panelCadastro.Controls.Add(txtNome);
            panelCadastro.Controls.Add(lblNome);
            panelCadastro.Controls.Add(txtCodigo);
            panelCadastro.Controls.Add(lblCodigo);
            panelCadastro.Dock = DockStyle.Top;
            panelCadastro.Location = new Point(0, 60);
            panelCadastro.Name = "panelCadastro";
            panelCadastro.Padding = new Padding(20);
            panelCadastro.Size = new Size(1000, 180);
            panelCadastro.TabIndex = 1;
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCodigo.Location = new Point(20, 20);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(64, 23);
            lblCodigo.TabIndex = 0;
            lblCodigo.Text = "Código:";
            // 
            // txtCodigo
            // 
            txtCodigo.Font = new Font("Segoe UI", 10F);
            txtCodigo.Location = new Point(20, 46);
            txtCodigo.MaxLength = 50;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(200, 30);
            txtCodigo.TabIndex = 1;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNome.Location = new Point(240, 20);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(144, 23);
            lblNome.TabIndex = 2;
            lblNome.Text = "Nome do Material:";
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Segoe UI", 10F);
            txtNome.Location = new Point(240, 46);
            txtNome.MaxLength = 200;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(500, 30);
            txtNome.TabIndex = 3;
            // 
            // lblUnidadeMedida
            // 
            lblUnidadeMedida.AutoSize = true;
            lblUnidadeMedida.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUnidadeMedida.Location = new Point(760, 20);
            lblUnidadeMedida.Name = "lblUnidadeMedida";
            lblUnidadeMedida.Size = new Size(73, 23);
            lblUnidadeMedida.TabIndex = 4;
            lblUnidadeMedida.Text = "Unidade:";
            // 
            // cboUnidadeMedida
            // 
            cboUnidadeMedida.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUnidadeMedida.Font = new Font("Segoe UI", 10F);
            cboUnidadeMedida.FormattingEnabled = true;
            cboUnidadeMedida.Location = new Point(760, 46);
            cboUnidadeMedida.Name = "cboUnidadeMedida";
            cboUnidadeMedida.Size = new Size(200, 31);
            cboUnidadeMedida.TabIndex = 5;
            // 
            // lblClassificacao
            // 
            lblClassificacao.AutoSize = true;
            lblClassificacao.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblClassificacao.Location = new Point(20, 100);
            lblClassificacao.Name = "lblClassificacao";
            lblClassificacao.Size = new Size(112, 23);
            lblClassificacao.TabIndex = 6;
            lblClassificacao.Text = "Classificação:";
            // 
            // cboClassificacao
            // 
            cboClassificacao.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClassificacao.Font = new Font("Segoe UI", 10F);
            cboClassificacao.FormattingEnabled = true;
            cboClassificacao.Location = new Point(20, 126);
            cboClassificacao.Name = "cboClassificacao";
            cboClassificacao.Size = new Size(250, 31);
            cboClassificacao.TabIndex = 7;
            // 
            // lblEstoqueMinimo
            // 
            lblEstoqueMinimo.AutoSize = true;
            lblEstoqueMinimo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEstoqueMinimo.Location = new Point(290, 100);
            lblEstoqueMinimo.Name = "lblEstoqueMinimo";
            lblEstoqueMinimo.Size = new Size(134, 23);
            lblEstoqueMinimo.TabIndex = 8;
            lblEstoqueMinimo.Text = "Estoque Mínimo:";
            // 
            // txtEstoqueMinimo
            // 
            txtEstoqueMinimo.Font = new Font("Segoe UI", 10F);
            txtEstoqueMinimo.Location = new Point(290, 126);
            txtEstoqueMinimo.MaxLength = 10;
            txtEstoqueMinimo.Name = "txtEstoqueMinimo";
            txtEstoqueMinimo.Size = new Size(150, 30);
            txtEstoqueMinimo.TabIndex = 9;
            txtEstoqueMinimo.Text = "0";
            // 
            // panelBotoes
            // 
            panelBotoes.BackColor = Color.White;
            panelBotoes.Controls.Add(btnExcluir);
            panelBotoes.Controls.Add(btnSalvar);
            panelBotoes.Controls.Add(btnNovo);
            panelBotoes.Dock = DockStyle.Top;
            panelBotoes.Location = new Point(0, 240);
            panelBotoes.Name = "panelBotoes";
            panelBotoes.Padding = new Padding(20, 10, 20, 10);
            panelBotoes.Size = new Size(1000, 70);
            panelBotoes.TabIndex = 2;
            // 
            // btnNovo
            // 
            btnNovo.BackColor = Color.FromArgb(0, 121, 214);
            btnNovo.Cursor = Cursors.Hand;
            btnNovo.FlatAppearance.BorderSize = 0;
            btnNovo.FlatStyle = FlatStyle.Flat;
            btnNovo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNovo.ForeColor = Color.White;
            btnNovo.Location = new Point(20, 15);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(150, 40);
            btnNovo.TabIndex = 0;
            btnNovo.Text = "Novo";
            btnNovo.UseVisualStyleBackColor = false;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = Color.FromArgb(0, 121, 214);
            btnSalvar.Cursor = Cursors.Hand;
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Location = new Point(190, 15);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(150, 40);
            btnSalvar.TabIndex = 1;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.BackColor = Color.FromArgb(0, 121, 214);
            btnExcluir.Cursor = Cursors.Hand;
            btnExcluir.FlatAppearance.BorderSize = 0;
            btnExcluir.FlatStyle = FlatStyle.Flat;
            btnExcluir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnExcluir.ForeColor = Color.White;
            btnExcluir.Location = new Point(360, 15);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(150, 40);
            btnExcluir.TabIndex = 2;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // panelGrid
            // 
            panelGrid.BackColor = Color.White;
            panelGrid.Controls.Add(dgvMateriais);
            panelGrid.Controls.Add(txtBusca);
            panelGrid.Controls.Add(lblBusca);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Location = new Point(0, 310);
            panelGrid.Name = "panelGrid";
            panelGrid.Padding = new Padding(20);
            panelGrid.Size = new Size(1000, 340);
            panelGrid.TabIndex = 3;
            // 
            // lblBusca
            // 
            lblBusca.AutoSize = true;
            lblBusca.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBusca.Location = new Point(20, 20);
            lblBusca.Name = "lblBusca";
            lblBusca.Size = new Size(59, 23);
            lblBusca.TabIndex = 0;
            lblBusca.Text = "Buscar:";
            // 
            // txtBusca
            // 
            txtBusca.Font = new Font("Segoe UI", 10F);
            txtBusca.Location = new Point(85, 17);
            txtBusca.Name = "txtBusca";
            txtBusca.PlaceholderText = "Digite o código, nome ou classificação para buscar...";
            txtBusca.Size = new Size(500, 30);
            txtBusca.TabIndex = 1;
            txtBusca.TextChanged += txtBusca_TextChanged;
            // 
            // dgvMateriais
            // 
            dgvMateriais.AllowUserToAddRows = false;
            dgvMateriais.AllowUserToDeleteRows = false;
            dgvMateriais.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMateriais.BackgroundColor = Color.White;
            dgvMateriais.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMateriais.Location = new Point(20, 60);
            dgvMateriais.MultiSelect = false;
            dgvMateriais.Name = "dgvMateriais";
            dgvMateriais.ReadOnly = true;
            dgvMateriais.RowHeadersWidth = 51;
            dgvMateriais.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMateriais.Size = new Size(960, 260);
            dgvMateriais.TabIndex = 2;
            dgvMateriais.CellClick += dgvMateriais_CellClick;
            // 
            // FormCadastroMateriais
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 650);
            Controls.Add(panelGrid);
            Controls.Add(panelBotoes);
            Controls.Add(panelCadastro);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCadastroMateriais";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cadastro de Materiais";
            panelCadastro.ResumeLayout(false);
            panelCadastro.PerformLayout();
            panelBotoes.ResumeLayout(false);
            panelGrid.ResumeLayout(false);
            panelGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMateriais).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Panel panelCadastro;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Label lblNome;
        private TextBox txtNome;
        private Label lblUnidadeMedida;
        private ComboBox cboUnidadeMedida;
        private Label lblClassificacao;
        private ComboBox cboClassificacao;
        private Label lblEstoqueMinimo;
        private TextBox txtEstoqueMinimo;
        private Panel panelBotoes;
        private Button btnNovo;
        private Button btnSalvar;
        private Button btnExcluir;
        private Panel panelGrid;
        private Label lblBusca;
        private TextBox txtBusca;
        private DataGridView dgvMateriais;
    }
}
