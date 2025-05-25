using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Runtime.Remoting.Contexts;

namespace LibraryManagementSystem
{
    class DataIssueBooks
    {
        public int ID { set; get; }
        public string IssueID { set; get; }
        public string Name { set; get; }
        public string Contact { set; get; }
        public string Email { set; get; }
        public string BookTitle { set; get; }
        public string DateIssue { set; get; }
        public string DateReturn { set; get; }
        public string Status { set; get; }

        public List<DataIssueBooks> IssueBooksData()
        {
            List<DataIssueBooks> listData = new List<DataIssueBooks>();

            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    if (conn == null)
                    {
                        Console.WriteLine("Database connection failed.");
                        return listData;
                    }

                    string selectData = "SELECT * FROM issues WHERE date_delete IS NULL";
                    using (MySqlCommand cmd = new MySqlCommand(selectData, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listData.Add(new DataIssueBooks
                            {
                                ID = reader.GetInt32("id"),
                                IssueID = reader["issue_id"].ToString(),
                                Name = reader["full_name"].ToString(),
                                Contact = reader["contact"].ToString(),
                                Email = reader["email"].ToString(),
                                BookTitle = reader["book_title"].ToString(),
                                DateIssue = reader["issue_date"].ToString(),
                                DateReturn = reader["return_date"].ToString(),
                                Status = reader["status"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to Database: " + ex.Message);
            }
            return listData;
        }

        public List<DataIssueBooks> ReturnIssueBooksData()
        {
            List<DataIssueBooks> listData = new List<DataIssueBooks>();

            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    if (conn == null)
                    {
                        Console.WriteLine("Database connection failed.");
                        return listData;
                    }

                    string selectData = "SELECT * FROM issues WHERE status = 'Not Return' AND date_delete IS NULL";
                    using (MySqlCommand cmd = new MySqlCommand(selectData, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listData.Add(new DataIssueBooks
                            {
                                ID = reader.GetInt32("id"),
                                IssueID = reader["issue_id"].ToString(),
                                Name = reader["full_name"].ToString(),
                                Contact = reader["contact"].ToString(),
                                Email = reader["email"].ToString(),
                                BookTitle = reader["book_title"].ToString(),
                                DateIssue = reader["issue_date"].ToString(),
                                DateReturn = reader["return_date"].ToString(),
                                Status = reader["status"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to Database: " + ex.Message);
            }
            return listData;
        }

    }
}
