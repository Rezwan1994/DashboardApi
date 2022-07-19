namespace DashboardAPI.Model.BEL
{
    public class UserLogin
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? LogId { get; set; }
        public string? Status { get; set; }
        public string? AccessLevel { get; set; }
        public string? EmployeeCode { get; set; }
        public string? EmployeeName { get; set; }
        public string? GroupCode { get; set; }
        public string? Code { get; set; }
        public int RoleId { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public int EmployeeID { get; internal set; }
        public string? CompanyLogoUrl { get; internal set; }

        public int UserBaseReportFilter { get; set; }

        public string ReportDownLoadStatus { get; set; }

    }

    public class UserLoginModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
