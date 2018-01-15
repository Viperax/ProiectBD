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
    public partial class Admin_AdaugaStudentiGrupa : UserControl
    {
        int idFacultate;//pentru afisarea departamentelor

        public void setIdFacultate(int newIdFacultate)
        {
            this.idFacultate = newIdFacultate;
        }
        public Admin_AdaugaStudentiGrupa()
        {
            InitializeComponent();
        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        List<int> IdDepartamente;
        public void AddDepartamentDropDown(string NumeDepartament,int IdDepartament)
        {
            bunifuDropdown1.AddItem(NumeDepartament);
            IdDepartamente.Add(IdDepartament);
        }

        public void ResetAllTools()
        {
            try
            {
                IdDepartamente = new List<int>();
                bunifuCustomDataGrid1.Rows.Clear();
                bunifuDropdown1.Clear();
                bunifuDropdown2.Clear();
                bunifuDropdown3.Clear();
                bunifuDropdown4.Clear();
                bunifuDropdown5.Clear();
                bunifuDropdown6.Clear();
                bunifuMaterialTextbox1.Text = "";
                bunifuMaterialTextbox2.Text = "";

                //adaugam in primul dropDown toate departamentele care corespund id-ului facultatii 
                var catalog = new CatalogEntities1();
                var departamente = from d in catalog.Departamnets
                                   where d.FacultateID == this.idFacultate
                                   select d;
                foreach (var dep in departamente)
                {
                    //adaugam departamente in dropdown
                    this.AddDepartamentDropDown(dep.Nume, dep.DepartamentID);
                }
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }

        }

        private void Admin_AdaugaStudentiGrupa_Load(object sender, EventArgs e)
        {

        }

        List<int> IdSpecializari;//tinem minte id-urile specializarilor din dropdown
        public void AddSpecializareDropDown(string NumeSpecializare,int IdSpecializare)
        {
            bunifuDropdown2.AddItem(NumeSpecializare);
            IdSpecializari.Add(IdSpecializare);
        }

        int IdDepartamentSelectat;//tinem minte ce departament a fost selectat
        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDropdown1.selectedIndex != -1)
                { //daca a fost ceva selectat
                  //resetam tot ce e mai jos daca se schimba valoarea 
                    IdSpecializari = new List<int>();
                    bunifuCustomDataGrid1.Rows.Clear();
                    bunifuDropdown2.Clear();
                    bunifuDropdown3.Clear();
                    bunifuDropdown4.Clear();
                    bunifuDropdown5.Clear();
                    bunifuDropdown6.Clear();
                    bunifuMaterialTextbox1.Text = "";
                    bunifuMaterialTextbox2.Text = "";
                    IdDepartamentSelectat = IdDepartamente.ElementAt(bunifuDropdown1.selectedIndex);

                    //adaugam toate specializarile corespunzatoare departamentului selectat
                    var catalog = new CatalogEntities1();
                    var specializari = from s in catalog.Specializares
                                       where s.DepartamentID == IdDepartamentSelectat
                                       select s;
                    foreach (var s in specializari)//adaugam pe fiecare in dropdown2
                    {
                        AddSpecializareDropDown(s.Nume, s.SpecializareID);
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

        List<int> IdAnScolari;
        public void AddAnScolarDropDown(int an1,int an2,int idAnScolar)
        {
            bunifuDropdown3.AddItem(an1.ToString() + "-" + an2.ToString());
            IdAnScolari.Add(idAnScolar);
        }


        int IdSpecializareSelectat;
        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDropdown2.selectedIndex != -1)
                {
                    IdAnScolari = new List<int>();
                    bunifuCustomDataGrid1.Rows.Clear();
                    bunifuDropdown3.Clear();
                    bunifuDropdown4.Clear();
                    bunifuDropdown5.Clear();
                    bunifuDropdown6.Clear();
                    bunifuMaterialTextbox1.Text = "";
                    bunifuMaterialTextbox2.Text = "";
                    this.IdSpecializareSelectat = IdSpecializari.ElementAt(bunifuDropdown2.selectedIndex);

                    var catalog = new CatalogEntities1();
                    var ani = from a in catalog.AnScolars
                              select a;
                    foreach (var a in ani)//adaugam fiecare an in dropDown3
                    {
                        AddAnScolarDropDown(a.AnPrimar, a.AnSecundar, a.AnScolarID);
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


        string[] aniRoman = { "I", "II", "III", "IV" }; //valoarea din dropDown reprezinta indexul
        List<int> IDAn;//tinem minte id-urile anilor adaugati (1,2,3,4) pentru a nu se adauga de 2 ori 
        public void AdaugareAnDropDown(int an)
        {
            if (!IDAn.Contains(an)) { //daca nu mai exista il adaugam
                IDAn.Add(an);
                bunifuDropdown4.AddItem(aniRoman[an-1]);
            }

        }

        int IdAnScolarSelectat;
        private void bunifuDropdown3_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDropdown3.selectedIndex != -1)
                { //inseamna ca s-a selectat un an scolar
                    IDAn = new List<int>();
                    bunifuCustomDataGrid1.Rows.Clear();
                    bunifuDropdown4.Clear();
                    bunifuDropdown5.Clear();
                    bunifuDropdown6.Clear();
                    bunifuMaterialTextbox1.Text = "";
                    bunifuMaterialTextbox2.Text = "";
                    this.IdAnScolarSelectat = IdAnScolari.ElementAt(bunifuDropdown3.selectedIndex);

                    //luam toate grupele care au AnScolarIdSelectat si SpecializareIdSelectata si returnam numai anii care exista
                    var catalog = new CatalogEntities1();
                    var grupe = from g in catalog.Grupas
                                where g.AnScolarID == IdAnScolarSelectat && g.SpecializareID == IdSpecializareSelectat
                                select g;
                    //adaugam anii grupelo in dropDown4 ( sa fie adaugati o singura data)
                    foreach (var g in grupe)
                    {
                        AdaugareAnDropDown(g.An);
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

        List<int> IdGrupe;
        public void AddGrupeDropDown(string NumeGrup,int IdGrupa)
        {
            bunifuDropdown5.AddItem(NumeGrup);
            IdGrupe.Add(IdGrupa);
        }

        int AnSelectat;
        private void bunifuDropdown4_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDropdown4.selectedIndex != -1)
                { //daca a fost selectat un AN
                    IdGrupe = new List<int>();
                    bunifuCustomDataGrid1.Rows.Clear();
                    bunifuDropdown5.Clear();
                    bunifuDropdown6.Clear();
                    bunifuMaterialTextbox1.Text = "";
                    bunifuMaterialTextbox2.Text = "";
                    this.AnSelectat = IDAn.ElementAt(bunifuDropdown4.selectedIndex);//este direct anul pe care l-a selectat


                    //adaugam toate grupele corespunzatoare An,AnScolarID,SpecializareID
                    var catalog = new CatalogEntities1();
                    var grupe = from g in catalog.Grupas
                                where g.An == AnSelectat && g.AnScolarID == IdAnScolarSelectat && g.SpecializareID == IdSpecializareSelectat
                                select g;
                    foreach (var g in grupe)//adaugam fiecare grupa in dropDown5
                    {
                        AddGrupeDropDown(g.Nume, g.GrupaID);
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


        public void AddStudentDataGrid(string NumeStudent,string PrenumeStudent)
        {
            bunifuCustomDataGrid1.Rows.Add();
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[0].Value = NumeStudent;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[1].Value = PrenumeStudent;
        }

        int IdGrupaSelectata;
        private void bunifuDropdown5_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDropdown5.selectedIndex != -1)
                { //insamna ca s-a selectat o grupa
                    bunifuCustomDataGrid1.Rows.Clear();
                    bunifuDropdown6.Clear();
                    bunifuMaterialTextbox1.Text = "";
                    bunifuMaterialTextbox2.Text = "";
                    this.IdGrupaSelectata = IdGrupe.ElementAt(bunifuDropdown5.selectedIndex);
                    //luam fiecare student si il adaugam in DataGridView

                    var catalog = new CatalogEntities1();
                    var studenti = from g in catalog.StudentiGrupas
                                   join s in catalog.Students
                                   on g.StudentID equals s.StudentID
                                   where g.GrupaID == IdGrupaSelectata
                                   select new
                                   {
                                       NumeStudent = s.Nume,
                                       PrenumeStudent = s.Prenume,
                                       IdStudent = s.StudentID
                                   };

                    foreach (var s in studenti)//adaugam fiecare student din grupa respectiva in datagridview
                    {
                        AddStudentDataGrid(s.NumeStudent, s.PrenumeStudent);
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

        public void AddCNPDropDown(string new_CNP)
        {
            bunifuDropdown6.AddItem(new_CNP);
        }
       
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuMaterialTextbox1.Text != "" && bunifuMaterialTextbox1.Text != "Adaugati Nume!" && bunifuMaterialTextbox2.Text != "" && bunifuMaterialTextbox2.Text != "Adaugati Prenume!" && bunifuMaterialTextbox1.Text != "Acest Student Nu Exista!" && bunifuMaterialTextbox2.Text != "Acest Student Nu Exista!")
                {
                    bunifuDropdown6.Clear();
                    string NumeStudent = bunifuMaterialTextbox1.Text;
                    string PrenumeStudent = bunifuMaterialTextbox2.Text;
                    //daca un nume si un prenume au fost adaugate, cautam toti studentii cu aceste nume si returnam cnp-urile (in caz ca sunt mai mutli cu acelasi nume si prenume)
                    var catalog = new CatalogEntities1();
                    var studenti = from s in catalog.Students
                                   where s.Nume.Equals(NumeStudent) && s.Prenume.Equals(PrenumeStudent)
                                   select s;

                    if (studenti.Count() != 0)
                    {//inseamna ca exista 
                        foreach (var st in studenti)//adaugam cnp-urile in dropdown6
                        {
                            this.AddCNPDropDown(st.CNP);
                        }
                    }
                    else//nu exista studentul cautat 
                    {
                        bunifuMaterialTextbox1.Text = "Acest Student Nu Exista!";
                        bunifuMaterialTextbox2.Text = "Acest Student Nu Exista!";
                    }
                }
                else
                {
                    if (bunifuMaterialTextbox1.Text == "")
                        bunifuMaterialTextbox1.Text = "Adaugati Nume!";
                    if (bunifuMaterialTextbox2.Text == "")
                        bunifuMaterialTextbox2.Text = "Adaugati Prenume!";
                }
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }


        string CNPSelectat;//cautam studentul dupa CNP si bagam Id-ul studentului in grupa de StudentiGrupa
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //verificam daca au fost completate toate campurile
                if (bunifuDropdown1.selectedIndex != -1 && bunifuDropdown2.selectedIndex != -1 && bunifuDropdown3.selectedIndex != -1 && bunifuDropdown4.selectedIndex != -1 && bunifuDropdown5.selectedIndex != -1 && bunifuMaterialTextbox1.Text != "" && bunifuMaterialTextbox2.Text != "" && bunifuDropdown6.selectedIndex != -1)
                {
                    string StudentNume = bunifuMaterialTextbox1.Text;
                    string StudentPrenume = bunifuMaterialTextbox2.Text;

                    this.CNPSelectat = bunifuDropdown6.selectedValue;
                    //trebuie sa cautam daca mai exista studentul respectiv in grupa si daca nu sa semnalizeze
                    using (var catalog = new CatalogEntities1())
                    {
                        using (var dbCatalogTransaction = catalog.Database.BeginTransaction())
                        {
                            var studenti = from g in catalog.StudentiGrupas
                                           join s in catalog.Students
                                           on g.StudentID equals s.StudentID
                                           where g.GrupaID == IdGrupaSelectata && s.CNP.Equals(CNPSelectat)
                                           select new
                                           {
                                               NumeStudent = s.Nume,
                                               PrenumeStudent = s.Prenume,
                                               IdStudent = s.StudentID
                                           };
                            if (studenti.Count() == 0)
                            { //daca studentul nu exista in tabela
                              //cautam in toti studentii cnp-ul selectat ca sa gasim Id-ul 
                                var studenti2 = from s in catalog.Students
                                                where s.CNP.Equals(CNPSelectat)
                                                select s;

                                int StudentID = studenti2.First().StudentID;
                                //adaugam in baza de date in tabela StudentiGrupa
                                try
                                {
                                    var newStudentGrupa = new StudentiGrupa
                                    {
                                        StudentID = StudentID,
                                        GrupaID = IdGrupaSelectata
                                    };
                                    catalog.StudentiGrupas.Add(newStudentGrupa);
                                    catalog.SaveChanges();
                                    dbCatalogTransaction.Commit();
                                    //adaugam in dataGridView
                                    this.AddStudentDataGrid(StudentNume, StudentPrenume);
                                }
                                catch (Exception)
                                {
                                    dbCatalogTransaction.Rollback();
                                }

                            }
                            else//studentul deja exista in grupa respectiva
                            {
                                bunifuDropdown6.Clear();
                                bunifuMaterialTextbox1.Text = "Studentul Exista!";
                                bunifuMaterialTextbox2.Text = "Studentul Exista!";

                            }

                        }
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

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Form1.gui.Bring_FirstPageAdmin();
        }


        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void Admin_AdaugaStudentiGrupa_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Admin_AdaugaStudentiGrupa_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void Admin_AdaugaStudentiGrupa_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
