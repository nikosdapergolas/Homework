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
    public partial class Professor_home_page : Form
    {
        // θα το χρησιμοποιήσω για να μπορώ να γυρίσω πίσω στην Login form
        LoginForm loginForm;

        // Κάποια flags τα οποία κυρίως ασχολούνται στη συνέχεια
        // με τον χρωματισμό τν κουμπιών αλλά και με το ποιά φόρμα
        // εμφανίζεται όταν ο χρήστης πατάει κάποιο απο τα πλαινά κουμπιά

        public static bool ta_mathimata_mou_is_active = false;
        public static bool trexouses_ergasies_is_active = false;
        public static bool orismos_ergasias_is_active = false;
        public static bool vathmologish_is_active = false;

        // Κάποια Public αντικείμενα των φορμών που ανοίγουν μέσα 
        // στο πάνελ του κυρίως μενού του καθηγητή

        Professor_my_lessons pml;
        Professor_current_homework pch;
        Professor_set_homework psh;
        Professor_grading pg;

        /// <summary>
        /// Μεσα στο κεντρικό πανελ στο κεντρικό μενού του καθηγητή, ανάλογα με ποιό κουμπί πατηθεί
        /// απο την αριστερή μερια, πετάγεται και η ανάλογη φόρμα. Όταν όμως ο χρήστης πατήσει άλλο κουμπί,
        /// η τρέχουσα φόρμα που φαίνεται εκείνη τη στιγμή πρέπει να κλείσει. Αυτή η συνάρτηση
        /// ασχολείται με το να κλείνει κάθε φορά την τρέχουσα ανοιχτή φόρμα μέσα στο πάνελ, ωστε να 
        /// μπορέσει να ανοίξει μία καινούργια.
        /// </summary>
        void close_current_form_in_panel()
        {
            if (ta_mathimata_mou_is_active)
            {
                ta_mathimata_mou_is_active = false;
                pml.Close();
            }
            else if (trexouses_ergasies_is_active)
            {
                trexouses_ergasies_is_active = false;
                pch.Close();
            }
            else if (orismos_ergasias_is_active)
            {
                orismos_ergasias_is_active = false;
                psh.Close();
            }
            else if (vathmologish_is_active)
            {
                vathmologish_is_active = false;
                pg.Close();
            }
        }

        public Professor_home_page(LoginForm login)
        {
            InitializeComponent();
            // θα το χρησιμοποιήσω για να μπορώ να γυρίσω πίσω στην Login form
            loginForm = login;
        }

        /// <summary>
        /// Κάθε φορά που ο χρήστης πατάει ένα κουμπί απο το αριστερά μενού,
        /// καλείται αυτη η συνάρτηση για να χρωματίσει κατάλληλα το background
        /// του κουμπιού ωστε να είναι πιο ευδιάκριτο στο μάτι
        /// </summary>
        void paint_button_background()
        {
            if(ta_mathimata_mou_is_active)
            {
                // For guna button 1
                guna2Button1.BackColor = Color.FromArgb(75, 117, 81);
                guna2Button1.FillColor = Color.FromArgb(75, 117, 81);
                // For guna button 2
                guna2Button2.BackColor = Color.FromArgb(48, 77, 78);
                guna2Button2.FillColor = Color.FromArgb(48, 77, 78);
                // For guna button 3
                guna2Button3.BackColor = Color.FromArgb(48, 77, 78);
                guna2Button3.FillColor = Color.FromArgb(48, 77, 78);
                // For guna button 4
                guna2Button4.BackColor = Color.FromArgb(48, 77, 78);
                guna2Button4.FillColor = Color.FromArgb(48, 77, 78);
            }
            else if(trexouses_ergasies_is_active)
            {
                // For guna button 1
                guna2Button1.BackColor = Color.FromArgb(48, 77, 78);
                guna2Button1.FillColor = Color.FromArgb(48, 77, 78);
                // For guna button 2
                guna2Button2.BackColor = Color.FromArgb(48, 77, 78);
                guna2Button2.FillColor = Color.FromArgb(48, 77, 78);
                // For guna button 3
                guna2Button3.BackColor = Color.FromArgb(75, 117, 81);
                guna2Button3.FillColor = Color.FromArgb(75, 117, 81);
                // For guna button 4
                guna2Button4.BackColor = Color.FromArgb(48, 77, 78);
                guna2Button4.FillColor = Color.FromArgb(48, 77, 78);
            }
            else if(orismos_ergasias_is_active)
            {
                // For guna button 1
                guna2Button1.BackColor = Color.FromArgb(48, 77, 78);
                guna2Button1.FillColor = Color.FromArgb(48, 77, 78);
                // For guna button 2
                guna2Button2.BackColor = Color.FromArgb(75, 117, 81);
                guna2Button2.FillColor = Color.FromArgb(75, 117, 81);
                // For guna button 3
                guna2Button3.BackColor = Color.FromArgb(48, 77, 78);
                guna2Button3.FillColor = Color.FromArgb(48, 77, 78);
                // For guna button 4
                guna2Button4.BackColor = Color.FromArgb(48, 77, 78);
                guna2Button4.FillColor = Color.FromArgb(48, 77, 78);
            }
            else if(vathmologish_is_active)
            {
                // For guna button 1
                guna2Button1.BackColor = Color.FromArgb(48, 77, 78);
                guna2Button1.FillColor = Color.FromArgb(48, 77, 78);
                // For guna button 2
                guna2Button2.BackColor = Color.FromArgb(48, 77, 78);
                guna2Button2.FillColor = Color.FromArgb(48, 77, 78);
                // For guna button 3
                guna2Button3.BackColor = Color.FromArgb(48, 77, 78);
                guna2Button3.FillColor = Color.FromArgb(48, 77, 78);
                // For guna button 4
                guna2Button4.BackColor = Color.FromArgb(75, 117, 81);
                guna2Button4.FillColor = Color.FromArgb(75, 117, 81);
            }
        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Τα μαθήματά μου"
        /// </summary>
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (ta_mathimata_mou_is_active == false)
            {
                // Κλεινω την τρέχουσα ανοιχτή φόρμα
                close_current_form_in_panel();

                // Φτιαχνω κάποια flags για το UI

                ta_mathimata_mou_is_active = true;
                trexouses_ergasies_is_active = false;
                orismos_ergasias_is_active = false;
                vathmologish_is_active = false;

                // Ζωγραφίζω το background του κουμπιού
                paint_button_background();

                // Άνοιγμα της φόρμας που ασχολείται με τα μαθήματά μου μέσα στο πάνελ της Form1

                pml = new Professor_my_lessons() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel2.Controls.Add(pml);
                pml.Show();
            }
        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Ορισμός εργασίας"
        /// </summary>
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (orismos_ergasias_is_active == false)
            {
                // Κλεινω την τρέχουσα ανοιχτή φόρμα
                close_current_form_in_panel();

                // Φτιαχνω κάποια flags για το UI

                ta_mathimata_mou_is_active = false;
                trexouses_ergasies_is_active = false;
                orismos_ergasias_is_active = true;
                vathmologish_is_active = false;

                // Ζωγραφίζω το background του κουμπιού
                paint_button_background();

                // Άνοιγμα της φόρμας που ασχολείται με τα μαθήματά μου μέσα στο πάνελ της Form1

                psh = new Professor_set_homework() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel2.Controls.Add(psh);
                psh.Show();
            }
        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Τρέχουσες εργασίες"
        /// </summary>
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (trexouses_ergasies_is_active == false)
            {
                // Κλεινω την τρέχουσα ανοιχτή φόρμα
                close_current_form_in_panel();

                // Φτιαχνω κάποια flags για το UI

                ta_mathimata_mou_is_active = false;
                trexouses_ergasies_is_active = true;
                orismos_ergasias_is_active = false;
                vathmologish_is_active = false;

                // Ζωγραφίζω το background του κουμπιού
                paint_button_background();

                // Άνοιγμα της φόρμας που ασχολείται με τα μαθήματά μου μέσα στο πάνελ της Form1

                pch = new Professor_current_homework() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel2.Controls.Add(pch);
                pch.Show();
            }
        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Βαθμολόγηση"
        /// </summary>
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            if (vathmologish_is_active == false)
            {
                // Κλεινω την τρέχουσα ανοιχτή φόρμα
                close_current_form_in_panel();

                // Φτιαχνω κάποια flags για το UI

                ta_mathimata_mou_is_active = false;
                trexouses_ergasies_is_active = false;
                orismos_ergasias_is_active = false;
                vathmologish_is_active = true;

                // Ζωγραφίζω το background του κουμπιού
                paint_button_background();

                // Άνοιγμα της φόρμας που ασχολείται με τα μαθήματά μου μέσα στο πάνελ της Form1

                pg = new Professor_grading() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel2.Controls.Add(pg);
                pg.Show();
            }

        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Έξοδος" 
        /// Επιστρέφω στο login form
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            loginForm.Show();
        }
    }
}
