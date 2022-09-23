using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework
{
    public partial class Sign_up_form : Form
    {
        LoginForm loginForm;

        public Sign_up_form(LoginForm login)
        {
            InitializeComponent();
            loginForm = login;
        }

        /// <summary>
        /// Οταν ο χρήστης πατάει να πάει πίσω στην φόρμα του Login
        /// </summary>
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            loginForm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox5.Text != guna2TextBox6.Text)
                {
                    MessageBox.Show("Οι 2 κωδικοί που πληκτρολογήσατε δεν είναι ίδιοι. Πρακαλώ προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (guna2TextBox1.Text == "")
                {
                    MessageBox.Show("Δεν μπορείτε να αφήσετε το πεδίο \"Όνομα\" κενό. Προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (guna2TextBox2.Text == "")
                {
                    MessageBox.Show("Δεν μπορείτε να αφήσετε το πεδίο \"Επίθετο\" κενό. Προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (guna2TextBox3.Text == "")
                {
                    MessageBox.Show("Δεν μπορείτε να αφήσετε το πεδίο \"Email\" κενό. Προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (guna2TextBox4.Text == "")
                {
                    MessageBox.Show("Δεν μπορείτε να αφήσετε το πεδίο \"Username\" κενό. Προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (guna2TextBox5.Text == "")
                {
                    MessageBox.Show("Δεν μπορείτε να αφήσετε το πεδίο \"Password\" κενό. Προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else
                {
                    string name = guna2TextBox1.Text;
                    string surname = guna2TextBox2.Text;
                    string email = guna2TextBox3.Text;
                    string username = guna2TextBox4.Text;
                    string password = guna2TextBox5.Text;

                    // Name of database file
                    string fileName = "HomeworkManagement.db";
                    FileInfo f = new FileInfo(fileName);
                    // Full path to it
                    string path = f.FullName;

                    // Connection string with relative path
                    string connectionstring = "Data Source=" + path + ";Version=3;";

                    SQLiteConnection conn = new SQLiteConnection(connectionstring);
                    conn.Open();
                    string query1 = "INSERT INTO Student(name,surname,email,username,password) VALUES ('" + name + "','" + surname + "','" + email + "','" + username + "','" + password + "');";
                    SQLiteCommand cmd = new SQLiteCommand(query1, conn);
                    SQLiteDataReader reader = cmd.ExecuteReader();

                    conn.Close();
                    MessageBox.Show("Έχετε καταχωρηθεί στο σύστημα επιτυχώς!! Σας μεταφέρουμε πίσω στην φόρμα εισαγωγής.", "Sign in successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loginForm.Show();
                    this.Close();
                }
            }
            catch (Exception exception)
            {
                // Default error message
                MessageBox.Show(exception.Message);
            }
        }
    }
}
