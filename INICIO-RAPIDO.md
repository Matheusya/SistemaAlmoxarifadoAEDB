# ? GUIA RÁPIDO - Upload para GitHub

## ?? OPÇÃO MAIS FÁCIL (Recomendada)

### GitHub Desktop - Sem precisar instalar Git

1. **Baixe o GitHub Desktop**
   - Link: https://desktop.github.com/
   - Instale e abra o programa

2. **Faça login**
   - Clique em "Sign in to GitHub.com"
   - Entre com sua conta

3. **Adicione o projeto**
   - File ? Add local repository
   - Escolha a pasta: `C:\Users\joses\source\repos\SistemaAlmoxarifado`
   - Clique em "Add repository"

4. **Publique no GitHub**
   - Clique em "Publish repository"
   - Nome: `SistemaAlmoxarifado`
   - Descrição: `Sistema de gestão de almoxarifado em .NET 10`
   - Desmarque "Keep this code private" (se quiser público)
   - Clique em "Publish repository"

? **PRONTO!** Seu projeto está no GitHub!

---

## ?? OPÇÃO ALTERNATIVA (Linha de Comando)

### 1. Instalar Git

- Baixe: https://git-scm.com/download/win
- Execute o instalador
- Use as opções padrão
- **IMPORTANTE:** Reinicie o PowerShell após instalar

### 2. Comandos

Depois de instalar o Git, execute no PowerShell:

```powershell
# Configurar (primeira vez)
git config --global user.name "Seu Nome"
git config --global user.email "seu@email.com"

# Ir para a pasta do projeto
cd C:\Users\joses\source\repos\SistemaAlmoxarifado

# Inicializar Git
git init

# Adicionar arquivos
git add .

# Primeiro commit
git commit -m "Initial commit - Sistema de Almoxarifado"

# Adicionar repositório remoto (crie antes em github.com/new)
git remote add origin https://github.com/SEU_USUARIO/SistemaAlmoxarifado.git

# Enviar para GitHub
git branch -M main
git push -u origin main
```

---

## ?? ANTES DE COMEÇAR

### Crie o repositório no GitHub:

1. Acesse: https://github.com/new
2. Nome: `SistemaAlmoxarifado`
3. Descrição: `Sistema de gestão de almoxarifado desenvolvido em .NET 10 com Windows Forms`
4. **NÃO** marque "Add a README file"
5. Clique em "Create repository"
6. **COPIE** a URL que aparece (você vai precisar)

---

## ? Arquivos Prontos para Upload

? `.gitignore` - Criado e configurado  
? `README.md` - Documentação completa  
? Código fonte - Todo organizado  
? Database scripts - Incluídos  

---

## ?? Depois do Upload

Seu projeto estará em:
```
https://github.com/SEU_USUARIO/SistemaAlmoxarifado
```

**Adicione tags no repositório:**
- `dotnet`, `csharp`, `windows-forms`, `entity-framework`, `sql-server`

---

## ? Precisa de Ajuda?

Use o **GitHub Desktop** - é muito mais fácil!
- Download: https://desktop.github.com/
- Tutorial em vídeo: https://www.youtube.com/results?search_query=github+desktop+tutorial
