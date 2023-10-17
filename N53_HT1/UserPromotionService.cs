using N53_HT1.Events;
using N53_HT1.Models;
using N53_HT1.Services;

namespace N53_HT1
{
    public class UserPromotionService
    {
        private readonly BonusEventStore _eventStore;
        private IEnumerable<INotificationService> _notifications;

        public UserPromotionService(BonusEventStore bonusEventStore,
            IEnumerable<INotificationService> notificationServices)
        {
            _eventStore = bonusEventStore;
            _notifications = notificationServices;
            _eventStore.OnBonusAchieveated += HandleBonusAchievedEventAsync;
        }

        public async ValueTask HandleBonusAchievedEventAsync(Bonus bonus)
        {
            foreach (var message in _notifications)
                await message.SendAsync(bonus.UserId, "You have reached bonus!!!");
        }
    }
}
