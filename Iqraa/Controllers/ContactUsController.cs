using Iqraa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
            var visitorsNo = (from m in db.VisitorsNumber
                              select m.VisitorNumber).Count();
            ViewBag.visitorsNum = visitorsNo;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMessage(ContactUs ComingMessage)
        {
            db.ContactUs.Add(ComingMessage);
            db.SaveChanges();
            //if (!ModelState.IsValid)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Please,Try Again");
            //}
            var fromAddress = new MailAddress("info@iqraa-center.com", "موقع اقرأ");
            var toAddress = new MailAddress("quran.literacycenter@gmail.com", "ادارة موقع اقرأ");
            var fromPassword = "info@123456";
            var subject = "رسالة واردة الي موقع اقرأ";
            var body = ComingMessage.Message;
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
                Priority = MailPriority.High,
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
            
            return RedirectToAction("Index","Home");
        }
    }
}