using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
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
            string strConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" +
                             Path.GetFullPath(@"..\..\..\DataBaseApi\LocalDBs\PersonsPhonesDB.mdf") +
                             ";Integrated Security=True;";
            connection = new SqlConnection();
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
            sqlCmd.ExecuteNonQuery();
            return (int) sqlCmd.ExecuteScalar();
        }

        protected override List<Person> ReadData(string cmd)
        {
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            SqlDataReader reader = sqlCmd.ExecuteReader();

            List<Person> listPerson = new List<Person>();
            while (reader.Read())
            {
                listPerson.Add(new Person(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3)));
            }
            reader.Close();
            return listPerson;
        }
    }
}
