using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TestASP.Data;
using TestASP.Models;
using TestASP.Repository.Base;

namespace TestASP.Repository
{
    public class MainRepository<T> : IRepository<T> where T : class
    {


        public MainRepository(AppDBcontext context)
        {
             this.context = context;
        }

        protected AppDBcontext context;



        public T FindById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T SelectOne(Expression<Func<T, bool>> match)
        {
            return context.Set<T>().SingleOrDefault(match);
        }

        public IEnumerable<T> FindAll()
        {
            return context.Set<T>().ToList();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> FindAll(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();

            if(agers.Length > 0)
            {
                foreach(var ager in agers)
                {
                    query = query.Include(ager);    
                }
            }
            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();

            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }
            return await query.ToListAsync();
        }

        //===============================================================//

        public void AddOne(T myitem)
        {
            context.Set<T>().Add(myitem);
            context.SaveChanges();
        }

        public void UpdateOne(T myitem)
        {
            context.Set<T>().Update(myitem);
            context.SaveChanges();
        }

        public void DeleteOne(T myitem)
        {
            context.Set<T>().Remove(myitem);
            context.SaveChanges();
        }

        public void AddList(IEnumerable<T> mylist)
        {
            context.Set<T>().AddRange(mylist);
            context.SaveChanges();
        }

        public void UpdateList(IEnumerable<T> mylist)
        {
            context.Set<T>().UpdateRange(mylist);
            context.SaveChanges();
        }

        public void DeleteList(IEnumerable<T> mylist)
        {
            context.Set<T>().RemoveRange(mylist);
            context.SaveChanges();
        }
    }
}
