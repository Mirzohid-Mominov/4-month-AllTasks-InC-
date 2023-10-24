
namespace MiddleWareAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.Use(async (context, next) =>
        {
            var message = $"{DateTimeOffset.Now:u} request path - {context.Request.Path} with method {context.Request.Method}";

            await using var fileStream = File.Open("log.txt", FileMode.Append, FileAccess.Write);
            await using var streamWriter = new StreamWriter(fileStream);
            await streamWriter.WriteLineAsync(message);

            await next();
        });

        app.MapGet("/", () => Results.Ok("Hello World"));
        app.Run();
    }
}