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
    
    public partial class VSR_Trn_ServiceEntryDetails_GetByServeEntryID_Result
    {
        public int ID { get; set; }
        public int ServiceId { get; set; }
        public int ServiceEntryID { get; set; }
        public decimal Amount { get; set; }
        public string ServiceTypeNameEn { get; set; }
        public string ServiceTypeNameAr { get; set; }
        public string EntryDate { get; set; }
        public int EntryNo { get; set; }
        public string CustomerName { get; set; }
        public decimal NetAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}