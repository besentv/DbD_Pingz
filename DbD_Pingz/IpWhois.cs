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
        public string whoisInfoString { get; private set; } = null;
        public bool isJsonParsed { get; private set; } = false;
        public bool gotWhoisData { get; private set; } = false;
        public bool workDone { get; private set; } = false;
        public Image CountryFlag { get; private set; } = null;
        public string CountryName { get; private set; } = "";

        public IpWhoisInfo ipWhoisInfo;
        private CountryStatsDatabase statsDatabase;

        private const int TimeUntilTimeout = 1000;

        public IpWhois(string ip)
        {
            initIpWhois(ip);
        }

        public IpWhois(string ip, CountryStatsDatabase statsDatabase)
        {
            this.statsDatabase = statsDatabase;
            initIpWhois(ip);
        }

        private void initIpWhois(string ip)
        {
            BackgroundWorker whoisLookupWorker = new BackgroundWorker();
            whoisLookupWorker.DoWork += new DoWorkEventHandler(doWhoisWork);
            whoisLookupWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(whoisDone);
            whoisLookupWorker.RunWorkerAsync(ip);
        }

        private void doWhoisWork(object sender, DoWorkEventArgs e)
        {
            string ip = (string)e.Argument;
            string requestUrl = "http://ipinfo.io/" + ip + "/json";

            whoisInfoString = getWhoisInfo(requestUrl);

            if (gotWhoisData)
            {
                Console.WriteLine("Trying to deserialize JSON");
                ipWhoisInfo = JsonConvert.DeserializeObject<IpWhoisInfo>(whoisInfoString);
                isJsonParsed = true;           
            }
            else
            {
                ipWhoisInfo = new IpWhoisInfo();
                ipWhoisInfo.Country = "_unknown";
            }

            Console.WriteLine("Trying to get country flag for country:" + ipWhoisInfo.Country);
            CountryFlag = CountryIdConverter.ConvertCountryIdToFlagImage(ipWhoisInfo.Country);

            Console.WriteLine("Trying to get country name for country:" + ipWhoisInfo.Country);
            string countryName;
            if (CountryIdConverter.TryGetName(ipWhoisInfo.Country, out countryName))
            {
               CountryName = countryName;
            }
        }

        private string getWhoisInfo(string requestUrl)
        {
            Console.WriteLine("Trying to WHOIS ip on '" + requestUrl + "'");
            WebRequest wr = WebRequest.Create(requestUrl);
            wr.Method = "GET";
            wr.Timeout = TimeUntilTimeout;

            try
            {
                WebResponse response = wr.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string content = reader.ReadToEnd();
                reader.Close();
                response.Close();
                gotWhoisData = true;
                Console.WriteLine("GOT whois data");

                return content;
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.ToString());
                gotWhoisData = false;

                return null;
            }
        }

        private void whoisDone(object sender, RunWorkerCompletedEventArgs e)
        {
            if (statsDatabase != null)
            {
                if (ipWhoisInfo != null)
                {
                    statsDatabase.IncrementCountry(ipWhoisInfo.Country);
                }
            }
            workDone = true;
        }
    }
}
