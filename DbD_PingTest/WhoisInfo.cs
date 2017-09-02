using System.Windows.Forms;

namespace DbD_Pingz
{
    public partial class WhoisInfo : Form
    {
        public WhoisInfo(string whoisString)
        {
            InitializeComponent();
            this.whoisText.Text = whoisString.Replace("\n", "\r\n");
        }
    }
}
