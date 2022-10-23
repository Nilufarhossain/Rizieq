using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RiziqFinal.Models;
using System.Net;
using System.Net.Mail;

namespace RiziqFinal.Controllers
{
    public class EmailSetupController : Controller
    {
        // GET: EmailSetup
        public ActionResult sendemail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult sendemail(RiziqFinal.Models.gmail model)
        {
            MailMessage mm = new MailMessage("riziquewebsite@gmail.com", model.To);
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("riziquewebsite@gmail.com", "180104031");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Messages = "Mail has Been Sent Successfully";
            return View();
        }
    }
}