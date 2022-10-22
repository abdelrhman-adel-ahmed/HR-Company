using HR_Employess_DataAccess;
using HR_Employess_DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;

namespace HR_Employess_Repo
{
    public class EmpRepo : IEmpRepo
    {
        private readonly HR_CompanyContext _context;
        public EmpRepo(HR_CompanyContext context)
        {
            _context = context;
        }

        public Task Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<ICollection<EmployeesLogin>> GetEmployeeAttendanceAsync()
        {
            return await _context.EmployeesLogins.ToListAsync();
        }

        public async Task<ICollection<Employee>> GetEmployeePageAsync(Expression<Func<Employee, bool>> selector, int skip, int take)
        {
            return await _context.Employees.Where(selector).OrderBy(e => e.EmployeeName).OrderBy(x=>x.ManagerId).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<ICollection<Employee>> GetManagerListAsync()
        {
            //only select name and if
            return await _context.Employees.Where(e => e.IsManager == true).ToListAsync();
        }

        public async Task InsertAsync(Employee entity)
        {
            await _context.Employees.AddAsync(entity);
            await SaveChanges();
        }

        public Task Remove(Employee entity)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public Task Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
