namespace LibraryManagementSystem
{
    partial class ReturnBooks
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bookIssue_issueDate = new System.Windows.Forms.DateTimePicker();
            this.returnBooks_status = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.returnBooks_clearBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.returnBooks_returnBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.returnBooks_bookTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.returnBooks_picture = new System.Windows.Forms.PictureBox();
            this.returnBooks_email = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.returnBooks_contact = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.returnBooks_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.returnBooks_issueID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.returnBooks_picture)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.bookIssue_issueDate);
            this.panel1.Controls.Add(this.returnBooks_status);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.returnBooks_clearBtn);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.returnBooks_returnBtn);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.returnBooks_bookTitle);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.returnBooks_picture);
            this.panel1.Controls.Add(this.returnBooks_email);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.returnBooks_contact);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.returnBooks_name);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.returnBooks_issueID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(15, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 819);
            this.panel1.TabIndex = 0;
            // 
            // bookIssue_issueDate
            // 
            this.bookIssue_issueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookIssue_issueDate.Location = new System.Drawing.Point(123, 416);
            this.bookIssue_issueDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bookIssue_issueDate.Name = "bookIssue_issueDate";
            this.bookIssue_issueDate.Size = new System.Drawing.Size(173, 27);
            this.bookIssue_issueDate.TabIndex = 20;
            // 
            // returnBooks_status
            // 
            this.returnBooks_status.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnBooks_status.FormattingEnabled = true;
            this.returnBooks_status.Items.AddRange(new object[] {
            "Return",
            "Not Return"});
            this.returnBooks_status.Location = new System.Drawing.Point(123, 463);
            this.returnBooks_status.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.returnBooks_status.Name = "returnBooks_status";
            this.returnBooks_status.Size = new System.Drawing.Size(173, 29);
            this.returnBooks_status.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(51, 467);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 21);
            this.label9.TabIndex = 18;
            this.label9.Text = "Status:";
            // 
            // returnBooks_clearBtn
            // 
            this.returnBooks_clearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(128)))), ((int)(((byte)(87)))));
            this.returnBooks_clearBtn.FlatAppearance.BorderSize = 0;
            this.returnBooks_clearBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkSeaGreen;
            this.returnBooks_clearBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSeaGreen;
            this.returnBooks_clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnBooks_clearBtn.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnBooks_clearBtn.ForeColor = System.Drawing.Color.White;
            this.returnBooks_clearBtn.Location = new System.Drawing.Point(181, 615);
            this.returnBooks_clearBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.returnBooks_clearBtn.Name = "returnBooks_clearBtn";
            this.returnBooks_clearBtn.Size = new System.Drawing.Size(104, 46);
            this.returnBooks_clearBtn.TabIndex = 17;
            this.returnBooks_clearBtn.Text = "CLEAR";
            this.returnBooks_clearBtn.UseVisualStyleBackColor = false;
            this.returnBooks_clearBtn.Click += new System.EventHandler(this.returnBooks_clearBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(85, 585);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(8, 7);
            this.button2.TabIndex = 16;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // returnBooks_returnBtn
            // 
            this.returnBooks_returnBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(128)))), ((int)(((byte)(87)))));
            this.returnBooks_returnBtn.FlatAppearance.BorderSize = 0;
            this.returnBooks_returnBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkSeaGreen;
            this.returnBooks_returnBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkSeaGreen;
            this.returnBooks_returnBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.returnBooks_returnBtn.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnBooks_returnBtn.ForeColor = System.Drawing.Color.White;
            this.returnBooks_returnBtn.Location = new System.Drawing.Point(41, 615);
            this.returnBooks_returnBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.returnBooks_returnBtn.Name = "returnBooks_returnBtn";
            this.returnBooks_returnBtn.Size = new System.Drawing.Size(104, 46);
            this.returnBooks_returnBtn.TabIndex = 15;
            this.returnBooks_returnBtn.Text = "RETURN";
            this.returnBooks_returnBtn.UseVisualStyleBackColor = false;
            this.returnBooks_returnBtn.Click += new System.EventHandler(this.returnBooks_returnBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 420);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 21);
            this.label8.TabIndex = 13;
            this.label8.Text = "Book Issued:";
            // 
            // returnBooks_bookTitle
            // 
            this.returnBooks_bookTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnBooks_bookTitle.Location = new System.Drawing.Point(123, 373);
            this.returnBooks_bookTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.returnBooks_bookTitle.Name = "returnBooks_bookTitle";
            this.returnBooks_bookTitle.Size = new System.Drawing.Size(173, 27);
            this.returnBooks_bookTitle.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 375);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 21);
            this.label6.TabIndex = 9;
            this.label6.Text = "Book Title:";
            // 
            // returnBooks_picture
            // 
            this.returnBooks_picture.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.returnBooks_picture.Location = new System.Drawing.Point(123, 41);
            this.returnBooks_picture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.returnBooks_picture.Name = "returnBooks_picture";
            this.returnBooks_picture.Size = new System.Drawing.Size(100, 100);
            this.returnBooks_picture.TabIndex = 8;
            this.returnBooks_picture.TabStop = false;
            // 
            // returnBooks_email
            // 
            this.returnBooks_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnBooks_email.Location = new System.Drawing.Point(123, 320);
            this.returnBooks_email.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.returnBooks_email.Name = "returnBooks_email";
            this.returnBooks_email.Size = new System.Drawing.Size(173, 27);
            this.returnBooks_email.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(56, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 21);
            this.label5.TabIndex = 6;
            this.label5.Text = "Email:";
            // 
            // returnBooks_contact
            // 
            this.returnBooks_contact.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnBooks_contact.Location = new System.Drawing.Point(123, 268);
            this.returnBooks_contact.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.returnBooks_contact.Name = "returnBooks_contact";
            this.returnBooks_contact.Size = new System.Drawing.Size(173, 27);
            this.returnBooks_contact.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Mobile No.:";
            // 
            // returnBooks_name
            // 
            this.returnBooks_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnBooks_name.Location = new System.Drawing.Point(123, 218);
            this.returnBooks_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.returnBooks_name.Name = "returnBooks_name";
            this.returnBooks_name.Size = new System.Drawing.Size(173, 27);
            this.returnBooks_name.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Name:";
            // 
            // returnBooks_issueID
            // 
            this.returnBooks_issueID.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnBooks_issueID.Location = new System.Drawing.Point(123, 169);
            this.returnBooks_issueID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.returnBooks_issueID.Name = "returnBooks_issueID";
            this.returnBooks_issueID.Size = new System.Drawing.Size(173, 27);
            this.returnBooks_issueID.TabIndex = 1;
            this.returnBooks_issueID.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Issued ID:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(351, 25);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(725, 819);
            this.panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(128)))), ((int)(((byte)(87)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 55);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(700, 748);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "All Issued Books";
            // 
            // ReturnBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ReturnBooks";
            this.Size = new System.Drawing.Size(871, 690);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.returnBooks_picture)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox returnBooks_issueID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox returnBooks_contact;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox returnBooks_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox returnBooks_bookTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox returnBooks_picture;
        private System.Windows.Forms.TextBox returnBooks_email;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button returnBooks_clearBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button returnBooks_returnBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox returnBooks_status;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker bookIssue_issueDate;
    }
}
