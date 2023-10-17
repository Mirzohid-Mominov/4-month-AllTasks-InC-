using N53_HT1.Models;

namespace N53_HT1.Events
{
    public class OrderEventStore
    {
        public event Func<Order, ValueTask>? OnOrderCreated;

        public async ValueTask<Order> CreateOrderCreatedEventAsync(Order order)
        {
            if (OnOrderCreated != null)
                await OnOrderCreated(order);

            return order;
        }
    }
}
