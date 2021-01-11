using Iqraa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iqraa.Controllers
{
    public class ContactUsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContactUs
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMessage(ContactUs ComingMessage)
        {
            db.ContactUs.Add(ComingMessage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}