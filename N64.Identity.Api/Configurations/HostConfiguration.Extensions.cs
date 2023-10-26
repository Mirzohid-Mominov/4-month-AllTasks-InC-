using N64.Identity.Application.Common.Identity.Services;
using N64.Identity.Application.Common.Settings;
using N64.Identity.Infrastructure.Common.Identity.Services;

namespace N64.Identity.Api.Configurations
{
    public static partial class HostConfiguration
    {
        public static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder;
        }

        public static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddRouting(options => options.LowercaseUrls = true);

            return builder;
        }

        public static WebApplicationBuilder AddIdentityInfrastructure(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));

            builder.Services.AddTransient<ITokenGeneratorService, TokenGeneratorService>();


            builder.Services.AddScoped<IAuthService, AuthService>();

            return builder;
        }

        public static WebApplication UseDevTools(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }

        public static WebApplication UseExposers(this WebApplication app)
        {
            app.MapControllers();

            return app;
        }

    }
}
