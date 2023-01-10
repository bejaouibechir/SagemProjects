namespace API.Services
{
    static public class CollectionServiceExtension
    {
        static public void AddCoffeeShop(this IServiceCollection services)
        {
            services.AddScoped<ICoffeeShopService, CoffeeShopService>();
        }
    }
}
