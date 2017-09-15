using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using System;

namespace DbD_Pingz
{
    public class Settings
    {
        [XmlElement("maxGoodPing")]
        public int maxGoodPing { get; set; }
        [XmlElement("killerMaxListEntries")]
        public int killerMaxListEntries { get; set; }
        [XmlElement("survivorMaxListEntries")]
        public int survivorMaxListEntries { get; set; }
        [XmlIgnore]
        public Color goodPingColor { get { return ColorTranslator.FromHtml(goodPingColorHtml); } private set { }  }
        [XmlIgnore]
        public Color badPingColor { get { return ColorTranslator.FromHtml(badPingColorHtml); } private set { } }
        [XmlElement("goodPingColorHtml")]
        public string goodPingColorHtml { get; set; }
        [XmlElement("badPingColorHtml")]
        public string badPingColorHtml { get; set; }
        [XmlElement("programMode")]
        public DbDPingzMode programMode { get; set; } 

        public Settings()
        {
            maxGoodPing = 90;
            killerMaxListEntries = 4;
            survivorMaxListEntries = 1;
            programMode = DbDPingzMode.Killer;
            setBadPingColor(Color.Red);
            setGoodPingColor(Color.LightGreen);
        }

        public void setGoodPingColor(Color color)
        {
            goodPingColorHtml = ColorTranslator.ToHtml(color);
            goodPingColor = color;
        }

        public void setBadPingColor(Color color)
        {
            badPingColorHtml = ColorTranslator.ToHtml(color);
            badPingColor = color;
        }

        public static void writeSettingsToXML(string uri, Settings settings)
        {
            Console.WriteLine("Writing settings to file.");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));
            using (TextWriter writer = new StreamWriter(uri))
            {
                xmlSerializer.Serialize(writer, settings);
            }
        }
        public static Settings loadSettingsFromXML(string uri)
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
