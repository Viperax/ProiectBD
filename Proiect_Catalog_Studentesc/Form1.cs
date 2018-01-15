using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_Catalog_Studentesc
{

    public partial class Form1 : Form
    {
        public static Form1 gui;//pentru a putea accesa totul global

        public Form1()
        {
            InitializeComponent();
            gui = this;//facem un handle catre Form
            student_Log1.BringToFront();

        }

        public void Bring_Main_Buttons()
        {
            main_Buttons1.BringToFront();
        }

        public void Bring_StudentLogPage(){
            student_Log1.BringToFront();
            student_Log1.ResetStudent();
        }
        public void Bring_CadruLogPage()
        {
            cadru_Log1.BringToFront();
            cadru_Log1.ResetCadru();
        }
        public void Bring_AdminLogPage()
        {
            admin_Log1.BringToFront();
            admin_Log1.ResetAdmin();
        }
        public void Bring_InformationPage(string text_info)
        {
            information1.BringToFront();
            information1.change_information(text_info);
        }
         
        public void Bring_FirstPageStudent()
        {
            mainPageStudent1.BringToFront();
        }

        public void Bring_CadruAfisareMaterii()
        {
            cadru_AfisareMaterii1.BringToFront();
        }

        public void Bring_Student_Afisare_Materii()
        {
            student_Afisare_Materii1.BringToFront();
        }
        public void Bring_FirstPageCadru()
        {
            firstPageCadru1.BringToFront();
            firstPageCadru1.resetDropDownColor();//resetam culoarea pentru DropDown in caz ca a fost gresita 
        }

        public void Bring_CadruAfisareStudentiNote()
        {
            cadru_AfisareStudentiNote1.BringToFront();
        }

        public void Bring_FirstPageAdmin()
        {
            firstPageAdmin1.BringToFront();
           
        }

        public void Bring_AdminAdaugaAnScolarFirstPage()
        {
            admin_AdaugaAnScolarFirstPage1.BringToFront();
            admin_AdaugaAnScolarFirstPage1.ResetAdaugaAnScolarText();
        }

        public void Bring_AdminAdaugaDepartament()
        {
            admin_AdaugareDepartament1.BringToFront();
            admin_AdaugareDepartament1.ResetTextDepartament();
        }

        public void Bring_AdminAdaugareSpecializare()
        {
            admin_AdaugaSpecializare1.BringToFront();
            admin_AdaugaSpecializare1.ResetText_Grid();
        }

        public void Bring_AdminAdaugaGrupa()
        {
            admin_AdaugareGrupa1.BringToFront();
            admin_AdaugareGrupa1.ResetAllTools();
        }
        public void Bring_AdminAdaugareMaterie()
        {
            admin_AdaugareMaterie1.ResetAllTools();
            admin_AdaugareMaterie1.BringToFront();
        }

        public void Bring_AdminAdaugareStudent()
        {
            admin_AdaugaStudent1.ResetToolsAddStudent();
            admin_AdaugaStudent1.BringToFront();
        }

        public void Bring_AdminAdaugareStudentiGrupa()
        {
            admin_AdaugaStudentiGrupa1.ResetAllTools();
            admin_AdaugaStudentiGrupa1.BringToFront();
            
        }

        public void Bring_AdminAdaugaNote()
        {
            admin_AdaugaNota1.ResetAllTools();
            admin_AdaugaNota1.BringToFront();
        }

        public void Bring_AdminAdaugaCadru()
        {
            admin_AdaugaCadru1.ResetAllTools();
            admin_AdaugaCadru1.BringToFront();
        }

        public void Bring_StudentExport()
        {
            student_Export1.BringToFront(); 
        }

        public void Bring_CadruViewSpecializari_Decan()
        {
            cadru_ViewSpecializari_Decan1.BringButtons();
            cadru_ViewSpecializari_Decan1.BringToFront();
        }

        public void AddStudentNote_Cadru(string studentName,string studentPrenume,int studentId,int idMaterieSelectata)
        {
            cadru_AfisareStudentiNote1.addStudentiNote(studentName,studentPrenume,studentId,idMaterieSelectata);
        }
        
        public void Bring_CadruFirstPageStatistici()
        {
            cadru_FirstPageStatistici1.BringToFront();
        }
        public void Bring_CadruAfisareStatistici()
        {
            cadru_AfisareStatistici1.BringAllFront();
            cadru_AfisareStatistici1.BringToFront();
        }

        public void SetAnStudent(int anStudent,int anInceputStudent)
        {
            mainPageStudent1.SetAnStudent(anStudent, anInceputStudent);
            mainPageStudent1.Initializare_Ani();
        }

        public void SetIndexStudent(int IndexStudentFunction)
        {
            mainPageStudent1.SetIndexStudent(IndexStudentFunction);
        }

        public void SetIdFacultate_AdminAddMaterie(int IdFacultate)
        {
            admin_AdaugareMaterie1.SetIdFacultate_AddMaterie(IdFacultate);
        }

        public void SetIndexCadru(int IndexCadruFunction)
        {
            firstPageCadru1.SetIndexCadru(IndexCadruFunction);
        }

        public void AddMaterie_Student(string numeMaterie, string prof1, string prof2, string asistent1, string asistent2, string procentCurs, string procentLab, string procentTeme, string procentProiect, string Examen, string credite,string notaCurs,string notaLaborator,string notaProiect,string notaFinala)
        {
            student_Afisare_Materii1.add_materie(numeMaterie, prof1, prof2, asistent1, asistent2, procentCurs, procentLab, procentTeme, procentProiect, Examen, credite,notaCurs,notaLaborator,notaProiect,notaFinala);
        }

        public void AddMaterii_Cadru(int idMaterie,string numeMaterie, string ProcentCurs, string ProcentLaborator, string ProcentTeme, string ProcentProiect, bool Examen, string Credite, string Sesiune)
        {
            cadru_AfisareMaterii1.add_materieProfesor(idMaterie,numeMaterie, ProcentCurs, ProcentLaborator, ProcentTeme, ProcentProiect, Examen, Credite, Sesiune);
        }

        public void Reset_StudentMateriiView()
        {
            student_Afisare_Materii1.Reset_MateriiView();
        }
        public void Reset_StudentLogPage()
        {
            student_Log1.ResetStudent();
        }

        public void Reset_CadruLogPage()
        {
            cadru_Log1.ResetCadru();
        }

        public void FirstPageStudentResetDropDownColors()
        {
            mainPageStudent1.ResetDropDownColors();
        }
        public void setIdGrupaSelectata(int idGrupa)
        {
            cadru_AfisareMaterii1.setIdGrupaSelectata(idGrupa);
        }

        public void ResetGridViewMaterii_Cadru()
        {
            cadru_AfisareMaterii1.ResetGridViewMaterii();
        }

        public void AdaugareAnScolar_Admin(int an1,int an2)
        {
            admin_AdaugaAnScolarFirstPage1.AdaugareAnScolar(an1, an2);
        }

        public void SetIdAdmin(int idAdmin,int idFacultate)
        {
            firstPageAdmin1.SetIdAdmin(idAdmin, idFacultate);
        }

        public void AdminAddDepartament(string numeDepartament)
        {
            admin_AdaugareDepartament1.AdminAddDepartament(numeDepartament);
        }

        public void SetFacultateId_AdDepartament(int IdFacultate)
        {
            admin_AdaugareDepartament1.SetareFacultateId(IdFacultate);
        }

        public void AdaugareSpecializare_Admin(string NumeSpecializare)
        {
            admin_AdaugaSpecializare1.AdaugareSpecializari(NumeSpecializare);
        }


        public void AdaugareDepartament_DropDown(string NumeDepartament,int IdDepartament)
        {
            admin_AdaugaSpecializare1.AdaugareDepartament_DropDown(NumeDepartament, IdDepartament);
        }

        public void SetFacultateID_AdminAddGrupa(int facultateID)
        {
            admin_AdaugareGrupa1.setFacultateId_AdminAddGrupa(facultateID);
        }

        public void SetFacutalteID_AdminAdaugaStudentiGrupa(int IDFacultate)
        {
            admin_AdaugaStudentiGrupa1.setIdFacultate(IDFacultate);
        }

        public string GenerareParola(int nr_mici, int nr_mari, int nr_cifre)
        {
            string mici = "abcdefghijklmnopqrstuvwxyz";
            string mari = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string cifre = "0123456789";
            Random random = new Random();
            string generated = "!";//pentru a putea insera 
            for (int i = 1; i <= nr_mici; i++)
                generated = generated.Insert(random.Next(generated.Length), mici[random.Next(mici.Length - 1)].ToString());//randon.next ->numere pozitive din intervalul
            for (int i = 1; i <= nr_mari; i++)
                generated = generated.Insert(random.Next(generated.Length), mari[random.Next(mari.Length - 1)].ToString());
            for (int i = 1; i <= nr_cifre; i++)
                generated = generated.Insert(random.Next(generated.Length), cifre[random.Next(cifre.Length - 1)].ToString());
            return generated.Replace("!", string.Empty);
        }


        public string Criptare_string(string old_pass)
        {
            //cryptam parola
            System.Security.Cryptography.SHA256 sha256 = new System.Security.Cryptography.SHA256Managed();
            byte[] sha256Bytes = System.Text.Encoding.Default.GetBytes(old_pass);
            byte[] cryString = sha256.ComputeHash(sha256Bytes);
            string sha256Str = string.Empty;
            Console.WriteLine("Lungime" + cryString.Length);
            for (int i = 0; i < cryString.Length; i++)
            {
                sha256Str += cryString[i].ToString("X");
            }
            return sha256Str;
        }

        public void SetParametersExport(int StudentID, int GrupaID, int Semestru)
        {
            student_Export1.SetParameters(StudentID, GrupaID, Semestru);
        }
        //pentru decan sa fie diferite butoanele 
        public void VerificaDecan_Cadre()
        {
            firstPageCadru1.VerificareDecan_Cadre();
        }

        public void SetDecan_Cadre(int idDecan)
        {
            firstPageCadru1.SetDecan_Cadre(idDecan);
        }

        public void SetSefDepartament_Cadre(int idSefDepartament)
        {
            firstPageCadru1.SetSefDepartament_Cadre(idSefDepartament);
        }

        public void CadruViewSpecializari_ResetTools()
        {
            cadru_ViewSpecializari_Decan1.ResetDataGrid_Specializari();
        }

        public void CadruViewSpecializari_addSpecializareDataGrid(string NumeSpecializare)
        {
            cadru_ViewSpecializari_Decan1.AddSpecializareDataGrid(NumeSpecializare);
        }

        public void Cadru_FirstPageStatistici_ResetTools()
        {
            cadru_FirstPageStatistici1.ResetTools();
        }

        public void Cadru_firstPageStatistici_AddDepartamentAutoSelect(string numeDepartament,int IdDepartament)
        {
            cadru_FirstPageStatistici1.AdaugaAutoSaveDepartamentDropDown(numeDepartament, IdDepartament);
        }

        public void Cadru_firstPageStatistici_AddDepartament(string numeDepartament,int IdDepartament,int sem)
        {
            cadru_FirstPageStatistici1.AdaugaDepartamentDropDown_Initializare(numeDepartament, IdDepartament,sem);
        }

        public void Cadru_FirstPageStatistici_AddAni()
        {
            cadru_FirstPageStatistici1.AdaugareAniDropDown();
        }

        public void Cadru_AfisareStatistici_AdaugaDataGrid(string Specializare, int Studenti, int Integralisti, int Restantieri, int R1, int R2, int R3, int Promovabilitate)
        {
            cadru_AfisareStatistici1.AdaugaDataGrid(Specializare, Studenti, Integralisti, Restantieri, R1, R2, R3, Promovabilitate);
        }
        /////////////////////////////////////////////////////////////////////


       public void Cadru_AfisareStatistici_SetStatistics(int NrTotal,int promovabilitate,int integralisti,int restantieri,int R1,int R2, int R3)
        {
            cadru_AfisareStatistici1.SetStatistics(NrTotal, promovabilitate, integralisti, restantieri, R1, R2, R3);
        }

        private void main_Buttons1_Load(object sender, EventArgs e)
        {
            
        }


        private void student_Log1_Load(object sender, EventArgs e)
        {

        }

        private void mainPageStudent1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void student_Afisare_Materii1_Load(object sender, EventArgs e)
        {

        }

        private void student_Afisare_Materii1_Load_1(object sender, EventArgs e)
        {

        }

        private void cadru_AfisareMaterii1_Load(object sender, EventArgs e)
        {

        }

        private void cadru_AfisareStudentiNote1_Load(object sender, EventArgs e)
        {

        }

        private void admin_AdaugareDepartament1_Load(object sender, EventArgs e)
        {

        }

        private void admin_AdaugaSpecializare1_Load(object sender, EventArgs e)
        {

        }

        private void admin_AdaugaStudent1_Load(object sender, EventArgs e)
        {

        }

        private void admin_AdaugaStudentiGrupa1_Load(object sender, EventArgs e)
        {

        }


        //pentru mouse

        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 700;
                mouseY = MousePosition.Y - 300;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        public void SetMouse(int mouseX,int mouseY){
            this.SetDesktopLocation(mouseX, mouseY);
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }


        

        //
    }
}
