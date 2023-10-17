namespace N53_HT1
{
    public interface INotificationService
    {
        ValueTask SendAsync(Guid userId, string content);
    }
}
