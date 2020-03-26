﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NEXUSPRODUCTEntities : DbContext
    {
        public NEXUSPRODUCTEntities()
            : base("name=NEXUSPRODUCTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<VSR_Mst_OwnVehicles_GetAll_Result> VSR_Mst_OwnVehicles_GetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VSR_Mst_OwnVehicles_GetAll_Result>("VSR_Mst_OwnVehicles_GetAll");
        }
    
        public virtual int VSR_Mst_ServiceTypes_Delete(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VSR_Mst_ServiceTypes_Delete", iDParameter);
        }
    
        public virtual ObjectResult<VSR_Mst_ServiceTypes_GetAll_Result> VSR_Mst_ServiceTypes_GetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VSR_Mst_ServiceTypes_GetAll_Result>("VSR_Mst_ServiceTypes_GetAll");
        }
    
        public virtual int VSR_Mst_ServiceTypes_Save(string serviceTypeNameEn, string serviceTypeNameAr, string descriptionEn, Nullable<int> iD)
        {
            var serviceTypeNameEnParameter = serviceTypeNameEn != null ?
                new ObjectParameter("ServiceTypeNameEn", serviceTypeNameEn) :
                new ObjectParameter("ServiceTypeNameEn", typeof(string));
    
            var serviceTypeNameArParameter = serviceTypeNameAr != null ?
                new ObjectParameter("serviceTypeNameAr", serviceTypeNameAr) :
                new ObjectParameter("serviceTypeNameAr", typeof(string));
    
            var descriptionEnParameter = descriptionEn != null ?
                new ObjectParameter("DescriptionEn", descriptionEn) :
                new ObjectParameter("DescriptionEn", typeof(string));
    
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VSR_Mst_ServiceTypes_Save", serviceTypeNameEnParameter, serviceTypeNameArParameter, descriptionEnParameter, iDParameter);
        }
    
        public virtual int VSR_Mst_VehicleTypes_Delete(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VSR_Mst_VehicleTypes_Delete", iDParameter);
        }
    
        public virtual ObjectResult<VSR_Mst_VehicleTypes_GetAll_Result> VSR_Mst_VehicleTypes_GetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VSR_Mst_VehicleTypes_GetAll_Result>("VSR_Mst_VehicleTypes_GetAll");
        }
    
        public virtual int VSR_Mst_VehicleTypes_Save(string vehicleTypeNameEn, string descriptionEn, Nullable<int> iD)
        {
            var vehicleTypeNameEnParameter = vehicleTypeNameEn != null ?
                new ObjectParameter("VehicleTypeNameEn", vehicleTypeNameEn) :
                new ObjectParameter("VehicleTypeNameEn", typeof(string));
    
            var descriptionEnParameter = descriptionEn != null ?
                new ObjectParameter("DescriptionEn", descriptionEn) :
                new ObjectParameter("DescriptionEn", typeof(string));
    
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VSR_Mst_VehicleTypes_Save", vehicleTypeNameEnParameter, descriptionEnParameter, iDParameter);
        }
    
        public virtual int VSR_STN_OpeningCount_Save(Nullable<int> actualCount)
        {
            var actualCountParameter = actualCount.HasValue ?
                new ObjectParameter("actualCount", actualCount) :
                new ObjectParameter("actualCount", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VSR_STN_OpeningCount_Save", actualCountParameter);
        }
    
        public virtual ObjectResult<VSR_STN_ServicePricing_GetAllByServiceID_Result> VSR_STN_ServicePricing_GetAllByServiceID(Nullable<int> serviceID)
        {
            var serviceIDParameter = serviceID.HasValue ?
                new ObjectParameter("ServiceID", serviceID) :
                new ObjectParameter("ServiceID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VSR_STN_ServicePricing_GetAllByServiceID_Result>("VSR_STN_ServicePricing_GetAllByServiceID", serviceIDParameter);
        }
    
        public virtual ObjectResult<VSR_STN_ServicePricing_GetAllByVehicleTypeID_Result> VSR_STN_ServicePricing_GetAllByVehicleTypeID(Nullable<int> vehicleTypeId)
        {
            var vehicleTypeIdParameter = vehicleTypeId.HasValue ?
                new ObjectParameter("vehicleTypeId", vehicleTypeId) :
                new ObjectParameter("vehicleTypeId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VSR_STN_ServicePricing_GetAllByVehicleTypeID_Result>("VSR_STN_ServicePricing_GetAllByVehicleTypeID", vehicleTypeIdParameter);
        }
    
        public virtual ObjectResult<VSR_STN_ServicePricing_GetAllByVehicleTypeIDAndBayType_Result> VSR_STN_ServicePricing_GetAllByVehicleTypeIDAndBayType(Nullable<int> vehicleTypeId, Nullable<int> bayType)
        {
            var vehicleTypeIdParameter = vehicleTypeId.HasValue ?
                new ObjectParameter("vehicleTypeId", vehicleTypeId) :
                new ObjectParameter("vehicleTypeId", typeof(int));
    
            var bayTypeParameter = bayType.HasValue ?
                new ObjectParameter("BayType", bayType) :
                new ObjectParameter("BayType", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VSR_STN_ServicePricing_GetAllByVehicleTypeIDAndBayType_Result>("VSR_STN_ServicePricing_GetAllByVehicleTypeIDAndBayType", vehicleTypeIdParameter, bayTypeParameter);
        }
    
        public virtual int VSR_STN_ServicePricing_Save(Nullable<int> serviceTypeID, string pricing)
        {
            var serviceTypeIDParameter = serviceTypeID.HasValue ?
                new ObjectParameter("ServiceTypeID", serviceTypeID) :
                new ObjectParameter("ServiceTypeID", typeof(int));
    
            var pricingParameter = pricing != null ?
                new ObjectParameter("Pricing", pricing) :
                new ObjectParameter("Pricing", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VSR_STN_ServicePricing_Save", serviceTypeIDParameter, pricingParameter);
        }
    
        public virtual ObjectResult<VSR_Trn_ServiceEntry_Details_GetAllByEntryId_Result> VSR_Trn_ServiceEntry_Details_GetAllByEntryId(Nullable<int> entryId)
        {
            var entryIdParameter = entryId.HasValue ?
                new ObjectParameter("EntryId", entryId) :
                new ObjectParameter("EntryId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VSR_Trn_ServiceEntry_Details_GetAllByEntryId_Result>("VSR_Trn_ServiceEntry_Details_GetAllByEntryId", entryIdParameter);
        }
    
        public virtual ObjectResult<VSR_Trn_ServiceEntry_GetAll_Result> VSR_Trn_ServiceEntry_GetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VSR_Trn_ServiceEntry_GetAll_Result>("VSR_Trn_ServiceEntry_GetAll");
        }
    
        public virtual ObjectResult<VSR_Trn_ServiceEntry_GetDashboardData_Result> VSR_Trn_ServiceEntry_GetDashboardData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VSR_Trn_ServiceEntry_GetDashboardData_Result>("VSR_Trn_ServiceEntry_GetDashboardData");
        }
    
        public virtual ObjectResult<VSR_Trn_ServiceEntry_Head_getMaxEntryNo_Result> VSR_Trn_ServiceEntry_Head_getMaxEntryNo()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VSR_Trn_ServiceEntry_Head_getMaxEntryNo_Result>("VSR_Trn_ServiceEntry_Head_getMaxEntryNo");
        }
    
        public virtual ObjectResult<Nullable<int>> VSR_Trn_ServiceEntry_IsShowOpening()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("VSR_Trn_ServiceEntry_IsShowOpening");
        }
    
        public virtual ObjectResult<Nullable<int>> VSR_Trn_ServiceEntry_Save(Nullable<int> entryStartNo, Nullable<int> bayType, Nullable<int> partyType, string vehicleNumber, Nullable<int> vehicleType, string imgUrl, string remarks, string customerName, Nullable<decimal> totalAmount, Nullable<decimal> discount, Nullable<decimal> netAmount, string details)
        {
            var entryStartNoParameter = entryStartNo.HasValue ?
                new ObjectParameter("EntryStartNo", entryStartNo) :
                new ObjectParameter("EntryStartNo", typeof(int));
    
            var bayTypeParameter = bayType.HasValue ?
                new ObjectParameter("BayType", bayType) :
                new ObjectParameter("BayType", typeof(int));
    
            var partyTypeParameter = partyType.HasValue ?
                new ObjectParameter("PartyType", partyType) :
                new ObjectParameter("PartyType", typeof(int));
    
            var vehicleNumberParameter = vehicleNumber != null ?
                new ObjectParameter("VehicleNumber", vehicleNumber) :
                new ObjectParameter("VehicleNumber", typeof(string));
    
            var vehicleTypeParameter = vehicleType.HasValue ?
                new ObjectParameter("VehicleType", vehicleType) :
                new ObjectParameter("VehicleType", typeof(int));
    
            var imgUrlParameter = imgUrl != null ?
                new ObjectParameter("ImgUrl", imgUrl) :
                new ObjectParameter("ImgUrl", typeof(string));
    
            var remarksParameter = remarks != null ?
                new ObjectParameter("Remarks", remarks) :
                new ObjectParameter("Remarks", typeof(string));
    
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var totalAmountParameter = totalAmount.HasValue ?
                new ObjectParameter("TotalAmount", totalAmount) :
                new ObjectParameter("TotalAmount", typeof(decimal));
    
            var discountParameter = discount.HasValue ?
                new ObjectParameter("Discount", discount) :
                new ObjectParameter("Discount", typeof(decimal));
    
            var netAmountParameter = netAmount.HasValue ?
                new ObjectParameter("NetAmount", netAmount) :
                new ObjectParameter("NetAmount", typeof(decimal));
    
            var detailsParameter = details != null ?
                new ObjectParameter("details", details) :
                new ObjectParameter("details", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("VSR_Trn_ServiceEntry_Save", entryStartNoParameter, bayTypeParameter, partyTypeParameter, vehicleNumberParameter, vehicleTypeParameter, imgUrlParameter, remarksParameter, customerNameParameter, totalAmountParameter, discountParameter, netAmountParameter, detailsParameter);
        }
    
        public virtual ObjectResult<VSR_Trn_ServiceEntryDetails_GetByServeEntryID_Result> VSR_Trn_ServiceEntryDetails_GetByServeEntryID(Nullable<int> serviceEntryID)
        {
            var serviceEntryIDParameter = serviceEntryID.HasValue ?
                new ObjectParameter("ServiceEntryID", serviceEntryID) :
                new ObjectParameter("ServiceEntryID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<VSR_Trn_ServiceEntryDetails_GetByServeEntryID_Result>("VSR_Trn_ServiceEntryDetails_GetByServeEntryID", serviceEntryIDParameter);
        }
    
        public virtual ObjectResult<CMN_Mst_User_Authenticate_Result> CMN_Mst_User_Authenticate(string userName, string password)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CMN_Mst_User_Authenticate_Result>("CMN_Mst_User_Authenticate", userNameParameter, passwordParameter);
        }
    }
}
