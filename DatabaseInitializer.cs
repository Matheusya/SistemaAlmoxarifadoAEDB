using SistemaAlmoxarifado.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace SistemaAlmoxarifado
{
    public static class DatabaseInitializer
    {
        public static void Initialize()
        {
            try
            {
                using var context = new AlmoxarifadoDbContext();
                
                // Criar o banco de dados se não existir
                var dbCreated = context.Database.EnsureCreated();
                
                if (dbCreated)
                {
                    MessageBox.Show(
                        "Banco de dados 'SistemaAlmoxarifado' criado com sucesso!\n\n" +
                        "As tabelas foram criadas:\n" +
                        "- Materiais\n" +
                        "- EntradasMateriais\n" +
                        "- SaidasMateriais\n" +
                        "- AjustesEstoque",
                        "Banco de Dados Criado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                // Verificar se já existem dados
                if (!context.Materiais.Any())
                {
                    SeedData(context);
                }
            }
            catch (SqlException sqlEx)
            {
                string errorMessage = $"Erro de SQL Server (Código {sqlEx.Number}):\n\n{sqlEx.Message}\n\n";
                
                switch (sqlEx.Number)
                {
                    case 53:
                    case -1:
                        errorMessage += "SUGESTÕES:\n" +
                                      "1. Verifique se o SQL Server está em execução (services.msc)\n" +
                                      "2. Abra o AlmoxarifadoDbContext.cs e ajuste a connection string\n" +
                                      "3. Se usa SQL Server Express, verifique a OPÇÃO 2";
                        break;
                    case 4060:
                        errorMessage += "O sistema tentará criar o banco automaticamente.\n" +
                                      "Se o erro persistir, execute o script CreateDatabase.sql manualmente.";
                        break;
                }
                
                MessageBox.Show(errorMessage, "Erro de Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao inicializar o banco de dados:\n\n{ex.Message}\n\n" +
                    $"Tipo: {ex.GetType().Name}\n\n" +
                    $"Verifique a connection string no arquivo AlmoxarifadoDbContext.cs",
                    "Erro de Banco de Dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                throw;
            }
        }

        private static void SeedData(AlmoxarifadoDbContext context)
        {
            var resultado = MessageBox.Show(
                "Deseja inserir dados de exemplo no banco de dados?\n\n" +
                "Isso incluirá materiais de Limpeza, Laboratório e Escritório para teste.",
                "Dados de Exemplo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado != DialogResult.Yes)
            {
                return;
            }

            try
            {
                // Materiais de Limpeza
                var materiaisLimpeza = new List<Material>
                {
                    new Material { Codigo = "LIMP001", Nome = "Detergente Neutro", UnidadeMedida = "L", Classificacao = "Limpeza", EstoqueMinimo = 10, EstoqueAtual = 15 },
                    new Material { Codigo = "LIMP002", Nome = "Água Sanitária", UnidadeMedida = "L", Classificacao = "Limpeza", EstoqueMinimo = 15, EstoqueAtual = 8 },
                    new Material { Codigo = "LIMP003", Nome = "Sabonete Líquido", UnidadeMedida = "L", Classificacao = "Limpeza", EstoqueMinimo = 20, EstoqueAtual = 5 },
                    new Material { Codigo = "LIMP004", Nome = "Papel Toalha", UnidadeMedida = "Fardo", Classificacao = "Limpeza", EstoqueMinimo = 5, EstoqueAtual = 3 },
                    new Material { Codigo = "LIMP005", Nome = "Saco de Lixo 100L", UnidadeMedida = "PC", Classificacao = "Limpeza", EstoqueMinimo = 50, EstoqueAtual = 60 }
                };

                // Materiais de Laboratório
                var materiaisLaboratorio = new List<Material>
                {
                    new Material { Codigo = "LAB001", Nome = "Ácido Clorídrico 1L", UnidadeMedida = "L", Classificacao = "Laboratório", EstoqueMinimo = 5, EstoqueAtual = 3 },
                    new Material { Codigo = "LAB002", Nome = "Hidróxido de Sódio 500g", UnidadeMedida = "KG", Classificacao = "Laboratório", EstoqueMinimo = 3, EstoqueAtual = 2 },
                    new Material { Codigo = "LAB003", Nome = "Luvas Descartáveis M", UnidadeMedida = "CX", Classificacao = "Laboratório", EstoqueMinimo = 10, EstoqueAtual = 7 },
                    new Material { Codigo = "LAB004", Nome = "Béquer de Vidro 250ml", UnidadeMedida = "UN", Classificacao = "Laboratório", EstoqueMinimo = 20, EstoqueAtual = 15 },
                    new Material { Codigo = "LAB005", Nome = "Pipeta Graduada 10ml", UnidadeMedida = "UN", Classificacao = "Laboratório", EstoqueMinimo = 15, EstoqueAtual = 10 }
                };

                // Materiais de Escritório
                var materiaisEscritorio = new List<Material>
                {
                    new Material { Codigo = "ESC001", Nome = "Papel A4 Sulfite", UnidadeMedida = "Resma", Classificacao = "Escritório", EstoqueMinimo = 20, EstoqueAtual = 25 },
                    new Material { Codigo = "ESC002", Nome = "Caneta Esferográfica Azul", UnidadeMedida = "CX", Classificacao = "Escritório", EstoqueMinimo = 10, EstoqueAtual = 12 },
                    new Material { Codigo = "ESC003", Nome = "Grampeador", UnidadeMedida = "UN", Classificacao = "Escritório", EstoqueMinimo = 5, EstoqueAtual = 4 },
                    new Material { Codigo = "ESC004", Nome = "Pasta Suspensa", UnidadeMedida = "CX", Classificacao = "Escritório", EstoqueMinimo = 5, EstoqueAtual = 2 },
                    new Material { Codigo = "ESC005", Nome = "Clips para Papel", UnidadeMedida = "CX", Classificacao = "Escritório", EstoqueMinimo = 8, EstoqueAtual = 6 }
                };

                context.Materiais.AddRange(materiaisLimpeza);
                context.Materiais.AddRange(materiaisLaboratorio);
                context.Materiais.AddRange(materiaisEscritorio);

                context.SaveChanges();

                MessageBox.Show(
                    "Dados de exemplo inseridos com sucesso!\n\n" +
                    $"- {materiaisLimpeza.Count} materiais de Limpeza\n" +
                    $"- {materiaisLaboratorio.Count} materiais de Laboratório\n" +
                    $"- {materiaisEscritorio.Count} materiais de Escritório\n\n" +
                    "Total: 15 materiais cadastrados.",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao inserir dados de exemplo:\n\n{ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static bool CanConnect()
        {
            try
            {
                using var context = new AlmoxarifadoDbContext();
                return context.Database.CanConnect();
            }
            catch
            {
                return false;
            }
        }

        public static string GetConnectionInfo()
        {
            using var context = new AlmoxarifadoDbContext();
            return context.Database.GetDbConnection().ConnectionString ?? "Não configurada";
        }
    }
}
