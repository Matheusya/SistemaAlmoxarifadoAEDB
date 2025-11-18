# Diagramas de Fluxo - Sistema de Almoxarifado

## Fluxo de Inicialização do Sistema

Este fluxo demonstra como o sistema inicializa e configura o banco de dados automaticamente ao ser executado pela primeira vez. O processo verifica se o banco existe, cria a estrutura necessária e oferece a opção de popular com dados de exemplo para facilitar os testes iniciais.

```mermaid
sequenceDiagram
    participant U as Usuário
    participant App as Aplicação
    participant DB as DatabaseInitializer
    participant EF as Entity Framework
    participant SQL as SQL Server

    U->>App: Inicia aplicação
    App->>DB: Initialize()
    DB->>EF: EnsureCreated()
    EF->>SQL: Conectar
    
    alt Banco não existe
        SQL-->>EF: Banco não encontrado
        EF->>SQL: CREATE DATABASE SistemaAlmoxarifado
        EF->>SQL: CREATE TABLE Materiais
        EF->>SQL: CREATE TABLE EntradasMateriais
        EF->>SQL: CREATE TABLE SaidasMateriais
        EF->>SQL: CREATE TABLE AjustesEstoque
        SQL-->>EF: Tabelas criadas
        DB->>U: Exibe: "Banco criado com sucesso!"
        DB->>U: Pergunta: "Inserir dados de exemplo?"
        
        alt Usuário aceita
            U->>DB: Sim
            DB->>EF: AddRange(15 materiais)
            EF->>SQL: INSERT INTO Materiais
            SQL-->>DB: Dados inseridos
            DB->>U: "15 materiais cadastrados"
        end
    end
    
    EF-->>DB: Conexão estabelecida
    DB-->>App: Inicialização completa
    App->>U: Exibe tela principal
```

---

## Fluxo de Cadastro de Material

Este fluxo ilustra o processo completo de cadastramento de um novo material no sistema. Inclui validação de dados, verificação de duplicidade de código e atualização automática da listagem após o cadastro bem-sucedido.

```mermaid
sequenceDiagram
    participant U as Usuário
    participant Form as FormCadastroMateriais
    participant EF as Entity Framework
    participant SQL as SQL Server

    U->>Form: Clica "Cadastro de Materiais"
    Form->>EF: Carregar materiais existentes
    EF->>SQL: SELECT * FROM Materiais
    SQL-->>EF: Lista de materiais
    EF-->>Form: Dados carregados
    Form->>U: Exibe grid com materiais

    U->>Form: Clica "Novo"
    Form->>U: Limpa campos

    U->>Form: Preenche código, nome, unidade, classificação, estoque mínimo
    U->>Form: Clica "Salvar"
    
    Form->>Form: Valida campos
    
    alt Dados válidos
        Form->>EF: Verifica código duplicado
        EF->>SQL: SELECT COUNT(*) WHERE Codigo = ?
        SQL-->>EF: 0 (não existe)
        
        Form->>EF: Add(novoMaterial)
        Form->>EF: SaveChanges()
        EF->>SQL: INSERT INTO Materiais
        SQL-->>EF: Material inserido (ID gerado)
        EF-->>Form: Sucesso
        
        Form->>U: "Material cadastrado com sucesso!"
        Form->>Form: Limpa campos
        Form->>EF: Recarrega grid
        EF->>SQL: SELECT * FROM Materiais
        SQL-->>Form: Lista atualizada
    else Dados inválidos
        Form->>U: Exibe mensagem de erro
    end
```

---

## Fluxo de Entrada de Material

Este fluxo mostra como é registrada a entrada de materiais no estoque, incluindo informações sobre fornecedor, lote e validade. O sistema atualiza automaticamente o estoque disponível através de uma transação que garante a integridade dos dados.

