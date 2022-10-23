using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RiziqFinal.Models
{
    public class Zakat
    {
        public float currency { get; set; }
        public float gold { get; set; }
        public float silver { get; set; }

        public float debts { get; set; }

        public float expenses { get; set; }
        public float amount { get; set; }

    }
}