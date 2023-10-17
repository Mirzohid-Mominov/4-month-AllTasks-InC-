using N53_HT1.Models;

namespace N53_HT1.Events
{
    public class BonusEventStore
    {
        public event Func<Bonus, ValueTask> OnBonusAchieveated;

        public async ValueTask<Bonus> CreateBonusCreatedEventAsync(Bonus bonus)
        {
            if(OnBonusAchieveated != null)
                await OnBonusAchieveated(bonus);
            return bonus;
        }
    }
}
