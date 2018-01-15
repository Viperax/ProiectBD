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

    public partial class MainPageStudent : UserControl
    {
       
        int AnCurentStudent;
        int AnInceputStudent;
        string[] Ani = {"I","II","III","IV"};
        int indexStudent;
        int anSelectat_int;//anul pe care l-a selectat studentul
        int grupaCautata_Student;//grupa pe care o cauta

        public MainPageStudent()
        {
            InitializeComponent();
           
        }

        private void MainPageStudent_Load(object sender, EventArgs e)
        {
            

        }

        public void ResetDropDownColors()
        {
            Color c = Color.FromArgb(21, 189, 177);
            bunifuDropdown1_Student_AnScolar.NomalColor = c;//de modificat cu culoarea finala 
            bunifuDropdown1_Student_Sesiunea.NomalColor = c;
        }
        public void Initializare_Ani()
        {
            bunifuDropdown1_Student_Sesiunea.Enabled = false;
            bunifuDropdown1_Student_AnScolar.Clear();//stergem tot ce era inainte
            for (int i = 1; i <= this.AnCurentStudent; i++)
            {
                bunifuDropdown1_Student_AnScolar.AddItem(Ani[i - 1]);
            }
            //bunifuDropdown1_Student_Sesiunea.AddItem("Selecteaza Anul Scolar");
           // bunifuDropdown1_Student_Sesiunea.selectedIndex=0;

        }
        public void SetAnStudent(int AnCurentStudentFunction,int AnInceputStudentFunction)
        {
            this.AnInceputStudent = AnInceputStudentFunction;
            this.AnCurentStudent = AnCurentStudentFunction;
        }

        public void SetIndexStudent(int indexStudentFunction)
        {
            this.indexStudent = indexStudentFunction;//am setat indexul studentului 


        }

        private void bunifuDropdown1_Student_AnScolar_onItemSelected(object sender, EventArgs e)//dupa ce selecteaza anul scolar
        {
            try
            {
                bunifuDropdown1_Student_Sesiunea.Enabled = true;
                bunifuDropdown1_Student_Sesiunea.Clear();//stergem tot ce era inainte

                string anSelectat = bunifuDropdown1_Student_AnScolar.selectedValue;
                anSelectat_int = -1;//retinem anul scolar care a fost selectat 
                for (int i = 1; i <= 4; i++)
                {
                    if (anSelectat == Ani[i - 1])
                    {
                        anSelectat_int = i;
                        break;
                    }
                }

                //toate grupele in care este studentul:

                var catalog = new CatalogEntities1();
                var lista_grupeId = from g in catalog.StudentiGrupas
                                    where g.StudentID == indexStudent
                                    select g;


                //int anAfisare = AnInceputStudent + anSelectat_int;
                int anAfisare1 = Student_Log.gui_LogareStudent.Lista_ani_student.ElementAt(anSelectat_int - 1).an1;
                int anAfisare2 = Student_Log.gui_LogareStudent.Lista_ani_student.ElementAt(anSelectat_int - 1).an2;


                int max = 0;
                foreach (var grupaId in lista_grupeId)
                {
                    var grupaName = from g in catalog.Grupas// selectam grupele care au si anul selectat 
                                    join a in catalog.AnScolars
                                    on g.AnScolarID equals a.AnScolarID
                                    where g.GrupaID == grupaId.GrupaID && (a.AnPrimar == anAfisare1 && a.AnSecundar == anAfisare2)
                                    select g;

                    foreach (var g in grupaName)
                    {
                        grupaCautata_Student = g.GrupaID;//aici imi ia numai grupa selectata dupa an
                                                         //cautam in materiile care apartin grupei, toate sesiunile 
                        var lista_materii = from m in catalog.Materies
                                            where m.GrupaID == g.GrupaID
                                            select m;

                        max = 1;//sesiunea 1 
                        foreach (var materie in lista_materii)//aici facem maximul pentru a nu le afisa de 2 ori
                        {
                            if (materie.Sesiune > max)
                                max = (int)materie.Sesiune;
                        }
                    }
                }
                for (int i = 1; i <= max; i++)
                {
                    bunifuDropdown1_Student_Sesiunea.AddItem(i.ToString());
                }
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }

        private void bunifuFlatButton1_Student_MainPage_Click(object sender, EventArgs e)
        {
            if (bunifuDropdown1_Student_AnScolar.selectedIndex != -1 && bunifuDropdown1_Student_Sesiunea.selectedIndex != -1 && !bunifuDropdown1_Student_Sesiunea.selectedValue.Contains("Selecteaza Anul Scolar"))
            {
                Form1.gui.SetParametersExport(indexStudent, grupaCautata_Student, sesiune_Selectata);
                Form1.gui.Bring_Student_Afisare_Materii();
            }
            else if (bunifuDropdown1_Student_AnScolar.selectedIndex == -1)
            {
                bunifuDropdown1_Student_AnScolar.NomalColor = Color.Red;
            }
            else if (bunifuDropdown1_Student_Sesiunea.selectedIndex == -1)
            {
                bunifuDropdown1_Student_Sesiunea.NomalColor = Color.Red;
            }
            
        }
        int sesiune_Selectata;
        private void bunifuDropdown1_Student_Sesiunea_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                int anCautat = AnInceputStudent + anSelectat_int;
                Form1.gui.Reset_StudentMateriiView();
                //luam toate materiile care apartin grupei si au si sesiunea selectata

                if (bunifuDropdown1_Student_Sesiunea.selectedIndex != -1)
                {
                    string sesiune_SelectataString = bunifuDropdown1_Student_Sesiunea.selectedValue;
                    sesiune_Selectata = Int32.Parse(sesiune_SelectataString);

                    var catalog = new CatalogEntities1();
                    var lista_materii = from m in catalog.Materies
                                        where m.GrupaID == grupaCautata_Student && m.Sesiune == sesiune_Selectata
                                        select m;

                    foreach (var materie in lista_materii)
                    {

                        //luam si nota materiei respective 
                        var nota = from n in catalog.Notas
                                   join a in catalog.AnScolars
                                   on n.AnScolarID equals a.AnScolarID
                                   where (n.StudentID == indexStudent) && (n.MaterieID == materie.MaterieID)// && ((a.AnPrimar ==anCautat) ||(a.AnSecundar ==anCautat))
                                   orderby n.NotaFinala descending
                                   select n;

                        //adaugam materia cu tot cu note
                        if (nota.Count() != 0)//daca exisa nota sau nu pentru materia respectiva
                            Form1.gui.AddMaterie_Student(materie.NumeMaterie, materie.Profesor1ID.ToString(), materie.Profesor2ID.ToString(), materie.Asistent1ID.ToString(), materie.Asisten2ID.ToString(), materie.ProcentCurs.ToString(), materie.ProcentLaborator.ToString(), materie.ProcentTeme.ToString(), materie.ProcentProiect.ToString(), materie.Examen.ToString(), materie.Credite.ToString(), nota.First().NotaCurs.ToString(), nota.First().NotaLaborator.ToString(), nota.First().NotaProiect.ToString(), nota.First().NotaFinala.ToString());
                        else//daca inca nu exita nota
                            Form1.gui.AddMaterie_Student(materie.NumeMaterie, materie.Profesor1ID.ToString(), materie.Profesor2ID.ToString(), materie.Asistent1ID.ToString(), materie.Asisten2ID.ToString(), materie.ProcentCurs.ToString(), materie.ProcentLaborator.ToString(), materie.ProcentTeme.ToString(), materie.ProcentProiect.ToString(), materie.Examen.ToString(), materie.Credite.ToString(), "-", "-", "-", "-");
                    }
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

        }

        private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
        {
            LogOut newForm = new LogOut();
            newForm.ShowDialog();
        }
        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void MainPageStudent_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void MainPageStudent_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void MainPageStudent_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
