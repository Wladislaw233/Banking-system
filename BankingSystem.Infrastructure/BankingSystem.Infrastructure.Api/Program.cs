using System.Reflection;
using BankingSystem.Application.Services.Mapping;
using BankingSystem.Application.Services.Services;
using BankingSystem.Infrastructure.Api;
using BankingSystem.Infrastructure.Api.Middlewares;
using BankingSystem.Infrastructure.Api.Validation;
using BankingSystem.Infrastructure.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddBankingSystemDbContext();

builder.Services.AddBankServices();

builder.Services.AddHostedService<MyHostedService>();
builder.Services.AddValidation();

builder.Services.AddMapping();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();