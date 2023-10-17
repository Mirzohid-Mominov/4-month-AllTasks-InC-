using FileBaseContext.Abstractions.Models.Entity;

namespace N53_HT1.Models
{
    public class Order : IEntity
    {
        public Order(Guid id, Guid userId, string orderItems, double totalAmount)
        {
            Id = id;
            UserId = userId;
            OrderItems = orderItems;
            TotalAmount = totalAmount;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string OrderItems { get; set; }
        public double TotalAmount { get; set; }
    }
}
