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
        // Για να μπορώ να καλέσω την συνάρτηση διαγραφής καθηγητή
        Admin admin;

        public Admin_delete_professor(Admin a)
        {
            InitializeComponent();
            admin = a;
        }

        /// <summary>
        /// Καλώ την συνάρτηση διαγραφής του καθηγητή μέσω της κλάσης Admin
        /// </summary>
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            admin.deleteProfessor(guna2TextBox1.Text);
        }

        /// <summary>
        /// Όταν ο χρήστης πληκτρολογήσει ένα id και πατήσει enter, γίνεται ότι
        /// θα γινόταν και αν πα΄τούσε το κουμπί delete
        /// </summary>
        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2Button1_Click(this, new EventArgs());
            }
        }
    }
}
