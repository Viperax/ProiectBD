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
    public partial class Admin_AdaugaSpecializare : UserControl
    {
        public Admin_AdaugaSpecializare()
        {
            InitializeComponent();
        }

        public void ResetText_Grid()
        {
            idDepartament = new List<int>();//pentru a tine minte id-urile departamentelor bagata in dropdown ex:dropdown[1]=list[1]
            bunifuCustomDataGrid1.Rows.Clear();
            bunifuDropdown1.Clear();
            bunifuMaterialTextbox1.Text = "";
        }

        public void AdaugareSpecializari(string numeSpecializare)
        {
            bunifuCustomDataGrid1.Rows.Add();
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[0].Value = numeSpecializare;
        }

        List<int> idDepartament;
        public void AdaugareDepartament_DropDown(string NumeDepartament,int addIdDep)
        {
            bunifuDropdown1.AddItem(NumeDepartament);//adaugam in dropdown numele departamentului
            idDepartament.Add(addIdDep);//adaugam in lista de ID-uri, id-ul departamentului
        }

        private void Admin_AdaugaSpecializare_Load(object sender, EventArgs e)
        {

        }
        int departamentId_Selectat;//pentru a tine minte ce s-a selectat
        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            try
            {
                bunifuCustomDataGrid1.Rows.Clear();//daca selecteaza de mai multe ori 
                this.departamentId_Selectat = idDepartament.ElementAt(bunifuDropdown1.selectedIndex);//id ul departamentului pe care l-a selectat

                var catalog = new CatalogEntities1();
                var specializari = from c in catalog.Specializares
                                   where c.DepartamentID == departamentId_Selectat
                                   select c;
                foreach (var spec in specializari)
                {
                    this.AdaugareSpecializari(spec.Nume);//adaugam pentru a le afisa 
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

        private void bunifuMaterialTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int sem = 0;//nu a mai fost adaugata
                if (bunifuDropdown1.selectedIndex != -1)
                { //daca a fost selectat ceva in dropdown
                    string NumeSpecializare = bunifuMaterialTextbox1.Text;
                    if (NumeSpecializare != "" && NumeSpecializare != "Completati Nume Specializare!" && NumeSpecializare != "Specializarea Exista!")//daca a scris ceva in textbox 
                    {

                        //cautam daca a mai fost adaugata specializarea
                        for (int i = 0; i < bunifuCustomDataGrid1.Rows.Count; i++)
                        {
                            if (bunifuCustomDataGrid1.Rows[i].Cells[0].Value.Equals(NumeSpecializare))
                            {
                                sem = 1;//inseamna ca exista
                                break;
                            }

                        }

                        if (sem == 0)
                        { //adica nu a mai fost adaugata
                          //adaugam specializarea in baza de date
                            using (var catalog = new CatalogEntities1())
                            {
                                using (var dbCatalogTransaction = catalog.Database.BeginTransaction())
                                {
                                    try
                                    {
                                        var newSpecializare = new Specializare
                                        {
                                            Nume = NumeSpecializare,
                                            DepartamentID = this.departamentId_Selectat
                                        };
                                        catalog.Specializares.Add(newSpecializare);
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

                                    AdaugareSpecializari(NumeSpecializare);//adaugam specializarea in data grid view
                                }
                            }
                        }
                        else
                            bunifuMaterialTextbox1.Text = "Specializarea Exista!";
                    }
                    else
                    {
                        bunifuMaterialTextbox1.Text = "Completati Nume Specializare!";
                    }
                }//daca nu e selectat nu se intampla nimic
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

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } 
        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;


        private void Admin_AdaugaSpecializare_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Admin_AdaugaSpecializare_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void Admin_AdaugaSpecializare_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;

        }
    }
}
