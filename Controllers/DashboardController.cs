using DashboardAPI.Model.BEL;
using DashboardAPI.Model.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DashboardAPI.Controllers
{

    [ApiController]
    public class DashboardController : ControllerBase
    {
        [Authorize(Policy = "AccessPermission")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("dashboard/api/gettodayvalue")]
        public object TodayCartData()
        {
            masterDashboardDal _masterDashboardDAL = new masterDashboardDal();
            TodayDashboardCartModel todayValue = _masterDashboardDAL.GetTodayCartValue(1);
            return new { Status = HttpStatusCode.OK, Data = todayValue };
        }
        [Authorize(Policy = "AccessPermission")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("dashboard/api/getmonthlyvalue")]
        public object MonthlyCartData()
        {
            masterDashboardDal _masterDashboardDAL = new masterDashboardDal();
            MonthlyDashboardCartModel monthlyValue = _masterDashboardDAL.GetMonthlyCartValue(1);
            return new {Satatus=HttpStatusCode.OK,Data = monthlyValue };
        }
        [Authorize(Policy = "AccessPermission")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("dashboard/api/getyearlyvalue")]
        public object YearlyCartData()
        {
            masterDashboardDal _masterDashboardDAL = new masterDashboardDal();
            MonthlyDashboardCartModel yearlyValue = _masterDashboardDAL.GetYearlyCartValue(1);
            return new { Satatus = HttpStatusCode.OK, Data = yearlyValue };
        }

        [Authorize(Policy = "AccessPermission")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("dashboard/api/getpCandlPCvalue")]
        public object GetPCLPCValue()
        {
            masterDashboardDal _masterDashboardDAL = new masterDashboardDal();
            PC_LPCCount pc_lpc_value = _masterDashboardDAL.GetTodayPCCount(1);
            return new { Satatus = HttpStatusCode.OK, Data = pc_lpc_value };
        }

        [Authorize(Policy = "AccessPermission")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("dashboard/api/getimsvalue")]
        public object GetImsValue()
        {
            DailyDataModel model = new DailyDataModel();
            masterDashboardDal _masterDashboardDAL = new masterDashboardDal();
            List<string> xAxisCategoryList = new List<string>();
            int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
            string monthname = DateTime.Now.ToString("MMM");
            int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
    

            int num = DateTime.DaysInMonth(year, month);
            for (int index = 1; index <= num; ++index)
            {
                string str2 = index.ToString() + " " + monthname;
                xAxisCategoryList.Add(str2);
            }
            try
            {
                List<DayWiseModel> imsValue = _masterDashboardDAL.GetIMSValue(1);
                model.status = true;
                model.message = "Day Wise IMS Value";
                Data imsdata = new Data();
                imsdata.currentYear = DateTime.Now.Year.ToString();
                imsdata.lastYear = (DateTime.Now.Year - 1).ToString();
                imsdata.month = month.ToString();
                model.data = imsdata;
                List<GraphData> graph = new List<GraphData>();
                if (imsValue != null)
                {
                    if (imsValue.Count > 1)
                    {

                        graph.Add(new GraphData() { current = imsValue[0].DAY_01, last = imsValue[1].DAY_01 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_02, last = imsValue[1].DAY_02 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_03, last = imsValue[1].DAY_03 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_04 , last = imsValue[1].DAY_04 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_06, last = imsValue[1].DAY_06 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_07, last = imsValue[1].DAY_07 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_08, last = imsValue[1].DAY_08 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_09, last = imsValue[1].DAY_09 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_12, last = imsValue[1].DAY_12 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_11, last = imsValue[1].DAY_11 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_13 , last = imsValue[1].DAY_13 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_14, last = imsValue[1].DAY_14 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_15, last = imsValue[1].DAY_15 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_16, last = imsValue[1].DAY_16 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_17, last = imsValue[1].DAY_17 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_18, last = imsValue[1].DAY_18 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_19 , last = imsValue[1].DAY_19 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_20, last = imsValue[1].DAY_20 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_21 , last = imsValue[1].DAY_21 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_22, last = imsValue[1].DAY_22 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_23, last = imsValue[1].DAY_23 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_24, last = imsValue[1].DAY_24 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_25, last = imsValue[1].DAY_25 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_26, last = imsValue[1].DAY_26 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_27, last = imsValue[1].DAY_27 });
                        graph.Add(new GraphData() { current = imsValue[0].DAY_28, last = imsValue[1].DAY_28 });
                        if (xAxisCategoryList.Count > 28)
                        {
                            graph.Add(new GraphData() { current = imsValue[0].DAY_29, last = imsValue[1].DAY_29 });
                            graph.Add(new GraphData() { current = imsValue[0].DAY_30, last = imsValue[1].DAY_30 });
                            if (xAxisCategoryList.Count > 30)
                            {
                                graph.Add(new GraphData() { current = imsValue[0].DAY_31, last = imsValue[1].DAY_31 });
                            }
                        }
                    }
            
                }

                model.data.graphData = graph;

            }
            catch(Exception ex)
            {

            }


            return new { Data = model };
        }

        [Authorize(Policy = "AccessPermission")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("dashboard/api/getimsvolume")]
        public object GetVolumeTrend()
        {
            DailyDataModel model = new DailyDataModel();
            masterDashboardDal _masterDashboardDAL = new masterDashboardDal();
            List<string> xAxisCategoryList = new List<string>();
            int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
            string monthname = DateTime.Now.ToString("MMM");
            int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));

            int num = DateTime.DaysInMonth(year, month);
            for (int index = 1; index <= num; ++index)
            {
                string str2 = index.ToString() + " " + monthname;
                xAxisCategoryList.Add(str2);
            }

            try
            {
                List<DayWiseModel> imsVolume = _masterDashboardDAL.GetIMSVolumeList(1);
                model.status = true;
                model.message = "Day Wise IMS Value";
                Data imsdata = new Data();
                imsdata.currentYear = DateTime.Now.Year.ToString();
                imsdata.lastYear = (DateTime.Now.Year - 1).ToString();
                imsdata.month = month.ToString();
                model.data = imsdata;
                List<GraphData> graph = new List<GraphData>();
                if (imsVolume != null)
                {
                    if (imsVolume.Count > 1)
                    {

                        graph.Add(new GraphData() { current = imsVolume[0].DAY_01, last = imsVolume[1].DAY_01 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_02, last = imsVolume[1].DAY_02 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_03, last = imsVolume[1].DAY_03 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_04, last = imsVolume[1].DAY_04 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_06, last = imsVolume[1].DAY_06 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_07, last = imsVolume[1].DAY_07 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_08, last = imsVolume[1].DAY_08 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_09, last = imsVolume[1].DAY_09 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_12, last = imsVolume[1].DAY_12 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_11, last = imsVolume[1].DAY_11 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_13, last = imsVolume[1].DAY_13 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_14, last = imsVolume[1].DAY_14 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_15, last = imsVolume[1].DAY_15 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_16, last = imsVolume[1].DAY_16 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_17, last = imsVolume[1].DAY_17 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_18, last = imsVolume[1].DAY_18 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_19, last = imsVolume[1].DAY_19 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_20, last = imsVolume[1].DAY_20 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_21, last = imsVolume[1].DAY_21 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_22, last = imsVolume[1].DAY_22 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_23, last = imsVolume[1].DAY_23 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_24, last = imsVolume[1].DAY_24 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_25, last = imsVolume[1].DAY_25 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_26, last = imsVolume[1].DAY_26 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_27, last = imsVolume[1].DAY_27 });
                        graph.Add(new GraphData() { current = imsVolume[0].DAY_28, last = imsVolume[1].DAY_28 });
                        if (xAxisCategoryList.Count > 28)
                        {
                            graph.Add(new GraphData() { current = imsVolume[0].DAY_29, last = imsVolume[1].DAY_29 });
                            graph.Add(new GraphData() { current = imsVolume[0].DAY_30, last = imsVolume[1].DAY_30 });
                            if (xAxisCategoryList.Count > 30)
                            {
                                graph.Add(new GraphData() { current = imsVolume[0].DAY_31, last = imsVolume[1].DAY_31 });
                            }
                        }
                    }

                }

                model.data.graphData = graph;

            }
            catch (Exception ex)
            {

            }
            return new { Data = model };
        }

        [Authorize(Policy = "AccessPermission")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("dashboard/api/getimsreturnvalue")]
        public object GetImsReturnValue()
        {
            DailyDataModel model = new DailyDataModel();
            masterDashboardDal _masterDashboardDAL = new masterDashboardDal();
            List<string> xAxisCategoryList = new List<string>();
            int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
            string monthname = DateTime.Now.ToString("MMM");
            int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            int num = DateTime.DaysInMonth(year, month);
            for (int index = 1; index <= num; ++index)
            {
                string str2 = index.ToString() + " " + monthname;
                xAxisCategoryList.Add(str2);
            }

            try
            {
                DayWiseModel imsReturn = _masterDashboardDAL.GetIMSReturnPct(1);
                model.status = true;
                model.message = "Day Wise IMS Value";
                Data imsdata = new Data();
                imsdata.currentYear = DateTime.Now.Year.ToString();
                imsdata.lastYear = (DateTime.Now.Year - 1).ToString();
                imsdata.month = month.ToString();
                model.data = imsdata;
                List<GraphData> graph = new List<GraphData>();
                if (imsReturn != null)
                {
                    if (imsReturn != null)
                    {

                        graph.Add(new GraphData() { current = imsReturn.DAY_01});
                        graph.Add(new GraphData() { current = imsReturn.DAY_02 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_03 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_04 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_06 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_07 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_08});
                        graph.Add(new GraphData() { current = imsReturn.DAY_09});
                        graph.Add(new GraphData() { current = imsReturn.DAY_12 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_11 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_13});
                        graph.Add(new GraphData() { current = imsReturn.DAY_14 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_15 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_16 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_17});
                        graph.Add(new GraphData() { current = imsReturn.DAY_18 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_19 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_20 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_21 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_22 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_23});
                        graph.Add(new GraphData() { current = imsReturn.DAY_24 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_25});
                        graph.Add(new GraphData() { current = imsReturn.DAY_26});
                        graph.Add(new GraphData() { current = imsReturn.DAY_27});
                        graph.Add(new GraphData() { current = imsReturn.DAY_28 });
                        if (xAxisCategoryList.Count > 28)
                        {
                            graph.Add(new GraphData() { current = imsReturn.DAY_29});
                            graph.Add(new GraphData() { current = imsReturn.DAY_30});
                            if (xAxisCategoryList.Count > 30)
                            {
                                graph.Add(new GraphData() { current = imsReturn.DAY_31 });
                            }
                        }
                    }

                }

                model.data.graphData = graph;

            }
            catch (Exception ex)
            {

            }

            return new { Data = model };
        }

        [Authorize(Policy = "AccessPermission")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("dashboard/api/getproductivitycall")]
        public object GetProductivityCall()
        {
            DailyDataModel model = new DailyDataModel();
            masterDashboardDal _masterDashboardDAL = new masterDashboardDal();
            List<string> xAxisCategoryList = new List<string>();
            int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
            string monthname = DateTime.Now.ToString("MMM");
            int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            int num = DateTime.DaysInMonth(year, month);
            for (int index = 1; index <= num; ++index)
            {
                string str2 = index.ToString() + " " + monthname;
                xAxisCategoryList.Add(str2);
            }

            string date = year.ToString() + DateTime.Now.ToString("MM");
            try
            {
                DayWiseModel pcTrend = _masterDashboardDAL.GetPCTrend(1, date);
                model.status = true;
                model.message = "Day Wise IMS Value";
                Data imsdata = new Data();
                imsdata.currentYear = DateTime.Now.Year.ToString();
                imsdata.lastYear = (DateTime.Now.Year - 1).ToString();
                imsdata.month = DateTime.Now.ToString("MM");
                model.data = imsdata;
                List<GraphData> graph = new List<GraphData>();
                if (pcTrend != null)
                {
                    if (pcTrend != null)
                    {

                        graph.Add(new GraphData() { current = pcTrend.DAY_01 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_02 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_03 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_04 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_06 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_07 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_08 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_09 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_12 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_11 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_13 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_14 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_15 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_16 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_17 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_18 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_19 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_20 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_21 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_22 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_23 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_24 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_25 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_26 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_27 });
                        graph.Add(new GraphData() { current = pcTrend.DAY_28 });
                        if (xAxisCategoryList.Count > 28)
                        {
                            graph.Add(new GraphData() { current = pcTrend.DAY_29 });
                            graph.Add(new GraphData() { current = pcTrend.DAY_30 });
                            if (xAxisCategoryList.Count > 30)
                            {
                                graph.Add(new GraphData() { current = pcTrend.DAY_31 });
                            }
                        }
                    }

                }

                model.data.graphData = graph;

            }
            catch (Exception ex)
            {

            }
            return new { Data = model };
        }

        [Authorize(Policy = "AccessPermission")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("dashboard/api/getphysicalandtransitstockList")]
        public object GetPhysicalAndTransitStockList()
        {
            DailyDataModel model = new DailyDataModel();
            masterDashboardDal _masterDashboardDAL = new masterDashboardDal();
            List<string> xAxisCategoryList = new List<string>();
            int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
            string monthname = DateTime.Now.ToString("MMM");
            int year = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            string date = year.ToString() + DateTime.Now.ToString("MM");
            int num = DateTime.DaysInMonth(year, month);
            for (int index = 1; index <= num; ++index)
            {
                string str2 = index.ToString() + " " + monthname;
                xAxisCategoryList.Add(str2);
            }

         
            try
            {
                List<DayWiseModel> stockList = _masterDashboardDAL.GetPhysicalAndTransitStockList(1, date);
                model.status = true;
                model.message = "Day Wise IMS Value";
                Data imsdata = new Data();
                imsdata.currentYear = DateTime.Now.Year.ToString();
                imsdata.lastYear = (DateTime.Now.Year - 1).ToString();
                imsdata.month = DateTime.Now.ToString("MM");
                model.data = imsdata;
                List<GraphData> graph = new List<GraphData>();
                if (stockList != null)
                {
                    if (stockList.Count > 1)
                    {

                        graph.Add(new GraphData() { current = stockList[0].DAY_01, last = stockList[1].DAY_01 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_02, last = stockList[1].DAY_02 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_03, last = stockList[1].DAY_03 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_04, last = stockList[1].DAY_04 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_06, last = stockList[1].DAY_06 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_07, last = stockList[1].DAY_07 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_08, last = stockList[1].DAY_08 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_09, last = stockList[1].DAY_09 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_12, last = stockList[1].DAY_12 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_11, last = stockList[1].DAY_11 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_13, last = stockList[1].DAY_13 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_14, last = stockList[1].DAY_14 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_15, last = stockList[1].DAY_15 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_16, last = stockList[1].DAY_16 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_17, last = stockList[1].DAY_17 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_18, last = stockList[1].DAY_18 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_19, last = stockList[1].DAY_19 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_20, last = stockList[1].DAY_20 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_21, last = stockList[1].DAY_21 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_22, last = stockList[1].DAY_22 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_23, last = stockList[1].DAY_23 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_24, last = stockList[1].DAY_24 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_25, last = stockList[1].DAY_25 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_26, last = stockList[1].DAY_26 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_27, last = stockList[1].DAY_27 });
                        graph.Add(new GraphData() { current = stockList[0].DAY_28, last = stockList[1].DAY_28 });
                        if (xAxisCategoryList.Count > 28)
                        {
                            graph.Add(new GraphData() { current = stockList[0].DAY_29, last = stockList[1].DAY_29 });
                            graph.Add(new GraphData() { current = stockList[0].DAY_30, last = stockList[1].DAY_30 });
                            if (xAxisCategoryList.Count > 30)
                            {
                                graph.Add(new GraphData() { current = stockList[0].DAY_31, last = stockList[1].DAY_31 });
                            }
                        }
                    }

                }

                model.data.graphData = graph;

            }
            catch (Exception ex)
            {

            }

            return new { Data = model };
        }

        [Authorize(Policy = "AccessPermission")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("dashboard/api/getfiveyearstargetvssales")]
        public object GetFiveYearsTargetVsSales()
        {
            DailyDataModel model = new DailyDataModel();
            List<LastFiveYearSalesModel> salesList = new List<LastFiveYearSalesModel>();
            masterDashboardDal _masterDashboardDAL = new masterDashboardDal();
            try
            {
               salesList = _masterDashboardDAL.GetfiveYearsSaleTrend();
            }
            catch (Exception ex)
            {

            }
            return new {Status=true, data = salesList };
        }

        [Authorize(Policy = "AccessPermission")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("dashboard/api/getcurrentyeartargetvssales")]
        public object GetCurrentyearTargetVsSales()
        {
            DailyDataModel model = new DailyDataModel();
            TargetSalesModel salesList = new TargetSalesModel();
            masterDashboardDal _masterDashboardDAL = new masterDashboardDal();
            try
            {
                salesList = _masterDashboardDAL.GetTargetSalesList(1,DateTime.Now.Year.ToString());
            }
            catch (Exception ex)
            {

            }
            return new { Status = true, data = salesList };
        }

        [Authorize(Policy = "AccessPermission")]
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Route("dashboard/api/getlastyeartargetvssales")]
        public object GetLastyearTargetVsSales()
        {
            DailyDataModel model = new DailyDataModel();
            TargetSalesModel salesList = new TargetSalesModel();
            masterDashboardDal _masterDashboardDAL = new masterDashboardDal();
            try
            {
                salesList = _masterDashboardDAL.GetTargetSalesListLastYear(1, (DateTime.Now.Year - 1).ToString());
            }
            catch (Exception ex)
            {

            }
            return new { Status = true, data = salesList };
        }

    }
}
