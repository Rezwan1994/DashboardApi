// Decompiled with JetBrains decompiler
// Type: DashboardAPI.Model.DAL.masterDashboardDal
// Assembly: DashboardAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6304A5F-607C-40EF-B4AA-478DAE5D9B02
// Assembly location: E:\DashboardCoreApi\DashboardAPI.dll

using DashboardAPI.Getway;
using DashboardAPI.Model.BEL;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


#nullable enable
namespace DashboardAPI.Model.DAL
{
    public class masterDashboardDal : ReturnData
    {
        private readonly DBHelper _dbHelper = new DBHelper();
        private readonly ErrorLogger _errorLogger = new ErrorLogger();
        private static readonly DBConnection DBConnection = new DBConnection();
        public readonly string ConnString = masterDashboardDal.DBConnection.SAConnStrReader("Oracle", "PHARMAERP");

        public TodayDashboardCartModel GetTodayCartValue(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("select fnc_today_order_val({0}) OrderValue,\r\n            fnc_today_sales_val({0}) SalesValue, fnc_today_sched_retailer({0}) ScheduledRetailer,\r\n            fnc_today_ordering_retailer({0}) OrderingRetailer, fnc_total_retailer({0}) TotalRetailer from dual", (object)UserId));
            TodayDashboardCartModel dashboardCartModel = new TodayDashboardCartModel();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, TodayDashboardCartModel>((Func<DataRow, TodayDashboardCartModel>)(row =>
            {
                TodayDashboardCartModel todayCartValue = new TodayDashboardCartModel();
                todayCartValue.OrderValue = row["ORDERVALUE"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ORDERVALUE"].ToString()), 2) : 0.0;
                todayCartValue.SalesValue = row["SalesValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["SalesValue"].ToString()), 2) : 0.0;
                todayCartValue.OrderingRetailer = row["OrderingRetailer"].ToString() != "" ? Math.Round(Convert.ToDouble(row["OrderingRetailer"].ToString()), 2) : 0.0;
                todayCartValue.ScheduledRetailer = row["ScheduledRetailer"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ScheduledRetailer"].ToString()), 2) : 0.0;
                todayCartValue.TotalRetailer = row["TotalRetailer"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TotalRetailer"].ToString()), 2) : 0.0;
                DateTime dateTime = DateTime.Now;
                dateTime = dateTime.Date;
                todayCartValue.Date = dateTime.ToString("dd-MM-yyyy");
                return todayCartValue;
            })).ToList<TodayDashboardCartModel>().FirstOrDefault<TodayDashboardCartModel>();
        }

        public MonthlyDashboardCartModel GetMonthlyCartValue(int UserId) => this._dbHelper.GetDataTable(string.Format("select FNC_MTD_TARGET_VAL(1) TargetValue,\r\n            FNC_MTD_IMS_VAL(1) SalesValue,FNC_MTD_RETURN_VAL(1) ReturnValue,\r\n            FNC_MTD_ACH_VAL(1) AchValue,FNC_MTD_GROWTH(1) GrowthValue from dual", (object)UserId)).Rows.Cast<DataRow>().Select<DataRow, MonthlyDashboardCartModel>((Func<DataRow, MonthlyDashboardCartModel>)(row =>
        {
            MonthlyDashboardCartModel monthlyCartValue = new MonthlyDashboardCartModel();
            monthlyCartValue.TargetValue = row["TargetValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TargetValue"].ToString()), 2) : 0.0;
            monthlyCartValue.SalesValue = row["SalesValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["SalesValue"].ToString()), 2) : 0.0;
            monthlyCartValue.AchValue = row["AchValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["AchValue"].ToString()), 2) : 0.0;
            monthlyCartValue.GrowthValue = row["GrowthValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["GrowthValue"].ToString()), 2) : 0.0;
            monthlyCartValue.ReturnValue = row["ReturnValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ReturnValue"].ToString()), 2) : 0.0;
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.Date;
            monthlyCartValue.Month = dateTime.ToString("MMMM");
            return monthlyCartValue;
        })).ToList<MonthlyDashboardCartModel>().FirstOrDefault<MonthlyDashboardCartModel>();

        public MonthlyDashboardCartModel GetYearlyCartValue(int UserId) => this._dbHelper.GetDataTable(string.Format("select FNC_YTD_TARGET_VAL(1) TargetValue,\r\n            FNC_YTD_IMS_VAL(1) SalesValue,FNC_YTD_RETURN_VAL(1) ReturnValue,\r\n            FNC_YTD_ACH_VAL(1) AchValue,FNC_YTD_GROWTH(1) GrowthValue from dual", (object)UserId)).Rows.Cast<DataRow>().Select<DataRow, MonthlyDashboardCartModel>((Func<DataRow, MonthlyDashboardCartModel>)(row =>
        {
            MonthlyDashboardCartModel yearlyCartValue = new MonthlyDashboardCartModel();
            yearlyCartValue.TargetValue = row["TargetValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TargetValue"].ToString()), 2) : 0.0;
            yearlyCartValue.SalesValue = row["SalesValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["SalesValue"].ToString()), 2) : 0.0;
            yearlyCartValue.AchValue = row["AchValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["AchValue"].ToString()), 2) : 0.0;
            yearlyCartValue.GrowthValue = row["GrowthValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["GrowthValue"].ToString()), 2) : 0.0;
            yearlyCartValue.ReturnValue = row["ReturnValue"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ReturnValue"].ToString()), 2) : 0.0;
            DateTime dateTime = DateTime.Now;
            dateTime = dateTime.Date;
            yearlyCartValue.Month = dateTime.ToString("MMMM");
            return yearlyCartValue;
        })).ToList<MonthlyDashboardCartModel>().FirstOrDefault<MonthlyDashboardCartModel>();

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
            RetailerCount retailerCount = new RetailerCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, RetailerCount>((Func<DataRow, RetailerCount>)(row => new RetailerCount()
            {
                ScheduledRetailer = row["ScheduledRetailer"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ScheduledRetailer"].ToString()), 2) : 0.0
            })).ToList<RetailerCount>().FirstOrDefault<RetailerCount>();
        }

        public RetailerCount GetTotalRetailerCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT fnc_total_retailer({0}) TotalRetailer FROM DUAL", (object)UserId));
            RetailerCount retailerCount = new RetailerCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, RetailerCount>((Func<DataRow, RetailerCount>)(row => new RetailerCount()
            {
                TotalRetailer = row["TotalRetailer"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TotalRetailer"].ToString()), 2) : 0.0
            })).ToList<RetailerCount>().FirstOrDefault<RetailerCount>();
        }

        public RetailerCount GetOrderingRetailerCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT fnc_today_ordering_retailer({0}) OrderingRetailer FROM DUAL", (object)UserId));
            RetailerCount retailerCount = new RetailerCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, RetailerCount>((Func<DataRow, RetailerCount>)(row => new RetailerCount()
            {
                OrderingRetailer = row["OrderingRetailer"].ToString() != "" ? Math.Round(Convert.ToDouble(row["OrderingRetailer"].ToString()), 2) : 0.0
            })).ToList<RetailerCount>().FirstOrDefault<RetailerCount>();
        }

        public ReturnACHGrowthCount GetMTDReturnCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_MTD_RETURN_VAL({0}) ReturnedCount FROM DUAL", (object)UserId));
            ReturnACHGrowthCount returnAchGrowthCount = new ReturnACHGrowthCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, ReturnACHGrowthCount>((Func<DataRow, ReturnACHGrowthCount>)(row => new ReturnACHGrowthCount()
            {
                ReturnedCount = row["ReturnedCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ReturnedCount"].ToString()) / 10000000.0, 2) : 0.0
            })).ToList<ReturnACHGrowthCount>().FirstOrDefault<ReturnACHGrowthCount>();
        }

