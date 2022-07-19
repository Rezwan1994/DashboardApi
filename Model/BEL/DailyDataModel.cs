namespace DashboardAPI.Model.BEL
{  
    public class Data
    {
        public string month { get; set; }
        public string currentYear { get; set; }
        public string lastYear { get; set; }
        public List<GraphData> graphData { get; set; }
    }

    public class GraphData
    {
        public double current { get; set; }
        public double last { get; set; }
    }

    public class DailyDataModel
    {
        public bool status { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
}
