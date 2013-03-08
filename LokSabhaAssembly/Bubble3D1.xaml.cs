using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Visifire.Charts;
using Microsoft.Phone.Shell;
using ElectionsServerRequest;
using ElectionConstants;

namespace Visifire_WP_Samples.Samples.GallerySamples.Bubble_Point
{
    public partial class Bubble3D1 : PhoneApplicationPage
    {
         List<DataByState> getDataList = new List<DataByState>();
        public Bubble3D1()
        {
            InitializeComponent();

             Chart chart = new Chart();

                // Create a new instance of Title
                Title title = new Title();

                // Set title property
                title.Text = "Election Result";

                // Add title to Titles collection
                chart.Titles.Add(title);

                DataPoint dataPoint;
                PhoneApplicationService.Current.State["GetTopEarnerList"] = GetDataByStatesJSONRequest.dataList;
                 getDataList = (List<DataByState>)PhoneApplicationService.Current.State["GetTopEarnerList"];
                    DataSeries dataSeries = new DataSeries(); 

                // Set DataSeries property
                dataSeries.RenderAs = RenderAs.Bubble;
                   for (int i = 0; i < getDataList.Count; i++)
                {
                    // Create a new instance of DataPoint
                    dataPoint = new DataPoint();

                    // Set YValue for a DataPoint
                    dataPoint.YValue = Convert.ToDouble(getDataList[i].votes);

                        dataPoint.AxisXLabel = getDataList[i].party;

                       
                    // Add dataPoint to DataPoints collection.
                    dataSeries.DataPoints.Add(dataPoint);
                }

                // Add dataSeries to Series collection.
                   chart.Series.Add(dataSeries);

                // Add chart to LayoutRoot
                LayoutRoot.Children.Add(chart);
            }
        }
    }
