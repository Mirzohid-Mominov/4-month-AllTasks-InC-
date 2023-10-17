namespace N53_HT1.Services
{
    public class TelegramSenderService : INotificationService
    {
        public ValueTask SendAsync(Guid userId, string content)
        {
            Console.WriteLine($"Sending message to {userId} with content {content}");

            return new ValueTask();
        }
    }
}
