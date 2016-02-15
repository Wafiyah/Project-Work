using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CascadingPractice.Business_Logic;
using CascadingPractice.Models;

namespace CascadingPractice.Controllers
{
    public class EnrollController : Controller
    {
        //
        // GET: /Enroll/
       StudentCourseEnrollManager manage = new StudentCourseEnrollManager();
        public ActionResult Index()
        {
            ViewBag.getRegNo = manage.StudentRegList();
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(Enroll enrollObj)
        {
            ViewBag.getRegNo = manage.StudentRegList();
            ViewBag.insert = manage.Save(enrollObj);
            return View();
        }

        public JsonResult GetStudentInfo(int departmentId)
        {
            var student = manage.StudentInfoList();
            var studentInfoList = student.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(studentInfoList, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetCourse(int departmentId)
        {
            var course = manage.CourseList();
            var courseName = course.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(courseName, JsonRequestBehavior.AllowGet);
        }
	}
}