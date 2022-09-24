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
    public partial class Admin_professor_registering : Form
    {
        Admin admin;

        public Admin_professor_registering(Admin a)
        {
            InitializeComponent();
            admin = a;
        }

        private void Admin_professor_registering_Load(object sender, EventArgs e)
        {
            label2.Text = admin.Name;
        }
    }
}
