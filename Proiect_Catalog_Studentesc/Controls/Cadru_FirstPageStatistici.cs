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
    public partial class Cadru_FirstPageStatistici : UserControl
    {
        public Cadru_FirstPageStatistici()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Form1.gui.VerificaDecan_Cadre();
            Form1.gui.Bring_FirstPageCadru();
        }


        bool Decan;//false daca nu e decan si true daca e -->daca e decan luam din lista 
        int IdDepartamentSelectat;
        public void AdaugaAutoSaveDepartamentDropDown(string DepartamentNume, int idDepartament)
        {
            this.Decan = false;
            bunifuDropdown1.AddItem(DepartamentNume);//selecteaza automat departamentul in care e 
            IdDepartamentSelectat = idDepartament;
            bunifuDropdown1.selectedIndex = 0;
        }

        List<int> IdDepartamenteDropDown;
        public void AdaugaDepartamentDropDown(string DepartamentNume,int idDepartament)
        {
            this.Decan = true;
            bunifuDropdown1.AddItem(DepartamentNume);
            IdDepartamenteDropDown.Add(idDepartament);
        }
        public void AdaugaDepartamentDropDown_Initializare(string DepartamentNume,int idDepartament,int sem)
        {
            if(sem==0)
                this.IdDepartamenteDropDown = new List<int>();
            this.AdaugaDepartamentDropDown(DepartamentNume, idDepartament);
        }


        public void ResetTools()
        {
            bunifuDropdown1.Clear();
            bunifuDropdown2.Clear();
            bunifuDropdown3.Clear();
        }

        string[] Ani = { "I", "II", "III", "IV" };//dropdown[0]==1 -->index+1

        List<int> IDAniScolari;
        public void AdaugareAniDropDown()
        {
            try
            {
                bunifuDropdown2.Clear();
                IDAniScolari = new List<int>();
                var catalog = new CatalogEntities1();
                var aniScolari = from a in catalog.AnScolars
                                 select a;
                foreach (var a in aniScolari)
                {
                    bunifuDropdown2.AddItem(a.AnPrimar + "-" + a.AnSecundar);
                    IDAniScolari.Add(a.AnScolarID);
                }

                //adauga ani I II III IV 
                bunifuDropdown3.Clear();
                for (int i = 0; i < 4; i++)
                    bunifuDropdown3.AddItem(Ani[i]);
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }

        private void Cadru_FirstPageStatistici_Load(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {

        }

        int AnSelectat;
        int idAniScolari_Selectat;
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (bunifuDropdown1.selectedIndex != -1 && bunifuDropdown2.selectedIndex != -1 && bunifuDropdown3.selectedIndex != -1)
            {
                try
                {
                    if (Decan == true)
                        this.IdDepartamentSelectat = IdDepartamenteDropDown.ElementAt(bunifuDropdown1.selectedIndex);
                    this.idAniScolari_Selectat = IDAniScolari.ElementAt(bunifuDropdown2.selectedIndex);
                    this.AnSelectat = (bunifuDropdown3.selectedIndex) + 1;

                    //luem fiecare specializare din departamentul selectat
                    //dam clear la chestiile de pe noua pagina 
                    var catalog = new CatalogEntities1();
                    var specializare = from s in catalog.Specializares
                                       where s.DepartamentID == IdDepartamentSelectat
                                       select s;

                    int nrStudenti = 0;
                    int Integralisti = 0;
                    int nrTotalStudenti = 0;
                    int nrTotalIntegralisti = 0;
                    int nrTotalRestantieri = 0;
                    int nrTotalR1 = 0;
                    int nrTotalR2 = 0;
                    int nrTotalR3 = 0;
                    foreach (var s in specializare)
                    {

                        //ne intrebam ce an e si apelam fix pentru anul care trebuie 
                        if (AnSelectat == 1)
                        {
                            var statistici = catalog.usp_statistica_an1(IdDepartamentSelectat, s.SpecializareID, idAniScolari_Selectat);
                            foreach (var item in statistici.ToList())
                            {
                                nrStudenti = (int)item.NR_STUDENTI;
                                Integralisti = (int)item.NR_STUDENTI_INTEGRALISTI;
                                if (Integralisti == 0)//asta asa ca nu avem adaugat in baza de date 
                                    Integralisti = 1;
                                if (nrStudenti == 0)
                                    nrStudenti = 1;
                                Form1.gui.Cadru_AfisareStatistici_AdaugaDataGrid(s.Nume, nrStudenti, Integralisti, nrStudenti - Integralisti, (int)item.NR_STUDENTI_R1, (int)item.NR_STUDENTI_R2, (int)item.NR_STUDENTI_R3, (int)(Integralisti * 100 / nrStudenti));
                                nrTotalStudenti += nrStudenti;
                                nrTotalIntegralisti += Integralisti;
                                nrTotalRestantieri += (nrStudenti - Integralisti);
                                nrTotalR1 += (int)item.NR_STUDENTI_R1;
                                nrTotalR2 += (int)item.NR_STUDENTI_R2;
                                nrTotalR3 += (int)item.NR_STUDENTI_R3;
                            }
                        }
                        else if (AnSelectat == 2)
                        {
                            var statistici = catalog.usp_statistica_an2(IdDepartamentSelectat, s.SpecializareID, idAniScolari_Selectat);
                            foreach (var item in statistici.ToList())
                            {
                                nrStudenti = (int)item.NR_STUDENTI;
                                Integralisti = (int)item.NR_STUDENTI_INTEGRALISTI;
                                if (Integralisti == 0)
                                    Integralisti = 1;
                                if (nrStudenti == 0)
                                    nrStudenti = 1;
                                Form1.gui.Cadru_AfisareStatistici_AdaugaDataGrid(s.Nume, nrStudenti, Integralisti, nrStudenti - Integralisti, (int)item.NR_STUDENTI_R1, (int)item.NR_STUDENTI_R2, (int)item.NR_STUDENTI_R3, (int)(Integralisti *100/ nrStudenti)) ;
                                nrTotalStudenti += nrStudenti;
                                nrTotalIntegralisti += Integralisti;
                                nrTotalRestantieri += (nrStudenti - Integralisti);
                                nrTotalR1 += (int)item.NR_STUDENTI_R1;
                                nrTotalR2 += (int)item.NR_STUDENTI_R2;
                                nrTotalR3 += (int)item.NR_STUDENTI_R3;
                            }
                        }
                        else if (AnSelectat == 3)
                        {
                            var statistici = catalog.usp_statistica_an3(IdDepartamentSelectat, s.SpecializareID, idAniScolari_Selectat);
                            foreach (var item in statistici.ToList())
                            {
                                nrStudenti = (int)item.NR_STUDENTI;
                                Integralisti = (int)item.NR_STUDENTI_INTEGRALISTI;
                                if (Integralisti == 0)
                                    Integralisti = 1;
                                if (nrStudenti == 0)
                                    nrStudenti = 1;
                                Form1.gui.Cadru_AfisareStatistici_AdaugaDataGrid(s.Nume, nrStudenti, Integralisti, nrStudenti - Integralisti, (int)item.NR_STUDENTI_R1, (int)item.NR_STUDENTI_R2, (int)item.NR_STUDENTI_R3, (int)(Integralisti * 100 / nrStudenti));
                                nrTotalStudenti += nrStudenti;
                                nrTotalIntegralisti += Integralisti;
                                nrTotalRestantieri += (nrStudenti - Integralisti);
                                nrTotalR1 += (int)item.NR_STUDENTI_R1;
                                nrTotalR2 += (int)item.NR_STUDENTI_R2;
                                nrTotalR3 += (int)item.NR_STUDENTI_R3;
                            }
                        }
                        else if (AnSelectat == 4)
                        {
                            var statistici = catalog.usp_statistica_an4(IdDepartamentSelectat, s.SpecializareID, idAniScolari_Selectat);
                            foreach (var item in statistici.ToList())
                            {
                                nrStudenti = (int)item.NR_STUDENTI;
                                Integralisti = (int)item.NR_STUDENTI_INTEGRALISTI;
                                if (Integralisti == 0)
                                    Integralisti = 1;
                                if (nrStudenti == 0)
                                    nrStudenti = 1;
                                Form1.gui.Cadru_AfisareStatistici_AdaugaDataGrid(s.Nume, nrStudenti, Integralisti, nrStudenti - Integralisti, (int)item.NR_STUDENTI_R1, (int)item.NR_STUDENTI_R2, (int)item.NR_STUDENTI_R3, (int)(Integralisti * 100 / nrStudenti));
                                nrTotalStudenti += nrStudenti;
                                nrTotalIntegralisti += Integralisti;
                                nrTotalRestantieri += (nrStudenti - Integralisti);
                                nrTotalR1 += (int)item.NR_STUDENTI_R1;
                                nrTotalR2 += (int)item.NR_STUDENTI_R2;
                                nrTotalR3 += (int)item.NR_STUDENTI_R3;
                            }
                        }
                    }
                    int promovabilitate = (int)(nrTotalIntegralisti * 100 / nrTotalStudenti);
                    Form1.gui.Cadru_AfisareStatistici_SetStatistics(nrTotalStudenti, promovabilitate, nrTotalIntegralisti, nrTotalStudenti - nrTotalIntegralisti, nrTotalR1, nrTotalR2, nrTotalR3);
                    Form1.gui.Bring_CadruAfisareStatistici();
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.ToString());
                    FormError newForm = new FormError();
                    newForm.SetText(ex.ToString());
                    newForm.ShowDialog();
                }
            }
        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {

        }
        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void Cadru_FirstPageStatistici_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void Cadru_FirstPageStatistici_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void Cadru_FirstPageStatistici_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
