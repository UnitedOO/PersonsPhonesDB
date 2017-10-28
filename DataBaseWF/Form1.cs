using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseWF
{
    public partial class FormMulti : Form
    {
        TableModel tableModel = null;
        public FormMulti()
        {
            InitializeComponent();
            string[] types = { "Mock", "Binary", "BinaryL", "MS SQL", "MY SQL", "H2", "MONGODB", "CSV", "CSV_L", "JSON", "JSON_L", "XML", "XML_L", "YAML", "YAML_L", "MS SQL EF" };

            foreach (string t in types)
            {
                DBSwitch.Items.Add(t);
            }
            DBSwitch.SelectedIndex = 0;
            tableModel = new TableModel("Mock");
        }

        
        private void btncreate_Click(object sender, EventArgs e)
        {
            FormSingle fSingle = new FormSingle();
            fSingle.Show();

        }

        private void dataGridDB_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormSingle fSingle = new FormSingle();
            fSingle.Show();
        }

        private void btnread_Click(object sender, EventArgs e)
        {
            dataGridDB.DataSource = tableModel.Read();
        }

        private void SelectDB(object sender, EventArgs e)
        {
            tableModel = new TableModel(DBSwitch.SelectedItem.ToString());
            tableModel.ClearTable(dataGridDB);
        }
    }
}
