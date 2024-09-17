using System.Linq.Expressions;

namespace TestASP.Repository.Base
{
    public interface IRepository<T> where T : class
    {
        T FindById(int id);

        T SelectOne(Expression<Func<T, bool>> match);

        IEnumerable<T> FindAll();

        IEnumerable<T> FindAll(params string[] agers);

        Task<T> FindByIdAsync(int id);

        Task<IEnumerable<T>> FindAllAsync();

        Task<IEnumerable<T>> FindAllAsync(params string[] agers);

        void AddOne(T myitem);

        void UpdateOne(T myitem);

        void DeleteOne(T myitem);

        void AddList(IEnumerable<T> mylist);

        void UpdateList(IEnumerable<T> mylist);

        void DeleteList(IEnumerable<T> mylist);

    }
}
