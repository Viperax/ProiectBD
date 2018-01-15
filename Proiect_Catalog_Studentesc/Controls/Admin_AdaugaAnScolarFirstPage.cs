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
    public partial class Admin_AdaugaAnScolarFirstPage : UserControl
    {
        public Admin_AdaugaAnScolarFirstPage()
        {
            InitializeComponent();
        }

        public void ResetAdaugaAnScolarText()
        {
            bunifuCustomDataGrid1.Rows.Clear();
            bunifuMaterialTextbox1AnPrimar.Text = "";
            bunifuMaterialTextbox1_AnSecundar.Text = "";
        }

        private void Admin_AdaugaAnScolarFirstPage_Load(object sender, EventArgs e)
        {

        }

        public void AdaugareAnScolar(int an1, int an2)
        {
            bunifuCustomDataGrid1.Rows.Add();
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[0].Value =an1;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[1].Value =an2;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string an1_Text = bunifuMaterialTextbox1AnPrimar.Text;
                string an2_Text = bunifuMaterialTextbox1_AnSecundar.Text;
                if (an1_Text != "" && an2_Text != "")//daca s-au completat
                {

                    //aici neaparat block trycatch deoarece se poate adauga si text nu numai int 
                    int an1 = Int32.Parse(an1_Text);//ne trebuie la adaugare 
                    int an2 = Int32.Parse(an2_Text);
                    if (an2 - an1 != 1)
                    {//daca diferenta e mai mare de un an
                        bunifuMaterialTextbox1AnPrimar.Text = "Diferenta maxima dintre ani este 1";
                        bunifuMaterialTextbox1_AnSecundar.Text = "Diferenta maxima dintre ani este 1";
                    }
                    else//inseamna ca diferenta este buna 
                    {
                        using (var catalog = new CatalogEntities1())
                        {
                            using (var dbCatalogTransaction = catalog.Database.BeginTransaction())
                            {
                                var ani = from c in catalog.AnScolars
                                          where c.AnPrimar == an1 && c.AnSecundar == an2
                                          select c;
                                if (ani.Count() == 0)//inseamna ca nu s-a mai gasit
                                {
                                    try
                                    {
                                        //adaugam anul in baza de date
                                        var newAn = new AnScolar()
                                        {
                                            AnPrimar = an1,
                                            AnSecundar = an2
                                        };
                                        catalog.AnScolars.Add(newAn);
                                        catalog.SaveChanges();
                                        dbCatalogTransaction.Commit();
                                        //end adaugam anul in baza de date
                                        this.AdaugareAnScolar(an1, an2);//adaugam in data grid view
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
                                { //inseamna ca a mai fost adaugat 
                                    bunifuMaterialTextbox1AnPrimar.Text = "Acesti ani au mai fost adaugati!";
                                    bunifuMaterialTextbox1_AnSecundar.Text = "Acesti ani au mai fost adaugati!";
                                }
                            }
                        }
                    }
                }
                else
                { //daca nu s-au completat campurile
                    if (an1_Text == "")
                        bunifuMaterialTextbox1AnPrimar.Text = "Completati anul!";
                    if (an2_Text == "")
                        bunifuMaterialTextbox1_AnSecundar.Text = "Completati anul!";
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
        // pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void Admin_AdaugaAnScolarFirstPage_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Admin_AdaugaAnScolarFirstPage_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Admin_AdaugaAnScolarFirstPage_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
