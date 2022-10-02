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
    public partial class Admin_delete_professor : Form
    {
        Admin admin;

        public Admin_delete_professor(Admin a)
        {
            InitializeComponent();
            admin = a;
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

                //if(reader.Read())
                //{
                //    MessageBox.Show("Ο καθηγητής με id " + guna2TextBox1.Text + " έχει πλέον διαγραφεί από το σύστημα!!"
                //        , "Deleting successful."
                //        , MessageBoxButtons.OK
                //        , MessageBoxIcon.Information);
                //}
                //else
                //{
                //    MessageBox.Show("Δεν υπάρχει καθηγητής με το συγκεκριμένο id... Προσπαθήστε ξανά"
                //        , "Σφάλμα!"
                //        , MessageBoxButtons.OK
                //        , MessageBoxIcon.Error);
                //}

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

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2Button1_Click(this, new EventArgs());
            }
        }
    }
}
