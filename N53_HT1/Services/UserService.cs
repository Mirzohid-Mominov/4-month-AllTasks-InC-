using N53_HT1.Models;
using System.Linq.Expressions;

namespace N53_HT1.Services
{
    public class UserService
    {
        private readonly IDataContext _dataContext;

        public UserService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
           
        public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        {
            return _dataContext.Users.Where(predicate.Compile()).AsQueryable();
        }

        public ValueTask<ICollection<User>> GetAsync(IEnumerable<Guid> ids)
        {
            var users = _dataContext.Users.Where(user => ids.Contains(user.Id));
            return new ValueTask<ICollection<User>>(users.ToList());
        }

        public ValueTask<User> GetByIdAsync(Guid id)
        {
            var foundUser = _dataContext.Users.FirstOrDefault(user => user.Id == id);   
            return new ValueTask<User>(foundUser);
        }

        public async ValueTask<User> CreateAsync(User user, bool saveChanges = true)
        {
            await _dataContext.Users.AddAsync(user);

            if (saveChanges)
                await _dataContext.SaveChangesAsync();

            return user;
        }

        public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true)
        {
            var foundUser = _dataContext.Users.FirstOrDefault(user=> user.Id == user.Id);

            if(foundUser is null) 
                throw new InvalidOperationException(nameof(user));

            foundUser.FirstName = user.FirstName;
            foundUser.LastName = user.LastName;
            foundUser.EmailAddress = user.EmailAddress;

            await _dataContext.SaveChangesAsync();
            return foundUser;
        }

        public async ValueTask<User> DeleteAsync(User user, bool saveChanges = true)
        {
            var foundUser = await GetByIdAsync(user.Id);

            if(foundUser is null)
                throw new InvalidOperationException($"{nameof(user)} is not found");

            await _dataContext.Users.RemoveAsync(foundUser);
            await _dataContext.Users.SaveChangesAsync();

            return foundUser;
        }

        public async ValueTask<User> DeleteAsync(Guid id, bool saveChanges = true)
        {
            var foundUser = await GetByIdAsync(id);

            if(foundUser is null)
                throw new InvalidOperationException("User not found");

            await _dataContext.Users.RemoveAsync(foundUser);
            await _dataContext.Users.SaveChangesAsync(); 
            return foundUser;
        }
    }
}
