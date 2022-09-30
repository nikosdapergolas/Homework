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
    public partial class Student_my_team : Form
    {
        public Student_my_team()
        {
            InitializeComponent();
        }
        
        private void guna2NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int p = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));

            if (p == 1)
            {
                name1.Visible = true;
                name2.Visible = false;
                name3.Visible = false;
                name4.Visible = false;
            }
            else if (p == 2)
            {
                name1.Visible = true;
                name2.Visible = true;
                name3.Visible = false;
                name4.Visible = false;
            }
            else if (p == 3)
            {
                name1.Visible = true;
                name2.Visible = true;
                name3.Visible = true;
                name4.Visible = false;
            }
            else 
            {
                name1.Visible = true;
                name2.Visible = true;
                name3.Visible = true;
                name4.Visible = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            int p = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            string res = "l";
            if (p == 1)
            {
                string[] names = { name1.Text};
                 res = string.Join(",", names);
            }
            if (p == 2)
            {
                string[] names = { name1.Text, name2.Text };
                 res = string.Join(",", names);
            }
            if (p == 3)
            {
                string[] names = { name1.Text, name2.Text, name3.Text };
                 res = string.Join(",", names);
            }
            if (p == 4)
            {
                string[] names = { name1.Text, name2.Text, name3.Text, name4.Text };
                 res = string.Join(",", names);
            }
            
            string tn = guna2TextBox1.Text;
            
            // Name of database file
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";
            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            conn.Open();
            System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(conn);
            com.CommandText = "INSERT INTO Team(teamName,listOfAM) VALUES ('" + tn + "','" + res + "');";
            try
            {

                SQLiteCommand cmd = new SQLiteCommand(com.CommandText, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();


                conn.Close();
                MessageBox.Show("Καταχωρηθηκε η ομάδα ", "Επιτυχής καταχώρηση", MessageBoxButtons.OK, MessageBoxIcon.Information);
                name1.Clear();
                name2.Clear();
                name3.Clear();
                name4.Clear();
                guna2TextBox1.Clear();

            }
            catch (Exception ex)
            {
                // Default error message
                MessageBox.Show("Το όνομα της ομάδας υπάρχει ήδη");
                conn.Close();
            }


        }
    }
}
