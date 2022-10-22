using HR_Employess_DataAccess.Entities;
using HR_Employess_DataService;
using HR_Employess_Helper;
using Microsoft.AspNetCore.Mvc;

namespace HR_Employees_Api.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeDSL _employeeDSL;
        public EmployeeController(EmployeeDSL employeeDSL)
        {
            _employeeDSL = employeeDSL;
        }
        
        [HttpGet("GetEmployeeList")]
        public async Task<ICollection<Employee>> GetEmployeeListAsync()
        {
            return await _employeeDSL.GetEmployeeListAsync();
        }

        [HttpGet("GetEmployeePage")]
        public async Task<ICollection<Employee>> GetEmployeePageAsync([FromQuery] SearchDTO searchDto)
        {
            return await _employeeDSL.GetEmployePageAsync(searchDto);
        }

        [HttpGet("GetManagerList")]
        public async Task<ICollection<Employee>> GetManagerListAsync()
        {
            return await _employeeDSL.GetManagerListAsync();
        }

        [HttpPost("AddEmployee")]
        public async Task AddEmployeeAsync(Employee employee)
        {
            await _employeeDSL.AddEmployeeAsync(employee);
        }

        [HttpGet("GetEmployeeAttendance")]
        public async Task<ICollection<EmployeesLogin>> GetEmployeeAttendanceAsync()
        {
            return await _employeeDSL.GetEmployeeAttendanceAsync();
        }

    }
}
