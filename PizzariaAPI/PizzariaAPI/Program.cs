using Microsoft.EntityFrameworkCore;
using PizzariaAPI.Data;
using PizzariaAPI.Interfaces;
using PizzariaAPI.Interfaces.IRepositories;
using PizzariaAPI.Interfaces.Repositories;
using PizzariaAPI.Repositories;
using PizzariaAPI.Services;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

builder.Services.AddScoped<EmailService>();

//registro do repositório
builder.Services.AddScoped<ICategoriaProdutoRepository, CategoriaProdutoRepository>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


//registro de servico
builder.Services.AddScoped<ICategoriaProdutoService, CategoriaProdutoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
