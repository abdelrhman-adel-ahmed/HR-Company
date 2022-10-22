using System;
using System.Collections.Generic;

namespace HR_Employess_DataAccess.Entities
{
    public partial class EmployeesLogin
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public TimeSpan? SignInTime { get; set; }
        public TimeSpan? SignOutTime { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? TotalHours { get; set; }

        public virtual Employee Employee { get; set; } = null!;
    }
}
