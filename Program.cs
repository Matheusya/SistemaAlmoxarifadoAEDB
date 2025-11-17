namespace SistemaAlmoxarifado
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {
            // Configuração da aplicação
            ApplicationConfiguration.Initialize();

            try
            {
                // Inicializar banco de dados
                DatabaseInitializer.Initialize();

                // Executar aplicação
                Application.Run(new Form1());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao iniciar a aplicação:\n\n{ex.Message}\n\n" +
                    "Verifique a configuração do banco de dados e tente novamente.",
                    "Erro Fatal",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}