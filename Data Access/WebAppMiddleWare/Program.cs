using System.Diagnostics;
using WebAppMiddleWare.Middlewares;

var builder = WebApplication.CreateBuilder(args);



var app = builder.Build();

//Middleware 1
app.Use(async (context, next) =>
{
    Debug.WriteLine("Requete middleware 1");
    await next();
    Debug.WriteLine("Reponse middleware 1");
});

//Middleware 2
app.Use(async (context, next) =>
{
    Debug.WriteLine("Requete middleware 2");
    await next();
    Debug.WriteLine("Reponse middleware 2");
});

//Middleware 3
app.Use(async (context, next) =>
{
    Debug.WriteLine("Requete middleware 3");
    await next();
    Debug.WriteLine("Reponse middleware 3");
});

app.UseMonMiddleWare();

string flag = "false";

app.MapWhen(context=>context.Request);

void methode(IApplicationBuilder obj)
{
    ;
}

app.MapGet("/h", () => "Hello World!");

app.Run();


