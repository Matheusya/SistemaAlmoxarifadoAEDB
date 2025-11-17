# Sistema de Almoxarifado

Sistema de gestão de almoxarifado desenvolvido em .NET 10 com Windows Forms para controle de materiais, entradas, saídas e estoque.

## Requisitos

- .NET 10 SDK
- SQL Server ou SQL Server Express
- Windows OS

## Como Executar

1. Clone o repositório
2. Abra o projeto no Visual Studio 2022 ou VS Code
3. Configure a conexão com o banco de dados em `Models\AlmoxarifadoDbContext.cs`
4. Execute o comando:
```bash
dotnet run
```

## Configuração do Banco de Dados

### SQL Server Express (Padrão)
A aplicação está configurada para usar SQL Server Express por padrão:
```
Server=localhost\SQLEXPRESS;Database=SistemaAlmoxarifado
```



## Funcionalidades

### Gestão de Materiais
- Cadastro de materiais
- Edição e exclusão
- Busca e filtros
- Controle de estoque mínimo

### Movimentações
- Registro de entradas de material
- Registro de saídas de material
- Ajuste de estoque (inventário)
- Histórico completo de movimentações

### Relatórios
- Relatório de ponto de pedido
- Materiais abaixo do estoque mínimo
- Consulta de movimentações por período

### Ferramentas
- Teste de conexão SQL
- Criação automática do banco de dados
- Dados de exemplo para testes

## Estrutura do Banco de Dados

O sistema cria automaticamente 4 tabelas:

- **Materiais**: Cadastro de materiais
- **EntradasMateriais**: Registro de entradas
- **SaidasMateriais**: Registro de saídas
- **AjustesEstoque**: Ajustes de inventário

## Interface

- Cor padrão: **#0079D6** (Azul Microsoft)
- Design limpo e intuitivo
- Layout responsivo
- Totalmente em português

## Tecnologias

- **.NET 10**
- **Windows Forms**
- **Entity Framework Core 10.0**
- **SQL Server**

## Primeiro Uso

1. Execute a aplicação
2. O sistema tentará conectar ao banco de dados
3. Se o banco não existir, será criado automaticamente
4. Opcionalmente, insira dados de exemplo (15 materiais de teste)
5. Comece a usar!

## Teste de Conexão

Use o botão **" Testar Conexão SQL"** na tela principal para:
- Verificar se o SQL Server está acessível
- Ver informações de conexão
- Criar o banco de dados manualmente
- Diagnosticar problemas


## Solução de Problemas

### Erro de Conexão
1. Verifique se o SQL Server está rodando (Execute `services.msc`)
2. Confirme a instância correta (SQLEXPRESS ou padrão)
3. Use o botão "Testar Conexão SQL" para diagnóstico

### Banco não Criado
1. Clique em " Testar Conexão SQL"
2. Use o botão "Criar Banco de Dados"
3. Ou execute manualmente o script `Database\CreateDatabase.sql`

## Licença

Este projeto foi desenvolvido para fins educacionais.

## Autor

Desenvolvido com .NET 10 e Entity Framework Core

Time de Desenvolvimento: Samuel José Dias, João Pedro Frech Soares,
Matheus Yuri Andrade Rosa, Flávio Nobrega Normanda, Pedro Riboura Vargas Figueiredo,
Fernando Silva Marassi, Paulo Vitor da Silva Costa

Centro Universitário UniDomBosco - RJ, Resende - RJ.
