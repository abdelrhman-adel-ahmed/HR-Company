using HR_Employess_DataAccess.Entities;
using System.Linq.Expressions;

namespace HR_Employess_Repo
{
    public interface IEmpRepo : IRepository<Employee>
    {
        Task<ICollection<EmployeesLogin>> GetEmployeeAttendanceAsync();
        Task<ICollection<Employee>> GetEmployeePageAsync(Expression<Func<Employee, bool>> selector, int skip, int take);
        Task<ICollection<Employee>> GetManagerListAsync();
    }
}
