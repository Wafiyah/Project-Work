using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CascadingPractice.Database_Access;
using CascadingPractice.Models;

namespace CascadingPractice.Business_Logic
{
    public class SaveCourseManager
    {
        SaveCourseGateWay gateWay=new SaveCourseGateWay();
        public List<Course> departmentList()
        {
            List<Course> departmentlist = gateWay.LoadDepartment();
            return departmentlist;
        }

        public string SaveCourse(Course courseObj)
        {

            string message = gateWay.SaveCourse(courseObj);
            return message;
        }
    }
}