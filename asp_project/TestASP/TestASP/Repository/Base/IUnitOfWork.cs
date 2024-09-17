using TestASP.Models;

namespace TestASP.Repository.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> categories { get; }

        IRepository<Item> items { get; }

        IEmpRepo employees { get; }

        int CommitChanges();


    }
}
