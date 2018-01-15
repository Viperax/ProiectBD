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
    public partial class Admin_AdaugareMaterie : UserControl
    {
        int IdFacultate;
        public Admin_AdaugareMaterie()
        {
            InitializeComponent();
        }

        public void SetIdFacultate_AddMaterie(int idFacultateToSet)
        {
            this.IdFacultate = idFacultateToSet;
        }


        List<int> idDepartamente;//tinem minte id-urile departamentelor din dropDown
        public void AddDepartament(string NumeDepartament, int new_idDepartament)
        {
            bunifuDropdown1.AddItem(NumeDepartament);
            idDepartamente.Add(new_idDepartament);//adaugam in lista de id-uri corespunzatori indexilor din dropDown
        }
        public void ResetCheckBox()
        {
            bunifuCheckbox2.Checked = false;
            bunifuDropdown7.Enabled = false;
            bunifuCheckbox3.Checked = false;
            bunifuDropdown9.Enabled = false;
        }
        public void ResetAllTools()
        {
            bunifuFlatButton3.Enabled = false;
            this.ResetCheckBox();
            Bitmap cale = new Bitmap("Failed_Exam.png");
            bunifuFlatButton1.Iconimage = cale;
            bunifuMaterialTextbox1.Enabled = false;
            this.idDepartamente = new List<int>();
            bunifuCheckbox1.Checked = false;
            bunifuCustomDataGrid1.Rows.Clear();
            bunifuDropdown1.Clear();
            bunifuDropdown2.Clear();
            bunifuDropdown3.Clear();
            bunifuDropdown4.Clear();
            bunifuDropdown5.Clear();
            bunifuDropdown6.Clear();
            bunifuDropdown7.Clear();
            bunifuDropdown8.Clear();
            bunifuDropdown9.Clear();
            bunifuMaterialTextbox1.Text = "";
            bunifuMaterialTextbox2.Text = "";
            bunifuMaterialTextbox3.Text = "";
            bunifuMaterialTextbox4.Text = "";
            bunifuMaterialTextbox5.Text = "";
            bunifuMaterialTextbox6.Text = "";


            //aici se apasa si butonul si populam si primul DropDown-> Departament
            var catalog = new CatalogEntities1();
            var departamente = from c in catalog.Departamnets//luam toate departamentele care au id-ul facultatii cautate
                               where c.FacultateID == this.IdFacultate
                               select c;

            foreach (var dep in departamente)//adaugam fiecare departament in dropDown
            {

                AddDepartament(dep.Nume, dep.DepartamentID);
            }
        }

        private void Admin_AdaugareMaterie_Load(object sender, EventArgs e)
        {

        }

        List<int> IdSpecializari;//tinem minte id-urile specializarilor din al doilea dropdown corespunzatoare indexilor din dropDown
        public void adaugareSpecializariDropDown(string NumeSpecializare, int idSpecializare)
        {
            bunifuDropdown2.AddItem(NumeSpecializare);
            IdSpecializari.Add(idSpecializare);//adaugam in lista de id-uri corespunzatori indexilor din dropDown
        }

        int IdDepartamentSelectat;//tinem minte ce departament a fost selectat
        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                //dupa ce selectam Departamentul:
                if (bunifuDropdown1.selectedIndex != -1)
                { //daca a fost selectat departamentul
                    bunifuFlatButton3.Enabled = false;
                    bunifuCheckbox1.Checked = false;
                    Bitmap cale = new Bitmap("Failed_Exam.png");
                    bunifuFlatButton1.Iconimage = cale;
                    bunifuCustomDataGrid1.Rows.Clear();
                    bunifuDropdown2.Clear();
                    bunifuDropdown3.Clear();
                    bunifuDropdown4.Clear();
                    bunifuDropdown5.Clear();
                    bunifuDropdown6.Clear();
                    bunifuDropdown7.Clear();
                    bunifuDropdown8.Clear();
                    bunifuDropdown9.Clear();
                    bunifuMaterialTextbox1.Text = "";
                    bunifuMaterialTextbox2.Text = "";
                    bunifuMaterialTextbox3.Text = "";
                    bunifuMaterialTextbox4.Text = "";
                    bunifuMaterialTextbox5.Text = "";
                    bunifuMaterialTextbox6.Text = "";
                    this.ResetCheckBox();
                    IdSpecializari = new List<int>();
                    this.IdDepartamentSelectat = idDepartamente.ElementAt(bunifuDropdown1.selectedIndex);

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
                //Console.WriteLine(ex.ToString());
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }


        List<int> IdAniScolari;//tinem minte id-urile anilor din al 3-lea dropDown corespunzatori anilor scolari adaugati
        public void adaugareAniScoloariDropDown(string anScolar, int idAnScolar)
        {
            bunifuDropdown3.AddItem(anScolar);
            IdAniScolari.Add(idAnScolar);//adaugam in lista de id-uri corespunzatori indexilor din dropDown
        }



        int idSpecializareSelectata;//tinem minte ce Specializare a fost selectata

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDropdown2.selectedIndex != -1)
                { //daca a fost selectat ceva
                    bunifuFlatButton3.Enabled = false;
                    Bitmap cale = new Bitmap("Failed_Exam.png");
                    bunifuFlatButton1.Iconimage = cale;
                    bunifuCheckbox1.Checked = false;
                    bunifuCustomDataGrid1.Rows.Clear();
                    bunifuDropdown3.Clear();
                    bunifuDropdown4.Clear();
                    bunifuDropdown5.Clear();
                    bunifuDropdown6.Clear();
                    bunifuDropdown7.Clear();
                    bunifuDropdown8.Clear();
                    bunifuDropdown9.Clear();
                    bunifuMaterialTextbox1.Text = "";
                    bunifuMaterialTextbox2.Text = "";
                    bunifuMaterialTextbox3.Text = "";
                    bunifuMaterialTextbox4.Text = "";
                    bunifuMaterialTextbox5.Text = "";
                    bunifuMaterialTextbox6.Text = "";
                    this.ResetCheckBox();
                    IdAniScolari = new List<int>();
                    this.idSpecializareSelectata = IdSpecializari.ElementAt(bunifuDropdown2.selectedIndex);

                    ////punem sa afisam toti aniiScolari: ex:2015-2016...
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



        List<int> IdAni;//tinem minte id-urile anilor din al 3-lea dropDown corespunzatori anilor scolari adaugati
        public void adaugareAniDropDown(string an, int idAn)
        {
            bunifuDropdown4.AddItem(an);
            IdAni.Add(idAn);//adaugam in lista de id-uri corespunzatori indexilor din dropDown
        }

        string[] aniRoman = { "I", "II", "III", "IV" };

        int idAnScolarSelectat;//tinem minte anulScolar pe care l-a selectat
        private void bunifuDropdown3_onItemSelected(object sender, EventArgs e)
        {
            if (bunifuDropdown3.selectedIndex != -1)
            { //daca a fost selectat ceva

                IdAni = new List<int>();
                bunifuFlatButton3.Enabled = false;
                Bitmap cale = new Bitmap("Failed_Exam.png");
                bunifuFlatButton1.Iconimage = cale;
                bunifuCheckbox1.Checked = false;
                bunifuCustomDataGrid1.Rows.Clear();
                bunifuDropdown4.Clear();
                bunifuDropdown5.Clear();
                bunifuDropdown6.Clear();
                bunifuDropdown7.Clear();
                bunifuDropdown8.Clear();
                bunifuDropdown9.Clear();
                bunifuMaterialTextbox1.Text = "";
                bunifuMaterialTextbox2.Text = "";
                bunifuMaterialTextbox3.Text = "";
                bunifuMaterialTextbox4.Text = "";
                bunifuMaterialTextbox5.Text = "";
                bunifuMaterialTextbox6.Text = "";
                this.ResetCheckBox();
                this.idAnScolarSelectat = IdAniScolari.ElementAt(bunifuDropdown3.selectedIndex);

                //punem sa afisam toti anii: 1,2,3,4
                for (int i = 0; i < 4; i++)//adaugam anii
                {
                    adaugareAniDropDown(aniRoman[i], i + 1);
                }
            }

        }
        List<int> IndexiGrupa;//tinem minte indexii corespunzatori dropDown-ului
        public void adaugareGrupeDropDown(string numeGrupa,int idGrupa)
        {
            bunifuDropdown5.AddItem(numeGrupa);
            IndexiGrupa.Add(idGrupa);//adaugam in lista de id-uri corespunzatori indexilor din dropDown
        }

        int AnSelectat;//anul pe care il selecteaza : 1,2,3,4
        private void bunifuDropdown4_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDropdown4.selectedIndex != -1)
                {
                    IndexiGrupa = new List<int>();
                    //Resetam totul
                    bunifuCheckbox1.Checked = false;
                    bunifuFlatButton3.Enabled = false;
                    Bitmap cale = new Bitmap("Failed_Exam.png");
                    bunifuFlatButton1.Iconimage = cale;
                    bunifuCustomDataGrid1.Rows.Clear();
                    bunifuDropdown5.Clear();
                    bunifuDropdown6.Clear();
                    bunifuDropdown7.Clear();
                    bunifuDropdown8.Clear();
                    bunifuDropdown9.Clear();
                    bunifuMaterialTextbox1.Text = "";
                    bunifuMaterialTextbox2.Text = "";
                    bunifuMaterialTextbox3.Text = "";
                    bunifuMaterialTextbox4.Text = "";
                    bunifuMaterialTextbox5.Text = "";
                    bunifuMaterialTextbox6.Text = "";
                    this.ResetCheckBox();
                    this.AnSelectat = IdAni.ElementAt(bunifuDropdown4.selectedIndex);
                    //afisam toate grupele cu an-ul selectat, anscolarIdSelectat, SpecializareId-Selectata
                    var catalog = new CatalogEntities1();
                    var grupe = from c in catalog.Grupas
                                where c.An == AnSelectat && c.AnScolarID == idAnScolarSelectat && c.SpecializareID == idSpecializareSelectata
                                select c;

                    foreach (var grupa in grupe)
                    {
                        //adaugam in gridview
                        this.adaugareGrupeDropDown(grupa.Nume, grupa.GrupaID);
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

        public void AdaugareMateriiGridView(string NumeMaterie)
        {
            bunifuCustomDataGrid1.Rows.Add();
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[0].Value = NumeMaterie;
        }
        int IdGrupaSelectata;//tinem minte Id-ul grupei care a fost selectata 
        private void bunifuDropdown5_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                //dupa ce selecteaza grupa afisam toate materiile corespunzatoare cu ce am selectat
                if (bunifuDropdown5.selectedIndex != -1)
                {

                    //Resetam totul
                    bunifuFlatButton3.Enabled = false;
                    Bitmap cale = new Bitmap("Failed_Exam.png");
                    bunifuFlatButton1.Iconimage = cale;
                    bunifuCheckbox1.Checked = false;
                    bunifuCustomDataGrid1.Rows.Clear();
                    bunifuDropdown6.Clear();
                    bunifuDropdown7.Clear();
                    bunifuDropdown8.Clear();
                    bunifuDropdown9.Clear();
                    bunifuMaterialTextbox1.Text = "";
                    bunifuMaterialTextbox2.Text = "";
                    bunifuMaterialTextbox3.Text = "";
                    bunifuMaterialTextbox4.Text = "";
                    bunifuMaterialTextbox5.Text = "";
                    bunifuMaterialTextbox6.Text = "";
                    this.ResetCheckBox();
                    this.IdGrupaSelectata = IndexiGrupa.ElementAt(bunifuDropdown5.selectedIndex);
                    //afisam toate materiile din grupa respectiva 
                    var catalog = new CatalogEntities1();
                    var materii = from c in catalog.Materies
                                  where c.GrupaID == this.IdGrupaSelectata
                                  select c;


                    foreach (var mat in materii)
                    {
                        //adaugam in gridview
                        this.AdaugareMateriiGridView(mat.NumeMaterie);
                    }
                    bunifuMaterialTextbox1.Enabled = true;
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

        public string GetNumeProfesor(int IdProfesor)
        {
            string Nume = "";
            var catalog = new CatalogEntities1();
            var Profi = from c in catalog.Cadrus
                        where c.CadruID == IdProfesor
                        select c;
            foreach(var prof in Profi)
            {
                Nume = prof.Nume + " " + prof.Prenume;
            }
            return Nume;
        }

        List<int> IndexiProfesori;//tinem minte indexii corespunzatori dropDown-ului
        public void adaugaProfesoriDropDown(string numeProfesor, int idProfesor)
        {
                bunifuDropdown6.AddItem(numeProfesor);
                bunifuDropdown7.AddItem(numeProfesor);
                bunifuDropdown8.AddItem(numeProfesor);
                bunifuDropdown9.AddItem(numeProfesor);
                IndexiProfesori.Add(idProfesor);//adaugam in lista de id-uri corespunzatori indexilor din dropDown

        }

        string NumeMaterieSelectata = "";
        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {
           
        }

        private void bunifuMaterialTextbox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuMaterialTextbox1.Text != "" && bunifuMaterialTextbox1.Text != "Aceasta Materie deja exsita!")
                {
                    this.NumeMaterieSelectata = bunifuMaterialTextbox1.Text;

                    //cautam daca mai exista aceasta materie
                    var catalog = new CatalogEntities1();
                    var materii = from c in catalog.Materies
                                  where c.NumeMaterie.Equals(this.NumeMaterieSelectata) && c.GrupaID == IdGrupaSelectata
                                  select c;
                    bunifuFlatButton3.Enabled = false;
                    if (materii.Count() == 0)//daca materia nu exista -> se vor genera profesorii in dropDown6
                    {

                        //adaugam sesiune 1/2
                        bunifuDropdown10.Clear();
                        bunifuDropdown10.AddItem("I");
                        bunifuDropdown10.AddItem("II");

                        bunifuFlatButton3.Enabled = true;

                        Bitmap cale = new Bitmap("Pass_Exam.png");
                        bunifuFlatButton1.Iconimage = cale;
                        bunifuCheckbox1.Checked = false;
                        bunifuDropdown6.Clear();
                        bunifuDropdown7.Clear();
                        bunifuDropdown8.Clear();
                        bunifuDropdown9.Clear();
                        bunifuMaterialTextbox2.Text = "";
                        bunifuMaterialTextbox3.Text = "";
                        bunifuMaterialTextbox4.Text = "";
                        bunifuMaterialTextbox5.Text = "";
                        bunifuMaterialTextbox6.Text = "";
                        this.ResetCheckBox();
                        IndexiProfesori = new List<int>();
                        //iau toti profesorii
                        var profi = from c in catalog.Cadrus
                                    select c;
                        //pentru fiecare materie iau toti profesorii si ii adaug in dropdown6,7,8,9
                        foreach (var p in profi)
                        {
                            adaugaProfesoriDropDown(GetNumeProfesor(p.CadruID), p.CadruID);
                        }

                    }
                    else
                    {
                        Bitmap cale = new Bitmap("Failed_Exam.png");
                        bunifuFlatButton1.Iconimage = cale;
                        bunifuMaterialTextbox1.Text = "Aceasta Materie deja exsita!";
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

        private void student_Afisare_Materii1_Load(object sender, EventArgs e)
        {

        }
        int idProf1, idProf2, idAsistent1, idAsistent2;//tinem minte id-urile asistentilor -> nu exista= -1

        bool ExamenSet;//daca e examen sau nu 
        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            try
            {
                this.idProf1 = bunifuDropdown6.selectedIndex;//sunt indexii din table de profesori --> IndexiProfesori
                this.idProf2 = bunifuDropdown7.selectedIndex;
                this.idAsistent1 = bunifuDropdown8.selectedIndex;
                this.idAsistent2 = bunifuDropdown9.selectedIndex;
                //adaugam in baza de date
                if (idProf1 != -1 && idAsistent1 != -1 && bunifuMaterialTextbox6.Text != "" && bunifuDropdown10.selectedIndex != -1 && bunifuMaterialTextbox2.Text != "" && bunifuMaterialTextbox3.Text != "" && bunifuMaterialTextbox4.Text != "" && bunifuMaterialTextbox5.Text != "")
                {
                    if (bunifuCheckbox1.Checked)
                        ExamenSet = true;
                    else ExamenSet = false;

                    int idProf2aux;//pentru a tine minte ce transmite mai departe
                    int idAsistent2aux;

                    //cautam daca mai exista aceasta materie
                    using (var catalog = new CatalogEntities1())
                    {
                        using (var dbCatalogTransaction = catalog.Database.BeginTransaction())
                        {
                            var materii = from c in catalog.Materies
                                          where c.NumeMaterie.Equals(this.NumeMaterieSelectata) && c.GrupaID == IdGrupaSelectata
                                          select c;
                            if (materii.Count() == 0)
                            { //daca nu mai exista o adaugam
                              //adaugam in baza de date 
                                try
                                {
                                    if (bunifuCheckbox2.Checked == false)
                                        idProf2aux = -1;//adica null 
                                    else
                                        idProf2aux = IndexiProfesori.ElementAt(idProf2);

                                    if (bunifuCheckbox3.Checked == false)
                                        idAsistent2aux = -1;//adica e null
                                    else
                                        idAsistent2aux = IndexiProfesori.ElementAt(idAsistent2);
                                    //apelam procedura stocata cu parametrii selectati pentru materie:

                                    catalog.Adaugare_Materie(IdGrupaSelectata, NumeMaterieSelectata, IndexiProfesori.ElementAt(idProf1), idProf2aux, IndexiProfesori.ElementAt(idAsistent1), idAsistent2aux, float.Parse(bunifuMaterialTextbox2.Text), float.Parse(bunifuMaterialTextbox3.Text), float.Parse(bunifuMaterialTextbox4.Text), float.Parse(bunifuMaterialTextbox5.Text), ExamenSet, Int32.Parse(bunifuMaterialTextbox6.Text), bunifuDropdown10.selectedIndex + 1);
                                    catalog.SaveChanges();
                                    dbCatalogTransaction.Commit();
                                    //end adaugare

                                    //adaugam in gridview
                                    AdaugareMateriiGridView(NumeMaterieSelectata);
                                }
                                catch (Exception ex)
                                {
                                    dbCatalogTransaction.Rollback();
                                    FormError newForm = new FormError();
                                    newForm.SetText(ex.ToString());
                                    newForm.ShowDialog();
                                }
                            }
                            else
                            {//semnalizam ca materia deja exista 
                                Bitmap cale = new Bitmap("Failed_Exam.png");
                                bunifuFlatButton1.Iconimage = cale;
                                bunifuMaterialTextbox1.Text = "Aceasta Materie deja exsita!";
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
        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;


        private void Admin_AdaugareMaterie_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Admin_AdaugareMaterie_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void Admin_AdaugareMaterie_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Form1.gui.Bring_FirstPageAdmin();
        }

        private void bunifuCheckbox3_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox3.Checked == false)
            {
                bunifuDropdown9.Enabled = false;
                idAsistent2 = -1;//adica nu exista
            }
            else
            {
                bunifuDropdown9.Enabled = true;
            }
        }

        private void bunifuCheckbox2_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox2.Checked == false)
            {
                bunifuDropdown7.Enabled = false;
                idProf2 = -1;//adica nu exista
            }
            else
            {
                bunifuDropdown7.Enabled = true;
            }
        }
    }
}
