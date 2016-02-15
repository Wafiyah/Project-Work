using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CascadingPractice.Business_Logic;
using CascadingPractice.Models;

namespace CascadingPractice.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager manage=new DepartmentManager();
        
        [HttpGet]
        public ActionResult ViewDepartment()
        {
            ViewBag.departmentList = manage.GetAllDepartmentInfo(); ;
            return View();
        }


        public ActionResult SaveDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveDepartment(Department departmentObj)
        {
           
            ViewBag.SaveDepartment = manage.SaveDepartment(departmentObj);
            return View();
        }

	}
}