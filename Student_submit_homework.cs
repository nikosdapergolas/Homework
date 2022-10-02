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
    public partial class Student_submit_homework : Form
    {
        string file_to_upload_in_db;
        string bob;
        string destinationDirectory;
        string fileToCopy;
        public Student_submit_homework()
        {
            InitializeComponent();
        }

        private void guna2Panel1_DragDrop(object sender, DragEventArgs e)
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

        private void guna2Button2_Click(object sender, EventArgs e)
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
                file_to_upload_in_db = Path.GetFileName(path);

            }
        }

        private void guna2Panel1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void guna2Panel2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                // Get path of file
                String path = file;
                fileToCopy = path;
                // Change the file shown in the rich textbox
                richTextBox2.Text = path;
            }
        }

        private void guna2Panel2_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            //*******************************************************************************
            // Ανάλογα με το ποιός ανεβάζει και τι, μόνο αυτό το σημείο του κώδικα θα αλλάζει
            string fileName = "homework_that_the_students_upload"; // Το αρχείο στο οποίο αποθηκεύουμε τα "τάδε" πράγματα στο bin/debug
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
            //string homeworkid = IDtxt.Text;
            //string nameofHW = hwname.Text;
            //string deadline = deadliner.Text;
            //string file_name = bob;
            //string visibility = visi.Text;
            //string subject1 = subject.Text;
            //string max_grade = maxvathmos.Text;
            //string yearboy = class_name.Text;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

            //*******************************************************************************
            // Ανάλογα με το ποιός ανεβάζει και τι, μόνο αυτό το σημείο του κώδικα θα αλλάζει
            string fileName = "homework_that_the_students_upload"; // Το αρχείο στο οποίο αποθηκεύουμε τα "τάδε" πράγματα στο bin/debug
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
            string Who = guna2TextBox2.Text;
            string  homework_name= guna2ComboBox2.Text;
            string  upload_date= DateTime.Now.ToString();
            string  file_name= file_to_upload_in_db;
            
        }

        private void Student_submit_homework_Load(object sender, EventArgs e)
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

            string query1 = "select nameofhw from Homework_Board ;";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query1, conn);

            DataSet dSet = new DataSet();
            adapter.Fill(dSet);
            //adapter.GetFillParameters(dSet, "wow");
            guna2ComboBox2.DataSource = dSet.Tables[0];
            guna2ComboBox2.DisplayMember = "nameofhw";
            guna2ComboBox1.DataSource = dSet.Tables[0];
            guna2ComboBox1.DisplayMember = "nameofhw";
            DataTable dt = new DataTable();
            conn.Close();
        }
    }
}
