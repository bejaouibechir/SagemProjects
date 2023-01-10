/*
 Pour générer une migration executer l'une des deux commandes
Add-Migration FirstMigrartion
dotnet ef migrations add FirstMigrartion202306011414
 */

using Microsoft.EntityFrameworkCore;
using Sagem.DataAccess.SQL.CF.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var configuration = builder.Configuration;

builder.Services.AddDbContext<BusinessDbContext>(options => options
.UseSqlServer(configuration
.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
