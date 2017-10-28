using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseApi.Models;
using DataBaseApi.PersonDAO;

namespace DataBaseApi
{
    public class DBFactory
    {
        public static IDAO<Person> GetInstance(string type)
        {
            IDAO<Person> db = null;

            switch (type)
            {
                case "Mock": db = new MockPersonDAO(); break;
            }
            return db;
        }
    }
}
