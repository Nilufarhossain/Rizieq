using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RiziqFinal.Models;

namespace RiziqFinal.Controllers
{
    public class ZakatController : Controller
    {
        // GET: Zakat
        public ActionResult zakat()
        {
            return View(new Zakat());
        }

        [HttpPost]
        public ActionResult zakat(Zakat z)
        {
            float x, y, p;


            x = z.debts + z.expenses;
            if (z.gold > 87.89 || z.silver > 612.36 || z.currency > 6384 && x < 6384)
            {
                p = ((z.silver * (72 / 100) + (z.gold * 57) + z.currency) - x) * 25;
                z.amount = p / 100;
            }
            else
            {
                z.amount = 0;
            }


            return View(z);
        }

    }

}