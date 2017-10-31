using DataBaseApi.Models;
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
        TableModel tableModel = new TableModel();
        public FormMulti()
        {
            InitializeComponent();
            string[] types = { "Mock", "Binary", "BinaryL", "MS SQL", "MY SQL", "H2", "MONGODB", "CSV", "CSV_L", "JSON", "JSON_L", "XML", "XML_L", "YAML", "YAML_L", "MS SQL EF" };

            foreach (string t in types)
            {
                DBSwitch.Items.Add(t);
            }
            DBSwitch.SelectedIndex = 0;
            tableModel.SetDataBase("Mock");

        }

        private void btncreate_Click(object sender, EventArgs e)
        {
            FormSingle fSingle = new FormSingle(tableModel, new Person(0, "", "", 0));
            fSingle.Show();
        }

        private void btnread_Click(object sender, EventArgs e)
        {
            dataGridDB.DataSource = tableModel.Read();
        }

        private void SelectDB(object sender, EventArgs e)
        {
            tableModel.SetDataBase(DBSwitch.SelectedItem.ToString());
            dataGridDB.DataSource = null;
        }

        private void dataGridDB_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            int id = Int32.Parse(dataGridDB.Rows[index].Cells[0].Value.ToString());
            foreach (Person p in tableModel.ReturnPersons())
            {
                if (id == p.Id)
                {
                    FormSingle fSingle = new FormSingle(tableModel, p);
                    fSingle.Show();
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int index = (int)dataGridDB.CurrentCell.RowIndex;
            int id = Int32.Parse(dataGridDB.Rows[index].Cells[0].Value.ToString());
            foreach (Person p in tableModel.ReturnPersons())
            {
                if (id == p.Id)
                {
                    tableModel.Delete(p);
                }
            }
            dataGridDB.DataSource = tableModel.Read();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dataGridDB.DataSource = "";
            dataGridDB.DataSource = tableModel.Search(txtSearch.Text);
            txtSearch.Text = "";
        }
    }
}
