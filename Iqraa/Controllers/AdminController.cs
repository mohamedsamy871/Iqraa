using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iqraa.Models;
using System.IO;

namespace Iqraa.Controllers
{
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult GetNews()
        {
            var Article = db.IqraaNews.ToList();
            return View(Article);
        }

        public ActionResult EditNews(int id)
        {
            var news = db.IqraaNews.FirstOrDefault(m => m.Id == id);
            return View(news);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateNews(IqraaNews IqraaNews)
        {
            var IqraaNewsIndb = db.IqraaNews.Single(m => m.Id == IqraaNews.Id);
            IqraaNewsIndb.TitleAr = IqraaNews.TitleAr;
            IqraaNewsIndb.DescAr = IqraaNews.DescAr;
            if (IqraaNews.ImageFile != null)
            {
                string FileName = Path.GetFileNameWithoutExtension(IqraaNews.ImageFile.FileName);
                string Extension = Path.GetExtension(IqraaNews.ImageFile.FileName);
                FileName = FileName + DateTime.Now.ToString("yymmssff") + Extension;
                IqraaNewsIndb.ImagePath = "~/UploadedImages/" + FileName;
                FileName = Path.Combine(Server.MapPath("~/UploadedImages/"), FileName);
                IqraaNews.ImageFile.SaveAs(FileName);
                IqraaNewsIndb.ImageFile = IqraaNews.ImageFile;
            }

            db.SaveChanges();
            return RedirectToAction("GetNews");
        }

        public ActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNews(IqraaNews IqraaNews)
        {
            if (IqraaNews.ImageFile != null)
            {
                string FileName = Path.GetFileNameWithoutExtension(IqraaNews.ImageFile.FileName);
                string Extension = Path.GetExtension(IqraaNews.ImageFile.FileName);
                FileName = FileName + DateTime.Now.ToString("yymmssff") + Extension;
                IqraaNews.ImagePath = "~/UploadedImages/" + FileName;
                FileName = Path.Combine(Server.MapPath("~/UploadedImages/"), FileName);
                IqraaNews.ImageFile.SaveAs(FileName);
            }
            db.IqraaNews.Add(IqraaNews);
            db.SaveChanges();
            return RedirectToAction("GetNews");
        }

        public ActionResult DeleteNews(int id)
        {
            var IqraaNews = db.IqraaNews.Find(id);
            db.IqraaNews.Remove(IqraaNews);
            db.SaveChanges();
            return RedirectToAction("GetNews");
        }
    }
}