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
    public partial class Cadru_ViewSpecializari_Decan : UserControl
    {
        public Cadru_ViewSpecializari_Decan()
        {
            InitializeComponent();
        }

        public void ResetDataGrid_Specializari()
        {
            bunifuCustomDataGrid1.Rows.Clear();
        }

        public void AddSpecializareDataGrid(string NumeSpecializare)
        {
            bunifuCustomDataGrid1.Rows.Add();
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[0].Value = NumeSpecializare;
        }

        private void Cadru_ViewSpecializari_Decan_Load(object sender, EventArgs e)
        {

        }

        public void BringButtons()
        {
            bunifuFlatButton1.BringToFront();
            bunifuCustomDataGrid1.BringToFront();
        }


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Form1.gui.VerificaDecan_Cadre();
            Form1.gui.Bring_FirstPageCadru();
        }
        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void Cadru_ViewSpecializari_Decan_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Cadru_ViewSpecializari_Decan_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void Cadru_ViewSpecializari_Decan_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

        }
    }
}
