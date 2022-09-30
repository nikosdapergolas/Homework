using Google.Apis.Admin.Directory.directory_v1.Data;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework
{
    public partial class Professor_my_lessons : Form
    {
        Professor professor;

        public Professor_my_lessons(Professor p)
        {
            InitializeComponent();
            professor = p;
        }

        private void Professor_my_lessons_Load(object sender, EventArgs e)
        {
            label2.Text ="Καλωσήρθατε κύριε"+ professor.Name+ "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                
                

                // Connection string with relative path
                /*string connectionstring = @"Data Source=HomeworkManagement.db;Version=3;";


                using (SqlConnection sqlCon = new SqlConnection(connectionstring))
                {
                    sqlCon.Open();
                    SqlDataAdapter adp = new SqlDataAdapter("select * from Homework_Posted/ To_be_posted",sqlCon);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    dgv1.DataSource = dt;
                }

            Homework_Posted / To_be_posted*/

                
                // Name of database file
                string fileName = "HomeworkManagement.db";
                FileInfo f = new FileInfo(fileName);
                // Full path to it
                string path = f.FullName;

                // Connection string with relative path
                string connectionstring = "Data Source=" + path + ";Version=3;";

                SQLiteConnection conn = new SQLiteConnection(connectionstring);
                conn.Open();

                string query1 = "select * from Homework_Board;";
                SQLiteDataAdapter adapter= new SQLiteDataAdapter(query1, conn);
                
                DataSet dSet = new DataSet(); 
                adapter.Fill(dSet,"wow");
                dgv1.DataSource = dSet.Tables[0];




                
                DataTable dt = new DataTable();
              
           

                
                conn.Close();




        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            conn.Open();

            string query1 = "select * from Complete_Homework;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

            DataSet dSet = new DataSet();
            adapter.Fill(dSet, "wow");
            dgv1.DataSource = dSet.Tables[0];





            DataTable dt = new DataTable();




            conn.Close();
        }

        private void dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            conn.Open();

            string query1 = "select * from Corrected_Homework;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

            DataSet dSet = new DataSet();
            adapter.Fill(dSet, "wow");
            dgv1.DataSource = dSet.Tables[0];





            DataTable dt = new DataTable();




            conn.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            conn.Open();

            string query1 = "select * from Homework_Board;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

            DataSet dSet = new DataSet();
            adapter.Fill(dSet, "wow");
            dgv1.DataSource = dSet.Tables[0];





            DataTable dt = new DataTable();




            conn.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            conn.Open();

            string query1 = "select * from Complete_Homework;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

            DataSet dSet = new DataSet();
            adapter.Fill(dSet, "wow");
            dgv1.DataSource = dSet.Tables[0];





            DataTable dt = new DataTable();




            conn.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            conn.Open();

            string query1 = "select * from Corrected_Homework;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

            DataSet dSet = new DataSet();
            adapter.Fill(dSet, "wow");
            dgv1.DataSource = dSet.Tables[0];





            DataTable dt = new DataTable();




            conn.Close();
        }
    }
}
