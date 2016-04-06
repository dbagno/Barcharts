using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading;

namespace BarCharts
{
    public class HomePage:ContentPage
    {
        public HomePage()
        {
           

        }

        protected override void OnAppearing()
        {            
            base.OnAppearing();
            List<BarChart> series = new List<BarChart>();
            var Bars = new List<BarItem>();
           
            var chart = new BarChart
            {
                ChartName = "Year in Review",
                Bars = Bars,
                HundredPercentValue = 100,
                    
            };
            
            Bars.Add(new BarItem
                {
                    BarValue = 10,
                    BarTitle = "January",
                });
            Bars.Add(new BarItem
                {
                    BarTitle = "February",
                    BarValue = 20,
                });
            Bars.Add(new BarItem
                {
                    BarTitle = "March",
                    BarValue = 30,
                });
            Bars.Add(new BarItem
                {
                    BarTitle = "April",
                    BarValue = 40,
                });
            Bars.Add(new BarItem
                {
                    BarTitle = "May",
                    BarValue = 50,
                        
                });
            Bars.Add(new BarItem
                {
                    BarTitle = "June",
                    BarValue = 60,

                });
            Bars.Add(new BarItem
                {
                    BarTitle = "July",
                    BarValue = 70,

                });
            Bars.Add(new BarItem
                {
                    BarTitle = "August",
                    BarValue = 80,

                });
            Bars.Add(new BarItem
                {
                    BarTitle = "September",
                    BarValue = 90,

                });
            Bars.Add(new BarItem
                {
                    BarTitle = "October",
                    BarValue = 100,

                });
            Bars.Add(new BarItem
                {
                    BarTitle = "November",
                    BarValue = 95,

                });
            Bars.Add(new BarItem
                {
                    BarTitle = "December",
                    BarValue = 15,

                });
            series.Add(chart);
            this.Content = new BarChartView(series, this);
        }

       
    }
}

