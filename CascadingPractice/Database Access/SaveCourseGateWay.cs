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
    public class SaveCourseGateWay
    {
        private static string connectionString = WebConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        public List<Course> LoadDepartment()
        {
            string query = "SELECT * FROM Department";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            List<Course> departmentList = new List<Course>();

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Course departmets = new Course();
                    departmets.DepartmentId = Convert.ToInt32(reader["DepartmentID"].ToString());
                    departmets.Department = reader["DepartmentName"].ToString();

                    departmentList.Add(departmets);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                throw e;
            }

            connection.Close();
            return departmentList;
        }

        public string SaveCourse(Course courseObj)
        {
            string query = "INSERT INTO Course VALUES (@code, @name,@credit,@description,@deptID,@semesetr)";
            SqlCommand insertCommand = new SqlCommand(query, connection);

            insertCommand.Parameters.Clear();

            insertCommand.Parameters.Add("code", SqlDbType.VarChar);
            insertCommand.Parameters["code"].Value = courseObj.CourseCode;

            insertCommand.Parameters.Add("name", SqlDbType.VarChar);
            insertCommand.Parameters["name"].Value = courseObj.CourseName;

            insertCommand.Parameters.Add("credit", SqlDbType.Decimal);
            insertCommand.Parameters["credit"].Value = courseObj.Credit;

            insertCommand.Parameters.Add("description", SqlDbType.VarChar);
            insertCommand.Parameters["description"].Value = courseObj.Description;

            insertCommand.Parameters.Add("deptID", SqlDbType.Int);
            insertCommand.Parameters["deptID"].Value = courseObj.DepartmentId;

            insertCommand.Parameters.Add("semesetr", SqlDbType.Int);
            insertCommand.Parameters["semesetr"].Value = courseObj.Semester;

            connection.Open();

            int rowAffected = insertCommand.ExecuteNonQuery();
            connection.Close();
            if (rowAffected > 0)
                return "Saved Successfully";
            return "Saved Failed";
        }
    }
}