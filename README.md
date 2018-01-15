# Proiect_Catalog_Studentesc




# 1. Descrierea Aplicatiei
  - Proiectul a are ca scop crearea unei aplicatii user-friendly ce permite stocarea si vizulaizarea notelor dar si a altor statistici in cadrul unei universitati folosindu-se de o baza de date.
  - Aplicatia functioneaza diferit pentru tipul utilizatorului ce se logheza. Astfel au fost concepute trei cazuri de functionare a aplicatiei in functie de selectia utilizatorului care se poate loga ca student, cadru al universitatii sau admin pentru o facutate.
  - Un student sau un cadru are drepturi de read asupra datelor ce il vizeaza in timp ce un admin poate introduce date noi in baza de date.

# 2. Posibile Metode de Utilizare
  - Aplicatia poate fii folosita de o universitate cu diferite facultati, diferite departamente si diferite specializari stocand datele depre grupe, materii, note, studenti diferentiat in functie de anul universitar si anul de facultate al unui student.
  1) Un student se poate loga in aplicatie pe baza CNP-uli sau si a parolei furnizata de catre administratorul din aplicatie. Dupa ce studentul s-a logat acesta poate sa isi selecteze anulul universitar si sesiunea pentru care doreste sa isi vada datele.
    Pentru un anul si o sesiunea(semestrul) selectat acesta poate vizulaiza materiile cu urmatoarele date aferente materiei:
    -numele profesorilor si asistentilor
    -raportul de puncte si notele pentru curs, laborator, proiect/teme
    -nota finala
    -numarul de credite
    -etc
  2) Un cadru se autentifica identic si poate selecta an-ul scolar si una din grupele la care preda urmand a i se afisa toate materiile pe care le preda acelei grupe dar si notele studentiilor.
     In cazul in care acel cadru este sef de departament poate vizulaiza diferite statistici in cadrul departamentului sau.
     In cazul in care acel cadru este decan poate selecta unul din departamnetele existente si vizualiza acelasi statistici ca seful de departament.
  3) Adminul din aplicatie este unul din cadre si posibilitatea de a adauga:
     -Departamente
     -Specializari
     -Grupe
     -Materii
     -Note
     -Studenti
     -Cadre
     -Ani universitari
     -etc
    
# 3. Descrierea Bazei de Date
  - Aplicatia fososeste o baza de date SQL Server numita "Catalog" si contine urmatoarele tabele:
    1) Cadre cu urmatoarele date: CadreID, Nume, Prenume, Cnp , Parola si flaguri in cazul in care cadrul este decan sau sau sef de departament.
    2) Facultate cu urmatoarele date: FacultateID, Nume, ID-urile decanului si administratorilor ( FKs in Cadre )
    3) Departament cu urmatoarele date: DepartamentID, Nume, ID-ul facultatii ( FK in Facultate)
    4) Specializare cu urmatoarele date: SpecializareID, Nume, ID-ul departamnetului ( FK in Departamnet )
    5) AnScolar cu urmatoarele date: AnScolarID, Anul de inceput, Anul de sfarsit ( ex: 2015-2016, 2016-2017, 2017-2018, samd)
    6) Student cu urmatoarele date: StudentID, Nume, Prenume , Cnp, numar de restante si medii pentru fiecare an, SpecizareID si AnScolarID in care a inceput facultatea (FKs in tabelele Specializare si AnScolar )
    7) Grupa cu urmatoarele date: GrupaID, Nume, An( 1,2,3 sau 4) , AnScolarID( FK in AnScoalr) si SpecizareID( FK in Specialiare)
    8) StudentiGrupa *TABELA MANY-TO-MANY CU ID-URILE STUDENTIILOR SI GRUPELOR DEOARECE UN STUDENT POATE APARTINE MAI MULTOR GRUPE CE SUNT DIFERENTIATE PE ANI UNIVERSITARI SI ANI DE FACULTATE IN TIMP CE UN STUDENT ARE DOAR ANUL UNIVERSITAR IN CARE A INCEPUT FAULTATEA*
    9) Materie cu urmatoarele date: MaterieID, Nume, GrupaID (FK in Grupa), 2 profesori si 2 asistenti ( FK in Cadre), procente pentu curs, laborator si proiect, flag examen/colocviu, Credite, Sesiune (semestru) *O materie apartine unei grupe deoarece profesorii pot diferentia de la o grupa la alta si pot avea numar de credite diferit in functie de specializare*
    10) Note cu urmatoarele date: NotaID, StudentID (FK in Student), NotaCurs, NotaLaborator, NotaProiect, NotaFinala, Sesiune, AnScolaID (FK in AnScolar).
  
  
# 4. Tehnologii Folosite
  - .NET Framework: Entity Framework 6.0 
  - SQL SERVER
  - Third Party Libraries
    1) Libraria iTextSharp
    2) Libraria Microsoft.Office.Interop
    3) Libraria Bunifu_UI_v1.5.3  *pentru interfata grafica*
  - *Aplicatia e scrisa in c#, baza de date contine proceduri stocate in T-SQL*
  
  
  
  
# 5. Features
  - Studentul poate exporta notele de pe un semestru in format xlsx, pdf sau csv.
  - Aplicatia este conceputa sa functioneze in diferite tipuri de retele: LAN, MAN, INTRAMAN, WAN; in functie de cerintele si nevoile univesitatii.
  
  
# 6. Securitatea Datelor
  - Aferent executabilului, in fisierul de configurare al aplicatiei, modul de logare default la baza de date este prin credidentialele Windows ale pc-ului astfel incat studentul poate accesa baza de date doar din interiorul institutiei, dupa ce administratorul bazei de date adauga un user nou.
  - Parolele de autentificare ale user-ilor sunt criptate cu SHA256, inainte de a fi stocate in baza de date. In momentul adaugarii unui user, este generata automat o parola random, salvata local intr-un fisier local pe pc-ul adminului care l-a adaugat urmand a-i comunica parola in clar.
 - Securitatea bazei de date este asigurata de tehnologia Microsoft.
 - Logarea in aplicatie nu poate fii exploatata prin SQL Injection.
  
  
  
