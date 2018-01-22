using System.Windows.Forms;
using System.Reflection;

namespace DbD_Pingz
{
    public partial class About : Form
    {
        public About(string buildtype)
        {
            InitializeComponent();
            version.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            this.buildtype.Text = buildtype;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://github.com/besentv");
        }
    }
}
