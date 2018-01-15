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
    public partial class Admin_AdaugaNota : UserControl
    {
        public Admin_AdaugaNota()
        {
            InitializeComponent();
        }

        public void ResetAllTools()
        {
            bunifuCustomDataGrid1.Rows.Clear();
            bunifuDropdown1.Clear();
            bunifuDropdown2.Clear();
            bunifuDropdown3.Clear();
            bunifuMaterialTextbox1.Text = "";
            bunifuMaterialTextbox2.Text = "";
            bunifuMaterialTextbox3.Text = "";
            bunifuMaterialTextbox4.Text = "";
            bunifuMaterialTextbox5.Text = "";
            bunifuMaterialTextbox6.Text = "";
            bunifuMaterialTextbox7.Text = "";
        }

        private void Admin_AdaugaNota_Load(object sender, EventArgs e)
        {

        }

        public void AddCNPDropDown(string newCNP)
        {
            bunifuDropdown1.AddItem(newCNP);

        }

        string NumeSelectat = "";
        string PrenumeSelectat = "";
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            //resetam toate toolurile
            bunifuDropdown1.Clear();
            bunifuDropdown2.Clear();
            bunifuDropdown3.Clear();
            bunifuMaterialTextbox3.Text = "";
            bunifuCustomDataGrid1.Rows.Clear();
            bunifuMaterialTextbox4.Text = "";
            bunifuMaterialTextbox5.Text = "";
            bunifuMaterialTextbox6.Text = "";
            bunifuMaterialTextbox7.Text = "";
            try
            {
                if (bunifuMaterialTextbox1.Text != "" && bunifuMaterialTextbox1.Text != "Adaugati Nume!" && bunifuMaterialTextbox2.Text != "" && bunifuMaterialTextbox2.Text != "Adaugati Prenume" && bunifuMaterialTextbox1.Text != "Acest student nu exista!" && bunifuMaterialTextbox2.Text != "Acest student nu exista!")
                {
                    this.NumeSelectat = bunifuMaterialTextbox1.Text;
                    this.PrenumeSelectat = bunifuMaterialTextbox2.Text;

                    //cautam toti studentii cu numele respectiv si afisam CNP-urile
                    var catalog = new CatalogEntities1();
                    var studenti = from s in catalog.Students
                                   where s.Nume.Equals(NumeSelectat) && s.Prenume.Equals(PrenumeSelectat)
                                   select s;
                    //verificam daca exista acest student
                    if (studenti.Count() != 0)
                    { //inseamna ca exista
                        foreach (var s in studenti)//adaugam CNP-urile in primul DropDown
                        {
                            this.AddCNPDropDown(s.CNP);
                        }
                    }
                    else
                    {
                        bunifuMaterialTextbox1.Text = "Acest student nu exista!";
                        bunifuMaterialTextbox2.Text = "Acest student nu exista!";
                    }
                }
                else
                {
                    if (bunifuMaterialTextbox1.Text == "")
                        bunifuMaterialTextbox1.Text = "Adaugati Nume!";
                    if (bunifuMaterialTextbox2.Text == "")
                        bunifuMaterialTextbox2.Text = "Adaugati Prenume";
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }

        public class Grupa_AnScolar
        {
            public int IDGrupa;
            public int IDAnScolar;
            public int an1;
            public int an2;

            public Grupa_AnScolar(int new_idGrupa, int new_idAnScolar)
            {
                try
                {
                    this.IDGrupa = new_idGrupa;
                    this.IDAnScolar = new_idAnScolar;
                    var catalog = new CatalogEntities1();
                    var an = from a in catalog.AnScolars
                             where a.AnScolarID == new_idAnScolar
                             select a;
                    if (an.Count() != 0)
                    {
                        this.an1 = an.First().AnPrimar;
                        this.an2 = an.First().AnSecundar;
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.ToString());
                    FormError newForm = new FormError();
                    newForm.SetText(ex.ToString());
                    newForm.ShowDialog();
                }
            }
        }
        List<Grupa_AnScolar> ListaGrupe_AnScolar;//tinem minte id-ul grupei si anul scolar respectiv
        public void AddGrupa_AnScolar(int idGrupa,int idAnScolar)
        {
            Grupa_AnScolar newItem = new Grupa_AnScolar(idGrupa, idAnScolar);
            bunifuDropdown2.AddItem(newItem.an1 + "-" + newItem.an2);
            ListaGrupe_AnScolar.Add(newItem);
        }


        string CNPSelectat;
        int IdStudentSelectat;
        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDropdown1.selectedIndex != -1)
                { //inseamna ca a fost selectat un CNP
                    this.CNPSelectat = bunifuDropdown1.selectedValue;
                    //Resetam toate toolurile
                    bunifuDropdown2.Clear();
                    bunifuDropdown3.Clear();
                    bunifuMaterialTextbox3.Text = "";
                    bunifuCustomDataGrid1.Rows.Clear();
                    bunifuMaterialTextbox4.Text = "";
                    bunifuMaterialTextbox5.Text = "";
                    bunifuMaterialTextbox6.Text = "";
                    bunifuMaterialTextbox7.Text = "";

                    ListaGrupe_AnScolar = new List<Grupa_AnScolar>();

                    //cautam grupele in care este studentul si luam anii scolari
                    var catalog = new CatalogEntities1();
                    var grupe = from g in catalog.StudentiGrupas
                                join s in catalog.Students
                                on g.StudentID equals s.StudentID
                                join gr in catalog.Grupas
                                on g.GrupaID equals gr.GrupaID
                                where s.CNP.Equals(CNPSelectat)
                                select new
                                {
                                    IdAnscolar = gr.AnScolarID,
                                    GrupaId = gr.GrupaID,
                                    IdStudent = s.StudentID
                                };
                    if (grupe.Count() != 0)
                    {
                        this.IdStudentSelectat = grupe.First().IdStudent;
                    }
                    foreach (var g in grupe)//adaugam id-ul grupei cu id-ul anului corespunzator in lista 
                    {
                        //in acelasi timp le adaugam si in dropdown2
                        this.AddGrupa_AnScolar(g.GrupaId, g.IdAnscolar);
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }


        List<int> IdMaterii;//tine minte id-urile materiilor din dropDown
        public void AddMateriiDropDown(string newNumeMaterie,int newIdMaterie)
        {
            bunifuDropdown3.AddItem(newNumeMaterie);
            IdMaterii.Add(newIdMaterie);
        }

        public void AddNoteDataGridView(string Materie, int Sesiune, int Curs, int Laborator, int Proiect, int Finala)
        {
            bunifuCustomDataGrid1.Rows.Add();
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[0].Value = Materie;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[1].Value = Sesiune.ToString();
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[2].Value = Curs.ToString();
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[3].Value = Laborator.ToString();
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[4].Value = Proiect.ToString();
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[5].Value = Finala.ToString();
            Bitmap cale = null;
            if (Finala >= 5)
                cale = new Bitmap("Pass_Exam.png");
            else
                cale = new Bitmap("Failed_Exam.png");
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[6].Value = cale;

        }

        int IdAnScolarSelectat;
        int IdGrupaSelectata;
        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDropdown2.selectedIndex != -1)
                { //daca a fost selectat un anScolar
                    this.IdAnScolarSelectat = ListaGrupe_AnScolar.ElementAt(bunifuDropdown2.selectedIndex).IDAnScolar;
                    this.IdGrupaSelectata = ListaGrupe_AnScolar.ElementAt(bunifuDropdown2.selectedIndex).IDGrupa;
                    //resetam toate tool-urile
                    bunifuDropdown3.Clear();
                    bunifuMaterialTextbox3.Text = "";
                    bunifuCustomDataGrid1.Rows.Clear();
                    bunifuMaterialTextbox4.Text = "";
                    bunifuMaterialTextbox5.Text = "";
                    bunifuMaterialTextbox6.Text = "";
                    bunifuMaterialTextbox7.Text = "";
                    this.IdMaterii = new List<int>();

                    //cautam toate materiile grupei selectate
                    var catalog = new CatalogEntities1();
                    var materii = from m in catalog.Materies
                                  where m.GrupaID == IdGrupaSelectata
                                  select m;
                    foreach (var m in materii)
                    { //adaugam materia in dropdown
                      //adaugam in datagrid

                        var note = from n in catalog.Notas
                                   where n.MaterieID == m.MaterieID && n.StudentID == IdStudentSelectat && n.AnScolarID == IdAnScolarSelectat
                                   select n;
                        foreach (var n in note)//adaugam notele in dataGridView
                        {
                            this.AddNoteDataGridView(m.NumeMaterie, n.Sesiune, (int)n.NotaCurs, (int)n.NotaLaborator, (int)n.NotaProiect, (int)n.NotaFinala);
                        }
                        //end adaugare in datagrid

                        this.AddMateriiDropDown(m.NumeMaterie, m.MaterieID);
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }

       

        int IdMaterieSelectata;
        private void bunifuDropdown3_onItemSelected(object sender, EventArgs e)
        {
            if (bunifuDropdown3.selectedIndex != -1) { //daca s-a selectat o materie
                this.IdMaterieSelectata = IdMaterii.ElementAt(bunifuDropdown3.selectedIndex);
                //resetam tool-urile
                bunifuMaterialTextbox3.Text = "";
            }
        }

        int SesiuneSelectata;
        int NotaCurs;
        int NotaLaborator;
        int NotaProiect;
        int NotaFinala;
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuMaterialTextbox1.Text != "" && bunifuMaterialTextbox2.Text != "" && bunifuDropdown1.selectedIndex != -1 && bunifuDropdown2.selectedIndex != -1 && bunifuDropdown3.selectedIndex != -1 && bunifuMaterialTextbox3.Text != "" && bunifuMaterialTextbox4.Text != "" && bunifuMaterialTextbox5.Text != "" && bunifuMaterialTextbox6.Text != "" && bunifuMaterialTextbox7.Text != "")
                {
                    this.SesiuneSelectata = Int32.Parse(bunifuMaterialTextbox3.Text);
                    this.NotaCurs = Int32.Parse(bunifuMaterialTextbox4.Text);
                    this.NotaLaborator = Int32.Parse(bunifuMaterialTextbox5.Text);
                    this.NotaProiect = Int32.Parse(bunifuMaterialTextbox6.Text);
                    this.NotaFinala = Int32.Parse(bunifuMaterialTextbox7.Text);
                    //trebuie sa verificam daca mai exista aceeasi Materie cu MaterieId,StudentId,AnScolarId,Sesiune
                    using (var catalog = new CatalogEntities1())
                    {
                        using (var dbCatalogTransaction = catalog.Database.BeginTransaction())
                        {
                            var materie = from n in catalog.Notas
                                          where n.MaterieID == IdMaterieSelectata && n.StudentID == IdStudentSelectat && n.AnScolarID == IdAnScolarSelectat && n.Sesiune == SesiuneSelectata
                                          select n;
                            if (materie.Count() == 0)
                            { //daca nu mai exita atunci o adauga
                              //adauga in baza de date
                                try
                                {
                                    var newNota = new Nota
                                    {
                                        MaterieID = IdMaterieSelectata,
                                        StudentID = IdStudentSelectat,
                                        NotaCurs = NotaCurs,
                                        NotaLaborator = NotaLaborator,
                                        NotaProiect = NotaProiect,
                                        NotaFinala = NotaFinala,
                                        Sesiune = SesiuneSelectata,
                                        AnScolarID = IdAnScolarSelectat
                                    };
                                    catalog.Notas.Add(newNota);
                                    catalog.SaveChanges();
                                    dbCatalogTransaction.Commit();
                                }
                                catch (Exception ex)
                                {
                                    dbCatalogTransaction.Rollback();
                                    FormError newForm = new FormError();
                                    newForm.SetText(ex.ToString());
                                    newForm.ShowDialog();
                                }

                                //adauga in dataGridView
                                this.AddNoteDataGridView(bunifuDropdown3.selectedValue, SesiuneSelectata, NotaCurs, NotaLaborator, NotaProiect, NotaFinala);
                            }
                            //daca exista nu se intampla nimic 
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

        private void Admin_AdaugaNota_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Admin_AdaugaNota_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void Admin_AdaugaNota_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

        }
    }
}
