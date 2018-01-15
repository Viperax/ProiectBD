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
    public partial class LogOut : Form
    {
        public LogOut()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Form1.gui.Bring_StudentLogPage();
            Form1.gui.Reset_StudentLogPage();//resetam toate paginile 
            Form1.gui.Reset_CadruLogPage();
            Form1.gui.Bring_Main_Buttons();
            this.Close();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }  //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void bunifuGradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void bunifuGradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LogOut_Load(object sender, EventArgs e)
        {

        }
        public void SetText(string text)
        {
            bunifuCustomLabel1.Text = text;
        }

        private void bunifuGradientPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

        }
    }
}
