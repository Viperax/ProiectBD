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
    public partial class Cadru_AfisareStudentiNote : UserControl
    {
        public Cadru_AfisareStudentiNote()
        {
            InitializeComponent();
        }

        private void Cadru_AfisareStudentiNote_Load(object sender, EventArgs e)
        {

        }

        public void addStudentiNote(string NumeStudent,string PrenumeStudent,int studentId,int IdMaterieSelectata)
        {
            try
            {
                bunifuCustomDataGrid1.Rows.Add();
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[0].Value = NumeStudent;
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[1].Value = PrenumeStudent;
                //cautam notele studentului cu studentId si IdMaterieSelectata si o alegem pe cea mai mare 
                var catalog = new CatalogEntities1();
                var note = from n in catalog.Notas
                           where n.StudentID == studentId && n.MaterieID == IdMaterieSelectata
                           select n;

                int max = 0;
                string notaCurs = "";
                string notaLaborator = "";
                string notaProiect = "";
                string notaFinala = "";
                int sem = 0;//inseamna ca nu are inca nota pusa 
                foreach (var k in note)//cautam cea mai mare nota si retinem detaliile pentru studentul respectiv
                {
                    sem = 1;
                    if (k.NotaFinala > max)
                    {
                        max = k.NotaFinala;
                        notaCurs = k.NotaCurs.ToString();
                        notaLaborator = k.NotaLaborator.ToString();
                        notaProiect = k.NotaProiect.ToString();
                        notaFinala = k.NotaFinala.ToString();

                    }
                }
                Bitmap cale;
                if (sem == 1)
                { //daca s-a gasit cel putin o nota adaugata
                    bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[2].Value = notaCurs;
                    bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[3].Value = notaLaborator;
                    bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[4].Value = notaProiect;
                    bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[5].Value = notaFinala;
                    //vedem daca a promovat sau nu :

                    if (Int32.Parse(notaFinala) >= 5)
                        cale = new Bitmap("Pass_Exam.png");
                    else
                        cale = new Bitmap("Failed_Exam.png");


                }
                else
                {
                    bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[2].Value = "-";
                    bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[3].Value = "-";
                    bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[4].Value = "-";
                    bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[5].Value = "-";
                    cale = new Bitmap("Failed_Exam.png");

                }

                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[6].Value = cale;
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }

       
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Form1.gui.Bring_CadruAfisareMaterii();
            bunifuCustomDataGrid1.Rows.Clear();
        }

        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void Cadru_AfisareStudentiNote_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Cadru_AfisareStudentiNote_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void Cadru_AfisareStudentiNote_MouseUp(object sender, MouseEventArgs e)
        {

            mouseDown = false;
        }
    }
}
