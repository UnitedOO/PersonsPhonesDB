using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseApi.Models;
using System.IO;
using System.Xml.Serialization;

namespace DataBaseApi.PersonDAO.FilesLib
{
    class XmlLibPersonDAO : FilesPersonDAO
    {
        public XmlLibPersonDAO() : base(@"XMLL_DB.txt")
        {
        }

        protected override List<Person> Load()
        {
            if (File.Exists(path) == false)
            {
                FileStream fs = File.Create(path);
                fs.Close();
            }
            TextReader reader = File.OpenText(path);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            List<Person> persons;
            try
            {
                persons = (List<Person>)serializer.Deserialize(reader);
            }
            catch (Exception exception)
            {
                persons = new List<Person>();
            }
            reader.Close();
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
            TextWriter writer = File.CreateText(path);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            serializer.Serialize(writer, persons);
            writer.Close();
        }

    }
}
