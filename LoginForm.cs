using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Homework
{
    public partial class LoginForm : Form
    {
        // Μεταβλητή που δείχνει αν θέλει ο χρήστης να φαίνεται ο κωδικός που γράφει
        bool show_password = false;

        // Αρχικοποιώ κάποια αντικείμενα για να τα περάσω μέσα στις έπόμενες φόρμες
        // όταν κάποιος μαθητής, ή καθηγητής ή αδμιν κάνει login
        public static Student student;
        public static Professor professor;
        public static Admin admin;

        public LoginForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Καλώ τη συνάρτηση για να κάνει ο Student Login
        /// </summary>
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            student_login(guna2TextBox1.Text, guna2TextBox2.Text);
        }

        /// <summary>
        /// Καλεί την φόρμα για νακάνουν sign up οι μαθητές που επιθυμούν
        /// </summary>
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Sign_up_form sign_Up_Form = new Sign_up_form(this);
            this.Hide();
            sign_Up_Form.Show();
        }

        /// <summary>
        /// The function is called every time to check if a student tries to login
        /// If at first it sees that this is not a student, it searches if the user trying to login is a professor
        /// </summary>
        void student_login(string username, string password)
        {
            // Name of database file
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            conn.Open();
            string query1 = "select * from Student where username='" + username + "' and password='" + password + "';";
            SQLiteCommand cmd = new SQLiteCommand(query1, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // Περνάω στο public αντικείμενο Student τις τιμές που αντιστοιχούν σε αυτόν στη βάση
                // Σύμφωνα με το username και το password του
                student = new Student();

                student.A_M = (int)reader.GetInt32(0);
                student.Name = reader.GetString(1);
                student.Surname = reader.GetString(2);
                student.Email = reader.GetString(3);

                // Μηνυμα επιτυχίας και χαράς
                // και καλώ τη δευτερη φόρμα
                MessageBox.Show("Καλωσόρισες " + reader.GetString(1) + " " + reader.GetString(2) + "!! :)", "Το login ήταν επιτυχές!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Πέρασμα στην καινούρια φόρμα με το προφίλ του μαθητή αυτού
                this.Hide();
                Form1 form1 = new Form1(this,student);
                form1.Show();
            }
            else
            {
                professor_login(guna2TextBox1.Text,guna2TextBox2.Text);
            }
            reader.Close();
            conn.Close();
            conn.Dispose();
        }

        /// <summary>
        /// The function is called every time to check if a professor tries to login
        /// If at first it sees that this is not a professor, it searches if the user trying to login is an admin
        /// </summary>
        void professor_login(string username, string password)
        {
            // Name of database file
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            conn.Open();
            string query1 = "select * from Professor where username='" + username + "' and password='" + password + "';";
            SQLiteCommand cmd = new SQLiteCommand(query1, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // Περνάω στο public αντικείμενο Student τις τιμές που αντιστοιχούν σε αυτόν στη βάση
                // Σύμφωνα με το username και το password του
                professor = new Professor();

                professor.ID = (int)reader.GetInt32(0);
                professor.Name = reader.GetString(1);
                professor.Surname = reader.GetString(2);
                professor.Email = reader.GetString(3);

                MessageBox.Show("Καλωσόρισες " + reader.GetString(1) + " " + reader.GetString(2) + "!! :)", "Το login ήταν επιτυχές!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Professor_home_page php = new Professor_home_page(this,professor);
                php.Show();

            }
            else
            {
                admin_login(guna2TextBox1.Text,guna2TextBox2.Text);
            }

            reader.Close();
            conn.Close();
            conn.Dispose();
        }

        /// <summary>
        /// The function is called every time to check if an admin tries to login
        /// </summary>
        void admin_login(string username, string password)
        {
            // Name of database file
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            conn.Open();
            string query1 = "select * from Admin where username='" + username + "' and password='" + password + "';";
            SQLiteCommand cmd = new SQLiteCommand(query1, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("Καλωσόρισες " + reader.GetString(1) + " " + reader.GetString(2) + "!! :)", "Το login ήταν επιτυχές!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Περνάω στο public αντικείμενο Student τις τιμές που αντιστοιχούν σε αυτόν στη βάση
                // Σύμφωνα με το username και το password του
                admin = new Admin();

                admin.AdminID = (int)reader.GetInt32(0);
                admin.Name = reader.GetString(1);
                admin.Surname = reader.GetString(2);
                admin.Email = reader.GetString(3);

                this.Hide();
                Admin_home_page ahp = new Admin_home_page(this, admin);
                ahp.Show();
            }
            else
            {
                MessageBox.Show("Δεν υπάρχει κάποιος χρήστης με το συγκεκριμένο username ή password... Προσπαθήστε ξανά.", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            reader.Close();
            conn.Close();
            conn.Dispose();
        }

        /// <summary>
        /// When the user presses "enter" on the keyboard after writing his password, 
        /// then this function is calling the function that would be called if the user 
        /// had pressed the "Login" button
        /// </summary>
        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2Button1_Click(this, new EventArgs());
            }
        }

        /// <summary>
        /// When the user presses "enter" on the keyboard after writing his username, 
        /// then this function is calling the function that would be called if the user 
        /// had pressed the "Login" button
        /// </summary>
        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2Button1_Click(this, new EventArgs());
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Change_password_via_email cpve = new Change_password_via_email(this);
            this.Enabled = false;
            cpve.Show();
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if(show_password == false)
            {
                show_password = true;
                guna2TextBox2.PasswordChar = '\0';
            }
            else
            {
                show_password = false;
                guna2TextBox2.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nikos_test_form nikos = new Nikos_test_form();
            this.Hide();
            nikos.Show();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }      

        
    }
}
