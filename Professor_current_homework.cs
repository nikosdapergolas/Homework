﻿using System;
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
    public partial class Professor_current_homework : Form
    {
        public Professor_current_homework()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Professor_current_homework_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
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

            string query1 = "select * from Homework_Board ;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

            DataSet dSet = new DataSet();
            adapter.Fill(dSet, "wow");
            dgv2.DataSource = dSet.Tables[0];





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
            string inp = guna2TextBox1.Text;
            System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(conn);

            com.CommandText = "update Homework_Board set visibility='yes' where homeworkID ='" + inp + "'";
            com.ExecuteNonQuery();
            SQLiteCommand cmd = new SQLiteCommand(com.CommandText, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                MessageBox.Show("ok", "ενεργεια εγινε", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Περνάω στο public αντικείμενο Student τις τιμές που αντιστοιχούν σε αυτόν στη βάση
                // Σύμφωνα με το username και το password του
                
            }
            else
            {
                MessageBox.Show("Το id δεν βρεθηκε", "ERROR", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }




            string query2 = "select * from Homework_Board where visibility='yes';";

            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query2, conn);

            DataSet dSet = new DataSet();
            adapter.Fill(dSet, "wow");
            dgv2.DataSource = dSet.Tables[0];
            DataTable dt = new DataTable();




            conn.Close();



        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
