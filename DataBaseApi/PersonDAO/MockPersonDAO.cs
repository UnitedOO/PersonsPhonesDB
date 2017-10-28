using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseApi.Models;

namespace DataBaseApi.PersonDAO
{
    class MockPersonDAO : IDAO<Person>
    {
        readonly SortedDictionary<int, Person> _people;
        public MockPersonDAO()
        {
            _people = new SortedDictionary<int, Person>();
            Person person = new Person(1, "Tom", "Test", 25);
            for (int i = 1; i < 4; i++)
            {
                person.Phones.Add(new Phone(i, "+38095716596" + i, 1));
            }
            _people.Add(person.Id, person);

            person = new Person(2, "Bob", "Smith", 22);
            for (int i = 4; i < 6; i++)
            {
                person.Phones.Add(new Phone(i, "+38095716596" + i, 2));
            }
            _people.Add(person.Id, person);

            person = new Person(3, "Vasya", "Ivanov", 12);
            for (int i = 6; i < 9; i++)
            {
                person.Phones.Add(new Phone(i, "+38095716596" + i, 3));
            }
            _people.Add(person.Id, person);
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
            _people.Add(model.Id, model);
        }
    }
}
