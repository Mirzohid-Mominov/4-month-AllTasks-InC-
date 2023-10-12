
using Microsoft.Extensions.DependencyInjection;
using User_Event_N52_HT1;
using User_Event_N52_HT1.Models;

var builder = new ServiceCollection();

builder.AddSingleton<AccountNotificationService>().AddSingleton<AccountOrchestrationService>().AddSingleton<AccountEventStore>();

var services = builder.BuildServiceProvider();

var userService = services.GetService<AccountNotificationService>() ?? throw new InvalidOperationException();
var accountService = services.GetRequiredService<AccountOrchestrationService>();

var user = new User
{
    Id = Guid.NewGuid(),
    FirstName = "Azizbek",
    LastName = "Abdurahmonov",
    EmailAddress = "Abdura52"
};

var createdUser = await userService.Create(user);
Console.WriteLine(createdUser.FirstName);