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
    public partial class Admin_modify_professor_credentials : Form
    {
        public Admin_modify_professor_credentials()
        {
            InitializeComponent();
        }

        private void Admin_modify_professor_credentials_Load(object sender, EventArgs e)
        {
            try
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

                if(guna2ComboBox1.Text == "Professors")
                {
                    string query1 = "select * from Professor";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

                    DataSet dSet = new DataSet();
                    adapter.Fill(dSet, "wow");
                    guna2DataGridView1.DataSource = dSet.Tables[0];
                    DataTable dt = new DataTable();

                    conn.Close();
                }
                else if(guna2ComboBox1.Text == "Students")
                {
                    string query1 = "select * from Student";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

                    DataSet dSet = new DataSet();
                    adapter.Fill(dSet, "wow");
                    guna2DataGridView1.DataSource = dSet.Tables[0];
                    DataTable dt = new DataTable();

                    conn.Close();
                }
                else if(guna2ComboBox1.Text == "Admins")
                {
                    string query1 = "select * from Admin";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

                    DataSet dSet = new DataSet();
                    adapter.Fill(dSet, "wow");
                    guna2DataGridView1.DataSource = dSet.Tables[0];
                    DataTable dt = new DataTable();

                    conn.Close();
                }
                
            }
            catch (Exception exception)
            {
                // Default error message
                MessageBox.Show(exception.Message);
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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

                if (guna2ComboBox1.Text == "Professors")
                {
                    string query1 = "select * from Professor";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

                    DataSet dSet = new DataSet();
                    adapter.Fill(dSet, "wow");
                    guna2DataGridView1.DataSource = dSet.Tables[0];
                    DataTable dt = new DataTable();

                    conn.Close();
                }
                else if (guna2ComboBox1.Text == "Students")
                {
                    string query1 = "select * from Student";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

                    DataSet dSet = new DataSet();
                    adapter.Fill(dSet, "wow");
                    guna2DataGridView1.DataSource = dSet.Tables[0];
                    DataTable dt = new DataTable();

                    conn.Close();
                }
                else if (guna2ComboBox1.Text == "Admins")
                {
                    string query1 = "select * from Admin";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

                    DataSet dSet = new DataSet();
                    adapter.Fill(dSet, "wow");
                    guna2DataGridView1.DataSource = dSet.Tables[0];
                    DataTable dt = new DataTable();

                    conn.Close();
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
