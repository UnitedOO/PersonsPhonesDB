using DataBaseApi;
using DataBaseApi.Models;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DataBaseWF
{
    public class TableModel
    {
        IDAO<Person> db = null;
        IDAO<Phone> dbPhone = null;

        public void SetDataBase(string type)
        {
            db = DBFactory.GetInstance(type);
        }

        public void Create(Person person)
        {
           db.Create(person);
        }

        public void Update(Person person)
        {
            db.Update(person);
        }

        public DataTable Read()
        {
            DataTable dataTable = new DataTable();
            List<Person> listPerson = db.Read();

            dataTable.Columns.Add(new DataColumn("Id"));
            dataTable.Columns.Add(new DataColumn("FirstName"));
            dataTable.Columns.Add(new DataColumn("LastName"));
            dataTable.Columns.Add(new DataColumn("Age"));

            foreach (Person person in listPerson)
            {
                DataRow row = dataTable.NewRow();
                row[0] = person.Id;
                row[1] = person.FirstName;
                row[2] = person.LastName;
                row[3] = person.Age;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

       
        public void ClearTable(DataGridView dgv)
        {
            dgv.DataSource = new DataTable();
        }

        public List<Person> ReturnPersons()
        {
            List<Person> listPerson = db.Read();
            return listPerson;
        }
    }
}