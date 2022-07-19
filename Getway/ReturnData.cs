namespace DashboardAPI.Getway
{
    public class ReturnData
    {
        public string ProcessSlno { get; set; }
        public long MstID { get; set; }
        public long DtlID { get; set; }

        public long ProductTypeID { get; set; }
        public long MaxID { get; set; }
        public string MaxCode { get; set; }
        public string IuMode { get; set; }
        public string MSG { get; set; }
        public string ExceptionReturn { get; set; }
        public object ListReturn { get; set; }
        public string ProcessRunMessage = "Process Successfully Run";
        public string InsertMessage = "Saved Successfully";
        public string UpdateMessage = "Updated Successfully";
        public string DeleteMessage = "Deleted Successfully";
        public string RefreshMessage = "Materialized View Refresh Complete";
        public string StatusChangeMessage = "Status Successfully Changed";
        public static string GetHostName
        {
            get
            {
                string strComputerName = Environment.MachineName.ToString();
                return strComputerName;
            }
        }




     
    }
}
