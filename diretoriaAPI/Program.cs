using diretoriaAPI.Infrastructure.Interface;
using diretoriaAPI.Infrastructure.Repository;
using diretoriaAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DiretoriaDatabaseSettings>(
    builder.Configuration.GetSection("DiretoriaDatabase"));

builder.Services.AddTransient<IDiretoriaInterface, DiretoriarRepository>();
builder.Services.AddTransient<IFraseInterface, FraseRepository>();

builder.Services.AddAutoMapper(typeof(Program));

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
