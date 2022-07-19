using DashboardAPI.Getway;
using DashboardAPI.Model.BEL;

using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Data;

namespace DashboardAPI.Model.DAL
{
    public class masterDashboardDal : ReturnData
    {
        private readonly DBHelper _dbHelper = new DBHelper();
        private readonly ErrorLogger _errorLogger = new ErrorLogger();
        private static readonly DBConnection DBConnection = new DBConnection();
        public readonly string ConnString = DBConnection.SAConnStrReader("Oracle", "PHARMAERP");


        public TodayDashboardCartModel GetTodayCartValue(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format(@"select fnc_today_order_val({0}) OrderValue,
            fnc_today_sales_val({0}) SalesValue, fnc_today_sched_retailer({0}) ScheduledRetailer,
            fnc_today_ordering_retailer({0}) OrderingRetailer, fnc_total_retailer({0}) TotalRetailer from dual", (object)UserId));
        
            TodayDashboardCartModel todayModel = new TodayDashboardCartModel();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, TodayDashboardCartModel>((Func<DataRow, TodayDashboardCartModel>)(row => new TodayDashboardCartModel()
            {
                OrderValue = row["ORDERVALUE"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ORDERVALUE"].ToString()), 2) : 0.0,
                SalesValue = row["SalesValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["SalesValue"].ToString()), 2) : 0.0,
                OrderingRetailer = row["OrderingRetailer"].ToString() != "" ? Math.Round(Convert.ToDouble(row["OrderingRetailer"].ToString()), 2) : 0.0,
                ScheduledRetailer = row["ScheduledRetailer"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ScheduledRetailer"].ToString()), 2) : 0.0,
                TotalRetailer = row["TotalRetailer"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TotalRetailer"].ToString()), 2) : 0.0,
                Date = DateTime.Now.Date.ToString("dd-MM-yyyy")
            })).ToList<TodayDashboardCartModel>().FirstOrDefault<TodayDashboardCartModel>();
        }
        public MonthlyDashboardCartModel GetMonthlyCartValue(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format(@"select FNC_MTD_TARGET_VAL(1) TargetValue,
            FNC_MTD_IMS_VAL(1) SalesValue,FNC_MTD_RETURN_VAL(1) ReturnValue,
            FNC_MTD_ACH_VAL(1) AchValue,FNC_MTD_GROWTH(1) GrowthValue from dual", (object)UserId));
            
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, MonthlyDashboardCartModel>((Func<DataRow, MonthlyDashboardCartModel>)(row => new MonthlyDashboardCartModel()
            {
                TargetValue = row["TargetValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TargetValue"].ToString()), 2) : 0.0,
                SalesValue = row["SalesValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["SalesValue"].ToString()), 2) : 0.0,
                 AchValue = row["AchValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["AchValue"].ToString()), 2) : 0.0,
                GrowthValue = row["GrowthValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["GrowthValue"].ToString()), 2) : 0.0,
                ReturnValue = row["ReturnValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ReturnValue"].ToString()), 2) : 0.0,
                Month = DateTime.Now.Date.ToString("MMM")
            })).ToList<MonthlyDashboardCartModel>().FirstOrDefault<MonthlyDashboardCartModel>();

        }
        public MonthlyDashboardCartModel GetYearlyCartValue(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format(@"select FNC_YTD_TARGET_VAL(1) TargetValue,
            FNC_YTD_IMS_VAL(1) SalesValue,FNC_YTD_RETURN_VAL(1) ReturnValue,
            FNC_YTD_ACH_VAL(1) AchValue,FNC_YTD_GROWTH(1) GrowthValue from dual", (object)UserId));

            return dataTable.Rows.Cast<DataRow>().Select<DataRow, MonthlyDashboardCartModel>((Func<DataRow, MonthlyDashboardCartModel>)(row => new MonthlyDashboardCartModel()
            {
                TargetValue = row["TargetValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TargetValue"].ToString()), 2) : 0.0,
                SalesValue = row["SalesValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["SalesValue"].ToString()), 2) : 0.0,
                AchValue = row["AchValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["AchValue"].ToString()), 2) : 0.0,
                GrowthValue = row["GrowthValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["GrowthValue"].ToString()), 2) : 0.0,
                ReturnValue = row["ReturnValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ReturnValue"].ToString()), 2) : 0.0,
                Month = DateTime.Now.Date.ToString("MMM")
            })).ToList<MonthlyDashboardCartModel>().FirstOrDefault<MonthlyDashboardCartModel>();

        }

        public OrderModel GetOrderCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT fnc_today_order_val({0}) OrderValue FROM DUAL", (object)UserId));
            OrderModel orderModel = new OrderModel();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, OrderModel>((Func<DataRow, OrderModel>)(row => new OrderModel()
            {
                OrderValue = row["ORDERVALUE"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ORDERVALUE"].ToString()) / 10000000.0, 2) : 0.0
            })).ToList<OrderModel>().FirstOrDefault<OrderModel>();
        }
        public MonthlyTargetModel GetMonthlyTargetCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_MTD_TARGET_VAL({0}) TargetValue FROM DUAL", (object)UserId));
            MonthlyTargetModel monthlyTargetModel = new MonthlyTargetModel();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, MonthlyTargetModel>((Func<DataRow, MonthlyTargetModel>)(row => new MonthlyTargetModel()
            {
                TargetValue = row["TargetValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TargetValue"].ToString()) / 10000000.0, 2) : 0.0
            })).ToList<MonthlyTargetModel>().FirstOrDefault<MonthlyTargetModel>();
        }

        public YearlyTargetModel GetYearlyTargetCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_YTD_TARGET_VAL({0}) TargetValue FROM DUAL", (object)UserId));
            YearlyTargetModel yearlyTargetModel = new YearlyTargetModel();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, YearlyTargetModel>((Func<DataRow, YearlyTargetModel>)(row => new YearlyTargetModel()
            {
                TargetValue = row["TargetValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TargetValue"].ToString()) / 10000000.0, 2) : 0.0
            })).ToList<YearlyTargetModel>().FirstOrDefault<YearlyTargetModel>();
        }

        public SalesModel GetSalesCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT fnc_today_sales_val({0}) SalesValue FROM DUAL", (object)UserId));
            SalesModel salesModel = new SalesModel();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, SalesModel>((Func<DataRow, SalesModel>)(row => new SalesModel()
            {
                SalesValue = row["SalesValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["SalesValue"].ToString()) / 10000000.0, 2) : 0.0
            })).ToList<SalesModel>().FirstOrDefault<SalesModel>();
        }

        public MonthlySalesModel GetMonthlySalesCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_MTD_IMS_VAL({0}) SalesValue FROM DUAL", (object)UserId));
            MonthlySalesModel monthlySalesModel = new MonthlySalesModel();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, MonthlySalesModel>((Func<DataRow, MonthlySalesModel>)(row => new MonthlySalesModel()
            {
                SalesValue = row["SalesValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["SalesValue"].ToString()) / 10000000.0, 2) : 0.0
            })).ToList<MonthlySalesModel>().FirstOrDefault<MonthlySalesModel>();
        }

        public YearlySalesModel GetYearlySalesCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_YTD_IMS_VAL({0}) SalesValue FROM DUAL", (object)UserId));
            YearlySalesModel yearlySalesModel = new YearlySalesModel();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, YearlySalesModel>((Func<DataRow, YearlySalesModel>)(row => new YearlySalesModel()
            {
                SalesValue = row["SalesValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["SalesValue"].ToString()) / 10000000.0, 2) : 0.0
            })).ToList<YearlySalesModel>().FirstOrDefault<YearlySalesModel>();
        }