```mermaid
sequenceDiagram
    participant U as Usuário
    participant Form as FormEntradaMaterial
    participant EF as Entity Framework
    participant SQL as SQL Server

    U->>Form: Clica "Registrar Entrada de Material"
    Form->>EF: Carregar lista de materiais
    EF->>SQL: SELECT Id, Codigo, Nome FROM Materiais ORDER BY Nome
    SQL-->>Form: Lista de materiais
    Form->>U: Exibe combo com materiais

    U->>Form: Seleciona material
    Form->>EF: Busca detalhes do material
    EF->>SQL: SELECT * FROM Materiais WHERE Id = ?
    SQL-->>Form: Dados do material (estoque atual, unidade)
    Form->>U: Exibe informações do material

    U->>Form: Preenche fornecedor, quantidade, custo, lote, validade, data
    U->>Form: Clica "Registrar Entrada"
    
    Form->>Form: Valida campos
    
    alt Dados válidos
        Form->>EF: Begin Transaction
        
        Note over Form,SQL: 1. Registrar entrada
        Form->>EF: Add(novaEntrada)
        EF->>SQL: INSERT INTO EntradasMateriais
        SQL-->>EF: Entrada registrada
        
        Note over Form,SQL: 2. Atualizar estoque
        Form->>EF: Material.EstoqueAtual += Quantidade
        EF->>SQL: UPDATE Materiais SET EstoqueAtual = ?
        SQL-->>EF: Estoque atualizado
        
        Form->>EF: SaveChanges()
        Form->>EF: Commit Transaction
        
        Form->>U: "Entrada registrada com sucesso!"
        Form->>Form: Limpa campos
        Form->>EF: Recarrega histórico (últimas 50 entradas)
        EF->>SQL: SELECT TOP 50 * FROM EntradasMateriais ORDER BY DataEntrada DESC
        SQL-->>Form: Histórico atualizado
    else Dados inválidos
        Form->>EF: Rollback Transaction
        Form->>U: Exibe mensagem de erro
    end
```

---

## Fluxo de Saída de Material

Este fluxo detalha o processo de retirada de materiais do estoque, com validação de quantidade disponível. O sistema verifica se há estoque suficiente, registra a movimentação e emite alertas caso o estoque fique abaixo do mínimo estabelecido.

```mermaid
sequenceDiagram
    participant U as Usuário
    participant Form as FormSaidaMaterial
    participant EF as Entity Framework
    participant SQL as SQL Server

    U->>Form: Clica "Registrar Saída de Material"
    Form->>EF: Carregar materiais
    EF->>SQL: SELECT * FROM Materiais
    SQL-->>Form: Lista de materiais
    Form->>U: Exibe combo

    U->>Form: Seleciona material
    Form->>EF: Busca dados do material
    EF->>SQL: SELECT * FROM Materiais WHERE Id = ?
    SQL-->>Form: Material com estoque atual
    Form->>U: Exibe estoque disponível

    U->>Form: Preenche setor, responsável, quantidade, data
    U->>Form: Clica "Registrar Saída"
    
    Form->>Form: Valida campos
    Form->>Form: Verifica estoque disponível
    
    alt Estoque suficiente
        Form->>EF: Begin Transaction
        
        Note over Form,SQL: 1. Registrar saída
        Form->>EF: Add(novaSaida)
        EF->>SQL: INSERT INTO SaidasMateriais
        SQL-->>EF: Saída registrada
        
        Note over Form,SQL: 2. Reduzir estoque
        Form->>EF: Material.EstoqueAtual -= Quantidade
        EF->>SQL: UPDATE Materiais SET EstoqueAtual = ?
        SQL-->>EF: Estoque reduzido
        
        Form->>EF: SaveChanges()
        Form->>EF: Commit Transaction
        
        alt Estoque ficou abaixo do mínimo
            Form->>U: "?? Atenção: Estoque abaixo do mínimo!"
        else Estoque OK
            Form->>U: "Saída registrada com sucesso!"
        end
        
        Form->>Form: Limpa campos
        Form->>EF: Recarrega histórico
        EF->>SQL: SELECT TOP 50 * FROM SaidasMateriais ORDER BY DataSaida DESC
        SQL-->>Form: Histórico atualizado
    else Estoque insuficiente
        Form->>U: "Estoque insuficiente! Disponível: X"
    end
```

---

## Fluxo de Ajuste de Estoque

Este fluxo apresenta o processo de ajuste manual de estoque, geralmente utilizado para correções de inventário. Exige justificativa obrigatória para manter a rastreabilidade e auditoria das alterações realizadas no sistema.

