using System.IO.Compression;
using Microsoft.AspNetCore.ResponseCompression;

namespace Modular.NetCore.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddCompression(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<GzipCompressionProviderOptions>(o => o.Level = CompressionLevel.Optimal);
        builder.Services.AddResponseCompression(o =>
        {
            o.Providers.Add<GzipCompressionProvider>();
        });

        return builder;
    }

    public static WebApplicationBuilder AddCorsPolicy(this WebApplicationBuilder builder, string origins)
    {
        builder.Services
            .AddCors(corsOptions =>
                corsOptions.AddDefaultPolicy(corsPolicyBuilder =>
                    corsPolicyBuilder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins(origins.Split(","))));

        return builder;
    }

    public static WebApplicationBuilder AddHttpContextAccessor(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();
        return builder;
    }

    public static WebApplicationBuilder AddHealthChecks(this WebApplicationBuilder builder)
    {
        builder.Services.AddHealthChecks();
        return builder;
    }

    public static WebApplicationBuilder AddRestApiServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        return builder;
    }
}