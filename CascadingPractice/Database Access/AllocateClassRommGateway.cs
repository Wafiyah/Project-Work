using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using CascadingPractice.Models;

namespace CascadingPractice.Database_Access
{
    public class AllocateClassRommGateway
    {
        private static string connectionString = WebConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        public List<AllocateClassRoom> LoadAllDepartment()
        {
            string query = "SELECT * FROM Department";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<AllocateClassRoom> departmentList = new List<AllocateClassRoom>();
            while (reader.Read())
            {
                AllocateClassRoom departmet = new AllocateClassRoom();
                departmet.DepartmentId = Convert.ToInt32(reader["DepartmentID"].ToString());
                departmet.DepartmentName = reader["DepartmentName"].ToString();

                departmentList.Add(departmet);
            }
            reader.Close();
            connection.Close();
            return departmentList;

        }

        public List<AllocateClassRoom> LoadAllCourseByDepartmet()
        {
            string query = "SELECT * FROM Course";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<AllocateClassRoom> courseList = new List<AllocateClassRoom>();
            while (reader.Read())
            {
                AllocateClassRoom course = new AllocateClassRoom();
                course.CourseId = Convert.ToInt32(reader["CourseID"].ToString());
                course.CourseName = reader["CourseName"].ToString();
                course.DepartmentId = Convert.ToInt32(reader["DepartmentID"].ToString());

                courseList.Add(course);
            }
            reader.Close();
            connection.Close();
            return courseList;

        }

        public List<AllocateClassRoom> LoadAllRoom()
        {
            string query = "SELECT * FROM Room";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<AllocateClassRoom> roomList = new List<AllocateClassRoom>();
            while (reader.Read())
            {
                AllocateClassRoom roomObj = new AllocateClassRoom();
                roomObj.RoomId = Convert.ToInt32(reader["RoomID"].ToString());
                roomObj.RoomName = reader["RoomName"].ToString();

                roomList.Add(roomObj);
            }
            reader.Close();
            connection.Close();
            return roomList;

        }

        public string SaveAllocation(AllocateClassRoom allocateClassRoomObj)
        {
            string query = "INSERT INTO AllocateRoom VALUES (@deptId,@courseId,@roomId,@day,@isDeleted,@allocTimeFrom,@allocTimeTo)";
            SqlCommand insertCommand = new SqlCommand(query, connection);

            insertCommand.Parameters.Clear();

            insertCommand.Parameters.Add("deptId", SqlDbType.Int);
            insertCommand.Parameters["deptId"].Value = allocateClassRoomObj.DepartmentId;

            insertCommand.Parameters.Add("courseId", SqlDbType.Int);
            insertCommand.Parameters["courseId"].Value = allocateClassRoomObj.CourseId;

            insertCommand.Parameters.Add("roomId", SqlDbType.Int);
            insertCommand.Parameters["roomId"].Value = allocateClassRoomObj.RoomId;

            insertCommand.Parameters.Add("day", SqlDbType.VarChar);
            insertCommand.Parameters["day"].Value = allocateClassRoomObj.Day;

            insertCommand.Parameters.Add("isDeleted", SqlDbType.Bit);
            insertCommand.Parameters["isDeleted"].Value = 0;

            insertCommand.Parameters.Add("allocTimeFrom", SqlDbType.DateTime);
            insertCommand.Parameters["allocTimeFrom"].Value = allocateClassRoomObj.StartTime;

            insertCommand.Parameters.Add("allocTimeTo", SqlDbType.DateTime);
            insertCommand.Parameters["allocTimeTo"].Value = allocateClassRoomObj.EndTime;

            connection.Open();

            int rowAffected = insertCommand.ExecuteNonQuery();
            connection.Close();
            if (rowAffected > 0)
                return "Saved Successfully";
            return "Saved Failed";
        }

        public List<AllocateClassRoom> CheckTimeOverlapping(string day, int roomId)
        {
            string query = "SELECT AllocTimeFrom, AllocTimeTo FROM AllocateRoom where RoomAllocDay=@day and RoomID=@roomId";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.Clear();

            command.Parameters.Add("day", SqlDbType.VarChar);
            command.Parameters["day"].Value = day;

            command.Parameters.Add("roomId", SqlDbType.Int);
            command.Parameters["roomId"].Value = roomId;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<AllocateClassRoom> timeList = new List<AllocateClassRoom>();
            while (reader.Read())
            {
                AllocateClassRoom roomObj = new AllocateClassRoom();

                roomObj.STime = (TimeSpan)(reader["AllocTimeFrom"]);
                roomObj.ETime = (TimeSpan)(reader["AllocTimeTo"]);

                timeList.Add(roomObj);
            }
            reader.Close();
            connection.Close();
            return timeList;

        }
    }
}