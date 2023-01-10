using Microsoft.EntityFrameworkCore;
using Sagem.DataAccess.SQL.DF.Data;
using Sagem.DataAccess.SQL.DF.Services;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

#region zone des service

var configuration = builder.Configuration;

// Add services to the container.
var port = configuration["port"];
builder.Services.AddControllers();
builder.Services.AddDatabaseService(configuration);

//A été remplacée par une méthode d'extension 
//builder.Services.AddDbContext<BusinessDBContext>(options =>
//options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

#endregion

//Création de l'application 
var app = builder.Build();

// Configure the HTTP request pipeline.

#region zone des middle ware



//Task methode(HttpContext arg1, Func<Task> arg2)
//{
//    throw new NotImplementedException();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



#endregion