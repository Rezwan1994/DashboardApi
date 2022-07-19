using DashboardAPI.Getway;
using DashboardAPI.Model.BEL;
using DashboardAPI.Universal.BEL;
using System.Data;

namespace DashboardAPI.Universal.DAL
{
    public class LoginRegistrationDAO
    {
        readonly DBHelper _dbHelper = new DBHelper();
        private readonly ErrorLogger _errorLogger = new ErrorLogger();
        public List<LoginRegistrationBEL> CheckUserCredential()
        {
            try
            {

                string uQry = "SELECT USER_ID, USER_NAME, PASSWORD,EMPLOYEE_ID FROM SC_USER_LOGIN";
                DataTable dt = _dbHelper.GetDataTable(uQry);
                var item = (from DataRow row in dt.Rows
                            select new LoginRegistrationBEL
                            {
                                USER_ID = row["USER_ID"].ToString(),
                                USER_NAME = row["USER_NAME"].ToString(),
                                PASSWORD = row["PASSWORD"].ToString(),
                                EMPLOYEE_ID = Convert.ToInt32(row["EMPLOYEE_ID"])
                                //SupervisorID = row["SupervisorID"].ToString(),
                                //SupervisorName = row["SupervisorName"].ToString(),
                                //Designation = row["Designation"].ToString(),
                                //EmploymentDate = row["EmploymentDate"].ToString(),
                                //IsActive = Convert.ToBoolean(row["IsActive"].ToString())

                            }).ToList();
                return item;
            }
            catch (Exception e)
            {
                var lineNum = e.StackTrace.Substring(e.StackTrace.LastIndexOf(' '));
                _errorLogger.GetErrorMessage(e.Message, "Home", lineNum);
                throw;
            }

        }

        public bool TryLogin(string UserName, string Password)
        {
            try
            {
                LoginRegistrationDAO loginRegistrationDAO = new LoginRegistrationDAO();
                if (UserName.Length <= 0 || Password.Length <= 0) return false;
                var v = loginRegistrationDAO.CheckUserCredential();
                var verifiedUserCredential = loginRegistrationDAO.CheckUserCredential().FirstOrDefault(m => m.USER_NAME.Equals(UserName) && m.PASSWORD.Equals(Password));

                if (verifiedUserCredential == null) return false;
                var userQry =
                   " SELECT" +
                   " A.USER_ID," +
                   " A.USER_NAME," +
                   " A.ACCESS_LOCATION," +
                   " C.EMPLOYEE_ID," +
                   " C.EMPLOYEE_CODE," +
                   " B.ROLE_ID," +
                   " C.EMPLOYEE_NAME," +
                   " D.COMP_NAME," +
                   " D.COMP_ADDR1," +
                   " D.COMP_LOGO_URL," +
                   " (SELECT COUNT(*) FROM USER_PRODUCT_DTL WHERE USER_ID=A.USER_ID) USER_BASE_REPORT_FILTER," +
                   " A.DOWNLOAD_STATUS" +
                   " FROM SC_USER_LOGIN A" +
                   " INNER JOIN SC_ROLE_USER_CONF B ON A.USER_ID=B.USER_ID" +
                   " INNER JOIN SC_EMPLOYEE_INFO C ON A.EMPLOYEE_ID=C.EMPLOYEE_ID" +
                   " INNER JOIN SC_COMPANY D " +
                   " ON C.COMPANY_ID=D.ID" +
                   " WHERE UPPER(A.USER_NAME)='" + verifiedUserCredential.USER_NAME.ToUpper() + "' " +
                   " AND A.PASSWORD='" + verifiedUserCredential.PASSWORD + "' " +
                   " AND A.STATUS='Active' ";
                var dt = _dbHelper.GetDataTable(userQry);

                var item = (from DataRow row in dt.Rows
                            select new UserLogin
                            {
                                UserId = Convert.ToInt32(row["USER_ID"]),
                                Username = (row["USER_NAME"]).ToString(),
                                EmployeeCode = row["EMPLOYEE_CODE"].ToString()
                            }).ToList();
                if (item.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
