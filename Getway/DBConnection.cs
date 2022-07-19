namespace DashboardAPI.Getway
{
    public class DBConnection
    {
        string connectionString = "";
        public DBConnection()
        {
            //SAConnStrReader("Dashboard");
        }

        public string SAConnStrReader(string dbType, string companyType)
        {
            connectionString = "Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 172.24.16.173)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME=ssmdb1.squaregroup.com)(SERVER = DEDICATED)));User Id=SPA_SFBL_BI;Password=SPA";
            return connectionString;
        }


    }
}
