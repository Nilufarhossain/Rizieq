using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RiziqFinal.Models;
using System.IO;



namespace RiziqFinal.Controllers
{
    public class DonorController : Controller
    {

        RiziqFinalEntities db = new RiziqFinalEntities();
        // GET: Donor
        public ActionResult Donorpanel()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Donate_Money()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Donate_Money(TBL_DONATE u)
        {
            TempData["msg"] = null;
            try
            {
                db.TBL_DONATE.Add(u);
                db.SaveChanges();
                TempData["msg"] = "Your Donation is successful..";
                return RedirectToAction("Donate_Money");

            }
            catch (Exception)
            {

            }
            return View();
        }

        [HttpGet]
        public ActionResult Donate_Other()
        {
            List<TBL_NEEDTYPE> Li = db.TBL_NEEDTYPE.ToList();
            ViewBag.list = new SelectList(Li, "NEED_ID", "NEED_TYPE");
            return View();
        }

        [HttpPost]
        public ActionResult Donate_Other(TBL_DONATEOthers u)
        {
            string fileName = Path.GetFileNameWithoutExtension(u.ImageFile.FileName);
            string extension = Path.GetExtension(u.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            u.do_ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            u.ImageFile.SaveAs(fileName);


            List<TBL_NEEDTYPE> Li = db.TBL_NEEDTYPE.ToList();
            ViewBag.list = new SelectList(Li, "NEED_ID", "NEED_TYPE");
            TempData["msg"] = null;
            try
            {
                db.TBL_DONATEOthers.Add(u);
                db.SaveChanges();
                TempData["msg"] = "Your Donation Request is submitted successfully..";
                return RedirectToAction("Donate_Other");

            }
            catch (Exception)
            {

            }
            return View();
        }
    }
}