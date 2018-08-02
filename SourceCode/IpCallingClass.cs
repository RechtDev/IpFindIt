using System.Net;
using System.IO;
using Newtonsoft.Json;
using System;



namespace IpFindIt
{
    class IpCalling
    { 
        internal static void ResolveIp(string IpAddress)
        {
            string IPGeolocationApiUrl;
            IPGeolocationApiUrl = "http://ip-api.com/json/" + IpAddress;
            // Tantalizes C# version of GET request
            WebRequest GetJsonApiFeedback;
            // Makes GET request 
            GetJsonApiFeedback = WebRequest.Create(IPGeolocationApiUrl);
            // Internalizes Stream object
            Stream ReturnedFeedBack;
            ReturnedFeedBack = GetJsonApiFeedback.GetResponse().GetResponseStream();
            // Reads the ReturnedFeedBack and stores it in ObjReader 
            StreamReader objReader = new StreamReader(ReturnedFeedBack);
            string IpGeolocationFeedBack = objReader.ReadToEnd();
            // Deserializing Json into C# class property's
            IpGeolocationMapping ipGeolocationMapping = JsonConvert.DeserializeObject<IpGeolocationMapping>(IpGeolocationFeedBack);
            // Prints results of Resolved Ip to screen
            Messages.PromptMessage($"Here are the results for IP-Address: {IpAddress}\n");
            Messages.PromptMessage("Results: \n");
            Messages.PromptMessage($"Country: { ipGeolocationMapping.country}\n" +
                                   $"State: {ipGeolocationMapping.regionName}\n" +
                                   $"City: {ipGeolocationMapping.city}\n" +
                                   $"Zip-Code: {ipGeolocationMapping.zip}\n" +
                                   $"ISP: {ipGeolocationMapping.isp}", ConsoleColor.Magenta);
            // Formats Results so it can be layed out in a .txt file a certain way  
            string ResolvedIps = String.Format("Country: {0,-20}" +
                                               "State: {1,-20}" +
                                               "City: {2,-20}" +
                                               "Zip-Code: {3,-20}" +
                                               "ISP: {4,-20}", ipGeolocationMapping.country, 
                                                               ipGeolocationMapping.regionName, 
                                                               ipGeolocationMapping.city, 
                                                               ipGeolocationMapping.zip,
                                                               ipGeolocationMapping.isp);
            //Writes Results to file on users Desktop
            string UsersPcName = Environment.UserName;
            
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\" + UsersPcName + @"\Desktop\ResolvedIps.txt", true))
            {
                file.WriteLine($" IP Address: {ipGeolocationMapping.query} {Environment.NewLine} {ResolvedIps} {Environment.NewLine}");

            }
        }

        internal static void ResolveIp(string IpAddress, char flag)
        {
            switch (flag)
            {
                case 'f':
                    {
                        string IPGeolocationApiUrl;
                        IPGeolocationApiUrl = "http://ip-api.com/json/" + IpAddress;
                        // Tantalizes C# version of GET request
                        WebRequest GetJsonApiFeedback;
                        // Makes GET request 
                        GetJsonApiFeedback = WebRequest.Create(IPGeolocationApiUrl);
                        // Internalizes Stream object
                        Stream ReturnedFeedBack;
                        ReturnedFeedBack = GetJsonApiFeedback.GetResponse().GetResponseStream();
                        // Reads the ReturnedFeedBack and stores it in ObjReader 
                        StreamReader objReader = new StreamReader(ReturnedFeedBack);
                        string IpGeolocationFeedBack = objReader.ReadToEnd();
                        // Deserializing Json into C# class property's
                        IpGeolocationMapping ipGeolocationMapping = JsonConvert.DeserializeObject<IpGeolocationMapping>(IpGeolocationFeedBack);
                        // Prints results of Resolved Ip to screen
                        Messages.PromptMessage($"Here are the results for IP-Address: {IpAddress}\n");
                        Messages.PromptMessage("Results: \n");
                        Messages.PromptMessage($"Country: { ipGeolocationMapping.country}\n" +
                                               $"State: {ipGeolocationMapping.regionName}\n" +
                                               $"City: {ipGeolocationMapping.city}\n" +
                                               $"Zip-Code: {ipGeolocationMapping.zip}\n" +
                                               $"ISP: {ipGeolocationMapping.isp}\n" +
                                               $"Latitude: {ipGeolocationMapping.lat}\n" +
                                               $"Longitude: {ipGeolocationMapping.lon}\n" +
                                               $"Timezone: {ipGeolocationMapping.timezone}\n" +
                                               $"Organization: {ipGeolocationMapping.org}\n", ConsoleColor.Magenta);
                        
                        break;
                    }
                default:
                    break;
            }

        }






    }
    // Auto generated class to match JSON feedback
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
