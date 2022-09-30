using Google.Apis.Util;
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
using System.Xml.Linq;

namespace Homework
{
    public partial class Professor_grading : Form
    {
        string fileToCopy;
        string bob;
        string destinationDirectory;
        public Professor_grading()
        {
            InitializeComponent();
        }

        private void Professor_grading_Load(object sender, EventArgs e)
        {
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            conn.Open();

            string query1 = "select * from Complete_Homework ;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

            DataSet dSet = new DataSet();
            adapter.Fill(dSet, "wow");
            guna2DataGridView1.DataSource = dSet.Tables[0];
            DataTable dt = new DataTable();
            conn.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(conn);
            int hwid = Convert.ToInt32(complete_id.Value); 







            com.CommandText = "Delete from Complete_Homework where homework_id='"+hwid+"';";


            try
            {

                SQLiteCommand cmd = new SQLiteCommand(com.CommandText, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();


                string query1 = "select * from Complete_Homework ;";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

                DataSet dSet = new DataSet();
                adapter.Fill(dSet, "wow");
                guna2DataGridView1.DataSource = dSet.Tables[0];
                DataTable dt = new DataTable();
                MessageBox.Show("Διαγράφτηκαν από πίνακα", "ΟΚ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();

            }


            catch (Exception exception)
            {
                // Default error message
                MessageBox.Show(exception.Message);
                conn.Close();
            }

            
            
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           

            string fileName1 = "HomeworkManagement.db";
            FileInfo f1 = new FileInfo(fileName1);
            // Full path to it
            string path = f1.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            conn.Open();
            System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(conn);
            
            







            com.CommandText = "Insert into Corrected_Homework values ('" + correct_id.Value+ "','" + name_corr.Text + "','" + upload_date_cor.Text + "','" + creator_corect.Text + "','" + gradecor.Text + "');";


            try
            {

                SQLiteCommand cmd = new SQLiteCommand(com.CommandText, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();
                string query1 = "select * from Corrected_Homework ;";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

                DataSet dSet = new DataSet();
                adapter.Fill(dSet, "wow");
                guna2DataGridView2.DataSource = dSet.Tables[0];
                DataTable dt = new DataTable();
                

                conn.Close();
                MessageBox.Show("Καταχωρηθηκαν διορθωμένες εργασίες ", "ΟΚ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                // Default error message
                MessageBox.Show(ex.Message); conn.Close();
            }

        }
    }
}
