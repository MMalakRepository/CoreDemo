using CoreDemo.Models;
using CoreDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeerepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeerepository = employeeRepository;
        }
        public ViewResult Index()
        {
            ViewBag.Title = _employeerepository.GetEmployee(1).Name + _employeerepository.GetEmployee(1).Department;
            return View();
        }

        public ViewResult Details(int? id)
        {
            var employee = _employeerepository.GetEmployee(id??1);
            EmployeeDataViewModel employeeDataViewModel = new EmployeeDataViewModel()
            {
                employee = employee,
                PageTitle = "New Page Title"
            };
            return View(employeeDataViewModel);
        }

        public ViewResult List()
        {
            var employees = _employeerepository.GetALlEmployees();
            return View(employees);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee e = _employeerepository.AddEmployee(employee);
                return RedirectToAction("Details", "Home", new { id = e.ID });
            }
            return View();
        }
    }
}