```mermaid
sequenceDiagram
    participant U as Usuário
    participant Form as FormAjusteEstoque
    participant EF as Entity Framework
    participant SQL as SQL Server

    U->>Form: Clica "Ajuste de Estoque - Inventário"
    Form->>EF: Carregar materiais
    EF->>SQL: SELECT * FROM Materiais ORDER BY Nome
    SQL-->>Form: Lista de materiais
    Form->>U: Exibe combo

    U->>Form: Seleciona material
    Form->>EF: Busca material
    EF->>SQL: SELECT * FROM Materiais WHERE Id = ?
    SQL-->>Form: Material selecionado
    Form->>U: Exibe estoque atual

    U->>Form: Informa nova quantidade e justificativa
    U->>Form: Clica "Registrar Ajuste"
    
    Form->>Form: Valida campos
    
    alt Dados válidos
        Form->>EF: Begin Transaction
        
        Note over Form,SQL: 1. Registrar ajuste
        Form->>EF: Add(novoAjuste)
        EF->>SQL: INSERT INTO AjustesEstoque (QuantidadeAnterior, NovaQuantidade, Justificativa)
        SQL-->>EF: Ajuste registrado
        
        Note over Form,SQL: 2. Atualizar estoque
        Form->>EF: Material.EstoqueAtual = NovaQuantidade
        EF->>SQL: UPDATE Materiais SET EstoqueAtual = ?
        SQL-->>EF: Estoque ajustado
        
        Form->>EF: SaveChanges()
        Form->>EF: Commit Transaction
        
        Form->>U: "Ajuste registrado com sucesso!"
        Form->>Form: Limpa campos
        Form->>EF: Recarrega histórico
        EF->>SQL: SELECT TOP 50 * FROM AjustesEstoque ORDER BY DataAjuste DESC
        SQL-->>Form: Histórico de ajustes
    else Justificativa não informada
        Form->>U: "Informe a justificativa do ajuste"
    end
```

---

## Fluxo de Relatório de Ponto de Pedido

Este fluxo demonstra como o sistema identifica e exibe materiais que estão com estoque abaixo do mínimo estabelecido. Permite aos gestores visualizar rapidamente quais itens precisam ser repostos, priorizando por classificação e urgência.

```mermaid
sequenceDiagram
    participant U as Usuário
    participant Form as FormRelatorioPontoPedido
    participant EF as Entity Framework
    participant SQL as SQL Server

    U->>Form: Clica "Relatório de Ponto de Pedido"
    Form->>EF: Buscar materiais abaixo do estoque mínimo
    EF->>SQL: SELECT * FROM Materiais WHERE EstoqueAtual <= EstoqueMinimo ORDER BY Classificacao
    SQL-->>EF: Lista de materiais em ponto de pedido
    EF-->>Form: Dados processados
    
    Form->>Form: Calcula estatísticas
    Note over Form: - Total de materiais em alerta<br/>- Quantidade por classificação<br/>- Prioridades
    
    Form->>U: Exibe relatório com:
    Note over U,Form: • Grid com materiais críticos<br/>• Código, Nome, Classificação<br/>• Estoque Atual vs Estoque Mínimo<br/>• Diferença e status de urgência
    
    alt Usuário exporta relatório
        U->>Form: Clica "Exportar"
        Form->>Form: Gera CSV/Excel
        Form->>U: Download do arquivo
    end
```

---

## Fluxo de Histórico de Movimentações

Este fluxo mostra como o sistema permite consultar todas as movimentações (entradas, saídas e ajustes) com diversos filtros. As consultas podem ser realizadas por tipo de movimentação, período específico ou material, facilitando auditorias e análises.

```mermaid
sequenceDiagram
    participant U as Usuário
    participant Form as FormHistoricoMovimentacoes
    participant EF as Entity Framework
    participant SQL as SQL Server

    U->>Form: Clica "Consultar Histórico de Movimentações"
    Form->>U: Exibe filtros (tipo, período, material)

    U->>Form: Seleciona filtros
    U->>Form: Clica "Buscar"
    
    alt Filtro: Todas as movimentações
        Form->>EF: Buscar todas
        
        par Busca paralela
            EF->>SQL: SELECT * FROM EntradasMateriais WHERE Data BETWEEN ? AND ?
            SQL-->>EF: Lista de entradas
        and
            EF->>SQL: SELECT * FROM SaidasMateriais WHERE Data BETWEEN ? AND ?
            SQL-->>EF: Lista de saídas
        and
            EF->>SQL: SELECT * FROM AjustesEstoque WHERE Data BETWEEN ? AND ?
            SQL-->>EF: Lista de ajustes
        end
        
        Form->>Form: Mescla e ordena por data
    else Filtro: Apenas entradas
        EF->>SQL: SELECT * FROM EntradasMateriais WHERE...
        SQL-->>EF: Entradas filtradas
    else Filtro: Apenas saídas
        EF->>SQL: SELECT * FROM SaidasMateriais WHERE...
        SQL-->>EF: Saídas filtradas
    else Filtro: Apenas ajustes
        EF->>SQL: SELECT * FROM AjustesEstoque WHERE...
        SQL-->>EF: Ajustes filtrados
    end
    
    Form->>U: Exibe histórico completo
    Note over U,Form: Grid com: Tipo, Data, Material,<br/>Quantidade, Responsável/Fornecedor
```

