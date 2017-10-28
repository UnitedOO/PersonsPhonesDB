using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseApi.Models;

namespace DataBaseApi.PersonDAO.EFPersonDAO
{
    class EFPersonDAO : IDAO<Person>
    {
        public List<Person> Read()
        {
            using (PersonsPhonesContext context = new PersonsPhonesContext())
            {
                return context.Persons.ToList();
            }
        }

        public void Update(Person model)
        {
            using (PersonsPhonesContext context = new PersonsPhonesContext())
            {
                Person original = context.Persons.FirstOrDefault(x => x.Id == model.Id);
                context.Entry(original).CurrentValues.SetValues(model);
                context.SaveChanges();
            }
        }

        public void Delete(Person model)
        {
            using (PersonsPhonesContext context = new PersonsPhonesContext())
            {
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
    }
}
