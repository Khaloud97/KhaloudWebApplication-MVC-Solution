using KhaloudWebApplication_MVC_.BLL.Interface;
using KhaloudWebApplication_MVC_.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaloudWebApplication_MVC_.BLL.Reposatory
{
    public class GenericReposatory<T> : IGenericReposatory<T> where T : class 
    {
        private readonly ApplicationDbContext _context;

        public GenericReposatory(ApplicationDbContext context) 
        {

            _context = context;
        }

        //=========================================================
        public int Create(T item)
        {
            _context.Set<T>().Add(item);
            return _context.SaveChanges();
        }

        public int Delete(T item)
        {
            _context.Set<T>().Remove(item);
            return _context.SaveChanges();
        }

        public T Get(int id) => _context.Set<T>().Find(id);

        public IEnumerable<T> GetAll()=> _context.Set<T>().ToList();

        public int Update(T item)
        {
            _context.Set<T>().Update(item);
             return _context.SaveChanges();
        }


    }
    
}
