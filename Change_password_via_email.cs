using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework
{
    public partial class Change_password_via_email : Form
    {
        LoginForm loginForm;
        public Change_password_via_email(LoginForm lf)
        {
            InitializeComponent();
            loginForm = lf;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Επιστροφή στο login form
            loginForm.Enabled = true;
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Αποστολή email με τον καινούριο κωδικό
        }
    }
}
