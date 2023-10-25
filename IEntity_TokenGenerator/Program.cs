using IEntity_TokenGenerator.Services;

namespace IEntity_TokenGenerator;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<AuthService>();
        builder.Services.AddTransient<TokenGeneratorService>();
        builder.Services.AddControllers();

        var app = builder.Build();

        app.MapControllers();

        app.Run();
    }
}