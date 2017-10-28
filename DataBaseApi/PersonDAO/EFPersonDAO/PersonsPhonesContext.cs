using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseApi.Models;

namespace DataBaseApi.PersonDAO.EFPersonDAO
{
    public class PersonsPhonesContext : DbContext
    {
        public PersonsPhonesContext() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Path.GetFullPath(@"..\..\..\DataBaseApi\LocalDBs\PersonsPhonesDB.mdf") + ";Integrated Security=True;")
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }
}
