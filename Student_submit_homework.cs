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
    public partial class Student_submit_homework : Form
    {
        string fileToCopy;
        public Student_submit_homework()
        {
            InitializeComponent();
        }

        private void guna2Panel1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                // Get path of file
                String path = file;
                fileToCopy = path;
                // Change the file shown in the rich textbox
                richTextBox1.Text = path;   
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //OpenFileDialog dialog = new OpenFileDialog();
            //dialog.Multiselect = false; // deny user to upload more than one file at a time
            //if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            //{
            //    bob = dialog.FileName;
            //    // Get path of file
            //    String path = dialog.FileName;
            //    fileToCopy = path;

            //    string filenamex = Path.GetFileName(bob);
            //    bob = filenamex;

            //    // Change the file shown in the rich textbox
            //    richTextBox1.Text = path;
            //}
        }
    }
}
