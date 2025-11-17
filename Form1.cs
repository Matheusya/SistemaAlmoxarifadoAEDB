namespace SistemaAlmoxarifado
{
    /// <summary>
    /// Tela Inicial do Sistema
    /// </summary>
    public partial class Form1 : Form
    {
        private PictureBox? picRodape;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Sistema de Almoxarifado - Menu Principal";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Resize += Form1_Resize;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            CriarPictureBoxRodape();
            CentralizarBotoes();
            CentralizarLogoAEDB();
            CarregarLogoAEDB();
        }

        private void CarregarLogoAEDB()
        {
            try
            {
                string logoPath = Path.Combine(Application.StartupPath, "logoAEDB.png");
                if (File.Exists(logoPath))
                {
                    picLogoAEDB.Image = Image.FromFile(logoPath);
                }
                else
                {
                    // Logo não encontrado - PictureBox fica vazio
                    Console.WriteLine($"Logo não encontrado: {logoPath}");
                }
            }
            catch (Exception ex)
            {
                // Erro ao carregar logo - continua sem a imagem
                Console.WriteLine($"Erro ao carregar logo: {ex.Message}");
            }
        }

        private void CriarPictureBoxRodape()
        {
            picRodape = new PictureBox
            {
                Size = new Size(400, 100),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.Transparent,
                Visible = true
            };

            // Adicionar ao panelMenu
            panelMenu.Controls.Add(picRodape);
            picRodape.BringToFront();
            
            // Posicionar após criar
            PosicionarRodape();
        }

        private void Form1_Resize(object? sender, EventArgs e)
        {
            CentralizarBotoes();
            PosicionarRodape();
            CentralizarLogoAEDB();
        }

        private void CentralizarLogoAEDB()
        {
            if (picLogoAEDB != null && panelHeader != null)
            {
                // Centralizar horizontalmente no painel header
                int x = (panelHeader.Width - picLogoAEDB.Width) / 2;
                picLogoAEDB.Location = new Point(x, 10);
            }
        }

        private void PosicionarRodape()
        {
            if (picRodape == null) return;

            // Margens
            const int MARGEM_INFERIOR = 20;

            // Centralizar horizontalmente
            int x = (panelMenu.Width - picRodape.Width) / 2;
            
            // Posicionar no canto inferior
            int y = panelMenu.Height - picRodape.Height - MARGEM_INFERIOR;

            // Garantir valores mínimos
            if (x < 0) x = 0;
            if (y < 0) y = 0;

            picRodape.Location = new Point(x, y);
        }

        private void CentralizarBotoes()
        {
            // Dimensões dos botões
            const int LARGURA_BOTAO = 480;
            const int ALTURA_BOTAO = 70;
            const int ESPACAMENTO_HORIZONTAL = 80;
            const int ESPACAMENTO_VERTICAL = 30;

            // Calcular espaço total ocupado
            int larguraTotalBotoes = (LARGURA_BOTAO * 2) + ESPACAMENTO_HORIZONTAL;
            int alturaTotalBotoes = (ALTURA_BOTAO * 3) + (ESPACAMENTO_VERTICAL * 2);

            // Calcular posições centralizadas horizontalmente
            int xInicio = (panelMenu.Width - larguraTotalBotoes) / 2;

            // Calcular posições centralizadas verticalmente
            int yInicio = (panelMenu.Height - alturaTotalBotoes) / 2;

            // Garantir valores mínimos para evitar posições negativas
            if (xInicio < 20) xInicio = 20;
            if (yInicio < 20) yInicio = 20;

            // Posições das colunas
            int xEsquerda = xInicio;
            int xDireita = xInicio + LARGURA_BOTAO + ESPACAMENTO_HORIZONTAL;

            // Linha 1
            int y1 = yInicio;
            btnCadastroMateriais.Location = new Point(xEsquerda, y1);
            btnCadastroMateriais.Size = new Size(LARGURA_BOTAO, ALTURA_BOTAO);
            btnRelatorioPontoPedido.Location = new Point(xDireita, y1);
            btnRelatorioPontoPedido.Size = new Size(LARGURA_BOTAO, ALTURA_BOTAO);

            // Linha 2
            int y2 = y1 + ALTURA_BOTAO + ESPACAMENTO_VERTICAL;
            btnEntradaMaterial.Location = new Point(xEsquerda, y2);
            btnEntradaMaterial.Size = new Size(LARGURA_BOTAO, ALTURA_BOTAO);
            btnSaidaMaterial.Location = new Point(xDireita, y2);
            btnSaidaMaterial.Size = new Size(LARGURA_BOTAO, ALTURA_BOTAO);

            // Linha 3
            int y3 = y2 + ALTURA_BOTAO + ESPACAMENTO_VERTICAL;
            btnHistoricoMovimentacoes.Location = new Point(xEsquerda, y3);
            btnHistoricoMovimentacoes.Size = new Size(LARGURA_BOTAO, ALTURA_BOTAO);
            btnAjusteEstoque.Location = new Point(xDireita, y3);
            btnAjusteEstoque.Size = new Size(LARGURA_BOTAO, ALTURA_BOTAO);
        }

        // Gerenciamento de Materiais
        private void btnCadastroMateriais_Click(object sender, EventArgs e)
        {
            var form = new Forms.FormCadastroMateriais();
            form.ShowDialog();
        }

        // Relatório de Ponto de Pedido
        private void btnRelatorioPontoPedido_Click(object sender, EventArgs e)
        {
            var form = new Forms.FormRelatorioPontoPedido();
            form.ShowDialog();
        }

        // Registro de Entrada
        private void btnEntradaMaterial_Click(object sender, EventArgs e)
        {
            var form = new Forms.FormEntradaMaterial();
            form.ShowDialog();
        }

        // Registro de Saída
        private void btnSaidaMaterial_Click(object sender, EventArgs e)
        {
            var form = new Forms.FormSaidaMaterial();
            form.ShowDialog();
        }

        // Consultar Histórico
        private void btnHistoricoMovimentacoes_Click(object sender, EventArgs e)
        {
            var form = new Forms.FormHistoricoMovimentacoes();
            form.ShowDialog();
        }

        // Ajuste de Estoque
        private void btnAjusteEstoque_Click(object sender, EventArgs e)
        {
            var form = new Forms.FormAjusteEstoque();
            form.ShowDialog();
        }

        // Teste de Conexão SQL Server
        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            var form = new Forms.FormTestConnection();
            form.ShowDialog();
        }
    }
}
