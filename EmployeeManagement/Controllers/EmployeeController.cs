using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.Models;
using System.Linq;
using EmployeeManagement.ViewModels;
using System.Collections.Generic;



namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly MockEmployeeRepository _empRepo;

        public EmployeeController()
        {
            _empRepo = new MockEmployeeRepository();
        }
        public IActionResult Index()
        {
            ViewData["Message"] = "Welcome to Employee Management!";
            ViewBag.TotalEmployees = _empRepo.GetAllEmployee().Count();

            var employees = new List<EmployeeViewModel>
    {
        new EmployeeViewModel { Id = 1, Name = "Alice Johnson", Email = "alice@example.com"},
        new EmployeeViewModel { Id = 2, Name = "Bob Williams", Email = "bob@example.com" },
        new EmployeeViewModel { Id = 3, Name = "Charlie Brown", Email = "charlie@example.com" }
    };
            return View(employees);
        }


        public ActionResult Employeedata()
        {
            var employees = new List<EmployeeViewModel>
    {
        new EmployeeViewModel { Id = 1, Name = "Alice Johnson", Email = "alice@example.com"},
        new EmployeeViewModel { Id = 2, Name = "Bob Williams", Email = "bob@example.com" },
        new EmployeeViewModel { Id = 3, Name = "Charlie Brown", Email = "charlie@example.com" }
    };
            return View(employees);
       
        }
    }
}



