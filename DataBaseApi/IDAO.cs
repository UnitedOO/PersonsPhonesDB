using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseApi
{
    public interface IDAO<TModel>
    {
        List<TModel> Read();
        void Update(TModel model);
        void Delete(TModel model);
        void Create(TModel model);
        List<TModel> Search(string searchStr);
    }
}
