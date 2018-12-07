using PIP.ExportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Data;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.ComponentModel;
using BusinessLogic;

namespace PIP.Controllers
{
    public class DataActionController : Controller, IExportMmethods
    {
        PIP.Data.PIPContext context = new Data.PIPContext();
        public void ExportCSV()
        {
            throw new NotImplementedException();
        }

        public void ExportCSV(HtmlString File)
        {
            throw new NotImplementedException();
        }

        public void ExportExcel()
        {
            throw new NotImplementedException();
        }

        public void ExportPDFFile()
        {
            var contextResult = context.DataSheet.ToList();

            var dataTableResult = GenericLogic.ToDataTable(contextResult);
            ExportPDF(dataTableResult, "test");
        }
       

        /// <summary>
        /// this method was copied
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="fileName"></param>
        //for more reference visit https://www.codeproject.com/Questions/405740/convert-fro-datatble-to-pdf-in-csharp-windows-appl
        public void ExportPDF(DataTable dt, string fileName)
        {
            iTextSharp.text.Document documentToOpen = new iTextSharp.text.Document();
            string rootpath = Server.MapPath("~/");

            PdfWriter writer = PdfWriter.GetInstance(documentToOpen,
                new FileStream(rootpath + fileName + ".pdf", FileMode.Create));

            documentToOpen.Open();
            iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);
            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow row = null;
            //float[] widths = new float[] { 4f, 4f, 4f, 4f };

            //table.SetWidths(/*widths*/);

            table.WidthPercentage = 100;
            int iCol = 0;
            string colname = "";
            PdfPCell cell = new PdfPCell(new Phrase("Products"));
            cell.Colspan = dt.Columns.Count;

            foreach (DataColumn c in dt.Columns)
            {

                table.AddCell(new Phrase(c.ColumnName, font5));
            }

            var columnsCount = dt.Columns.Count;

            foreach (DataRow r in dt.Rows)
            {
                if (dt.Rows.Count > 0)
                {

                    table.AddCell(new Phrase(r[0].ToString(), font5));
                    table.AddCell(new Phrase(r[1].ToString(), font5));
                    table.AddCell(new Phrase(r[2].ToString(), font5));
                    table.AddCell(new Phrase(r[3].ToString(), font5));
                }
            }
            ///revisar, solo las columnas estan siendo desplegadas
            /// los rows no estan siendo desplegados.
            documentToOpen.Add(table);
            documentToOpen.Close();

        }

        public void ExportPNG()
        {
            throw new NotImplementedException();
        }

        public void ExportSGV()
        {
            throw new NotImplementedException();
        }
    }
}