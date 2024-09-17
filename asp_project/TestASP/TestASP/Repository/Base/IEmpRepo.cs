using TestASP.Models;

namespace TestASP.Repository.Base
{
    public interface IEmpRepo : IRepository<Employee>
    {
        void setPayRoll(Employee employee);

        decimal getSalary(Employee employee);

    }
}
