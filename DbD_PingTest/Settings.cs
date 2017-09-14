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

        public Settings()
        {
            maxGoodPing = 90;
            killerMaxListEntries = 4;
            survivorMaxListEntries = 1;
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
    }
}
