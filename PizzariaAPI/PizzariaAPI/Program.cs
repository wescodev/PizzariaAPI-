using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;
using PizzariaAPI.Interfaces;
using PizzariaAPI.Interfaces.IRepositories;
using PizzariaAPI.Interfaces.Repositories;
using PizzariaAPI.Repositories;
using PizzariaAPI.Services;
using System;
using Npgsql.EntityFrameworkCore.PostgreSQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<EmailService>();

//registro do repositório
builder.Services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

//registro de servico
builder.Services.AddScoped<ICategoriaProdutoService, CategoriaProdutoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IClienteService, ClienteService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", builder => 
    {
        builder.WithOrigins(
            "http://127.0.0.1:5501",
            "http://127.0.0.1:5500",
            "http://localhost:5501",
            "http://localhost:5500",
            "https://martiniclayton.github.io"

        )
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigins"); 

app.UseAuthorization();

app.MapControllers();

app.Run();