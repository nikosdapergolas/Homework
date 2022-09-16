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

        public static Student student;
        public static Professor professor;
        public static Admin admin;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            student_login(guna2TextBox1.Text, guna2TextBox2.Text);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// The function is here for the student to login when the student_logging_in flag is true
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
                MessageBox.Show("welcome " + reader.GetString(1) + " " + reader.GetString(2) + "!! :)", "Login Successful");

                // Πέρασμα στην καινούρια φόρμα με το προφίλ του μαθητή αυτού
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
            }
            else
            {
                MessageBox.Show("There is no such user...sorry", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                // Κώδικας για το αν πατήσει το οκ αντι για cancel
                // (Σε περίπτωση που χρειαστεί κάπου)

            }

            conn.Close();
        }

        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2Button1_Click(this, new EventArgs());
            }
        }
    }
}
