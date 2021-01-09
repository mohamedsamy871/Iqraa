using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Iqraa
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            HttpCookie Cookie = HttpContext.Current.Request.Cookies["Language"];
            if (Cookie != null && Cookie.Value != null)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(Cookie.Value);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(Cookie.Value);

            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            }
            //    HttpContext context = HttpContext.Current;
            //var languageSession = "en";
            //if (context != null && context.Session != null)
            //{
            //    languageSession = context.Session["lang"] != null ? context.Session["lang"].ToString() : "en";
            //}
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageSession);
            //Thread.CurrentThread.CurrentCulture = new CultureInfo(languageSession);
        }

    }
}
