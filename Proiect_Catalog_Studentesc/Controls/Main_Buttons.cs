using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Proiect_Catalog_Studentesc.Controls
{
    public partial class Main_Buttons : UserControl
    {
        public Main_Buttons()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Student_Click(object sender, EventArgs e)
        {
            Form1.gui.Bring_StudentLogPage();
        }

        private void bunifuFlatButton2_Cadru_Click(object sender, EventArgs e)
        {

            Form1.gui.Bring_CadruLogPage();
        }

        private void bunifuFlatButton3_Admin_Click(object sender, EventArgs e)
        {
            Form1.gui.Bring_AdminLogPage();
        }
        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void Main_Buttons_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Main_Buttons_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void Main_Buttons_Load(object sender, EventArgs e)
        {

        }

        private void Main_Buttons_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
