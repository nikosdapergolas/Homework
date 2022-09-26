using FluentEmail.Core;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
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
        public static bool change_is_happening = false;
        int new_password;
        LoginForm loginForm;
        public Change_password_via_email(LoginForm lf)
        {
            InitializeComponent();
            loginForm = lf;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Οταν πάω πίσω, αν πρέπει να γίνει αλλαγή κωδικού, την κάνω
            if(change_is_happening)
            {
                //change_password(new_password);
                change_password(new_password);
            }

            // Επιστροφή στο login form
            loginForm.Enabled = true;
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(guna2TextBox1.Text == "")
            {
                MessageBox.Show("Δεν μπορείτε να αφήσετε κενό το πεδίο του username.\nΠαρακαλώ εισάγετε το username του προφίλ σας στο οποίο έχετε ξεχάσει τον κωδικό"
                    ,"Σφάλμα!"
                    ,MessageBoxButtons.OK
                    ,MessageBoxIcon.Error);
            }
            else
            {
                // Name of database file
                string fileName = "HomeworkManagement.db";
                FileInfo f = new FileInfo(fileName);
                // Full path to it
                string path = f.FullName;

                // Connection string with relative path
                string connectionstring = "Data Source=" + path + ";Version=3;";
                string query1 = "select * from Student where username='" + guna2TextBox1.Text + "';";

                using (SQLiteConnection conn = new SQLiteConnection(connectionstring))
                {
                    conn.Open();
                    using (SQLiteCommand cmd = new SQLiteCommand(query1, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Περνάω στο αντικείμενο Student τις τιμές που αντιστοιχούν σε αυτόν στη βάση
                                // Σύμφωνα με το username του
                                Student student = new Student();

                                student.A_M = (int)reader.GetInt32(0);
                                student.Name = reader.GetString(1);
                                student.Surname = reader.GetString(2);
                                student.Email = reader.GetString(3);

                                // Γέννηση κάποιου καινούριου τυχαίου κωδικού

                                Random rnd = new Random();
                                new_password = rnd.Next();

                                // Μηνυμα επιτυχίας και χαράς
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
                                    .To(student.Email)
                                    .Subject("Αλλαγη κωδικού πρόσβασης")
                                    .Body("Ο καινούριος σας κωδικός είναι ο εξής: \n" + new_password.ToString())
                                    .SendAsync();

                                change_is_happening = true;

                                // Σε αυτό το σημείο θα πετάξω μία φόρμα στον χρήστη με ένα loading animation στον χρήστη
                                // για να φαίνεται πως το email στέλνεται εκείνη τη στιγμή στον email provider του
                                Email_sending_animation email_Sending_animation = new Email_sending_animation();
                                email_Sending_animation.Show();
                            }
                            else
                            {
                                // Μήνυμα μη εύρεσης μαθητή με αυτό το username

                                MessageBox.Show("Δεν υπάρχει κάποιος μαθητής στο σύστημα με το username που πληκτρολογήσατε. \nΠαρακαλούμε ελέγξτε αν κάνατε λάθος και προσπαθείστε ξανά"
                                , "Σφάλμα!"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Error);

                                change_is_happening = false;
                            }
                        }
                    }
                    conn.Close();
                }              
            }            
        }

        void change_password(int new_random_password)
        {
            // Name of database file
            string fileName = "HomeworkManagement.db";
            FileInfo f = new FileInfo(fileName);
            // Full path to it
            string path = f.FullName;

            // Connection string with relative path
            string connectionstring = "Data Source=" + path + ";Version=3;";

            //SQLiteConnection conn2 = new SQLiteConnection(connectionstring);
            //conn2.Open();
            // Το καινούργιο query που αλλάζει τον κωδικό του χρήστη σε αυτόν που του έδωσα

            string query2 = "UPDATE Student SET password = '" + new_password.ToString() + "' WHERE username = '" + guna2TextBox1.Text.ToString() + "';";
            //SQLiteCommand cmd2 = new SQLiteCommand(query2, conn2);
            //SQLiteDataReader reader2 = cmd2.ExecuteReader();
            //conn2.Close();
            using (SQLiteConnection conn2 = new SQLiteConnection(connectionstring))
            {
                conn2.Open();
                using (SQLiteCommand cmd2 = new SQLiteCommand(query2, conn2))
                {
                    cmd2.ExecuteNonQuery();
                }
                conn2.Close();
            }
        }

        private void guna2Button2_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                guna2Button2_Click(this, new EventArgs());
            }
        }
    }
}
