using TestASP.Data;
using TestASP.Models;
using TestASP.Repository.Base;

namespace TestASP.Repository
{
    public class EmpRepo : MainRepository<Employee>, IEmpRepo
    {
        public EmpRepo(AppDBcontext context) : base(context)
        {
            _context = context;
        }

        private readonly AppDBcontext _context;

        public decimal getSalary(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void setPayRoll(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
