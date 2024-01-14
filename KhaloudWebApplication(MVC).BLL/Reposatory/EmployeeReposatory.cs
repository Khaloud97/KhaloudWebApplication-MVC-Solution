using KhaloudWebApplication_MVC_.BLL.Interface;
using KhaloudWebApplication_MVC_.DAL.Context;
using KhaloudWebApplication_MVC_.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaloudWebApplication_MVC_.BLL.Reposatory
{
    public class EmployeeReposatory : GenericReposatory<Employee>, IEmployeeReposatory
    {
        public readonly ApplicationDbContext _context;
        public EmployeeReposatory(ApplicationDbContext context) : base(context) {

            _context = context;
        }

        public IEnumerable<Employee> Search(string name)
        {
            var emp = _context.Employees.Where(e => e.Name.ToLower().Contains(name.ToLower())).ToList();
            return emp;
        }
    }
}
