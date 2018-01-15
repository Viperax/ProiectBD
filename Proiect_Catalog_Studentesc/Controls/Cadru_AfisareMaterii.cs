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
    public partial class Cadru_AfisareMaterii : UserControl
    {
        int idGrupaSelectata;//ca sa stim ce studenti sa selectam 
        public Cadru_AfisareMaterii()
        {
            InitializeComponent();
        }

        public void setIdGrupaSelectata(int IdGrupa)
        {
            try
            {
                this.idGrupaSelectata = IdGrupa;
                this.id_Materii = new List<int>();//sa tinem minte id-urile materiilor in ordinea din gridview
                foreach (DataGridViewColumn column in bunifuCustomDataGrid1.Columns)//facem sa nu poata fii sortate deoarece se incurca indexii
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }
        private void Cadru_AfisareMaterii_Load(object sender, EventArgs e)
        {

        }

        public void ResetGridViewMaterii()
        {
            this.bunifuCustomDataGrid1.Rows.Clear();
        }

        List<int> id_Materii;//tinem minte id-urile materiei din dropdown 
        public void add_materieProfesor(int IdMaterie,string numeMaterie,string ProcentCurs,string ProcentLaborator,string ProcentTeme,string ProcentProiect,bool Examen,string Credite,string Sesiune)
        {
            id_Materii.Add(IdMaterie);
            bunifuCustomDataGrid1.Rows.Add();
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[0].Value = numeMaterie;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[1].Value = ProcentCurs;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[2].Value = ProcentLaborator;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[3].Value = ProcentTeme;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[4].Value = ProcentProiect;
            Bitmap cale = null;
            if (Examen)
                cale = new Bitmap("Green_Exam.png");
            else
                cale = new Bitmap("Red_Exam.png");
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[5].Value = cale;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[6].Value = Credite;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[7].Value = Sesiune;


        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (bunifuCustomDataGrid1.Columns[e.ColumnIndex].HeaderText == "NoteStudenti")
                {
                    //vedem ce materie este selectata 
                    int IdMaterieSelectat = this.id_Materii.ElementAt(e.RowIndex);

                    //adaugam toti studentii din grupa selectata 
                    var catalog = new CatalogEntities1();
                    var stud = from st in catalog.StudentiGrupas
                               join c in catalog.Students
                               on st.StudentID equals c.StudentID
                               where st.GrupaID == this.idGrupaSelectata
                               select new
                               {
                                   Nume = c.Nume,
                                   Prenume = c.Prenume,
                                   StudentID = c.StudentID
                               };

                    foreach (var student in stud)
                    {
                        Form1.gui.AddStudentNote_Cadru(student.Nume, student.Prenume, student.StudentID, IdMaterieSelectat);
                    }

                    Form1.gui.Bring_CadruAfisareStudentiNote();
                }
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
            Form1.gui.VerificaDecan_Cadre();//daca scoate butonul de specializari sau nu 
            Form1.gui.Bring_FirstPageCadru();
        }

        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void Cadru_AfisareMaterii_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Cadru_AfisareMaterii_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }

        }

        private void Cadru_AfisareMaterii_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
