using Api.Data;
using Api.Repositorios;
using Api.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<Contexto>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );

builder.Services.AddScoped <IAgendamentoRepositorio, AgendamentoRepositorio>();
builder.Services.AddScoped <IAssinaturaClubeRepositorio, AssinaturaClubeRepositorio>();
builder.Services.AddScoped <IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped <IClubeRepositorio, ClubeRepositorio>();
builder.Services.AddScoped <IFormaPagamentoRepositorio, FormaPagamentoRepositorio>();
builder.Services.AddScoped <IPagamentoAgendamentoRepositorio, PagamentoAgendamentoRepositorio>();
builder.Services.AddScoped <IPagamentoAssinaturaRepositorio, PagamentoAssinaturaRepositorio>();
builder.Services.AddScoped <IProcedimentoRepositorio, ProcedimentoRepositorio>();
builder.Services.AddScoped <IProfissionalRepositorio, ProfissionalRepositorio>();
builder.Services.AddScoped <ITipoClubeRepositorio, TipoClubeRepositorio>();
builder.Services.AddScoped <ITipoPlanoRepositorio, TipoPlanoRepositorio>();
builder.Services.AddScoped <ITipoProcedimentoRepositorio, TipoProcedimentoRepositorio>();
builder.Services.AddScoped <ITipoProfissionalRepositorio, TipoProfissionalRepositorio>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors();

app.MapControllers();

app.Run();
