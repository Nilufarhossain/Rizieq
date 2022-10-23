using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RiziqFinal.Models;

namespace Blog.Controllers
{
    public class BlogController : Controller
    {
        RiziqFinalEntities nd = new RiziqFinalEntities();
        // GET: Blog
        //public ActionResult Index()
        //{
        //    //var blogdetails = nd.BlogPosts.ToList().OrderByDescending(x=>x.BID);
        //    using (RiziqFinalEntities nd = new RiziqFinalEntities())
        //    {
        //        return View(nd.BlogPosts.ToList().OrderByDescending(x => x.BID));

        //    }


        //}
        public ActionResult Volunteerpanel()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Uploadblog()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Uploadblog(BlogPost imageModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);

            using (RiziqFinalEntities nd = new RiziqFinalEntities())
            {
                nd.BlogPosts.Add(imageModel);
                nd.SaveChanges();
            }

            ModelState.Clear();
            ViewBag.message = "Blog Details Are Saved Successfully...!";
            return View();
        }

        public ActionResult Food()
        {
            var fooddonation = nd.BlogPosts.Where(x => x.BCategory == "Food");
            return View(fooddonation);


        }
        public ActionResult Cloth()
        {
            var clothdonation = nd.BlogPosts.Where(x => x.BCategory == "Cloth");
            return View(clothdonation);


        }
        public ActionResult Education()
        {
            var educationdonation = nd.BlogPosts.Where(x => x.BCategory == "Education");
            return View(educationdonation);


        }
        public ActionResult other()
        {
            var otherdonation = nd.BlogPosts.Where(x => x.BCategory == "Other");
            return View(otherdonation);


        }

    }
}