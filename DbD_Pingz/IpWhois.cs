using System.ComponentModel;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using System.Drawing;
using System;
using System.Reflection;

namespace DbD_Pingz
{
    class IpWhoisInfo
    {
        public string Ip { get; set; }
        public string Hostname { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Loc { get; set; }
        public string Org { get; set; }
    }

    class IpWhois
    {
        public string whoisInfoString { get; private set; }
        public bool isJsonParsed { get; private set; } = false;
        public Image CountryFlag { get; private set; } = null;
        public string CountryName { get; private set; } = "";
        public IpWhoisInfo ipWhoisInfo;


        public IpWhois(string ip)
        {
            BackgroundWorker whoisLookupWorker = new BackgroundWorker();
            whoisLookupWorker.DoWork += new DoWorkEventHandler(initializeObject);
            whoisLookupWorker.RunWorkerAsync(ip);

        }

        private void initializeObject(object sender, DoWorkEventArgs e)
        {
            string ip = (string)e.Argument;
            string requestUrl = "http://ipinfo.io/" + ip + "/json";
            whoisInfoString = getWhoisInfo(requestUrl);
            Console.WriteLine("Trying to deserialize JSON");
            ipWhoisInfo = JsonConvert.DeserializeObject<IpWhoisInfo>(whoisInfoString);
            Console.WriteLine("Trying to get country flag for country:" + ipWhoisInfo.Country);
            CountryFlag = CountryIdConverter.ConvertCountryIdToFlagImage(ipWhoisInfo.Country);
            Console.WriteLine("Trying to get country name for country:" + ipWhoisInfo.Country);
            string countryName;
            if (CountryIdConverter.TryGetName(ipWhoisInfo.Country, out countryName))
            {
                CountryName = countryName;
            }
            Console.WriteLine("GOT whois info");
            isJsonParsed = true;
        }

        private string getWhoisInfo(string requestUrl)
        {
            WebRequest wr = WebRequest.Create(requestUrl);
            wr.Method = "GET";
            WebResponse response = wr.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();
            reader.Close();
            response.Close();
            return content;
        }
    }
}
