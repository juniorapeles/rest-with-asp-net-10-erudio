using RestWithASPNET10Erudio.Configurations;
using RestWithASPNET10Erudio.Services;
using RestWithASPNET10Erudio.Services.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//adicionando a configuração do banco de dados
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// =============================
// 🔹 LIFETIMES (ESCOPOS) NO .NET DI
// =============================
//
// O .NET possui 3 tipos principais de ciclo de vida (lifetime)
// para serviços registrados no container de injeção de dependência:
//
// 1) Singleton
// 2) Scoped
// 3) Transient
//
// A escolha correta é MUITO importante para evitar:
// - vazamento de memória
// - concorrência inesperada
// - dados inconsistentes entre requisições
//
// =============================
// 🔸 Singleton
// =============================
//
// Uma única instância é criada e reutilizada durante TODA a vida da aplicação.
//
// ✔ Criado uma vez (no primeiro uso ou startup)
// ✔ Compartilhado entre TODAS as requisições
// ✔ Mesma instância para todos os usuários
//
// ⚠ Cuidado:
// - Precisa ser thread-safe
// - NÃO deve guardar estado mutável por usuário
//
// 🧠 Use quando:
// - serviços stateless
// - cache
// - utilitários
//
// Exemplo:
//builder.Services.AddSingleton<MathService>();

// Nesse caso:
// - MathService será criado uma única vez
// - Todos os controllers/services vão usar a MESMA instância



// =============================
// 🔸 Scoped
// =============================
//
// Uma instância é criada POR REQUISIÇÃO HTTP.
//
// ✔ Cada request recebe sua própria instância
// ✔ Dentro da mesma request, é reutilizado
// ✔ Entre requests, é recriado
//
// 🧠 Use quando:
// - regra de negócio
// - acesso a banco (DbContext)
// - dados relacionados ao contexto da requisição
//
// Exemplo:
builder.Services.AddScoped<IPersonServices, PersonServicesImpl>();

// Nesse caso:
// - Para cada requisição HTTP:
//      -> cria 1 PersonServicesImpl
// - Se dentro da mesma request for chamado várias vezes:
//      -> reutiliza a mesma instância
//
// 💡 Analogia:
// É como o @Scope("request") do Spring



// =============================
// 🔸 Transient
// =============================
//
// Uma nova instância é criada TODA VEZ que for solicitada.
//
// ✔ Nunca reutiliza
// ✔ Sempre novo objeto
//
// 🧠 Use quando:
// - objetos leves
// - sem estado
// - operações rápidas
//
// Exemplo:
// builder.Services.AddTransient<IEmailService, EmailService>();



// =============================
// ⚠️ REGRAS IMPORTANTES
// =============================
//
// ❌ NUNCA injete Scoped dentro de Singleton
// Isso causa erro ou comportamento imprevisível
//
// ✔ Singleton pode depender apenas de:
//    - Singleton
//
// ✔ Scoped pode depender de:
//    - Scoped
//    - Singleton
//
// ✔ Transient pode depender de:
//    - qualquer um
//
// =============================
// 🧠 RESUMO MENTAL
// =============================
//
// Singleton → 1 instância pra aplicação inteira
// Scoped    → 1 instância por requisição HTTP
// Transient → 1 instância por uso
//
// =============================

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
