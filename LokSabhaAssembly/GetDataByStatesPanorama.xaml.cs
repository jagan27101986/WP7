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
using Microsoft.Phone.Shell;
using ElectionsServerRequest;
using ElectionConstants;

namespace LokSabhaAssembly
{
    public partial class GetDataByStatesPanorama : PhoneApplicationPage
    {
        List<DataByState> getDataByState = new List<DataByState>();
        public GetDataByStatesPanorama()
        {
            InitializeComponent();
            PhoneApplicationService.Current.State["GetDataByStates"] = GetDataByStatesJSONRequest.dataList;
            getDataByState = (List<DataByState>)PhoneApplicationService.Current.State["GetDataByStates"];

           for(int i =0;i < getDataByState.Count;i++)
           {
               StatesData.ItemsSource = getDataByState;
           }
        }

        private void bar_chart_click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/ChartTypes.xaml", UriKind.Relative));
        }

        
    }
}