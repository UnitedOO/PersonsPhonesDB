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
    class MSPhoneDAO : SQLPhoneDAO
    {
        SqlConnection connection = null;

        public MSPhoneDAO()
        {
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

        protected override List<Phone> ReadData(string cmd)
        {
            SqlCommand sqlCmd = new SqlCommand(cmd, connection);
            SqlDataReader reader = sqlCmd.ExecuteReader();

            List<Phone> listPhone = new List<Phone>();
            while (reader.Read())
            {
                listPhone.Add(new Phone(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
            }
            reader.Close();
            return listPhone;
        }
    }
}
