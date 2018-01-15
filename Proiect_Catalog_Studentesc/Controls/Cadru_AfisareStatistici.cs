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
    public partial class Cadru_AfisareStatistici : UserControl
    {
        public Cadru_AfisareStatistici()
        {
            InitializeComponent();
        }

        public void RestartDataGridStatistica()
        {
            bunifuCustomDataGrid1.Rows.Clear();

        }
        public void SetStatistics(int nrTotal, int promovabilitate, int integralisti, int restantieri, int R1, int R2, int R3)
        {
            bunifuCustomLabel1.Text = "Studenti:" + nrTotal.ToString();
            bunifuCircleProgressbar3.Value = promovabilitate;
            bunifuCircleProgressbar2.Value = integralisti;
            bunifuCircleProgressbar1.Value = restantieri;
            bunifuCircleProgressbar6.Value = R1;
            bunifuCircleProgressbar5.Value = R2;
            bunifuCircleProgressbar4.Value = R3;
        }

        public void AdaugaDataGrid(string Specializare,int Studenti,int Integralisti,int Restantieri,int R1,int R2,int R3,int Promovabilitate)
        {
            bunifuCustomDataGrid1.Rows.Add();
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[0].Value = Specializare;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[1].Value = Studenti;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[2].Value = Integralisti;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[3].Value = Restantieri;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[4].Value = R1;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[5].Value = R2;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[6].Value = R3;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[7].Value = Promovabilitate;
        }

        private void Cadru_AfisareStatistici_Load(object sender, EventArgs e)
        {
          
        }
        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        public void BringAllFront()
        {
            bunifuCircleProgressbar1.BringToFront();
            bunifuCircleProgressbar2.BringToFront();
            bunifuCircleProgressbar3.BringToFront();
            bunifuCircleProgressbar4.BringToFront();
            bunifuCircleProgressbar5.BringToFront();
            bunifuCircleProgressbar6.BringToFront();
            bunifuCustomDataGrid1.BringToFront();
            bunifuCustomLabel1.BringToFront();
            bunifuCustomLabel2.BringToFront();
            bunifuCustomLabel3.BringToFront();
            bunifuCustomLabel4.BringToFront();
            bunifuCustomLabel5.BringToFront();
            bunifuCustomLabel7.BringToFront();
            bunifuCustomLabel6.BringToFront();
            bunifuFlatButton1.BringToFront();
        }


        private void Cadru_AfisareStatistici_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Cadru_AfisareStatistici_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Form1.gui.Bring_CadruFirstPageStatistici();
        }

        private void Cadru_AfisareStatistici_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
