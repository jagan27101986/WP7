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

namespace LokSabhaAssembly
{
    public partial class ChartTypes : PhoneApplicationPage
    {
        public ChartTypes()
        {
            InitializeComponent();
        }

       

        private void bar_image_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Column2D1.xaml", UriKind.Relative));
        }

        private void bubble_image_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Bubble3D1.xaml", UriKind.Relative));
        }

        private void funnel_image_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Funnel3D2.xaml", UriKind.Relative));
        }
    }
}