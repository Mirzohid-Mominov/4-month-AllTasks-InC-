using N53_HT1.Events;
using N53_HT1.Models;
using N53_HT1.Services;

namespace N53_HT1
{
    public class UserBonusService
    {
        private readonly OrderEventStore _orderEventStore;
        private readonly BonusEventStore _bonusEventStore;
        private readonly UserService _userService;
        private readonly BonusService _bonusService;
        private IEnumerable<INotificationService> _notificationService;


        public UserBonusService(OrderEventStore orderEventStore, UserService userService,
            BonusEventStore bonusEventStore, BonusService bonusService,
            IEnumerable<INotificationService> notificationServices)
        {
            _orderEventStore = orderEventStore;
            _userService = userService;
            _bonusService = bonusService;
            _notificationService = notificationServices;
            _notificationService = notificationServices;

            orderEventStore.OnOrderCreated += HandleOrderCreatedEventAsync;
        }

        public async ValueTask HandleOrderCreatedEventAsync(Order order)
        {
            var foundUser = _userService.Get(user => user.Id == order.Id).FirstOrDefault();
            var foundBonus = _bonusService.Get(bonus => bonus.Id == order.Id).FirstOrDefault();

            var bonusLength = foundBonus.Amount.ToString().Length;
            var createdNewBonus = (foundBonus.Amount + order.TotalAmount).ToString().Length;

            var changedAmount = new Bonus(foundBonus.Id, foundBonus.Amount + order.TotalAmount, foundBonus.Description, foundBonus.UserId);
            await _bonusService.UpdateAsync(changedAmount);


            if (bonusLength < createdNewBonus)
            {
                await _bonusEventStore.CreateBonusCreatedEventAsync(foundBonus);
                return;
            }


            var numString = "1";
            for (var i = 0; i < bonusLength; i++)
            {
                numString += "0";
            }

            var num = Convert.ToInt32(numString);

            foreach (var item in _notificationService)
                await item.SendAsync(foundUser.Id, $"Bonus qoldig'i - {num - foundBonus.Amount}");
        }
    }
}
