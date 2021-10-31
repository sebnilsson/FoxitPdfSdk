using FoxitPdfSdk.Products;
using Microsoft.Extensions.DependencyInjection;

namespace FoxitPdfSdk.DependencyInjection
{
    public static class ServiceCollectionProductsExtensions
    {
        public static IServiceCollection AddProducts(this IServiceCollection services)
        {
            services.AddSingleton<IProductService, ProductService>();

            return services;
        }
    }
}
