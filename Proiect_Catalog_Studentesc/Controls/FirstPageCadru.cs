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
    public partial class FirstPageCadru : UserControl
    {

        List<int> ListaId_grupaDropDown;//tine minte indexii(id-urile) din dropDown --> selectedIndex=id_grupaDropDown
        public class GrupaDetails
        {
            public int GrupaId;
            public int AnId;
            public string NumeGrupa;
            public int AnGrupa;
            public string SpecializareGrupa;

            public GrupaDetails(int new_GrupaId,int new_AnId,string new_numeGrupa,int new_AnGrupa,int new_SpecializareId)
            {
                this.GrupaId = new_GrupaId;
                this.AnId = new_AnId;
                this.NumeGrupa = new_numeGrupa;
                this.AnGrupa = new_AnGrupa;

                var catalog = new CatalogEntities1();
                var specializare = from s in catalog.Specializares
                                   where s.SpecializareID == new_SpecializareId
                                   select s;
                foreach(var k in specializare)
                {
                    this.SpecializareGrupa = k.Nume;
                    break;
                }

            }
        }
        public class AnStudiu
        {
           public int an1;//AnPrimar
           public int an2;//AnSecundar

            public AnStudiu(int new_an1,int new_an2)
            {
                this.an1 = new_an1;
                this.an2 = new_an2;
            }

            
        }
        int DepartamentId_SefDepartament;
        int SefDepartamentID;//daca e 0 inseamna ca nu e sefDepartament
        public void SetSefDepartament_Cadre(int IdSefDepartament)
        {
            try
            {
                this.SefDepartamentID = IdSefDepartament;
                this.IdFacultate = 0;
                if (SefDepartamentID == 0 && DecanID == 0)
                {
                    bunifuFlatButton3.Enabled = false;
                }
                else if (SefDepartamentID != 0 && DecanID == 0)//daca nu e decan 
                {
                    string DepartamentNumeSelectat = "";
                    bunifuFlatButton3.Enabled = true;
                    //cautam la ce departament este 
                    var catalog = new CatalogEntities1();
                    var departament = from d in catalog.Departamnets
                                      where d.SefDepartament == SefDepartamentID
                                      select d;
                    if (departament.Count() != 0)
                    {
                        this.DepartamentId_SefDepartament = departament.First().DepartamentID;
                        this.IdFacultate = departament.First().FacultateID;
                        DepartamentNumeSelectat = departament.First().Nume;
                    }
                    //dupa ce am aflat departament id --> il bagam si il selectam automat
                    Form1.gui.Cadru_firstPageStatistici_AddDepartamentAutoSelect(DepartamentNumeSelectat, DepartamentId_SefDepartament);


                    //anii scolari ii bagam la bring 

                }
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }

        }

        int DecanID;//daca e 0 inseamna ca nu e decan si daca e diferit cautam in facultate al cui e decanul 
        int IdFacultate;//si pentru decan si pt sefDepartament
        public void SetDecan_Cadre(int IdDecan)
        {
            try
            {
                Form1.gui.Cadru_FirstPageStatistici_ResetTools();
                Form1.gui.CadruViewSpecializari_ResetTools();//resetam la fiecare logare noua 
                this.IdFacultate = 0;//1 sau 2
                this.DecanID = IdDecan;
                if (DecanID == 0)
                { //inseamna ca nu e decan
                    bunifuFlatButton2.Enabled = false;
                }
                else
                { //cautam al carei facultati e
                    bunifuFlatButton2.Enabled = true;
                    var catalog = new CatalogEntities1();
                    var facultate = from f in catalog.Facultates
                                    where f.DecanID == IdDecan
                                    select f;
                    if (facultate.Count() != 0)
                    {
                        this.IdFacultate = facultate.First().FacultateID;
                    }
                    /// ne intrebam de la ce facultate si scriem in ce apare dupa buton in gridview doar pt facultatea respectiva 
                    if (IdFacultate == 1)
                    {
                        var specializari = from s in catalog.SpecializariEs
                                           select s;
                        foreach (var spec in specializari)
                        {
                            Form1.gui.CadruViewSpecializari_addSpecializareDataGrid(spec.Nume);
                        }
                    }
                    else
                    {
                        var specializari = from s in catalog.SpecializariMs
                                           select s;
                        foreach (var spec in specializari)
                        {
                            Form1.gui.CadruViewSpecializari_addSpecializareDataGrid(spec.Nume);
                        }
                    }

                    //facem sa isi poate alege ce departament vrea in functie de ce facultate  e
                    //luam toate departamentele care sunt in facultatea respectiva
                    bunifuFlatButton3.Enabled = true;
                    var departamente = from d in catalog.Departamnets
                                       where d.FacultateID == IdFacultate
                                       select d;
                    int sem = 0;
                    foreach (var d in departamente)//o bagam in dropdown
                    {
                        Form1.gui.Cadru_firstPageStatistici_AddDepartament(d.Nume, d.DepartamentID, sem);
                        sem = 1;
                    }

                }

                //adaugam toti anii scolari 
                Form1.gui.Cadru_FirstPageStatistici_AddAni();
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }
        //facem verifica id pt back sa vedem ce e si face din nou asta --> daca e diferit de 0 nu il ascunde 
        public void VerificareDecan_Cadre()
        {
            if (DecanID == 0)
                bunifuFlatButton2.Enabled = true;
        }

        List<GrupaDetails> ListaDetaliiGrupe;//tinem minte detaliile despre toate grupele la care preda profesorul 
        List<AnStudiu> ListaAniMaterii;//tinem minte anii materiilor pe care le preda
        public bool Exist(int an1_exist, int an2_exist)
        {
            foreach(AnStudiu k in ListaAniMaterii)
            {
                if(k.an1==an1_exist && k.an2 == an2_exist)
                {
                    return true;//mai exista
                }
            }
            return false;
        }

        public bool ExistGrupaDetails(int GrupaIdE,int AnIdE)
        {
            foreach(GrupaDetails k in ListaDetaliiGrupe)
            {
                if (k.GrupaId == GrupaIdE && k.AnId == AnIdE)
                    return true;//mai exista
            }
            return false;
        }


        public void addDetaliuGrupaLista(int GrupaIdDet,int AnIdDet,string NumeGrupaDet,int AnGrupaDet,int SpecializareIDdet)
        {
            try
            {

                if (!ExistGrupaDetails(GrupaIdDet, AnIdDet))
                {
                    GrupaDetails temp = new GrupaDetails(GrupaIdDet, AnIdDet, NumeGrupaDet, AnGrupaDet, SpecializareIDdet);
                    ListaDetaliiGrupe.Add(temp);
                }
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }
        public void addAnMaterieLista(int new_an1,int new_an2)
        {
            
            if (!Exist(new_an1,new_an2)) { //daca nu contine anul respectiv
                AnStudiu temp = new AnStudiu(new_an1, new_an2);
                ListaAniMaterii.Add(temp);
            }
        }

        int indexCadru;//Id-ul cadrului care s-a logat

        public FirstPageCadru()
        {
            InitializeComponent();
        }

        private void FirstPageCadru_Load(object sender, EventArgs e)
        {

        }

        public void SetIndexCadru(int indexCadruSet)
        {
            try
            {
                bunifuDropdown2.Enabled = false;
                ListaAniMaterii = new List<AnStudiu>();//o alocam de fiecare data 
                ListaDetaliiGrupe = new List<GrupaDetails>();

                this.indexCadru = indexCadruSet;

                var catalog = new CatalogEntities1();
                var materii = from c in catalog.Materies
                              where c.Profesor1ID == indexCadru || c.Profesor2ID == indexCadru || c.Asistent1ID == indexCadru || c.Asisten2ID == indexCadru
                              select c;

                bunifuDropdown1.Clear();
                foreach (var m in materii)//cautam pentru fiecare materie predata, toate grupele si luam anii
                {

                    var grupa = from g in catalog.Grupas
                                join c in catalog.AnScolars
                                on g.AnScolarID equals c.AnScolarID
                                where g.GrupaID == m.GrupaID
                                select new
                                {
                                    AnPrimar = c.AnPrimar,
                                    AnSecundar = c.AnSecundar,
                                    NumeGrupa = g.Nume,
                                    IdGrupa = g.GrupaID,
                                    IdAn = g.AnScolarID,
                                    AnGrupa = g.An,
                                    SpecializareID = g.SpecializareID
                                };

                    if (grupa.Count() != 0)
                    { //daca s-a gasit un element, deoarece este o singura grupa cu id-ul respectiv 
                        this.addAnMaterieLista(grupa.First().AnPrimar, grupa.First().AnSecundar);
                        //adaugam grupaID si anId in clasa
                        this.addDetaliuGrupaLista(grupa.First().IdGrupa, grupa.First().IdAn, grupa.First().NumeGrupa, grupa.First().AnGrupa, grupa.First().SpecializareID);//ne ajuta pentru dupa ce selecteaza anul 

                    }
                }
                //trebuie sa sortam ListaAniMaterii
                // ListaAniMaterii.Sort();
                ListaAniMaterii.Sort((x, y) => x.an1.CompareTo(y.an1));


                foreach (AnStudiu k in this.ListaAniMaterii)//adaugam anii in care preda materii
                {
                    string addAn = k.an1.ToString() + "-" + k.an2.ToString();
                    bunifuDropdown1.AddItem(addAn);
                }

                bunifuDropdown2.Clear();//stergem dropdown-ul cu grupe pentru reconstruire 
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                this.ListaId_grupaDropDown = new List<int>();//alocam lista de id-uri care corespund cu indexii din dropdown
                bunifuDropdown2.Clear();
                bunifuDropdown2.Enabled = true;

                int anSelectatIndex = bunifuDropdown1.selectedIndex;
                int an1Selectat = ListaAniMaterii.ElementAt(anSelectatIndex).an1;
                int an2Selectat = ListaAniMaterii.ElementAt(anSelectatIndex).an2;


                var catalog = new CatalogEntities1();
                string numeGrupaSpaces = "";
                int IdForAdd = 0;//id-ul care se va adauga in lista pt dropDown
                foreach (GrupaDetails g in ListaDetaliiGrupe)
                {
                    var anGrupa = from c in catalog.AnScolars//luam anii corespunzatori id-ului 
                                  where c.AnScolarID == g.AnId
                                  select c;

                    foreach (var anGrupaCautat in anGrupa)
                    {
                        if (anGrupaCautat.AnPrimar == an1Selectat && anGrupaCautat.AnSecundar == an2Selectat)
                        { //se potriveste si anul 
                            IdForAdd = g.GrupaId;
                            ListaId_grupaDropDown.Add(IdForAdd);
                            numeGrupaSpaces = removeSpaces(g.NumeGrupa);
                            bunifuDropdown2.AddItem(numeGrupaSpaces + "\r\n   Anul: " + g.AnGrupa + "\r\n   " + g.SpecializareGrupa);
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

        public string removeSpaces(string toRemove)
        {

                string newString = "";
            for (int i = 0; i < toRemove.Length; i++)
            {
                if (toRemove.ElementAt(i) != ' ')
                    newString += toRemove.ElementAt(i);
            }
            return newString;
  
        }

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
        }

        private void bunifuFlatButton1_CautaMaterii_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.gui.ResetGridViewMaterii_Cadru();

                //verificam daca a selectat ambele campuri 
                if (bunifuDropdown1.selectedIndex != -1 && bunifuDropdown2.selectedIndex != -1)
                {

                    //Construim lista de materii
                    int IndexGrupaSelectata = bunifuDropdown2.selectedIndex;
                    int IdGrupaCautata = ListaId_grupaDropDown.ElementAt(IndexGrupaSelectata);

                    //setam id-ul grupei selectate 
                    Form1.gui.setIdGrupaSelectata(IdGrupaCautata);

                    //adaugam materiile 
                    var catalog = new CatalogEntities1();
                    var materii = from m in catalog.Materies
                                  where m.GrupaID == IdGrupaCautata && (m.Profesor1ID == indexCadru || m.Profesor2ID == indexCadru || m.Asistent1ID == indexCadru || m.Asisten2ID == indexCadru)
                                  select m;

                    foreach (var materieAdd in materii)
                    {
                        Form1.gui.AddMaterii_Cadru(materieAdd.MaterieID, materieAdd.NumeMaterie, materieAdd.ProcentCurs.ToString(), materieAdd.ProcentLaborator.ToString(), materieAdd.ProcentTeme.ToString(), materieAdd.ProcentProiect.ToString(), materieAdd.Examen, materieAdd.Credite.ToString(), materieAdd.Sesiune.ToString());
                    }
                    Form1.gui.Bring_CadruAfisareMaterii();
                }
                else if (bunifuDropdown1.selectedIndex == -1)
                    bunifuDropdown1.NomalColor = Color.Red;
                else if (bunifuDropdown2.selectedIndex == -1)
                    bunifuDropdown2.NomalColor = Color.Red;
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }

        public void resetDropDownColor()
        {
            Color c = Color.FromArgb(21, 189, 177);
            bunifuDropdown1.NomalColor = c;
            bunifuDropdown2.NomalColor = c;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            LogOut newForm = new LogOut();
            newForm.ShowDialog();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            Form1.gui.Bring_CadruViewSpecializari_Decan();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Form1.gui.Bring_CadruFirstPageStatistici();
        }
        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void FirstPageCadru_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void FirstPageCadru_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void FirstPageCadru_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
           
        }
    }
}
