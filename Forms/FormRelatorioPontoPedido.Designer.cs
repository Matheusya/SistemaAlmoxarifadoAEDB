namespace SistemaAlmoxarifado.Forms
{
    partial class FormRelatorioPontoPedido
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
            panelInfo = new Panel();
            lblDescricao = new Label();
            panelBotoes = new Panel();
            btnImprimir = new Button();
            btnAtualizar = new Button();
            panelGrid = new Panel();
            dgvPontoPedido = new DataGridView();
            lblTotal = new Label();
            panelInfo.SuspendLayout();
            panelBotoes.SuspendLayout();
            panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPontoPedido).BeginInit();
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
            lblTitulo.Text = "Relatório de Ponto de Pedido";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelInfo
            // 
            panelInfo.BackColor = Color.FromArgb(255, 240, 240);
            panelInfo.Controls.Add(lblDescricao);
            panelInfo.Dock = DockStyle.Top;
            panelInfo.Location = new Point(0, 60);
            panelInfo.Name = "panelInfo";
            panelInfo.Padding = new Padding(20);
            panelInfo.Size = new Size(1000, 100);
            panelInfo.TabIndex = 1;
            // 
            // lblDescricao
            // 
            lblDescricao.Dock = DockStyle.Fill;
            lblDescricao.Font = new Font("Segoe UI", 10F);
            lblDescricao.Location = new Point(20, 20);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(960, 60);
            lblDescricao.TabIndex = 0;
            lblDescricao.Text = "Este relatório mostra todos os materiais onde o Estoque Atual está menor ou igual ao Estoque Mínimo.\r\nMateriais com estoque ZERADO aparecem em vermelho e materiais CRÍTICOS em laranja.";
            lblDescricao.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panelBotoes
            // 
            panelBotoes.BackColor = Color.White;
            panelBotoes.Controls.Add(btnImprimir);
            panelBotoes.Controls.Add(btnAtualizar);
            panelBotoes.Dock = DockStyle.Top;
            panelBotoes.Location = new Point(0, 160);
            panelBotoes.Name = "panelBotoes";
            panelBotoes.Padding = new Padding(20, 10, 20, 10);
            panelBotoes.Size = new Size(1000, 70);
            panelBotoes.TabIndex = 2;
            // 
            // btnAtualizar
            // 
            btnAtualizar.BackColor = Color.FromArgb(0, 121, 214);
            btnAtualizar.Cursor = Cursors.Hand;
            btnAtualizar.FlatAppearance.BorderSize = 0;
            btnAtualizar.FlatStyle = FlatStyle.Flat;
            btnAtualizar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnAtualizar.ForeColor = Color.White;
            btnAtualizar.Location = new Point(20, 15);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(180, 40);
            btnAtualizar.TabIndex = 0;
            btnAtualizar.Text = "Atualizar Relatório";
            btnAtualizar.UseVisualStyleBackColor = false;
            btnAtualizar.Click += btnAtualizar_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.BackColor = Color.FromArgb(0, 121, 214);
            btnImprimir.Cursor = Cursors.Hand;
            btnImprimir.FlatAppearance.BorderSize = 0;
            btnImprimir.FlatStyle = FlatStyle.Flat;
            btnImprimir.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnImprimir.ForeColor = Color.White;
            btnImprimir.Location = new Point(220, 15);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(180, 40);
            btnImprimir.TabIndex = 1;
            btnImprimir.Text = "Imprimir";
            btnImprimir.UseVisualStyleBackColor = false;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // panelGrid
            // 
            panelGrid.BackColor = Color.White;
            panelGrid.Controls.Add(dgvPontoPedido);
            panelGrid.Controls.Add(lblTotal);
            panelGrid.Dock = DockStyle.Fill;
            panelGrid.Location = new Point(0, 230);
            panelGrid.Name = "panelGrid";
            panelGrid.Padding = new Padding(20);
            panelGrid.Size = new Size(1000, 420);
            panelGrid.TabIndex = 3;
            // 
            // lblTotal
            // 
            lblTotal.Dock = DockStyle.Top;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.Location = new Point(20, 20);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(960, 30);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total de materiais em ponto de pedido: 0";
            lblTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvPontoPedido
            // 
            dgvPontoPedido.AllowUserToAddRows = false;
            dgvPontoPedido.AllowUserToDeleteRows = false;
            dgvPontoPedido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPontoPedido.BackgroundColor = Color.White;
            dgvPontoPedido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPontoPedido.Dock = DockStyle.Fill;
            dgvPontoPedido.Location = new Point(20, 50);
            dgvPontoPedido.MultiSelect = false;
            dgvPontoPedido.Name = "dgvPontoPedido";
            dgvPontoPedido.ReadOnly = true;
            dgvPontoPedido.RowHeadersWidth = 51;
            dgvPontoPedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPontoPedido.Size = new Size(960, 350);
            dgvPontoPedido.TabIndex = 1;
            // 
            // FormRelatorioPontoPedido
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 650);
            Controls.Add(panelGrid);
            Controls.Add(panelBotoes);
            Controls.Add(panelInfo);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormRelatorioPontoPedido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Relatório de Ponto de Pedido";
            panelInfo.ResumeLayout(false);
            panelBotoes.ResumeLayout(false);
            panelGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPontoPedido).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Panel panelInfo;
        private Label lblDescricao;
        private Panel panelBotoes;
        private Button btnAtualizar;
        private Button btnImprimir;
        private Panel panelGrid;
        private Label lblTotal;
        private DataGridView dgvPontoPedido;
    }
}
