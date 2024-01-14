using KhaloudWebApplication_MVC_.BLL.Interface;
using KhaloudWebApplication_MVC_.DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace KhaloudWebApplication_MVC_.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeReposatory _employeeRepo;
        private readonly IDepartmentReposatory _departmentRepo;

        public EmployeeController(IEmployeeReposatory employeeRepo , IDepartmentReposatory departmentRepo)
        {

            _employeeRepo = employeeRepo;
            _departmentRepo = departmentRepo;
        }
       
        public IActionResult Index(string search)
        {
            IEnumerable<Employee> emps;
            if (string.IsNullOrEmpty(search))
            {
                emps = _employeeRepo.GetAll();
            }
            else { emps = _employeeRepo.Search(search);
            }

            return View(emps);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var dep = _employeeRepo.Get(id.Value);
            return View(dep);

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _employeeRepo.Create(emp);

                return RedirectToAction("Index");
            }
            return View();

        }



        public IActionResult Update(Employee emp)
        {
            if (ModelState.IsValid)
            {
                _employeeRepo.Update(emp);

                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int id)
        {

            var emp = _employeeRepo.Get(id);
            _employeeRepo.Delete(emp);
            return RedirectToAction("Index");
        }

    }
}
