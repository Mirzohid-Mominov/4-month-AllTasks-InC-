using FileBaseContext.Abstractions.Models.Entity;
using Humanizer;

namespace N53_HT1.Models
{
    public class Bonus : IEntity
    {
        public Bonus(Guid id, double amount, string description, Guid userId)
        {
            Id = id;
            Amount = amount;
            Description = description;
            UserId = userId;
        }

        public Guid Id { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
    }
}                                                                                                   