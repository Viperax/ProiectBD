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

namespace Proiect_Catalog_Studentesc
{
    public partial class Admin_AdaugaCadru : UserControl
    {
        public Admin_AdaugaCadru()
        {
            InitializeComponent();
        }

        public void AddProfesorDataGrid(string NumeProfesor, string PrenumeProfesor)
        {
            bunifuCustomDataGrid1.Rows.Add();
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[0].Value = NumeProfesor;
            bunifuCustomDataGrid1.Rows[bunifuCustomDataGrid1.Rows.Count - 1].Cells[1].Value = PrenumeProfesor;
        }

        public void ResetAllTools()
        {
            bunifuCheckbox1.Checked = false;
            bunifuCheckbox2.Checked = false;
            bunifuCustomDataGrid1.Rows.Clear();
            bunifuMaterialTextbox1.Text = "";
            bunifuMaterialTextbox2.Text = "";
            bunifuMaterialTextbox3.Text = "";

            //adaugam toti profesorii in dataGrid (Nume,Prenume,Materie)

            var catalog = new CatalogEntities1();
            //luam toti profesorii si dupaia pentru fiecare profesor il cautam in materii 
            var profi = from p in catalog.Cadrus
                        select
                        p;
            foreach (var p in profi)
            {
                this.AddProfesorDataGrid(p.Nume, p.Prenume);
            }
        }

        private void Admin_AdaugaCadru_Load(object sender, EventArgs e)
        {

        }


        public void AddtoFile(string NumeCadru, string PrenumeCadru, string CNPCadru, string ParolaCadru)
        {
            StreamWriter scrieFisier = File.AppendText("ParoleCadre.txt");
            scrieFisier.WriteLine(NumeCadru+ "/" + PrenumeCadru + "/" + CNPCadru + "/" + ParolaCadru);
            scrieFisier.Flush();
            scrieFisier.Close();

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (bunifuMaterialTextbox1.Text != "" && bunifuMaterialTextbox2.Text != "" && bunifuMaterialTextbox3.Text != "" && bunifuMaterialTextbox1.Text != "Cadrul Exista!")
                {
                    string NumeCadru = bunifuMaterialTextbox1.Text;
                    string PrenumeCadru = bunifuMaterialTextbox2.Text;
                    string CNPCadru = bunifuMaterialTextbox3.Text;
                    using (var catalog = new CatalogEntities1())
                    {
                        var Cadre = from c in catalog.Cadrus
                                    where c.CNP.Equals(CNPCadru)
                                    select c;
                        if (Cadre.Count() == 0)
                        { //adica nu mai exista
                            bool SefDepartament = false;
                            bool Decan = false;
                            if (bunifuCheckbox1.Checked == true)
                                SefDepartament = true;
                            if (bunifuCheckbox2.Checked == true)
                                Decan = true;

                            //parola random
                            string new_pass = Form1.gui.GenerareParola(3, 3, 4);//3litere mici, 3litere mari, 4cifre
                                                                                //salvam in fisier
                            this.AddtoFile(NumeCadru, PrenumeCadru, CNPCadru, new_pass);

                            //criptam parola
                            string new_pass_encrypted = Form1.gui.Criptare_string(new_pass);


                            using (var dbCatalogTransaction = catalog.Database.BeginTransaction())
                            {

                                //adaugam in baza de date 
                                try
                                {
                                    Cadru newCadru = new Cadru
                                    {
                                        Nume = NumeCadru,
                                        Prenume = PrenumeCadru,
                                        CNP = CNPCadru,
                                        SefDepartament = SefDepartament,
                                        Decan = Decan,
                                        Password = new_pass_encrypted//o adaugam pe cea criptata 
                                    };

                                    catalog.Cadrus.Add(newCadru);
                                    catalog.SaveChanges();
                                    dbCatalogTransaction.Commit();


                                    //adaugam in gridview
                                    AddProfesorDataGrid(NumeCadru, PrenumeCadru);
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
                        else
                        {
                            bunifuMaterialTextbox1.Text = "Cadrul Exista!";
                            bunifuMaterialTextbox2.Text = "";
                            bunifuMaterialTextbox3.Text = "";
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

        //pentru nouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void Admin_AdaugaCadru_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void Admin_AdaugaCadru_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Admin_AdaugaCadru_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }
    }
}