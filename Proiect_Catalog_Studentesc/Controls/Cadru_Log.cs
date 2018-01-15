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
    public partial class Cadru_Log : UserControl
    {
        public Cadru_Log()
        {
            InitializeComponent();
        }

        private void Cadru_Log_Load(object sender, EventArgs e)
        {
            
        }
        public void ResetCadru()
        {
            bunifuMaterialTextbox1_CNP_Cadru.Text = "";
            bunifuMaterialTextbox2_Parola_Cadru.Text = "";
        }

        private void bunifuMaterialTextbox2_Parola_Cadru_OnValueChanged(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2_Parola_Cadru.isPassword = true; 
            
        }

        private void bunifuFlatButton1_Log_Cadru_Click(object sender, EventArgs e)
        {
            try
            {
                string cnp = bunifuMaterialTextbox1_CNP_Cadru.Text;
                string pass = bunifuMaterialTextbox2_Parola_Cadru.Text;

                if (cnp != "" && pass != "")//daca au completat
                {
                    DateTime current = DateTime.Now;//pentru data curenta
                    var catalog = new CatalogEntities1();
                    var cadru = from c in catalog.Cadrus
                                where c.CNP.Equals(cnp)
                                select c;

                    if (cadru.Count() == 0)//daca nu s-a gasit cadrul respectiv
                    {
                        bunifuMaterialTextbox1_CNP_Cadru.Text = "This teacher doesn't exist!";
                        bunifuMaterialTextbox2_Parola_Cadru.Text = "";
                    }
                    else
                    {

                        int IndexCadru = -1;
                        //int anStudent = 1;// anul in care e: 1,2,3,4
                        //int anInceputStudent = 0;
                        string text_information = "";
                        int sem = 1;//inseamna ca e ok
                        string encryptedPass = Form1.gui.Criptare_string(pass);
                        foreach (var k in cadru)
                        {
                            if (k.Password != encryptedPass)//verificam daca corespunde parola 
                            {
                                sem = 0;//parola nu corespunde
                                bunifuMaterialTextbox1_CNP_Cadru.Text = "Incorrect Password!";
                                bunifuMaterialTextbox2_Parola_Cadru.Text = "";
                                break;
                            }


                            IndexCadru = k.CadruID;//setam indexul studentului pentru a-l trimite in mainPageStudent
                            if (k.SefDepartament == true)
                            {//0 inseamna ca e cadru sau sef departament si nu apare butonul de specializari disable buton
                                Form1.gui.SetDecan_Cadre(0);
                                Form1.gui.SetSefDepartament_Cadre(k.CadruID);
                                text_information = "Nume:" + k.Nume + "\r\nPrenume:" + k.Prenume + "\r\nSef Departament";
                            }
                            else if (k.Decan == true)
                            {//daca e !=0 inseamna ca este decan si luam din facultate-> facultatea lui  daca e 1-->e 
                             //enable butonul de vezi toate specializarile --> Setam Id-ul Decanului in pg urmatoare (difera ce se afiseaza dupa buton)
                                Form1.gui.SetDecan_Cadre(k.CadruID);
                                Form1.gui.SetSefDepartament_Cadre(0);
                                text_information = "Nume:" + k.Nume + "\r\nPrenume:" + k.Prenume + "\r\nDecan";
                            }
                            else
                            {//selectam id decan->0 disable buton 
                                Form1.gui.SetDecan_Cadre(0);
                                Form1.gui.SetSefDepartament_Cadre(0);
                                text_information = "Nume:" + k.Nume + "\r\nPrenume:" + k.Prenume + "\r\n";
                            }
                            break;//deoarece cel mai probabil o sa fie unul singur 
                        }
                        if (sem != 0)//daca parola corespunde
                        {
                            Form1.gui.SetIndexCadru(IndexCadru);
                            Form1.gui.Bring_InformationPage(text_information);
                            //Form1.gui.SetAnStudent(anStudent, anInceputStudent);//,Lista_ani_student);//anStudent:1,2,3,4(anul in care este)/anInceputStudent:anul in care a inceput facultatea/Lista_ani_Student:2015-2016=>anul1 =>list[0]
                            Form1.gui.Bring_FirstPageCadru();
                        }
                    }
                }
                else
                {
                    if (cnp == "")
                        bunifuMaterialTextbox1_CNP_Cadru.Text = "This field is empty!";
                    if (pass == "")
                    {
                        bunifuMaterialTextbox2_Parola_Cadru.Text = "Type a password...";
                        bunifuMaterialTextbox2_Parola_Cadru.isPassword = false;
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

        private void Cadru_Log_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Cadru_Log_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void Cadru_Log_MouseUp(object sender, MouseEventArgs e)
        {

            mouseDown = false;
        }
    }
}
