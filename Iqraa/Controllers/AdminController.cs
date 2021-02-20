using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Iqraa.Models;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace Iqraa.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        public ActionResult Index()
        {

            return View();
        }
        #region News
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
            IqraaNewsIndb.TitleEn = IqraaNews.TitleEn;
            IqraaNewsIndb.TitleFr = IqraaNews.TitleFr;
            IqraaNewsIndb.TitleEs = IqraaNews.TitleEs;
            IqraaNewsIndb.TitleUr = IqraaNews.TitleUr;
            IqraaNewsIndb.DescAr = IqraaNews.DescAr;
            IqraaNewsIndb.DescEn = IqraaNews.DescEn;
            IqraaNewsIndb.DescFr = IqraaNews.DescFr;
            IqraaNewsIndb.DescEs = IqraaNews.DescEs;
            IqraaNewsIndb.DescUr = IqraaNews.DescUr;
            if (IqraaNews.ImageFile != null)
            {
                string FileName = Path.GetFileNameWithoutExtension(IqraaNews.ImageFile.FileName);
                string Extension = Path.GetExtension(IqraaNews.ImageFile.FileName);
                FileName = FileName + DateTime.Now.ToString("yymmssff") + Extension;
                IqraaNewsIndb.ImagePath = "/UploadedImages/" + FileName;
                FileName = Path.Combine(Server.MapPath("/UploadedImages/"), FileName);
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
                IqraaNews.ImagePath = "/UploadedImages/" + FileName;
                FileName = Path.Combine(Server.MapPath("/UploadedImages/"), FileName);
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
        #endregion
        #region Contact Message
        public ActionResult GetContactMessage()
        {
            var ContactUsMessages = db.ContactUs.ToList();
            return View(ContactUsMessages);
        }
        public ActionResult EditContactMessage(int id)
        {
            var ContactMessage = db.ContactUs.FirstOrDefault(m => m.Id == id);

            return View(ContactMessage);
        }
        public ActionResult UpdateContactMessage(ContactUs ContactMessage)
        {
            var MessageIndb = db.ContactUs.Single(m => m.Id == ContactMessage.Id);
            MessageIndb.Name = ContactMessage.Name;
            MessageIndb.Email = ContactMessage.Email;
            MessageIndb.Message = ContactMessage.Message;
            MessageIndb.Reply = ContactMessage.Reply;
            db.SaveChanges();
            var fromAddress = new MailAddress("info@iqraa-center.com", "مركز اقرأ");
            var toAddress = new MailAddress(ContactMessage.Email, ContactMessage.Name);
            var fromPassword = "info@123456";
            var subject = "الرد علي رسالتكم";
            var body = ContactMessage.Reply;
            var smtp = new SmtpClient("mail.iqraa-center.com") /*587*/
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("info@iqraa-center.com", fromPassword),
                EnableSsl = false,
                Port = 8889

            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                Priority =MailPriority.High,
                IsBodyHtml = true,
                
            }
                  )
            {
                //smtp.Send(message);
                try
                {
                    smtp.Send(message);
                    Response.Write("Email Send successfully");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            return RedirectToAction("GetContactMessage");
        }
        public ActionResult DeleteContactMessage(int id)
        {
            var ContactMessage = db.ContactUs.Find(id);
            db.ContactUs.Remove(ContactMessage);
            db.SaveChanges();
            return RedirectToAction("GetContactMessage");
        }
        #endregion
    }
}