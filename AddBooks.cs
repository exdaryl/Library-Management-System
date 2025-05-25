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

namespace LibraryManagementSystem
{
    public partial class AddBooks: UserControl
    {
        public AddBooks()
        {
            InitializeComponent();

            displayBooks();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            displayBooks();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addBook_importBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddBooks_Load(object sender, EventArgs e)
        {

        }

        private void addBooks_importBtn_Click(object sender, EventArgs e)
        {
            string imagePath = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files (*.jpg; *.png)|*.jpg;*.png";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    imagePath = dialog.FileName;
                    addBooks_picture.ImageLocation = imagePath; // Show image in PictureBox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addBooks_addBtn_Click(object sender, EventArgs e)
        {
            if (addBooks_picture.Image == null
                || string.IsNullOrWhiteSpace(addBooks_bookTitle.Text)
                || string.IsNullOrWhiteSpace(addBooks_author.Text)
                || addBooks_published.Value == DateTime.MinValue
                || string.IsNullOrWhiteSpace(addBooks_status.Text))
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection connect = Database.GetConnection()) // Use Database.cs connection
                {
                    DateTime today = DateTime.Today;
                    string publishedDate = addBooks_published.Value.ToString("yyyy-MM-dd");

                    // Define the image path in Books_Directory
                    string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Books_Directory");
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath); // Create if not exists
                    }

                    string path = Path.Combine(directoryPath,
                        addBooks_bookTitle.Text.Trim() + "_" +
                        addBooks_author.Text.Trim() + "_" +
                        today.ToString("yyyy-MM-dd") + ".jpg");

                    if (string.IsNullOrWhiteSpace(addBooks_picture.ImageLocation))
                    {
                        MessageBox.Show("No image selected for the book.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Save the image locally in the defined folder
                    File.Copy(addBooks_picture.ImageLocation, path, true); // Overwrite if exists

                    string insertData = "INSERT INTO books (book_title, author, published_date, status, image, date_insert) " +
                                        "VALUES (@bookTitle, @author, @published, @status, @image, @dateInsert)";

                    if (connect.State != ConnectionState.Open)
                    {
                        connect.Open();
                    }

                    using (MySqlCommand cmd = new MySqlCommand(insertData, connect))
                    {
                        cmd.Parameters.AddWithValue("@bookTitle", addBooks_bookTitle.Text.Trim());
                        cmd.Parameters.AddWithValue("@author", addBooks_author.Text.Trim());
                        cmd.Parameters.AddWithValue("@published", publishedDate);
                        cmd.Parameters.AddWithValue("@status", addBooks_status.Text.Trim());
                        cmd.Parameters.AddWithValue("@image", path); // Save the image path in the database
                        cmd.Parameters.AddWithValue("@dateInsert", today.ToString("yyyy-MM-dd"));

                        cmd.ExecuteNonQuery();
                    }

                    displayBooks(); // Refresh the displayed books
                    MessageBox.Show("Added successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void clearFields()
        {
            addBooks_bookTitle.Text = "";
            addBooks_author.Text = "";
            addBooks_picture.Image = null;
            addBooks_status.SelectedIndex = -1;
        }

        public void displayBooks()
        {
            DataAddBooks dab = new DataAddBooks();
            List<DataAddBooks> listData = dab.addBooksData();

            dataGridView1.DataSource = listData;

        }

        private int bookID = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                bookID = (int)row.Cells[0].Value;
                addBooks_bookTitle.Text = row.Cells[1].Value.ToString();
                addBooks_author.Text = row.Cells[2].Value.ToString();
                addBooks_published.Text = row.Cells[3].Value.ToString();

                string imagePath = row.Cells[4].Value.ToString();

                if (imagePath != null || imagePath.Length >= 1)
                {
                    addBooks_picture.Image = Image.FromFile(imagePath);
                }
                else
                {
                    addBooks_picture.Image = null;
                }
                addBooks_status.Text = row.Cells[5].Value.ToString();
            }
        }

        private void addBooks_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void addBooks_updateBtn_Click(object sender, EventArgs e)
        {
            if (addBooks_picture.Image == null
                || string.IsNullOrWhiteSpace(addBooks_bookTitle.Text)
                || string.IsNullOrWhiteSpace(addBooks_author.Text)
                || string.IsNullOrWhiteSpace(addBooks_status.Text))
            {
                MessageBox.Show("Please select an item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult check = MessageBox.Show("Are you sure you want to UPDATE Book ID: " + bookID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connect = Database.GetConnection()) // Use Database.cs connection
                    {
                        DateTime today = DateTime.Today;
                        string publishedDate = addBooks_published.Value.ToString("yyyy-MM-dd");

                        // Get existing image path from database
                        string oldImagePath = "";
                        string selectQuery = "SELECT image FROM books WHERE id = @id";

                        using (MySqlCommand selectCmd = new MySqlCommand(selectQuery, connect))
                        {
                            selectCmd.Parameters.AddWithValue("@id", bookID);
                            object result = selectCmd.ExecuteScalar();
                            if (result != null)
                            {
                                oldImagePath = result.ToString();
                            }
                        }

                        // Check if a new image is selected
                        string newImagePath = oldImagePath; // Default to old image
                        if (!string.IsNullOrEmpty(addBooks_picture.ImageLocation)) // If a new image is selected
                        {
                            // Dispose the current image first
                            if (addBooks_picture.Image != null)
                            {
                                addBooks_picture.Image.Dispose();
                            }

                            // Define a safe, relative directory path
                            string directoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Books_Directory");
                            if (!Directory.Exists(directoryPath))
                            {
                                Directory.CreateDirectory(directoryPath);
                            }

                            // Create a new file name using book title + author + today's date
                            newImagePath = Path.Combine(directoryPath,
                                addBooks_bookTitle.Text.Trim() + "_" +
                                addBooks_author.Text.Trim() + "_" +
                                today.ToString("yyyy-MM-dd") + ".jpg");

                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            File.Copy(addBooks_picture.ImageLocation, newImagePath, true); // Save new image
                        }


                        string updateData = "UPDATE books SET book_title = @bookTitle, author = @author, " +
                                            "published_date = @published, status = @status, image = @image, date_update = @dateUpdate " +
                                            "WHERE id = @id";

                        //if (connect.State != ConnectionState.Open)
                        //{
                        //    connect.Open();
                        //}

                        using (MySqlCommand cmd = new MySqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@bookTitle", addBooks_bookTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@author", addBooks_author.Text.Trim());
                            cmd.Parameters.AddWithValue("@published", publishedDate);
                            cmd.Parameters.AddWithValue("@status", addBooks_status.Text.Trim());
                            cmd.Parameters.AddWithValue("@image", newImagePath); // Use new or existing image
                            cmd.Parameters.AddWithValue("@dateUpdate", today.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@id", bookID);

                            cmd.ExecuteNonQuery();
                        }

                        displayBooks();

                        MessageBox.Show("Updated successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        clearFields();

                    }
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

        private void addBooks_delBtn_Click(object sender, EventArgs e)
        {
            if (addBooks_bookTitle.Text == ""
                || addBooks_author.Text == ""
                || addBooks_published.Value == null
                || addBooks_status.Text == "")
            {
                MessageBox.Show("Please select an item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult check = MessageBox.Show("Are you sure you want to DELETE Book ID: " + bookID + "?", "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connect = Database.GetConnection()) // Use Database.cs connection
                    {
                        if (connect.State != ConnectionState.Open)
                        {
                            connect.Open();
                        }

                        string updateData = "UPDATE books SET date_delete = @dateDelete WHERE id = @id";

                        using (MySqlCommand cmd = new MySqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@dateDelete", DateTime.Today.ToString("yyyy-MM-dd"));
                            cmd.Parameters.AddWithValue("@id", bookID);

                            cmd.ExecuteNonQuery();

                            displayBooks();

                            MessageBox.Show("Deleted successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            clearFields();
                        }
                    }
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
    }
}
