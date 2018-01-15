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
    public partial class Student_Export : UserControl
    {

        int StudentId, GrupaId, Semestru;
        public Student_Export()
        {
            InitializeComponent();
        }

        public void SetParameters(int newStudentID,int newGrupaID,int newSemestru)
        {
            this.StudentId = newStudentID;
            this.GrupaId = newGrupaID;
            this.Semestru = newSemestru;
        }

        private void Student_Export_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.gui.Bring_Student_Afisare_Materii();
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Export.Pdf(StudentId, GrupaId, Semestru, ReturnFilename(StudentId));
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Export.Csv(StudentId, GrupaId, Semestru, ReturnFilename(StudentId));
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }
        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void Student_Export_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Student_Export_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Export.Excel(StudentId, GrupaId, Semestru, ReturnFilename(StudentId));
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                Export.Pdf(StudentId, GrupaId, Semestru, ReturnFilename(StudentId));
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                Export.Csv(StudentId, GrupaId, Semestru, ReturnFilename(StudentId));
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }

        private void Student_Export_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        public string ReturnFilename(int studentID)
        {
           
                string filename = "";
                var catalog = new CatalogEntities1();
                var studenti = from s in catalog.Students
                               where s.StudentID == studentID
                               select s;
            if (studenti.Count() != 0)
            { //daca a gasit student cu id-ul corespunzator
                filename = studenti.First().Nume + "_" + studenti.First().Prenume;
            }
            return filename;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Export.Excel(StudentId, GrupaId, Semestru, ReturnFilename(StudentId));
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }
    }
}
