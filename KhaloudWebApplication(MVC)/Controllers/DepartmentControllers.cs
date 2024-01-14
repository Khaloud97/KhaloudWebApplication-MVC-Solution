using KhaloudWebApplication_MVC_.BLL.Interface;
using KhaloudWebApplication_MVC_.DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace KhaloudWebApplication_MVC_.Controllers
{
    public class DepartmentControllers : Controller
    {
        private readonly IDepartmentReposatory _departmentRepo;

        public DepartmentControllers(IDepartmentReposatory departmentrepo)
        {

            _departmentRepo = departmentrepo;
        }
       
        public IActionResult Index()
        {
            ViewBag.massage = "Hello from Action";
            ViewData["Msg"] = "Hello from ViewData";
           
            var deps = _departmentRepo.GetAll();
            return View(deps);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var dep = _departmentRepo.Get(id.Value);
            return View(dep);

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department dep)
        {
            if (ModelState.IsValid)
            {
                _departmentRepo.Create(dep);
                TempData["success"] = "Added Successfully";
                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Update(int id)
        {
            var dep = _departmentRepo.Get(id);

            return View();
        }

        [HttpPost]
        public IActionResult Update(Department dep)
        {
            if(ModelState.IsValid) {
                _departmentRepo.Update(dep);

                return RedirectToAction("Index");
            }
            return View();

        }
        public IActionResult Delete(int id)
        {
           
             var dep = _departmentRepo.Get(id);
            _departmentRepo.Delete(dep);
             return RedirectToAction("Index");
        }

    }
}