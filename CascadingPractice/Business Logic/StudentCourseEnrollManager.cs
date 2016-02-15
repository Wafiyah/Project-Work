using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CascadingPractice.Database_Access;
using CascadingPractice.Models;

namespace CascadingPractice.Business_Logic
{
    public class StudentCourseEnrollManager
    {
        StudentCourseEnrollGateway gateway = new StudentCourseEnrollGateway();

        public List<Enroll> StudentRegList()
        {
            List<Enroll> enrollObj = gateway.LoadAllRegNo();
            return enrollObj;
        }

        public List<Enroll> StudentInfoList()
        {
            List<Enroll> enrollObj = gateway.LoadStudentInfo();
            return enrollObj;
        }

        public List<Enroll> CourseList()
        {
            List<Enroll> enrollObj = gateway.LoadCourseName();
            return enrollObj;
        }

        public string Save(Enroll enrollObj)
        {
            bool check = IsStudentEnrollThisCourse(enrollObj);
            if (!check)
            {
                string message = gateway.InsertEnrolment(enrollObj);
                return message;
            }

            return "This Student Already Enroll this Course";

        }

        private bool IsStudentEnrollThisCourse(Enroll enrollObj)
        {
            bool check = gateway.IsStudentEnrollThisCourse(enrollObj);
            if (check)
                return true;
            return false;
        }
    }
}