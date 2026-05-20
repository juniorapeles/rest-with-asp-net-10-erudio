# RestWithASPNET10Erudio

API RESTful construída com ASP.NET Core 10 como projeto prático de estudo.

## Sobre o projeto

Este repositório faz parte do aprendizado do curso **Domine ASP .NET 10 Swagger Docker Kubernetes REST Web API RESTful JWT xUnit Testcontainers React JS do 0 à Azure, GCP e+**.

O objetivo do projeto é consolidar, na prática, a construção de uma Web API moderna com .NET, cobrindo desde a modelagem de entidades e CRUD até organização em camadas, persistência de dados, documentação, testes e preparação para deploy em ambientes containerizados e cloud.

## Objetivos de aprendizado

- Estruturar uma API RESTful com ASP.NET Core 10
- Trabalhar com controllers, services e repositories
- Mapear entidades com Entity Framework Core
- Versionar banco com migrations SQL usando Evolve
- Integrar SQL Server ao projeto
- Evoluir a API para Swagger, JWT, testes com xUnit e Testcontainers
- Preparar a aplicação para Docker, Kubernetes, Azure e GCP
- Praticar integração futura com frontend em React JS

## O que já existe no projeto

- CRUD de `Person` e `Book`
- Persistência com SQL Server
- Mapeamento de entidades com EF Core
- Migrações com Evolve
- Injeção de dependência
- Logging com Serilog
- Repositório genérico
- **DTOs** para Person e Book (desacoplamento da camada de domínio)
- **Mapeamento Objeto-Objeto**: `PersonConverter` (via `IParser<O,D>`) para Person e **Mapster** para Book

## Stack principal

- .NET 10
- ASP.NET Core 10
- Entity Framework Core 10
- SQL Server
- Evolve
- Serilog
- Mapster

## Arquitetura

O projeto segue uma estrutura em camadas com **DTOs** para desacoplar a representação dos dados expostos pela API do modelo de domínio:

`Controller (DTO) -> Service (DTO <-> Entity) -> Repository (Entity) -> DbContext -> SQL Server`

O mapeamento entre **DTO** e **Entity** é feito com `PersonConverter` (via `IParser<O,D>`) para Person e **Mapster** para Book, ambos centralizados na camada de serviço.

## Estrutura do projeto

```text
RestWithASPNET10Erudio/
|- Configurations/
|- Controllers/
|- Data/
|   |- Converter/
|   |   |- Contract/
|   |   |   `- IParser.cs
|   |   `- Impl/
|   |       `- PersonConverter.cs
|   `- DTO/
|       |- BookDTO.cs
|       `- PersonDTO.cs
|- Model/
|- Repositories/
|- Services/
|- db/
|- Program.cs
|- appsettings.json
`- RestWithASPNET10Erudio.csproj
```

## Endpoints atuais

### Person

- `GET /api/person`
- `GET /api/person/{id}`
- `POST /api/person`
- `PUT /api/person`
- `DELETE /api/person/{id}`

### Book

- `GET /api/book`
- `GET /api/book/{id}`
- `POST /api/book`
- `PUT /api/book`
- `DELETE /api/book/{id}`

## Como executar

1. Instale o .NET 10 SDK
2. Configure a connection string do SQL Server em `appsettings.json`
3. Execute o projeto:

```bash
dotnet run
```

## Descrição curta para portfólio

Projeto de estudo focado na construção de uma API RESTful com ASP.NET Core 10, aplicando CRUD, DTOs, mapeamento objeto-objeto (Mapster e IParser), Entity Framework Core, SQL Server, migrations com Evolve, injeção de dependência e arquitetura em camadas. A aplicação está sendo evoluída como base prática para Swagger, autenticação com JWT, testes com xUnit e Testcontainers, Docker, Kubernetes e deploy em Azure e GCP.

## Descrição média para portfólio

Desenvolvi esta API RESTful em ASP.NET Core 10 como laboratório prático para consolidar conceitos de backend moderno no ecossistema .NET. O projeto já inclui cadastro de pessoas e livros, DTOs para desacoplamento das camadas, mapeamento objeto-objeto com PersonConverter (IParser) e Mapster, persistência com SQL Server, organização em camadas, uso de Entity Framework Core, migrations com Evolve e repositório genérico. A proposta é expandir essa base com Swagger, autenticação JWT, testes automatizados com xUnit e Testcontainers, conteinerização com Docker, orquestração com Kubernetes e integração com React, criando uma trilha completa de aprendizado até cenários de cloud em Azure e GCP.

## Licença

Projeto educacional para fins de estudo e prática.
