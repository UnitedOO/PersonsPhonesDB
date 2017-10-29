using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseApi.Models;

namespace DataBaseApi.PersonDAO
{
    abstract class SQLPersonDAO : IDAO<Person>
    {
        private SQLPhoneDAO phoneDao;

        protected string tablePersons = "";

        public SQLPersonDAO()
        {
            tablePersons = "Persons";
        }

        public void Create(Person person)
        {
            OpenConnection();
            string cmd =
                $"INSERT INTO {tablePersons} (Id, FirstName, LastName, Age) " +
                $"VALUES ({null}, '{person.FirstName}', '{person.LastName}', {person.Age})";
            int personId = ExecuteCreate(cmd);

            foreach (var phone in person.Phones)
            {
                phone.PersonId = personId; 
                phoneDao.Create(phone);
            }

            CloseConnection();
        }

        public void Delete(Person person)
        {
            OpenConnection();
            string cmd =
                $"Delete FROM {tablePersons} " +
                $"WHERE Id = {person.Id};";
            ExecuteCommand(cmd);
            CloseConnection();
        }

        public List<Person> Read()
        {
            OpenConnection();
            string cmd = $"SELECT * FROM {tablePersons};";
            List<Person> listPerson = ReadData(cmd);
            CloseConnection();
            return listPerson;
        }

        public void Update(Person person)
        {
            OpenConnection();
            string cmd =
                $"UPDATE {tablePersons} " +
                $"SET FirstName = '{person.FirstName}', LastName='{person.LastName}', Age={person.Age} " +
                $"WHERE Id = {person.Id};";
            ExecuteCommand(cmd);
            
            CloseConnection();
        }

        abstract protected void CloseConnection();
        abstract protected void OpenConnection();
        abstract protected void ExecuteCommand(string cmd);
        abstract protected int ExecuteCreate(string cmd);
        abstract protected List<Person> ReadData(string cmd);
    }
}
