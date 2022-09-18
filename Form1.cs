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
        public static bool ta_mathimata_is_active = false;
        public static bool trexouses_ergasies_is_active = false;
        public static bool ypobolh_ergasias_is_active = false;
        public static bool h_omada_mou_is_active = false;



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

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Φτιαχνει ενα bug που για κάποιο λόγο δεν μου φόρτωνε την εικόνα (μονο αυτη για καποιο λόγο)
            button5.Image = Image.FromFile("pictures/team.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Δίνω τις κατάλληλες τιμές σε κάποια flags

            ta_mathimata_is_active = true;
            trexouses_ergasies_is_active = false;
            ypobolh_ergasias_is_active = false;
            h_omada_mou_is_active = false;
            open_a_yellow_panel(); // Κιτρινίζω το κατάλληλο πάνελ

            // Άνοιγμα της φόρμας που ασχολείται με τα μαθήματά μου μέσα στο πάνελα της Form1

            Student_my_lessons sml = new Student_my_lessons() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel2.Controls.Add(sml);
            sml.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Δίνω τις κατάλληλες τιμές σε κάποια flags

            ta_mathimata_is_active = false;
            trexouses_ergasies_is_active = true;
            ypobolh_ergasias_is_active = false;
            h_omada_mou_is_active = false;
            open_a_yellow_panel(); // Κιτρινίζω το κατάλληλο πάνελ
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Δίνω τις κατάλληλες τιμές σε κάποια flags

            ta_mathimata_is_active = false;
            trexouses_ergasies_is_active = false;
            ypobolh_ergasias_is_active = true;
            h_omada_mou_is_active = false;
            open_a_yellow_panel(); // Κιτρινίζω το κατάλληλο πάνελ
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Δίνω τις κατάλληλες τιμές σε κάποια flags

            ta_mathimata_is_active = false;
            trexouses_ergasies_is_active = false;
            ypobolh_ergasias_is_active = false;
            h_omada_mou_is_active = true;
            open_a_yellow_panel(); // Κιτρινίζω το κατάλληλο πάνελ
        }
    }
}
