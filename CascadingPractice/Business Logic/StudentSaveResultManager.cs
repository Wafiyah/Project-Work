using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CascadingPractice.Database_Access;
using CascadingPractice.Models;

namespace CascadingPractice.Business_Logic
{
    public class StudentSaveResultManager
    {
        StudentSaveResultGateway gateway = new StudentSaveResultGateway();
        private List<SaveResult> saveResultObj;

        public List<SaveResult> StudentRegList()
        {
            saveResultObj = gateway.LoadAllReg();

            return saveResultObj;
        }

        public List<SaveResult> StudentInfoList()
        {
            List<SaveResult> enrollObj = gateway.LoadStudentInfo();
            return enrollObj;
        }

        public List<SaveResult> CourseList()
        {
            List<SaveResult> enrollObj = gateway.LoadCourseName();
            return enrollObj;
        }

        public string Save(SaveResult saveResultObj)
        {
            bool check = IsStudentEnrollThisCourse(saveResultObj);
            if (!check)
            {
                string message = gateway.SaveResult(saveResultObj);
                return message;
            }

            return "Result for that Particular Course Already Exists";
        }

        private bool IsStudentEnrollThisCourse(SaveResult saveResultObj)
        {
            bool check = gateway.IsStudentResultExistInThisCourse(saveResultObj);
            if (check)
                return true;
            return false;
        }
    }
}