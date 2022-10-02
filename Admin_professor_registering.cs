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
    public partial class Admin_professor_registering : Form
    {
        // Για να μπορώ να καλέσω τις συναρτήσεις της κλάσης "Admin"
        Admin admin;

        public Admin_professor_registering(Admin a)
        {
            InitializeComponent();
            admin = a;
        }

        private void Admin_professor_registering_Load(object sender, EventArgs e)
        {
            label2.Text = admin.Name;
        }

        /// <summary>
        /// Κατά τό πάτημα του κουμπιού "Submit" γίνονται οι απαραίτητοι έλεγχοι για να μην 
        /// μείνει καμία τιμή κενή, και εντέλει καλείται η συνάρτηση απο την κλάση 
        /// Admin η οποία είναι υπεύθυνη για την δημιουργία καινούριου καθηγητή
        /// </summary>
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2TextBox5.Text != guna2TextBox6.Text)
                {
                    MessageBox.Show("Οι 2 κωδικοί που πληκτρολογήσατε δεν είναι ίδιοι. Πρακαλώ προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (guna2TextBox1.Text == "")
                {
                    MessageBox.Show("Δεν μπορείτε να αφήσετε το πεδίο \"Όνομα\" κενό. Προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (guna2TextBox2.Text == "")
                {
                    MessageBox.Show("Δεν μπορείτε να αφήσετε το πεδίο \"Επίθετο\" κενό. Προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (guna2TextBox3.Text == "")
                {
                    MessageBox.Show("Δεν μπορείτε να αφήσετε το πεδίο \"Email\" κενό. Προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (guna2TextBox4.Text == "")
                {
                    MessageBox.Show("Δεν μπορείτε να αφήσετε το πεδίο \"Username\" κενό. Προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (guna2TextBox5.Text == "")
                {
                    MessageBox.Show("Δεν μπορείτε να αφήσετε το πεδίο \"Password\" κενό. Προσπαθήστε ξανά", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else
                {
                    string name = guna2TextBox1.Text;
                    string surname = guna2TextBox2.Text;
                    string email = guna2TextBox3.Text;
                    string username = guna2TextBox4.Text;
                    string password = guna2TextBox5.Text;

                    // Κλήση της συνάρτησης του Admin για να φτιαχτεί ένας νέος Professor με τα στοιχεία απο την φόρμα
                    admin.createProfessor(name, surname, email, username, password);
                }
            }
            catch (Exception exception)
            {
                // Default error message
                MessageBox.Show(exception.Message);
            }
        }

        /// <summary>
        /// Οταν ο χρήστης κάνει hover πάνω απο το εικονίδιο για παραπάνω 
        /// πληροφορίες εμφανίζεται ένα πάνελ με αυτές τις παραπάνω πληροφορίες
        /// </summary>
        private void guna2PictureBox2_MouseHover(object sender, EventArgs e)
        {
            richTextBox1.Visible = true;
        }

        /// <summary>
        /// Οταν ο χρήστης κάνει hover έξω απο το εικονίδιο για παραπάνω 
        /// πληροφορίες εξαφανίζεται το πάνελ με αυτές τις παραπάνω πληροφορίες
        /// </summary>
        private void guna2PictureBox2_MouseLeave(object sender, EventArgs e)
        {
            richTextBox1.Visible = false;
        }

        /// <summary>
        /// Όταν ο χρήστης βρίσκεται στο textbox της επαλήθευσης του κωδικού του,
        /// τότε αν πατήσει enter, είναι σαν να έκανε κλικ στο κουμπί "Submit" 
        /// </summary>
        private void guna2TextBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2Button1_Click(this, new EventArgs());
            }
        }
    }
}
