# 🚀 RestWithASPNET10Erudio

API RESTful construída com **ASP.NET Core 10** durante o curso de REST APIs do Erudio.

---

## 📋 Visão Geral

Esta é uma API RESTful de cadastro de **Pessoas** e **Livros** que implementa um **CRUD completo** seguindo as melhores práticas de arquitetura de software, incluindo o padrão **Repository**, migrações automatizadas com **Evolve** e injeção de dependência.

---

## 🧱 Tecnologias Utilizadas

### 🎯 .NET 10

Versão mais recente do framework da Microsoft para construção de aplicações modernas, rápidas e multiplataforma. O .NET 10 traz melhorias de performance, suporte a `ImplicitUsings` (usings implícitos) e `Nullable` habilitado por configuração.

```
<TargetFramework>net10.0</TargetFramework>
```

### 🌐 ASP.NET Core 10

Framework web para construção de APIs e aplicações web. Utilizamos o modelo **minimal API + Controllers** com:

- **Controllers** — Organização das rotas e endpoints REST.
- **Model Binding** — Mapeamento automático de parâmetros da requisição.
- **Dependency Injection (DI)** — Container nativo para injeção de dependências.

### 🗄️ Entity Framework Core 10

ORM (Object-Relational Mapper) que abstrai o banco de dados relacional. Permite trabalhar com objetos C# em vez de SQL puro.

**Pacote:** `Microsoft.EntityFrameworkCore.SqlServer` `v10.0.5`

**O que faz:**
- Mapeia classes C# (`Person`) para tabelas do banco (`person`)
- Gerencia conexões, consultas e migrações
- Fornece o `DbContext` como unidade de trabalho

### 🔄 Evolve

Ferramenta de migração de banco de dados baseada em arquivos SQL versionados. Inspirada no Flyway, o Evolve executa scripts SQL em ordem crescente de versão para criar e evoluir o schema do banco.

**Pacote:** `Evolve` `v3.2.0`

**Como funciona:**
- Escaneia as pastas `db/migrations` e `db/dataset`
- Executa scripts `.sql` em ordem numérica (V1, V2, V3...)
- Controla quais migrações já foram aplicadas via tabela de controle
- Só executa em ambiente de desenvolvimento (`IsDevelopment()`)

### 🏛️ SQL Server (MSSQL)

Banco de dados relacional da Microsoft rodando em container Docker. Responsável pelo armazenamento persistente dos dados.

**Connection string:**
```
Data Source=localhost,11433;Initial Catalog=asp_net_10_erudio;...
```

### 📝 Serilog

Biblioteca de logging estruturado de alto desempenho para .NET. Diferente do logging tradicional (que gera texto puro), o Serilog permite logs com propriedades nomeadas e serialização estruturada.

**Pacotes:**
| Pacote | Versão | Função |
|--------|--------|--------|
| `Serilog.AspNetCore` | 10.0.0 | Integração com o ASP.NET Core |
| `Serilog.Settings.Configuration` | 10.0.0 | Leitura de configurações do `appsettings.json` |
| `Serilog.Sinks.Console` | 6.1.1 | Saída dos logs no console |

**O que faz:**
- Loga informações da aplicação no console com níveis configuráveis (Information, Warning, Debug, Error)
- Enriquece logs com contexto da requisição
- Exibe banner personalizado na inicialização da API

### 🧩 Padrão Repository

Camada de abstração entre a lógica de negócio (Services) e o acesso a dados (DbContext). Implementado com interface + implementação concreta.

```
IPersonRepository (interface)
    └── PersonRepository (implementação com EF Core)
```

**Benefícios:**
- Desacopla a lógica de acesso a dados dos serviços
- Facilita testes unitários (mock do repositório)
- Centraliza a lógica de consultas em um único lugar

### 💉 Injeção de Dependência (DI)

Container nativo do ASP.NET Core que gerencia o ciclo de vida dos objetos. Escopos utilizados:

| Escopo | Comportamento | Onde usamos |
|--------|--------------|-------------|
| **Scoped** | 1 instância por requisição HTTP | `PersonServicesImpl`, `PersonRepository`, `MSSQLContext` |

### 📐 Arquitetura em Camadas

```
Controller  →  Service  →  Repository  →  DbContext  →  SQL Server
   HTTP          Regras      Acesso a dados      ORM        Database
```

**Fluxo de uma requisição:**
1. O **Controller** recebe a requisição HTTP e valida os parâmetros
2. O **Service** aplica as regras de negócio
3. O **Repository** executa as operações no banco via EF Core
4. O **SQL Server** persiste/retorna os dados

---

## 📦 Estrutura do Projeto

```
RestWithASPNET10Erudio/
├── Configurations/
│   ├── DatabaseConfig.cs      # Configuração do EF Core + SQL Server
│   ├── EvolveConfig.cs        # Configuração do Evolve (migrações)
│   └── LoggingConfig.cs       # Configuração do Serilog
├── Controllers/
│   ├── PersonController.cs    # Endpoints REST de Person
│   └── BookController.cs      # Endpoints REST de Book
├── Model/
│   ├── Person.cs              # Entidade mapeada para tabela "person"
│   ├── Book.cs                # Entidade mapeada para tabela "books"
│   └── Context/
│       └── MSSQLContext.cs    # DbContext do Entity Framework
├── Repositories/
│   ├── IPersonRepository.cs   # Contrato do repositório
│   └── Impl/
│       └── PersonRepository.cs # Implementação com EF Core
├── Services/
│   ├── IPersonServices.cs     # Contrato do serviço
│   └── Impl/
│       └── PersonServicesImpl.cs # Regras de negócio
├── Utils/                     # Classes utilitárias
├── db/
│   ├── migrations/            # Scripts de migração (V1, V3...)
│   └── dataset/               # Scripts de dados iniciais (V2, V4...)
├── Program.cs                 # Ponto de entrada e configuração DI
├── appsettings.json           # Configurações (connection string, Serilog)
└── RestWithASPNET10Erudio.csproj # Dependências e target framework
```

---

## 🔌 Endpoints

| Método | Rota | Descrição |
|--------|------|-----------|
| `GET` | `/api/person` | Lista todas as pessoas |
| `GET` | `/api/person/{id}` | Busca pessoa por ID |
| `POST` | `/api/person` | Cria uma nova pessoa |
| `PUT` | `/api/person` | Atualiza uma pessoa existente |
| `DELETE` | `/api/person/{id}` | Remove uma pessoa |
| `GET` | `/api/book` | Lista todos os livros |
| `GET` | `/api/book/{id}` | Busca livro por ID |
| `POST` | `/api/book` | Cria um novo livro |
| `PUT` | `/api/book` | Atualiza um livro existente |
| `DELETE` | `/api/book/{id}` | Remove um livro |

---

## 🚀 Como Executar

1. **Pré-requisitos:**
   - [.NET 10 SDK](https://dotnet.microsoft.com/download)
   - SQL Server (ou Docker com SQL Server)

2. **Configurar conexão:**
   Edite `appsettings.json` com sua connection string do MSSQL.

3. **Executar:**
```bash
dotnet run
```

4. **Acessar:**
```
https://localhost:5001/api/person
```

---

## 🧪 Exemplo de Payload (JSON)

```json
{
  "firstName": "João",
  "lastName": "Silva",
  "address": "Rua Exemplo, 123",
  "gender": "Male"
}
```

---

## 📄 Licença

Projeto educacional — curso REST APIs do Erudio.
