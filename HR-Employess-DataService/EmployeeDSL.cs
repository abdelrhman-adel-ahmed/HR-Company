using HR_Employess_DataAccess.Entities;
using HR_Employess_Helper;
using HR_Employess_Repo;
using System.Linq.Expressions;

namespace HR_Employess_DataService
{
    public class EmployeeDSL
    {
        private readonly IEmpRepo _empRepo;
        public EmployeeDSL(IEmpRepo empRepo)
        {
            _empRepo = empRepo;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            await _empRepo.InsertAsync(employee);
        }

        public async Task<ICollection<EmployeesLogin>> GetEmployeeAttendanceAsync()
        {
            return await _empRepo.GetEmployeeAttendanceAsync();
        }

        public async Task<ICollection<Employee>> GetEmployeeListAsync()
        {
            return await _empRepo.GetAll();
        }

        public async Task<ICollection<Employee>> GetEmployePageAsync(SearchDTO searchDto)
        {
            Expression<Func<Employee, bool>> selector = _ => true;

            if (!string.IsNullOrEmpty(searchDto.EmployeeName))
            {
                selector = x => x.EmployeeName.Equals(searchDto.EmployeeName);
            }
            return await _empRepo.GetEmployeePageAsync(selector, searchDto.Skip, searchDto.Take);
        }

        public async Task<ICollection<Employee>> GetManagerListAsync()
        {
            return await _empRepo.GetManagerListAsync();
        }
    }
}