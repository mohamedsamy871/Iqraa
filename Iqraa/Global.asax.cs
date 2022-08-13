using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Iqraa.Models;

namespace Iqraa
{
    public class MvcApplication : System.Web.HttpApplication
    {
        
        protected void Session_Start()
        {
            Application.Lock();

            Application["Totaluser"] = (int)Application["Totaluser"] + 1;
            ApplicationDbContext db = new ApplicationDbContext();
            VisitorsNumber vn = new VisitorsNumber();
            vn.VisitorNumber = (int)Application["Totaluser"];
            db.VisitorsNumber.Add(vn);
            db.SaveChanges();
            Application.UnLock();
        }
        protected void Application_Start()
        {
            
            Application["Totaluser"] = 0;
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
        //protected void Application_End()
        //{
        //    var count = Application["Totaluser"];
        //    ApplicationDbContext db = new ApplicationDbContext();
        //    db.VisitorsNumber.Add((VisitorsNumber)count);
        //    db.SaveChanges();

        //}
    }
}
