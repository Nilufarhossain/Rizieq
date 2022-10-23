using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RiziqFinal.Models;


namespace RiziqFinal.Controllers
{
    public class RegisterUserController : Controller
    {
        // GET: RegisterUser
        RiziqFinalEntities db = new RiziqFinalEntities();
        // GET: RegisterUser
        [HttpGet]
        public ActionResult Register()
        {
            List<TBL_OCCUPATION> Li = db.TBL_OCCUPATION.ToList();
            ViewBag.list = new SelectList(Li, "OCC_ID", "OCC_TYPE");
            List<TBL_MEMBERSHIP> Li1 = db.TBL_MEMBERSHIP.ToList();
            ViewBag.list1 = new SelectList(Li1, "MEM_ID ", "MEM_TYPE ");
            return View();
        }

        [HttpPost]
        public ActionResult Register(TBL_USER u)
        {
            List<TBL_OCCUPATION> Li = db.TBL_OCCUPATION.ToList();
            ViewBag.list = new SelectList(Li, "OCC_ID", "OCC_TYPE");
            List<TBL_MEMBERSHIP> Li1 = db.TBL_MEMBERSHIP.ToList();
            ViewBag.list1 = new SelectList(Li1, "MEM_ID ", "MEM_TYPE ");
            TempData["msg"] = null;
            try
            {
                //if (db.TBL_USER.Any(x => x.u_name == u.u_name && x.u_type == u.u_type))
                //{
                //    TempData["msg"] = "This username has already existed..";
                //}

                if (db.TBL_USER.Any(x => x.u_email == u.u_email))
                {
                    TempData["msg"] = "This Account has already existed..";
                }
                else if (db.TBL_USER.Any(x => x.u_contact == u.u_contact))
                {
                    TempData["msg"] = "This Contact Number has already existed..";
                }
                else
                {
                    u.u_status = 0;
                    db.TBL_USER.Add(u);
                    db.SaveChanges();

                    TempData["msg"] = "Your Account is Successfully Created...Thank you";

                    return RedirectToAction("Register");
                }


            }
            catch (Exception)
            {

            }
            return View();
        }

        public ActionResult DonorPanel()
        {
            //return View();
            return RedirectToAction("Donorpanel", "Donor");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult VolunteerPanel()
        {
            return RedirectToAction("Volunteerpanel", "Volunter");
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
        public ActionResult Donate_Others()
        {
            TempData["msg"] = null;
            //ViewBag.error = "Please Sign Up First..";
            TempData["msg"] = "At First Sign Up Please ....";
            return View();
        }


        [HttpGet]
        public ActionResult NeedHelp()
        {
            List<TBL_NEEDTYPE> Li = db.TBL_NEEDTYPE.ToList();
            ViewBag.list = new SelectList(Li, "NEED_ID", "NEED_TYPE");
            return View();
        }

        [HttpPost]
        public ActionResult NeedHelp(NeedHelp u)
        {
            List<TBL_NEEDTYPE> Li = db.TBL_NEEDTYPE.ToList();
            ViewBag.list = new SelectList(Li, "NEED_ID", "NEED_TYPE");
            TempData["msg"] = null;
            try
            {
                db.NeedHelps.Add(u);
                db.SaveChanges();
                TempData["msg"] = "Your Request is submitted successfully..";
                return RedirectToAction("NeedHelp");

            }
            catch (Exception)
            {

            }
            return View();
        }


        [HttpGet]
        public ActionResult Feedback()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Feedback(TBL_FEEDBACK u)
        {
            TempData["msg"] = null;
            try
            {
                db.TBL_FEEDBACK.Add(u);
                db.SaveChanges();
                TempData["msg"] = "Your Feedback is submitted successfully..";
                return RedirectToAction("Feedback");

            }
            catch (Exception)
            {

            }
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            List<TBL_MEMBERSHIP> Li = db.TBL_MEMBERSHIP.ToList();
            ViewBag.list = new SelectList(Li, "MEM_ID", "MEM_TYPE");
            return View();
        }


        [HttpPost]
        public ActionResult Login(TBL_USER u)
        {
            // TempData["msg"] = null;

            List<TBL_MEMBERSHIP> Li = db.TBL_MEMBERSHIP.ToList();
            ViewBag.list = new SelectList(Li, "MEM_ID", "MEM_TYPE");

            TBL_USER ui = db.TBL_USER.Where(x => x.u_email == u.u_email && x.u_password == u.u_password && x.u_type == u.u_type).SingleOrDefault();
            if (ui != null)
            {
                //u.u_status = 0;
                //if (u.u_status == 0)
                //{
                //    ViewBag.error = "Your Account has not been verified yet..";
                //}
                //else if (u.u_status == 1)
                //{
                if (u.u_type == 1)
                {
                    Session["u_email"] = u.u_email.ToString();
                    return RedirectToAction("VolunteerPanel");
                }
                else if (u.u_type == 2)
                {
                    Session["u_email"] = u.u_email.ToString();
                    return RedirectToAction("DonorPanel");
                }

                // }
                //else
                //{
                //    ViewBag.error = "Your Account has  been Blocked";
                //}
            }
            else
            {
                TempData["msg"] = "Invalid email or password or usertype..";
            }
            return View();
        }



    }
}
