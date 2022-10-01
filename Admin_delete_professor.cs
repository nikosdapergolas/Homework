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
    public partial class Admin_delete_professor : Form
    {
        public Admin_delete_professor()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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
                string query1 = "Delete from Professor where id = '" + guna2TextBox1.Text + "';";
                SQLiteCommand cmd2 = new SQLiteCommand(query1, conn);
                SQLiteDataReader reader = cmd2.ExecuteReader();

                reader.Close();
                conn.Close();
                MessageBox.Show("Ο καθηγητής με id " + guna2TextBox1.Text + " έχει πλέον διαγραφεί από το σύστημα!!", "Deleting successful.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                // Default error message
                MessageBox.Show(exception.Message);
            }
        }
    }
}
