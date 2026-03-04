# 🛒 GeekShopping

<div align="center">
  
  ![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet)
  ![C#](https://img.shields.io/badge/C%23-12.0-239120?style=for-the-badge&logo=c-sharp)
  ![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white)
  ![Entity Framework](https://img.shields.io/badge/Entity_Framework-8.0-512BD4?style=for-the-badge)
  
  **Um sistema de e-commerce moderno baseado em arquitetura de microsserviços**

</div>

---

## 📋 Sobre o Projeto

O **GeekShopping** é uma aplicação de e-commerce desenvolvida com **.NET 8** utilizando arquitetura de microsserviços. O projeto demonstra as melhores práticas no desenvolvimento de aplicações distribuídas, separando responsabilidades em serviços independentes e escaláveis.

### ✨ Características Principais

- 🏗️ **Arquitetura de Microsserviços** - Serviços independentes e desacoplados
- 🔄 **API RESTful** - Comunicação padronizada entre serviços
- 🗄️ **Entity Framework Core** - ORM moderno para acesso a dados
- 🐘 **PostgreSQL** - Banco de dados relacional robusto
- 📝 **Swagger/OpenAPI** - Documentação interativa da API
- 🎨 **Razor Pages** - Interface web responsiva
- 🔧 **AutoMapper** - Mapeamento eficiente entre objetos

---

## 🏛️ Arquitetura

O projeto está estruturado em microsserviços independentes:

### 🔹 GeekShopping.ProductAPI
API responsável pelo gerenciamento de produtos do e-commerce.

**Principais funcionalidades:**
- ✅ CRUD completo de produtos
- ✅ Gerenciamento de categorias
- ✅ Controle de preços e estoque
- ✅ Upload de imagens de produtos

**Tecnologias:**
- ASP.NET Core Web API
- Entity Framework Core 8.0
- PostgreSQL com Npgsql
- Swagger para documentação
- AutoMapper para DTOs

### 🔹 GeekShopping.Web
Interface web do usuário construída com Razor Pages.

**Principais funcionalidades:**
- 🛍️ Catálogo de produtos
- 🔍 Busca e filtragem
- 🛒 Carrinho de compras
- 👤 Interface responsiva

**Tecnologias:**
- ASP.NET Core MVC/Razor Pages
- Bootstrap para UI
- Consumo de APIs via HttpClient

---

## 🗂️ Estrutura do Projeto

```
GeekShooping/
│
├── 📁 GeekShopping.ProductAPI/
│   ├── Controllers/          # Endpoints da API
│   ├── Model/
│   │   ├── Base/            # Entidades base
│   │   ├── Context/         # DbContext do EF Core
│   │   └── Product.cs       # Modelo de Produto
│   ├── Migrations/          # Migrações do banco
│   └── Program.cs           # Configuração da API
│
└── 📁 GeekShopping.Web/
    ├── Controllers/         # Controllers MVC
    ├── Models/             # ViewModels
    └── Program.cs          # Configuração Web
```

---

## 🚀 Começando

### 📦 Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/) (versão 12 ou superior)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)

### ⚙️ Configuração

1. **Clone o repositório**
   ```bash
   git clone https://github.com/cleane2003/GeekShooping.git
   cd GeekShooping
   ```

2. **Configure o banco de dados PostgreSQL**
   
   Crie um banco de dados no PostgreSQL:
   ```sql
   CREATE DATABASE geekshopping;
   ```

3. **Configure a connection string**
   
   Edite o arquivo `GeekShopping.ProductAPI/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Host=localhost;Database=geekshopping;Username=seu_usuario;Password=sua_senha"
     }
   }
   ```

4. **Execute as migrações**
   ```bash
   cd GeekShopping.ProductAPI
   dotnet ef database update
   ```

5. **Execute os projetos**
   
   Terminal 1 - API:
   ```bash
   cd GeekShopping.ProductAPI
   dotnet run
   ```
   
   Terminal 2 - Web:
   ```bash
   cd GeekShopping.Web
   dotnet run
   ```

---

## 📡 Endpoints da API

A API de Produtos está disponível em: `https://localhost:5001` (ou porta configurada)

### Documentação Swagger
Acesse a documentação interativa em: `https://localhost:5001/swagger`

### Principais Endpoints

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| GET | `/api/products` | Lista todos os produtos |
| GET | `/api/products/{id}` | Obtém um produto específico |
| POST | `/api/products` | Cria um novo produto |
| PUT | `/api/products/{id}` | Atualiza um produto |
| DELETE | `/api/products/{id}` | Remove um produto |

---

## 🗃️ Modelo de Dados

### Product (Produto)

| Campo | Tipo | Descrição |
|-------|------|-----------|
| Id | long | Identificador único |
| Name | string(150) | Nome do produto |
| Price | decimal(18,2) | Preço do produto |
| Description | string(500) | Descrição detalhada |
| CategoryName | string(50) | Categoria do produto |
| ImageUrl | string(300) | URL da imagem |

---

## 🛠️ Tecnologias Utilizadas

### Backend
- **ASP.NET Core 8.0** - Framework web moderno
- **Entity Framework Core 8.0** - ORM para acesso a dados
- **PostgreSQL** - Banco de dados relacional
- **Npgsql** - Provider PostgreSQL para .NET
- **AutoMapper 12.0** - Mapeamento objeto-objeto
- **Swashbuckle (Swagger)** - Documentação da API

### Frontend
- **Razor Pages** - Engine de views
- **Bootstrap** - Framework CSS
- **JavaScript** - Interatividade

### Ferramentas
- **Entity Framework Migrations** - Controle de versão do banco
- **Swagger UI** - Interface de teste da API
- **Git** - Controle de versão

---

## 📈 Próximos Passos

- [ ] 🔐 Implementar autenticação e autorização (Identity Server)
- [ ] 🛒 Microsserviço de Carrinho de Compras
- [ ] 💳 Microsserviço de Pagamento
- [ ] 📦 Microsserviço de Pedidos
- [ ] 🚀 Gateway de API (Ocelot)
- [ ] 📬 Mensageria com RabbitMQ
- [ ] 🐳 Containerização com Docker
- [ ] ☸️ Orquestração com Kubernetes
- [ ] 📊 Monitoramento e Logs

---

## 👨‍💻 Autor

**Cleane Oliveira**

- GitHub: [@cleane2003](https://github.com/cleane2003)
- 📧 Email: [seu-email@exemplo.com]

---

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## 🤝 Contribuindo

Contribuições são sempre bem-vindas! Para contribuir:

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/NovaFeature`)
3. Commit suas mudanças (`git commit -m 'Adiciona nova feature'`)
4. Push para a branch (`git push origin feature/NovaFeature`)
5. Abra um Pull Request

---

<div align="center">
  
  ### ⭐ Se este projeto foi útil para você, considere dar uma estrela!
  
  **Desenvolvido com ❤️ usando .NET 8**
  
</div>
