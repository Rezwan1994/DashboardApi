using Oracle.ManagedDataAccess.Client;
using System.Data;


namespace DashboardAPI.Getway
{
    public class DBHelper : ReturnData
    {
        private static readonly DBConnection DBConnection = new DBConnection();
        private readonly ErrorLogger _errorLogger = new ErrorLogger();

        private const string DBType = "Oracle";
        private const string CompanyType = "PHARMAERP";
        public readonly string ConnString = DBConnection.SAConnStrReader(DBType, CompanyType);

        public bool CmdExecute(string qry, string activityType, string actionForm, string actionTable, long transactionId)
        {
            try
            {
                var isTrue = false;
                using (OracleConnection con = new OracleConnection(ConnString))
                {
                    using (OracleCommand cmd = new OracleCommand(qry, con))
                    {
                        con.Open();
                        int noOfRows = cmd.ExecuteNonQuery();
                        if (noOfRows > 0)
                        {
                          
                            isTrue = true;
                        }
                    }
                }
                return isTrue;
            }
            catch (Exception e)
            {

                ExceptionReturn = e.Message;
                throw;
            }
        }
     
        public bool CmdTransExecute(string qry)
        {
            try
            {
                bool isTrue = false;
                using (OracleConnection con = new OracleConnection(ConnString))
                {
                    OracleCommand cmd = new OracleCommand(qry, con);
                    con.Open();
                    int noOfRows = cmd.ExecuteNonQuery();
                    if (noOfRows > 0)
                    {
                        isTrue = true;
                    }
                }
                return isTrue;
            }
            catch (Exception e)
            {
                var lineNum = e.StackTrace.Substring(e.StackTrace.LastIndexOf(' '));
                _errorLogger.GetErrorMessage(e.Message, "DBHelper", lineNum);
                throw;
            }
        }

        public DataTable GetDataTable(string qry)
        {
            try
            {
                DataTable dt = new DataTable();
                using (OracleConnection objConn = new OracleConnection(ConnString))
                {
                    using (OracleCommand objCmd = new OracleCommand())
                    {
                        objCmd.CommandText = qry;
                        objCmd.Connection = objConn;
                        objConn.Open();
                        objCmd.ExecuteNonQuery();
                        using (OracleDataReader rdr = objCmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                dt.Load(rdr);
                            }
                        }
                    }
                }
                return dt;
            }
            catch (OracleException)
            {

                throw;
            }

        }
        public DataTable GetDataTableWithAuditTrial(string qry, string reportName)
        {
            try
            {
                DataTable dt = new DataTable();
                using (OracleConnection objConn = new OracleConnection(ConnString))
                {
                    using (OracleCommand objCmd = new OracleCommand())
                    {
                        objCmd.CommandText = qry;
                        objCmd.Connection = objConn;
                        objConn.Open();
                        objCmd.ExecuteNonQuery();
                        using (OracleDataReader rdr = objCmd.ExecuteReader())
                        {
                            if (rdr.HasRows)
                            {
                                dt.Load(rdr);
                            }
                    
                        }
                    }
                }
                return dt;
            }
            catch (OracleException)
            {

                throw;
            }

        }

        public string GetValue(string qry)
        {
            string value = "";
            using (OracleConnection odbcConnection = new OracleConnection(ConnString))
            {
                odbcConnection.Open();
                using (OracleCommand odbcCommand = new OracleCommand(qry, odbcConnection))
                {
                    OracleDataReader rdr = odbcCommand.ExecuteReader();
                    if (rdr.Read())
                    {
                        value = rdr[0].ToString();
                    }
                    rdr.Close();
                    odbcConnection.Close();
                    return value;
                }
            }
        }
        public DataRow GetDataRow(string qry)
        {
            DataRow row = null;
            using (OracleConnection odbcConnection = new OracleConnection(ConnString))
            {
                odbcConnection.Open();
                using (OracleCommand odbcCommand = new OracleCommand(qry, odbcConnection))
                {
                    OracleDataReader rdr = odbcCommand.ExecuteReader();
                    if (rdr.Read())
                    {
                        row[0] = rdr[0];
                    }
                    rdr.Close();
                    odbcConnection.Close();
                    return row;
                }
            }
        }
        public string GetEmpName(int empID)
        {

            string empName = "";
            string queryString = "select EMPLOYEE_NAME from EMPLOYEE_INFO where employee_id = " + empID + " ";
            using (OracleConnection oracleConnection = new OracleConnection(ConnString))
            {
                oracleConnection.Open();
                using (OracleCommand oracleCommand = new OracleCommand(queryString, oracleConnection))
                {
                    using (OracleDataReader rdr = oracleCommand.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            empName = rdr["EMPLOYEE_NAME"].ToString();
                        }
                    }
                }
            }

            return empName.ToString();
        }
        public string GetNo(string tableName, string columnName)
        {
            string noId = "";
            string queryString = "SELECT TO_CHAR(SYSDATE,'YY')||TO_CHAR(SYSDATE,'MM')||LPAD(NVL(MAX(NVL(TO_NUMBER(" + columnName + "),0)),0)+1,6,0) gNo FROM " + tableName + "";
            using (OracleConnection oracleConnection = new OracleConnection(ConnString))
            {
                oracleConnection.Open();
                using (OracleCommand oracleCommand = new OracleCommand(queryString, oracleConnection))
                {
                    using (OracleDataReader rdr = oracleCommand.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            noId = rdr["gNo"].ToString();
                        }
                    }
                }
            }
            return noId;
        }

    }
}
