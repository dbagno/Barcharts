using System;
using Xamarin.Forms;

using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace BarCharts
{
    public class BarChartView:StackLayout
    {
       
        public class ChartView:AbsoluteLayout
        {
            public int RowHeight = 20;
            public double GridWidth = 0;
            public double GridHeight = 0;
            public int Columns = 5;
            public int Rows = 0;
            public double ColumnWidth = 0;
            public int CurrentRow = 0;
            private List<BarChart> _series;
            public double Unit = 0;

            public void Hline(int row)
            {
                this.Children.Add(new BoxView{ HeightRequest = .5, WidthRequest = GridWidth, BackgroundColor = Color.Gray.WithLuminosity(.9) }, new Rectangle(0, row * RowHeight, GridWidth, .5), AbsoluteLayoutFlags.None);
                string legend = String.Empty;
                if (row < Rows)
                {
                    if (row > 0)
                    {
                        legend = _series[0].Bars[row - 1].BarTitle;
                    }
                    else
                    {
                        legend = "0";
                    }
                    this.Children.Add(new Label
                        { 
                            Text = legend, 
                            HorizontalTextAlignment = TextAlignment.End, 
                            VerticalTextAlignment = TextAlignment.Center, 
                            WidthRequest = ColumnWidth - 2,
                            HeightRequest = RowHeight,
                            FontSize = 12,
                            TextColor = Color.Gray.WithLuminosity(.4),
                            LineBreakMode = LineBreakMode.TailTruncation,
                        }, new Rectangle(0, row * RowHeight, ColumnWidth - 2, RowHeight), AbsoluteLayoutFlags.None);     


                    CurrentRow = row;
                }
            }

            public void Vline(int column)
            {
                this.Children.Add(new BoxView{ HeightRequest = GridHeight, WidthRequest = .5, BackgroundColor = Color.Gray.WithLuminosity(.9) }, new Rectangle(ColumnWidth * column, 0, .5, GridHeight), AbsoluteLayoutFlags.None);
                if (column > 1)
                {


                }
            }

            public ChartView(List<BarChart> series, ContentPage parentPage)
            {
                _series = series;
                this.Padding = 0;
                this.BackgroundColor = Color.White;

                this.GridWidth = (parentPage.Width - parentPage.Padding.HorizontalThickness) - 2;
                this.Rows = series[0].Bars.Count + 1;
                this.GridHeight = this.Rows * RowHeight;
                this.WidthRequest = this.GridWidth;
                this.HeightRequest = this.HeightRequest;


                ColumnWidth = GridWidth / Columns;
                this.Unit = (GridWidth - ColumnWidth) / series[0].HundredPercentValue;
                for (int i = 0; i < Rows + 1; i++)
                {
                    Hline(i);
                }

                for (int i = 0; i < Columns + 1; i++)
                {
                    Vline(i);
                    if (i > 0 && i < Columns)
                    {
                        var header = ((series[0].HundredPercentValue / 4) * i).ToString();
                        this.Children.Add(new Label
                            {
                                Text = header,
                                HorizontalTextAlignment = TextAlignment.End,
                                VerticalTextAlignment = TextAlignment.Center,
                                HeightRequest = RowHeight,
                                WidthRequest = ColumnWidth,
                                FontSize = 12,
                                TextColor = Color.Gray.WithLuminosity(.4),
                            }, new Rectangle(ColumnWidth * i, 0, ColumnWidth, RowHeight), AbsoluteLayoutFlags.None);
                    }

                }
                for (int i = 0; i < series[0].Bars.Count; i++)
                {
                    var bar = new StackLayout
                    {
                        HeightRequest = RowHeight - 2,
                        BackgroundColor = Color.Pink,
                        Opacity = .5,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        WidthRequest = _series[0].Bars[i].BarValue * Unit,

                    };
                    var label = new Label
                    {
                        HeightRequest = RowHeight - 2,
                        BackgroundColor = Color.Transparent,

                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.End,
                        FontSize = 12,
                        WidthRequest = (_series[0].Bars[i].BarValue * Unit) - 2,
                        Text = _series[0].Bars[i].BarValue.ToString(),
                        LineBreakMode = LineBreakMode.TailTruncation,

                    };

                    this.Children.Add(bar, new Rectangle(ColumnWidth, ((i + 1) * RowHeight) + 1, bar.WidthRequest, RowHeight - 2), AbsoluteLayoutFlags.None);
                    this.Children.Add(label, new Rectangle(ColumnWidth, ((i + 1) * RowHeight) + 1, label.WidthRequest, RowHeight - 2), AbsoluteLayoutFlags.None);
                }
            }
        }

        public BarChartView(List<BarChart> series, ContentPage parentPage)
        {
            this.BackgroundColor = Color.White;
            this.Spacing = 1;
            this.Padding = 1;
            this.Children.Add(new Label
                {
                    Text = series[0].ChartName,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.Start,
                    HeightRequest = 20,
                    VerticalTextAlignment = TextAlignment.Start,
                    BackgroundColor = Color.Gray.WithLuminosity(.8),


                });
            this.Children.Add(new ChartView(series, parentPage));
        }


         
    }

    
}

