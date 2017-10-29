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
        protected SQLPhoneDAO phoneDao;

        protected string tablePersons = "";

        public SQLPersonDAO()
        {
            tablePersons = "People";
        }

        public void Create(Person person)
        {
            OpenConnection();
            string cmd =
                $"INSERT INTO {tablePersons} (FirstName, LastName, Age) " +
                $"VALUES ('{person.FirstName}', '{person.LastName}', {person.Age});" +
                "SELECT SCOPE_IDENTITY()";
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
            foreach (var phone in person.Phones)
            {
                phoneDao.Delete(phone);
            }
            OpenConnection();
            string cmd =
                $"Delete FROM {tablePersons} " +
                $"WHERE Id = {person.Id};";
            ExecuteCommand(cmd);
            CloseConnection();
        }

        public List<Person> Read()
        {
            string cmd = $"SELECT * FROM {tablePersons} LEFT JOIN {phoneDao.GetTableName()} ON {tablePersons}.Id = {phoneDao.GetTableName()}.PersonId;";
            List<Person> listPerson = ReadData(cmd);
            CloseConnection();
            return listPerson;
        }

        public void Update(Person person)
        {
            foreach (var phone in person.Phones)
            {
                phoneDao.Update(phone);
            }
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
