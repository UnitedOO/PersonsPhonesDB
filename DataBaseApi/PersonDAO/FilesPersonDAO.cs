using DataBaseApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi.PersonDAO
{
    abstract class FilesPersonDAO : IDAO<Person>
    {
        protected string path = "";
        public FilesPersonDAO(string path)
        {
            this.path = path;
        }

        public void Create(Person person)
        {
            List<Person> people = Load();
            Person add = people.Find((x) => x.Id == person.Id);
            if (add == null)
            {
                people.Add(person);
                people.Sort(Person.CompareById);
            }
            Write(people);
        }

        public void Delete(Person person)
        {
            List<Person> people = Load();
            Person del = people.Find((x) => x.Id == person.Id);
            if (del != null)
            {
                people.Remove(del);
            }
            Write(people);
        }

        public void Update(Person person)
        {
            List<Person> people = Load();
            Person add = people.Find((x) => x.Id == person.Id);
            if (add != null)
            {
                int i = people.IndexOf(add);
                people.ElementAt(i).FirstName = person.FirstName;
                people.ElementAt(i).LastName = person.LastName;
                people.ElementAt(i).Age = person.Age;
                people[i].Phones = person.Phones;
            }
            Write(people);
        }

        public List<Person> Read()
        {
            return Load();
        }

        abstract protected List<Person> Load();
        abstract protected void Write(List<Person> people);

        public List<Person> Search(string searchStr)
        {
            throw new NotImplementedException();
        }
    }
}
