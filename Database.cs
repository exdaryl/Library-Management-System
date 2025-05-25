using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace LibraryManagementSystem
{
    public static class Database
    {

        private static string connectionString = "Server=localhost;Database=library;User ID=your_DB_username;Password=your_DB_password;";

        // This method ensures a new connection is returned and properly managed
        public static MySqlConnection GetConnection()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            try
            {
                if (conn.State == ConnectionState.Closed) // Only open if closed
                {
                    conn.Open();
                }
                return conn;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Connection Error: " + ex.Message);
                return null; // Return null if the connection fails
            }
        }

    }
}
