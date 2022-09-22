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
    public partial class Form1 : Form
    {
        // Κάποια flags τα οποία κυρίως ασχολούνται στη συνέχεια
        // με τον χρωματισμό τν κουμπιών αλλά και με το ποιά φόρμα
        // εμφανίζεται όταν ο χρήστης πατάει κάποιο απο τα πλαινά κουμπιά

        public static bool ta_mathimata_is_active = false;
        public static bool trexouses_ergasies_is_active = false;
        public static bool ypobolh_ergasias_is_active = false;
        public static bool h_omada_mou_is_active = false;

        // Κάποια Public αντικείμενα των φορμών που ανοίγουν μέσα 
        // στο πάνελ του κυρίως μενού του μαθητή

        Student_my_lessons sml;
        Student_see_current_homework ssch;
        Student_submit_homework ssh;
        Student_my_team smt;


        /// <summary>
        /// Κάθε φορά που ο χρήστης πατάει ένα κουμπί απο το αριστερά μενού,
        /// καλείται αυτη η συνάρτηση για να χρωματίσει κατάλληλα στο background
        /// στο δεξί μέρος του κουμπιού ένα κίτρινο πανελάκι ωστε να είναι 
        /// πιο ευδιάκριτο στο μάτι πόιά φόρμα είναι ενεργή την τωρινή στιγμή
        /// </summary>
        void open_a_yellow_panel()
        {
            if(ta_mathimata_is_active)
            {
                panel4.Visible = true;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
            }
            else if(trexouses_ergasies_is_active)
            {
                panel4.Visible = false;
                panel5.Visible = true;
                panel6.Visible = false;
                panel7.Visible = false;
            }
            else if(ypobolh_ergasias_is_active)
            {
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = true;
                panel7.Visible = false;
            }
            else if (h_omada_mou_is_active)
            {
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = true;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Κλείνει την εφαρμογή
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Φτιαχνει ενα bug που για κάποιο λόγο δεν μου φόρτωνε την εικόνα (μονο αυτη για καποιο λόγο)
            button5.Image = Image.FromFile("pictures/team.png");
        }

        /// <summary>
        /// Μεσα στο κεντρικό πανελ στο κεντρικό μενού του μαθητή, ανάλογα με ποιό κουμπί πατηθεί
        /// απο την αριστερή μερια, πετάγεται και η ανάλογη φόρμα. Όταν όμως ο χρήστης πατήσει άλλο κουμπί,
        /// η τρέχουσα φόρμα που φαίνεται εκείνη τη στιγμή πρέπει να κλείσει. Αυτή η συνάρτηση
        /// ασχολείται με το να κλείνει κάθε φορά την τρέχουσα ανοιχτή φόρμα μέσα στο πάνελ, ωστε να 
        /// μπορέσει να ανοίξει μία καινούργια.
        /// </summary>
        void close_current_form_in_panel()
        {
            if(ta_mathimata_is_active)
            {
                ta_mathimata_is_active = false;
                sml.Close();
            }
            else if(trexouses_ergasies_is_active)
            {
                trexouses_ergasies_is_active = false;
                ssch.Close();
            }
            else if(ypobolh_ergasias_is_active)
            {
                ypobolh_ergasias_is_active = false;
                ssh.Close();
            }
            else if(h_omada_mou_is_active)
            {
                h_omada_mou_is_active = false;
                smt.Close();
            }
        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Τα μαθήματά μου"
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            if (ta_mathimata_is_active == false)
            {
                // Κλεινω την τρέχουσα α΄νοιχτή φόρμα
                close_current_form_in_panel();

                // Δίνω τις κατάλληλες τιμές σε κάποια flags

                ta_mathimata_is_active = true;
                trexouses_ergasies_is_active = false;
                ypobolh_ergasias_is_active = false;
                h_omada_mou_is_active = false;
                open_a_yellow_panel(); // Κιτρινίζω το κατάλληλο πάνελ

                // Άνοιγμα της φόρμας που ασχολείται με τα μαθήματά μου μέσα στο πάνελ της Form1

                sml = new Student_my_lessons() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel2.Controls.Add(sml);
                sml.Show();
            }
        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Προβολή τρέχοντων εργασιών"
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            if (trexouses_ergasies_is_active == false)
            {
                // Κλεινω την τρέχουσα α΄νοιχτή φόρμα
                close_current_form_in_panel();

                // Δίνω τις κατάλληλες τιμές σε κάποια flags

                ta_mathimata_is_active = false;
                trexouses_ergasies_is_active = true;
                ypobolh_ergasias_is_active = false;
                h_omada_mou_is_active = false;
                open_a_yellow_panel(); // Κιτρινίζω το κατάλληλο πάνελ

                // Άνοιγμα της φόρμας που ασχολείται με τα μαθήματά μου μέσα στο πάνελ της Form1

                ssch = new Student_see_current_homework() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel2.Controls.Add(ssch);
                ssch.Show();
            }
        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Υποβολή εργασίας"
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            // Κλεινω την τρέχουσα α΄νοιχτή φόρμα
            close_current_form_in_panel();

            if (ypobolh_ergasias_is_active == false)
            {
                // Δίνω τις κατάλληλες τιμές σε κάποια flags

                ta_mathimata_is_active = false;
                trexouses_ergasies_is_active = false;
                ypobolh_ergasias_is_active = true;
                h_omada_mou_is_active = false;
                open_a_yellow_panel(); // Κιτρινίζω το κατάλληλο πάνελ

                // Άνοιγμα της φόρμας που ασχολείται με τα μαθήματά μου μέσα στο πάνελ της Form1

                ssh = new Student_submit_homework { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel2.Controls.Add(ssh);
                ssh.Show();
            }
        }

        /// <summary>
        /// Αυτό το κουμπί ασχολείται με όλα όσα γίνονται αφού ο χρήστης πατήσει
        /// το κουμπί "Η ομάδα μου"
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            // Κλεινω την τρέχουσα α΄νοιχτή φόρμα
            close_current_form_in_panel();

            if (h_omada_mou_is_active == false)
            {
                // Δίνω τις κατάλληλες τιμές σε κάποια flags

                ta_mathimata_is_active = false;
                trexouses_ergasies_is_active = false;
                ypobolh_ergasias_is_active = false;
                h_omada_mou_is_active = true;
                open_a_yellow_panel(); // Κιτρινίζω το κατάλληλο πάνελ

                // Άνοιγμα της φόρμας που ασχολείται με τα μαθήματά μου μέσα στο πάνελ της Form1

                smt = new Student_my_team { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                this.panel2.Controls.Add(smt);
                smt.Show();
            }
        }
    }
}
