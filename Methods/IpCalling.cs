using System.Net;
using System.IO;
using Newtonsoft.Json;
using System;
using System.Text;

namespace IpFindIt
{
    class IpCalling
    {
        
        internal static void CustomIpAddress(string IpAddress)
        {
            string IPGeolocationApiUrl;
            IPGeolocationApiUrl = "http://ip-api.com/json/" + IpAddress;
            WebRequest GetJsonApiFeedback;
            GetJsonApiFeedback = WebRequest.Create(IPGeolocationApiUrl);
            Stream ReturnedFeedBack;
            ReturnedFeedBack = GetJsonApiFeedback.GetResponse().GetResponseStream();
            StreamReader objReader = new StreamReader(ReturnedFeedBack);
            string IpGeolocationFeedBack = objReader.ReadToEnd();
            IpGeolocationMapping ipGeolocationMapping = JsonConvert.DeserializeObject<IpGeolocationMapping>(IpGeolocationFeedBack);
            Messages.PromptMessage($"Here are the results for IP-Address:{IpAddress}\n");
            Messages.PromptMessage("Results: \n");
            Messages.PromptMessage($"Country: { ipGeolocationMapping.country}\n" +
                                   $"State: {ipGeolocationMapping.regionName}\n" +
                                   $"City: {ipGeolocationMapping.city}\n" +
                                   $"Zip-Code: {ipGeolocationMapping.zip}\n" +
                                   $"ISP: {ipGeolocationMapping.isp}", ConsoleColor.Magenta);

            string ResolvedIps = String.Format("Country: {0,-20}" +
                                               "State: {1,-20}" +
                                               "City: {2,-20}" +
                                               "Zip-Code: {3,-20}" +
                                               "ISP: {4,-20}", ipGeolocationMapping.country, 
                                                               ipGeolocationMapping.regionName, 
                                                               ipGeolocationMapping.city, 
                                                               ipGeolocationMapping.zip,
                                                               ipGeolocationMapping.isp);

            string UsersPcName = Environment.UserName;
            
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\" + UsersPcName + @"\Desktop\ResolvedIps.txt", true))
            {
                file.WriteLine($"{ResolvedIps}\n");

            }
        }


    
    }

    public class IpGeolocationMapping
    {
        public string status { get; set; }
        public string country { get; set; }
        public string countryCode { get; set; }
        public string region { get; set; }
        public string regionName { get; set; }
        public string city { get; set; }
        public string zip { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public string timezone { get; set; }
        public string isp { get; set; }
        public string org { get; set; }
        public string _as { get; set; }
        public string query { get; set; }
    }

}
