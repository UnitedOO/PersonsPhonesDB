using DataBaseApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi.PersonDAO.FilesLib
{
    class BinaryLibPersonDAO : FilesPersonDAO
    {
        public BinaryLibPersonDAO() : base(@"BinaryL_DB.txt")
        {
        }

        protected override List<Person> Load()
        {
            List<Person> persons = new List<Person>();
            if (File.Exists(path) == false)
            {
                return persons;
            }
            else
            {
                string[] ls = File.ReadAllLines(path);
                if (ls.Length == 0)
                    return persons;
            }
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                persons = (List<Person>)bf.Deserialize(fs);
            }
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
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, persons);
            }
        }
    }
}
