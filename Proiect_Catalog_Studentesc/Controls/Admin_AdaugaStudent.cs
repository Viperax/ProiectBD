using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Proiect_Catalog_Studentesc.Controls
{
    public partial class Admin_AdaugaStudent : UserControl
    {
        public Admin_AdaugaStudent()
        {
            InitializeComponent();
        }


        List<int> IdAniScolari;
        public void AddAniScolariDropDown(int newAnPrimar,int newAnSecundar, int IdAnScolar)
        {
            bunifuDropdown2.AddItem(newAnPrimar.ToString() + "-" + newAnSecundar.ToString());
            IdAniScolari.Add(IdAnScolar);
        }

        List<int> SpecializariId;//tinem minte id-urile corespunzatoare indexilori din dropDown
        public void AddSpecializareDropDown(string new_NumeSpecializare,int new_idSpecializare)
        {
            bunifuDropdown1.AddItem(new_NumeSpecializare);
            SpecializariId.Add(new_idSpecializare);
        }

        public void ResetToolsAddStudent()
        {

            SpecializariId = new List<int>();
            bunifuCustomDataGrid1.Rows.Clear();
            bunifuDropdown1.Clear();
            bunifuDropdown2.Clear();
            bunifuMaterialTextbox1.Text = "";
            bunifuMaterialTextbox2.Text = "";
            bunifuMaterialTextbox3.Text = "";

            //populam dropDown specializare 
            var catalog = new CatalogEntities1();
            var specializari = from c in catalog.Specializares
                               select c;
            foreach(var spec in specializari)
            {
                AddSpecializareDropDown(spec.Nume, spec.SpecializareID);
            }

            IdAniScolari = new List<int>();
            //populam dropDown anScolar

            var ani = from c in catalog.AnScolars
                      select c;
            foreach(var a in ani)
            {
                AddAniScolariDropDown(a.AnPrimar, a.AnSecundar, a.AnScolarID);
            }


        }

        private void Admin_AdaugaStudent_Load(object sender, EventArgs e)
        {

        }


        public void AddStudentDataGrid(string numeStudent,string PrenumeStudent)
        {
            bunifuCustomDataGrid1.Rows.Add();
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[0].Value = numeStudent;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[1].Value = PrenumeStudent;
        }

        int idSpecializareSelectata;
        int idAnScolarSelectat;
        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDropdown1.selectedIndex != -1 && bunifuDropdown2.selectedIndex != -1)//daca au fost selectate amandoua dropDown-urile
                {
                    bunifuCustomDataGrid1.Rows.Clear();
                    this.idSpecializareSelectata = SpecializariId.ElementAt(bunifuDropdown1.selectedIndex);
                    this.idAnScolarSelectat = IdAniScolari.ElementAt(bunifuDropdown2.selectedIndex);

                    var catalog = new CatalogEntities1();
                    var student = from c in catalog.Students
                                  where c.SpecializareID == idSpecializareSelectata && c.AnScolarDeInceputID == idAnScolarSelectat
                                  select c;

                    foreach (var st in student)
                    { //adaugam in dataGrid
                        this.AddStudentDataGrid(st.Nume, st.Prenume);
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

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                if (bunifuDropdown1.selectedIndex != -1 && bunifuDropdown2.selectedIndex != -1)//daca au fost selectate amandoua dropDown-urile
                {
                    bunifuCustomDataGrid1.Rows.Clear();
                    this.idSpecializareSelectata = SpecializariId.ElementAt(bunifuDropdown1.selectedIndex);
                    this.idAnScolarSelectat = IdAniScolari.ElementAt(bunifuDropdown2.selectedIndex);

                    var catalog = new CatalogEntities1();
                    var student = from c in catalog.Students
                                  where c.SpecializareID == idSpecializareSelectata && c.AnScolarDeInceputID == idAnScolarSelectat
                                  select c;

                    foreach (var st in student)
                    { //adaugam in dataGrid
                        this.AddStudentDataGrid(st.Nume, st.Prenume);
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

        public void AddtoFile(string NumeStudent,string PrenumeStudent,string CNPStudent,string ParolaStudent)
        {
            StreamWriter scrieFisier = File.AppendText("ParoleStudenti.txt");
            scrieFisier.WriteLine(NumeStudent+ "/" + PrenumeStudent+ "/" + CNPStudent+ "/" + ParolaStudent);
            scrieFisier.Flush();
            scrieFisier.Close();

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //verificam ca toate campurile sa fie selectate 
                if (bunifuMaterialTextbox1.Text != "" && bunifuMaterialTextbox2.Text != "" && bunifuMaterialTextbox3.Text != "" && bunifuDropdown1.selectedIndex != -1 && bunifuDropdown2.selectedIndex != -1 && bunifuMaterialTextbox3.Text != "Acest CNP exista!")
                {
                    string NumeStudentSelectat = bunifuMaterialTextbox1.Text;
                    string PrenumeStudentSelectat = bunifuMaterialTextbox2.Text;
                    string CNPStudentSelectat = bunifuMaterialTextbox3.Text;
                    //Generam Parola
                    string new_pass = Form1.gui.GenerareParola(3, 3, 4);//3litere mici, 3litere mari,4cifre

                    //Adaugam Nume/Prenume/CNP->Parola in fisier 
                    this.AddtoFile(NumeStudentSelectat, PrenumeStudentSelectat, CNPStudentSelectat, new_pass);
                    //Criptam Parola
                    string new_pass_encrypted = Form1.gui.Criptare_string(new_pass);
                    //verificam CNP-ul studentului, sa nu mai existe
                    using (var catalog = new CatalogEntities1())
                    {
                        using (var dbCatalogTransaction = catalog.Database.BeginTransaction())
                        {
                            var cnps = from c in catalog.Students
                                       where c.CNP.Equals(CNPStudentSelectat)
                                       select c;
                            if (cnps.Count() == 0)
                            { //inseamna ca nu mai exista 
                              //adaugam in baza de date
                                try
                                {
                                    var newStudent = new Student
                                    {
                                        Nume = NumeStudentSelectat,
                                        Prenume = PrenumeStudentSelectat,
                                        CNP = CNPStudentSelectat,
                                        SpecializareID = idSpecializareSelectata,
                                        AnScolarDeInceputID = idAnScolarSelectat,
                                        Password = new_pass_encrypted
                                    };
                                    catalog.Students.Add(newStudent);
                                    catalog.SaveChanges();
                                    dbCatalogTransaction.Commit();

                                    //adaugam in datagridview
                                    AddStudentDataGrid(NumeStudentSelectat, PrenumeStudentSelectat);
                                }
                                catch (Exception)
                                {
                                    dbCatalogTransaction.Rollback();
                                }
                            }
                            else
                            {

                                bunifuMaterialTextbox3.Text = "Acest CNP exista!";
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

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Form1.gui.Bring_FirstPageAdmin();
        }

        private void admin_AdaugareGrupa1_Load(object sender, EventArgs e)
        {

        }
        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;


        private void Admin_AdaugaStudent_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Admin_AdaugaStudent_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void Admin_AdaugaStudent_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
