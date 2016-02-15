using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CascadingPractice.Business_Logic;
using CascadingPractice.Database_Access;
using CascadingPractice.Models;

namespace CascadingPractice.Controllers
{
    public class SaveCourseController : Controller
    {
        //
        // GET: /SaveCourse/
        SaveCourseManager manager=new SaveCourseManager();
        public ActionResult SaveCourse()
        {
            ViewBag.departmentList = manager.departmentList();
            ViewBag.Semester = GetSemester();
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(Course courseObj)
        {
            ViewBag.departmentList = manager.departmentList();
            ViewBag.Semester = GetSemester();
            ViewBag.Savemessage = manager.SaveCourse(courseObj);
            return View();
        }
        private List<int> GetSemester()
        {
            List<int> semesterList = new List<int>
            {
                 1,2,3,4,5,6,7,8
            };
            return semesterList;
        }
	}


}