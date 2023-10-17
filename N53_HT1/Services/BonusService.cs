using N53_HT1.Models;
using System.Linq.Expressions;

namespace N53_HT1.Services
{
    public class BonusService
    {
        private readonly IDataContext _dataContext;

        public BonusService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IQueryable<Bonus> Get(Expression<Func<Bonus, bool>> predicate)
        {
            return _dataContext.Bonuses.Where(predicate.Compile()).AsQueryable();
        }

        public ValueTask<ICollection<Bonus>> GetAsync(IEnumerable<Guid> ids)
        {
            var bonuses = _dataContext.Bonuses.Where(bonus => ids.Contains(bonus.Id));
            return new ValueTask<ICollection<Bonus>>(bonuses.ToList());
        }

        public ValueTask<Bonus> GetByIdAsync(Guid id)
        {
            var foundBonus = _dataContext.Bonuses.FirstOrDefault(bonus => bonus.Id == id);
            return new ValueTask<Bonus>(foundBonus);
        }

        public async ValueTask<Bonus> CreateAsync(Bonus bonus, bool saveChanges = true)
        {
            await _dataContext.Bonuses.AddAsync(bonus);
            if(saveChanges)
                await _dataContext.SaveChangesAsync();
            return bonus;
        }

        public async ValueTask<Bonus> UpdateAsync(Bonus bonus, bool savChanges = true)
        {
            var foundBonus = _dataContext.Bonuses.FirstOrDefault(x => x.Id == bonus.Id);

            if (foundBonus is null)
                throw new InvalidOperationException("bonus not found");
            foundBonus.Description = bonus.Description;
            foundBonus.Id = bonus.Id;
            foundBonus.Amount = bonus.Amount;

            await _dataContext.SaveChangesAsync();
            return foundBonus;
        }

        public async ValueTask<Bonus> DeleteAsync(Bonus bonus, bool saveChanges = true)
        {
            var foundBonus = await GetByIdAsync(bonus.Id);

            if (foundBonus is null)
                throw new InvalidOperationException($"{nameof(bonus)} is not found");

            await _dataContext.Bonuses.RemoveAsync(foundBonus);
            await _dataContext.SaveChangesAsync();

            return foundBonus;
        }

        public async ValueTask<Bonus> DeleteAsync(Guid id, bool saveChanges = true)
        {
            var foundBonus = await GetByIdAsync(id);

            if (foundBonus is null)
                throw new InvalidOperationException("bonus is not found");

            await _dataContext.Bonuses.RemoveAsync(foundBonus);
            await _dataContext.SaveChangesAsync();

            return foundBonus;
        }
    }
}
