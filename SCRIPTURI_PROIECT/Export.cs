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

namespace ExportNou
{
    class Export
    {
        public static void Pdf(int StudentID, int GrupaID, int Semestru, string FileName)
        {

            //Creating iTextSharp Table from the DataTable data
           
            using (var context = new CatalogEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        

                        var tabel=context.usp_catalog_sesiunea_x( StudentID, GrupaID, Semestru);
                       // var tabel  = from a in context.CATALOG_CU_NOTE_TEMPORAR
                        //             select a;

                       // context.CATALOG_CU_NOTE_TEMPORAR.ToString();




                        // Console.Out.WriteLine(query.Count);
                        //Console.Out.WriteLine(query[0].NumeMaterie.ToString());



                        //PdfPTable pdfTable = new PdfPTable(query.Count);//nr of collumns
                        //pdfTable.DefaultCell.Padding = 3;
                        //pdfTable.WidthPercentage = 30;
                        //pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                        //pdfTable.DefaultCell.BorderWidth = 1;


                        //for ( int i=0; i< query.Count; i++)
                        //{
                        //    PdfPCell cell = new PdfPCell(new Phrase(query.ElementAt(i).));
                        //    pdfTable.AddCell(cell);
                        //}



                        //foreach (var post in query)
                        //{

                        //}

                        context.SaveChanges();

                        dbContextTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }






    }
}
