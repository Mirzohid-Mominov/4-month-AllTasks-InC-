
using FileBaseContext.Context.Models.Configurations;
using N53_HT1;
using N53_HT1.Events;
using N53_HT1.Models;
using N53_HT1.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<IDataContext, AppFileContext>(_ =>
{
    var options = new FileContextOptions<AppFileContext>
    {
        StorageRootPath = Path.Combine(builder.Environment.ContentRootPath, "Data", "Storage")
    };

    var context = new AppFileContext(options);
    context.FetchAsync().AsTask().Wait();
    return context;
});


builder.Services.AddSingleton<UserService, UserService>()
    .AddSingleton<OrderEventStore>()
    .AddSingleton<BonusEventStore>()
    .AddSingleton<UserBonusService>()
    .AddSingleton<UserPromotionService>()
    .AddSingleton<BonusService, BonusService>()
    .AddSingleton<OrderService, OrderService>()
    .AddSingleton<INotificationService, EmailSenderService>()
    .AddSingleton<INotificationService, SmsSenderService>()
    .AddSingleton<INotificationService, TelegramSenderService>();


    

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.     
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var test1 = app.Services.GetRequiredService<UserPromotionService>();
var test2 = app.Services.GetRequiredService<UserBonusService>();


app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
