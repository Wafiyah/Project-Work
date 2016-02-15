using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CascadingPractice.Business_Logic;
using CascadingPractice.Models;

namespace CascadingPractice.Controllers
{
    public class AllocateClassroomController : Controller
    {
        //
        // GET: /AllocateClassroom/
        AllocateClassRoomManager manage = new AllocateClassRoomManager();
        public ActionResult Index()
        {
            ViewBag.departmentlist = manage.LoadDepartment();
            ViewBag.roomList = manage.LoadRoom();
            ViewBag.dayLilst = GetDay();
            return View();
        }

        private List<string> GetDay()
        {
            List<string> dayList = new List<string>
            {
                 "Saturday","Sunday","Monday","Tuesday","Wednesday","Thusday"
              };
            return dayList;
        }

        [HttpPost]
        public ActionResult Index(AllocateClassRoom obj)
        {
            string startTime = obj.StartTime +" "+ obj.FromAmPm;
            string endTime = obj.EndTime + " " + obj.ToAmPm;

            obj.StartTime = startTime;
            obj.EndTime = endTime;

            ViewBag.departmentlist = manage.LoadDepartment();
            ViewBag.roomList = manage.LoadRoom();
            ViewBag.dayLilst = GetDay();
            ViewBag.Savemessage = manage.SaveAllocation(obj);
            return View();
        }

        public JsonResult GetCourseByCourseID(int departmentId)
        {
            var course = manage.CourseLoad();
            var courseName = course.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(courseName, JsonRequestBehavior.AllowGet);
        }
    }
}