using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.Remoting.Contexts;
using System.Data.SqlClient;

namespace LibraryManagementSystem
{
    public partial class Dashboard: UserControl
    {
        public Dashboard()
        {
            InitializeComponent();

            displayAB();
            displayIB();
            displayRB();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            displayAB();
            displayIB();
            displayRB();
        }

        public void displayAB()
        {
            try
            {
                using (MySqlConnection connect = Database.GetConnection()) // Already opened connection
                {
                    string selectData = "SELECT COUNT(id) FROM books WHERE status = 'Available' AND date_delete IS NULL";

                    using (MySqlCommand cmd = new MySqlCommand(selectData, connect))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int tempAB = 0;

                            if (reader.Read())
                            {
                                tempAB = Convert.ToInt32(reader[0]);
                                dashboard_AB.Text = tempAB.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void displayIB()
        {
            try
            {
                using (MySqlConnection connect = Database.GetConnection()) // Already opened connection
                {
                    string selectData = "SELECT COUNT(id) FROM issues WHERE date_delete IS NULL";

                    using (MySqlCommand cmd = new MySqlCommand(selectData, connect))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int tempIB = 0;

                            if (reader.Read())
                            {
                                tempIB = Convert.ToInt32(reader[0]);
                                dashboard_IB.Text = tempIB.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void displayRB()
        {
            try
            {
                using (MySqlConnection connect = Database.GetConnection()) // Already opened connection
                {
                    string selectData = "SELECT COUNT(id) FROM issues WHERE status = 'Return' AND date_delete IS NULL";

                    using (MySqlCommand cmd = new MySqlCommand(selectData, connect))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int tempRB = 0;

                            if (reader.Read())
                            {
                                tempRB = Convert.ToInt32(reader[0]);
                                dashboard_RB.Text = tempRB.ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
