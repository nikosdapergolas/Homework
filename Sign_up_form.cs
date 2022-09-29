﻿using System;
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
        // θα το χρησιμοποιήσω για να μπορώ να γυρίσω πίσω στην Login form
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
            // θα το χρησιμοποιήσω για να μπορώ να γυρίσω πίσω στην Login form
            loginForm.Show();
        }

        /// <summary>
        /// Αρχικα γίνονται οι έλεγχοι για το αν ο χρήστης έχει αφήσει κενό καποιο απο τα 6 πεδία.
        /// Επίσης γίνεται έλεγχος για το αν οι 2 κωδικοί που πληκτρολόγησε ο χρήστης είναι ίδιοι.
        /// Αν δεν υπάρχει κάποιο τέτοιο πρόβλημα, με το που ο χρήστης πατήσει submit τότε,
        /// ανοίγω σύνδεση με τη βάση μου και περνάω τα στοιχεία του εγεγραμμένου στον αντίστοιχο πίνακα
        /// τψν μαθητών στην βάση μου
        /// </summary>
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
                    string year1=gunaatext.Text;
                    
                        if(year1=="1"|| year1 == "2"|| year1 == "3"||year1 == "4")
                        {
                            
                        }
                        else
                        {
                            MessageBox.Show("error year inputted not in format '1' , '2', '3','4'");
                            guna2Button1.Refresh();
                        }    
                    

                    // Name of database file
                    string fileName = "HomeworkManagement.db";
                    FileInfo f = new FileInfo(fileName);
                    // Full path to it
                    string path = f.FullName;

                    // Connection string with relative path
                    string connectionstring = "Data Source=" + path + ";Version=3;";

                    SQLiteConnection conn = new SQLiteConnection(connectionstring);
                    conn.Open();
                    string query1 = "INSERT INTO Student(name,surname,email,username,password) VALUES ('" + name + "','" + surname + "','" + email + "','" + username + "','" + password + "','"+year1+"');";
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

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Όταν χρήστης κάνει hover πάνω απο το info εικονίδιο, εμφανίζω ένα μήνυμα βοήθειας
        /// </summary>
        private void guna2PictureBox2_MouseHover(object sender, EventArgs e)
        {
            richTextBox1.Visible = true;
        }

        private void guna2PictureBox2_MouseLeave(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
        }

        /// <summary>
        /// Αν ο χρήστης πατήσει enter ενώ έχει το ποντίκι του στο τελευταίο textbox,
        /// τότε καλείται η συνάρτηση που καλείται και όταν ο χρήστης πατήσει το 
        /// κουμπι "submit". Είναι δηλαδή ένα 2ος τρόπος να το κάνει.
        /// </summary>
        private void guna2TextBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2Button1_Click(this, new EventArgs());
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
