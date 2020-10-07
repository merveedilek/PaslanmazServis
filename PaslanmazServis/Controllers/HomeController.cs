using PaslanmazServis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace PaslanmazServis.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult iletisim(iletisim form)
        {
            
                SmtpClient mailClient = new SmtpClient("smtp.gmail.com", 587);
                NetworkCredential cred = new NetworkCredential("metaliletisim@gmail.com", "Metal123");
                mailClient.Credentials = cred;
                MailMessage contact = new MailMessage();
                contact.From = new MailAddress("metaliletisim@gmail.com"); //burası kendi maili
                contact.Subject = "İletişim Formu " + DateTime.Now;
                contact.IsBodyHtml = true;
                contact.Body = "www.Paslanmazservis.net web sitesinden iletişim formu dolduruldu. <br/>";
                contact.Body += "<br/>Ad Soyad: " + form.Ad;
                contact.Body += "<br/>Email: " + form.Mail;
            contact.Body += "<br/>Konu: " + form.Konu;
            contact.Body += "<br/>Mesaj: " + form.Mesaj;
                mailClient.EnableSsl = true;
                contact.To.Add("info@metalmuhendislik.com.tr"); //burası info maili
                mailClient.EnableSsl = true;
                mailClient.Send(contact);
                return RedirectToAction("Index");

            
        }
    }
}