using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Kaya.AspNetCore;

public static class AspNetCoreKayaExtensions
{
    public static void AddKayaLogging(this IServiceCollection services, IKayaCredentials credentials)
    {
        services.AddTransient(typeof(IKayaHttpClient), _ => new KayaHttpClient(credentials.Endpoint));
        services.AddScoped(typeof(IKayaContext), _ => new KayaContext(_.GetRequiredService<IKayaHttpClient>(), credentials));
        services.AddScoped<KayaExceptionFilter>();
        services.AddTransient<KayaTraceIdentifierLoggerMiddleware>();
        
        services.AddMvc(options => options.Filters.Add(typeof(KayaExceptionFilter), 1000));
    }
    
    public static void UseKayaLogging(this IApplicationBuilder app)
    {
        app.UseMiddleware<KayaTraceIdentifierLoggerMiddleware>();
    }
}