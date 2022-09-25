using FluentEmail.Core;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

            var sender1 = new SmtpSender(() => new SmtpClient("localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25
            });

            Email.DefaultSender = sender1;

            var email = Email
                .From("Homework@team.com")
                .To("nikos.2001@outlook.com.gr")
                .Subject("Αλλαγη κωδικού πρόσβασης")
                .Body("Ο καινούριος σας κωδικός είναι ο εξής: \n123456789")
                .SendAsync();

            // Σε αυτό το σημείο θα πετάξω μία φόρμα στον χρήστη με ένα loading animation στον χρήστη
            // για να φαίνεται πως το email στέλνεται εκείνη τη στιγμή στον email provider του


            // Αφού σταλεί το email, δείχνω ένα μήνυμα επιβεβαίωσης
            MessageBox.Show("Ο κωδικός σας άλλαξε επιτυχώς. συνδεθείτε στο email σας για να δείτε τον καινούρια σας κωδικο"
                , "Επιτυχής αλλαγή κωδικού"
                , MessageBoxButtons.OK
                , MessageBoxIcon.Information);
        }
    }
}
