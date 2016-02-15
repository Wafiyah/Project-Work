using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CascadingPractice.Database_Access;

namespace CascadingPractice.Controllers
{
    public class UnAssignCourseController : Controller
    {
        //
        // GET: /UnAssignCourse/
        public ActionResult Index()
        {
            return View();
        }

        public void UnassignCourse()
        {
            UnAssignCourseGateWay gateWay=new UnAssignCourseGateWay();
            gateWay.UnAssignCourse();
            gateWay.UnAssignTeacher();
        }
	}
}