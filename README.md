# 🚀 SUBINO - Sistema Desktop de Gerenciamento

**Sistema desktop em C# (.NET Framework 4.8) com interface WinForms para gerenciar usuários, clientes, veículos, motoristas e recepcionistas.**

---

## 🔧 **Tecnologias Utilizadas**
- **C#** - Linguagem principal
- **.NET Framework 4.8** - Plataforma de desenvolvimento
- **Windows Forms (WinForms)** - Interface gráfica
- **MySQL** - Banco de dados relacional
- **NuGet Packages** - MySql.Data, BouncyCastle, Google.Protobuf

---

## ✨ **Funcionalidades Principais**
- 🔐 **Autenticação de usuários** com sistema de login seguro
- 👥 **Cadastro completo** de clientes, veículos, motoristas e recepcionistas
- 📸 **Upload de fotos** armazenadas como BLOB no banco de dados
- 🔄 **Operações CRUD** completas integradas ao MySQL
- 🗂️ **Gerenciamento centralizado** de múltiplas entidades

---

## 📁 **Arquivos Chave do Projeto**
- `SUBINO.csproj` - Configuração do projeto
- `app.config` - Configurações de aplicação
- `MainForm.cs` - Tela principal do sistema
- `Form1.cs` - Tela de login
- `Form9.cs` - Cadastro de cliente com upload de imagem
- `Form11.cs` - Registro de usuário

---

## ⚙️ **Pré-requisitos de Instalação**
- **Sistema Operacional:** Windows 7 ou superior
- **Ambiente de Desenvolvimento:** Visual Studio 2019/2022
- **Framework:** .NET Framework 4.8
- **Banco de Dados:** MySQL Server ou MariaDB compatível
- **Gerenciador de Pacotes:** NuGet Package Manager

---

## 🚀 **Instalação & Execução**

### 1. **Clone o Repositório**
```bash
git clone <sua-url>
cd SUBINO
```

### 2. **Configure o Banco de Dados**
```sql
-- Crie o banco de dados
CREATE DATABASE subino;

-- Execute os scripts SQL para criar as tabelas:
-- Usuario, cliente, veiculo, motorista, recepcionista
```

### 3. **Configure a Conexão**
Atualize a string de conexão no código ou no `app.config`:
```csharp
// Exemplo (substitua com suas credenciais)
string connectionString = "Server=localhost;Database=subino;Uid=root;Pwd=sua_senha;";
```

### 4. **Restaure os Pacotes NuGet**
- Abra o projeto no Visual Studio
- Clique com botão direito na solução
- Selecione "Restaurar Pacotes NuGet"

### 5. **Compile e Execute**
- Pressione **Ctrl+Shift+B** para compilar
- Pressione **F5** para executar
- O executável será gerado em `bin/Debug/SUBINO.exe`

---

## ⚠️ **Observações Importantes**
- Atualmente algumas strings de conexão estão *hardcoded* no código
- **Recomendação:** Mover todas as credenciais para o `app.config`
- Configure adequadamente as permissões do banco de dados

---

## 🖼️ **Capturas de Tela**
*(Adicione suas screenshots na pasta `assets/screenshots/`)*
```
📂 assets/
 └── 📂 screenshots/
      ├── main.png       # Tela Principal
      ├── login.png      # Tela de Login
      ├── client.png     # Cadastro de Cliente
      └── list.png       # Listagem de Dados
```

---

## ✅ **Boas Práticas & Melhorias Sugeridas**

### 🔐 **Segurança**
- Remover credenciais do código fonte
- Usar `app.config` com criptografia ou variáveis de ambiente
- Implementar hash adequado para senhas

### ✔️ **Validação de Dados**
- Implementar validação de CPF/CNPJ
- Validar formatos de arquivo de imagem
- Controlar tamanhos máximos de upload

### 🧪 **Qualidade de Código**
- Adicionar testes automatizados
- Criar scripts de migração de banco
- Implementar padrões de projeto (Repository, Unit of Work)

### 🎨 **Interface do Usuário**
- Melhorar UX/UI com controles modernos
- Adicionar suporte a internacionalização
- Implementar temas claro/escuro

---

## 📊 **Estrutura do Banco de Dados**
```
subino/
 ├── Usuario          # Tabela de usuários do sistema
 ├── cliente          # Cadastro de clientes
 ├── veiculo          # Registro de veículos
 ├── motorista        # Cadastro de motoristas
 └── recepcionista    # Registro de recepcionistas
```

---

## 💼 **Para o Portfólio**
Este projeto demonstra competências em:
- ✅ **Desenvolvimento Desktop** com C# e WinForms
- ✅ **Integração com Banco de Dados** MySQL
- ✅ **Manipulação de Imagens** (BLOB no banco)
- ✅ **Arquitetura de Software** em camadas
- ✅ **Versionamento** com Git

---

## 📞 **Suporte**
Para dúvidas ou sugestões:
1. Verifique os issues abertos no repositório
2. Consulte a documentação do código
3. Entre em contato através do GitHub

---

## 📄 **Licença**
Projeto desenvolvido para fins educacionais e de portfólio.

---

<div align="center">
  
  **Sistema desenvolvido para demonstrar habilidades em desenvolvimento desktop C#**
  
  
</div>
