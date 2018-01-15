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
    public partial class Admin_AdaugareDepartament : UserControl
    {
        int FacultateID;//setam facultate id pentru care bagam departamentul
        public Admin_AdaugareDepartament()
        {
            InitializeComponent();
        }

        public void ResetTextDepartament()
        {
            bunifuMaterialTextbox1.Text = "";
            bunifuCustomDataGrid1.Rows.Clear();
        }

        private void Admin_AdaugareDepartament_Load(object sender, EventArgs e)
        {

        }
        public void SetareFacultateId(int facIdSet)
        {
            this.FacultateID = facIdSet;
        }

        public void AdminAddDepartament(string numeDepartament)
        {
            bunifuCustomDataGrid1.Rows.Add();
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[0].Value = numeDepartament;

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            Form1.gui.Bring_FirstPageAdmin();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string NumeDepartament = bunifuMaterialTextbox1.Text;//numele departamentului adaugat
                if (NumeDepartament != "" && NumeDepartament != "Adaugati Nume Departament!" && NumeDepartament != "Departament deja existent!")
                {
                    int sem = 0;//inseamna ca nu exista
                                //testam daca mai exista numele de departament care vrea sa il adauge 
                    for (int i = 0; i < bunifuCustomDataGrid1.Rows.Count; i++)
                    {
                        if (bunifuCustomDataGrid1.Rows[i].Cells[0].Value.Equals(NumeDepartament))
                        {
                            sem = 1;//inseamna ca exista
                            break;
                        }

                    }

                    if (sem == 0)
                    { //daca nu mai exista deja
                        AdminAddDepartament(NumeDepartament);//adaugam departamentul in gridview

                        //adaugam departamentul in baza de date  
                        using (var catalog = new CatalogEntities1())
                        {
                            using (var dbCatalogTransaction = catalog.Database.BeginTransaction())
                            {
                                try
                                {
                                    var newDepartament = new Departamnet
                                    {
                                        Nume = NumeDepartament,
                                        FacultateID = this.FacultateID
                                    };
                                    catalog.Departamnets.Add(newDepartament);
                                    catalog.SaveChanges();
                                    dbCatalogTransaction.Commit();
                                    //end adaugam departament in baza de date
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
                        bunifuMaterialTextbox1.Text = "Departament deja existent!";
                    }

                }
                else
                {
                    bunifuMaterialTextbox1.Text = "Adaugati Nume Departament!";
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
        private void Admin_AdaugareDepartament_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Admin_AdaugareDepartament_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Admin_AdaugareDepartament_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }
    }
}
