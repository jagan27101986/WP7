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
using ElectionsServerRequest;
using System.Threading;
using ElectionConstants;
using Microsoft.Phone.Shell;



namespace LokSabhaAssembly
{
    public partial class MainPage : PhoneApplicationPage
    {
        
        public Thread threadrequest;
        ListByStatesJSONRequest StatesRequest = new ListByStatesJSONRequest();
           
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void next_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            threadrequest = new Thread(new ThreadStart(LstStates));
            threadrequest.Start();
            StatesRequest.requestStates();
        }

        public void LstStates()
        {
            while (true)
            {
                if (0 != global.my_flag)
                    break;
                else
                    Dispatcher.BeginInvoke(() =>
                    {
                        loginIndicator.IsVisible = true;
                    });
                Thread.Sleep(5000);
            }
            if (global.my_flag == 1)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    NavigationService.Navigate(new Uri("/States.xaml", UriKind.Relative));
                    loginIndicator.IsVisible = false;
                });
                global.my_flag = 0;
            }
            else
            {

            }

        }
      
    }
}