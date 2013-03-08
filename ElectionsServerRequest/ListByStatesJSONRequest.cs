using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using ElectionConstants;
using Newtonsoft.Json.Linq;
using ElectionsConnections;

namespace ElectionsServerRequest
{
    public class ListByStatesJSONRequest
    {
        HttpWebRequest request;
        WebResponse response;

        public static List<string> Stateslisted;
        Constants constant = new Constants();
        public void requestStates()
        {
            String urlRequest = ElectionsServerRequest.Resource1.ServerUrl + ElectionsConnections.ElectionConnect.ListStates+ ElectionsConnections.ElectionConnect.API_KEY ;
            request = WebRequest.Create(urlRequest) as HttpWebRequest;
            request.BeginGetResponse(GetStatesResultData, null);     
        }
        private void GetStatesResultData(IAsyncResult result)
        {
            response = request.EndGetResponse(result);
            StreamReader sd = new StreamReader(response.GetResponseStream());
            JsonReader jreader = new JsonTextReader(sd);
            JsonSerializer se = new JsonSerializer();
            Dictionary<string, object> GetState = se.Deserialize<Dictionary<string, object>>(jreader);
            Stateslisted = GettingStatesData(GetState);
            response.Close();
            sd.Close();
            global.my_flag = 1;
        }

        public List<string> GettingStatesData(Dictionary<string, object> GetState)
        {
            Dictionary<string, string> DictMapTpcst = new Dictionary<string, string>();
            foreach (KeyValuePair<string, object> keyValuePair in GetState)
            {
                DictMapTpcst.Add(keyValuePair.Key, keyValuePair.Value.ToString());
            }
            constant.status_code = DictMapTpcst["status_code"];
            constant.status_text = DictMapTpcst["status_text"];
            if (constant.status_code == "200" && constant.status_text == "Success")
            {
                constant.data = DictMapTpcst["data"];
                JArray array = JArray.Parse(constant.data);
                Stateslisted = new List<string>();
                foreach (var stateslst in array)
                {
                    Stateslisted.Add(stateslst.ToString());
                }
            }
            return Stateslisted;
        }        
    }
}
