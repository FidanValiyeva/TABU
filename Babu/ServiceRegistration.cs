using Babu.Services.Abstarcts;
using Babu.Services.Implements;

namespace Babu
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
           services.AddScoped<ILanguageService, LanguageService>();
           services.AddScoped<IWordService,WordService>();
           services.AddScoped<IWordService, WordService>();



           return services;


        }
    }
}
