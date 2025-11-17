namespace SistemaAlmoxarifado.Forms
{
    partial class FormAjusteEstoque
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
            txtJustificativa = new TextBox();
            lblJustificativa = new Label();
            txtNovaQuantidade = new TextBox();
            lblNovaQuantidade = new Label();
            txtEstoqueAtual = new TextBox();
            lblEstoqueAtual = new Label();
            lblInfoMaterial = new Label();
            cboMaterial = new ComboBox();
            lblMaterial = new Label();
            panelBotoes = new Panel();
            btnLimpar = new Button();
            btnAjustar = new Button();
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
            lblTitulo.BackColor = Color.FromArgb(0, 153, 188);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1000, 60);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Ajuste de Estoque - Inventário";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelCadastro
            // 
            panelCadastro.BackColor = Color.White;
            panelCadastro.Controls.Add(txtJustificativa);
            panelCadastro.Controls.Add(lblJustificativa);
            panelCadastro.Controls.Add(txtNovaQuantidade);
            panelCadastro.Controls.Add(lblNovaQuantidade);
            panelCadastro.Controls.Add(txtEstoqueAtual);
            panelCadastro.Controls.Add(lblEstoqueAtual);
            panelCadastro.Controls.Add(lblInfoMaterial);
            panelCadastro.Controls.Add(cboMaterial);
            panelCadastro.Controls.Add(lblMaterial);
            panelCadastro.Dock = DockStyle.Top;
            panelCadastro.Location = new Point(0, 60);
            panelCadastro.Name = "panelCadastro";
            panelCadastro.Padding = new Padding(20);
            panelCadastro.Size = new Size(1000, 240);
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
            // lblEstoqueAtual
            // 
            lblEstoqueAtual.AutoSize = true;
            lblEstoqueAtual.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblEstoqueAtual.Location = new Point(20, 95);
            lblEstoqueAtual.Name = "lblEstoqueAtual";
            lblEstoqueAtual.Size = new Size(116, 23);
            lblEstoqueAtual.TabIndex = 3;
            lblEstoqueAtual.Text = "Estoque Atual:";
            // 
            // txtEstoqueAtual
            // 
            txtEstoqueAtual.Font = new Font("Segoe UI", 10F);
            txtEstoqueAtual.Location = new Point(20, 121);
            txtEstoqueAtual.Name = "txtEstoqueAtual";
            txtEstoqueAtual.ReadOnly = true;
            txtEstoqueAtual.Size = new Size(150, 30);
            txtEstoqueAtual.TabIndex = 4;
            txtEstoqueAtual.TabStop = false;
            // 
            // lblNovaQuantidade
            // 
            lblNovaQuantidade.AutoSize = true;
            lblNovaQuantidade.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblNovaQuantidade.ForeColor = Color.DarkRed;
            lblNovaQuantidade.Location = new Point(190, 95);
            lblNovaQuantidade.Name = "lblNovaQuantidade";
            lblNovaQuantidade.Size = new Size(142, 23);
            lblNovaQuantidade.TabIndex = 5;
            lblNovaQuantidade.Text = "Nova Quantidade:";
            // 
            // txtNovaQuantidade
            // 
            txtNovaQuantidade.Font = new Font("Segoe UI", 10F);
            txtNovaQuantidade.Location = new Point(190, 121);
            txtNovaQuantidade.MaxLength = 10;
            txtNovaQuantidade.Name = "txtNovaQuantidade";
            txtNovaQuantidade.Size = new Size(150, 30);
            txtNovaQuantidade.TabIndex = 6;
            // 
            // lblJustificativa
            // 
            lblJustificativa.AutoSize = true;
            lblJustificativa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblJustificativa.ForeColor = Color.DarkRed;
            lblJustificativa.Location = new Point(20, 170);
            lblJustificativa.Name = "lblJustificativa";
            lblJustificativa.Size = new Size(191, 23);
            lblJustificativa.TabIndex = 7;
            lblJustificativa.Text = "Justificativa (obrigatória):";
            // 
            // txtJustificativa
            // 
            txtJustificativa.Font = new Font("Segoe UI", 10F);
            txtJustificativa.Location = new Point(20, 196);
            txtJustificativa.MaxLength = 500;
            txtJustificativa.Name = "txtJustificativa";
            txtJustificativa.PlaceholderText = "Ex: Inventário mensal, perda de material, ajuste por contagem física, etc.";
            txtJustificativa.Size = new Size(940, 30);
            txtJustificativa.TabIndex = 8;
            // 
            // panelBotoes
            // 
            panelBotoes.BackColor = Color.White;
            panelBotoes.Controls.Add(btnLimpar);
            panelBotoes.Controls.Add(btnAjustar);
            panelBotoes.Dock = DockStyle.Top;
            panelBotoes.Location = new Point(0, 300);
            panelBotoes.Name = "panelBotoes";
            panelBotoes.Padding = new Padding(20, 10, 20, 10);
            panelBotoes.Size = new Size(1000, 70);
            panelBotoes.TabIndex = 2;
            // 
            // btnAjustar
            // 
            btnAjustar.BackColor = Color.FromArgb(0, 153, 188);
            btnAjustar.Cursor = Cursors.Hand;
            btnAjustar.FlatAppearance.BorderSize = 0;
            btnAjustar.FlatStyle = FlatStyle.Flat;
            btnAjustar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAjustar.ForeColor = Color.White;
            btnAjustar.Location = new Point(20, 15);
            btnAjustar.Name = "btnAjustar";
            btnAjustar.Size = new Size(200, 40);
            btnAjustar.TabIndex = 0;
            btnAjustar.Text = "Realizar Ajuste";
            btnAjustar.UseVisualStyleBackColor = false;
            btnAjustar.Click += btnAjustar_Click;
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
            panelGrid.Location = new Point(0, 370);
            panelGrid.Name = "panelGrid";
            panelGrid.Padding = new Padding(20);
            panelGrid.Size = new Size(1000, 280);
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
            lblHistorico.Text = "Últimos 50 Ajustes Realizados:";
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
            dgvHistorico.Size = new Size(960, 210);
            dgvHistorico.TabIndex = 1;
            // 
            // FormAjusteEstoque
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
            Name = "FormAjusteEstoque";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ajuste de Estoque";
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
        private Label lblEstoqueAtual;
        private TextBox txtEstoqueAtual;
        private Label lblNovaQuantidade;
        private TextBox txtNovaQuantidade;
        private Label lblJustificativa;
        private TextBox txtJustificativa;
        private Panel panelBotoes;
        private Button btnAjustar;
        private Button btnLimpar;
        private Panel panelGrid;
        private Label lblHistorico;
        private DataGridView dgvHistorico;
    }
}
