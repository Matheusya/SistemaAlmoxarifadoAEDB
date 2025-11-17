# Script para subir o projeto para o GitHub
# Execute este script no PowerShell

Write-Host "=== UPLOAD DO PROJETO PARA GITHUB ===" -ForegroundColor Cyan
Write-Host ""

# 1. Verificar se Git está instalado
Write-Host "1. Verificando instalação do Git..." -ForegroundColor Yellow
try {
    $gitVersion = git --version
    Write-Host "   ? Git instalado: $gitVersion" -ForegroundColor Green
} catch {
    Write-Host "   ? Git não encontrado. Instale em: https://git-scm.com/" -ForegroundColor Red
    exit
}

Write-Host ""

# 2. Inicializar repositório Git (se ainda não foi)
Write-Host "2. Inicializando repositório Git..." -ForegroundColor Yellow
if (Test-Path ".git") {
    Write-Host "   - Repositório Git já existe" -ForegroundColor Gray
} else {
    git init
    Write-Host "   ? Repositório Git inicializado" -ForegroundColor Green
}

Write-Host ""

# 3. Configurar usuário Git (se necessário)
Write-Host "3. Configuração do Git..." -ForegroundColor Yellow
$userName = git config user.name
$userEmail = git config user.email

if ([string]::IsNullOrEmpty($userName)) {
    Write-Host "   Configure seu nome de usuário Git:" -ForegroundColor Cyan
    $nome = Read-Host "   Digite seu nome"
    git config --global user.name "$nome"
    Write-Host "   ? Nome configurado: $nome" -ForegroundColor Green
}

if ([string]::IsNullOrEmpty($userEmail)) {
    Write-Host "   Configure seu email Git:" -ForegroundColor Cyan
    $email = Read-Host "   Digite seu email"
    git config --global user.email "$email"
    Write-Host "   ? Email configurado: $email" -ForegroundColor Green
}

Write-Host ""

# 4. Adicionar arquivos
Write-Host "4. Adicionando arquivos ao Git..." -ForegroundColor Yellow
git add .
Write-Host "   ? Arquivos adicionados" -ForegroundColor Green

Write-Host ""

# 5. Fazer commit
Write-Host "5. Criando commit..." -ForegroundColor Yellow
$mensagemCommit = Read-Host "   Digite a mensagem do commit (ou pressione Enter para usar 'Initial commit')"
if ([string]::IsNullOrEmpty($mensagemCommit)) {
    $mensagemCommit = "Initial commit - Sistema de Almoxarifado"
}
git commit -m "$mensagemCommit"
Write-Host "   ? Commit criado" -ForegroundColor Green

Write-Host ""

# 6. Conectar ao repositório remoto
Write-Host "6. Configurando repositório remoto..." -ForegroundColor Yellow
Write-Host "   Você precisa criar um repositório no GitHub primeiro!" -ForegroundColor Cyan
Write-Host "   Acesse: https://github.com/new" -ForegroundColor Cyan
Write-Host ""
$repoUrl = Read-Host "   Digite a URL do repositório GitHub (ex: https://github.com/usuario/repo.git)"

# Verificar se já existe um remote
$remoteExists = git remote | Select-String "origin"
if ($remoteExists) {
    git remote set-url origin $repoUrl
    Write-Host "   ? Remote 'origin' atualizado" -ForegroundColor Green
} else {
    git remote add origin $repoUrl
    Write-Host "   ? Remote 'origin' adicionado" -ForegroundColor Green
}

Write-Host ""

# 7. Fazer push
Write-Host "7. Enviando para o GitHub..." -ForegroundColor Yellow
Write-Host "   Você pode precisar fazer login no GitHub..." -ForegroundColor Cyan

# Verificar branch principal
$branchAtual = git branch --show-current
if ([string]::IsNullOrEmpty($branchAtual)) {
    $branchAtual = "main"
    git branch -M main
}

try {
    git push -u origin $branchAtual
    Write-Host "   ? Projeto enviado com sucesso!" -ForegroundColor Green
} catch {
    Write-Host "   ? Erro ao fazer push. Você pode precisar:" -ForegroundColor Red
    Write-Host "     1. Fazer login no GitHub" -ForegroundColor Yellow
    Write-Host "     2. Verificar se a URL do repositório está correta" -ForegroundColor Yellow
    Write-Host "     3. Executar manualmente: git push -u origin $branchAtual" -ForegroundColor Yellow
}

Write-Host ""
Write-Host "=== PROCESSO CONCLUÍDO ===" -ForegroundColor Cyan
Write-Host ""
Write-Host "PRÓXIMOS PASSOS:" -ForegroundColor Yellow
Write-Host "1. Acesse seu repositório no GitHub" -ForegroundColor White
Write-Host "2. Verifique se todos os arquivos foram enviados" -ForegroundColor White
Write-Host "3. Configure descrição e tags do repositório" -ForegroundColor White
Write-Host ""
Write-Host "URL do repositório: $repoUrl" -ForegroundColor Cyan
