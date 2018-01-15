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
    public partial class Student_Log : UserControl
    {
        public static Student_Log gui_LogareStudent;

        public class an_student
        {
            public  int an1;
            public int an2;
            public an_student(int new_an1,int new_an2)
            {
                this.an1 = new_an1;
                this.an2 = new_an2;
            }
        };

        public List<an_student> Lista_ani_student;//tinem minte toti anii in care este ex:anul 1:2015-2016



        public void populate_ListaAniStudent(int anCurent,int anStart)//anul curent va fi de forma: 1,2,3,4
        {
            Lista_ani_student = new List<an_student>();
            
            for (int i = 0; i < 4; i++)
            {
                an_student anScolar = new an_student(anStart+i,anStart+i+1);
                Lista_ani_student.Add(anScolar);
            }
        }

        public Student_Log()
        {
            InitializeComponent();
            gui_LogareStudent = this;
            //bunifuMaterialTextbox2_Parola_Student;
        }

        private void Student_Log_Load(object sender, EventArgs e)
        {
            
        }

        public void ResetStudent()
        {
            bunifuMaterialTextbox1_CNP_Student.Text = "";
            bunifuMaterialTextbox2_Parola_Student.Text = "";
        }

        private void bunifuFlatButton1_Log_Student_Click(object sender, EventArgs e)
        {
            try
            {
                string cnp = bunifuMaterialTextbox1_CNP_Student.Text;
                string pass = bunifuMaterialTextbox2_Parola_Student.Text;
                if (cnp != "" && pass != "")//daca au completat
                {
                    DateTime current = DateTime.Now;//pentru data curenta
                    var catalog = new CatalogEntities1();
                    var student = from s in catalog.Students
                                  join o in catalog.Specializares
                                  on s.SpecializareID equals o.SpecializareID
                                  join an in catalog.AnScolars
                                  on s.AnScolarDeInceputID equals an.AnScolarID
                                  where s.CNP.Equals(cnp)
                                  select new
                                  {
                                      Nume_student = s.Nume,
                                      Prenume_student = s.Prenume,
                                      Specializare = o.Nume,
                                      An_Curent = current.Year,//anul in care suntem
                                      Luna_Curenta = current.Month,//luna in care suntem
                                      Parola = s.Password,
                                      Index = s.StudentID,
                                      AnInceput = an.AnPrimar//anul in care a inceput facultatea studentul 
                                  };

                    if (student.Count() == 0)//daca nu s-a gasit studentul respectiv 
                    {
                        bunifuMaterialTextbox1_CNP_Student.Text = "This student doesn't exist!";
                        bunifuMaterialTextbox2_Parola_Student.Text = "";
                    }
                    else
                    {

                        int IndexStudent = -1;
                        int anStudent = 1;// anul in care e: 1,2,3,4
                        int anInceputStudent = 0;
                        string text_information = "";
                        int sem = 1;//inseamna ca e ok
                        string Parola_Criptata = Form1.gui.Criptare_string(pass);
                        foreach (var k in student)
                        {
                            if (k.Parola != Parola_Criptata)//aici verificam parola criptata daca exista 
                            {
                                sem = 0;//parola nu corespunde
                                bunifuMaterialTextbox1_CNP_Student.Text = "Incorrect Password!";
                                bunifuMaterialTextbox2_Parola_Student.Text = "";
                                break;
                            }
                            anInceputStudent = k.AnInceput;
                            //calculam in ce an este studentul
                            if (k.Luna_Curenta >= 9)//inseamna ca este anul urmator (ne ajuta pe viitor la dropdown )
                                anStudent = (k.An_Curent - k.AnInceput) + 1;//inseamna ca deja este in anul urmator
                            else
                                anStudent = k.An_Curent - k.AnInceput;

                            populate_ListaAniStudent(k.An_Curent, k.AnInceput);//facem lista cu anii corespunzatori  //!!!! aici putem scoate an curent ca nu avem nevoie de el 

                            IndexStudent = k.Index;//setam indexul studentului pentru a-l trimite in mainPageStudent
                            if (k.Specializare.Length > 20)//daca este textul prea mare la specializare sa il imparta in 2 randuri
                            {
                                int index2 = 0;
                                int index = k.Specializare.IndexOf(" ");
                                string Specializare_Temp = "";
                                int first = 0;
                                //pentru a pune specializarea pe mai multe randuri deoarece este prea lunga 
                                while (index != -1 && index != k.Specializare.Length)
                                {
                                    if (first == 0)
                                        Specializare_Temp += k.Specializare.Substring(index2, index);
                                    first = 1;
                                    index2 = index;
                                    Specializare_Temp += "\r\n";
                                    index = k.Specializare.IndexOf(" ", index + 1);
                                    if (index == -1)
                                        index = k.Specializare.Length;
                                    Specializare_Temp += k.Specializare.Substring(index2 + 1, (index) - (index2 + 1));
                                }
                                text_information = "Nume:" + k.Nume_student + "\nPrenume:" + k.Prenume_student + "\nSpecializare:\r\n" + Specializare_Temp + "\nAn: " + anStudent;
                            }
                            else
                                text_information = "Nume:" + k.Nume_student + "\nPrenume:" + k.Prenume_student + "\nSpecializare: " + k.Specializare + "\nAn: " + anStudent;

                            break;
                        }
                        if (sem != 0)//daca parola nu corespunde
                        {
                            Form1.gui.SetIndexStudent(IndexStudent);
                            Form1.gui.Bring_InformationPage(text_information);
                            Form1.gui.SetAnStudent(anStudent, anInceputStudent);//,Lista_ani_student);//anStudent:1,2,3,4(anul in care este)/anInceputStudent:anul in care a inceput facultatea/Lista_ani_Student:2015-2016=>anul1 =>list[0]
                            Form1.gui.FirstPageStudentResetDropDownColors();
                            Form1.gui.Bring_FirstPageStudent();
                        }
                    }
                }
                else
                {
                    if (cnp == "")
                        bunifuMaterialTextbox1_CNP_Student.Text = "This field is empty!";
                    if (pass == "")
                    {
                        bunifuMaterialTextbox2_Parola_Student.Text = "Type a password...";
                        bunifuMaterialTextbox2_Parola_Student.isPassword = false;
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

        private void bunifuMaterialTextbox2_Parola_Student_OnValueChanged(object sender, EventArgs e)
        {
            bunifuMaterialTextbox2_Parola_Student.isPassword = true;
        }


        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void Student_Log_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X-700;
                mouseY = MousePosition.Y-300;
                Form1.gui.SetMouse(mouseX, mouseY);
               
            }
        }

        private void Student_Log_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void Student_Log_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }
    }
}
