using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using CascadingPractice.Database_Access;
using CascadingPractice.Models;

namespace CascadingPractice.Business_Logic
{
    public class AllocateClassRoomManager
    {
        AllocateClassRommGateway gateway = new AllocateClassRommGateway();

        public List<AllocateClassRoom> LoadDepartment()
        {
            List<AllocateClassRoom> departmentList = gateway.LoadAllDepartment();
            return departmentList;
        }

        public List<AllocateClassRoom> CourseLoad()
        {
            List<AllocateClassRoom> courseList = gateway.LoadAllCourseByDepartmet();
            return courseList;
        }

        public List<AllocateClassRoom> LoadRoom()
        {
            List<AllocateClassRoom> roomList = gateway.LoadAllRoom();
            return roomList;
        }

        public string SaveAllocation(AllocateClassRoom allocateClassRoomObj)
        {
            string startTime = allocateClassRoomObj.StartTime;
            bool check = TimeOverlapping(startTime, allocateClassRoomObj.Day, allocateClassRoomObj.RoomId);
            if (!check)
            {
                string message = gateway.SaveAllocation(allocateClassRoomObj);
                return message;
            }
            return "Not Possible";
        }

        private bool TimeOverlapping(string startTime, string day, int roomId)
        {
            TimeSpan starTime = (DateTime.ParseExact(startTime, "hh:mm tt", CultureInfo.InvariantCulture).TimeOfDay);

            List<AllocateClassRoom> allocateClassRoomList = gateway.CheckTimeOverlapping(day,roomId);

            foreach (var list in allocateClassRoomList)
            {
                if ((starTime > list.STime) && (starTime < list.ETime))
                    return true;
            }
            return false;
        }
    }
}