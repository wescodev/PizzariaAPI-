using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;
using PizzariaAPI.Interfaces;
using PizzariaAPI.Interfaces.IRepositories;
using PizzariaAPI.Interfaces.Repositories;
using PizzariaAPI.Repositories;
using PizzariaAPI.Services;
using System;
using Npgsql.EntityFrameworkCore.PostgreSQL;
//using Npgsql.EntityFrameworkCore.PostgreSQL; // <--- ESTE USING FOI ADICIONADO AQUI!

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql( // <--- AGORA ESTÁ USANDO NPGSQL
        builder.Configuration.GetConnectionString("DefaultConnection")
    // A linha "ServerVersion.AutoDetect" foi removida pois é específica do MySQL
    ));

builder.Services.AddScoped<EmailService>();

//registro do repositório
builder.Services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>(); // Corrigido para a interface correta
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


//registro de servico
builder.Services.AddScoped<ICategoriaProdutoService, CategoriaProdutoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevPolicy", builder =>
    {
        builder.WithOrigins("http://127.0.0.1:5500").AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseCors("DevPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();