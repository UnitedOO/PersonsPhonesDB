using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseApi.Models;

namespace DataBaseApi.PersonDAO
{
    abstract class SQLPhoneDAO : IDAO<Phone>
    {
        protected string tablePhones = "";

        public SQLPhoneDAO()
        {
            tablePhones = "Phones";
        }

        public void Create(Phone phone)
        {
            OpenConnection();

            string cmd = $"INSERT INTO {tablePhones} (Id, Number, PersonId) " +
                      $"VALUES ({null}, {phone.Number}, {phone.PersonId})";
            ExecuteCommand(cmd);
            
            CloseConnection();
        }

        public void Delete(Phone phone)
        {
            OpenConnection();
            string cmd =
                $"Delete FROM {tablePhones} " +
                $"WHERE Id = {phone.Id};";
            ExecuteCommand(cmd);
            CloseConnection();
        }

        public List<Phone> Read()
        {
            OpenConnection();
            string cmd = $"SELECT * FROM {tablePhones};";
            List<Phone> listPhone = ReadData(cmd);
            CloseConnection();
            return listPhone;
        }

        public void Update(Phone phone)
        {
            OpenConnection();
            string cmd =
                $"UPDATE {tablePhones} " +
                $"SET Number = '{phone.Number}' " +
                $"WHERE Id = {phone.Id};";
            ExecuteCommand(cmd);

            CloseConnection();
        }

        abstract protected void CloseConnection();
        abstract protected void OpenConnection();
        abstract protected void ExecuteCommand(string cmd);
        abstract protected int ExecuteCreate(string cmd);
        abstract protected List<Phone> ReadData(string cmd);
    }
}
