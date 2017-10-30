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
        public TableModel tableModel;

        public FormSingle(TableModel tableModel, Person person)
        {
            InitializeComponent();
            this.tableModel = tableModel;
            this.person = person;

            if (person.Id != 0)
            {
                btnUpdate.Visible = true;
                btnCreate.Visible = false;

                txtId.Text += person.Id.ToString();
                txtAge.Text += person.Age.ToString();
            }
            txtFirstName.Text += person.FirstName;
            txtLastName.Text += person.LastName;

            foreach (Phone phone in person.Phones)
            {
                listPhones.Items.Add(phone.Number);
            }
        }

        private Person GetPerson()
        {
            person.FirstName = txtFirstName.Text;
            person.LastName = txtLastName.Text;
            person.Age = Int32.Parse(txtAge.Text);

            foreach (string phoneNumber in listPhones.Items)
            {
                Phone phone = new Phone();
                phone.Id = 0;
                phone.Number = phoneNumber;
                phone.Person = person;
                person.Phones.Add(phone);
            }
            return person;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            tableModel.Update(GetPerson());
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            tableModel.Create(GetPerson());
            this.Close();

        }

        private void btnAddPhone_Click(object sender, EventArgs e)
        {
            listPhones.Items.Add(txtPhone.Text);
            txtPhone.Text = "";
        }
    }
}
