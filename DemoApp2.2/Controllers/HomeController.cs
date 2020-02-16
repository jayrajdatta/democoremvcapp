using DemoApp2._2.Models;
using DemoApp2._2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp2._2.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        //public string Index()
        //{
        //    //return "Hello from Home Controller";
        //    return _employeeRepository.GetEmployee(1).Name;
        //}

        [Route("")]
        //[Route("Home")]
        //[Route("Home/Index")]
        [Route("[action]")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View(_employeeRepository.GetAllEmployees());
        }
        //public JsonResult Index()
        //{
        //    return Json(new { id=1, name="Jayraj"});
        //}

        //public JsonResult Details()
        //{
        //    Employee empModel = _employeeRepository.GetEmployee(1);
        //    return Json(empModel);
        //}

        //public ObjectResult Details()
        //{
        //    Employee empModel = _employeeRepository.GetEmployee(1);
        //    return new ObjectResult(empModel);
        //}
        //[Route("Home/Details/{id?}")]
        [Route("[action]/{id?}")]
        public ViewResult Details(int? id)
        {
            Employee empModel = _employeeRepository.GetEmployee(id ?? 1);
            ViewData["Employee"] = empModel;
            ViewData["PageTitle"] = "Employee Detais";

            return View(empModel);
            //return View();
        }

        [Route("[action]")]
        public ViewResult Information()
        {
            HomeDetailsViewModel modeldata = new HomeDetailsViewModel()
            {
                Employee = _employeeRepository.GetEmployee(2),
                PageTitle = "Employee Information"
            };

            return View(modeldata);
        }
    }
}
