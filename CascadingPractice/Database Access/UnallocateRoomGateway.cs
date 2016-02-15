using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CascadingPractice.Database_Access
{
    public class UnallocateRoomGateway
    {
        private static string connectionString = WebConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        SqlConnection connection = new SqlConnection(connectionString);

        public void UnallocateRoom()
        {
            string query = "UPDATE AllocateRoom SET isDeleted=1 WHERE isDeleted=0";
            SqlCommand updateCommand=new SqlCommand(query,connection);

            connection.Open();
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}