        public RetailerCount GetScheduledRetailerCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT fnc_today_sched_retailer({0}) ScheduledRetailer FROM DUAL", (object)UserId));
            RetailerCount rtailerModel = new RetailerCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, RetailerCount>((Func<DataRow, RetailerCount>)(row => new RetailerCount()
            {
                ScheduledRetailer = row["ScheduledRetailer"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ScheduledRetailer"].ToString()), 2) : 0.0
            })).ToList<RetailerCount>().FirstOrDefault<RetailerCount>();
        }
        public RetailerCount GetTotalRetailerCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT fnc_total_retailer({0}) TotalRetailer FROM DUAL", (object)UserId));
            RetailerCount rtailerModel = new RetailerCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, RetailerCount>((Func<DataRow, RetailerCount>)(row => new RetailerCount()
            {
                TotalRetailer = row["TotalRetailer"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TotalRetailer"].ToString()), 2) : 0.0
            })).ToList<RetailerCount>().FirstOrDefault<RetailerCount>();
        }
        public RetailerCount GetOrderingRetailerCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT fnc_today_ordering_retailer({0}) OrderingRetailer FROM DUAL", (object)UserId));
            RetailerCount rtailerModel = new RetailerCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, RetailerCount>((Func<DataRow, RetailerCount>)(row => new RetailerCount()
            {
                OrderingRetailer = row["OrderingRetailer"].ToString() != "" ? Math.Round(Convert.ToDouble(row["OrderingRetailer"].ToString()), 2) : 0.0
            })).ToList<RetailerCount>().FirstOrDefault<RetailerCount>();
        }

        public ReturnACHGrowthCount GetMTDReturnCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_MTD_RETURN_VAL({0}) ReturnedCount FROM DUAL", (object)UserId));
            ReturnACHGrowthCount countModel = new ReturnACHGrowthCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, ReturnACHGrowthCount>((Func<DataRow, ReturnACHGrowthCount>)(row => new ReturnACHGrowthCount()
            {
                ReturnedCount = row["ReturnedCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ReturnedCount"].ToString()) / 10000000, 2) : 0.0
            })).ToList<ReturnACHGrowthCount>().FirstOrDefault<ReturnACHGrowthCount>();
        }
        public ReturnACHGrowthCount GetMTDACHCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_MTD_ACH_VAL({0}) ACHCount FROM DUAL", (object)UserId));
            ReturnACHGrowthCount countModel = new ReturnACHGrowthCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, ReturnACHGrowthCount>((Func<DataRow, ReturnACHGrowthCount>)(row => new ReturnACHGrowthCount()
            {
                ACHCount = row["ACHCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ACHCount"].ToString()), 2) : 0.0
            })).ToList<ReturnACHGrowthCount>().FirstOrDefault<ReturnACHGrowthCount>();
        }
        public ReturnACHGrowthCount GetMTDGrowthCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_MTD_GROWTH({0}) GrowthCount FROM DUAL", (object)UserId));
            ReturnACHGrowthCount countModel = new ReturnACHGrowthCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, ReturnACHGrowthCount>((Func<DataRow, ReturnACHGrowthCount>)(row => new ReturnACHGrowthCount()
            {
                GrowthCount = row["GrowthCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["GrowthCount"].ToString()), 2) : 0.0
            })).ToList<ReturnACHGrowthCount>().FirstOrDefault<ReturnACHGrowthCount>();
        }
        public ReturnACHGrowthCount GetYTDGrowthCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_YTD_GROWTH({0}) GrowthCount FROM DUAL", (object)UserId));
            ReturnACHGrowthCount countModel = new ReturnACHGrowthCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, ReturnACHGrowthCount>((Func<DataRow, ReturnACHGrowthCount>)(row => new ReturnACHGrowthCount()
            {
                GrowthCount = row["GrowthCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["GrowthCount"].ToString()), 2) : 0.0
            })).ToList<ReturnACHGrowthCount>().FirstOrDefault<ReturnACHGrowthCount>();
        }
        public ReturnACHGrowthCount GetYTDReturnCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_YTD_RETURN_VAL({0}) ReturnedCount FROM DUAL", (object)UserId));
            ReturnACHGrowthCount countModel = new ReturnACHGrowthCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, ReturnACHGrowthCount>((Func<DataRow, ReturnACHGrowthCount>)(row => new ReturnACHGrowthCount()
            {
                ReturnedCount = row["ReturnedCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ReturnedCount"].ToString()) / 10000000, 2) : 0.0
            })).ToList<ReturnACHGrowthCount>().FirstOrDefault<ReturnACHGrowthCount>();
        }



        public PC_LPCCount GetTodayPCCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_TODAY_PC({0}) TodayPCCount,FNC_MTD_PC({0}) MonthlyPCCount" +
                ",FNC_YTD_PC({0}) YearlyPCCount,FNC_TODAY_LPC({0}) TodayLPCCount,FNC_MTD_LPC({0}) MonthlyLPCCount," +
                " FNC_YTD_LPC({0}) YearlyLPCCount" +
                " FROM DUAL", (object)UserId));
            PC_LPCCount countModel = new PC_LPCCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, PC_LPCCount>((Func<DataRow, PC_LPCCount>)(row => new PC_LPCCount()
            {
                TodayPCCount = row["TodayPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TodayPCCount"].ToString()), 2) : 0.0,
                MonthlyPCCount = row["MonthlyPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["MonthlyPCCount"].ToString()), 2) : 0.0,
                YearlyPCCount = row["YearlyPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["YearlyPCCount"].ToString()), 2) : 0.0,
                TodayLPCCount = row["TodayLPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TodayLPCCount"].ToString()), 2) : 0.0,
                MonthlyLPCCount = row["MonthlyLPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["MonthlyLPCCount"].ToString()), 2) : 0.0,
                YearlyLPCCount = row["YearlyLPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["YearlyLPCCount"].ToString()), 2) : 0.0,
            })).ToList<PC_LPCCount>().FirstOrDefault<PC_LPCCount>();
        }
        public PC_LPCCount GetMonthlyPCCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_MTD_PC({0}) MonthlyPCCount FROM DUAL", (object)UserId));
            PC_LPCCount countModel = new PC_LPCCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, PC_LPCCount>((Func<DataRow, PC_LPCCount>)(row => new PC_LPCCount()
            {
                MonthlyPCCount = row["MonthlyPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["MonthlyPCCount"].ToString()), 2) : 0.0
            })).ToList<PC_LPCCount>().FirstOrDefault<PC_LPCCount>();
        }
        public PC_LPCCount GetYearlyPCCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_YTD_PC({0}) YearlyPCCount FROM DUAL", (object)UserId));
            PC_LPCCount countModel = new PC_LPCCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, PC_LPCCount>((Func<DataRow, PC_LPCCount>)(row => new PC_LPCCount()
            {
                YearlyPCCount = row["YearlyPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["YearlyPCCount"].ToString()), 2) : 0.0
            })).ToList<PC_LPCCount>().FirstOrDefault<PC_LPCCount>();
        }

        public PC_LPCCount GetYearlyLPCCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_YTD_LPC({0}) YearlyLPCCount FROM DUAL", (object)UserId));
            PC_LPCCount countModel = new PC_LPCCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, PC_LPCCount>((Func<DataRow, PC_LPCCount>)(row => new PC_LPCCount()
            {
                YearlyPCCount = row["YearlyLPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["YearlyLPCCount"].ToString()), 2) : 0.0
            })).ToList<PC_LPCCount>().FirstOrDefault<PC_LPCCount>();
        }
        public PC_LPCCount GetMonthlyLPCCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_MTD_LPC({0}) MonthlyLPCCount FROM DUAL", (object)UserId));
            PC_LPCCount countModel = new PC_LPCCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, PC_LPCCount>((Func<DataRow, PC_LPCCount>)(row => new PC_LPCCount()
            {
                MonthlyPCCount = row["MonthlyLPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["MonthlyLPCCount"].ToString()), 2) : 0.0
            })).ToList<PC_LPCCount>().FirstOrDefault<PC_LPCCount>();
        }
        public PC_LPCCount GetTodayLPCCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_TODAY_LPC({0}) TodayLPCCount FROM DUAL", (object)UserId));
            PC_LPCCount countModel = new PC_LPCCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, PC_LPCCount>((Func<DataRow, PC_LPCCount>)(row => new PC_LPCCount()
            {
                TodayPCCount = row["TodayLPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TodayLPCCount"].ToString()), 2) : 0.0
            })).ToList<PC_LPCCount>().FirstOrDefault<PC_LPCCount>();
        }
        public ReturnACHGrowthCount GetYTDACHCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_YTD_ACH_VAL({0}) ACHCount FROM DUAL", (object)UserId));
            ReturnACHGrowthCount countModel = new ReturnACHGrowthCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, ReturnACHGrowthCount>((Func<DataRow, ReturnACHGrowthCount>)(row => new ReturnACHGrowthCount()
            {
                ACHCount = row["ACHCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ACHCount"].ToString()), 2) : 0.0
            })).ToList<ReturnACHGrowthCount>().FirstOrDefault<ReturnACHGrowthCount>();
        }

        public DayWiseModel GetIMSReturnPct(int UserId)
        {
            DayWiseModel dayWiseModel = new DayWiseModel();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(this.ConnString))
                {
                    using (OracleCommand oracleCommand = new OracleCommand())
                    {
                        string anonymous_block = "begin " +
                            "  :refcursor1 := FN_DAY_WISE_RETURN_PCT(" + UserId + ") ;" +
                            "end;";
                        //fill in your function and variables via the above example
                        OracleCommand sqlCom = oracleConnection.CreateCommand();
                        sqlCom.CommandText = anonymous_block;

                        // Bind 
                        sqlCom.Parameters.Add("refcursor1", OracleDbType.RefCursor);
                        sqlCom.Parameters[0].Direction = ParameterDirection.ReturnValue;


                        try
                        {
                            // Execute command; Have the parameters populated
                            oracleConnection.Open();
                            sqlCom.ExecuteNonQuery();


                            DataTable dataTable = new DataTable();


                            OracleDataAdapter da = new OracleDataAdapter(sqlCom);

                            // Populate a DataSet with refcursor1.
                            DataSet ds = new DataSet();
                            da.Fill(ds, "refcursor1", (OracleRefCursor)(sqlCom.Parameters["refcursor1"].Value));
                            dataTable = ds.Tables["refcursor1"];
                            // Print out the field count the REF Cursor



                            dayWiseModel= dataTable.Rows.Cast<DataRow>().Select<DataRow, DayWiseModel>((Func<DataRow, DayWiseModel>)(row => new DayWiseModel()
                            {
                                YYYYMMMM = Convert.ToInt32(row["YYYYMM"].ToString()),
                                DAY_01 = Math.Round(Convert.ToDouble(row["DAY_01"].ToString()), 2),
                                DAY_02 = Math.Round(Convert.ToDouble(row["DAY_02"].ToString()), 2),
                                DAY_03 = Math.Round(Convert.ToDouble(row["DAY_03"].ToString()), 2),
                                DAY_04 = Math.Round(Convert.ToDouble(row["DAY_04"].ToString()), 2),
                                DAY_05 = Math.Round(Convert.ToDouble(row["DAY_05"].ToString()), 2),
                                DAY_06 = Math.Round(Convert.ToDouble(row["DAY_06"].ToString()), 2),
                                DAY_07 = Math.Round(Convert.ToDouble(row["DAY_07"].ToString()), 2),
                                DAY_08 = Math.Round(Convert.ToDouble(row["DAY_08"].ToString()), 2),
                                DAY_09 = Math.Round(Convert.ToDouble(row["DAY_09"].ToString()), 2),
                                DAY_10 = Math.Round(Convert.ToDouble(row["DAY_10"].ToString()), 2),
                                DAY_11 = Math.Round(Convert.ToDouble(row["DAY_11"].ToString()), 2),
                                DAY_12 = Math.Round(Convert.ToDouble(row["DAY_12"].ToString()), 2),
                                DAY_13 = Math.Round(Convert.ToDouble(row["DAY_13"].ToString()), 2),
                                DAY_14 = Math.Round(Convert.ToDouble(row["DAY_14"].ToString()), 2),
                                DAY_15 = Math.Round(Convert.ToDouble(row["DAY_15"].ToString()), 2),
                                DAY_16 = Math.Round(Convert.ToDouble(row["DAY_16"].ToString()), 2),
                                DAY_17 = Math.Round(Convert.ToDouble(row["DAY_17"].ToString()), 2),
                                DAY_18 = Math.Round(Convert.ToDouble(row["DAY_18"].ToString()), 2),
                                DAY_19 = Math.Round(Convert.ToDouble(row["DAY_19"].ToString()), 2),
                                DAY_20 = Math.Round(Convert.ToDouble(row["DAY_20"].ToString()), 2),
                                DAY_21 = Math.Round(Convert.ToDouble(row["DAY_21"].ToString()), 2),
                                DAY_22 = Math.Round(Convert.ToDouble(row["DAY_22"].ToString()), 2),
                                DAY_23 = Math.Round(Convert.ToDouble(row["DAY_23"].ToString()), 2),
                                DAY_24 = Math.Round(Convert.ToDouble(row["DAY_24"].ToString()), 2),
                                DAY_25 = Math.Round(Convert.ToDouble(row["DAY_25"].ToString()), 2),
                                DAY_26 = Math.Round(Convert.ToDouble(row["DAY_26"].ToString()), 2),
                                DAY_27 = Math.Round(Convert.ToDouble(row["DAY_27"].ToString()), 2),
                                DAY_28 = Math.Round(Convert.ToDouble(row["DAY_28"].ToString()), 2),
                                DAY_29 = Math.Round(Convert.ToDouble(row["DAY_29"].ToString()), 2),
                                DAY_30 = Math.Round(Convert.ToDouble(row["DAY_30"].ToString()), 2),
                                DAY_31 = Math.Round(Convert.ToDouble(row["DAY_31"].ToString()), 2)
                            })).ToList<DayWiseModel>().FirstOrDefault();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: {0}", e.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
                return new DayWiseModel();
            }
            return dayWiseModel;
        }
        public DayWiseModel GetPCTrend(int UserId, string Year)
        {
            DayWiseModel dayWiseModel = new DayWiseModel();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(this.ConnString))
                {
                    using (OracleCommand oracleCommand = new OracleCommand())
                    {
                        string anonymous_block = String.Format(@"begin   :refcursor1 := FN_DAY_WISE_PC({0},'{1}'); 
                          end;", UserId, Year);
                        //fill in your function and variables via the above example
                        OracleCommand sqlCom = oracleConnection.CreateCommand();
                        sqlCom.CommandText = anonymous_block;

                        // Bind 
                        sqlCom.Parameters.Add("refcursor1", OracleDbType.RefCursor);
                        sqlCom.Parameters[0].Direction = ParameterDirection.ReturnValue;

                        try
                        {
                            // Execute command; Have the parameters populated
                            oracleConnection.Open();
                            sqlCom.ExecuteNonQuery();


                            DataTable dataTable = new DataTable();


                            OracleDataAdapter da = new OracleDataAdapter(sqlCom);

                            // Populate a DataSet with refcursor1.
                            DataSet ds = new DataSet();
                            da.Fill(ds, "refcursor1", (OracleRefCursor)(sqlCom.Parameters["refcursor1"].Value));
                            dataTable = ds.Tables["refcursor1"];
                            // Print out the field count the REF Cursor



                            dayWiseModel = dataTable.Rows.Cast<DataRow>().Select<DataRow, DayWiseModel>((Func<DataRow, DayWiseModel>)(row => new DayWiseModel()
                            {
                                YYYYMMMM = Convert.ToInt32(row["YYYYMM"].ToString()),
                                DAY_01 = Math.Round(Convert.ToDouble(row["DAY_01"].ToString()), 2),
                                DAY_02 = Math.Round(Convert.ToDouble(row["DAY_02"].ToString()), 2),
                                DAY_03 = Math.Round(Convert.ToDouble(row["DAY_03"].ToString()), 2),
                                DAY_04 = Math.Round(Convert.ToDouble(row["DAY_04"].ToString()), 2),
                                DAY_05 = Math.Round(Convert.ToDouble(row["DAY_05"].ToString()), 2),
                                DAY_06 = Math.Round(Convert.ToDouble(row["DAY_06"].ToString()), 2),
                                DAY_07 = Math.Round(Convert.ToDouble(row["DAY_07"].ToString()), 2),
                                DAY_08 = Math.Round(Convert.ToDouble(row["DAY_08"].ToString()), 2),
                                DAY_09 = Math.Round(Convert.ToDouble(row["DAY_09"].ToString()), 2),
                                DAY_10 = Math.Round(Convert.ToDouble(row["DAY_10"].ToString()), 2),
                                DAY_11 = Math.Round(Convert.ToDouble(row["DAY_11"].ToString()), 2),
                                DAY_12 = Math.Round(Convert.ToDouble(row["DAY_12"].ToString()), 2),
                                DAY_13 = Math.Round(Convert.ToDouble(row["DAY_13"].ToString()), 2),
                                DAY_14 = Math.Round(Convert.ToDouble(row["DAY_14"].ToString()), 2),
                                DAY_15 = Math.Round(Convert.ToDouble(row["DAY_15"].ToString()), 2),
                                DAY_16 = Math.Round(Convert.ToDouble(row["DAY_16"].ToString()), 2),
                                DAY_17 = Math.Round(Convert.ToDouble(row["DAY_17"].ToString()), 2),
                                DAY_18 = Math.Round(Convert.ToDouble(row["DAY_18"].ToString()), 2),
                                DAY_19 = Math.Round(Convert.ToDouble(row["DAY_19"].ToString()), 2),
                                DAY_20 = Math.Round(Convert.ToDouble(row["DAY_20"].ToString()), 2),
                                DAY_21 = Math.Round(Convert.ToDouble(row["DAY_21"].ToString()), 2),
                                DAY_22 = Math.Round(Convert.ToDouble(row["DAY_22"].ToString()), 2),
                                DAY_23 = Math.Round(Convert.ToDouble(row["DAY_23"].ToString()), 2),
                                DAY_24 = Math.Round(Convert.ToDouble(row["DAY_24"].ToString()), 2),
                                DAY_25 = Math.Round(Convert.ToDouble(row["DAY_25"].ToString()), 2),
                                DAY_26 = Math.Round(Convert.ToDouble(row["DAY_26"].ToString()), 2),
                                DAY_27 = Math.Round(Convert.ToDouble(row["DAY_27"].ToString()), 2),
                                DAY_28 = Math.Round(Convert.ToDouble(row["DAY_28"].ToString()), 2),
                                DAY_29 = Math.Round(Convert.ToDouble(row["DAY_29"].ToString()), 2),
                                DAY_30 = Math.Round(Convert.ToDouble(row["DAY_30"].ToString()), 2),
                                DAY_31 = Math.Round(Convert.ToDouble(row["DAY_31"].ToString()), 2)
                            })).ToList<DayWiseModel>().FirstOrDefault();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: {0}", e.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
                return new DayWiseModel();
            }
            return dayWiseModel;
        }

        public List<DayWiseModel> GetPhysicalAndTransitStockList(
  int UserId,
  string Year)
        {
            List<DayWiseModel> dayWiseModelList = new List<DayWiseModel>();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(this.ConnString))
                {
                    using (OracleCommand oracleCommand = new OracleCommand())
                    {
                        string anonymous_block = String.Format(@"begin   :refcursor1 := FN_DATE_WISE_STOCK_VALUE({0},'{1}'); 
                          end;", UserId, Year);
                        //fill in your function and variables via the above example
                        OracleCommand sqlCom = oracleConnection.CreateCommand();
                        sqlCom.CommandText = anonymous_block;

                        // Bind 
                        sqlCom.Parameters.Add("refcursor1", OracleDbType.RefCursor);
                        sqlCom.Parameters[0].Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            // Execute command; Have the parameters populated
                            oracleConnection.Open();
                            sqlCom.ExecuteNonQuery();


                            DataTable dataTable = new DataTable();


                            OracleDataAdapter da = new OracleDataAdapter(sqlCom);

                            // Populate a DataSet with refcursor1.
                            DataSet ds = new DataSet();
                            da.Fill(ds, "refcursor1", (OracleRefCursor)(sqlCom.Parameters["refcursor1"].Value));
                            dataTable = ds.Tables["refcursor1"];
                            // Print out the field count the REF Cursor



                            dayWiseModelList = dataTable.Rows.Cast<DataRow>().Select<DataRow, DayWiseModel>((Func<DataRow, DayWiseModel>)(row => new DayWiseModel()
                            {
                                YYYYMMMM = Convert.ToInt32(row["YYYYMM"].ToString()),
                                DAY_01 = Math.Round(Convert.ToDouble(row["DAY_01"].ToString()), 2),
                                DAY_02 = Math.Round(Convert.ToDouble(row["DAY_02"].ToString()), 2),
                                DAY_03 = Math.Round(Convert.ToDouble(row["DAY_03"].ToString()), 2),
                                DAY_04 = Math.Round(Convert.ToDouble(row["DAY_04"].ToString()), 2),
                                DAY_05 = Math.Round(Convert.ToDouble(row["DAY_05"].ToString()), 2),
                                DAY_06 = Math.Round(Convert.ToDouble(row["DAY_06"].ToString()), 2),
                                DAY_07 = Math.Round(Convert.ToDouble(row["DAY_07"].ToString()), 2),
                                DAY_08 = Math.Round(Convert.ToDouble(row["DAY_08"].ToString()), 2),
                                DAY_09 = Math.Round(Convert.ToDouble(row["DAY_09"].ToString()), 2),
                                DAY_10 = Math.Round(Convert.ToDouble(row["DAY_10"].ToString()), 2),
                                DAY_11 = Math.Round(Convert.ToDouble(row["DAY_11"].ToString()), 2),
                                DAY_12 = Math.Round(Convert.ToDouble(row["DAY_12"].ToString()), 2),
                                DAY_13 = Math.Round(Convert.ToDouble(row["DAY_13"].ToString()), 2),
                                DAY_14 = Math.Round(Convert.ToDouble(row["DAY_14"].ToString()), 2),
                                DAY_15 = Math.Round(Convert.ToDouble(row["DAY_15"].ToString()), 2),
                                DAY_16 = Math.Round(Convert.ToDouble(row["DAY_16"].ToString()), 2),
                                DAY_17 = Math.Round(Convert.ToDouble(row["DAY_17"].ToString()), 2),
                                DAY_18 = Math.Round(Convert.ToDouble(row["DAY_18"].ToString()), 2),
                                DAY_19 = Math.Round(Convert.ToDouble(row["DAY_19"].ToString()), 2),
                                DAY_20 = Math.Round(Convert.ToDouble(row["DAY_20"].ToString()), 2),
                                DAY_21 = Math.Round(Convert.ToDouble(row["DAY_21"].ToString()), 2),
                                DAY_22 = Math.Round(Convert.ToDouble(row["DAY_22"].ToString()), 2),
                                DAY_23 = Math.Round(Convert.ToDouble(row["DAY_23"].ToString()), 2),
                                DAY_24 = Math.Round(Convert.ToDouble(row["DAY_24"].ToString()), 2),
                                DAY_25 = Math.Round(Convert.ToDouble(row["DAY_25"].ToString()), 2),
                                DAY_26 = Math.Round(Convert.ToDouble(row["DAY_26"].ToString()), 2),
                                DAY_27 = Math.Round(Convert.ToDouble(row["DAY_27"].ToString()), 2),
                                DAY_28 = Math.Round(Convert.ToDouble(row["DAY_28"].ToString()), 2),
                                DAY_29 = Math.Round(Convert.ToDouble(row["DAY_29"].ToString()), 2),
                                DAY_30 = Math.Round(Convert.ToDouble(row["DAY_30"].ToString()), 2),
                                DAY_31 = Math.Round(Convert.ToDouble(row["DAY_31"].ToString()), 2)
                            })).ToList<DayWiseModel>();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: {0}", e.Message);
                        }

                      
                    }
                }
                return dayWiseModelList;
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
                return new List<DayWiseModel>();
            }
        }
        public List<DayWiseModel> GetIMSVolumeList(int UserId)
        {
            List<DayWiseModel> dayWiseModelList = new List<DayWiseModel>();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(this.ConnString))
                {
                    using (OracleCommand oracleCommand = new OracleCommand())
                    {

                        string anonymous_block = "begin " +
                            "  :refcursor1 := FN_NATIONAL_DAY_WISE_IMS_VOL(" + UserId + ") ;" +
                            "end;";
                        //fill in your function and variables via the above example
                        OracleCommand sqlCom = oracleConnection.CreateCommand();
                        sqlCom.CommandText = anonymous_block;

                        // Bind 
                        sqlCom.Parameters.Add("refcursor1", OracleDbType.RefCursor);
                        sqlCom.Parameters[0].Direction = ParameterDirection.ReturnValue;


                        try
                        {
                            // Execute command; Have the parameters populated
                            oracleConnection.Open();
                            sqlCom.ExecuteNonQuery();


                            DataTable dataTable = new DataTable();


                            OracleDataAdapter da = new OracleDataAdapter(sqlCom);

                            // Populate a DataSet with refcursor1.
                            DataSet ds = new DataSet();
                            da.Fill(ds, "refcursor1", (OracleRefCursor)(sqlCom.Parameters["refcursor1"].Value));
                            dataTable = ds.Tables["refcursor1"];
                            // Print out the field count the REF Cursor



                            dayWiseModelList = dataTable.Rows.Cast<DataRow>().Select<DataRow, DayWiseModel>((Func<DataRow, DayWiseModel>)(row => new DayWiseModel()
                            {
                                YYYYMMMM = Convert.ToInt32(row["YYYYMM"].ToString()),
                                DAY_01 = Math.Round(Convert.ToDouble(row["DAY_01"].ToString()), 2),
                                DAY_02 = Math.Round(Convert.ToDouble(row["DAY_02"].ToString()), 2),
                                DAY_03 = Math.Round(Convert.ToDouble(row["DAY_03"].ToString()), 2),
                                DAY_04 = Math.Round(Convert.ToDouble(row["DAY_04"].ToString()), 2),
                                DAY_05 = Math.Round(Convert.ToDouble(row["DAY_05"].ToString()), 2),
                                DAY_06 = Math.Round(Convert.ToDouble(row["DAY_06"].ToString()), 2),
                                DAY_07 = Math.Round(Convert.ToDouble(row["DAY_07"].ToString()), 2),
                                DAY_08 = Math.Round(Convert.ToDouble(row["DAY_08"].ToString()), 2),
                                DAY_09 = Math.Round(Convert.ToDouble(row["DAY_09"].ToString()), 2),
                                DAY_10 = Math.Round(Convert.ToDouble(row["DAY_10"].ToString()), 2),
                                DAY_11 = Math.Round(Convert.ToDouble(row["DAY_11"].ToString()), 2),
                                DAY_12 = Math.Round(Convert.ToDouble(row["DAY_12"].ToString()), 2),
                                DAY_13 = Math.Round(Convert.ToDouble(row["DAY_13"].ToString()), 2),
                                DAY_14 = Math.Round(Convert.ToDouble(row["DAY_14"].ToString()), 2),
                                DAY_15 = Math.Round(Convert.ToDouble(row["DAY_15"].ToString()), 2),
                                DAY_16 = Math.Round(Convert.ToDouble(row["DAY_16"].ToString()), 2),
                                DAY_17 = Math.Round(Convert.ToDouble(row["DAY_17"].ToString()), 2),
                                DAY_18 = Math.Round(Convert.ToDouble(row["DAY_18"].ToString()), 2),
                                DAY_19 = Math.Round(Convert.ToDouble(row["DAY_19"].ToString()), 2),
                                DAY_20 = Math.Round(Convert.ToDouble(row["DAY_20"].ToString()), 2),
                                DAY_21 = Math.Round(Convert.ToDouble(row["DAY_21"].ToString()), 2),
                                DAY_22 = Math.Round(Convert.ToDouble(row["DAY_22"].ToString()), 2),
                                DAY_23 = Math.Round(Convert.ToDouble(row["DAY_23"].ToString()), 2),
                                DAY_24 = Math.Round(Convert.ToDouble(row["DAY_24"].ToString()), 2),
                                DAY_25 = Math.Round(Convert.ToDouble(row["DAY_25"].ToString()), 2),
                                DAY_26 = Math.Round(Convert.ToDouble(row["DAY_26"].ToString()), 2),
                                DAY_27 = Math.Round(Convert.ToDouble(row["DAY_27"].ToString()), 2),
                                DAY_28 = Math.Round(Convert.ToDouble(row["DAY_28"].ToString()), 2),
                                DAY_29 = Math.Round(Convert.ToDouble(row["DAY_29"].ToString()), 2),
                                DAY_30 = Math.Round(Convert.ToDouble(row["DAY_30"].ToString()), 2),
                                DAY_31 = Math.Round(Convert.ToDouble(row["DAY_31"].ToString()), 2)
                            })).ToList<DayWiseModel>();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: {0}", e.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
                return new List<DayWiseModel>();
            }
            return dayWiseModelList;
        }
        public List<DayWiseModel> GetIMSValue(int UserId)
        {
            List<DayWiseModel> dayWiseModelList = new List<DayWiseModel>();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(this.ConnString))
                {
                    using (OracleCommand oracleCommand = new OracleCommand())
                    {
                        //oracleCommand.Connection = oracleConnection;
                        //oracleCommand.CommandText = "FN_DAY_WISE_SALES";
                        //oracleCommand.CommandType = CommandType.StoredProcedure;
                        //oracleCommand.Parameters.Add("pUserId", OracleDbType.Int32).Value = (object)UserId;

                        //oracleCommand.Parameters.Add("return_value", OracleDbType.RefCursor, ParameterDirection.InputOutput);
                        //oracleConnection.Open();
                        //oracleCommand.ExecuteNonQuery();
                        //OracleDataReader reader = oracleCommand.ExecuteReader();
                        //DataTable dataTable = new DataTable();
                        //if (reader.HasRows)
                        //    dataTable.Load((IDataReader)reader);


                        string anonymous_block = "begin " +
                              "  :refcursor1 := FN_DAY_WISE_SALES("+ UserId + ") ;" +
                              "end;";
                        //fill in your function and variables via the above example
                        OracleCommand sqlCom = oracleConnection.CreateCommand();
                        sqlCom.CommandText = anonymous_block;

                        // Bind 
                        sqlCom.Parameters.Add("refcursor1", OracleDbType.RefCursor);
                        sqlCom.Parameters[0].Direction = ParameterDirection.ReturnValue;

                        try
                        {
                            // Execute command; Have the parameters populated
                            oracleConnection.Open();
                            sqlCom.ExecuteNonQuery();

                       
                            DataTable dataTable = new DataTable();
                        

                            OracleDataAdapter da = new OracleDataAdapter(sqlCom);

                            // Populate a DataSet with refcursor1.
                            DataSet ds = new DataSet();
                            da.Fill(ds, "refcursor1", (OracleRefCursor)(sqlCom.Parameters["refcursor1"].Value));
                            dataTable = ds.Tables["refcursor1"];
                            // Print out the field count the REF Cursor
                       
                        

                            dayWiseModelList = dataTable.Rows.Cast<DataRow>().Select<DataRow, DayWiseModel>((Func<DataRow, DayWiseModel>)(row => new DayWiseModel()
                            {
                                YYYYMMMM = Convert.ToInt32(row["YYYYMM"].ToString()),
                                DAY_01 = Math.Round(Convert.ToDouble(row["DAY_01"].ToString()) / 10000000.0, 2),
                                DAY_02 = Math.Round(Convert.ToDouble(row["DAY_02"].ToString()) / 10000000.0, 2),
                                DAY_03 = Math.Round(Convert.ToDouble(row["DAY_03"].ToString()) / 10000000.0, 2),
                                DAY_04 = Math.Round(Convert.ToDouble(row["DAY_04"].ToString()) / 10000000.0, 2),
                                DAY_05 = Math.Round(Convert.ToDouble(row["DAY_05"].ToString()) / 10000000.0, 2),
                                DAY_06 = Math.Round(Convert.ToDouble(row["DAY_06"].ToString()) / 10000000.0, 2),
                                DAY_07 = Math.Round(Convert.ToDouble(row["DAY_07"].ToString()) / 10000000.0, 2),
                                DAY_08 = Math.Round(Convert.ToDouble(row["DAY_08"].ToString()) / 10000000.0, 2),
                                DAY_09 = Math.Round(Convert.ToDouble(row["DAY_09"].ToString()) / 10000000.0, 2),
                                DAY_10 = Math.Round(Convert.ToDouble(row["DAY_10"].ToString()) / 10000000.0, 2),
                                DAY_11 = Math.Round(Convert.ToDouble(row["DAY_11"].ToString()) / 10000000.0, 2),
                                DAY_12 = Math.Round(Convert.ToDouble(row["DAY_12"].ToString()) / 10000000.0, 2),
                                DAY_13 = Math.Round(Convert.ToDouble(row["DAY_13"].ToString()) / 10000000.0, 2),
                                DAY_14 = Math.Round(Convert.ToDouble(row["DAY_14"].ToString()) / 10000000.0, 2),
                                DAY_15 = Math.Round(Convert.ToDouble(row["DAY_15"].ToString()) / 10000000.0, 2),
                                DAY_16 = Math.Round(Convert.ToDouble(row["DAY_16"].ToString()) / 10000000.0, 2),
                                DAY_17 = Math.Round(Convert.ToDouble(row["DAY_17"].ToString()) / 10000000.0, 2),
                                DAY_18 = Math.Round(Convert.ToDouble(row["DAY_18"].ToString()) / 10000000.0, 2),
                                DAY_19 = Math.Round(Convert.ToDouble(row["DAY_19"].ToString()) / 10000000.0, 2),
                                DAY_20 = Math.Round(Convert.ToDouble(row["DAY_20"].ToString()) / 10000000.0, 2),
                                DAY_21 = Math.Round(Convert.ToDouble(row["DAY_21"].ToString()) / 10000000.0, 2),
                                DAY_22 = Math.Round(Convert.ToDouble(row["DAY_22"].ToString()) / 10000000.0, 2),
                                DAY_23 = Math.Round(Convert.ToDouble(row["DAY_23"].ToString()) / 10000000.0, 2),
                                DAY_24 = Math.Round(Convert.ToDouble(row["DAY_24"].ToString()) / 10000000.0, 2),
                                DAY_25 = Math.Round(Convert.ToDouble(row["DAY_25"].ToString()) / 10000000.0, 2),
                                DAY_26 = Math.Round(Convert.ToDouble(row["DAY_26"].ToString()) / 10000000.0, 2),
                                DAY_27 = Math.Round(Convert.ToDouble(row["DAY_27"].ToString()) / 10000000.0, 2),
                                DAY_28 = Math.Round(Convert.ToDouble(row["DAY_28"].ToString()) / 10000000.0, 2),
                                DAY_29 = Math.Round(Convert.ToDouble(row["DAY_29"].ToString()) / 10000000.0, 2),
                                DAY_30 = Math.Round(Convert.ToDouble(row["DAY_30"].ToString()) / 10000000.0, 2),
                                DAY_31 = Math.Round(Convert.ToDouble(row["DAY_31"].ToString()) / 10000000.0, 2)
                            })).ToList<DayWiseModel>();

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: {0}", e.Message);
                        }

                        
                    
                    }
                }

            }
            catch (Exception ex)
            {
                dayWiseModelList = new List<DayWiseModel>();
            }


            return dayWiseModelList;
        }


    

        public List<LastFiveYearSalesModel> GetfiveYearsSaleTrend()
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT * from MV_L5Y_TAR_SAL_ACH  order by year desc"));
            List<LastFiveYearSalesModel> fiveYearSalesModelList = new List<LastFiveYearSalesModel>();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, LastFiveYearSalesModel>((Func<DataRow, LastFiveYearSalesModel>)(row => new LastFiveYearSalesModel()
            {
                Year = row["Year"].ToString(),
                IMS_VAL = row["IMS_VAL"].ToString() != "" ? Math.Round(Convert.ToDouble(row["IMS_VAL"].ToString()) / 10000000.0, 2) : 0.0,
                ACH = row["ACH"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ACH"].ToString()) / 10000000.0, 2) : 0.0,
                TARGET_VAL = row["TARGET_VAL"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TARGET_VAL"].ToString()) / 10000000.0, 2) : 0.0
            })).ToList<LastFiveYearSalesModel>();
        }

        public TargetSalesModel GetTargetSalesList(int UserId, string Year)
        {
            TargetSalesModel targetSalesModel = new TargetSalesModel();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(this.ConnString))
                {
                    using (OracleCommand oracleCommand = new OracleCommand())
                    {
                        string anonymous_block = String.Format("begin " +
                             "  :refcursor1 := FN_MONTH_WISE_TAR_SAL_ACH_CY({0},{1}) ;" +
                             "end;",UserId,Year);
                        //fill in your function and variables via the above example
                        OracleCommand sqlCom = oracleConnection.CreateCommand();
                        sqlCom.CommandText = anonymous_block;

                        // Bind 
                        sqlCom.Parameters.Add("refcursor1", OracleDbType.RefCursor);
                        sqlCom.Parameters[0].Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            // Execute command; Have the parameters populated
                            oracleConnection.Open();
                            sqlCom.ExecuteNonQuery();


                            DataTable dataTable = new DataTable();


                            OracleDataAdapter da = new OracleDataAdapter(sqlCom);

                            // Populate a DataSet with refcursor1.
                            DataSet ds = new DataSet();
                            da.Fill(ds, "refcursor1", (OracleRefCursor)(sqlCom.Parameters["refcursor1"].Value));
                            dataTable = ds.Tables["refcursor1"];
                            // Print out the field count the REF Cursor



                            targetSalesModel = dataTable.Rows.Cast<DataRow>().Select<DataRow, TargetSalesModel>((Func<DataRow, TargetSalesModel>)(row => new TargetSalesModel()
                            {
                                JAN_ACH = Math.Round(Convert.ToDouble(row["JAN_ACH"].ToString()), 2),
                                JAN_IMS_VAL = Math.Round(Convert.ToDouble(row["JAN_IMS_VAL"].ToString()) / 10000000.0, 2),
                                JAN_TARGET_VAL = Math.Round(Convert.ToDouble(row["JAN_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                FEB_ACH = Math.Round(Convert.ToDouble(row["FEB_ACH"].ToString()), 2),
                                FEB_IMS_VAL = Math.Round(Convert.ToDouble(row["FEB_IMS_VAL"].ToString()) / 10000000.0, 2),
                                FEB_TARGET_VAL = Math.Round(Convert.ToDouble(row["FEB_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                MAR_ACH = Math.Round(Convert.ToDouble(row["MAR_ACH"].ToString()), 2),
                                MAR_IMS_VAL = Math.Round(Convert.ToDouble(row["MAR_IMS_VAL"].ToString()) / 10000000.0, 2),
                                MAR_TARGET_VAL = Math.Round(Convert.ToDouble(row["MAR_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                APR_ACH = Math.Round(Convert.ToDouble(row["APR_ACH"].ToString()), 2),
                                APR_IMS_VAL = Math.Round(Convert.ToDouble(row["APR_IMS_VAL"].ToString()) / 10000000.0, 2),
                                APR_TARGET_VAL = Math.Round(Convert.ToDouble(row["APR_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                MAY_ACH = Math.Round(Convert.ToDouble(row["MAY_ACH"].ToString()), 2),
                                MAY_IMS_VAL = Math.Round(Convert.ToDouble(row["MAY_IMS_VAL"].ToString()) / 10000000.0, 2),
                                MAY_TARGET_VAL = Math.Round(Convert.ToDouble(row["MAY_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                JUN_ACH = Math.Round(Convert.ToDouble(row["JUN_ACH"].ToString()), 2),
                                JUN_IMS_VAL = Math.Round(Convert.ToDouble(row["JUN_IMS_VAL"].ToString()) / 10000000.0, 2),
                                JUN_TARGET_VAL = Math.Round(Convert.ToDouble(row["JUN_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                JUL_ACH = Math.Round(Convert.ToDouble(row["JUL_ACH"].ToString()), 2),
                                JUL_IMS_VAL = Math.Round(Convert.ToDouble(row["JUL_IMS_VAL"].ToString()) / 10000000.0, 2),
                                JUL_TARGET_VAL = Math.Round(Convert.ToDouble(row["JUL_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                AUG_ACH = Math.Round(Convert.ToDouble(row["AUG_ACH"].ToString()), 2),
                                AUG_IMS_VAL = Math.Round(Convert.ToDouble(row["AUG_IMS_VAL"].ToString()) / 10000000.0, 2),
                                AUG_TARGET_VAL = Math.Round(Convert.ToDouble(row["AUG_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                SEP_ACH = Math.Round(Convert.ToDouble(row["SEP_ACH"].ToString()), 2),
                                SEP_IMS_VAL = Math.Round(Convert.ToDouble(row["SEP_IMS_VAL"].ToString()) / 10000000.0, 2),
                                SEP_TARGET_VAL = Math.Round(Convert.ToDouble(row["SEP_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                OCT_ACH = Math.Round(Convert.ToDouble(row["OCT_ACH"].ToString()), 2),
                                OCT_IMS_VAL = Math.Round(Convert.ToDouble(row["OCT_IMS_VAL"].ToString()) / 10000000.0, 2),
                                OCT_TARGET_VAL = Math.Round(Convert.ToDouble(row["OCT_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                NOV_ACH = Math.Round(Convert.ToDouble(row["NOV_ACH"].ToString()), 2),
                                NOV_IMS_VAL = Math.Round(Convert.ToDouble(row["NOV_IMS_VAL"].ToString()) / 10000000.0, 2),
                                NOV_TARGET_VAL = Math.Round(Convert.ToDouble(row["NOV_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                DEC_ACH = Math.Round(Convert.ToDouble(row["DEC_ACH"].ToString()), 2),
                                DEC_IMS_VAL = Math.Round(Convert.ToDouble(row["DEC_IMS_VAL"].ToString()) / 10000000.0, 2),
                                DEC_TARGET_VAL = Math.Round(Convert.ToDouble(row["DEC_TARGET_VAL"].ToString()) / 10000000.0, 2)
                            })).ToList<TargetSalesModel>().FirstOrDefault<TargetSalesModel>(); ;

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: {0}", e.Message);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
                return new TargetSalesModel();
            }

            return targetSalesModel;
        }
        public TargetSalesModel GetTargetSalesListLastYear(int UserId, string Year)
        {
            TargetSalesModel targetSalesModel = new TargetSalesModel();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(this.ConnString))
                {
                    using (OracleCommand oracleCommand = new OracleCommand())
                    {
                        string anonymous_block = String.Format("begin " +
                             "  :refcursor1 := FN_MONTH_WISE_TAR_SAL_ACH_LY({0},{1}) ;" +
                             "end;", UserId, Year);
                        //fill in your function and variables via the above example
                        OracleCommand sqlCom = oracleConnection.CreateCommand();
                        sqlCom.CommandText = anonymous_block;

                        // Bind 
                        sqlCom.Parameters.Add("refcursor1", OracleDbType.RefCursor);
                        sqlCom.Parameters[0].Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            // Execute command; Have the parameters populated
                            oracleConnection.Open();
                            sqlCom.ExecuteNonQuery();


                            DataTable dataTable = new DataTable();


                            OracleDataAdapter da = new OracleDataAdapter(sqlCom);

                            // Populate a DataSet with refcursor1.
                            DataSet ds = new DataSet();
                            da.Fill(ds, "refcursor1", (OracleRefCursor)(sqlCom.Parameters["refcursor1"].Value));
                            dataTable = ds.Tables["refcursor1"];
                            // Print out the field count the REF Cursor



                            targetSalesModel = dataTable.Rows.Cast<DataRow>().Select<DataRow, TargetSalesModel>((Func<DataRow, TargetSalesModel>)(row => new TargetSalesModel()
                            {
                                JAN_ACH = Math.Round(Convert.ToDouble(row["JAN_ACH"].ToString()), 2),
                                JAN_IMS_VAL = Math.Round(Convert.ToDouble(row["JAN_IMS_VAL"].ToString()) / 10000000.0, 2),
                                JAN_TARGET_VAL = Math.Round(Convert.ToDouble(row["JAN_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                FEB_ACH = Math.Round(Convert.ToDouble(row["FEB_ACH"].ToString()), 2),
                                FEB_IMS_VAL = Math.Round(Convert.ToDouble(row["FEB_IMS_VAL"].ToString()) / 10000000.0, 2),
                                FEB_TARGET_VAL = Math.Round(Convert.ToDouble(row["FEB_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                MAR_ACH = Math.Round(Convert.ToDouble(row["MAR_ACH"].ToString()), 2),
                                MAR_IMS_VAL = Math.Round(Convert.ToDouble(row["MAR_IMS_VAL"].ToString()) / 10000000.0, 2),
                                MAR_TARGET_VAL = Math.Round(Convert.ToDouble(row["MAR_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                APR_ACH = Math.Round(Convert.ToDouble(row["APR_ACH"].ToString()), 2),
                                APR_IMS_VAL = Math.Round(Convert.ToDouble(row["APR_IMS_VAL"].ToString()) / 10000000.0, 2),
                                APR_TARGET_VAL = Math.Round(Convert.ToDouble(row["APR_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                MAY_ACH = Math.Round(Convert.ToDouble(row["MAY_ACH"].ToString()), 2),
                                MAY_IMS_VAL = Math.Round(Convert.ToDouble(row["MAY_IMS_VAL"].ToString()) / 10000000.0, 2),
                                MAY_TARGET_VAL = Math.Round(Convert.ToDouble(row["MAY_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                JUN_ACH = Math.Round(Convert.ToDouble(row["JUN_ACH"].ToString()), 2),
                                JUN_IMS_VAL = Math.Round(Convert.ToDouble(row["JUN_IMS_VAL"].ToString()) / 10000000.0, 2),
                                JUN_TARGET_VAL = Math.Round(Convert.ToDouble(row["JUN_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                JUL_ACH = Math.Round(Convert.ToDouble(row["JUL_ACH"].ToString()), 2),
                                JUL_IMS_VAL = Math.Round(Convert.ToDouble(row["JUL_IMS_VAL"].ToString()) / 10000000.0, 2),
                                JUL_TARGET_VAL = Math.Round(Convert.ToDouble(row["JUL_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                AUG_ACH = Math.Round(Convert.ToDouble(row["AUG_ACH"].ToString()), 2),
                                AUG_IMS_VAL = Math.Round(Convert.ToDouble(row["AUG_IMS_VAL"].ToString()) / 10000000.0, 2),
                                AUG_TARGET_VAL = Math.Round(Convert.ToDouble(row["AUG_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                SEP_ACH = Math.Round(Convert.ToDouble(row["SEP_ACH"].ToString()), 2),
                                SEP_IMS_VAL = Math.Round(Convert.ToDouble(row["SEP_IMS_VAL"].ToString()) / 10000000.0, 2),
                                SEP_TARGET_VAL = Math.Round(Convert.ToDouble(row["SEP_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                OCT_ACH = Math.Round(Convert.ToDouble(row["OCT_ACH"].ToString()), 2),
                                OCT_IMS_VAL = Math.Round(Convert.ToDouble(row["OCT_IMS_VAL"].ToString()) / 10000000.0, 2),
                                OCT_TARGET_VAL = Math.Round(Convert.ToDouble(row["OCT_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                NOV_ACH = Math.Round(Convert.ToDouble(row["NOV_ACH"].ToString()), 2),
                                NOV_IMS_VAL = Math.Round(Convert.ToDouble(row["NOV_IMS_VAL"].ToString()) / 10000000.0, 2),
                                NOV_TARGET_VAL = Math.Round(Convert.ToDouble(row["NOV_TARGET_VAL"].ToString()) / 10000000.0, 2),
                                DEC_ACH = Math.Round(Convert.ToDouble(row["DEC_ACH"].ToString()), 2),
                                DEC_IMS_VAL = Math.Round(Convert.ToDouble(row["DEC_IMS_VAL"].ToString()) / 10000000.0, 2),
                                DEC_TARGET_VAL = Math.Round(Convert.ToDouble(row["DEC_TARGET_VAL"].ToString()) / 10000000.0, 2)
                            })).ToList<TargetSalesModel>().FirstOrDefault<TargetSalesModel>(); ;

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: {0}", e.Message);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
                return new TargetSalesModel();
            }

            return targetSalesModel;
        }
  

        public List<SalesWiseModel> GetProductWiseSales()
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("select * from MV_PRODUCT_WISE_SALES"));
            List<SalesWiseModel> salesWiseModelList = new List<SalesWiseModel>();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, SalesWiseModel>((Func<DataRow, SalesWiseModel>)(row => new SalesWiseModel()
            {
                PRODUCT_CODE = row["PRODUCT_CODE"].ToString(),
                PRODUCT_NAME = row["PRODUCT_NAME"].ToString(),
                IMS_VALUE = row["IMS_VALUE"].ToString() != "" ? Convert.ToDouble(row["IMS_VALUE"].ToString()) : 0.0,
                RETURN_VALUE = row["RETURN_VALUE"].ToString() != "" ? Convert.ToDouble(row["RETURN_VALUE"].ToString()) : 0.0,
                SALES_VALUE = row["SALES_VALUE"].ToString() != "" ? Convert.ToDouble(row["SALES_VALUE"].ToString()) : 0.0,
                PCT_OF_TOTAL_IMS_VALUE = row["PCT_OF_TOTAL_IMS_VALUE"].ToString() != "" ? Convert.ToDouble(row["PCT_OF_TOTAL_IMS_VALUE"].ToString()) : 0.0,
                IMS_VALUE_CORE = row["IMS_VALUE_CORE"].ToString() != "" ? Convert.ToDouble(row["IMS_VALUE_CORE"].ToString()) : 0.0
            })).ToList<SalesWiseModel>();
        }

        public List<SalesWiseModel> GetCategoryWiseSales()
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("select * from MV_Category_WISE_SALES"));
            List<SalesWiseModel> salesWiseModelList = new List<SalesWiseModel>();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, SalesWiseModel>((Func<DataRow, SalesWiseModel>)(row => new SalesWiseModel()
            {
                CATEGORY_CODE = row["CATEGORY_CODE"].ToString(),
                CATEGORY_NAME = row["CATEGORY_NAME"].ToString(),
                IMS_VALUE = row["IMS_VALUE"].ToString() != "" ? Convert.ToDouble(row["IMS_VALUE"].ToString()) : 0.0,
                RETURN_VALUE = row["RETURN_VALUE"].ToString() != "" ? Convert.ToDouble(row["RETURN_VALUE"].ToString()) : 0.0,
                SALES_VALUE = row["SALES_VALUE"].ToString() != "" ? Convert.ToDouble(row["SALES_VALUE"].ToString()) : 0.0,
                PCT_OF_TOTAL_IMS_VALUE = row["PCT_OF_TOTAL_IMS_VALUE"].ToString() != "" ? Convert.ToDouble(row["PCT_OF_TOTAL_IMS_VALUE"].ToString()) : 0.0,
                IMS_VALUE_CORE = row["IMS_VALUE_CORE"].ToString() != "" ? Convert.ToDouble(row["IMS_VALUE_CORE"].ToString()) : 0.0
            })).ToList<SalesWiseModel>();
        }
        public List<SalesWiseModel> GetBrandWiseSales()
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("select * from MV_Brand_WISE_SALES"));
            List<SalesWiseModel> salesWiseModelList = new List<SalesWiseModel>();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, SalesWiseModel>((Func<DataRow, SalesWiseModel>)(row => new SalesWiseModel()
            {
                BRAND_CODE = row["BRAND_CODE"].ToString(),
                BRAND_NAME = row["BRAND_NAME"].ToString(),
                IMS_VALUE = row["IMS_VALUE"].ToString() != "" ? Convert.ToDouble(row["IMS_VALUE"].ToString()) : 0.0,
                RETURN_VALUE = row["RETURN_VALUE"].ToString() != "" ? Convert.ToDouble(row["RETURN_VALUE"].ToString()) : 0.0,
                SALES_VALUE = row["SALES_VALUE"].ToString() != "" ? Convert.ToDouble(row["SALES_VALUE"].ToString()) : 0.0,
                PCT_OF_TOTAL_IMS_VALUE = row["PCT_OF_TOTAL_IMS_VALUE"].ToString() != "" ? Convert.ToDouble(row["PCT_OF_TOTAL_IMS_VALUE"].ToString()) : 0.0,
                IMS_VALUE_CORE = row["IMS_VALUE_CORE"].ToString() != "" ? Convert.ToDouble(row["IMS_VALUE_CORE"].ToString()) : 0.0
            })).ToList<SalesWiseModel>();
        }
    }
}
