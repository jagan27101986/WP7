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
using System.Threading;
using ElectionsServerRequest;
using ElectionConstants;
using Microsoft.Phone.Controls.Maps;
using Microsoft.Phone.Shell;

namespace LokSabhaAssembly
{
    public partial class States : PhoneApplicationPage
    {
        string year = null;
        string house = null;
        GetDataByStatesJSONRequest getReq = new GetDataByStatesJSONRequest();
        

        public Thread threadrequest;
        int page = 1;

        public States()
        {
            InitializeComponent();
            checkState();
            year = "2011";
            house = "Assembly";

        }

        public void checkState()
        {
            List<Pushpin> checkList = new List<Pushpin>();
            checkList.Add(Maharastra);
            checkList.Add(Karnataka);
            checkList.Add(jamua_kashmir);
            checkList.Add(goa);
            checkList.Add(kerala);
            checkList.Add(tamilnadu);
            checkList.Add(puducherry);
            checkList.Add(andhrapradesh);
            checkList.Add(orissa);
            checkList.Add(chatigardh);
            checkList.Add(madhyapradesh);
            checkList.Add(gujarat);
            checkList.Add(rajasthan);
            checkList.Add(westbengal);
            checkList.Add(bihar);
            checkList.Add(jharkand);
            checkList.Add(uttarpradesh);
            checkList.Add(misoram);
            checkList.Add(tripura);
            checkList.Add(manipur);
            checkList.Add(assam);
            checkList.Add(arunachalpradesh);
            checkList.Add(meghalaya);
            checkList.Add(sikkim);
            checkList.Add(himachalpradesh);
            checkList.Add(punjab);
            checkList.Add(uttarakand);
            checkList.Add(haryana);
            checkList.Add(delhi);
            checkList.Add(nagaland);

            for (int i = 0; i < ListByStatesJSONRequest.Stateslisted.Count; i++)
            {
                for (int j = 0; j < checkList.Count; j++)
                {
                    if (ListByStatesJSONRequest.Stateslisted[i] == checkList[j].Content.ToString().ToLower())
                    {
                        checkList[j].Visibility = System.Windows.Visibility.Visible;  

                                                             
                    }
                }
            }

        }

        public void resultDetails(string state)
        {
            LayoutRoot.IsHitTestVisible = false;
            threadrequest = new Thread(new ThreadStart(GetDatabyStates));
            threadrequest.Start();
            getReq.GetDataByStates(state,house,year,page);
        }

        public void GetDatabyStates()
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
                    if (GetDataByStatesJSONRequest.dataList.Count == 0)
                    {
                        loginIndicator.IsVisible = false;
                        MessageBox.Show("No Records avaiable");
                        LayoutRoot.IsHitTestVisible = true;
                    }
                    else
                    {
                        NavigationService.Navigate(new Uri("/GetDataByStatesPanorama.xaml", UriKind.Relative));
                        loginIndicator.IsVisible = false;
                        LayoutRoot.IsHitTestVisible = true;
                        
                    }
                });
                global.my_flag = 0;
            }
            else
            {

            }

        }

        private void maharastra_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
          // Maharastra.Content = "Maharastra";

           resultDetails(Maharastra.Content.ToString());
        }

        private void karnataka_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
           // Karnataka.Content = "Karnataka";
            resultDetails(Karnataka.Content.ToString());
        }

        private void kerala_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //kerala.Content = "Kerala";
            resultDetails(kerala.Content.ToString());
        }

        private void tamilnadu_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //tamilnadu.Content = "Tamil Nadu";
            resultDetails(tamilnadu.Content.ToString());
        }

        private void andhrapradesh_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //andhrapradesh.Content = "Andhra Pradesh";
            resultDetails(andhrapradesh.Content.ToString());
        }

        private void orissa_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //orissa.Content = "Orissa";
            resultDetails(orissa.Content.ToString());
        }

        private void chatigardh_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //chatigardh.Content = "Chhattisgarh";
            resultDetails(chatigardh.Content.ToString());
        }

        private void madhyapradesh_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //madhyapradesh.Content = "Madhya Pradesh";
            resultDetails(madhyapradesh.Content.ToString());
        }

        private void gujarat_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //gujarat.Content = "Gujarat";
            resultDetails(gujarat.Content.ToString());
        }

        private void rajasthan_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //rajasthan.Content = "Rajasthan";
            resultDetails(rajasthan.Content.ToString());
        }

        private void westbengal_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //westbengal.Content = "West Bengal";
            resultDetails(westbengal.Content.ToString());
        }

        private void bihar_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //bihar.Content = "Bihar";
            resultDetails(bihar.Content.ToString());
        }

        private void jharkand_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //jharkand.Content = "Jharkhand";
            resultDetails(jharkand.Content.ToString());
        }

        private void uttarpradesh_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //uttarpradesh.Content = "Uttar Pradesh";
            resultDetails(uttarpradesh.Content.ToString());
        }

        private void misoram_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //misoram.Content = "Mizoram";
            resultDetails(misoram.Content.ToString());
        }

        private void tripura_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //tripura.Content = "Tripura";
            resultDetails(tripura.Content.ToString());
        }

        private void manipur_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //manipur.Content = "Manipur";
            resultDetails(manipur.Content.ToString());
        }

        private void assam_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //assam.Content = "Assam";
            resultDetails(assam.Content.ToString());
        }

        private void arunachalpradesh_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //arunachalpradesh.Content = "Arunachal Pradesh";
            resultDetails(arunachalpradesh.Content.ToString());
        }

        private void meghalaya_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //meghalaya.Content = "Meghalaya";
            resultDetails(meghalaya.Content.ToString());
        }

        private void sikkim_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //sikkim.Content = "Sikkim";
            resultDetails(sikkim.Content.ToString());
        }

        private void jamua_kashmir_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //jamua_kashmir.Content = "Jamu and Kashmir";
            resultDetails(jamua_kashmir.Content.ToString());
        }

        private void himachalpradesh_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //himachalpradesh.Content = "Himachal Pradesh";
            resultDetails(himachalpradesh.Content.ToString());
        }

        private void punjab_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //punjab.Content = "Punjab";
            resultDetails(punjab.Content.ToString());
        }

        private void uttarakand_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //uttarakand.Content = "Uttarakand";
            resultDetails(uttarakand.Content.ToString());
        }

        private void haryana_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //haryana.Content = "Haryana";
            resultDetails(haryana.Content.ToString());
        }

        private void delhi_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
           //delhi.Content = "Delhi";
            resultDetails(delhi.Content.ToString());
        }

        private void nagaland_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //nagaland.Content = "Nagaland";
            resultDetails(nagaland.Content.ToString());
        }

        private void goa_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //goa.Content = "Goa";
            resultDetails(goa.Content.ToString());
        }

        private void puducherry_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //puducherry.Content = "Puducherry";
            resultDetails(puducherry.Content.ToString());
        }

        private void yearType_Click(object sender, RoutedEventArgs e)
        {
            if (yearType.IsChecked == true)
            {
                yearType.Content = "Year 2012";
                year = "2012";
            }
            else
            {
                yearType.Content = "Year 2011";
                year = "2011";
            }
        }

        private void houseType_Click(object sender, RoutedEventArgs e)
        {
            if (houseType.IsChecked == true)
            {
                houseType.Content = "Lok Sabha";
                house = "Lok Sabha";
            }
            else
            {
                houseType.Content = "Assembly";
                house = "Assembly";
            }
        }
     

     
    }
}