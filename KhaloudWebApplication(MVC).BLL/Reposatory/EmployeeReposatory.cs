using KhaloudWebApplication_MVC_.BLL.Interface;
using KhaloudWebApplication_MVC_.DAL.Context;
using KhaloudWebApplication_MVC_.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KhaloudWebApplication_MVC_.BLL.Reposatory
{
    public class EmployeeReposatory : GenericReposatory<Employee>, IEmployeeReposatory
    {
        public EmployeeReposatory(ApplicationDbContext context) : base(context) { }
    }
}
