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
    public class DepartmentGateWay
    {

        private static string connectionString = WebConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        public string SaveDepartment(Department departmentObj)
        {
            string query = "INSERT INTO Department VALUES(@departmentCode, @departmentName)";
            SqlCommand insertCommand = new SqlCommand(query, connection);

            insertCommand.Parameters.Clear();

            insertCommand.Parameters.Add("departmentCode", SqlDbType.VarChar);
            insertCommand.Parameters["departmentCode"].Value = departmentObj.DepartmentCode;

            insertCommand.Parameters.Add("departmentName", SqlDbType.VarChar);
            insertCommand.Parameters["departmentName"].Value = departmentObj.DepartmentName;

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

        public List<Department> GetAllDepartmentInfo()
        {

            string query = "SELECT * FROM Department";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();

            List<Department> departmetList = new List<Department>();

            try
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Department departmentObj = new Department();
                    departmentObj.DepartmentCode = reader["DepartmentCode"].ToString();
                    departmentObj.DepartmentName = reader["DepartmentName"].ToString();

                    departmetList.Add(departmentObj);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                connection.Close();
                throw e;
            }

            connection.Close();
            return departmetList;
        }

        public bool CheckDepartmentName(string departmentName)
        {
            string query = "SELECT * FROM Department WHERE DepartmentName='" + departmentName + "'";
            SqlCommand command=new SqlCommand(query,connection);

            connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    connection.Close();
                     return true;
                }
            }
            catch (Exception e)
            {
                connection.Close();
                throw e;
            }
            connection.Close();
            return false;
        }

        public bool CheckDepartmentCode(string departmentCode)
        {
            string query = "SELECT * FROM Department WHERE DepartmentCode='" + departmentCode + "'";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    connection.Close();
                    return true;
                }           
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