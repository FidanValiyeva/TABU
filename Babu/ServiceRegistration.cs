using Babu.Exceptions;
using Babu.Services.Abstarcts;
using Babu.Services.Implements;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;

namespace Babu
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
           services.AddScoped<ILanguageService, LanguageService>();
           services.AddScoped<IWordService,WordService>();
           services.AddScoped<IWordService, WordService>();
           services.AddScoped<IGameService, GameService>();
           return services;
        }
        /*public static IApplicationBuilder UseBabuExceptionHandler(this IApplicationBuilder app)
        {
            *//*app.UseExceptionHandler(
                opt =>
                {
                    opt.Run(async context =>
                    {
                        var feature = context.Features.GetRequiredFeature<IExceptionHandlerFeature>();
                        var exception = feature.Error;
                        if (exception is IBaseException bEx)
                        {
                            context.Response.StatusCode = bEx.StatusCode;
                            await context.Response.WriteAsJsonAsync(new
                            {
                                Message = bEx.ErrorMessage,
                                StatusCode = bEx.StatusCode

                            });

                        }
                        else
                        {
                            context.Response.StatusCode = 400;
                            await context.Response.WriteAsJsonAsync(new
                            {
                                Message = "Bir xeta oldu(400)",
                            });
                        }
                    });
                });
            return app;*//*
        }*/
    }
}
