using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Homework
{
    public class Admin : Person
    {
        int adminID;
        public int AdminID
        {
            get { return adminID; }
            set { adminID = value; }
        }

        /// <summary>
        /// Σε αυτή την συνάρτηση μέσα γίνεται η σύνδεση με την βάση ετσι ώστε
        /// να γίνει η εγγραφή κάποιου καθηγητή μέσα στη βάση
        /// </summary>
        internal void createProfessor(string name, string surname, string email, string username, string password)
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
            string query1 = "INSERT INTO Professor(name,surname,email,username,password) VALUES ('" + name + "','" + surname + "','" + email + "','" + username + "','" + password + "');";
            SQLiteCommand cmd = new SQLiteCommand(query1, conn);
            SQLiteDataReader reader = cmd.ExecuteReader();

            reader.Close();
            conn.Close();
            MessageBox.Show("Ο νέος καθηγητής έχει καταχωρηθεί στο σύστημα επιτυχώς!!"
                , "Sign up successful."
                , MessageBoxButtons.OK
                , MessageBoxIcon.Information);
        }
    }
}