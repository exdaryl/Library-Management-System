using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;
using MySql.Data.MySqlClient;

namespace LibraryManagementSystem
{
    public partial class ReturnBooks : UserControl
    {
        private IssueBooks issueBooksForm;
        public ReturnBooks(IssueBooks issueBooks)
        {
            InitializeComponent();
            issueBooksForm = issueBooks;
            displayIssuedBooksData();
        }

        public void refreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)refreshData);
                return;
            }

            displayIssuedBooksData();
        }

        private void returnBooks_returnBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(returnBooks_issueID.Text)
                || string.IsNullOrWhiteSpace(returnBooks_name.Text)
                || string.IsNullOrWhiteSpace(returnBooks_contact.Text)
                || string.IsNullOrWhiteSpace(returnBooks_email.Text)
                || string.IsNullOrWhiteSpace(returnBooks_bookTitle.Text))
            {
                MessageBox.Show("Please select an item first", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult check = MessageBox.Show("Are you sure that Issue ID: " + returnBooks_issueID.Text.Trim() + " is returned?",
                "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (check == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection connect = Database.GetConnection()) // Already open connection
                    {
                        string updateData = "UPDATE issues SET status = @status, date_update = @dateUpdate WHERE issue_id = @issueID";

                        using (MySqlCommand cmd = new MySqlCommand(updateData, connect))
                        {
                            cmd.Parameters.AddWithValue("@status", "Return");
                            cmd.Parameters.AddWithValue("@dateUpdate", DateTime.Today);
                            cmd.Parameters.AddWithValue("@issueID", returnBooks_issueID.Text.Trim());

                            cmd.ExecuteNonQuery();
                        }
                    }

                    if (issueBooksForm != null)
                    {
                        issueBooksForm.RefreshIssuedBooksData();  // This method will refresh the DataGridView in IssueBooks
                    }

                    MessageBox.Show("Returned successfully!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void displayIssuedBooksData()
        {
            DataIssueBooks dib = new DataIssueBooks();
            List<DataIssueBooks> listData = dib.ReturnIssueBooksData();

            dataGridView1.DataSource = listData;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                returnBooks_issueID.Text = row.Cells[1].Value.ToString();
                returnBooks_name.Text = row.Cells[2].Value.ToString();
                returnBooks_contact.Text = row.Cells[3].Value.ToString();
                returnBooks_email.Text = row.Cells[4].Value.ToString();
                returnBooks_bookTitle.Text = row.Cells[5].Value.ToString();
                bookIssue_issueDate.Text = row.Cells[6].Value.ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void clearFields()
        {
            returnBooks_issueID.Text = "";
            returnBooks_name.Text = "";
            returnBooks_contact.Text = "";
            returnBooks_email.Text = "";
            returnBooks_bookTitle.Text = "";
            returnBooks_picture.Image = null;
        }

        private void returnBooks_clearBtn_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}
