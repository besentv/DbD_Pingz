using System.IO;
using System.Net;
using System.Windows.Forms;

namespace DbD_Pingz
{
    public partial class WhoisInfo : Form
    {
        public WhoisInfo(string ip)
        {
            InitializeComponent();
            string whoisString = whoisIp("http://ipinfo.io/" + ip + "/json");
            this.whoisText.Text = whoisString.Replace("\n", "\r\n");
        }

        private string whoisIp(string requestUrl)
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
