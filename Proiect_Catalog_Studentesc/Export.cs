using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.SqlClient;
using System.Data.Entity.Core.EntityClient;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace Proiect_Catalog_Studentesc
{
    class Export
    {
        
        public static void Pdf(int StudentID, int GrupaID, int Semestru, string FileName)
        {
            using (var context = new CatalogEntities1())
            {
                try
                {
                    var tabel = context.usp_catalog_sesiunea_x(StudentID, GrupaID, Semestru).ToList();
                    string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                    Document document = new Document();
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path+ "\\" + FileName+" Semestrul "+Semestru.ToString()+".pdf", FileMode.Create));
                    document.Open();
                    iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);

                    PdfPTable table = new PdfPTable(6);
                    PdfPRow row = null;
                    float[] widths = new float[] { 4f, 4f, 4f, 4f, 4f, 4f };

                    table.SetWidths(widths);

                    table.WidthPercentage = 100;
                    int iCol = 0;
                    string colname = "";
                    PdfPCell cell = new PdfPCell(new Phrase("Note pe semestrul"+Semestru.ToString()));

                    cell.Colspan = 6;

                    table.AddCell(new Phrase("Disciplina", font5));
                    table.AddCell(new Phrase("NotaCurs", font5));
                    table.AddCell(new Phrase("NotaLaborator", font5));
                    table.AddCell(new Phrase("NotaProiect", font5));
                    table.AddCell(new Phrase("NotaFinala", font5));
                    table.AddCell(new Phrase("Credite", font5));
                   

                    for(int i=0;i<tabel.Count;i++)
                    {
                        table.AddCell(new Phrase(tabel[i].NumeMaterie.ToString(), font5));
                        table.AddCell(new Phrase(tabel[i].NotaCurs.ToString(), font5));
                        table.AddCell(new Phrase(tabel[i].NotaFinala.ToString(), font5));
                        table.AddCell(new Phrase(tabel[i].NotaProiect.ToString(), font5));
                        table.AddCell(new Phrase(tabel[i].NotaFinala.ToString(), font5));
                        table.AddCell(new Phrase(tabel[i].Credite.ToString(), font5));
                    }

                    document.Add(table);
                    document.Close();

                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.ToString());

                }

            }
        }


        public static void Excel(int StudentID, int GrupaID, int Semestru, string FileName)
        {
            using (var context = new CatalogEntities1())
            {
                try
                {
                    var tabel = context.usp_catalog_sesiunea_x(StudentID, GrupaID, Semestru).ToList();
                   

                    // load excel, and create a new workbook
                    var excelApp = new Excel.Application();
                    excelApp.Workbooks.Add();

                    // single worksheet
                    Excel._Worksheet workSheet = excelApp.ActiveSheet;

                    // column headings
                    workSheet.Cells[1, 1]="Disciplina";
                    workSheet.Cells[1, 2] = "NotaCurs";
                    workSheet.Cells[1, 3] = "NotaLaborator";
                    workSheet.Cells[1, 4] = "NotaProiect";
                    workSheet.Cells[1, 5] = "NotaFinala";
                    workSheet.Cells[1, 6] = "Credite";


                    for (int i = 0; i < tabel.Count; i++)
                    {
                        
                            workSheet.Cells[i + 2, 1] = tabel[i].NumeMaterie.ToString();
                            workSheet.Cells[i + 2, 2] = tabel[i].NotaCurs.ToString();
                            workSheet.Cells[i + 2, 3] = tabel[i].NotaLaborator.ToString();
                            workSheet.Cells[i + 2, 4] = tabel[i].NotaProiect.ToString();
                            workSheet.Cells[i + 2, 5] = tabel[i].NotaFinala.ToString();
                            workSheet.Cells[i + 2, 6] = tabel[i].Credite.ToString();
                        

                    }

                    
                  
                    if (!string.IsNullOrEmpty(FileName + " Semestrul " + Semestru.ToString() + ".xlsx"))
                    {
                        try
                        {
                            workSheet.SaveAs(FileName + " Semestrul " + Semestru.ToString() + ".xlsx");
                            excelApp.Quit();
                           
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                                + ex.Message);
                        }
                    }
                    else
                    {
                        excelApp.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("ExportToExcel: \n" + ex.Message);
                }
            }
        }

        
        public static void Csv(int StudentID, int GrupaID, int Semestru, string FileName)
        {
            using (var context = new CatalogEntities1())
            {
                try
                {
                    var tabel = context.usp_catalog_sesiunea_x(StudentID, GrupaID, Semestru).ToList();

                    var csv = new StringBuilder();
                    csv.AppendLine("Disciplina,NotaCurs,NotaLaborator,NotaProiect,NotaFinala,Credite");

                    for (int i = 0; i < tabel.Count; i++)
                    {
                        csv.AppendLine(tabel[i].NumeMaterie.ToString() + "," + tabel[i].NotaCurs.ToString() + "," + tabel[i].NotaLaborator.ToString() + "," + tabel[i].NotaProiect.ToString() + "," + tabel[i].NotaFinala.ToString() + "," + tabel[i].Credite.ToString());
                    }

                    string path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    File.WriteAllText(path + "\\" + FileName + " Semestrul " + Semestru.ToString() + ".csv", csv.ToString());

                }
                catch (Exception ex)
                {
                    throw new Exception("Csv: Csv file could not be saved! Check filepath.\n"+ ex.Message);
                }
                   
            }
        }


    }
}






    
