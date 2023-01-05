namespace DashboardAPI.Model.BEL
{
    public class DashboardModel
    {
        public OrderModel OrderModel { get; set; }

        public SalesModel SalesModel { get; set; }

        public MonthlyTargetModel MonthlyTargetModel { get; set; }

        public YearlyTargetModel YearlyTargetModel { get; set; }

        public MonthlySalesModel MonthlySalesModel { get; set; }

        public YearlySalesModel YearlySalesModel { get; set; }
    }

    public class MtdGrowthStatusDash
    {
        public DateTime REFRESH_DATE { get; set; }

        public double CYM_TARGET_VAL { get; set; }

        public double PYM_IMS_SALES_VAL { get; set; }

        public double CYM_IMS_SALES_VAL { get; set; }

        public double ACH_PCT { get; set; }

        public double GROWTH { get; set; }
    }

    public class YtdGrowthStatusDash
    {
        public DateTime REFRESH_DATE { get; set; }

        public double TARGET_VAL { get; set; }

        public double CY_IMS_SALES_VAL { get; set; }

        public double PY_IMS_SALES_VAL { get; set; }

        public double ACH_PCT { get; set; }

        public double GROWTH { get; set; }
    }
    public class AchLiftingMtdModel
    {
        public bool status { get; set; }

        public string message { get; set; }

        public MonthlyLiftingStatusDash data { get; set; }
    }
    public class MonthlyLiftingStatusDash
    {
        public DateTime REFRESH_DATE { get; set; }

        public double Net_Lifting_TARGET_VALUE { get; set; }

        public double CYM_ACTUAL_LIFTING_VALUE { get; set; }

        public double PYM_ACTUAL_LIFTING_VALUE { get; set; }

        public double ACH_PCT { get; set; }

        public double GROWTH { get; set; }
    }
    public class MonthlySalesModel
    {
        public double SalesValue { get; set; }
    }
    public class MonthlyTargetModel
    {
        public double TargetValue { get; set; }
    }
    public class TodayDashboardCartModel
    {
        public double OrderValue { get; set; }
        public double SalesValue { get; set; }
        public double ScheduledRetailer { get; set; }
        public double TotalRetailer { get; set; }
        public double OrderingRetailer { get; set; }
        public string Date { get; set; }
    }
    public class YearlyLiftingStatusDash
    {
        public DateTime REFRESH_DATE { get; set; }

        public double Net_Lifting_TARGET_VALUE { get; set; }

        public double CY_ACTUAL_LIFTING_VALUE { get; set; }

        public double PY_ACTUAL_LIFTING_VALUE { get; set; }

        public double ACH_PCT { get; set; }

        public double GROWTH { get; set; }
    }
    public class AchLiftingYtdModel
    {
        public bool status { get; set; }

        public string message { get; set; }

        public YearlyLiftingStatusDash data { get; set; }
    }
    public class AchBudgetYtdModel
    {
        public bool status { get; set; }

        public string message { get; set; }

        public YtdGrowthStatusDash data { get; set; }
    }

    public class AchBudgetMtdModel
    {
        public bool status { get; set; }

        public string message { get; set; }

        public MtdGrowthStatusDash data { get; set; }
    }
    public class MonthlyDashboardCartModel
    {
        public double TargetValue { get; set; }
        public double SalesValue { get; set; }
        public double ReturnValue { get; set; }
        public double AchValue { get; set; }
        public double GrowthValue { get; set; }
        public string Month { get; set; }
    }
    public class OrderModel
    {
        public double OrderValue { get; set; }
    }
    public class SalesModel
    {
        public double SalesValue { get; set; }
    }
    public class SalesWiseModel
    {
        public DateTime REFRESH_DATE { get; set; }

        public string PRODUCT_CODE { get; set; }

        public string PRODUCT_NAME { get; set; }

        public string CATEGORY_CODE { get; set; }

        public string CATEGORY_NAME { get; set; }

        public string BRAND_NAME { get; set; }

        public string BRAND_CODE { get; set; }

        public double SALES_VALUE { get; set; }

        public double RETURN_VALUE { get; set; }

        public double IMS_VALUE { get; set; }

        public double PCT_OF_TOTAL_IMS_VALUE { get; set; }

        public double IMS_VALUE_CORE { get; set; }
    }

    public class TargetSalesModel
    {
        public double JAN_TARGET_VAL { get; set; }

        public double JAN_IMS_VAL { get; set; }

        public double JAN_ACH { get; set; }

        public double FEB_TARGET_VAL { get; set; }

        public double FEB_IMS_VAL { get; set; }

        public double FEB_ACH { get; set; }

        public double MAR_TARGET_VAL { get; set; }

        public double MAR_IMS_VAL { get; set; }

        public double MAR_ACH { get; set; }

        public double APR_TARGET_VAL { get; set; }

        public double APR_IMS_VAL { get; set; }

        public double APR_ACH { get; set; }

        public double MAY_TARGET_VAL { get; set; }

        public double MAY_IMS_VAL { get; set; }

        public double MAY_ACH { get; set; }

        public double JUN_TARGET_VAL { get; set; }

        public double JUN_IMS_VAL { get; set; }

        public double JUN_ACH { get; set; }

        public double JUL_TARGET_VAL { get; set; }

        public double JUL_IMS_VAL { get; set; }

        public double JUL_ACH { get; set; }

        public double AUG_TARGET_VAL { get; set; }

        public double AUG_IMS_VAL { get; set; }

        public double AUG_ACH { get; set; }

        public double SEP_TARGET_VAL { get; set; }

        public double SEP_IMS_VAL { get; set; }

        public double SEP_ACH { get; set; }

        public double OCT_TARGET_VAL { get; set; }

        public double OCT_IMS_VAL { get; set; }

        public double OCT_ACH { get; set; }

        public double NOV_TARGET_VAL { get; set; }

        public double NOV_IMS_VAL { get; set; }

        public double NOV_ACH { get; set; }

        public double DEC_TARGET_VAL { get; set; }

        public double DEC_IMS_VAL { get; set; }

        public double DEC_ACH { get; set; }
    }
    public class TargetVsSalesList
    {
        public double TARGET_VAL { get; set; }

        public double IMS_VAL { get; set; }

        public double ACH { get; set; }
    }
    public class RetailerCount
    {
        public double ScheduledRetailer { get; set; }
        public double TotalRetailer { get; set; }
        public double OrderingRetailer { get; set; }
    }
    public class ReturnACHGrowthCount
    {
        public double ReturnedCount { get; set; }
        public double ACHCount { get; set; }
        public double GrowthCount { get; set; }
    }
    public class PC_LPCCount
    {
        public double TodayPCCount { get; set; }
        public double MonthlyPCCount { get; set; }
        public double YearlyPCCount { get; set; }

        public double TodayLPCCount { get; set; }
        public double MonthlyLPCCount { get; set; }
        public double YearlyLPCCount { get; set; }

    }
    public class YearlySalesModel
    {
        public double SalesValue { get; set; }
    }
    public class YearlyTargetModel
    {
        public double TargetValue { get; set; }
    }
    public class DayWiseModel
    {
        public int YYYYMMMM { get; set; }

        public double DAY_01 { get; set; }

        public double DAY_02 { get; set; }

        public double DAY_03 { get; set; }

        public double DAY_04 { get; set; }

        public double DAY_05 { get; set; }

        public double DAY_06 { get; set; }

        public double DAY_07 { get; set; }

        public double DAY_08 { get; set; }

        public double DAY_09 { get; set; }

        public double DAY_10 { get; set; }

        public double DAY_11 { get; set; }

        public double DAY_12 { get; set; }

        public double DAY_13 { get; set; }

        public double DAY_14 { get; set; }

        public double DAY_15 { get; set; }

        public double DAY_16 { get; set; }

        public double DAY_17 { get; set; }

        public double DAY_18 { get; set; }

        public double DAY_19 { get; set; }

        public double DAY_20 { get; set; }

        public double DAY_21 { get; set; }

        public double DAY_22 { get; set; }

        public double DAY_23 { get; set; }

        public double DAY_24 { get; set; }

        public double DAY_25 { get; set; }

        public double DAY_26 { get; set; }

        public double DAY_27 { get; set; }

        public double DAY_28 { get; set; }

        public double DAY_29 { get; set; }

        public double DAY_30 { get; set; }

        public double DAY_31 { get; set; }
    }

    public class LastFiveYearSalesModel
    {
        public string Year { get; set; }

        public double TARGET_VAL { get; set; }

        public double IMS_VAL { get; set; }

        public double ACH { get; set; }
    }
    public class BrandSalesMtd
    {
        public string BRAND_CODE { get; set; }

        public string BRAND_NAME { get; set; }

        public double CY_MTD_TARGET_WEIGHT { get; set; }

        public double CY_MTD_TARGET_VALUE { get; set; }

        public double CY_MTD_WEIGHT { get; set; }

        public double CY_MTD_IMS { get; set; }

        public double LY_MTD_WET { get; set; }

        public double LY_MTD_IMS { get; set; }

        public double ACH { get; set; }

        public double GROWTH { get; set; }
    }
    public class BrandSalesYtd
    {
        public string BRAND_CODE { get; set; }

        public string BRAND_NAME { get; set; }

        public double CY_YTD_TARGET_WEIGHT { get; set; }

        public double CY_YTD_TARGET_VALUE { get; set; }

        public double CY_YTD_WEIGHT { get; set; }

        public double CY_YTD_IMS { get; set; }

        public double LY_YTD_WET { get; set; }

        public double LY_YTD_IMS { get; set; }

        public double ACH { get; set; }

        public double GROWTH { get; set; }
    }
    public class CategorySalesMtd
    {
        public string Category_CODE { get; set; }

        public string Category_NAME { get; set; }

        public double CY_MTD_TARGET_WEIGHT { get; set; }

        public double CY_MTD_TARGET_VALUE { get; set; }

        public double CY_MTD_WEIGHT { get; set; }

        public double CY_MTD_IMS { get; set; }

        public double LY_MTD_WET { get; set; }

        public double LY_MTD_IMS { get; set; }

        public double ACH { get; set; }

        public double GROWTH { get; set; }
    }

    public class CategorySalesYtd
    {
        public string Category_CODE { get; set; }

        public string Category_NAME { get; set; }

        public double CY_YTD_TARGET_WEIGHT { get; set; }

        public double CY_YTD_TARGET_VALUE { get; set; }

        public double CY_YTD_WEIGHT { get; set; }

        public double CY_YTD_IMS { get; set; }

        public double LY_YTD_WET { get; set; }

        public double LY_YTD_IMS { get; set; }

        public double ACH { get; set; }

        public double GROWTH { get; set; }
    }
    public class NationalSalesMtd
    {
        public double CY_MTD_TARGET_WEIGHT { get; set; }

        public double CY_MTD_TARGET_VALUE { get; set; }

        public double CY_MTD_WEIGHT { get; set; }

        public double CY_MTD_IMS { get; set; }

        public double LY_MTD_WET { get; set; }

        public double LY_MTD_IMS { get; set; }

        public double ACH { get; set; }

        public double GROWTH { get; set; }
    }
    public class NationalSalesYtd
    {
        public double CY_YTD_TARGET_WEIGHT { get; set; }

        public double CY_YTD_TARGET_VALUE { get; set; }

        public double CY_YTD_WEIGHT { get; set; }

        public double CY_YTD_IMS { get; set; }

        public double LY_YTD_WET { get; set; }

        public double LY_YTD_IMS { get; set; }

        public double ACH { get; set; }

        public double GROWTH { get; set; }
    }
}
