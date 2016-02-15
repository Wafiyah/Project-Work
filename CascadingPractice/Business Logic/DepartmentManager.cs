using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CascadingPractice.Database_Access;
using CascadingPractice.Models;

namespace CascadingPractice.Business_Logic
{
    public class DepartmentManager
    {
        DepartmentGateWay gateWay = new DepartmentGateWay();

        public string SaveDepartment(Department departmentObj)
        {
            bool checkName = IsDepartmentNameExist(departmentObj.DepartmentName);
            bool checkCode = IsDepartmentCodeExist(departmentObj.DepartmentCode);

            if (checkName && checkCode)
                return "Department Name and Code Already Exists";

            else if (checkName)
                return "Department Name Already Exists";

            else if (checkCode)
                return "Department Code Already Exists";

            else
            {
                string message = gateWay.SaveDepartment(departmentObj);
                return message;
            }
        }

        private bool IsDepartmentNameExist(string departmentName)
        {
            bool check = gateWay.CheckDepartmentName(departmentName);
            if (check)
                return true;
            return false;
        }

        private bool IsDepartmentCodeExist(string departmentCode)
        {
            bool check = gateWay.CheckDepartmentCode(departmentCode);
            if (check)
                return true;
            return false;
        }

        public List<Department> GetAllDepartmentInfo()
        {
            List<Department> departmentInfoList = gateWay.GetAllDepartmentInfo();
            return departmentInfoList;
        }
    }
}