using diretoriaAPI.Infrastructure.Interface;
using diretoriaAPI.Infrastructure.Service;
using diretoriaAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DiretoriaDatabaseSettings>(
    builder.Configuration.GetSection("DiretoriaDatabase"));

builder.Services.AddTransient<IDiretoriaService, DiretoriaService>();
builder.Services.AddTransient<IFraseService, FraseService>();

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
