using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly MockEmployeeRepository _empRepo;

        public HomeController()
        {
            _empRepo = new MockEmployeeRepository();
        }

        public ViewResult Index()
        {
            var model = _empRepo.GetAllEmployee();

            return View(model);
        }

        public ViewResult Details(int Id)
        {
            var model = _empRepo.GetEmployee(Id);
            var _empVM = new EmployeeViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Department = model.Department
            };

            return View(_empVM);
        }

        [HttpGet]
        public ViewResult Edit(int? Id)
        {
            if (Id == null)
            {
                return View(new Employee());
            }

            var empModel = _empRepo.GetEmployee(Id.Value);
            if (empModel == null)
            {
                return View("NotFound");
            }
            return View(empModel);
        }

        [HttpPost]
        public IActionResult Edit(Employee employeeModel)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeModel);
            }
            if (employeeModel.Id > 0)
            {
             _empRepo.Update(employeeModel);
            }
            else
            {
             _empRepo.Add(employeeModel);
            }

            return RedirectToAction("Index");

           }

        [HttpGet]
        public IActionResult Delete (int Id)
        {
            var employee = _empRepo.GetEmployee(Id);
            if (employee == null)
            {
                return NotFound();
            }

            var employeeVM = new EmployeeViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department
            };

            return View(employeeVM);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int Id)
        {

            var deletedEmployee = _empRepo.Remove(Id);
            if (deletedEmployee == null)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }


    }
}
