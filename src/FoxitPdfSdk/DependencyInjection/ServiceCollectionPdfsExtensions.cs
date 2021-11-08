using FoxitPdfSdk.Pdfs;
using Microsoft.Extensions.DependencyInjection;

namespace FoxitPdfSdk.DependencyInjection
{
    public static class ServiceCollectionPdfsExtensions
    {
        public static IServiceCollection AddPdfs(this IServiceCollection services)
        {
            services
                .AddOptions<FoxitPdfOptions>()
                .BindConfiguration(FoxitPdfOptions.SectionName);

            services.AddSingleton<IPdfGenerator, PdfGenerator>();

            return services;
        }
    }
}
