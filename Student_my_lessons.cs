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
            if (student.Year = 1)
            {
                guna2PictureBox1
            }
            else if (student.Year = 2)
            {

            }
            else if (student.Year = 3)
            {

            }
            else if (student.Year = 4)
            {

            }
        }
    }
}
