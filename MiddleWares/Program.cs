namespace MiddleWares;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.UseMiddleware<CultureMiddleWare>();
        app.MapGet("/", () => DateTime.Now.ToString());

        app.Run();
    }
}