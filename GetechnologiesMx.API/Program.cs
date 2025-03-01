using GetechnologiesMx.API.Configurations;
using SharedKernel.Middleware;
using Microsoft.EntityFrameworkCore.Sqlite;
using GetechnologiesMx.Service.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApiDbContext>(Options =>
{
    Options.UseSqlite(builder.Configuration.GetConnectionString("GetechnologiesMxDB"));
});

var _config = new ConfigurationBuilder().AddJsonFile(
Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"), false);
IConfiguration configuration = _config.Build();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configurar_Repositories();
//builder.Services.AddConfigurationAuth(configuration);
builder.Services.AddConfigurationDBA(configuration);
//builder.Services.AgregarTokenSwagger();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseCorrs();
//app.UseAuthentication();
//app.UseAuthorization();
//app.UseAuthorization();

app.MapControllers();

app.Run();
