using DemoApp2._2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp2._2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public string Index()
        {
            //return "Hello from Home Controller";
            return _employeeRepository.GetEmployee(1).Name;
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

        public ViewResult Details()
        {
            Employee empModel = _employeeRepository.GetEmployee(1);
            ViewData["Employee"] = empModel;
            ViewData["PageTitle"] = "Employee Detais";

            return View(empModel);
            //return View();
        }
    }
}
