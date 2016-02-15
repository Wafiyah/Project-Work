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
    public class SaveResultController : Controller
    {
        StudentSaveResultManager manage = new StudentSaveResultManager();

        public ActionResult Index()
        {
            ViewBag.regList = manage.StudentRegList();
            ViewBag.gradeList = Grade();
            return View();
        }

        private List<string> Grade()
        {
            List<string> gradeList = new List<string>
            {
                 "A+", "A", "A-", "B+", "B-", "C+", "C", "C-", "D+", "D", "D-", "F"
            };
            return gradeList;
        }

        [HttpPost]
        public ActionResult Index(SaveResult saveResultObj)
        {
            ViewBag.regList = manage.StudentRegList();
            ViewBag.gradeList = Grade();
            ViewBag.saveMessage = manage.Save(saveResultObj);
            return View();
        }

        public JsonResult GetStudentInfo(int studentId)
        {
            var student = manage.StudentInfoList();
            var studentInfoList = student.Where(a => a.StudentId == studentId).ToList();
            return Json(studentInfoList, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetCourse(int studentId)
        {
            var course = manage.CourseList();
            //var courseName = course.Where(a => a.StudentId == studentId).ToList();
            List<SaveResult> courseList = new List<SaveResult>();
            foreach (SaveResult saveResult in course)
            {
                if (saveResult.StudentId == studentId)
                {
                    courseList.Add(saveResult);
                }
            }
            if (courseList.Count != 0)
                return Json(courseList, JsonRequestBehavior.AllowGet);
            List<SaveResult> message = new List<SaveResult>
            {
                new SaveResult{CourseName = "The Student didn't enroll in any course "}
            };
            return Json(message, JsonRequestBehavior.AllowGet);
            ViewBag.noCourseMesage = "No Course Found";
            //return Json(courseName, JsonRequestBehavior.AllowGet);
        }
    }
}