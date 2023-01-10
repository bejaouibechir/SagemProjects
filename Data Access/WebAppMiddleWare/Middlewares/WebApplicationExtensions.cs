using System.Runtime.CompilerServices;

namespace WebAppMiddleWare.Middlewares
{
    static public class WebApplicationExtensions
    {
        static public void UseMonMiddleWare(this WebApplication app)
        {
            app.UseMiddleware<MonMiddleWare>();
        }
    }
}
