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
    public partial class Email_sending_animation : Form
    {
        int timerCounter = 0;

        public Email_sending_animation()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerCounter++;
            if(timerCounter == 10)
            {
                this.Close();

                // Αφού σταλεί το email, δείχνω ένα μήνυμα επιβεβαίωσης
                MessageBox.Show("Ο κωδικός σας άλλαξε επιτυχώς. συνδεθείτε στο email σας για να δείτε τον καινούρια σας κωδικο"
                    , "Επιτυχής αλλαγή κωδικού"
                    , MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
            }
        }
    }
}
