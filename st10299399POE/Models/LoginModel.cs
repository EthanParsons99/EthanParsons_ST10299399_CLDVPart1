﻿using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace st10299399POE.Models
{
    public class LoginModel
    {
        public static string con_string = "Server=tcp:ethan1-sql-server.database.windows.net,1433;Initial Catalog=ethan1-sql-database;Persist Security Info=False;User ID=EthanP1;Password=Landfour66;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";


        public int SelectUser(string email, string name)
        {
            int userId = -1; 
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT userID FROM userTable WHERE userEmail = @Email AND userName = @Name";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Name", name);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return userId;
        }
    }
}

