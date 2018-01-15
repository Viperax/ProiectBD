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
    public partial class Admin_AdaugareGrupa : UserControl
    {

        int facultateID;//id-ul facultatii pentru a cauta departamentele care apartin 

        public void setFacultateId_AdminAddGrupa(int new_FacultateID)
        {
            this.facultateID = new_FacultateID;
        }

        public Admin_AdaugareGrupa()
        {
            InitializeComponent();
        }

        List<int> idDepartamente;//tinem minte id-urile departamentelor din dropDown
        public void AddDepartament(string NumeDepartament,int new_idDepartament)
        {
            bunifuDropdown1.AddItem(NumeDepartament);
            idDepartamente.Add(new_idDepartament);//adaugam in lista de id-uri corespunzatori indexilor din dropDown
        }

        public void ResetAllTools()
        {
            this.idDepartamente = new List<int>();
            bunifuCustomDataGrid1.Rows.Clear();
            bunifuDropdown1.Clear();
            bunifuDropdown2.Clear();
            bunifuDropdown3.Clear();
            bunifuDropdown4.Clear();
            bunifuMaterialTextbox1.Text="";

            //aici se apasa si butonul si populam si primul DropDown-> Departament
            var catalog = new CatalogEntities1();
            var departamente = from c in catalog.Departamnets//luam toate departamentele care au id-ul facultatii cautate
                               where c.FacultateID == this.facultateID
                               select c;

            foreach(var dep in departamente)//adaugam fiecare departament in dropDown
            {

                AddDepartament(dep.Nume, dep.DepartamentID);
            }

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void Admin_AdaugareGrupa_Load(object sender, EventArgs e)
        {

        }

        List<int> IdSpecializari;//tinem minte id-urile specializarilor din al doilea dropdown corespunzatoare indexilor din dropDown
        public void adaugareSpecializariDropDown(string NumeSpecializare,int idSpecializare)
        {
            bunifuDropdown2.AddItem(NumeSpecializare);
            IdSpecializari.Add(idSpecializare);//adaugam in lista de id-uri corespunzatori indexilor din dropDown
        }

        int IdDepartamentSelectat;//tinem minte ce departament a fost selectat 
        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDropdown1.selectedIndex != -1)//daca a fost selectat ceva
                {
                    bunifuDropdown3.Clear();
                    bunifuDropdown4.Clear();
                    bunifuDropdown2.Clear();
                    IdSpecializari = new List<int>();
                    IdDepartamentSelectat = idDepartamente.ElementAt(bunifuDropdown1.selectedIndex);
                    var catalog = new CatalogEntities1();
                    var specializare = from c in catalog.Specializares//luam toate specializarile care apartin departamentului
                                       where c.DepartamentID == IdDepartamentSelectat
                                       select c;
                    //adaugam specializarile in al doilea dropDown
                    foreach (var spec in specializare)
                    {
                        adaugareSpecializariDropDown(spec.Nume, spec.SpecializareID);
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

        List<int> IdAniScolari;//tinem minte id-urile anilor din al 3-lea dropDown corespunzatori anilor scolari adaugati
        public void adaugareAniScoloariDropDown(string anScolar, int idAnScolar)
        {
            bunifuDropdown4.AddItem(anScolar);
            IdAniScolari.Add(idAnScolar);//adaugam in lista de id-uri corespunzatori indexilor din dropDown
        }



        int idSpecializareSelectata;//tinem minte ce Specializare a fost selectata
        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDropdown2.selectedIndex != -1)
                { //daca a fost selectat ceva
                    bunifuDropdown4.Clear();
                    bunifuDropdown3.Clear();
                    IdAniScolari = new List<int>();
                    this.idSpecializareSelectata = IdSpecializari.ElementAt(bunifuDropdown2.selectedIndex);

                    ////punem sa afisam toti aniiScolari: 2015-2016...
                    var catalog = new CatalogEntities1();
                    var AnScolar = from c in catalog.AnScolars
                                   select c;
                    //adaugam indexii anilor si anii in dropdown 
                    string anScolar_string = "";
                    foreach (var anscl in AnScolar)
                    {
                        anScolar_string = anscl.AnPrimar.ToString() + "-" + anscl.AnSecundar.ToString();
                        adaugareAniScoloariDropDown(anScolar_string, anscl.AnScolarID);
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

        public void adaugareGrupaGridView(string numeGrupa)
        {
            bunifuCustomDataGrid1.Rows.Add();
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[0].Value = numeGrupa;
        }

        int AnSelectat;//anul pe care il selecteaza : 1,2,3,4
        private void bunifuDropdown3_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDropdown3.selectedIndex != -1)
                {
                    this.AnSelectat = IdAni.ElementAt(bunifuDropdown3.selectedIndex);
                    //afisam toate grupele cu an-ul selectat, anscolarIdSelectat, SpecializareId-Selectata
                    var catalog = new CatalogEntities1();
                    var grupe = from c in catalog.Grupas
                                where c.An == AnSelectat && c.AnScolarID == idAnScolarSelectat && c.SpecializareID == idSpecializareSelectata
                                select c;

                    foreach (var grupa in grupe)
                    {
                        //adaugam in gridview
                        this.adaugareGrupaGridView(grupa.Nume);
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


        List<int> IdAni;//tinem minte id-urile anilor din al 3-lea dropDown corespunzatori anilor scolari adaugati
        public void adaugareAniDropDown(string an, int idAn)
        {
            bunifuDropdown3.AddItem(an);
            IdAni.Add(idAn);//adaugam in lista de id-uri corespunzatori indexilor din dropDown
        }

        string []aniRoman= { "I","II","III","IV"};

        int idAnScolarSelectat;//tinem minte anulScolar pe care l-a selectat
        private void bunifuDropdown4_onItemSelected(object sender, EventArgs e)
        {
            if (bunifuDropdown4.selectedIndex != -1) { //daca a fost selectat ceva
                IdAni = new List<int>();
                bunifuDropdown3.Clear();
                this.idAnScolarSelectat =IdAniScolari.ElementAt(bunifuDropdown4.selectedIndex);

                //punem sa afisam toti anii: 1,2,3,4
                for(int i = 0; i < 4; i++)//adaugam anii
                {
                    adaugareAniDropDown(aniRoman[i], i+1);
                }
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string numeGrupa = bunifuMaterialTextbox1.Text;
                if (numeGrupa != "" && numeGrupa != "Introduceti Nume Grupa!" && numeGrupa != "Aceasta Grupa deja exista!")
                {
                    //verificam sa nu mai existe 
                    using (var catalog = new CatalogEntities1())
                    {
                        using (var dbCatalogTransaction = catalog.Database.BeginTransaction())
                        {
                            var grupe = from c in catalog.Grupas
                                        where c.An == AnSelectat && c.AnScolarID == idAnScolarSelectat && c.SpecializareID == idSpecializareSelectata && c.Nume == numeGrupa
                                        select c;
                            try
                            {
                                if (grupe.Count() == 0)
                                {//inseamna ca nu mai exista si o adaugam


                                    //adaugam in baza de date 
                                    var newGrupa = new Grupa
                                    {
                                        Nume = numeGrupa,
                                        An = AnSelectat,
                                        AnScolarID = idAnScolarSelectat,
                                        SpecializareID = idSpecializareSelectata
                                    };
                                    catalog.Grupas.Add(newGrupa);
                                    catalog.SaveChanges();
                                    dbCatalogTransaction.Commit();


                                    //adaugam in gridview
                                    this.adaugareGrupaGridView(numeGrupa);
                                }
                                else
                                {
                                    bunifuMaterialTextbox1.Text = "Aceasta Grupa deja exista!";
                                }
                            }
                            catch (Exception ex)
                            {
                                dbCatalogTransaction.Rollback();
                                FormError newForm = new FormError();
                                newForm.SetText(ex.ToString());
                                newForm.ShowDialog();
                            }
                        }
                    }
                }
                else
                {
                    bunifuMaterialTextbox1.Text = "Introduceti Nume Grupa!";
                }
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
            Form1.gui.Bring_FirstPageAdmin();
        }
        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void Admin_AdaugareGrupa_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Admin_AdaugareGrupa_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void Admin_AdaugareGrupa_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
