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
        public Student_see_current_homework()
        {
            InitializeComponent();
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
            conn.Open();

            string query1 = "select * from Homework_Board where visibility ='yes';";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

            DataSet dSet = new DataSet();
            adapter.Fill(dSet, "wow");
            guna2DataGridView1.DataSource = dSet.Tables[0];
            DataTable dt = new DataTable();
            conn.Close();
        }
    }
}
