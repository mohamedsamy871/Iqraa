using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iqraa.Models;

namespace Iqraa.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var visitorsNo = (from m in db.VisitorsNumber
                              select m.VisitorNumber).Count();
            ViewBag.visitorsNum = visitorsNo;
            return View();
        }

        public ActionResult About()
        {

            return View();
        }

    }
}