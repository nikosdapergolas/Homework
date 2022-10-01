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
    public partial class File_uploading_animation : Form
    {
        Nikos_test_form nikos;
        int timer_count = 0;

        public File_uploading_animation(Nikos_test_form given)
        {
            InitializeComponent();
            nikos = given;
        }

        private void File_uploading_animation_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_count++;

            if(timer_count == 10)
            {
                this.Close();
                nikos.Enabled = true;
                nikos.BringToFront();
            }
        }
    }
}
