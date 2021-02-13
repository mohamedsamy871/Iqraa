using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iqraa.Models;

namespace Iqraa.Controllers
{
    [AllowAnonymous]
    public class NewsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: News
        public ActionResult Index()
        {
            var News = db.IqraaNews.ToList();

            var visitorsNo = (from m in db.VisitorsNumber
                              select m.VisitorNumber).Count();
            ViewBag.visitorsNum = visitorsNo;

            return View(News);
        }
    }
}