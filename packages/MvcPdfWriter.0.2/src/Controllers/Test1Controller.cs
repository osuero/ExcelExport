using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MvcPdfWriter;

namespace Mvc4PdfWriter.Demo.Controllers
{   
    [AllowAnonymous]
	public class Test1Controller : Controller
	{

        #region Html to Pdf

        protected ActionResult ViewPdf(string viewName)
        {
            //get html data
            var htmlMarkup = RenderActionResultToString(View(viewName));
            return RenderHtmlToPdf(htmlMarkup);
        }

        protected ActionResult ViewPdf(object model)
        {
            //get html data
            var htmlMarkup = RenderActionResultToString(View(model));
            return RenderHtmlToPdf(htmlMarkup);
        }

        protected ActionResult ViewPdf(string viewName, object model)
        {
            //get html data
            var htmlMarkup = RenderActionResultToString(View(viewName, model));
            return RenderHtmlToPdf(htmlMarkup);
        }

        protected ActionResult RenderHtmlToPdf(string htmlMarkup)
        {
            var htmlPdfWriter = DependencyResolver.Current.GetService<IHtmlToPdfWriter>() ?? new HtmlToPdfWriter();
             
            var memoryStream = htmlPdfWriter.WritePdf(htmlMarkup);

            memoryStream.Position = 0;
            return new FileStreamResult(memoryStream, "application/pdf");
        }

        /// <summary>
        ///render action result as string.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        protected string RenderActionResultToString(ActionResult result)
        {
            // Create memory writer.
            var sb = new StringBuilder();
            var memWriter = new StringWriter(sb);

            // Create fake http context to render the view.
            var fakeResponse = new HttpResponse(memWriter);
            var fakeContext = new HttpContext(System.Web.HttpContext.Current.Request, fakeResponse);
            var fakeControllerContext = new ControllerContext(
                new HttpContextWrapper(fakeContext),
                ControllerContext.RouteData,
                ControllerContext.Controller);

            var oldContext = System.Web.HttpContext.Current;
            System.Web.HttpContext.Current = fakeContext;

            // Render the view.
            result.ExecuteResult(fakeControllerContext);

            // Restore old context.
            System.Web.HttpContext.Current = oldContext;

            // Flush memory and return output.
            memWriter.Flush();
            return sb.ToString();
        }


        protected ActionResult ViewPdf(string templateFilename, IEnumerable<ElementMetadata> metadatas, object model, string outputFilePath)
        {
            var templatePdfWriter = DependencyResolver.Current.GetService<ITemplatePdfWriter>() ??
                                    new TemplatePdfWriter();

            var memoryStream = templatePdfWriter.PrintPdf(templateFilename, metadatas, model, outputFilePath);

            memoryStream.Position = 0;
            return new FileStreamResult(memoryStream, "application/pdf");
        }

        #endregion

        [HttpGet]
        public ActionResult ViewAsPdf(int id)
        {
            var testModel = new
            {
                To = "Abc",
                FAO = " test fao",
                RefDate = DateTime.Now.ToShortDateString(),
                Name = "Abc",
                TradingName = "Xyz",
                Address = "abc road, abc, AB12CD",
                TotalCost = 1000,
                VAT = 200,
                WarrantyExpiryDate = DateTime.Now.AddMonths(48).ToShortDateString()
            };
            return View(testModel);
        }

		[HttpGet]
		public ActionResult ToPdf(int id)
		{
			var testModel = new 
				{
					To = "Abc",
					FAO = " test fao",
					RefDate = DateTime.Now.ToShortDateString(),
					Name = "Abc",
					TradingName = "Xyz",
					Address ="abc road, abc, AB12CD",
					TotalCost = 1000,
					VAT = 200,
                    WarrantyExpiryDate = DateTime.Now.AddMonths(48).ToShortDateString()
				};
			return ViewPdf(testModel);
		}

	    [HttpGet]
	    public ActionResult FromTemplatePdf()
	    {
            var testModel = new 
				{
					To = "Abc",
					FAO = " test fao",
					RefDate = DateTime.Now.ToShortDateString(),
					Name = "Abc",
					TradingName = "Xyz",
					FunderAddress ="abc road, abc, AB12CD",
					TotalCost = 1000,
					VAT = 200,
					CreditExpiryDate = DateTime.Now.AddMonths(1).ToShortDateString()
				};

	        var metadatas = new List<ElementMetadata>
	        {
	            new ElementMetadata()
	            {
	                Name = "RefDate",
	                X = 20,
	                Y = 50,
	                PageNo = 0
	            },
	            new ElementMetadata()
	            {
	                Name = "Name",
	                X = 40,
	                Y = 50,
	                PageNo = 0
	            }
	        };
	        var templatePdfFile = Server.MapPath("~/Templates/pdfTemplate.pdf");
	        var guid = Guid.NewGuid();
	        var outputPdfFile = Server.MapPath("~/OutputFiles/") + string.Format("{0}.pdf", guid);

            return ViewPdf(templatePdfFile, metadatas, testModel, outputPdfFile);
	    }
	}
}