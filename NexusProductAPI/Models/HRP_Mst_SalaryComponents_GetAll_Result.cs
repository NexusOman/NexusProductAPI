//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NexusProductAPI.Models
{
    using System;
    
    public partial class HRP_Mst_SalaryComponents_GetAll_Result
    {
        public int id { get; set; }
        public string salarycomponentcode { get; set; }
        public string salarycomponentname { get; set; }
        public string addordeduct { get; set; }
        public Nullable<decimal> defaultamount { get; set; }
        public Nullable<decimal> defaultpercent { get; set; }
        public bool active { get; set; }
    }
}
