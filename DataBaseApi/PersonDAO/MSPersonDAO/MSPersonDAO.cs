﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DataBaseApi.Models;

namespace DataBaseApi.PersonDAO.MSPersonDAO
{
    class MSPersonDAO : SQLPersonDAO
    {
        SqlConnection connection = null;
        
        public MSPersonDAO()
        {
            this.phoneDao = new MSPhoneDAO();
            string strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                             Path.GetFullPath(@"..\..\..\DataBaseApi\LocalDBs\PersonsPhonesDB.mdf") +
                             ";Integrated Security=True;";
            connection = new SqlConnection(strConn);
        }
        protected override void CloseConnection()
        {
            connection.Close();
        }

        protected override void OpenConnection()
        {
            connection.Open();
        }

        protected override void ExecuteCommand(string cmd)
        {
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            sqlCmd.ExecuteNonQuery();
        }

        protected override int ExecuteCreate(string cmd)
        {
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            return Convert.ToInt32(sqlCmd.ExecuteScalar());
        }

        protected override List<Person> ReadData(string cmd)
        {
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            SqlDataReader reader = sqlCmd.ExecuteReader();

            List<Person> listPerson = new List<Person>();
            Person currentPerson = null;
            while (reader.Read())
            {
                if (currentPerson == null || currentPerson.Id != reader.GetInt32(0)) //determine by person id if current row is row of another person
                {
                    currentPerson = new Person(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                    listPerson.Add(currentPerson);
                }
                if (!reader.IsDBNull(4))
                {
                    Phone currentPhone = new Phone(reader.GetInt32(4), reader.GetString(5), reader.GetInt32(6));
                    currentPerson.Phones.Add(currentPhone);
                }
            }
            reader.Close();
            return listPerson;
        }
    }
}