---

## Fluxo de Teste de Conexão SQL

Este fluxo apresenta a ferramenta de diagnóstico que permite verificar a conectividade com o SQL Server. O sistema testa a conexão, identifica problemas comuns e oferece soluções, além de permitir a criação do banco de dados diretamente pela interface.

```mermaid
sequenceDiagram
    participant U as Usuário
    participant Form as FormTestConnection
    participant EF as Entity Framework
    participant SQL as SQL Server

    U->>Form: Clica "?? Testar Conexão SQL"
    Form->>U: Exibe connection string atual
    
    U->>Form: Clica "Testar Conexão"
    Form->>EF: GetDbConnection()
    EF->>SQL: Tenta conectar
    
    alt Conexão bem-sucedida
        SQL-->>EF: Conectado
        EF->>SQL: SELECT @@VERSION
        SQL-->>EF: Versão do servidor
        EF->>SQL: SELECT DB_ID('SistemaAlmoxarifado')
        SQL-->>EF: ID do banco (ou null)
        
        alt Banco existe
            EF->>SQL: SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES
            SQL-->>EF: Lista de tabelas
            Form->>U: "? Conexão OK! Banco existe com X tabelas"
        else Banco não existe
            Form->>U: "?? Conexão OK! Mas banco não existe"
            Form->>U: Habilita botão "Criar Banco"
        end
    else Erro de conexão
        SQL-->>EF: Erro (código)
        Form->>Form: Analisa código do erro
        
        alt Erro 53/-1 (Servidor não encontrado)
            Form->>U: "? Servidor não encontrado<br/>Sugestões: Verifique services.msc"
        else Erro 4060 (Banco não existe)
            Form->>U: "?? Banco não existe<br/>Clique em 'Criar Banco'"
        else Erro 18456 (Autenticação)
            Form->>U: "? Erro de autenticação<br/>Verifique usuário/senha"
        end
    end
    
    opt Usuário cria banco
        U->>Form: Clica "Criar Banco de Dados"
        Form->>EF: Database.EnsureCreated()
        EF->>SQL: CREATE DATABASE + CREATE TABLEs
        SQL-->>EF: Banco criado
        Form->>U: "? Banco criado com sucesso!"
    end
```

---

## Fluxo de Busca e Filtro

Este fluxo demonstra a funcionalidade de busca em tempo real disponível nas telas de listagem. O sistema filtra automaticamente os registros à medida que o usuário digita, sem necessidade de clicar em botões, proporcionando uma experiência ágil e intuitiva.

```mermaid
sequenceDiagram
    participant U as Usuário
    participant Form as FormCadastroMateriais
    participant EF as Entity Framework
    participant SQL as SQL Server

    U->>Form: Digita no campo de busca
    Form->>Form: Evento TextChanged
    
    alt Texto vazio
        Form->>EF: Carregar todos
        EF->>SQL: SELECT * FROM Materiais
    else Com filtro
        Form->>EF: Busca com LIKE
        EF->>SQL: SELECT * FROM Materiais WHERE Codigo LIKE '%?%' OR Nome LIKE '%?%' OR Classificacao LIKE '%?%'
    end
    
    SQL-->>EF: Resultados filtrados
    EF-->>Form: Lista de materiais
    Form->>U: Atualiza grid em tempo real
    
    Note over U,Form: Busca instantânea sem<br/>necessidade de clicar em botão
```

---

## Diagrama de Relacionamento de Entidades

```mermaid
erDiagram
    MATERIAIS ||--o{ ENTRADAS : "tem"
    MATERIAIS ||--o{ SAIDAS : "tem"
    MATERIAIS ||--o{ AJUSTES : "tem"
    
    MATERIAIS {
        int Id PK
        string Codigo UK
        string Nome
        string UnidadeMedida
        string Classificacao
        int EstoqueMinimo
        int EstoqueAtual
        datetime DataCadastro
    }
    
    ENTRADAS {
        int Id PK
        int MaterialId FK
        string Fornecedor
        int Quantidade
        decimal CustoUnitario
        string NumeroLote
        string DataValidade
        datetime DataEntrada
    }
    
    SAIDAS {
        int Id PK
        int MaterialId FK
        string SetorSolicitante
        string Responsavel
        int Quantidade
        datetime DataSaida
    }
    
    AJUSTES {
        int Id PK
        int MaterialId FK
        int QuantidadeAnterior
        int NovaQuantidade
        string Justificativa
        datetime DataAjuste
    }
