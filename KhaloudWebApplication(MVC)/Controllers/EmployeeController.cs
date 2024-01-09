using KhaloudWebApplication_MVC_.BLL.Interface;
using KhaloudWebApplication_MVC_.DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace KhaloudWebApplication_MVC_.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeReposatory _employeeRepo;

        public EmployeeController(IEmployeeReposatory employeeRepo)
        {

            _employeeRepo = employeeRepo;
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Index()
        {
            var deps = _employeeRepo.GetAll();
            return View(deps);
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
