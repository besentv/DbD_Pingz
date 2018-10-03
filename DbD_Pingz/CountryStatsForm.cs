using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbD_Pingz
{
    public partial class CountryStatsForm : Form
    {
        DataTable countryStatsContent;

        public CountryStatsForm(DataTable contents)
        {
            InitializeComponent();

            countryStatsContent = contents;

            Console.WriteLine("Data types:" + contents.Columns[0].DataType.ToString() + " - " + contents.Columns[1].DataType.ToString());

            countryStatsDataGridView.Columns[1].ValueType = typeof(Int64);
            countryStatsDataGridView.Columns[0].ValueType = typeof(String);
            countryStatsDataGridView.Columns["CountryFlag"].DefaultCellStyle.NullValue = null;
            countryStatsDataGridView.Sort(countryStatsDataGridView.Columns["amount"], ListSortDirection.Descending);
            countryStatsDataGridView.DataSource = contents;

            if (contents.Rows.Count > 0 && contents.Rows.Count > 0)
            {    
                countryStatsDataGridView.Rows[0].Cells[0].Selected = false;
            }
        }

        private void countryStatsDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DataGridView countryStats = (DataGridView)sender;

            for (int i = e.RowIndex; i < (e.RowIndex + e.RowCount); i++)
            {
                Image flag;
                flag = CountryIdConverter.ConvertCountryIdToFlagImage((string)countryStats.Rows[i].Cells["countrycode"].Value);
                if (flag != null)
                {
                    countryStats.Rows[i].Cells["CountryFlag"].Value = flag;
                    countryStats.Rows[i].Height = flag.Height;
                }

                string fullName;
                if (CountryIdConverter.TryGetName((string)countryStats.Rows[i].Cells["countrycode"].Value, out fullName))
                {
                    countryStats.Rows[i].Cells["CountryFlag"].ToolTipText = fullName;
                }
            }
        }
    }
}