        public ReturnACHGrowthCount GetMTDACHCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_MTD_ACH_VAL({0}) ACHCount FROM DUAL", (object)UserId));
            ReturnACHGrowthCount returnAchGrowthCount = new ReturnACHGrowthCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, ReturnACHGrowthCount>((Func<DataRow, ReturnACHGrowthCount>)(row => new ReturnACHGrowthCount()
            {
                ACHCount = row["ACHCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ACHCount"].ToString()), 2) : 0.0
            })).ToList<ReturnACHGrowthCount>().FirstOrDefault<ReturnACHGrowthCount>();
        }

        public ReturnACHGrowthCount GetMTDGrowthCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_MTD_GROWTH({0}) GrowthCount FROM DUAL", (object)UserId));
            ReturnACHGrowthCount returnAchGrowthCount = new ReturnACHGrowthCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, ReturnACHGrowthCount>((Func<DataRow, ReturnACHGrowthCount>)(row => new ReturnACHGrowthCount()
            {
                GrowthCount = row["GrowthCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["GrowthCount"].ToString()), 2) : 0.0
            })).ToList<ReturnACHGrowthCount>().FirstOrDefault<ReturnACHGrowthCount>();
        }

        public ReturnACHGrowthCount GetYTDGrowthCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_YTD_GROWTH({0}) GrowthCount FROM DUAL", (object)UserId));
            ReturnACHGrowthCount returnAchGrowthCount = new ReturnACHGrowthCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, ReturnACHGrowthCount>((Func<DataRow, ReturnACHGrowthCount>)(row => new ReturnACHGrowthCount()
            {
                GrowthCount = row["GrowthCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["GrowthCount"].ToString()), 2) : 0.0
            })).ToList<ReturnACHGrowthCount>().FirstOrDefault<ReturnACHGrowthCount>();
        }

        public ReturnACHGrowthCount GetYTDReturnCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_YTD_RETURN_VAL({0}) ReturnedCount FROM DUAL", (object)UserId));
            ReturnACHGrowthCount returnAchGrowthCount = new ReturnACHGrowthCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, ReturnACHGrowthCount>((Func<DataRow, ReturnACHGrowthCount>)(row => new ReturnACHGrowthCount()
            {
                ReturnedCount = row["ReturnedCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ReturnedCount"].ToString()) / 10000000.0, 2) : 0.0
            })).ToList<ReturnACHGrowthCount>().FirstOrDefault<ReturnACHGrowthCount>();
        }

        public PC_LPCCount GetTodayPCCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_TODAY_PC({0}) TodayPCCount,FNC_MTD_PC({0}) MonthlyPCCount,FNC_YTD_PC({0}) YearlyPCCount,FNC_TODAY_LPC({0}) TodayLPCCount,FNC_MTD_LPC({0}) MonthlyLPCCount, FNC_YTD_LPC({0}) YearlyLPCCount FROM DUAL", (object)UserId));
            PC_LPCCount pcLpcCount = new PC_LPCCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, PC_LPCCount>((Func<DataRow, PC_LPCCount>)(row => new PC_LPCCount()
            {
                TodayPCCount = row["TodayPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TodayPCCount"].ToString()), 2) : 0.0,
                MonthlyPCCount = row["MonthlyPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["MonthlyPCCount"].ToString()), 2) : 0.0,
                YearlyPCCount = row["YearlyPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["YearlyPCCount"].ToString()), 2) : 0.0,
                TodayLPCCount = row["TodayLPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TodayLPCCount"].ToString()), 2) : 0.0,
                MonthlyLPCCount = row["MonthlyLPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["MonthlyLPCCount"].ToString()), 2) : 0.0,
                YearlyLPCCount = row["YearlyLPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["YearlyLPCCount"].ToString()), 2) : 0.0
            })).ToList<PC_LPCCount>().FirstOrDefault<PC_LPCCount>();
        }

        public PC_LPCCount GetMonthlyPCCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_MTD_PC({0}) MonthlyPCCount FROM DUAL", (object)UserId));
            PC_LPCCount pcLpcCount = new PC_LPCCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, PC_LPCCount>((Func<DataRow, PC_LPCCount>)(row => new PC_LPCCount()
            {
                MonthlyPCCount = row["MonthlyPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["MonthlyPCCount"].ToString()), 2) : 0.0
            })).ToList<PC_LPCCount>().FirstOrDefault<PC_LPCCount>();
        }

        public PC_LPCCount GetYearlyPCCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_YTD_PC({0}) YearlyPCCount FROM DUAL", (object)UserId));
            PC_LPCCount pcLpcCount = new PC_LPCCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, PC_LPCCount>((Func<DataRow, PC_LPCCount>)(row => new PC_LPCCount()
            {
                YearlyPCCount = row["YearlyPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["YearlyPCCount"].ToString()), 2) : 0.0
            })).ToList<PC_LPCCount>().FirstOrDefault<PC_LPCCount>();
        }

        public PC_LPCCount GetYearlyLPCCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_YTD_LPC({0}) YearlyLPCCount FROM DUAL", (object)UserId));
            PC_LPCCount pcLpcCount = new PC_LPCCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, PC_LPCCount>((Func<DataRow, PC_LPCCount>)(row => new PC_LPCCount()
            {
                YearlyPCCount = row["YearlyLPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["YearlyLPCCount"].ToString()), 2) : 0.0
            })).ToList<PC_LPCCount>().FirstOrDefault<PC_LPCCount>();
        }

        public PC_LPCCount GetMonthlyLPCCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_MTD_LPC({0}) MonthlyLPCCount FROM DUAL", (object)UserId));
            PC_LPCCount pcLpcCount = new PC_LPCCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, PC_LPCCount>((Func<DataRow, PC_LPCCount>)(row => new PC_LPCCount()
            {
                MonthlyPCCount = row["MonthlyLPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["MonthlyLPCCount"].ToString()), 2) : 0.0
            })).ToList<PC_LPCCount>().FirstOrDefault<PC_LPCCount>();
        }

        public PC_LPCCount GetTodayLPCCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_TODAY_LPC({0}) TodayLPCCount FROM DUAL", (object)UserId));
            PC_LPCCount pcLpcCount = new PC_LPCCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, PC_LPCCount>((Func<DataRow, PC_LPCCount>)(row => new PC_LPCCount()
            {
                TodayPCCount = row["TodayLPCCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["TodayLPCCount"].ToString()), 2) : 0.0
            })).ToList<PC_LPCCount>().FirstOrDefault<PC_LPCCount>();
        }

        public ReturnACHGrowthCount GetYTDACHCount(int UserId)
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("SELECT FNC_YTD_ACH_VAL({0}) ACHCount FROM DUAL", (object)UserId));
            ReturnACHGrowthCount returnAchGrowthCount = new ReturnACHGrowthCount();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, ReturnACHGrowthCount>((Func<DataRow, ReturnACHGrowthCount>)(row => new ReturnACHGrowthCount()
            {
                ACHCount = row["ACHCount"].ToString() != "" ? Math.Round(Convert.ToDouble(row["ACHCount"].ToString()), 2) : 0.0
            })).ToList<ReturnACHGrowthCount>().FirstOrDefault<ReturnACHGrowthCount>();
        }

        public DayWiseModel GetIMSReturnPct(int UserId)
        {
            DayWiseModel imsReturnPct = new DayWiseModel();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(this.ConnString))
                {
                    using (new OracleCommand())
                    {
                        string str = "begin   :refcursor1 := FN_DAY_WISE_RETURN_PCT(" + UserId.ToString() + ") ;end;";
                        OracleCommand command = oracleConnection.CreateCommand();
                        command.CommandText = str;
                        command.Parameters.Add("refcursor1", OracleDbType.RefCursor);
                        command.Parameters[0].Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            oracleConnection.Open();
                            command.ExecuteNonQuery();
                            DataTable dataTable = new DataTable();
                            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(command);
                            DataSet dataSet = new DataSet();
                            oracleDataAdapter.Fill(dataSet, "refcursor1", (OracleRefCursor)command.Parameters["refcursor1"].Value);
                            imsReturnPct = dataSet.Tables["refcursor1"].Rows.Cast<DataRow>().Select<DataRow, DayWiseModel>((Func<DataRow, DayWiseModel>)(row => new DayWiseModel()
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
                            })).ToList<DayWiseModel>().FirstOrDefault<DayWiseModel>();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: {0}", (object)ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
                return new DayWiseModel();
            }
            return imsReturnPct;
        }

        public DayWiseModel GetPCTrend(int UserId, string Year)
        {
            DayWiseModel pcTrend = new DayWiseModel();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(this.ConnString))
                {
                    using (new OracleCommand())
                    {
                        string str = string.Format("begin   :refcursor1 := FN_DAY_WISE_PC({0},'{1}'); \r\n                          end;", (object)UserId, (object)Year);
                        OracleCommand command = oracleConnection.CreateCommand();
                        command.CommandText = str;
                        command.Parameters.Add("refcursor1", OracleDbType.RefCursor);
                        command.Parameters[0].Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            oracleConnection.Open();
                            command.ExecuteNonQuery();
                            DataTable dataTable = new DataTable();
                            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(command);
                            DataSet dataSet = new DataSet();
                            oracleDataAdapter.Fill(dataSet, "refcursor1", (OracleRefCursor)command.Parameters["refcursor1"].Value);
                            pcTrend = dataSet.Tables["refcursor1"].Rows.Cast<DataRow>().Select<DataRow, DayWiseModel>((Func<DataRow, DayWiseModel>)(row => new DayWiseModel()
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
                            })).ToList<DayWiseModel>().FirstOrDefault<DayWiseModel>();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: {0}", (object)ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
                return new DayWiseModel();
            }
            return pcTrend;
        }

        public List<DayWiseModel> GetPhysicalAndTransitStockList(int UserId, string Year)
        {
            List<DayWiseModel> transitStockList = new List<DayWiseModel>();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(this.ConnString))
                {
                    using (new OracleCommand())
                    {
                        string str = string.Format("begin   :refcursor1 := FN_DATE_WISE_STOCK_VALUE({0},'{1}'); \r\n                          end;", (object)UserId, (object)Year);
                        OracleCommand command = oracleConnection.CreateCommand();
                        command.CommandText = str;
                        command.Parameters.Add("refcursor1", OracleDbType.RefCursor);
                        command.Parameters[0].Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            oracleConnection.Open();
                            command.ExecuteNonQuery();
                            DataTable dataTable = new DataTable();
                            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(command);
                            DataSet dataSet = new DataSet();
                            oracleDataAdapter.Fill(dataSet, "refcursor1", (OracleRefCursor)command.Parameters["refcursor1"].Value);
                            transitStockList = dataSet.Tables["refcursor1"].Rows.Cast<DataRow>().Select<DataRow, DayWiseModel>((Func<DataRow, DayWiseModel>)(row => new DayWiseModel()
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
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: {0}", (object)ex.Message);
                        }
                    }
                }
                return transitStockList;
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
                return new List<DayWiseModel>();
            }
        }

        public List<DayWiseModel> GetIMSVolumeList(int UserId)
        {
            List<DayWiseModel> imsVolumeList = new List<DayWiseModel>();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(this.ConnString))
                {
                    using (new OracleCommand())
                    {
                        string str = "begin   :refcursor1 := FN_NATIONAL_DAY_WISE_IMS_VOL(" + UserId.ToString() + ") ;end;";
                        OracleCommand command = oracleConnection.CreateCommand();
                        command.CommandText = str;
                        command.Parameters.Add("refcursor1", OracleDbType.RefCursor);
                        command.Parameters[0].Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            oracleConnection.Open();
                            command.ExecuteNonQuery();
                            DataTable dataTable = new DataTable();
                            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(command);
                            DataSet dataSet = new DataSet();
                            oracleDataAdapter.Fill(dataSet, "refcursor1", (OracleRefCursor)command.Parameters["refcursor1"].Value);
                            imsVolumeList = dataSet.Tables["refcursor1"].Rows.Cast<DataRow>().Select<DataRow, DayWiseModel>((Func<DataRow, DayWiseModel>)(row => new DayWiseModel()
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
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: {0}", (object)ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
                return new List<DayWiseModel>();
            }
            return imsVolumeList;
        }

        public List<DayWiseModel> GetIMSValue(int UserId)
        {
            List<DayWiseModel> imsValue = new List<DayWiseModel>();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(this.ConnString))
                {
                    using (new OracleCommand())
                    {
                        string str = "begin   :refcursor1 := FN_DAY_WISE_SALES(" + UserId.ToString() + ") ;end;";
                        OracleCommand command = oracleConnection.CreateCommand();
                        command.CommandText = str;
                        command.Parameters.Add("refcursor1", OracleDbType.RefCursor);
                        command.Parameters[0].Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            oracleConnection.Open();
                            command.ExecuteNonQuery();
                            DataTable dataTable = new DataTable();
                            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(command);
                            DataSet dataSet = new DataSet();
                            oracleDataAdapter.Fill(dataSet, "refcursor1", (OracleRefCursor)command.Parameters["refcursor1"].Value);
                            imsValue = dataSet.Tables["refcursor1"].Rows.Cast<DataRow>().Select<DataRow, DayWiseModel>((Func<DataRow, DayWiseModel>)(row => new DayWiseModel()
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
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: {0}", (object)ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                imsValue = new List<DayWiseModel>();
            }
            return imsValue;
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
            TargetSalesModel targetSalesList = new TargetSalesModel();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(this.ConnString))
                {
                    using (new OracleCommand())
                    {
                        string str = string.Format("begin   :refcursor1 := FN_MONTH_WISE_TAR_SAL_ACH_CY({0},{1}) ;end;", (object)UserId, (object)Year);
                        OracleCommand command = oracleConnection.CreateCommand();
                        command.CommandText = str;
                        command.Parameters.Add("refcursor1", OracleDbType.RefCursor);
                        command.Parameters[0].Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            oracleConnection.Open();
                            command.ExecuteNonQuery();
                            DataTable dataTable = new DataTable();
                            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(command);
                            DataSet dataSet = new DataSet();
                            oracleDataAdapter.Fill(dataSet, "refcursor1", (OracleRefCursor)command.Parameters["refcursor1"].Value);
                            targetSalesList = dataSet.Tables["refcursor1"].Rows.Cast<DataRow>().Select<DataRow, TargetSalesModel>((Func<DataRow, TargetSalesModel>)(row => new TargetSalesModel()
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
                            })).ToList<TargetSalesModel>().FirstOrDefault<TargetSalesModel>();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: {0}", (object)ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
                return new TargetSalesModel();
            }
            return targetSalesList;
        }

        public TargetSalesModel GetTargetSalesListLastYear(int UserId, string Year)
        {
            TargetSalesModel salesListLastYear = new TargetSalesModel();
            try
            {
                using (OracleConnection oracleConnection = new OracleConnection(this.ConnString))
                {
                    using (new OracleCommand())
                    {
                        string str = string.Format("begin   :refcursor1 := FN_MONTH_WISE_TAR_SAL_ACH_LY({0},{1}) ;end;", (object)UserId, (object)Year);
                        OracleCommand command = oracleConnection.CreateCommand();
                        command.CommandText = str;
                        command.Parameters.Add("refcursor1", OracleDbType.RefCursor);
                        command.Parameters[0].Direction = ParameterDirection.ReturnValue;
                        try
                        {
                            oracleConnection.Open();
                            command.ExecuteNonQuery();
                            DataTable dataTable = new DataTable();
                            OracleDataAdapter oracleDataAdapter = new OracleDataAdapter(command);
                            DataSet dataSet = new DataSet();
                            oracleDataAdapter.Fill(dataSet, "refcursor1", (OracleRefCursor)command.Parameters["refcursor1"].Value);
                            salesListLastYear = dataSet.Tables["refcursor1"].Rows.Cast<DataRow>().Select<DataRow, TargetSalesModel>((Func<DataRow, TargetSalesModel>)(row => new TargetSalesModel()
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
                            })).ToList<TargetSalesModel>().FirstOrDefault<TargetSalesModel>();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error: {0}", (object)ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine((object)ex);
                return new TargetSalesModel();
            }
            return salesListLastYear;
        }

        public List<SalesWiseModel> GetProductWiseSales()
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("select * from MV_PRODUCT_WISE_SALES"));
            List<SalesWiseModel> salesWiseModelList = new List<SalesWiseModel>();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, SalesWiseModel>((Func<DataRow, SalesWiseModel>)(row => new SalesWiseModel()
            {
                PRODUCT_NAME = row["PRODUCT_NAME"].ToString(),
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
                CATEGORY_NAME = row["CATEGORY_NAME"].ToString(),
                PCT_OF_TOTAL_IMS_VALUE = row["PCT_OF_TOTAL_IMS_VALUE"].ToString() != "" ? Convert.ToDouble(row["PCT_OF_TOTAL_IMS_VALUE"].ToString()) : 0.0,
                IMS_VALUE_CORE = row["IMS_VALUE_CORE"].ToString() != "" ? Convert.ToDouble(row["IMS_VALUE_CORE"].ToString()) : 0.0
            })).ToList<SalesWiseModel>();
        }

        public List<SalesWiseModel> GetBrandWiseSales()
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("select * from MV_BRAND_MTD_ACH_GROWTH_TON"));
            List<SalesWiseModel> salesWiseModelList = new List<SalesWiseModel>();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, SalesWiseModel>((Func<DataRow, SalesWiseModel>)(row => new SalesWiseModel()
            {
                BRAND_NAME = row["BRAND_NAME"].ToString(),
                PCT_OF_TOTAL_IMS_VALUE = row["PCT_OF_TOTAL_IMS_VALUE"].ToString() != "" ? Convert.ToDouble(row["PCT_OF_TOTAL_IMS_VALUE"].ToString()) : 0.0,
                IMS_VALUE_CORE = row["IMS_VALUE_CORE"].ToString() != "" ? Convert.ToDouble(row["IMS_VALUE_CORE"].ToString()) : 0.0
            })).ToList<SalesWiseModel>();
        }

        public List<BrandSalesMtd> GetMonthlyBrandSales()
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("select * from MV_BRAND_MTD_ACH_GROWTH_TON"));
            List<BrandSalesMtd> brandSalesMtdList = new List<BrandSalesMtd>();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, BrandSalesMtd>((Func<DataRow, BrandSalesMtd>)(row => new BrandSalesMtd()
            {
                BRAND_NAME = row["BRAND_NAME"].ToString(),
                BRAND_CODE = row["BRAND_CODE"].ToString(),
                CY_MTD_TARGET_WEIGHT = row["CY_MTD_TARGET_WEIGHT"].ToString() != "" ? Convert.ToDouble(row["CY_MTD_TARGET_WEIGHT"].ToString()) : 0.0,
                CY_MTD_WEIGHT = row["CY_MTD_WEIGHT"].ToString() != "" ? Convert.ToDouble(row["CY_MTD_WEIGHT"].ToString()) : 0.0,
                LY_MTD_WET = row["LY_MTD_WET"].ToString() != "" ? Convert.ToDouble(row["LY_MTD_WET"].ToString()) : 0.0,
                ACH = row["ACH"].ToString() != "" ? Convert.ToDouble(row["ACH"].ToString()) : 0.0,
                GROWTH = row["GROWTH"].ToString() != "" ? Convert.ToDouble(row["GROWTH"].ToString()) : 0.0
            })).ToList<BrandSalesMtd>();
        }

        public List<BrandSalesYtd> GetYearlyBrandSales()
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("select * from MV_BRAND_YTD_ACH_GROWTH_TON"));
            List<BrandSalesYtd> brandSalesYtdList = new List<BrandSalesYtd>();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, BrandSalesYtd>((Func<DataRow, BrandSalesYtd>)(row => new BrandSalesYtd()
            {
                BRAND_NAME = row["BRAND_NAME"].ToString(),
                BRAND_CODE = row["BRAND_CODE"].ToString(),
                CY_YTD_TARGET_WEIGHT = row["CY_YTD_TARGET_WEIGHT"].ToString() != "" ? Convert.ToDouble(row["CY_YTD_TARGET_WEIGHT"].ToString()) : 0.0,
                CY_YTD_WEIGHT = row["CY_YTD_WEIGHT"].ToString() != "" ? Convert.ToDouble(row["CY_YTD_WEIGHT"].ToString()) : 0.0,
                LY_YTD_WET = row["LY_YTD_WET"].ToString() != "" ? Convert.ToDouble(row["LY_YTD_WET"].ToString()) : 0.0,
                ACH = row["ACH"].ToString() != "" ? Convert.ToDouble(row["ACH"].ToString()) : 0.0,
                GROWTH = row["GROWTH"].ToString() != "" ? Convert.ToDouble(row["GROWTH"].ToString()) : 0.0
            })).ToList<BrandSalesYtd>();
        }

        public List<CategorySalesMtd> GetMonthlyCategorySales()
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("select * from MV_CATEGORY_MTD_ACH_GROWTH_TON"));
            List<CategorySalesMtd> categorySalesMtdList = new List<CategorySalesMtd>();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, CategorySalesMtd>((Func<DataRow, CategorySalesMtd>)(row => new CategorySalesMtd()
            {
                Category_NAME = row["Category_NAME"].ToString(),
                Category_CODE = row["Category_CODE"].ToString(),
                CY_MTD_TARGET_WEIGHT = row["CY_MTD_TARGET_WEIGHT"].ToString() != "" ? Convert.ToDouble(row["CY_MTD_TARGET_WEIGHT"].ToString()) : 0.0,
                CY_MTD_WEIGHT = row["CY_MTD_WEIGHT"].ToString() != "" ? Convert.ToDouble(row["CY_MTD_WEIGHT"].ToString()) : 0.0,
                LY_MTD_WET = row["LY_MTD_WET"].ToString() != "" ? Convert.ToDouble(row["LY_MTD_WET"].ToString()) : 0.0,
                ACH = row["ACH"].ToString() != "" ? Convert.ToDouble(row["ACH"].ToString()) : 0.0,
                GROWTH = row["GROWTH"].ToString() != "" ? Convert.ToDouble(row["GROWTH"].ToString()) : 0.0
            })).ToList<CategorySalesMtd>();
        }

        public List<CategorySalesYtd> GetYearlyCategorySales()
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("select * from MV_CATEGORY_YTD_ACH_GROWTH_TON"));
            List<CategorySalesYtd> categorySalesYtdList = new List<CategorySalesYtd>();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, CategorySalesYtd>((Func<DataRow, CategorySalesYtd>)(row => new CategorySalesYtd()
            {
                Category_NAME = row["Category_NAME"].ToString(),
                Category_CODE = row["Category_CODE"].ToString(),
                CY_YTD_TARGET_WEIGHT = row["CY_YTD_TARGET_WEIGHT"].ToString() != "" ? Convert.ToDouble(row["CY_YTD_TARGET_WEIGHT"].ToString()) : 0.0,
                CY_YTD_WEIGHT = row["CY_YTD_WEIGHT"].ToString() != "" ? Convert.ToDouble(row["CY_YTD_WEIGHT"].ToString()) : 0.0,
                LY_YTD_WET = row["LY_YTD_WET"].ToString() != "" ? Convert.ToDouble(row["LY_YTD_WET"].ToString()) : 0.0,
                ACH = row["ACH"].ToString() != "" ? Convert.ToDouble(row["ACH"].ToString()) : 0.0,
                GROWTH = row["GROWTH"].ToString() != "" ? Convert.ToDouble(row["GROWTH"].ToString()) : 0.0
            })).ToList<CategorySalesYtd>();
        }

        public List<NationalSalesMtd> GetNationalSalesMtd()
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("select * from MV_NATIONAL_MTD_ACH_GROWTH_TON"));
            List<NationalSalesMtd> nationalSalesMtdList = new List<NationalSalesMtd>();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, NationalSalesMtd>((Func<DataRow, NationalSalesMtd>)(row => new NationalSalesMtd()
            {
                CY_MTD_TARGET_WEIGHT = row["CY_MTD_TARGET_WEIGHT"].ToString() != "" ? Convert.ToDouble(row["CY_MTD_TARGET_WEIGHT"].ToString()) : 0.0,
                CY_MTD_WEIGHT = row["CY_MTD_WEIGHT"].ToString() != "" ? Convert.ToDouble(row["CY_MTD_WEIGHT"].ToString()) : 0.0,
                LY_MTD_WET = row["LY_MTD_WET"].ToString() != "" ? Convert.ToDouble(row["LY_MTD_WET"].ToString()) : 0.0,
                ACH = row["ACH"].ToString() != "" ? Convert.ToDouble(row["ACH"].ToString()) : 0.0,
                GROWTH = row["GROWTH"].ToString() != "" ? Convert.ToDouble(row["GROWTH"].ToString()) : 0.0
            })).ToList<NationalSalesMtd>();
        }

        public List<NationalSalesYtd> GetNationalSalesYtd()
        {
            DataTable dataTable = this._dbHelper.GetDataTable(string.Format("select * from MV_NATIONAL_YTD_ACH_GROWTH_TON"));
            List<NationalSalesYtd> nationalSalesYtdList = new List<NationalSalesYtd>();
            return dataTable.Rows.Cast<DataRow>().Select<DataRow, NationalSalesYtd>((Func<DataRow, NationalSalesYtd>)(row => new NationalSalesYtd()
            {
                CY_YTD_TARGET_WEIGHT = row["CY_YTD_TARGET_WEIGHT"].ToString() != "" ? Convert.ToDouble(row["CY_YTD_TARGET_WEIGHT"].ToString()) : 0.0,
                CY_YTD_WEIGHT = row["CY_YTD_WEIGHT"].ToString() != "" ? Convert.ToDouble(row["CY_YTD_WEIGHT"].ToString()) : 0.0,
                LY_YTD_WET = row["LY_YTD_WET"].ToString() != "" ? Convert.ToDouble(row["LY_YTD_WET"].ToString()) : 0.0,
                ACH = row["ACH"].ToString() != "" ? Convert.ToDouble(row["ACH"].ToString()) : 0.0,
                GROWTH = row["GROWTH"].ToString() != "" ? Convert.ToDouble(row["GROWTH"].ToString()) : 0.0
            })).ToList<NationalSalesYtd>();
        }
    }
}
