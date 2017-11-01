using DataBaseApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace DataBaseApi.PersonDAO.FilesLib
{
    class YamlLibPersonDAO : FilesPersonDAO
    {
        public YamlLibPersonDAO() : base(@"YAMLL_DB.txt")
        {
        }

        protected override List<Person> Load()
        {
            if (File.Exists(path) == false)
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            string yamlString = File.ReadAllText(path);
            List<Person> persons;
            Deserializer deserializer = new Deserializer();
            if (yamlString.Length == 0)
                persons = new List<Person>();
            else
                persons = persons = deserializer.Deserialize<List<Person>>(yamlString);
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
            Serializer serializer = new Serializer();
            string yamlString = serializer.Serialize(persons);
            File.WriteAllText(path, yamlString);
        }
    }
}
