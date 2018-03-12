using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;
using System;

namespace DbD_Pingz
{
    public class Settings
    {
        private int _MaximumGoodPing;
        private string _GoodPingColorHtml;
        private string _BadPingColorHtml;
        private int _SecondsUntilIPTimeout;
        private int _MainWindowSplitter1Distance;
        private int _MainWindowSplitter2Distance;
        private bool _DbDPingzIsTopmost;
        private int _PingInfoChartScale;
        private Size _PingInfoFormSize;
        private int _SecondsUntilTimeoutedIpRemoved;
        private string _LastNetworkAdapterName;


        [XmlElement("MaximumGoodPing")]
        public int MaximumGoodPing
        {
            get { return _MaximumGoodPing; }
            set
            {
                _MaximumGoodPing = value;
                fireSettingsChangedEvent("MaximumGoodPing");
            }
        }
        [XmlIgnore]
        public Color GoodPingColor { get { return ColorTranslator.FromHtml(GoodPingColorHtml); } private set { } }
        [XmlIgnore]
        public Color BadPingColor { get { return ColorTranslator.FromHtml(BadPingColorHtml); } private set { } }
        [XmlElement("BoodPingColorHtml")]
        public string GoodPingColorHtml
        {
            get
            { return _GoodPingColorHtml; }
            set
            {
                _GoodPingColorHtml = value;
                fireSettingsChangedEvent("GoodPingColor");
            }
        }
        [XmlElement("BadPingColorHtml")]
        public string BadPingColorHtml
        {
            get
            { return _BadPingColorHtml; }
            set
            {
                _BadPingColorHtml = value;
                fireSettingsChangedEvent("BadPingColorHtml");
            }
        }
        [XmlElement("SecondsUntilIPTimeout")]
        public int SecondsUntilIPTimeout
        {
            get
            { return _SecondsUntilIPTimeout; }
            set
            {
                _SecondsUntilIPTimeout = value;
                fireSettingsChangedEvent("SecondsUntilIPTimeout");
            }
        }
        [XmlElement("MainWindowSplitter1Distance")]
        public int MainWindowSplitter1Distance
        {
            get
            { return _MainWindowSplitter1Distance; }
            set
            {
                _MainWindowSplitter1Distance = value;
                fireSettingsChangedEvent("MainWindowSplitter1Distance");
            }
        }
        [XmlElement("MainWindowSplitter2Distance")]
        public int MainWindowSplitter2Distance
        {
            get
            { return _MainWindowSplitter2Distance; }
            set
            {
                _MainWindowSplitter2Distance = value;
                fireSettingsChangedEvent("MainWindowSplitter2Distance");
            }
        }
        [XmlElement("DbDPingzIsTopmost")]
        public bool DbDPingzIsTopmost
        {
            get
            { return _DbDPingzIsTopmost; }
            set
            {
                _DbDPingzIsTopmost = value;
                fireSettingsChangedEvent("DbDPingzIsTopmost");
            }
        }
        [XmlElement("PingInfoChartScale")]
        public int PingInfoChartScale
        {
            get
            { return _PingInfoChartScale; }
            set
            {
                _PingInfoChartScale = value;
                fireSettingsChangedEvent("PingInfoChartScale");
            }
        }
        [XmlElement("PingInfoFormSize")]
        public Size PingInfoFormSize
        {
            get
            { return _PingInfoFormSize; }
            set
            {
                _PingInfoFormSize = value;
                fireSettingsChangedEvent("PingInfoFormSize");
            }
        }
        [XmlElement("SecondsUntilTimeoutRemoved")]
        public int SecondsUntilTimeoutedIpRemoved
        {
            get
            { return _SecondsUntilTimeoutedIpRemoved; }
            set
            {
                _SecondsUntilTimeoutedIpRemoved = value;
                fireSettingsChangedEvent("SecondsUntilTimeoutedIpRemoved");
            }
        }
        [XmlElement("LastNetworkAdapter")]
        public string LastNetworkAdapterName
        {
            get
            { return _LastNetworkAdapterName; }
            set
            {
                _LastNetworkAdapterName = value;
                fireSettingsChangedEvent("LastNetworkAdapterName");
            }
        }

        public event PropertyChangedEventHandler onSettingsChanged;

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
            PingInfoFormSize = new Size(830, 570);
            SecondsUntilTimeoutedIpRemoved = 3;
            LastNetworkAdapterName = null;
        }

        public void SetGoodPingColor(Color color)
        {
            GoodPingColorHtml = ColorTranslator.ToHtml(color);
            GoodPingColor = color;
            fireSettingsChangedEvent("GoodPingColor");
        }

        public void SetBadPingColor(Color color)
        {
            BadPingColorHtml = ColorTranslator.ToHtml(color);
            BadPingColor = color;
            fireSettingsChangedEvent("BadPingColor");
        }

        private void fireSettingsChangedEvent(string propertyName)
        {
            if (onSettingsChanged != null)
            {
                onSettingsChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
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
