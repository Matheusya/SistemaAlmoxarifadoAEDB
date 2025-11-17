namespace SistemaAlmoxarifado
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelHeader = new Panel();
            picLogoAEDB = new PictureBox();
            lblTitulo = new Label();
            btnCadastroMateriais = new Button();
            btnRelatorioPontoPedido = new Button();
            btnEntradaMaterial = new Button();
            btnSaidaMaterial = new Button();
            btnHistoricoMovimentacoes = new Button();
            btnAjusteEstoque = new Button();
            panelMenu = new Panel();
            lblSubtitulo = new Label();
            btnTestConnection = new Button();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(picLogoAEDB)).BeginInit();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(0, 121, 214);
            panelHeader.Controls.Add(picLogoAEDB);
            panelHeader.Controls.Add(lblTitulo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1050, 120);
            panelHeader.TabIndex = 0;
            // 
            // picLogoAEDB
            // 
            picLogoAEDB.BackColor = Color.Transparent;
            picLogoAEDB.Location = new Point(425, 10);
            picLogoAEDB.Name = "picLogoAEDB";
            picLogoAEDB.Size = new Size(200, 60);
            picLogoAEDB.SizeMode = PictureBoxSizeMode.Zoom;
            picLogoAEDB.TabIndex = 1;
            picLogoAEDB.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.Transparent;
            lblTitulo.Dock = DockStyle.Bottom;
            lblTitulo.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 75);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1050, 45);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "SISTEMA DE ALMOXARIFADO";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCadastroMateriais
            // 
            btnCadastroMateriais.BackColor = Color.FromArgb(0, 121, 214);
            btnCadastroMateriais.Cursor = Cursors.Hand;
            btnCadastroMateriais.FlatAppearance.BorderSize = 0;
            btnCadastroMateriais.FlatStyle = FlatStyle.Flat;
            btnCadastroMateriais.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnCadastroMateriais.ForeColor = Color.White;
            btnCadastroMateriais.Location = new Point(61, 45);
            btnCadastroMateriais.Margin = new Padding(3, 2, 3, 2);
            btnCadastroMateriais.Name = "btnCadastroMateriais";
            btnCadastroMateriais.Size = new Size(368, 39);
            btnCadastroMateriais.TabIndex = 0;
            btnCadastroMateriais.Text = "Cadastro de Materiais";
            btnCadastroMateriais.UseVisualStyleBackColor = false;
            btnCadastroMateriais.Click += btnCadastroMateriais_Click;
            // 
            // btnRelatorioPontoPedido
            // 
            btnRelatorioPontoPedido.BackColor = Color.FromArgb(0, 121, 214);
            btnRelatorioPontoPedido.Cursor = Cursors.Hand;
            btnRelatorioPontoPedido.FlatAppearance.BorderSize = 0;
            btnRelatorioPontoPedido.FlatStyle = FlatStyle.Flat;
            btnRelatorioPontoPedido.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnRelatorioPontoPedido.ForeColor = Color.White;
            btnRelatorioPontoPedido.Location = new Point(490, 45);
            btnRelatorioPontoPedido.Margin = new Padding(3, 2, 3, 2);
            btnRelatorioPontoPedido.Name = "btnRelatorioPontoPedido";
            btnRelatorioPontoPedido.Size = new Size(368, 39);
            btnRelatorioPontoPedido.TabIndex = 1;
            btnRelatorioPontoPedido.Text = "Relatório de Ponto de Pedido";
            btnRelatorioPontoPedido.UseVisualStyleBackColor = false;
            btnRelatorioPontoPedido.Click += btnRelatorioPontoPedido_Click;
            // 
            // btnEntradaMaterial
            // 
            btnEntradaMaterial.BackColor = Color.FromArgb(0, 121, 214);
            btnEntradaMaterial.Cursor = Cursors.Hand;
            btnEntradaMaterial.FlatAppearance.BorderSize = 0;
            btnEntradaMaterial.FlatStyle = FlatStyle.Flat;
            btnEntradaMaterial.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnEntradaMaterial.ForeColor = Color.White;
            btnEntradaMaterial.Location = new Point(61, 101);
            btnEntradaMaterial.Margin = new Padding(3, 2, 3, 2);
            btnEntradaMaterial.Name = "btnEntradaMaterial";
            btnEntradaMaterial.Size = new Size(368, 39);
            btnEntradaMaterial.TabIndex = 2;
            btnEntradaMaterial.Text = "Registrar Entrada de Material";
            btnEntradaMaterial.UseVisualStyleBackColor = false;
            btnEntradaMaterial.Click += btnEntradaMaterial_Click;
            // 
            // btnSaidaMaterial
            // 
            btnSaidaMaterial.BackColor = Color.FromArgb(0, 121, 214);
            btnSaidaMaterial.Cursor = Cursors.Hand;
            btnSaidaMaterial.FlatAppearance.BorderSize = 0;
            btnSaidaMaterial.FlatStyle = FlatStyle.Flat;
            btnSaidaMaterial.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnSaidaMaterial.ForeColor = Color.White;
            btnSaidaMaterial.Location = new Point(490, 101);
            btnSaidaMaterial.Margin = new Padding(3, 2, 3, 2);
            btnSaidaMaterial.Name = "btnSaidaMaterial";
            btnSaidaMaterial.Size = new Size(368, 39);
            btnSaidaMaterial.TabIndex = 3;
            btnSaidaMaterial.Text = "Registrar Saída de Material";
            btnSaidaMaterial.UseVisualStyleBackColor = false;
            btnSaidaMaterial.Click += btnSaidaMaterial_Click;
            // 
            // btnHistoricoMovimentacoes
            // 
            btnHistoricoMovimentacoes.BackColor = Color.FromArgb(0, 121, 214);
            btnHistoricoMovimentacoes.Cursor = Cursors.Hand;
            btnHistoricoMovimentacoes.FlatAppearance.BorderSize = 0;
            btnHistoricoMovimentacoes.FlatStyle = FlatStyle.Flat;
            btnHistoricoMovimentacoes.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnHistoricoMovimentacoes.ForeColor = Color.White;
            btnHistoricoMovimentacoes.Location = new Point(61, 158);
            btnHistoricoMovimentacoes.Margin = new Padding(3, 2, 3, 2);
            btnHistoricoMovimentacoes.Name = "btnHistoricoMovimentacoes";
            btnHistoricoMovimentacoes.Size = new Size(368, 39);
            btnHistoricoMovimentacoes.TabIndex = 4;
            btnHistoricoMovimentacoes.Text = "Consultar Histórico de Movimentações";
            btnHistoricoMovimentacoes.UseVisualStyleBackColor = false;
            btnHistoricoMovimentacoes.Click += btnHistoricoMovimentacoes_Click;
            // 
            // btnAjusteEstoque
            // 
            btnAjusteEstoque.BackColor = Color.FromArgb(0, 121, 214);
            btnAjusteEstoque.Cursor = Cursors.Hand;
            btnAjusteEstoque.FlatAppearance.BorderSize = 0;
            btnAjusteEstoque.FlatStyle = FlatStyle.Flat;
            btnAjusteEstoque.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnAjusteEstoque.ForeColor = Color.White;
            btnAjusteEstoque.Location = new Point(490, 158);
            btnAjusteEstoque.Margin = new Padding(3, 2, 3, 2);
            btnAjusteEstoque.Name = "btnAjusteEstoque";
            btnAjusteEstoque.Size = new Size(368, 39);
            btnAjusteEstoque.TabIndex = 5;
            btnAjusteEstoque.Text = "Ajuste de Estoque - Inventário";
            btnAjusteEstoque.UseVisualStyleBackColor = false;
            btnAjusteEstoque.Click += btnAjusteEstoque_Click;
            // 
            // btnTestConnection
            // 
            btnTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            btnTestConnection.BackColor = Color.FromArgb(0, 97, 171);
            btnTestConnection.Cursor = Cursors.Hand;
            btnTestConnection.FlatAppearance.BorderSize = 0;
            btnTestConnection.FlatStyle = FlatStyle.Flat;
            btnTestConnection.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTestConnection.ForeColor = Color.White;
            btnTestConnection.Location = new Point(870, 333);
            btnTestConnection.Margin = new Padding(3, 2, 3, 2);
            btnTestConnection.Name = "btnTestConnection";
            btnTestConnection.Size = new Size(160, 30);
            btnTestConnection.TabIndex = 6;
            btnTestConnection.Text = "🔧 Testar Conexão SQL";
            btnTestConnection.UseVisualStyleBackColor = false;
            btnTestConnection.Click += btnTestConnection_Click;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.White;
            panelMenu.Controls.Add(btnTestConnection);
            panelMenu.Controls.Add(btnAjusteEstoque);
            panelMenu.Controls.Add(btnHistoricoMovimentacoes);
            panelMenu.Controls.Add(btnSaidaMaterial);
            panelMenu.Controls.Add(btnEntradaMaterial);
            panelMenu.Controls.Add(btnRelatorioPontoPedido);
            panelMenu.Controls.Add(btnCadastroMateriais);
            panelMenu.Dock = DockStyle.Fill;
            panelMenu.Location = new Point(0, 142);
            panelMenu.Margin = new Padding(3, 2, 3, 2);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(1050, 360);
            panelMenu.TabIndex = 2;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.BackColor = Color.FromArgb(0, 97, 171);
            lblSubtitulo.Dock = DockStyle.Top;
            lblSubtitulo.Font = new Font("Segoe UI", 12F);
            lblSubtitulo.ForeColor = Color.White;
            lblSubtitulo.Location = new Point(0, 120);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(1050, 22);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Selecione uma opção abaixo para começar";
            lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1050, 502);
            Controls.Add(panelMenu);
            Controls.Add(lblSubtitulo);
            Controls.Add(panelHeader);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Almoxarifado";
            panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(picLogoAEDB)).EndInit();
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private PictureBox picLogoAEDB;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Panel panelMenu;
        private Button btnCadastroMateriais;
        private Button btnRelatorioPontoPedido;
        private Button btnEntradaMaterial;
        private Button btnSaidaMaterial;
        private Button btnHistoricoMovimentacoes;
        private Button btnAjusteEstoque;
        private Button btnTestConnection;
    }
}
