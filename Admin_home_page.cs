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
    public partial class Admin_home_page : Form
    {
        // θα το χρησιμοποιήσω για να μπορώ να γυρίσω πίσω στην Login form
        LoginForm loginForm;

        // Κάποια flags τα οποία κυρίως ασχολούνται στη συνέχεια
        // με τον χρωματισμό των κουμπιών αλλά και με το ποιά φόρμα
        // εμφανίζεται όταν ο χρήστης πατάει κάποιο απο τα πλαινά κουμπιά

        public static bool kataxorisi_kathigiti_is_active = false;
        public static bool probolh_listas_is_active = false;
        public static bool diagrafi_kathigiti_is_active = false;

        // Κάποια Public αντικείμενα των φορμών που ανοίγουν μέσα 
        // στο πάνελ του κυρίως μενού του καθηγητή

        Admin_professor_registering apr;
        Admin_show_list_of_professors aslop;
        Admin_delete_professor adp;

        /// <summary>
        /// Μεσα στο κεντρικό πανελ στο κεντρικό μενού του αδμιν, ανάλογα με ποιό κουμπί πατηθεί
        /// απο την αριστερή μερια, πετάγεται και η ανάλογη φόρμα. Όταν όμως ο χρήστης πατήσει άλλο κουμπί,
        /// η τρέχουσα φόρμα που φαίνεται εκείνη τη στιγμή πρέπει να κλείσει. Αυτή η συνάρτηση
        /// ασχολείται με το να κλείνει κάθε φορά την τρέχουσα ανοιχτή φόρμα μέσα στο πάνελ, ωστε να 
        /// μπορέσει να ανοίξει μία καινούργια.
        /// </summary>
        void close_current_form_in_panel()
        {
            if (kataxorisi_kathigiti_is_active)
            {
                kataxorisi_kathigiti_is_active = false;
                apr.Close();
            }
            else if (probolh_listas_is_active)
            {
                probolh_listas_is_active = false;
                aslop.Close();
            }
            else if (diagrafi_kathigiti_is_active)
            {
                diagrafi_kathigiti_is_active = false;
                adp.Close();
            }
        }

        /// <summary>
        /// Κάθε φορά που ο χρήστης πατάει ένα κουμπί απο το αριστερά μενού,
        /// καλείται αυτη η συνάρτηση για να χρωματίσει κατάλληλα το background
        /// του κουμπιού ωστε να είναι πιο ευδιάκριτο στο μάτι
        /// </summary>
        void paint_button_background()
        {
            if (kataxorisi_kathigiti_is_active)
            {
                // For guna button 1
                guna2Button1.BackColor = Color.FromArgb(108, 67, 67);
                guna2Button1.FillColor = Color.FromArgb(108, 67, 67);
                // For guna button 2
                guna2Button2.BackColor = Color.FromArgb(54, 73, 104);
                guna2Button2.FillColor = Color.FromArgb(54, 73, 104);
                // For guna button 3
                guna2Button3.BackColor = Color.FromArgb(54, 73, 104);
                guna2Button3.FillColor = Color.FromArgb(54, 73, 104);
            }
            else if (probolh_listas_is_active)
            {
                // For guna button 1
                guna2Button1.BackColor = Color.FromArgb(54, 73, 104);
                guna2Button1.FillColor = Color.FromArgb(54, 73, 104);
                // For guna button 2
                guna2Button2.BackColor = Color.FromArgb(108, 67, 67);
                guna2Button2.FillColor = Color.FromArgb(108, 67, 67);
                // For guna button 3
                guna2Button3.BackColor = Color.FromArgb(54, 73, 104);
                guna2Button3.FillColor = Color.FromArgb(54, 73, 104);
            }
            else if (diagrafi_kathigiti_is_active)
            {
                // For guna button 1
                guna2Button1.BackColor = Color.FromArgb(54, 73, 104);
                guna2Button1.FillColor = Color.FromArgb(54, 73, 104);
                // For guna button 2
                guna2Button2.BackColor = Color.FromArgb(54, 73, 104);
                guna2Button2.FillColor = Color.FromArgb(54, 73, 104);
                // For guna button 3
                guna2Button3.BackColor = Color.FromArgb(108, 67, 67);
                guna2Button3.FillColor = Color.FromArgb(108, 67, 67);
            }
        }

        public Admin_home_page(LoginForm login)
        {
            InitializeComponent();
            // θα το χρησιμοποιήσω για να μπορώ να γυρίσω πίσω στην Login form
            loginForm = login;
        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Έξοδος"
        /// Επιστρέφω στην Login form
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            loginForm.Show();
        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Καταχώρηση καθηγητών"
        /// </summary>
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (kataxorisi_kathigiti_is_active == false)
            {
                // Κλεινω την τρέχουσα ανοιχτή φόρμα
                close_current_form_in_panel();

                // Φτιαχνω κάποια flags για το UI

                kataxorisi_kathigiti_is_active = true;
                probolh_listas_is_active = false;
                diagrafi_kathigiti_is_active = false;

                // Ζωγραφίζω το background του κουμπιού
                paint_button_background();

                // Άνοιγμα της φόρμας που ασχολείται με τα μαθήματά μου μέσα στο πάνελ της Form1

                apr = new Admin_professor_registering() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel3.Controls.Add(apr);
                apr.Show();
            }
        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Εμφάνιση λίστας καθηγητών"
        /// </summary>
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (probolh_listas_is_active == false)
            {
                // Κλεινω την τρέχουσα ανοιχτή φόρμα
                close_current_form_in_panel();

                // Φτιαχνω κάποια flags για το UI

                kataxorisi_kathigiti_is_active = false;
                probolh_listas_is_active = true;
                diagrafi_kathigiti_is_active = false;

                // Ζωγραφίζω το background του κουμπιού
                paint_button_background();

                // Άνοιγμα της φόρμας που ασχολείται με τα μαθήματά μου μέσα στο πάνελ της Form1

                aslop = new Admin_show_list_of_professors { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel3.Controls.Add(aslop);
                aslop.Show();
            }
        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Διαγραφή καθηγητή"
        /// </summary>
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (diagrafi_kathigiti_is_active == false)
            {
                // Κλεινω την τρέχουσα ανοιχτή φόρμα
                close_current_form_in_panel();

                // Φτιαχνω κάποια flags για το UI

                kataxorisi_kathigiti_is_active = false;
                probolh_listas_is_active = false;
                diagrafi_kathigiti_is_active = true;

                // Ζωγραφίζω το background του κουμπιού
                paint_button_background();

                // Άνοιγμα της φόρμας που ασχολείται με τα μαθήματά μου μέσα στο πάνελ3 της Form

                adp = new Admin_delete_professor { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel3.Controls.Add(adp);
                adp.Show();
            }
        }
    }
}
