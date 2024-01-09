using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaloudWebApplication_MVC_.BLL.Interface
{
    public interface IGenericReposatory<T>
    {
        
        // 5 actions ==> Get All , get , create ,  delete, update
        IEnumerable<T> GetAll();
        T Get(int id); 
        int Create(T item);
        int Update(T item);
        int Delete(T item);
    }
}
