using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseApi.Models;

namespace DataBaseApi.PersonDAO
{
    public class MockPersonDAO : IDAO<Person>
    {
        private int countPerson = 0;
        private int countPhone = 0;
        readonly SortedDictionary<int, Person> _people;
        public MockPersonDAO()
        {
            _people = new SortedDictionary<int, Person>();
            Person person = new Person(0, "Tom", "Test", 25);
            for (int i = 0; i < 3; i++)
            {
                person.Phones.Add(new Phone(0, "+38095716596" + i, 1));
            }
            Create(person);

            person = new Person(0, "Bob", "Smith", 22);
            for (int i = 0; i < 2; i++)
            {
                person.Phones.Add(new Phone(0, "+38095716596" + i, 2));
            }
            Create(person);

            person = new Person(0, "Vasya", "Ivanov", 12);
            for (int i = 0; i < 3; i++)
            {
                person.Phones.Add(new Phone(0, "+38095716596" + i, 3));
            }
            Create(person);
        }
        public List<Person> Read()
        {
            return _people.Values.ToList();
        }

        public void Update(Person model)
        {
            _people[model.Id] = model;
        }

        public void Delete(Person model)
        {
            _people.Remove(model.Id);
        }

        public void Create(Person model)
        {
            model.Id = ++countPerson;
            foreach (var phone in model.Phones)
            {
                phone.Id = ++countPhone;
            }
            _people.Add(model.Id, model);
        }

        public List<Person> Search(string searchStr)
        {
            List<Person> list = new List<Person>();
            foreach (Person p in _people.Values)
            {
                if (searchStr == p.Id.ToString() || searchStr == p.FirstName || searchStr == p.LastName || searchStr == p.Age.ToString())
                {
                    list.Add(p);
                }
            }
            return list;
        }
    }
}
