using N53_HT1.Models;
using System.Data;
using System.Linq.Expressions;

namespace N53_HT1.Services
{
    public class OrderService
    {
        private readonly IDataContext _dataContext;

        public OrderService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }   

        public IQueryable<Order> Get(Expression<Func<Order, bool>> predicate)
        {
            return _dataContext.Orders.Where(predicate.Compile()).AsQueryable();
        }

        public ValueTask<ICollection<Order>> GetAsync(IEnumerable<Guid> ids)
        {
            var foundOrder = _dataContext.Orders.Where(order => ids.Contains(order.Id));
            return new ValueTask<ICollection<Order>>(foundOrder.ToList());
        }

        public ValueTask<Order> GetByIdAsync(Guid id)
        {
            var foundOrder = _dataContext.Orders.FirstOrDefault(order => order.Id == id);
            return new ValueTask<Order>(foundOrder);
        }

        public async ValueTask<Order> CreateAsync(Order order, bool saveChanges = true)
        {
            _dataContext.Orders.AddAsync(order);
            if(saveChanges)
                await _dataContext.SaveChangesAsync();  
            return order;
        }

        public async ValueTask<Order> UpdateAsync(Order order, bool saveChanges = true)
        {
            var foundOrder = _dataContext.Orders.FirstOrDefault(order=> order.Id == order.Id);
            if (foundOrder is null)
                throw new InvalidOperationException("Order not found");

            foundOrder.Id = order.Id;
            foundOrder.Id = order.Id;
            foundOrder.TotalAmount = order.TotalAmount;

            await _dataContext.SaveChangesAsync();
            return foundOrder;
        }

        public async ValueTask<Order> DeleteAsync(Order order, bool saveChanges = true)
        {
            var foundOrder = await GetByIdAsync(order.Id);

            if (foundOrder is null)
                throw new InvalidOperationException("Order not found");

            await _dataContext.Orders.RemoveAsync(foundOrder);
            await _dataContext.SaveChangesAsync();

            return foundOrder;
        }

        public async ValueTask<Order> DeletaAsync(Guid id)
        {
            var foundOrder = await GetByIdAsync(id);

            if (foundOrder is null)
                throw new InvalidOperationException("Order not found");


            await _dataContext.Orders.RemoveAsync(foundOrder);
            await _dataContext.SaveChangesAsync();

            return foundOrder;
        }
    }
}
