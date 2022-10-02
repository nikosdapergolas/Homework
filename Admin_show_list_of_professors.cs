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
    public partial class Admin_show_list_of_professors : Form
    {
        public Admin_show_list_of_professors()
        {
            InitializeComponent();
        }

        private void Admin_show_list_of_professors_Load(object sender, EventArgs e)
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

                string query1 = "select id,name,surname,email,username from Professor";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

                DataSet dSet = new DataSet();
                adapter.Fill(dSet, "wow");
                guna2DataGridView1.DataSource = dSet.Tables[0];
                DataTable dt = new DataTable();

                conn.Close();
            }
            catch (Exception exception)
            {
                // Default error message
                MessageBox.Show(exception.Message);
            }
        }
    }
}
