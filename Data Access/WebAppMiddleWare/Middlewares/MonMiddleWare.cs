using System.Diagnostics;

namespace WebAppMiddleWare.Middlewares
{
    public class MonMiddleWare
    {
        private readonly RequestDelegate _next;

        public MonMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //Develpper tout ce qui est développement de requêtes
            Debug.WriteLine(context.Request.Path);
           await _next(context);
            ;
            

            //Develpper tout ce qui est développement de responses
        }

    }
}
