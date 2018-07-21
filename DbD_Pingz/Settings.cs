using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System.ComponentModel;
using System;
using System.Windows.Forms.DataVisualization.Charting;

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
        private string _PingInfoChartPaletteString;
        private bool _UseAveragePing;


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
        public Color GoodPingColor
        {
            get { return ColorTranslator.FromHtml(GoodPingColorHtml); }
            set
            {
                GoodPingColorHtml = ColorTranslator.ToHtml(value);
            }
        }
        [XmlIgnore]
        public Color BadPingColor
        {
            get { return ColorTranslator.FromHtml(BadPingColorHtml); }
            set
            {
                BadPingColorHtml = ColorTranslator.ToHtml(value);
            }
        }
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
        [XmlIgnore]
        public ChartColorPalette PingInfoChartPalette
        {
            get
            {
                return (ChartColorPalette)Enum.Parse(typeof(ChartColorPalette), PingInfoChartPaletteString);
            }
            set
            {
                PingInfoChartPaletteString = value.ToString();
            }
        }

        [XmlElement("PingInfoChartPaletteString")]
        public string PingInfoChartPaletteString
        {
            get { return _PingInfoChartPaletteString; }
            set
            {
                _PingInfoChartPaletteString = value;
                fireSettingsChangedEvent("PingInfoChartPaletteString");
            }
        }

        [XmlElement("UseAveragePing")]
        public bool UseAveragePing
        {
            get { return _UseAveragePing; }
            set
            {
                _UseAveragePing = value;
                fireSettingsChangedEvent("UseAveragePing");
            }
        }

        public event PropertyChangedEventHandler onSettingsChanged;

        public Settings()
        {
            MaximumGoodPing = 90;
            BadPingColor = Color.Red;
            GoodPingColor = Color.LightGreen;
            SecondsUntilIPTimeout = 3;
            MainWindowSplitter1Distance = 140;
            MainWindowSplitter2Distance = 280;
            DbDPingzIsTopmost = false;
            PingInfoChartScale = 250;
            PingInfoFormSize = new Size(830, 570);
            SecondsUntilTimeoutedIpRemoved = 3;
            LastNetworkAdapterName = null;
            PingInfoChartPalette = ChartColorPalette.BrightPastel;
            UseAveragePing = false;

        }

        private void fireSettingsChangedEvent(string propertyName)
        {
            if (onSettingsChanged != null)
            {
                onSettingsChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static string WriteSettingsToXML(string uri, Settings settings)
        {        
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));

            try
            {
                using (TextWriter writer = new StreamWriter(uri))
                {
                    xmlSerializer.Serialize(writer, settings);
                }
                Console.WriteLine("Wrote settings to file.");
                return null;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("Could not write settings to file! Probably write protected.");
                return ex.ToString();
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
                        Console.WriteLine(ex.ToString());
                        return null;
                    }
                }
            }
            return null;
        }
    }
}
