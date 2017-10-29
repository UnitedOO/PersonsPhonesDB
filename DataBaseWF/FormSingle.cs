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
    public partial class FormSingle : Form
    {
        private Person person = null;
        private Phone phone = null;
        public TableModel tableModel = new TableModel();
      
        public FormSingle()
        {
            InitializeComponent();
        }

        private Person GetPerson()
        {
            int id = Int32.Parse(txtId.Text);
            string fn = txtFirstName.Text;
            string ln = txtLastName.Text;
            int age = Int32.Parse(txtAge.Text);
            return new Person(id, fn, ln, age);
        }

        public void AddPersonInf(Person person)
        {
            btnUpdate.Visible=true;
            btnCreate.Visible = false;
            this.person = person;

            txtId.Text += person.Id.ToString();
            txtFirstName.Text += person.FirstName;
            txtLastName.Text += person.LastName;
            txtAge.Text += person.Age.ToString();

        }

      
        private void btnUpdate_Click(object sender, EventArgs e)
        {
         //   tableModel.Update(GetPerson());
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
          //  tableModel.Create(GetPerson());
           
            this.Close();
        }
    }
}
