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
    public partial class Nikos_test_form : Form
    {
        public Nikos_test_form()
        {
            InitializeComponent();
        }

        private void Nikos_test_form_Load(object sender, EventArgs e)
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

            string query1 = "select * from Student";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

            DataSet dSet = new DataSet();
            adapter.Fill(dSet, "wow");
            guna2DataGridView1.DataSource = dSet.Tables[0];
            DataTable dt = new DataTable();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File_uploading_animation file_upload = new File_uploading_animation(this);
            this.Enabled = false;
            file_upload.Show();
        }
    }
}
