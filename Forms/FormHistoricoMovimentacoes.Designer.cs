namespace SistemaAlmoxarifado.Forms
{
    partial class FormHistoricoMovimentacoes
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
            panelSelecao = new Panel();
            btnConsultar = new Button();
            cboMaterial = new ComboBox();
            lblMaterial = new Label();
            panelInfo = new Panel();
            lblInfoMaterial = new Label();
            panelGrid = new Panel();
            dgvHistorico = new DataGridView();
            lblTotal = new Label();
            lblLegenda = new Label();
            panelSelecao.SuspendLayout();
            panelInfo.SuspendLayout();
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
            lblTitulo.Text = "Consultar Histórico de Movimentações";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelSelecao
            // 
            panelSelecao.BackColor = Color.White;
            panelSelecao.Controls.Add(btnConsultar);
            panelSelecao.Controls.Add(cboMaterial);
            panelSelecao.Controls.Add(lblMaterial);
            panelSelecao.Dock = DockStyle.Top;
            panelSelecao.Location = new Point(0, 60);
            panelSelecao.Name = "panelSelecao";
            panelSelecao.Padding = new Padding(20);
            panelSelecao.Size = new Size(1000, 100);
            panelSelecao.TabIndex = 1;
            // 
            // lblMaterial
            // 
            lblMaterial.AutoSize = true;
            lblMaterial.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblMaterial.Location = new Point(20, 20);
            lblMaterial.Name = "lblMaterial";
            lblMaterial.Size = new Size(172, 23);
            lblMaterial.TabIndex = 0;
            lblMaterial.Text = "Selecione o Material:";
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
            // btnConsultar
            // 
            btnConsultar.BackColor = Color.FromArgb(0, 121, 214);
            btnConsultar.Cursor = Cursors.Hand;
            btnConsultar.FlatAppearance.BorderSize = 0;
            btnConsultar.FlatStyle = FlatStyle.Flat;
            btnConsultar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnConsultar.ForeColor = Color.White;
            btnConsultar.Location = new Point(640, 40);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(180, 40);
            btnConsultar.TabIndex = 2;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = false;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // panelInfo
            // 
            panelInfo.BackColor = Color.White;
            panelInfo.Controls.Add(lblInfoMaterial);
            panelInfo.Dock = DockStyle.Top;
            panelInfo.Location = new Point(0, 160);
            panelInfo.Name = "panelInfo";
            panelInfo.Padding = new Padding(20, 10, 20, 10);
            panelInfo.Size = new Size(1000, 50);
            panelInfo.TabIndex = 2;
            // 
            // lblInfoMaterial
            // 
            lblInfoMaterial.Dock = DockStyle.Fill;
            lblInfoMaterial.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblInfoMaterial.ForeColor = Color.DarkBlue;
            lblInfoMaterial.Location = new Point(20, 10);
            lblInfoMaterial.Name = "lblInfoMaterial";
            lblInfoMaterial.Size = new Size(960, 30);
            lblInfoMaterial.TabIndex = 0;
            lblInfoMaterial.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelGrid
            // 
            panelGrid.BackColor = Color.White;
            panelGrid.Controls.Add(dgvHistorico);
            panelGrid.Controls.Add(lblTotal);
            panelGrid.Controls.Add(lblLegenda);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Location = new Point(0, 210);
            panelGrid.Name = "panelGrid";
            panelGrid.Padding = new Padding(20);
            panelGrid.Size = new Size(1000, 440);
            panelGrid.TabIndex = 3;
            // 
            // lblLegenda
            // 
            lblLegenda.Dock = DockStyle.Top;
            lblLegenda.Font = new Font("Segoe UI", 9F);
            lblLegenda.Location = new Point(20, 20);
            lblLegenda.Name = "lblLegenda";
            lblLegenda.Size = new Size(960, 25);
            lblLegenda.TabIndex = 0;
            lblLegenda.Text = "Legenda: Verde = Entrada | Laranja = Saída | Azul = Ajuste";
            lblLegenda.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            lblTotal.Dock = DockStyle.Top;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.Location = new Point(20, 45);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(960, 25);
            lblTotal.TabIndex = 1;
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvHistorico
            // 
            dgvHistorico.AllowUserToAddRows = false;
            dgvHistorico.AllowUserToDeleteRows = false;
            dgvHistorico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorico.BackgroundColor = Color.White;
            dgvHistorico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorico.Dock = DockStyle.Fill;
            dgvHistorico.Location = new Point(20, 70);
            dgvHistorico.MultiSelect = false;
            dgvHistorico.Name = "dgvHistorico";
            dgvHistorico.ReadOnly = true;
            dgvHistorico.RowHeadersWidth = 51;
            dgvHistorico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorico.Size = new Size(960, 350);
            dgvHistorico.TabIndex = 2;
            // 
            // FormHistoricoMovimentacoes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 650);
            Controls.Add(panelGrid);
            Controls.Add(panelInfo);
            Controls.Add(panelSelecao);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormHistoricoMovimentacoes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Histórico de Movimentações";
            panelSelecao.ResumeLayout(false);
            panelSelecao.PerformLayout();
            panelInfo.ResumeLayout(false);
            panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorico).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Panel panelSelecao;
        private Label lblMaterial;
        private ComboBox cboMaterial;
        private Button btnConsultar;
        private Panel panelInfo;
        private Label lblInfoMaterial;
        private Panel panelGrid;
        private Label lblLegenda;
        private Label lblTotal;
        private DataGridView dgvHistorico;
    }
}
