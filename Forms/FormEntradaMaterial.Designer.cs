namespace SistemaAlmoxarifado.Forms
{
    partial class FormEntradaMaterial
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
            lblInfoMaterial = new Label();
            dtpDataEntrada = new DateTimePicker();
            lblDataEntrada = new Label();
            txtValidade = new TextBox();
            lblValidade = new Label();
            txtLote = new TextBox();
            lblLote = new Label();
            txtCustoUnitario = new TextBox();
            lblCustoUnitario = new Label();
            txtQuantidade = new TextBox();
            lblQuantidade = new Label();
            txtFornecedor = new TextBox();
            lblFornecedor = new Label();
            cboMaterial = new ComboBox();
            lblMaterial = new Label();
            panelBotoes = new Panel();
            btnLimpar = new Button();
            btnRegistrar = new Button();
            panelGrid = new Panel();
            dgvHistorico = new DataGridView();
            lblHistorico = new Label();
            panelCadastro.SuspendLayout();
            panelBotoes.SuspendLayout();
            panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorico).BeginInit();
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
            lblTitulo.Text = "Registrar Entrada de Material";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCadastro
            // 
            panelCadastro.BackColor = Color.White;
            panelCadastro.Controls.Add(lblInfoMaterial);
            panelCadastro.Controls.Add(dtpDataEntrada);
            panelCadastro.Controls.Add(lblDataEntrada);
            panelCadastro.Controls.Add(txtValidade);
            panelCadastro.Controls.Add(lblValidade);
            panelCadastro.Controls.Add(txtLote);
            panelCadastro.Controls.Add(lblLote);
            panelCadastro.Controls.Add(txtCustoUnitario);
            panelCadastro.Controls.Add(lblCustoUnitario);
            panelCadastro.Controls.Add(txtQuantidade);
            panelCadastro.Controls.Add(lblQuantidade);
            panelCadastro.Controls.Add(txtFornecedor);
            panelCadastro.Controls.Add(lblFornecedor);
            panelCadastro.Controls.Add(cboMaterial);
            panelCadastro.Controls.Add(lblMaterial);
            panelCadastro.Dock = DockStyle.Top;
            panelCadastro.Location = new Point(0, 60);
            panelCadastro.Name = "panelCadastro";
            panelCadastro.Padding = new Padding(20);
            panelCadastro.Size = new Size(1000, 220);
            panelCadastro.TabIndex = 1;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMaterial.Location = new Point(20, 20);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(71, 23);
            lblMaterial.TabIndex = 0;
            lblMaterial.Text = "Material:";
            // 
            // cboMaterial
            // 
            cboMaterial.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaterial.Font = new Font("Segoe UI", 10F);
            cboMaterial.FormattingEnabled = true;
            cboMaterial.Location = new Point(20, 46);
            cboMaterial.Name = "cboMaterial";
            cboMaterial.Size = new Size(500, 31);
            cboMaterial.TabIndex = 1;
            cboMaterial.SelectedIndexChanged += cboMaterial_SelectedIndexChanged;
            // 
            // lblInfoMaterial
            // 
            lblInfoMaterial.AutoSize = true;
            lblInfoMaterial.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblInfoMaterial.ForeColor = Color.DarkBlue;
            lblInfoMaterial.Location = new Point(540, 51);
            lblInfoMaterial.Name = "lblInfoMaterial";
            lblInfoMaterial.Size = new Size(0, 20);
            lblInfoMaterial.TabIndex = 2;
            // 
            // lblFornecedor
            // 
            lblFornecedor.AutoSize = true;
            lblFornecedor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFornecedor.Location = new Point(20, 95);
            lblFornecedor.Name = "lblFornecedor";
            lblFornecedor.Size = new Size(96, 23);
            lblFornecedor.TabIndex = 3;
            lblFornecedor.Text = "Fornecedor:";
            // 
            // txtFornecedor
            // 
            txtFornecedor.Font = new Font("Segoe UI", 10F);
            txtFornecedor.Location = new Point(20, 121);
            txtFornecedor.MaxLength = 200;
            txtFornecedor.Name = "txtFornecedor";
            txtFornecedor.Size = new Size(400, 30);
            txtFornecedor.TabIndex = 4;
            // 
            // lblQuantidade
            // 
            lblQuantidade.AutoSize = true;
            lblQuantidade.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblQuantidade.Location = new Point(440, 95);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(103, 23);
            lblQuantidade.TabIndex = 5;
            lblQuantidade.Text = "Quantidade:";
            // 
            // txtQuantidade
            // 
            txtQuantidade.Font = new Font("Segoe UI", 10F);
            txtQuantidade.Location = new Point(440, 121);
            txtQuantidade.MaxLength = 10;
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.Size = new Size(120, 30);
            txtQuantidade.TabIndex = 6;
            // 
            // lblCustoUnitario
            // 
            lblCustoUnitario.AutoSize = true;
            lblCustoUnitario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCustoUnitario.Location = new Point(580, 95);
            lblCustoUnitario.Name = "lblCustoUnitario";
            lblCustoUnitario.Size = new Size(119, 23);
            lblCustoUnitario.TabIndex = 7;
            lblCustoUnitario.Text = "Custo Unitário:";
            // 
            // txtCustoUnitario
            // 
            txtCustoUnitario.Font = new Font("Segoe UI", 10F);
            txtCustoUnitario.Location = new Point(580, 121);
            txtCustoUnitario.MaxLength = 20;
            txtCustoUnitario.Name = "txtCustoUnitario";
            txtCustoUnitario.Size = new Size(140, 30);
            txtCustoUnitario.TabIndex = 8;
            txtCustoUnitario.Text = "0,00";
            // 
            // lblLote
            // 
            lblLote.AutoSize = true;
            lblLote.Font = new Font("Segoe UI", 10F);
            lblLote.Location = new Point(20, 170);
            lblLote.Name = "lblLote";
            lblLote.Size = new Size(129, 23);
            lblLote.TabIndex = 9;
            lblLote.Text = "Nº Lote (opc.):";
            // 
            // txtLote
            // 
            txtLote.Font = new Font("Segoe UI", 10F);
            txtLote.Location = new Point(155, 167);
            txtLote.MaxLength = 100;
            txtLote.Name = "txtLote";
            txtLote.Size = new Size(200, 30);
            txtLote.TabIndex = 10;
            // 
            // lblValidade
            // 
            lblValidade.AutoSize = true;
            lblValidade.Font = new Font("Segoe UI", 10F);
            lblValidade.Location = new Point(375, 170);
            lblValidade.Name = "lblValidade";
            lblValidade.Size = new Size(123, 23);
            lblValidade.TabIndex = 11;
            lblValidade.Text = "Validade (opc.):";
            // 
            // txtValidade
            // 
            txtValidade.Font = new Font("Segoe UI", 10F);
            txtValidade.Location = new Point(504, 167);
            txtValidade.MaxLength = 100;
            txtValidade.Name = "txtValidade";
            txtValidade.PlaceholderText = "Ex: 12/2025";
            txtValidade.Size = new Size(150, 30);
            txtValidade.TabIndex = 12;
            // 
            // lblDataEntrada
            // 
            lblDataEntrada.AutoSize = true;
            lblDataEntrada.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDataEntrada.Location = new Point(740, 95);
            lblDataEntrada.Name = "lblDataEntrada";
            lblDataEntrada.Size = new Size(48, 23);
            lblDataEntrada.TabIndex = 13;
            lblDataEntrada.Text = "Data:";
            // 
            // dtpDataEntrada
            // 
            dtpDataEntrada.Font = new Font("Segoe UI", 10F);
            dtpDataEntrada.Format = DateTimePickerFormat.Short;
            dtpDataEntrada.Location = new Point(740, 121);
            dtpDataEntrada.Name = "dtpDataEntrada";
            dtpDataEntrada.Size = new Size(220, 30);
            dtpDataEntrada.TabIndex = 14;
            // 
            // panelBotoes
            // 
            panelBotoes.BackColor = Color.White;
            panelBotoes.Controls.Add(btnLimpar);
            panelBotoes.Controls.Add(btnRegistrar);
            panelBotoes.Dock = DockStyle.Top;
            panelBotoes.Location = new Point(0, 280);
            panelBotoes.Name = "panelBotoes";
            panelBotoes.Padding = new Padding(20, 10, 20, 10);
            panelBotoes.Size = new Size(1000, 70);
            panelBotoes.TabIndex = 2;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(0, 121, 214);
            btnRegistrar.Cursor = Cursors.Hand;
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(20, 15);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(200, 40);
            btnRegistrar.TabIndex = 0;
            btnRegistrar.Text = "Registrar Entrada";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.BackColor = Color.FromArgb(0, 121, 214);
            btnLimpar.Cursor = Cursors.Hand;
            btnLimpar.FlatAppearance.BorderSize = 0;
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLimpar.ForeColor = Color.White;
            btnLimpar.Location = new Point(240, 15);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(150, 40);
            btnLimpar.TabIndex = 1;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = false;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // panelGrid
            // 
            panelGrid.BackColor = Color.White;
            panelGrid.Controls.Add(dgvHistorico);
            panelGrid.Controls.Add(lblHistorico);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Location = new Point(0, 350);
            panelGrid.Name = "panelGrid";
            panelGrid.Padding = new Padding(20);
            panelGrid.Size = new Size(1000, 300);
            panelGrid.TabIndex = 3;
            // 
            // lblHistorico
            // 
            lblHistorico.Dock = DockStyle.Top;
            lblHistorico.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblHistorico.Location = new Point(20, 20);
            lblHistorico.Name = "lblHistorico";
            lblHistorico.Size = new Size(960, 30);
            lblHistorico.TabIndex = 0;
            lblHistorico.Text = "Últimas 50 Entradas Registradas:";
            lblHistorico.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvHistorico
            // 
            dgvHistorico.AllowUserToAddRows = false;
            dgvHistorico.AllowUserToDeleteRows = false;
            dgvHistorico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorico.BackgroundColor = Color.White;
            dgvHistorico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorico.Dock = DockStyle.Fill;
            dgvHistorico.Location = new Point(20, 50);
            dgvHistorico.MultiSelect = false;
            dgvHistorico.Name = "dgvHistorico";
            dgvHistorico.ReadOnly = true;
            dgvHistorico.RowHeadersWidth = 51;
            dgvHistorico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorico.Size = new Size(960, 230);
            dgvHistorico.TabIndex = 1;
            // 
            // FormEntradaMaterial
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
            Name = "FormEntradaMaterial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar Entrada de Material";
            panelCadastro.ResumeLayout(false);
            panelCadastro.PerformLayout();
            panelBotoes.ResumeLayout(false);
            panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorico).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Panel panelCadastro;
        private Label lblMaterial;
        private ComboBox cboMaterial;
        private Label lblInfoMaterial;
        private Label lblFornecedor;
        private TextBox txtFornecedor;
        private Label lblQuantidade;
        private TextBox txtQuantidade;
        private Label lblCustoUnitario;
        private TextBox txtCustoUnitario;
        private Label lblLote;
        private TextBox txtLote;
        private Label lblValidade;
        private TextBox txtValidade;
        private Label lblDataEntrada;
        private DateTimePicker dtpDataEntrada;
        private Panel panelBotoes;
        private Button btnRegistrar;
        private Button btnLimpar;
        private Panel panelGrid;
        private Label lblHistorico;
        private DataGridView dgvHistorico;
    }
}
