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
    public partial class firstPageAdmin : UserControl
    {
        int IdAdmin;//id-ul adminului care s-a logat
        int IdFacultate;//facultatea de care apartine adminul

      
        public firstPageAdmin()
        {
            InitializeComponent();
        }

        private void firstPageAdmin_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_anScolar_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.gui.Bring_AdminAdaugaAnScolarFirstPage();
                //aici adaugam toti anii existenti in tabela si mai adaugam si atunci cand adauga 
                var catalog = new CatalogEntities1();
                var aniScolari = from c in catalog.AnScolars
                                 select c;
                foreach (var an in aniScolari)
                {
                    Form1.gui.AdaugareAnScolar_Admin(an.AnPrimar, an.AnSecundar);
                }
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            LogOut newForm = new LogOut();
            newForm.ShowDialog();
        }

        private void bunifuFlatButton2_AddDepartament_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.gui.Bring_AdminAdaugaDepartament();
                Form1.gui.SetFacultateId_AdDepartament(IdFacultate);

                var catalog = new CatalogEntities1();
                var departament = from c in catalog.Departamnets
                                  select c;
                foreach (var dep in departament)
                {
                    Form1.gui.AdminAddDepartament(dep.Nume);
                }
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }

        public void SetIdAdmin(int newIdAdmin, int newIdFacultate)
        {
            this.IdAdmin = newIdAdmin;
            this.IdFacultate = newIdFacultate;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Form1.gui.Bring_AdminAdaugareSpecializare();

                var catalog = new CatalogEntities1();
                var departament = from c in catalog.Departamnets//luam toate departamentele din aceasta facultate 
                                  where c.FacultateID == IdFacultate
                                  select c;
                foreach (var dep in departament)
                {
                    Form1.gui.AdaugareDepartament_DropDown(dep.Nume, dep.DepartamentID);
                }
            }
            catch (Exception ex)
            {
                FormError newForm = new FormError();
                newForm.SetText(ex.ToString());
                newForm.ShowDialog();
            }
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            Form1.gui.SetFacultateID_AdminAddGrupa(this.IdFacultate);
            Form1.gui.Bring_AdminAdaugaGrupa();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            
            Form1.gui.SetIdFacultate_AdminAddMaterie(this.IdFacultate);
            Form1.gui.Bring_AdminAdaugareMaterie();

        }

        private void bunifuFlatButton6_Click(object sender, EventArgs e)
        {
            Form1.gui.Bring_AdminAdaugareStudent();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            //setam id facultate deoarece avem nevoie de afisarea departamentelor pe baza id facultate
            Form1.gui.SetFacutalteID_AdminAdaugaStudentiGrupa(this.IdFacultate);
            Form1.gui.Bring_AdminAdaugareStudentiGrupa();
        }

        private void bunifuFlatButton7_Click(object sender, EventArgs e)
        {
            Form1.gui.Bring_AdminAdaugaNote();
        }

        private void bunifuFlatButton8_Click(object sender, EventArgs e)
        {
            Form1.gui.Bring_AdminAdaugaCadru();
        }
        //pentru mouse
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        private void firstPageAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void firstPageAdmin_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;
                Form1.gui.SetMouse(mouseX, mouseY);

            }
        }

        private void firstPageAdmin_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
    }
}
