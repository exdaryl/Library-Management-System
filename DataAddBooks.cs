using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace LibraryManagementSystem
{
    class DataAddBooks
    {
        public int ID { set; get; }
        public string BookTitle { set; get; }
        public string Author { set; get; }
        public string Published { set; get; }
        public string Image { set; get; }
        public string Status { set; get; }

        public List<DataAddBooks> addBooksData()
        {

            List<DataAddBooks> listData = new List<DataAddBooks>();

            try
            {
                using (MySqlConnection conn = Database.GetConnection())
                {
                    if (conn == null)
                    {
                        Console.WriteLine("Database connection failed.");
                        return listData;
                    }

                    string selectData = "SELECT * FROM books WHERE date_delete IS NULL";
                    using (MySqlCommand cmd = new MySqlCommand(selectData, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listData.Add(new DataAddBooks
                            {
                                ID = reader.GetInt32("id"),
                                BookTitle = reader.GetString("book_title"),
                                Author = reader.GetString("author"),
                                Published = reader["published_date"].ToString(),
                                Image = reader["image"].ToString(),
                                Status = reader.GetString("status")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to Database: " + ex.Message);
            }

            Console.WriteLine("Total Books Found: " + listData.Count);
            return listData;
        }
    }
}
