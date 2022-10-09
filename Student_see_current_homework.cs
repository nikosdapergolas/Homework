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
    public partial class Student_see_current_homework : Form
    {
        Student student;
        public Student_see_current_homework(Student s)
        {
            InitializeComponent();
            student = s;
        }

        private void Student_see_current_homework_Load(object sender, EventArgs e)
        {
            // Name of database file
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            

            string query1 = "select * from Homework_Board where visibility ='yes';";
            
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

            DataSet dSet = new DataSet();
            adapter.Fill(dSet, "wow");
            guna2DataGridView1.DataSource = dSet.Tables[0];
            DataTable dt = new DataTable();
            conn.Close();

            //----------------------------------------------------------------------------------------




            conn.Open();

            string query2 = "select * from Corrected_Homework where creator_of_Homework = '"+student.A_M.ToString()+"' ;";



            SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(query2, conn);

            DataSet dSet2 = new DataSet();
            adapter2.Fill(dSet2, "wow2");
            guna2DataGridView2.DataSource = dSet2.Tables[0];
            DataTable dt2 = new DataTable();
            conn.Close();




        }
    }
}
