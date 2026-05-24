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
- Evoluir a API para Swagger, JWT e testes de integração com Testcontainers
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
- **Versionamento da API** com `V1` e `V2` para `Person`
- **Content negotiation** com suporte a `application/json` e `application/xml`
- Projeto de testes automatizados com xUnit
- Asserções fluentes com FluentAssertions
- Mocks com Moq
- Coleta de cobertura com coverlet

## Stack principal

- .NET 10
- ASP.NET Core 10
- Entity Framework Core 10
- SQL Server
- Evolve
- Serilog
- Mapster
- xUnit
- FluentAssertions
- Moq
- coverlet.collector

## Arquitetura

O projeto segue uma estrutura em camadas com **DTOs** para desacoplar a representação dos dados expostos pela API do modelo de domínio:

`Controller (DTO) -> Service (DTO <-> Entity) -> Repository (Entity) -> DbContext -> SQL Server`

O mapeamento entre **DTO** e **Entity** é feito com `PersonConverter` (via `IParser<O,D>`) para Person e **Mapster** para Book, ambos centralizados na camada de serviço.

Na `V2` de `Person`, o DTO expõe `Id`, `FirstName`, `LastName`, `Address`, `Gender` e `BirthDay`. A API também respeita o header `Accept` e retorna `406 Not Acceptable` para formatos não suportados.

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
|   |       `- V2/
|   |           `- PersonConverter.cs
|   `- DTO/
|       |- BookDTO.cs
|       `- V2/
|           `- PersonDTO.cs
|- JsonSerializers/
|   |- DateSerializer.cs
|   `- GenderSerializer.cs
|- Model/
|- Repositories/
|- Services/
|- db/
|- Program.cs
|- appsettings.json
`- RestWithASPNET10Erudio.csproj

RestWithASPNET10Erudio.Tests/
|- Services/
`- RestWithASPNET10Erudio.Tests.csproj
```

## Testes automatizados

O repositório já conta com um projeto de testes em `RestWithASPNET10Erudio.Tests`, usando `xUnit` como framework principal, `FluentAssertions` para asserções mais legíveis, `Moq` para mocks e `coverlet.collector` para coleta de cobertura.

Para executar os testes:

```bash
dotnet test
```

## Endpoints atuais

### Person

- `GET /api/person`
- `GET /api/person/{id}`
- `POST /api/person`
- `PUT /api/person`
- `DELETE /api/person/{id}`
- `GET /api/v2/person`
- `GET /api/v2/person/{id}`
- `POST /api/v2/person`
- `PUT /api/v2/person`
- `DELETE /api/v2/person/{id}`

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

Projeto de estudo focado na construção de uma API RESTful com ASP.NET Core 10, aplicando CRUD, DTOs, mapeamento objeto-objeto (Mapster e IParser), Entity Framework Core, SQL Server, migrations com Evolve, injeção de dependência, arquitetura em camadas e testes automatizados com xUnit, FluentAssertions, Moq e coverlet. A aplicação segue evoluindo como base prática para Swagger, autenticação com JWT, testes de integração com Testcontainers, Docker, Kubernetes e deploy em Azure e GCP.

## Descrição média para portfólio

Desenvolvi esta API RESTful em ASP.NET Core 10 como laboratório prático para consolidar conceitos de backend moderno no ecossistema .NET. O projeto já inclui cadastro de pessoas e livros, DTOs para desacoplamento das camadas, mapeamento objeto-objeto com PersonConverter (IParser) e Mapster, persistência com SQL Server, organização em camadas, uso de Entity Framework Core, migrations com Evolve, repositório genérico e testes automatizados com xUnit, FluentAssertions, Moq e coverlet. A proposta é expandir essa base com Swagger, autenticação JWT, testes de integração com Testcontainers, conteinerização com Docker, orquestração com Kubernetes e integração com React, criando uma trilha completa de aprendizado até cenários de cloud em Azure e GCP.

## Licença

Projeto educacional para fins de estudo e prática.
