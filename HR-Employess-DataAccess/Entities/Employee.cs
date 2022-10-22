using System;
using System.Collections.Generic;

namespace HR_Employess_DataAccess.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeesLogins = new HashSet<EmployeesLogin>();
            InverseManager = new HashSet<Employee>();
        }

        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeAddress { get; set; }
        public DateTime? EmployeeBirthDate { get; set; }
        public string? EmployeeEmailAddress { get; set; }
        public string? EmployeeMobile { get; set; }
        public int? ManagerId { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool? IsManager { get; set; }

        public virtual Employee? Manager { get; set; }
        public virtual ICollection<EmployeesLogin> EmployeesLogins { get; set; }
        public virtual ICollection<Employee> InverseManager { get; set; }
    }
}
