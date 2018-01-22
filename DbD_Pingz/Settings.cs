using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System;

namespace DbD_Pingz
{
    public class Settings
    {
        [XmlElement("MaximumGoodPing")]
        public int MaximumGoodPing { get; set; }
        [XmlIgnore]
        public Color GoodPingColor { get { return ColorTranslator.FromHtml(GoodPingColorHtml); } private set { } }
        [XmlIgnore]
        public Color BadPingColor { get { return ColorTranslator.FromHtml(BadPingColorHtml); } private set { } }
        [XmlElement("BoodPingColorHtml")]
        public string GoodPingColorHtml { get; set; }
        [XmlElement("BadPingColorHtml")]
        public string BadPingColorHtml { get; set; }
        [XmlElement("SecondsUntilIPTimeout")]
        public int SecondsUntilIPTimeout { get; set; }
        [XmlElement("MainWindowSplitter1Distance")]
        public int MainWindowSplitter1Distance { get; set; }
        [XmlElement("MainWindowSplitter2Distance")]
        public int MainWindowSplitter2Distance { get; set; }
        [XmlElement("DbDPingzIsTopmost")]
        public bool DbDPingzIsTopmost { get; set; }
        [XmlElement("PingInfoChartScale")]
        public int PingInfoChartScale { get; set; }
        [XmlElement("PingInfoFormSize")]
        public Size PingInfoFormSize { get; set; }
        [XmlElement("NetworkAdapterId")]
        public string NetworkAdapterId { get; set; }
        [XmlElement("SecondsUntilTimeoutRemoved")]
        public int SecondsUntilTimeoutedIpRemoved { get; set; }

        public Settings()
        {
            MaximumGoodPing = 90;
            SetBadPingColor(Color.Red);
            SetGoodPingColor(Color.LightGreen);
            SecondsUntilIPTimeout = 5;
            MainWindowSplitter1Distance = 140;
            MainWindowSplitter2Distance = 280;
            DbDPingzIsTopmost = false;
            PingInfoChartScale = 250;
            PingInfoFormSize = new Size(830,570);
            SecondsUntilTimeoutedIpRemoved = 3;
        }

        public void SetGoodPingColor(Color color)
        {
            GoodPingColorHtml = ColorTranslator.ToHtml(color);
            GoodPingColor = color;
        }

        public void SetBadPingColor(Color color)
        {
            BadPingColorHtml = ColorTranslator.ToHtml(color);
            BadPingColor = color;
        }

        public static void WriteSettingsToXML(string uri, Settings settings)
        {
            Console.WriteLine("Writing settings to file.");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));
            using (TextWriter writer = new StreamWriter(uri))
            {
                xmlSerializer.Serialize(writer, settings);
            }
        }
        public static Settings LoadSettingsFromXML(string uri)
        {
            if (File.Exists(uri))
            {
                Console.WriteLine("Loading settings from file.");
                XmlSerializer serializer = new XmlSerializer(typeof(Settings));
                using (TextReader reader = new StreamReader(uri))
                {
                    try
                    {
                        return (Settings)serializer.Deserialize(reader);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                        return null;
                    }
                }
            }
            return null;
        }
    }
}
