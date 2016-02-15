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
    public class StudentCourseEnrollGateway
    {
        private static string connectionString = WebConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        public List<Enroll> LoadAllRegNo()
        {
            string query = "Select StudentID, RegNo, DepartmentID from Student";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            List<Enroll> students = new List<Enroll>();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Enroll student = new Enroll();
                    student.StudentId = Convert.ToInt32(reader["StudentID"].ToString());
                    student.RegNo = reader["RegNo"].ToString();
                    student.DepartmentId = Convert.ToInt32(reader["DepartmentID"].ToString());

                    students.Add(student);
                }
                reader.Close();
            }

            catch (Exception e)
            {
                connection.Close();
                throw e;
            }

            connection.Close();
            return students;
        }

        public List<Enroll> LoadStudentInfo()
        {
            string query = "Select S.StudentID, S.StudentName,S.RegNo,S.StudentEmail,S.DepartmentID,D.DepartmentName from Student S, Department D where S.DepartmentID=D.DepartmentID ";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            List<Enroll> students = new List<Enroll>();
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Enroll student = new Enroll();
                    student.StudentId = Convert.ToInt32(reader["StudentID"].ToString());
                    student.RegNo = reader["RegNo"].ToString();
                    student.StudentEmail = reader["StudentEmail"].ToString();
                    student.StudentName = reader["StudentName"].ToString();
                    student.StudentDepartment = reader["DepartmentName"].ToString();
                    student.DepartmentId = Convert.ToInt32(reader["DepartmentID"].ToString());

                    students.Add(student);
                }

                reader.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                throw e;
            }

            connection.Close();
            return students;
        }

        public List<Enroll> LoadCourseName()
        {
            string query = "Select * from Course";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            List<Enroll> students = new List<Enroll>();

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Enroll student = new Enroll();
                    student.DepartmentId = Convert.ToInt32(reader["DepartmentID"].ToString());
                    student.CourseId = Convert.ToInt32(reader["CourseId"].ToString());
                    student.CourseName = reader["CourseName"].ToString();

                    students.Add(student);
                }

                reader.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                throw e;
            }

            connection.Close();
            return students;
        }

        public string InsertEnrolment(Enroll enrollObj)
        {
            string query = "Insert into Enroll values(@courseId, @studentId,@enrollDate,@isDeleted)";
            SqlCommand insertCommand = new SqlCommand(query, connection);

            insertCommand.Parameters.Clear();

            insertCommand.Parameters.Add("courseId", SqlDbType.Int);
            insertCommand.Parameters["courseId"].Value = enrollObj.CourseId;

            insertCommand.Parameters.Add("studentId", SqlDbType.Int);
            insertCommand.Parameters["studentId"].Value = enrollObj.StudentId;

            insertCommand.Parameters.Add("enrollDate", SqlDbType.Date);
            insertCommand.Parameters["enrollDate"].Value = enrollObj.EnrollDate;

            insertCommand.Parameters.Add("isDeleted", SqlDbType.Bit);
            insertCommand.Parameters["isDeleted"].Value = 0;

            connection.Open();

            try
            {
                int rowAffected = insertCommand.ExecuteNonQuery();
                connection.Close();
                if (rowAffected > 0)
                    return "Saved Successfully";
                return "Saved Failed";
            }
            catch (Exception e)
            {

                throw e;
            }


        }

        public bool IsStudentEnrollThisCourse(Enroll enrollObj)
        {

            string query = "Select * from Enroll where StudentID=@studentId and CourseID=@courseId and isDeleted='False'";
            SqlCommand checkCommand = new SqlCommand(query, connection);

            checkCommand.Parameters.Clear();
            checkCommand.Parameters.Add("courseId", SqlDbType.Int);
            checkCommand.Parameters["courseId"].Value = enrollObj.CourseId;

            checkCommand.Parameters.Add("studentId", SqlDbType.Int);
            checkCommand.Parameters["studentId"].Value = enrollObj.StudentId;

            connection.Open();
            try
            {
                SqlDataReader reader = checkCommand.ExecuteReader();

                if (reader.Read())
                {
                    connection.Close();
                    reader.Close();
                    return true;
                }
                reader.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                throw e;
            }

            connection.Close();

            return false;
        }
    }
}