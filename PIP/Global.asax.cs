using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcPdfWriter.Core;

namespace PIP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

			ViewEngines.Engines.Add(new PdfViewEngine());
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
