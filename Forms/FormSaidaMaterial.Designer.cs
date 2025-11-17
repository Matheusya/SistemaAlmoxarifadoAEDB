namespace SistemaAlmoxarifado.Forms
{
    partial class FormSaidaMaterial
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
            dtpDataSaida = new DateTimePicker();
            lblDataSaida = new Label();
            txtQuantidade = new TextBox();
            lblQuantidade = new Label();
            txtResponsavel = new TextBox();
            lblResponsavel = new Label();
            cboSetor = new ComboBox();
            lblSetor = new Label();
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
            lblTitulo.BackColor = Color.FromArgb(0
, 121, 214);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1000, 60);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar Saída de Material";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCadastro
            // 
            panelCadastro.BackColor = Color.White;
            panelCadastro.Controls.Add(lblInfoMaterial);
            panelCadastro.Controls.Add(dtpDataSaida);
            panelCadastro.Controls.Add(lblDataSaida);
            panelCadastro.Controls.Add(txtQuantidade);
            panelCadastro.Controls.Add(lblQuantidade);
            panelCadastro.Controls.Add(txtResponsavel);
            panelCadastro.Controls.Add(lblResponsavel);
            panelCadastro.Controls.Add(cboSetor);
            panelCadastro.Controls.Add(lblSetor);
            panelCadastro.Controls.Add(cboMaterial);
            panelCadastro.Controls.Add(lblMaterial);
            panelCadastro.Dock = DockStyle.Top;
            panelCadastro.Location = new Point(0, 60);
            panelCadastro.Name = "panelCadastro";
            panelCadastro.Padding = new Padding(20);
            panelCadastro.Size = new Size(1000, 180);
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
            cboMaterial.Size = new Size(600, 31);
            cboMaterial.TabIndex = 1;
            cboMaterial.SelectedIndexChanged += cboMaterial_SelectedIndexChanged;
            // 
            // lblInfoMaterial
            // 
            lblInfoMaterial.AutoSize = true;
            lblInfoMaterial.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblInfoMaterial.ForeColor = Color.DarkBlue;
            lblInfoMaterial.Location = new Point(640, 51);
            lblInfoMaterial.Name = "lblInfoMaterial";
            lblInfoMaterial.Size = new Size(0, 20);
            lblInfoMaterial.TabIndex = 2;
            // 
            // lblSetor
            // 
            lblSetor.AutoSize = true;
            lblSetor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSetor.Location = new Point(20, 95);
            lblSetor.Name = "lblSetor";
            lblSetor.Size = new Size(136, 23);
            lblSetor.TabIndex = 3;
            lblSetor.Text = "Setor Solicitante:";
            // 
            // cboSetor
            // 
            cboSetor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSetor.Font = new Font("Segoe UI", 10F);
            cboSetor.FormattingEnabled = true;
            cboSetor.Location = new Point(20, 121);
            cboSetor.Name = "cboSetor";
            cboSetor.Size = new Size(300, 31);
            cboSetor.TabIndex = 4;
            // 
            // lblResponsavel
            // 
            lblResponsavel.AutoSize = true;
            lblResponsavel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblResponsavel.Location = new Point(340, 95);
            lblResponsavel.Name = "lblResponsavel";
            lblResponsavel.Size = new Size(106, 23);
            lblResponsavel.TabIndex = 5;
            lblResponsavel.Text = "Responsável:";
            // 
            // txtResponsavel
            // 
            txtResponsavel.Font = new Font("Segoe UI", 10F);
            txtResponsavel.Location = new Point(340, 121);
            txtResponsavel.MaxLength = 200;
            txtResponsavel.Name = "txtResponsavel";
            txtResponsavel.Size = new Size(300, 30);
            txtResponsavel.TabIndex = 6;
            // 
            // lblQuantidade
            // 
            lblQuantidade.AutoSize = true;
            lblQuantidade.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblQuantidade.Location = new Point(660, 95);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(103, 23);
            lblQuantidade.TabIndex = 7;
            lblQuantidade.Text = "Quantidade:";
            // 
            // txtQuantidade
            // 
            txtQuantidade.Font = new Font("Segoe UI", 10F);
            txtQuantidade.Location = new Point(660, 121);
            txtQuantidade.MaxLength = 10;
            txtQuantidade.Name = "txtQuantidade";
            txtQuantidade.Size = new Size(120, 30);
            txtQuantidade.TabIndex = 8;
            // 
            // lblDataSaida
            // 
            lblDataSaida.AutoSize = true;
            lblDataSaida.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDataSaida.Location = new Point(800, 95);
            lblDataSaida.Name = "lblDataSaida";
            lblDataSaida.Size = new Size(48, 23);
            lblDataSaida.TabIndex = 9;
            lblDataSaida.Text = "Data:";
            // 
            // dtpDataSaida
            // 
            dtpDataSaida.Font = new Font("Segoe UI", 10F);
            dtpDataSaida.Format = DateTimePickerFormat.Short;
            dtpDataSaida.Location = new Point(800, 121);
            dtpDataSaida.Name = "dtpDataSaida";
            dtpDataSaida.Size = new Size(160, 30);
            dtpDataSaida.TabIndex = 10;
            // 
            // panelBotoes
            // 
            panelBotoes.BackColor = Color.White;
            panelBotoes.Controls.Add(btnLimpar);
            panelBotoes.Controls.Add(btnRegistrar);
            panelBotoes.Dock = DockStyle.Top;
            panelBotoes.Location = new Point(0, 240);
            panelBotoes.Name = "panelBotoes";
            panelBotoes.Padding = new Padding(20, 10, 20, 10);
            panelBotoes.Size = new Size(1000, 70);
            panelBotoes.TabIndex = 2;
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(0
, 121, 214);
            btnRegistrar.Cursor = Cursors.Hand;
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRegistrar.ForeColor = Color.White;
            btnRegistrar.Location = new Point(20, 15);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(200, 40);
            btnRegistrar.TabIndex = 0;
            btnRegistrar.Text = "Registrar Saída";
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
            panelGrid.Location = new Point(0, 310);
            panelGrid.Name = "panelGrid";
            panelGrid.Padding = new Padding(20);
            panelGrid.Size = new Size(1000, 340);
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
            lblHistorico.Text = "Últimas 50 Saídas Registradas:";
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
            dgvHistorico.Size = new Size(960, 270);
            dgvHistorico.TabIndex = 1;
            // 
            // FormSaidaMaterial
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
            Name = "FormSaidaMaterial";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar Saída de Material";
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
        private Label lblSetor;
        private ComboBox cboSetor;
        private Label lblResponsavel;
        private TextBox txtResponsavel;
        private Label lblQuantidade;
        private TextBox txtQuantidade;
        private Label lblDataSaida;
        private DateTimePicker dtpDataSaida;
        private Panel panelBotoes;
        private Button btnRegistrar;
        private Button btnLimpar;
        private Panel panelGrid;
        private Label lblHistorico;
        private DataGridView dgvHistorico;
    }
}
