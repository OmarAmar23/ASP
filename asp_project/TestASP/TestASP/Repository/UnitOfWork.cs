using TestASP.Data;
using TestASP.Models;
using TestASP.Repository.Base;

namespace TestASP.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AppDBcontext context)
        {
            _context = context;

            categories = new MainRepository<Category>(_context);
            items = new MainRepository<Item>(_context);
            employees = new EmpRepo(_context);

        }
        private readonly AppDBcontext _context;

        public IRepository<Category> categories { get; private set; }

        public IRepository<Item> items { get; private set; }

        public IEmpRepo employees { get; private set; }

        public int CommitChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }


}
