# Guia: Como Subir o Projeto para o GitHub

## ?? Pré-requisitos

1. **Git instalado** - Download: https://git-scm.com/
2. **Conta no GitHub** - Criar em: https://github.com/
3. **GitHub Desktop** (opcional) - Download: https://desktop.github.com/

---

## ?? Método 1: Automático (Recomendado)

### Execute o script PowerShell:

```powershell
.\upload-github.ps1
```

O script fará tudo automaticamente! Siga as instruções na tela.

---

## ?? Método 2: Manual (Linha de Comando)

### Passo 1: Criar Repositório no GitHub

1. Acesse: https://github.com/new
2. Nome do repositório: `SistemaAlmoxarifado` (ou outro nome)
3. Descrição: `Sistema de gestão de almoxarifado em .NET 10`
4. Escolha: **Público** ou **Privado**
5. **NÃO** marque "Add a README file" (já temos um)
6. Clique em **"Create repository"**

### Passo 2: Configurar Git Local

Abra o PowerShell na pasta do projeto e execute:

```powershell
# Configurar nome e email (uma vez só)
git config --global user.name "Seu Nome"
git config --global user.email "seu@email.com"

# Inicializar repositório
git init

# Adicionar todos os arquivos
git add .

# Criar primeiro commit
git commit -m "Initial commit - Sistema de Almoxarifado"
```

### Passo 3: Conectar ao GitHub

```powershell
# Adicionar repositório remoto (substitua pela sua URL)
git remote add origin https://github.com/SEU_USUARIO/SistemaAlmoxarifado.git

# Renomear branch para main (se necessário)
git branch -M main

# Enviar para o GitHub
git push -u origin main
```

### Passo 4: Autenticação

Se pedir autenticação, você tem duas opções:

**Opção A: GitHub CLI**
```powershell
gh auth login
```

**Opção B: Personal Access Token**
1. Acesse: https://github.com/settings/tokens
2. Gere um novo token (classic)
3. Use o token como senha no Git

---

## ??? Método 3: GitHub Desktop (Mais Fácil)

### Passos:

1. **Abra o GitHub Desktop**
2. Clique em **"Add" ? "Add existing repository"**
3. Selecione a pasta: `C:\Users\joses\source\repos\SistemaAlmoxarifado`
4. Clique em **"Publish repository"**
5. Configure:
   - Nome: `SistemaAlmoxarifado`
   - Descrição: `Sistema de gestão de almoxarifado em .NET 10`
   - Keep this code private: (marque se quiser privado)
6. Clique em **"Publish repository"**

Pronto! ?

---

## ?? Comandos Úteis para o Futuro

### Fazer alterações e enviar:

```powershell
# Ver status dos arquivos
git status

# Adicionar arquivos modificados
git add .

# Criar commit
git commit -m "Descrição das alterações"

# Enviar para o GitHub
git push
```

### Atualizar do GitHub:

```powershell
git pull
```

### Ver histórico:

```powershell
git log --oneline
```

### Criar uma nova branch:

```powershell
git checkout -b nome-da-branch
```

---

## ?? Verificar se Funcionou

Acesse: `https://github.com/SEU_USUARIO/SistemaAlmoxarifado`

Você deve ver:
- ? Todos os arquivos do projeto
- ? README.md visível
- ? Pasta Models, Forms, Database, etc.

---

## ?? Solução de Problemas

### "Git não reconhecido"
- Instale o Git: https://git-scm.com/
- Reinicie o PowerShell após instalar

### "Authentication failed"
- Use GitHub Desktop (mais fácil)
- Ou configure Personal Access Token

### "Remote origin already exists"
```powershell
git remote remove origin
git remote add origin SUA_URL_AQUI
```

### Arquivos muito grandes
- Verifique o .gitignore
- Não envie as pastas `bin/` e `obj/`

---

## ?? Recomendações

### Adicione Tags ao Repositório:
- `dotnet`
- `csharp`
- `windows-forms`
- `entity-framework`
- `sql-server`
- `almoxarifado`

### Adicione Topics no GitHub:
- Vá em Settings ? Topics
- Adicione: `dotnet`, `windows-forms`, `inventory-management`

### Proteja a Branch Main:
- Settings ? Branches ? Add rule
- Require pull request reviews before merging

---

## ?? URL do Projeto no GitHub

Após o upload, seu projeto estará em:

```
https://github.com/SEU_USUARIO/SistemaAlmoxarifado
```

Compartilhe este link! ??
