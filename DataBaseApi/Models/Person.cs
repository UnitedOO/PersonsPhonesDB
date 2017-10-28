using System.Collections.Generic;

namespace DataBaseApi.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public virtual ICollection<Phone> Phones { get; set; }

        public Person()
        {
            Phones = new HashSet<Phone>();
        }

        public Person(int id, string firstName, string lastName, int age)
        {
            Phones = new HashSet<Phone>();
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
}
