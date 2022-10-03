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
    public partial class Student_my_lessons : Form
    {
        Student student;

        public Student_my_lessons(Student s)
        {
            InitializeComponent();
            student = s;
        }

        private void Student_my_lessons_Load(object sender, EventArgs e)
        {
            
            label3.Text = student.Name;
            // Name of database file
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            conn.Open();
            string query1 = "select year from Student where name='" + student.Name + "' ;";
            SQLiteCommand cmd = new SQLiteCommand(query1, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();
            if ( student.Year == "1")
            {
                guna2PictureBox1.Visible = true;
            }
            else if (student.Year == "2")
            {
                guna2PictureBox2.Visible = true;
            }
            else if (student.Year == "3")
            {
                guna2PictureBox3.Visible = true;
            }
            else if (student.Year == "4")
            {
                guna2PictureBox4.Visible = true;
            }
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
