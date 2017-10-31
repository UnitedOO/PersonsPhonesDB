using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseApi.Models;

namespace DataBaseApi.PersonDAO.EFPersonDAO
{
    public class EFPersonDAO : IDAO<Person>
    {
        EFPhoneDAO phoneDAO = new EFPhoneDAO();
        public List<Person> Read()
        {
            using (PersonsPhonesContext context = new PersonsPhonesContext())
            {
                return context.Persons.Include(p => p.Phones).ToList();
            }
        }

        public void Update(Person model)
        {
            using (PersonsPhonesContext context = new PersonsPhonesContext())
            {
                foreach (var phone in model.Phones)
                {
                    if (phone.Id == 0)
                    {
                        phone.Person = null;
                        phone.PersonId = model.Id;
                        phoneDAO.Create(phone);
                    }
                }
                Person original = context.Persons.FirstOrDefault(x => x.Id == model.Id);
                context.Entry(original).CurrentValues.SetValues(model);
                context.SaveChanges();
            }
        }

        public void Delete(Person model)
        {
            using (PersonsPhonesContext context = new PersonsPhonesContext())
            {
                foreach (var phone in model.Phones)
                {
                    phoneDAO.Delete(phone);
                }
                Person pToDel = context.Persons.First(x => x.Id == model.Id);
                context.Persons.Remove(pToDel);
                context.SaveChanges();
            }
        }

        public void Create(Person model)
        {
            using (PersonsPhonesContext context = new PersonsPhonesContext())
            {
                context.Persons.Add(model);
                context.SaveChanges();
            }
        }

        public List<Person> Search(string searchStr)
        {
            List<Person> listPerson = Read();
            List<Person> list = new List<Person>();
            foreach (Person p in listPerson)
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
