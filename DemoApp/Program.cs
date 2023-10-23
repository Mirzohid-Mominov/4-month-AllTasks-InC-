
using DemoApp;
using DemoApp.Dtos;
using DemoApp.Entities;
using Sharprompt;

var service = new UserService();

while(true)
{
    object choose = Prompt.Select("Tanlang : ", new[] { "User yaratish", "Get users" });

    if(choose == "User yaratish")
    {
        var firstName = Prompt.Input<string>("Enter your FirstName ");
        var lastName = Prompt.Input<string>("Enter your LastName ");
        var email = Prompt.Input<string>("Enter your email ");
        var password = Prompt.Input<string>("Enter your password ");
        var userName = Prompt.Input<string>("Enter your userName ");

        var user = new UserForCreation()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password,
            UserName = userName
        };

        service.Create(user);
    }

    else if(choose == "Get users")
    {
        var users = service.GetUsers();

        foreach(var user in users)
        {
            Console.WriteLine($"{user.FirstName} {user.LastName} {user.UserName} {user.CreatedAt}");
            Prompt.Input<string>(" ");
        }
    }

    Console.Clear();
}    