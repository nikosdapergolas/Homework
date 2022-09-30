using Guna.UI2.WinForms;
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
    public partial class Professor_set_homework : Form
    {
        string fileToCopy;
        string bob;
        string destinationDirectory;
        public Professor_set_homework()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false; // deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                bob = dialog.FileName;
                // Get path of file
                String path = dialog.FileName;
                fileToCopy = path;

                string filenamex = Path.GetFileName(bob);
                bob = filenamex;

                // Change the file shown in the rich textbox
                richTextBox1.Text = path;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            

            //*******************************************************************************
            // Ανάλογα με το ποιός ανεβάζει και τι, μόνο αυτό το σημείο του κώδικα θα αλλάζει
            string fileName = "professor_upload_a_new_homework"; // Το αρχείο στο οποίο αποθηκεύουμε τα "τάδε" πράγματα στο bin/debug
            //*******************************************************************************
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            destinationDirectory = f.FullName;
            try
            {
                // Copying the file chosen, to the folder inside bin/debug
                // that has all the other files like it
                File.Copy(fileToCopy, destinationDirectory + "/" + Path.GetFileName(fileToCopy));
                // Μήνυμα επιτυχίας
                
                MessageBox.Show("Το αρχείο ανέβηκε επιτυχώς!"
                    , "Επιτυχία!"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information
                    );
            }
            catch
            {
                // Exception handling για αν ο χρήστης προσπαθήσει
                // να πατήσει 2 φορές το ίδιο αρχείο για να ανέβει
                MessageBox.Show("Το αρχείο που προσπαθείτε να ανεβάσετε υπάρχει ήδη.\nΠροσπαθήστε ξανά!"
                    , "Σφάλμα"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Error);
            }

            string fileName1 = "HomeworkManagement.db";
            FileInfo f1 = new FileInfo(fileName1);
            // Full path to it
            string path = f1.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            SQLiteConnection conn = new SQLiteConnection(connectionstring);
            conn.Open();
            System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(conn);
            string homeworkid= IDtxt.Text;
            string nameofHW = hwname.Text;
            string deadline= deadliner.Text;
            string file_name= bob;
            string visibility = visi.Text;
            string subject1 = subject.Text;
            string max_grade=maxvathmos.Text;   
            string yearboy=class_name.Text;
            






            com.CommandText = "Insert into Homework_Board values ('" + IDtxt.Text + "','" + hwname.Text + "','" + deadliner.Text + "','" + bob + "','" + visi.Text + "','" + subject1 + "','"+max_grade+"','"+yearboy+"');";

            
            try
            {

                SQLiteCommand cmd = new SQLiteCommand(com.CommandText, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();
                
                
                conn.Close();
                MessageBox.Show("Καταχωρηθηκαν εργασίες ", "ΟΚ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {
                // Default error message
                MessageBox.Show(ex.Message);conn.Close();
            }

            











            

        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                // Get path of file
                String path = file;
                fileToCopy = path;
                // Change the file shown in the rich textbox
                richTextBox1.Text = path;
            }
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
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
            System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(conn);
            string c_name_of_classDB = c_name.Text;
            string num_of_ex_classDB = numofex.Text;
            string num_of_pers_clasDB= numofpers.Text;
            string num_of_teams_classDB=numofteam.Text;
            string name_of_exe_classDB = textname.Text;
            //string name_of_file_classDB=




           

            com.CommandText = "Insert into Class values ('"+c_name_of_classDB+ "','"+num_of_ex_classDB+ "','"+num_of_pers_clasDB+ "','"+num_of_teams_classDB+ "','"+name_of_exe_classDB+"');";

            
            try
            {

                SQLiteCommand cmd = new SQLiteCommand(com.CommandText, conn);
                SQLiteDataReader reader = cmd.ExecuteReader();
                com.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Καταχωρηθηκαν εργασίες τάξης", "ΟΚ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            
        
            catch (Exception exception)
            {
                // Default error message
                MessageBox.Show("ERROR: Πιθανόν βάλατε ήδη υπάρχουσα τάξη");
            }

                conn.Close();





            
        }

        private void Professor_set_homework_Load(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void visi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void IDtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void hwname_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void class_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void maxvathmos_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void subject_TextChanged(object sender, EventArgs e)
        {

        }

        private void deadliner_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
