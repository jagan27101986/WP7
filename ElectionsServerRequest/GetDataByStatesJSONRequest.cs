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

namespace ElectionsServerRequest
{

    public class GetDataByStatesJSONRequest
    {
        HttpWebRequest request;
        WebResponse response;
        Constants constant = new Constants();
        public static List<DataByState> dataList;

        public void GetDataByStates(string state,string house,string year,int page)
        {
            
            String urlRequest = ElectionsServerRequest.Resource1.ServerUrl + ElectionsConnections.ElectionConnect.GetDataByStates + ElectionsConnections.ElectionConnect.API_KEY+ ElectionsConnections.ElectionConnect.house +house +"&state="+state+"&year="+year+"&page="+page ;
            request = WebRequest.Create(urlRequest) as HttpWebRequest;
            request.BeginGetResponse(GetdataByStates, null);   
        }

        private void GetdataByStates(IAsyncResult result)
        {
            response = request.EndGetResponse(result);
            StreamReader sd = new StreamReader(response.GetResponseStream());
            JsonReader jreader = new JsonTextReader(sd);
            JsonSerializer se = new JsonSerializer();
            Dictionary<string, object> GetdataState = se.Deserialize<Dictionary<string, object>>(jreader);
            dataList = DataStatebyvotes(GetdataState);
            response.Close();
            sd.Close();
            global.my_flag = 1;
        }

        public List<DataByState> DataStatebyvotes(Dictionary<string, object> GetdataState)
        {
            Dictionary<string, string> DictMapTpcst = new Dictionary<string, string>();
            foreach (KeyValuePair<string, object> keyValuePair in GetdataState)
            {
                DictMapTpcst.Add(keyValuePair.Key, keyValuePair.Value.ToString());
            }
            constant.status_code = DictMapTpcst["status_code"];
            constant.status_text = DictMapTpcst["status_text"];

            if (constant.status_code == "200" && constant.status_text == "Success")
            {
                constant.data = DictMapTpcst["data"];
                dataList = (List<DataByState>)Newtonsoft.Json.JsonConvert.DeserializeObject(DictMapTpcst["data"], typeof(List<DataByState>));                
            }
            return dataList;
        }        

    }
}
