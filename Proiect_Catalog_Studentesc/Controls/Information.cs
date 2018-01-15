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
    public partial class Information : UserControl
    {
        public Information()
        {
            InitializeComponent();
        }

        private void Information_Load(object sender, EventArgs e)
        {

        }

        public void change_information(string information_text)
        {
            bunifuCustomLabel1.Text = information_text;
        }
        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void Information_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Information_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }

        }

        private void Information_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

        }
    }
}
