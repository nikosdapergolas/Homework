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
        // Κάποια flags τα οποία κυρίως ασχολούνται στη συνέχεια
        // με τον χρωματισμό τν κουμπιών αλλά και με το ποιά φόρμα
        // εμφανίζεται όταν ο χρήστης πατάει κάποιο απο τα πλαινά κουμπιά

        public static bool ta_mathimata_mou_is_active = false;
        public static bool trexouses_ergasies_is_active = false;
        public static bool orismos_ergasias_is_active = false;
        public static bool vathmologish_is_active = false;

        public Professor_home_page()
        {
            InitializeComponent();
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
                guna2Button2.BackColor = Color.FromArgb(75, 117, 81);
                guna2Button2.FillColor = Color.FromArgb(75, 117, 81);
                // For guna button 3
                guna2Button3.BackColor = Color.FromArgb(48, 77, 78);
                guna2Button3.FillColor = Color.FromArgb(48, 77, 78);
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
                guna2Button2.BackColor = Color.FromArgb(48, 77, 78);
                guna2Button2.FillColor = Color.FromArgb(48, 77, 78);
                // For guna button 3
                guna2Button3.BackColor = Color.FromArgb(75, 117, 81);
                guna2Button3.FillColor = Color.FromArgb(75, 117, 81);
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
            // Φτιαχνω κάποια flags για το UI

            ta_mathimata_mou_is_active = true;
            trexouses_ergasies_is_active = false;
            orismos_ergasias_is_active = false;
            vathmologish_is_active = false;

            // Ζωγραφίζω το background του κουμπιού
            paint_button_background();
        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Τρέχουσες εργασίες"
        /// </summary>
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Φτιαχνω κάποια flags για το UI

            ta_mathimata_mou_is_active = false;
            trexouses_ergasies_is_active = true;
            orismos_ergasias_is_active = false;
            vathmologish_is_active = false;

            // Ζωγραφίζω το background του κουμπιού
            paint_button_background();
        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Ορισμός εργασίας"
        /// </summary>
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Φτιαχνω κάποια flags για το UI

            ta_mathimata_mou_is_active = false;
            trexouses_ergasies_is_active = false ;
            orismos_ergasias_is_active = true;
            vathmologish_is_active = false;

            // Ζωγραφίζω το background του κουμπιού
            paint_button_background();
        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Βαθμολόγηση"
        /// </summary>
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            // Φτιαχνω κάποια flags για το UI

            ta_mathimata_mou_is_active = false;
            trexouses_ergasies_is_active = false;
            orismos_ergasias_is_active = false;
            vathmologish_is_active = true;

            // Ζωγραφίζω το background του κουμπιού
            paint_button_background();
        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Έξοδος"
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
