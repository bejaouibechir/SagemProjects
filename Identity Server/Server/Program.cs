//Pour decouvrir les paramètres de l'identity server
//https://localhost:5443/.well-known/openid-configuration

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Server;
using Server.Data;

/* ---------  Etape 3 s'assurer qu'au moins un utilisateur est ajouté pour la première fois avant d'utiliser le serveur----------*/
var seed = args.Contains("/seed");
if (seed) /*Juste il faut l'enlever de l'addresse avant la construction de l'application */
{
    args = args.Except(new[] { "/seed" }).ToArray();
}
/* --------- Fin Etape 3 ----------*/

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly.GetName().Name;
var defaultConnString = builder.Configuration.GetConnectionString("DefaultConnection");

/* ---------  Etape 3 ----------*/
if (seed)
{
    SeedData.EnsureSeedData(defaultConnString);
}
/* --------- Fin Etape 3 ----------*/

/* ---------               Etape 2 après la génération des migration de Identity Server -----------------------------*/

builder.Services.AddDbContext<AspNetIdentityDbContext>(options =>
    options.UseSqlServer(defaultConnString,
        b => b.MigrationsAssembly(assembly)));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AspNetIdentityDbContext>();

/* ---------              Fin Etape 2  ------------------------------------------------------------------------------*/


/* ---------               Etape 1 avant la génération des migration de Identity Server -----------------------------*/



builder.Services.AddIdentityServer()/*Ajoutée dans etape 2 également -> */.AddAspNetIdentity<IdentityUser>()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b =>
        b.UseSqlServer(defaultConnString, options => options.MigrationsAssembly(assembly));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b =>
        b.UseSqlServer(defaultConnString, options => options.MigrationsAssembly(assembly));
    })
    .AddDeveloperSigningCredential();

/* ---------              Fin Etape 1  ------------------------------------------------------------------------------*/

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddMvc();


var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();



//app.MapGet("/", () => "Hello world");
app.UseIdentityServer();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
