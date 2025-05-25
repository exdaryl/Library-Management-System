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
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.Net;

namespace LibraryManagementSystem
{
    public partial class IssueBooks: UserControl
    {
        public IssueBooks()
        {
            InitializeComponent();

            DataBookTitle();
            displayBookIssueData();            
        }

        public void RefreshIssuedBooksData()
        {
            displayBookIssueData();  // This will refresh the DataGridView with the latest data
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }
                      
            displayBookIssueData();
            DataBookTitle();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        public void displayBookIssueData()
        {
            DataIssueBooks dib = new DataIssueBooks();
            List<DataIssueBooks> listData = dib.IssueBooksData();

            dataGridView1.DataSource = listData;
        }

        private void bookIssue_addBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(bookIssue_id.Text) 
                || string.IsNullOrWhiteSpace(bookIssue_name.Text) 
                || string.IsNullOrWhiteSpace(bookIssue_contact.Text) 
                || string.IsNullOrWhiteSpace(bookIssue_email.Text) 
                || string.IsNullOrWhiteSpace(bookIssue_bookTitle.Text) 
                || string.IsNullOrWhiteSpace(bookIssue_status.Text) 
                || bookIssue_picture.Image == null)
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // using (var connect = Database.GetConnection()) // Get MySQL connection
            using (MySqlConnection connect = Database.GetConnection())
            {
                if (connect == null)
                {
                    MessageBox.Show("Database connection failed!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    DateTime today = DateTime.Today;

                    string insertData = "INSERT INTO issues (issue_id, full_name, contact, email, book_title, status, issue_date, return_date, date_insert) " +
                                        "VALUES (@issueID, @fullname, @contact, @email, @bookTitle, @status, @issueDate, @returnDate, @dateInsert)";

                    using (MySqlCommand cmd = new MySqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@issueID", bookIssue_id.Text.Trim());
                        cmd.Parameters.AddWithValue("@fullname", bookIssue_name.Text.Trim());
                        cmd.Parameters.AddWithValue("@contact", bookIssue_contact.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", bookIssue_email.Text.Trim());
                        cmd.Parameters.AddWithValue("@bookTitle", bookIssue_bookTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@status", bookIssue_status.Text.Trim());
                        cmd.Parameters.AddWithValue("@issueDate", bookIssue_issueDate.Value);
                        cmd.Parameters.AddWithValue("@returnDate", bookIssue_returnDate.Value);
                        cmd.Parameters.AddWithValue("@dateInsert", today);

                        cmd.ExecuteNonQuery();
                    }

                    displayBookIssueData(); // Refresh data
                    MessageBox.Show("Issued successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFields(); // Clear input fields
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void clearFields()
        {
            bookIssue_id.Text = "";
            bookIssue_name.Text = "";
            bookIssue_contact.Text = "";
            bookIssue_email.Text = "";
            bookIssue_bookTitle.SelectedIndex = -1;
            bookIssue_status.SelectedIndex = -1;
            bookIssue_picture.Image = null;
        }

        public void DataBookTitle()
        {
            using (MySqlConnection connect = Database.GetConnection())
            {
                try
                {
                    if (connect.State != ConnectionState.Open)
                    {
                        connect.Open(); // Only open if it's not already open
                    }

                    string selectData = "SELECT id, book_title FROM books WHERE status = 'Available' AND date_delete IS NULL";

                    using (MySqlCommand cmd = new MySqlCommand(selectData, connect))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        if (table.Rows.Count > 0)
                        {
                            // Rebind the ComboBox only if there’s new data
                            bookIssue_bookTitle.DataSource = table;
                            bookIssue_bookTitle.DisplayMember = "book_title";
                            bookIssue_bookTitle.ValueMember = "id";

                            // Optional: Keep the selected index the same if it was previously set
                            if (bookIssue_bookTitle.SelectedIndex == -1) // If no item was selected previously
                            {
                                bookIssue_bookTitle.SelectedIndex = 0; // Select first item
                            }
                        }
                        else
                        {
                            // No available books, so clear the ComboBox
                            bookIssue_bookTitle.DataSource = null;
                            bookIssue_bookTitle.Items.Clear();
                            // Optionally, show a message to indicate no available books
                            // MessageBox.Show("No available books found!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bookIssue_bookTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bookIssue_bookTitle.SelectedItem is DataRowView selectedRow)
            {
                int selectID = Convert.ToInt32(selectedRow["id"]);

                using (MySqlConnection connect = Database.GetConnection())
                {
                    try
                    {
                        if (connect.State == ConnectionState.Closed)
                        {
                            connect.Open(); // Open only if it's closed
                        }
                        
                        string selectData = "SELECT image FROM books WHERE id = @id";

                        using (MySqlCommand cmd = new MySqlCommand(selectData, connect))
                        {
                            cmd.Parameters.AddWithValue("@id", selectID);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    // Display book cover in PictureBox
                                    if (!(reader["image"] is DBNull))
                                    {
                                        string imagePath = reader["image"].ToString();
                                        if (File.Exists(imagePath)) // Ensure file exists
                                        {
                                            bookIssue_picture.Image = Image.FromFile(imagePath);
                                        }
                                        else
                                        {
                                            bookIssue_picture.Image = null; // If file not found, clear picture
                                        }
                                    }
                                    else
                                    {
                                        bookIssue_picture.Image = null; // If no image, clear picture
                                    }
                                }
                                else
                                {
                                    bookIssue_picture.Image = null;
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

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                bookIssue_id.Text = row.Cells[1].Value.ToString();
                bookIssue_name.Text = row.Cells[2].Value.ToString();
                bookIssue_contact.Text = row.Cells[3].Value.ToString();
                bookIssue_email.Text = row.Cells[4].Value.ToString();
                bookIssue_bookTitle.Text = row.Cells[5].Value.ToString();

                // Use Convert.ToDateTime and handle DBNull values
                bookIssue_issueDate.Value = row.Cells[6].Value != DBNull.Value ? Convert.ToDateTime(row.Cells[6].Value) : DateTime.Today; // Fallback to today's date if DBNull

                bookIssue_returnDate.Value = row.Cells[7].Value != DBNull.Value ? Convert.ToDateTime(row.Cells[7].Value) : DateTime.Today; // Fallback to today's date if DBNull

                bookIssue_status.Text = row.Cells[8].Value.ToString();
            }
        }

        private void bookIssue_updateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(bookIssue_id.Text)
                || string.IsNullOrWhiteSpace(bookIssue_name.Text)
                || string.IsNullOrWhiteSpace(bookIssue_contact.Text)
                || string.IsNullOrWhiteSpace(bookIssue_email.Text)
                || string.IsNullOrWhiteSpace(bookIssue_bookTitle.Text)
                || string.IsNullOrWhiteSpace(bookIssue_status.Text)
                || bookIssue_picture.Image == null)
            {
                MessageBox.Show("Please select an item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult check = MessageBox.Show("Are you sure you want to UPDATE Issue ID: " + bookIssue_id.Text + "?",
                "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connect = Database.GetConnection()) // Use Database.cs connection
                    {
                        string updateData = "UPDATE issues SET full_name = @fullName, contact = @contact, email = @email, " +
                            "book_title = @bookTitle, status = @status, issue_date = @issueDate, " +
                            "return_date = @returnDate, date_update = @dateUpdate WHERE issue_id = @issueID";

                        using (MySqlCommand cmd = new MySqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@fullName", bookIssue_name.Text.Trim());
                            cmd.Parameters.AddWithValue("@contact", bookIssue_contact.Text.Trim());
                            cmd.Parameters.AddWithValue("@email", bookIssue_email.Text.Trim());
                            cmd.Parameters.AddWithValue("@bookTitle", bookIssue_bookTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@status", bookIssue_status.Text.Trim());
                            cmd.Parameters.AddWithValue("@issueDate", bookIssue_issueDate.Value);
                            cmd.Parameters.AddWithValue("@returnDate", bookIssue_returnDate.Value);
                            cmd.Parameters.AddWithValue("@dateUpdate", DateTime.Today);
                            cmd.Parameters.AddWithValue("@issueID", bookIssue_id.Text.Trim());
                         
                            cmd.ExecuteNonQuery();
                        }
                    }

                    displayBookIssueData();

                    MessageBox.Show("Updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Cancelled.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bookIssue_deleteBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(bookIssue_id.Text)
                || string.IsNullOrWhiteSpace(bookIssue_name.Text)
                || string.IsNullOrWhiteSpace(bookIssue_contact.Text)
                || string.IsNullOrWhiteSpace(bookIssue_email.Text)
                || string.IsNullOrWhiteSpace(bookIssue_bookTitle.Text)
                || string.IsNullOrWhiteSpace(bookIssue_status.Text)
                || bookIssue_picture.Image == null)
            {
                MessageBox.Show("Please select an item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult check = MessageBox.Show("Are you sure you want to DELETE Issue ID: " + bookIssue_id.Text.Trim() + "?",
                "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connect = Database.GetConnection()) // Already open connection
                    {
                        string updateData = "UPDATE issues SET date_delete = @dateDelete WHERE issue_id = @issueID";

                        using (MySqlCommand cmd = new MySqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@dateDelete", DateTime.Today.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@issueID", bookIssue_id.Text.Trim());

                            cmd.ExecuteNonQuery();
                        }                       
                    }

                    displayBookIssueData();

                    MessageBox.Show("Deleted successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Cancelled.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void bookIssue_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void bookIssue_contact_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only control keys (like Backspace) and digits
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block non-digit input
            }

            // Limit input to 11 digits
            if (char.IsDigit(e.KeyChar) && bookIssue_contact.Text.Length >= 11)
            {
                e.Handled = true;
            }
        }
        

        private void bookIssue_email_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow letters, digits, control keys (e.g., Backspace), and common email symbols
            if (!char.IsControl(e.KeyChar) &&
                !char.IsLetterOrDigit(e.KeyChar) &&
                e.KeyChar != '@' &&
                e.KeyChar != '.' &&
                e.KeyChar != '_' &&
                e.KeyChar != '-')
            {
                e.Handled = true; // Block other characters
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {
            
        }

        private void bookIssue_refreshBtn_Click(object sender, EventArgs e)
        {
            DataBookTitle();
            displayBookIssueData();
        }
    }
}
