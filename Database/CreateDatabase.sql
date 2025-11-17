-- ========================================
-- Script de Criação do Banco de Dados
-- Sistema de Almoxarifado
-- ========================================

-- Criar banco de dados
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'AlmoxarifadoDB')
BEGIN
    CREATE DATABASE AlmoxarifadoDB;
END
GO

USE AlmoxarifadoDB;
GO

-- ========================================
-- Tabela: Materiais
-- ========================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Materiais')
BEGIN
    CREATE TABLE Materiais (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Codigo NVARCHAR(50) NOT NULL UNIQUE,
        Nome NVARCHAR(200) NOT NULL,
        UnidadeMedida NVARCHAR(20) NOT NULL,
        Classificacao NVARCHAR(100) NOT NULL,
        EstoqueMinimo INT NOT NULL,
        EstoqueAtual INT NOT NULL DEFAULT 0,
        DataCadastro DATETIME2 NOT NULL DEFAULT GETDATE()
    );

    CREATE INDEX IX_Materiais_Codigo ON Materiais(Codigo);
    CREATE INDEX IX_Materiais_Nome ON Materiais(Nome);
END
GO

-- ========================================
-- Tabela: EntradasMateriais
-- ========================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'EntradasMateriais')
BEGIN
    CREATE TABLE EntradasMateriais (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        MaterialId INT NOT NULL,
        Fornecedor NVARCHAR(200) NOT NULL,
        Quantidade INT NOT NULL,
        CustoUnitario DECIMAL(18,2) NOT NULL,
        NumeroLote NVARCHAR(100) NULL,
        DataValidade NVARCHAR(100) NULL,
        DataEntrada DATETIME2 NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_EntradasMateriais_Materiais 
            FOREIGN KEY (MaterialId) REFERENCES Materiais(Id)
    );

    CREATE INDEX IX_EntradasMateriais_MaterialId ON EntradasMateriais(MaterialId);
    CREATE INDEX IX_EntradasMateriais_DataEntrada ON EntradasMateriais(DataEntrada);
END
GO

-- ========================================
-- Tabela: SaidasMateriais
-- ========================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'SaidasMateriais')
BEGIN
    CREATE TABLE SaidasMateriais (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        MaterialId INT NOT NULL,
        SetorSolicitante NVARCHAR(200) NOT NULL,
        Responsavel NVARCHAR(200) NOT NULL,
        Quantidade INT NOT NULL,
        DataSaida DATETIME2 NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_SaidasMateriais_Materiais 
            FOREIGN KEY (MaterialId) REFERENCES Materiais(Id)
    );

    CREATE INDEX IX_SaidasMateriais_MaterialId ON SaidasMateriais(MaterialId);
    CREATE INDEX IX_SaidasMateriais_DataSaida ON SaidasMateriais(DataSaida);
    CREATE INDEX IX_SaidasMateriais_SetorSolicitante ON SaidasMateriais(SetorSolicitante);
END
GO

-- ========================================
-- Tabela: AjustesEstoque
-- ========================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'AjustesEstoque')
BEGIN
    CREATE TABLE AjustesEstoque (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        MaterialId INT NOT NULL,
        QuantidadeAnterior INT NOT NULL,
        NovaQuantidade INT NOT NULL,
        Justificativa NVARCHAR(500) NOT NULL,
        DataAjuste DATETIME2 NOT NULL DEFAULT GETDATE(),
        CONSTRAINT FK_AjustesEstoque_Materiais 
            FOREIGN KEY (MaterialId) REFERENCES Materiais(Id)
    );

    CREATE INDEX IX_AjustesEstoque_MaterialId ON AjustesEstoque(MaterialId);
    CREATE INDEX IX_AjustesEstoque_DataAjuste ON AjustesEstoque(DataAjuste);
END
GO

-- ========================================
-- Dados de Exemplo (Opcional)
-- ========================================

-- Inserir materiais de exemplo
IF NOT EXISTS (SELECT * FROM Materiais)
BEGIN
    -- Materiais de Limpeza
    INSERT INTO Materiais (Codigo, Nome, UnidadeMedida, Classificacao, EstoqueMinimo, EstoqueAtual)
    VALUES 
        ('LIMP001', 'Detergente Neutro', 'L', 'Limpeza', 10, 15),
        ('LIMP002', 'Água Sanitária', 'L', 'Limpeza', 15, 8),
        ('LIMP003', 'Sabonete Líquido', 'L', 'Limpeza', 20, 5),
        ('LIMP004', 'Papel Toalha', 'Fardo', 'Limpeza', 5, 3),
        ('LIMP005', 'Saco de Lixo 100L', 'PC', 'Limpeza', 50, 60);

    -- Materiais de Laboratório
    INSERT INTO Materiais (Codigo, Nome, UnidadeMedida, Classificacao, EstoqueMinimo, EstoqueAtual)
    VALUES 
        ('LAB001', 'Ácido Clorídrico 1L', 'L', 'Laboratório', 5, 3),
        ('LAB002', 'Hidróxido de Sódio 500g', 'KG', 'Laboratório', 3, 2),
        ('LAB003', 'Luvas Descartáveis M', 'CX', 'Laboratório', 10, 7),
        ('LAB004', 'Béquer de Vidro 250ml', 'UN', 'Laboratório', 20, 15),
        ('LAB005', 'Pipeta Graduada 10ml', 'UN', 'Laboratório', 15, 10);

    -- Materiais de Escritório
    INSERT INTO Materiais (Codigo, Nome, UnidadeMedida, Classificacao, EstoqueMinimo, EstoqueAtual)
    VALUES 
        ('ESC001', 'Papel A4 Sulfite', 'Resma', 'Escritório', 20, 25),
        ('ESC002', 'Caneta Esferográfica Azul', 'CX', 'Escritório', 10, 12),
        ('ESC003', 'Grampeador', 'UN', 'Escritório', 5, 4),
        ('ESC004', 'Pasta Suspensa', 'CX', 'Escritório', 5, 2),
        ('ESC005', 'Clips para Papel', 'CX', 'Escritório', 8, 6);

    PRINT 'Materiais de exemplo inseridos com sucesso!';
END
GO

PRINT '========================================';
PRINT 'Banco de dados criado com sucesso!';
PRINT 'Database: AlmoxarifadoDB';
PRINT '========================================';
GO
