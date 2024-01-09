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
    public class DepartmentReposatory : GenericReposatory<Department> , IDepartmentReposatory
    {
        public DepartmentReposatory(ApplicationDbContext context) : base(context) { }
    }
}
