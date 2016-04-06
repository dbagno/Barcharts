using System;
using System.Collections.Generic;

namespace BarCharts
{
     

    public class BarItem
    {
        public string BarTitle{ get; set; }

        public double BarValue{ get; set; }

        public string BarColor{ get; set; }
    }

    public class BarChart
    {
        public string ChartName{ get; set; }

        public double HundredPercentValue{ get; set; }

        public List<BarItem>Bars{ get; set; }
    }
}

