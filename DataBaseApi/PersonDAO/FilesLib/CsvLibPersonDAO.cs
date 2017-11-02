using DataBaseApi.Models;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi.PersonDAO.FilesLib
{
    class CsvLibPersonDAO : FilesPersonDAO
    {
        public CsvLibPersonDAO() : base(@"CSVL_DB.txt")
        {
        }

        protected override List<Person> Load()
        {
            if (File.Exists(path) == false)
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            string csvString = File.ReadAllText(path);
            List<Person> persons = new List<Person>();
            if (csvString.Length == 0)
                persons = new List<Person>();
            else
                persons = CsvSerializer.DeserializeFromString<List<Person>>(csvString);
            return persons;
        }

        protected override void Write(List<Person> persons)
        {
            int count = 0;
            foreach (var item in persons)
            {
                item.Id = ++count;
                foreach (var phone in item.Phones)
                {
                    phone.Person = null;
                }
            }
            string csvString = CsvSerializer.SerializeToCsv(persons);
            File.WriteAllText(path, csvString);
        }
    }
}
