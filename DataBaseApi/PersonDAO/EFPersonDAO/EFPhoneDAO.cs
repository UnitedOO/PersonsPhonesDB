using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseApi.Models;

namespace DataBaseApi.PersonDAO.EFPersonDAO
{
    public class EFPhoneDAO : IDAO<Phone>
    {
        public List<Phone> Read()
        {
            using (PersonsPhonesContext context = new PersonsPhonesContext())
            {
                return context.Phones.ToList();
            }
        }

        public void Update(Phone model)
        {
            using (PersonsPhonesContext context = new PersonsPhonesContext())
            {
                Phone original = context.Phones.FirstOrDefault(x => x.Id == model.Id);
                context.Entry(original).CurrentValues.SetValues(model);
                context.SaveChanges();
            }
        }

        public void Delete(Phone model)
        {
            using (PersonsPhonesContext context = new PersonsPhonesContext())
            {
                Phone pToDel = context.Phones.First(x => x.Id == model.Id);
                context.Phones.Remove(pToDel);
                context.SaveChanges();
            }
        }

        public void Create(Phone model)
        {
            using (PersonsPhonesContext context = new PersonsPhonesContext())
            {
                context.Phones.Add(model);
                context.SaveChanges();
            }
        }

        public List<Phone> Search(string searchStr)
        {
            throw new NotImplementedException();
        }
    }
}
