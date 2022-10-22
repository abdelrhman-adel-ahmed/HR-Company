namespace HR_Employess_Helper
{
    public class SearchDTO
    {
        public string? EmployeeName { get; set; }
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 10;
    }
}
