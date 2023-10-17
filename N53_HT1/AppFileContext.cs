using FileBaseContext.Abstractions.Models.Entity;
using FileBaseContext.Abstractions.Models.FileContext;
using FileBaseContext.Abstractions.Models.FileEntry;
using FileBaseContext.Abstractions.Models.FileSet;
using FileBaseContext.Context.Models.Configurations;
using FileBaseContext.Context.Models.FileContext;
using N53_HT1.Models;

namespace N53_HT1
{
    public class AppFileContext : FileContext, IDataContext
    {
        public AppFileContext(IFileContextOptions<IFileContext> fileContextOptions) : base(fileContextOptions)
        {
            OnSaveChanges += AddPrimaryKey;
        }

        public IFileSet<User, Guid> Users => Set<User, Guid>(nameof(Users));

        public IFileSet<Order, Guid> Orders => Set<Order, Guid>(nameof(Orders));

        public IFileSet<Bonus, Guid> Bonuses => Set<Bonus, Guid>(nameof(Bonuses));

        public ValueTask AddPrimaryKey(IEnumerable<IFileSetBase> files)
        {
            foreach (IFileSetBase file in files)
                foreach(var item in file.GetEntries())
                {
                    if (item is not IFileEntityEntry<IEntity> entityEntry) continue;

                    if (entityEntry.State == FileEntityState.Added)
                        entityEntry.Entity.Id = Guid.NewGuid();

                    if (item is not IFileEntityEntry<IFileSetEntity<Guid>> fileSetEntry) continue;
                }
            return new ValueTask(Task.CompletedTask);
        }
    }
}
