using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Iqraa.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
        public ActionResult Change(string LanguageAbbreviation)
        {

            if(LanguageAbbreviation != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbreviation);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbreviation);

            }

            HttpCookie Cookie = new HttpCookie("Language");
            Cookie.Value = LanguageAbbreviation;
            Response.Cookies.Add(Cookie);


            return RedirectToAction("Index","Home");
        }
    }
}