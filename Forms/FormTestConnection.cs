using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using SistemaAlmoxarifado.Models;
using Microsoft.Data.SqlClient;

namespace SistemaAlmoxarifado.Forms
{
    public partial class FormTestConnection : Form
    {
        public FormTestConnection()
        {
            InitializeComponent();
        }

        private void FormTestConnection_Load(object sender, EventArgs e)
        {
            LoadConnectionInfo();
        }

        private void LoadConnectionInfo()
        {
            using var context = new AlmoxarifadoDbContext();
            txtConnectionString.Text = context.Database.GetDbConnection().ConnectionString;
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            txtResult.AppendText("Testando conexão com SQL Server...\n\n");
            Application.DoEvents();

            try
            {
                using var context = new AlmoxarifadoDbContext();
                var connection = context.Database.GetDbConnection();
                
                connection.Open();
                
                txtResult.AppendText("? CONEXÃO ESTABELECIDA COM SUCESSO!\n\n");
                txtResult.ForeColor = System.Drawing.Color.Green;
                
                txtResult.AppendText($"Servidor: {connection.DataSource}\n");
                txtResult.AppendText($"Banco de dados: {connection.Database}\n");
                txtResult.AppendText($"Estado: {connection.State}\n\n");
                
                // Verifica se o banco existe
                using var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT DB_ID('SistemaAlmoxarifado')";
                var dbExists = cmd.ExecuteScalar() != DBNull.Value && cmd.ExecuteScalar() != null;
                
                txtResult.AppendText($"Banco 'SistemaAlmoxarifado' existe: {(dbExists ? "Sim" : "Não")}\n");
                
                if (dbExists)
                {
                    txtResult.AppendText("\nTabelas criadas:\n");
                    cmd.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' ORDER BY TABLE_NAME";
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        txtResult.AppendText($"  - {reader.GetString(0)}\n");
                    }
                }
                
                connection.Close();
            }
            catch (SqlException sqlEx)
            {
                txtResult.ForeColor = System.Drawing.Color.Red;
                txtResult.AppendText($"? ERRO DE CONEXÃO SQL\n\n");
                txtResult.AppendText($"Código: {sqlEx.Number}\n");
                txtResult.AppendText($"Mensagem: {sqlEx.Message}\n\n");
                
                txtResult.AppendText("SUGESTÕES:\n");
                switch (sqlEx.Number)
                {
                    case 53:
                    case -1:
                        txtResult.AppendText("1. Verifique se o SQL Server está em execução (services.msc)\n");
                        txtResult.AppendText("2. Abra AlmoxarifadoDbContext.cs e ajuste a connection string\n");
                        txtResult.AppendText("3. Verifique a instância correta (localhost ou localhost\\SQLEXPRESS)\n");
                        break;
                    case 4060:
                        txtResult.AppendText("1. O banco de dados não existe\n");
                        txtResult.AppendText("2. Clique em 'Criar Banco de Dados' para criá-lo\n");
                        break;
                    case 18456:
                        txtResult.AppendText("1. Erro de autenticação\n");
                        txtResult.AppendText("2. Verifique usuário e senha na connection string\n");
                        break;
                }
                
                txtResult.AppendText("\nVerifique as sugestões acima e ajuste a connection string.\n");
            }
            catch (Exception ex)
            {
                txtResult.ForeColor = System.Drawing.Color.Red;
                txtResult.AppendText($"? ERRO: {ex.Message}\n");
            }
        }

        private void btnCreateDatabase_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            txtResult.AppendText("Tentando criar o banco de dados...\n\n");
            Application.DoEvents();

            try
            {
                using var context = new AlmoxarifadoDbContext();
                context.Database.EnsureCreated();
                
                txtResult.AppendText("? Banco de dados criado com sucesso!\n\n");
                txtResult.ForeColor = System.Drawing.Color.Green;
                
                // Lista as tabelas criadas
                var connection = context.Database.GetDbConnection();
                connection.Open();
                
                using var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' ORDER BY TABLE_NAME";
                
                txtResult.AppendText("Tabelas criadas:\n");
                using var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtResult.AppendText($"  - {reader.GetString(0)}\n");
                }
                
                connection.Close();
            }
            catch (Exception ex)
            {
                txtResult.AppendText($"? Erro ao criar banco de dados:\n\n{ex.Message}\n");
                txtResult.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnOpenConfig_Click(object sender, EventArgs e)
        {
            try
            {
                var projectPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
                var configFile = System.IO.Path.Combine(projectPath, "..", "..", "..", "Models", "AlmoxarifadoDbContext.cs");
                configFile = System.IO.Path.GetFullPath(configFile);
                
                if (System.IO.File.Exists(configFile))
                {
                    System.Diagnostics.Process.Start("notepad.exe", configFile);
                }
                else
                {
                    MessageBox.Show(
                        "Arquivo de configuração não encontrado.\n\n" +
                        "Abra manualmente o arquivo:\n" +
                        "Models\\AlmoxarifadoDbContext.cs",
                        "Arquivo não encontrado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
