using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_Catalog_Studentesc
{
    public partial class FormError : Form
    {
        public FormError()
        {
            InitializeComponent();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {
            Form1.gui.Bring_StudentLogPage();
            Form1.gui.Bring_Main_Buttons();
            this.Close();

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        public void SetText(string text)
        {
            bunifuCustomLabel1.Text = text;
        }

        private void FormError_Load(object sender, EventArgs e)
        {

        }
    }
}
