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
    public partial class Professor_my_lessons : Form
    {
        Professor professor;

        public Professor_my_lessons(Professor p)
        {
            InitializeComponent();
            professor = p;
        }

        private void Professor_my_lessons_Load(object sender, EventArgs e)
        {
            label2.Text = professor.Name;
        }
    }
}
