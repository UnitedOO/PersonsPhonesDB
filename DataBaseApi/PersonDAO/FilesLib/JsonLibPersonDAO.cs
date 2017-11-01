using DataBaseApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi.PersonDAO.FilesLib
{
    class JsonLibPersonDAO : FilesPersonDAO
    { 
        public JsonLibPersonDAO() : base(@"JSONL_DB.txt")
        {
        }

        protected override List<Person> Load()
        {
            if (File.Exists(path) == false)
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            string jsonString = File.ReadAllText(path);
            List<Person> persons = new List<Person>();
            if (jsonString.Length == 0)
                persons = new List<Person>();
            else
                persons = JsonConvert.DeserializeObject<List<Person>>(jsonString);
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
            string jsonString = JsonConvert.SerializeObject(persons);
            File.WriteAllText(path, jsonString);
        }
    }
}
