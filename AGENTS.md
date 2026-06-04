# AGENTS

## Objetivo

Este repositório usa ASP.NET Core 10 com versionamento de API, DTOs e testes em xUnit. Antes de alterar qualquer coisa, o agente deve preservar mudanças locais do usuário, validar o comportamento real do código e evitar divergência de final de linha.

## Regras operacionais

- Sempre começar com `git status --short`.
- Nunca reverter mudanças existentes que não foram feitas pelo agente.
- Antes de editar documentação, ler o código atual e confirmar o comportamento real da API.
- Antes de commitar, executar `dotnet test`.
- Seguir o padrão de commit já usado no histórico: `feat: ...`, `fix: ...`, `refactor: ...`, `docs: ...`, `test: ...`.
- Quando houver mudança em `Data/DTO/V2/PersonDTO.cs` ou `Data/Converter/Impl/V2/PersonConverter.cs`, revisar também `RestWithASPNET10Erudio.Tests/PersonConverterTests.cs`.
- Quando houver mudança de contrato JSON em `V2`, revisar também o `README.md`.

## Linha de fim de arquivo

- O repositório deve usar `LF` como final de linha versionado.
- Respeitar `.gitattributes` como fonte principal para EOL.
- Evitar editores ou scripts que regravem arquivos com `CRLF` sem necessidade.
- Se o Git acusar `LF will be replaced by CRLF`, corrigir a política de EOL antes de seguir com commits adicionais.

## Validação mínima

- `dotnet test`
- Conferir `git diff --stat`
- Conferir `git status --short` antes e depois do commit

## Escopo e segurança

- Não mover, renomear ou apagar arquivos fora do escopo pedido sem necessidade clara.
- Não introduzir mudanças de massa por encoding ou formatação sem avisar.
- Se o workspace estiver com mudanças paralelas do usuário, trabalhar de forma isolada e evitar colisões.
