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
    public class StudentSaveResultGateway
    {
        private static string connectionString = WebConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

       public List<SaveResult> LoadAllReg()
        {
            string query = "Select StudentID, RegNo, DepartmentID from Student";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<SaveResult> students = new List<SaveResult>();
            while (reader.Read())
            {
                SaveResult student = new SaveResult();
                student.StudentId = Convert.ToInt32(reader["StudentID"].ToString());
                student.RegNo = reader["RegNo"].ToString();
                student.DepartmentId = Convert.ToInt32(reader["DepartmentID"].ToString());

                students.Add(student);
            }

            reader.Close();
            connection.Close();
            return students;
        }
       public List<SaveResult> LoadStudentInfo()
       {
           string query = "Select S.StudentID, S.StudentName,S.RegNo,S.StudentEmail,S.DepartmentID,D.DepartmentName from Student S, Department D where S.DepartmentID=D.DepartmentID ";
           SqlCommand command = new SqlCommand(query, connection);

           connection.Open();
           SqlDataReader reader = command.ExecuteReader();

           List<SaveResult> students = new List<SaveResult>();
           while (reader.Read())
           {
               SaveResult student = new SaveResult();
               student.StudentId = Convert.ToInt32(reader["StudentID"].ToString());
               student.RegNo = reader["RegNo"].ToString();
               student.StudentEmail = reader["StudentEmail"].ToString();
               student.StudentName = reader["StudentName"].ToString();
               student.Department = reader["DepartmentName"].ToString();
               student.DepartmentId = Convert.ToInt32(reader["DepartmentID"].ToString());

               students.Add(student);
           }

           reader.Close();
           connection.Close();
           return students;
       }

       public List<SaveResult> LoadCourseName()
       {
           string query = "Select C.CourseName, E.StudentID from Enroll E INNER JOIN Course C ON E.CourseID=C.CourseID ";
           SqlCommand command = new SqlCommand(query, connection);

           connection.Open();
           SqlDataReader reader = command.ExecuteReader();

           List<SaveResult> students = new List<SaveResult>();
           while (reader.Read())
           {
              SaveResult student = new SaveResult();
              student.StudentId = Convert.ToInt32(reader["StudentID"].ToString());
              student.CourseName = reader["CourseName"].ToString();

               students.Add(student);
           }

           reader.Close();
           connection.Close();
           return students;
       }

       public string SaveResult(SaveResult saveResultObj)
       {
           string query = "Insert into Result values(@regNo,@name, @mail,@deptName,@courseName,@grade)";
           SqlCommand insertCommand = new SqlCommand(query, connection);

           insertCommand.Parameters.Clear();

           insertCommand.Parameters.Add("regNo", SqlDbType.VarChar);
           insertCommand.Parameters["regNo"].Value = saveResultObj.RegNo;

           insertCommand.Parameters.Add("name", SqlDbType.VarChar);
           insertCommand.Parameters["name"].Value = saveResultObj.StudentName;

           insertCommand.Parameters.Add("mail", SqlDbType.VarChar);
           insertCommand.Parameters["mail"].Value = saveResultObj.StudentEmail;

           insertCommand.Parameters.Add("deptName", SqlDbType.VarChar);
           insertCommand.Parameters["deptName"].Value = saveResultObj.Department;

           insertCommand.Parameters.Add("courseName", SqlDbType.VarChar);
           insertCommand.Parameters["courseName"].Value = saveResultObj.CourseName;

           insertCommand.Parameters.Add("grade", SqlDbType.VarChar);
           insertCommand.Parameters["grade"].Value = saveResultObj.Grade;

           connection.Open();

           int rowAffected = insertCommand.ExecuteNonQuery();
           connection.Close();
           if (rowAffected > 0)
               return "Saved Successfully";
           return "Saved Failed";
       }

        public bool IsStudentResultExistInThisCourse(SaveResult saveResultObj) 
        {
            string query = "Select * from Result where StudentRegNo=@regNo and CourseName=@courseName";
            SqlCommand checkCommand = new SqlCommand(query, connection);

            checkCommand.Parameters.Clear();
            checkCommand.Parameters.Add("regNo", SqlDbType.VarChar);
            checkCommand.Parameters["regNo"].Value = saveResultObj.RegNo;

            checkCommand.Parameters.Add("courseName", SqlDbType.VarChar);
            checkCommand.Parameters["courseName"].Value = saveResultObj.CourseName;

            connection.Open();
            SqlDataReader reader = checkCommand.ExecuteReader();

            if (reader.Read())
            {
                connection.Close();
                reader.Close();
                return true;
            }
            connection.Close();
            reader.Close();
            return false;
        }
    }
}