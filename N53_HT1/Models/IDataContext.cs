using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.FileContext;

namespace N53_HT1.Models
{
    public interface IDataContext
    {
        IFileSet<User, Guid> Users { get; }
        IFileSet<Order, Guid> Orders { get; }
        IFileSet<Bonus, Guid> Bonuses { get; }
        ValueTask SaveChangesAsync();
    }
}
