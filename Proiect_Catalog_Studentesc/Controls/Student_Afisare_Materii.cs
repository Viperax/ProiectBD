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
    public partial class Student_Afisare_Materii : UserControl
    {
        public Student_Afisare_Materii()
        {
            InitializeComponent();
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Student_Afisare_Materii_Load(object sender, EventArgs e)
        {

        }
        public void Reset_MateriiView()
        {
            bunifuCustomDataGrid1.Rows.Clear();
        }

        public string return_numeCadru(string ID_prof)
        {
            string nume = "";
            if (ID_prof != "")
            {
                int ID = Int32.Parse(ID_prof);
                var catalog = new CatalogEntities1();
                var nume_prof1 = from p in catalog.Cadrus
                                 where p.CadruID == ID
                                 select p;
                foreach (var profesor in nume_prof1)
                {
                    nume = profesor.Nume;
                }

                return nume;
            }
            else
                return "-";
        }

        public void add_materie(string numeMaterie, string prof1, string prof2, string asistent1, string asistent2, string procentCurs, string procentLab, string procentTeme, string procentProiect, string Examen, string credite, string notaCurs,string notaLaborator,string notaProiect,string notaFinala)
        {
            try
            {
                bunifuCustomDataGrid1.Rows.Add();
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[0].Value = numeMaterie;
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[1].Value = return_numeCadru(prof1);            //cautam numele profesorului1 dupa id in functie
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[2].Value = return_numeCadru(prof2);            //cautam numele profesorului1 dupa id in functie
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[3].Value = return_numeCadru(asistent1);            //cautam numele profesorului1 dupa id in functie
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[4].Value = return_numeCadru(asistent2);            //cautam numele profesorului1 dupa id in functie
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[5].Value = procentCurs;
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[6].Value = procentLab;
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[7].Value = procentTeme;
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[8].Value = procentProiect;
                Bitmap cale = null;
                if (Examen == "True")
                    cale = new Bitmap("Green_Exam.png");
                else
                    cale = new Bitmap("Red_Exam.png");

                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[9].Value = cale;
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[10].Value = credite;
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[11].Value = notaCurs;
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[12].Value = notaLaborator;
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[13].Value = notaProiect;
                bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[14].Value = notaFinala;
                if (notaFinala != "-")
                {//inseamna ca a pus nota
                    int Medie = Int32.Parse(notaFinala);
                    if (Medie >= 5)
                    {//admis
                        cale = new Bitmap("Pass_Exam.png");
                        bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[15].Value = cale;
                    }
                    else
                    {
                        cale = new Bitmap("Failed_Exam.png");
                        bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[15].Value = cale;
                    }
                }
                else
                {
                    cale = new Bitmap("Failed_Exam.png");
                    bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[15].Value = cale;
                }
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }

        }

        private void bunifuCustomDataGrid1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Form1.gui.Bring_FirstPageStudent();

            Form1.gui.FirstPageStudentResetDropDownColors();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Form1.gui.Bring_StudentExport();
        }
        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void Student_Afisare_Materii_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Student_Afisare_Materii_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void bunifuCustomDataGrid1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Student_Afisare_Materii_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
