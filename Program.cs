using Microsoft.EntityFrameworkCore;
using PasswordManager.PasswordManagerServices.Services;
using PasswordManager.Infrastructure.Data;
using PasswordManager.Infrastructure.Repositories;
using PasswordManager.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();

builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();
builder.Services.AddScoped<IPasswordService, PasswordService>();

builder.Services.AddTransient<AesEncryptionStrategy>();
builder.Services.AddTransient<RsaEncryptionStrategy>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (!File.Exists("private_key.xml") || !File.Exists("public_key.xml"))
{
    RsaKeyManager.GenerateKeys();
}

var apiKey = builder.Configuration["ApiKey"];

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Use(async (context, next) =>
{
    if (!context.Request.Headers.TryGetValue("x-api-key", out var extractedApiKey) || extractedApiKey != apiKey)
    {
        context.Response.StatusCode = 401; // Unauthorized
        await context.Response.WriteAsync("Accès refusé : Clé API invalide !");
        return;
    }
    await next();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
