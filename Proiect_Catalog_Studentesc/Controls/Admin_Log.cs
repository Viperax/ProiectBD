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
    public partial class Admin_Log : UserControl
    {
        public Admin_Log()
        {
            InitializeComponent();
        }

        private void Admin_Log_Load(object sender, EventArgs e)
        {

        }


        private void bunifuFlatButton1_Log_Admin_Click(object sender, EventArgs e)
        {
            try
            {
                string cnp = bunifuMaterialTextbox1_CNP_Admin.Text;
                string pass = bunifuMaterialTextbox2_Parola_Admin.Text;

                if (cnp != "" && pass != "")//daca au completat
                {
                    DateTime current = DateTime.Now;//pentru data curenta
                    var catalog = new CatalogEntities1();
                    var cadru = from c in catalog.Cadrus
                                where c.CNP.Equals(cnp)
                                select c;

                    if (cadru.Count() == 0)//daca nu s-a gasit cadrul respectiv
                    {
                        bunifuMaterialTextbox1_CNP_Admin.Text = "This Admin doesn't exist!";
                        bunifuMaterialTextbox2_Parola_Admin.Text = "";
                    }
                    else
                    {

                        int IndexAdmin = -1;
                        int IdFacultate = -1;
                        string text_information = "";
                        int sem = 1;//inseamna ca e ok
                        string pass_encrypted = Form1.gui.Criptare_string(pass);

                        foreach (var k in cadru)
                        {
                            if (k.Password != pass_encrypted)//verificam daca corespunde parola 
                            {
                                sem = 0;//parola nu corespunde
                                bunifuMaterialTextbox1_CNP_Admin.Text = "Incorrect Password!";
                                bunifuMaterialTextbox2_Parola_Admin.Text = "";
                                break;
                            }

                            //verificam daca e admin (il cautam in AdministratorFacultate1ID sau AdministratorFacultate2ID din Facultate
                            var admin = from c in catalog.Facultates
                                        where c.AdministratorFacultate1ID == k.CadruID || c.AdministratorFacultate2ID == k.CadruID
                                        select c;
                            if (admin.Count() != 0)//inseamna ca a gasit un admin la o facultate cu datele cautate 
                            {
                                foreach (var adminInfo in admin)
                                {
                                    IdFacultate = adminInfo.FacultateID;//tinem minte id-ul facultatii
                                    IndexAdmin = k.CadruID;//setam indexul Admin-ului pentru a-l trimite in mainpage
                                    text_information = "Nume:" + k.Nume + "\r\nPrenume:" + k.Prenume + "\r\nAdmin";
                                }
                            }
                            else
                            {//daca nu gaseste admin la o facultate cu datele cadrului :
                                bunifuMaterialTextbox1_CNP_Admin.Text = "This is not an Admin!";
                                bunifuMaterialTextbox2_Parola_Admin.Text = "";
                                sem = 0;
                            }
                            break;//deoarece cel mai probabil o sa fie unul singur 
                        }
                        if (sem != 0)//daca parola corespunde si este si Admin 
                        {
                            Form1.gui.SetIdAdmin(IndexAdmin, IdFacultate);
                            Form1.gui.Bring_InformationPage(text_information);
                            Form1.gui.Bring_FirstPageAdmin();
                        }
                    }
                }
                else
                {
                    if (cnp == "")
                        bunifuMaterialTextbox1_CNP_Admin.Text = "This field is empty!";
                    if (pass == "")
                    {
                        bunifuMaterialTextbox2_Parola_Admin.Text = "Type a password...";
                        bunifuMaterialTextbox2_Parola_Admin.isPassword = false;
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

        private void bunifuMaterialTextbox2_Parola_Admin_OnValueChanged(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2_Parola_Admin.isPassword = true;
        }

        public void ResetAdmin()
        {
            bunifuMaterialTextbox1_CNP_Admin.Text = "";
            bunifuMaterialTextbox2_Parola_Admin.Text = "";
        }

        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void Admin_Log_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Admin_Log_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void Admin_Log_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
