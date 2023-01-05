// Decompiled with JetBrains decompiler
// Type: DashboardAPI.Controllers.DashboardController
// Assembly: DashboardAPI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D6304A5F-607C-40EF-B4AA-478DAE5D9B02
// Assembly location: E:\DashboardCoreApi\DashboardAPI.dll

using DashboardAPI.Model.BEL;
using DashboardAPI.Model.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;


#nullable enable
namespace DashboardAPI.Controllers
{
    [ApiController]
    public class DashboardController : ControllerBase
    {
        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/gettodayvalue")]
        public object TodayCartData() => (object)new
        {
            Status = HttpStatusCode.OK,
            Data = new masterDashboardDal().GetTodayCartValue(1)
        };

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/getmonthlyvalue")]
        public object MonthlyCartData() => (object)new
        {
            Satatus = HttpStatusCode.OK,
            Data = new masterDashboardDal().GetMonthlyCartValue(1)
        };

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/getyearlyvalue")]
        public object YearlyCartData() => (object)new
        {
            Satatus = HttpStatusCode.OK,
            Data = new masterDashboardDal().GetYearlyCartValue(1)
        };

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/getpCandlPCvalue")]
        public object GetPCLPCValue() => (object)new
        {
            Satatus = HttpStatusCode.OK,
            Data = new masterDashboardDal().GetTodayPCCount(1)
        };

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/getimsvalue")]
        public object GetImsValue()
        {
            DailyDataModel dailyDataModel = new DailyDataModel();
            masterDashboardDal masterDashboardDal = new masterDashboardDal();
            List<string> stringList = new List<string>();
            int int32 = Convert.ToInt32(DateTime.Now.ToString("MM"));
            string str1 = DateTime.Now.ToString("MMMM");
            int num1 = DateTime.DaysInMonth(Convert.ToInt32(DateTime.Now.ToString("yyyy")), int32);
            for (int index = 1; index <= num1; ++index)
            {
                string str2 = index.ToString() + " " + str1;
                stringList.Add(str2);
            }
            try
            {
                List<DayWiseModel> imsValue = masterDashboardDal.GetIMSValue(1);
                dailyDataModel.status = true;
                dailyDataModel.message = "Day Wise IMS Value";
                Data data1 = new Data();
                Data data2 = data1;
                int num2 = DateTime.Now.Year;
                string str3 = num2.ToString();
                data2.currentYear = str3;
                Data data3 = data1;
                num2 = DateTime.Now.Year - 1;
                string str4 = num2.ToString();
                data3.lastYear = str4;
                data1.month = str1;
                dailyDataModel.data = data1;
                List<GraphData> graphDataList = new List<GraphData>();
                if (imsValue != null && imsValue.Count > 1)
                {
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_01,
                        last = imsValue[1].DAY_01
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_02,
                        last = imsValue[1].DAY_02
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_03,
                        last = imsValue[1].DAY_03
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_04,
                        last = imsValue[1].DAY_04
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_05,
                        last = imsValue[1].DAY_05
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_06,
                        last = imsValue[1].DAY_06
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_07,
                        last = imsValue[1].DAY_07
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_08,
                        last = imsValue[1].DAY_08
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_09,
                        last = imsValue[1].DAY_09
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_10,
                        last = imsValue[1].DAY_10
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_11,
                        last = imsValue[1].DAY_11
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_12,
                        last = imsValue[1].DAY_12
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_13,
                        last = imsValue[1].DAY_13
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_14,
                        last = imsValue[1].DAY_14
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_15,
                        last = imsValue[1].DAY_15
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_16,
                        last = imsValue[1].DAY_16
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_17,
                        last = imsValue[1].DAY_17
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_18,
                        last = imsValue[1].DAY_18
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_19,
                        last = imsValue[1].DAY_19
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_20,
                        last = imsValue[1].DAY_20
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_21,
                        last = imsValue[1].DAY_21
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_22,
                        last = imsValue[1].DAY_22
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_23,
                        last = imsValue[1].DAY_23
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_24,
                        last = imsValue[1].DAY_24
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_25,
                        last = imsValue[1].DAY_25
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_26,
                        last = imsValue[1].DAY_26
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_27,
                        last = imsValue[1].DAY_27
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsValue[0].DAY_28,
                        last = imsValue[1].DAY_28
                    });
                    if (stringList.Count > 28)
                    {
                        graphDataList.Add(new GraphData()
                        {
                            current = imsValue[0].DAY_29,
                            last = imsValue[1].DAY_29
                        });
                        graphDataList.Add(new GraphData()
                        {
                            current = imsValue[0].DAY_30,
                            last = imsValue[1].DAY_30
                        });
                        if (stringList.Count > 30)
                            graphDataList.Add(new GraphData()
                            {
                                current = imsValue[0].DAY_31,
                                last = imsValue[1].DAY_31
                            });
                    }
                }
                dailyDataModel.data.graphData = graphDataList;
            }
            catch (Exception ex)
            {
            }
            return (object)new { Data = dailyDataModel };
        }

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/getimsvolume")]
        public object GetVolumeTrend()
        {
            DailyDataModel dailyDataModel = new DailyDataModel();
            masterDashboardDal masterDashboardDal = new masterDashboardDal();
            List<string> stringList = new List<string>();
            int int32 = Convert.ToInt32(DateTime.Now.ToString("MM"));
            string str1 = DateTime.Now.ToString("MMMM");
            int num1 = DateTime.DaysInMonth(Convert.ToInt32(DateTime.Now.ToString("yyyy")), int32);
            for (int index = 1; index <= num1; ++index)
            {
                string str2 = index.ToString() + " " + str1;
                stringList.Add(str2);
            }
            try
            {
                List<DayWiseModel> imsVolumeList = masterDashboardDal.GetIMSVolumeList(1);
                dailyDataModel.status = true;
                dailyDataModel.message = "Day Wise IMS Value";
                Data data1 = new Data();
                Data data2 = data1;
                int num2 = DateTime.Now.Year;
                string str3 = num2.ToString();
                data2.currentYear = str3;
                Data data3 = data1;
                num2 = DateTime.Now.Year - 1;
                string str4 = num2.ToString();
                data3.lastYear = str4;
                data1.month = str1;
                dailyDataModel.data = data1;
                List<GraphData> graphDataList = new List<GraphData>();
                if (imsVolumeList != null && imsVolumeList.Count > 1)
                {
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_01,
                        last = imsVolumeList[1].DAY_01
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_02,
                        last = imsVolumeList[1].DAY_02
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_03,
                        last = imsVolumeList[1].DAY_03
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_04,
                        last = imsVolumeList[1].DAY_04
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_05,
                        last = imsVolumeList[1].DAY_05
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_06,
                        last = imsVolumeList[1].DAY_06
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_07,
                        last = imsVolumeList[1].DAY_07
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_08,
                        last = imsVolumeList[1].DAY_08
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_09,
                        last = imsVolumeList[1].DAY_09
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_10,
                        last = imsVolumeList[1].DAY_10
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_11,
                        last = imsVolumeList[1].DAY_11
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_12,
                        last = imsVolumeList[1].DAY_12
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_13,
                        last = imsVolumeList[1].DAY_13
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_14,
                        last = imsVolumeList[1].DAY_14
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_15,
                        last = imsVolumeList[1].DAY_15
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_16,
                        last = imsVolumeList[1].DAY_16
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_17,
                        last = imsVolumeList[1].DAY_17
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_18,
                        last = imsVolumeList[1].DAY_18
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_19,
                        last = imsVolumeList[1].DAY_19
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_20,
                        last = imsVolumeList[1].DAY_20
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_21,
                        last = imsVolumeList[1].DAY_21
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_22,
                        last = imsVolumeList[1].DAY_22
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_23,
                        last = imsVolumeList[1].DAY_23
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_24,
                        last = imsVolumeList[1].DAY_24
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_25,
                        last = imsVolumeList[1].DAY_25
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_26,
                        last = imsVolumeList[1].DAY_26
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_27,
                        last = imsVolumeList[1].DAY_27
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = imsVolumeList[0].DAY_28,
                        last = imsVolumeList[1].DAY_28
                    });
                    if (stringList.Count > 28)
                    {
                        graphDataList.Add(new GraphData()
                        {
                            current = imsVolumeList[0].DAY_29,
                            last = imsVolumeList[1].DAY_29
                        });
                        graphDataList.Add(new GraphData()
                        {
                            current = imsVolumeList[0].DAY_30,
                            last = imsVolumeList[1].DAY_30
                        });
                        if (stringList.Count > 30)
                            graphDataList.Add(new GraphData()
                            {
                                current = imsVolumeList[0].DAY_31,
                                last = imsVolumeList[1].DAY_31
                            });
                    }
                }
                dailyDataModel.data.graphData = graphDataList;
            }
            catch (Exception ex)
            {
            }
            return (object)new { Data = dailyDataModel };
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

                        graph.Add(new GraphData() { current = imsReturn.DAY_01 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_02 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_03 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_04 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_06 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_07 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_08 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_09 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_12 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_11 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_13 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_14 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_15 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_16 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_17 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_18 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_19 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_20 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_21 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_22 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_23 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_24 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_25 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_26 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_27 });
                        graph.Add(new GraphData() { current = imsReturn.DAY_28 });
                        if (xAxisCategoryList.Count > 28)
                        {
                            graph.Add(new GraphData() { current = imsReturn.DAY_29 });
                            graph.Add(new GraphData() { current = imsReturn.DAY_30 });
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
        [HttpGet]
        [Route("dashboard/api/getphysicalandtransitstockList")]
        public object GetPhysicalAndTransitStockList()
        {
            DailyDataModel dailyDataModel = new DailyDataModel();
            masterDashboardDal masterDashboardDal = new masterDashboardDal();
            List<string> stringList = new List<string>();
            int int32_1 = Convert.ToInt32(DateTime.Now.ToString("MM"));
            string str1 = DateTime.Now.ToString("MMMM");
            int int32_2 = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
            string Year = int32_2.ToString() + DateTime.Now.ToString("MM");
            int num = DateTime.DaysInMonth(int32_2, int32_1);
            for (int index = 1; index <= num; ++index)
            {
                string str2 = index.ToString() + " " + str1;
                stringList.Add(str2);
            }
            try
            {
                List<DayWiseModel> transitStockList = masterDashboardDal.GetPhysicalAndTransitStockList(1, Year);
                dailyDataModel.status = true;
                dailyDataModel.message = "Day Wise IMS Value";
                Data data1 = new Data();
                data1.currentYear = DateTime.Now.Year.ToString();
                Data data2 = data1;
                DateTime now = DateTime.Now;
                string str3 = (now.Year - 1).ToString();
                data2.lastYear = str3;
                Data data3 = data1;
                now = DateTime.Now;
                string str4 = now.ToString("MMMM");
                data3.month = str4;
                dailyDataModel.data = data1;
                List<GraphData> graphDataList = new List<GraphData>();
                if (transitStockList != null && transitStockList.Count > 1)
                {
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_01,
                        last = transitStockList[1].DAY_01
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_02,
                        last = transitStockList[1].DAY_02
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_03,
                        last = transitStockList[1].DAY_03
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_04,
                        last = transitStockList[1].DAY_04
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_05,
                        last = transitStockList[1].DAY_05
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_06,
                        last = transitStockList[1].DAY_06
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_07,
                        last = transitStockList[1].DAY_07
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_08,
                        last = transitStockList[1].DAY_08
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_09,
                        last = transitStockList[1].DAY_09
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_10,
                        last = transitStockList[1].DAY_10
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_11,
                        last = transitStockList[1].DAY_11
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_12,
                        last = transitStockList[1].DAY_12
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_13,
                        last = transitStockList[1].DAY_13
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_14,
                        last = transitStockList[1].DAY_14
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_15,
                        last = transitStockList[1].DAY_15
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_16,
                        last = transitStockList[1].DAY_16
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_17,
                        last = transitStockList[1].DAY_17
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_18,
                        last = transitStockList[1].DAY_18
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_19,
                        last = transitStockList[1].DAY_19
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_20,
                        last = transitStockList[1].DAY_20
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_21,
                        last = transitStockList[1].DAY_21
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_22,
                        last = transitStockList[1].DAY_22
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_23,
                        last = transitStockList[1].DAY_23
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_24,
                        last = transitStockList[1].DAY_24
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_25,
                        last = transitStockList[1].DAY_25
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_26,
                        last = transitStockList[1].DAY_26
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_27,
                        last = transitStockList[1].DAY_27
                    });
                    graphDataList.Add(new GraphData()
                    {
                        current = transitStockList[0].DAY_28,
                        last = transitStockList[1].DAY_28
                    });
                    if (stringList.Count > 28)
                    {
                        graphDataList.Add(new GraphData()
                        {
                            current = transitStockList[0].DAY_29,
                            last = transitStockList[1].DAY_29
                        });
                        graphDataList.Add(new GraphData()
                        {
                            current = transitStockList[0].DAY_30,
                            last = transitStockList[1].DAY_30
                        });
                        if (stringList.Count > 30)
                            graphDataList.Add(new GraphData()
                            {
                                current = transitStockList[0].DAY_31,
                                last = transitStockList[1].DAY_31
                            });
                    }
                }
                dailyDataModel.data.graphData = graphDataList;
            }
            catch (Exception ex)
            {
            }
            return (object)new { Data = dailyDataModel };
        }

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/getfiveyearstargetvssales")]
        public object GetFiveYearsTargetVsSales()
        {
            DailyDataModel dailyDataModel = new DailyDataModel();
            List<LastFiveYearSalesModel> fiveYearSalesModelList = new List<LastFiveYearSalesModel>();
            masterDashboardDal masterDashboardDal = new masterDashboardDal();
            try
            {
                fiveYearSalesModelList = masterDashboardDal.GetfiveYearsSaleTrend();
            }
            catch (Exception ex)
            {
            }
            return (object)new
            {
                Status = true,
                data = fiveYearSalesModelList
            };
        }

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/getcurrentyeartargetvssales")]
        public object GetCurrentyearTargetVsSales()
        {
            DailyDataModel dailyDataModel = new DailyDataModel();
            TargetSalesModel targetSalesModel = new TargetSalesModel();
            masterDashboardDal masterDashboardDal = new masterDashboardDal();
            List<TargetVsSalesList> targetVsSalesListList = new List<TargetVsSalesList>();
            try
            {
                TargetSalesModel targetSalesList = masterDashboardDal.GetTargetSalesList(1, DateTime.Now.Year.ToString());
                if (targetSalesList != null)
                {
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = targetSalesList.JAN_TARGET_VAL,
                        IMS_VAL = targetSalesList.JAN_IMS_VAL,
                        ACH = targetSalesList.JAN_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = targetSalesList.FEB_TARGET_VAL,
                        IMS_VAL = targetSalesList.FEB_IMS_VAL,
                        ACH = targetSalesList.FEB_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = targetSalesList.MAR_TARGET_VAL,
                        IMS_VAL = targetSalesList.MAR_IMS_VAL,
                        ACH = targetSalesList.MAR_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = targetSalesList.APR_TARGET_VAL,
                        IMS_VAL = targetSalesList.APR_IMS_VAL,
                        ACH = targetSalesList.APR_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = targetSalesList.MAY_TARGET_VAL,
                        IMS_VAL = targetSalesList.MAY_IMS_VAL,
                        ACH = targetSalesList.MAY_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = targetSalesList.JUN_TARGET_VAL,
                        IMS_VAL = targetSalesList.JUN_IMS_VAL,
                        ACH = targetSalesList.JUN_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = targetSalesList.JUL_TARGET_VAL,
                        IMS_VAL = targetSalesList.JUL_IMS_VAL,
                        ACH = targetSalesList.JUL_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = targetSalesList.AUG_TARGET_VAL,
                        IMS_VAL = targetSalesList.AUG_IMS_VAL,
                        ACH = targetSalesList.AUG_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = targetSalesList.SEP_TARGET_VAL,
                        IMS_VAL = targetSalesList.SEP_IMS_VAL,
                        ACH = targetSalesList.SEP_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = targetSalesList.OCT_TARGET_VAL,
                        IMS_VAL = targetSalesList.OCT_IMS_VAL,
                        ACH = targetSalesList.OCT_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = targetSalesList.NOV_TARGET_VAL,
                        IMS_VAL = targetSalesList.NOV_IMS_VAL,
                        ACH = targetSalesList.NOV_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = targetSalesList.DEC_TARGET_VAL,
                        IMS_VAL = targetSalesList.DEC_IMS_VAL,
                        ACH = targetSalesList.DEC_ACH
                    });
                }
            }
            catch (Exception ex)
            {
            }
            return (object)new
            {
                Status = true,
                data = targetVsSalesListList
            };
        }

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/getlastyeartargetvssales")]
        public object GetLastyearTargetVsSales()
        {
            DailyDataModel dailyDataModel = new DailyDataModel();
            TargetSalesModel targetSalesModel = new TargetSalesModel();
            masterDashboardDal masterDashboardDal = new masterDashboardDal();
            List<TargetVsSalesList> targetVsSalesListList = new List<TargetVsSalesList>();
            try
            {
                TargetSalesModel salesListLastYear = masterDashboardDal.GetTargetSalesListLastYear(1, (DateTime.Now.Year - 1).ToString());
                if (salesListLastYear != null)
                {
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = salesListLastYear.JAN_TARGET_VAL,
                        IMS_VAL = salesListLastYear.JAN_IMS_VAL,
                        ACH = salesListLastYear.JAN_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = salesListLastYear.FEB_TARGET_VAL,
                        IMS_VAL = salesListLastYear.FEB_IMS_VAL,
                        ACH = salesListLastYear.FEB_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = salesListLastYear.MAR_TARGET_VAL,
                        IMS_VAL = salesListLastYear.MAR_IMS_VAL,
                        ACH = salesListLastYear.MAR_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = salesListLastYear.APR_TARGET_VAL,
                        IMS_VAL = salesListLastYear.APR_IMS_VAL,
                        ACH = salesListLastYear.APR_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = salesListLastYear.MAY_TARGET_VAL,
                        IMS_VAL = salesListLastYear.MAY_IMS_VAL,
                        ACH = salesListLastYear.MAY_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = salesListLastYear.JUN_TARGET_VAL,
                        IMS_VAL = salesListLastYear.JUN_IMS_VAL,
                        ACH = salesListLastYear.JUN_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = salesListLastYear.JUL_TARGET_VAL,
                        IMS_VAL = salesListLastYear.JUL_IMS_VAL,
                        ACH = salesListLastYear.JUL_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = salesListLastYear.AUG_TARGET_VAL,
                        IMS_VAL = salesListLastYear.AUG_IMS_VAL,
                        ACH = salesListLastYear.AUG_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = salesListLastYear.SEP_TARGET_VAL,
                        IMS_VAL = salesListLastYear.SEP_IMS_VAL,
                        ACH = salesListLastYear.SEP_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = salesListLastYear.OCT_TARGET_VAL,
                        IMS_VAL = salesListLastYear.OCT_IMS_VAL,
                        ACH = salesListLastYear.OCT_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = salesListLastYear.NOV_TARGET_VAL,
                        IMS_VAL = salesListLastYear.NOV_IMS_VAL,
                        ACH = salesListLastYear.NOV_ACH
                    });
                    targetVsSalesListList.Add(new TargetVsSalesList()
                    {
                        TARGET_VAL = salesListLastYear.DEC_TARGET_VAL,
                        IMS_VAL = salesListLastYear.DEC_IMS_VAL,
                        ACH = salesListLastYear.DEC_ACH
                    });
                }
            }
            catch (Exception ex)
            {
            }
            return (object)new
            {
                Status = true,
                data = targetVsSalesListList
            };
        }

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/getbrandwisesales")]
        public object GetBrandWiseSales()
        {
            DailyDataModel dailyDataModel = new DailyDataModel();
            List<SalesWiseModel> salesWiseModelList = new List<SalesWiseModel>();
            masterDashboardDal masterDashboardDal = new masterDashboardDal();
            try
            {
                salesWiseModelList = masterDashboardDal.GetBrandWiseSales();
            }
            catch (Exception ex)
            {
            }
            return (object)new
            {
                Status = true,
                data = salesWiseModelList
            };
        }

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/getcategorywisesales")]
        public object GetCategoryWiseSales()
        {
            DailyDataModel dailyDataModel = new DailyDataModel();
            List<SalesWiseModel> salesWiseModelList = new List<SalesWiseModel>();
            masterDashboardDal masterDashboardDal = new masterDashboardDal();
            try
            {
                salesWiseModelList = masterDashboardDal.GetCategoryWiseSales();
            }
            catch (Exception ex)
            {
            }
            return (object)new
            {
                Status = true,
                data = salesWiseModelList
            };
        }

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/getproductwisesales")]
        public object GetproductWiseSales()
        {
            DailyDataModel dailyDataModel = new DailyDataModel();
            List<SalesWiseModel> salesWiseModelList = new List<SalesWiseModel>();
            masterDashboardDal masterDashboardDal = new masterDashboardDal();
            try
            {
                salesWiseModelList = masterDashboardDal.GetProductWiseSales();
            }
            catch (Exception ex)
            {
            }
            return (object)new
            {
                Status = true,
                data = salesWiseModelList
            };
        }

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/MonthlyBrandSalesPartial")]
        public object MonthlyBrandSalesPartial() => (object)new
        {
            Status = true,
            data = new masterDashboardDal().GetMonthlyBrandSales()
        };

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/YearlyBrandSalesPartial")]
        public object YearlyBrandSalesPartial() => (object)new
        {
            Status = true,
            data = new masterDashboardDal().GetYearlyBrandSales()
        };

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/MonthlyCategorySalesPartial")]
        public object MonthlyCategorySalesPartial() => (object)new
        {
            Status = true,
            data = new masterDashboardDal().GetMonthlyCategorySales()
        };

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/YearlyCategorySalesPartial")]
        public object YearlyCategorySalesPartial() => (object)new
        {
            Status = true,
            data = new masterDashboardDal().GetYearlyCategorySales()
        };

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/MonthlyNationalSalesPartial")]
        public object MonthlyNationalSalesPartial() => (object)new
        {
            Status = true,
            data = new masterDashboardDal().GetNationalSalesMtd()
        };

        [Authorize(Policy = "AccessPermission")]
        [HttpGet]
        [Route("dashboard/api/YearlyNationalSalesPartial")]
        public object YearlyNationalSalesPartial() => (object)new
        {
            Status = true,
            data = new masterDashboardDal().GetNationalSalesYtd()
        };
    }
}
