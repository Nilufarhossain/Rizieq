//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RiziqFinal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_NEEDTYPE
    {
        public TBL_NEEDTYPE()
        {
            this.NeedHelps = new HashSet<NeedHelp>();
            this.TBL_DONATEOthers = new HashSet<TBL_DONATEOthers>();
        }
    
        public int NEED_ID { get; set; }
        public string NEED_TYPE { get; set; }
    
        public virtual ICollection<NeedHelp> NeedHelps { get; set; }
        public virtual ICollection<TBL_DONATEOthers> TBL_DONATEOthers { get; set; }
    }
}
