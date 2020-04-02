using NexusProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Configuration;
using System.Data.Entity.Core.Objects;
using System.Data;
using System.ComponentModel;
using Microsoft.Reporting.WebForms;
using System.IO;
using System.Text;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Web;
using System.Drawing;

namespace NexusProductAPI.Controllers.ServiceModule
{
    public class ServiceCenterController : ApiController
    {
        NEXUSPRODUCTEntities db = new NEXUSPRODUCTEntities();

        #region VSR_OwnVehicle
        [Route("api/getOwnVehicles")]
        public OwnVehiclesResponse getOwnVehicles()
        {
            OwnVehiclesResponse VR = new OwnVehiclesResponse();
            List<VSR_Mst_OwnVehicles_GetAll_Result> vehicleType = new List<VSR_Mst_OwnVehicles_GetAll_Result>();
            try
            {
                vehicleType = db.VSR_Mst_OwnVehicles_GetAll().ToList();
                if (vehicleType.Count() > 0)
                {
                    VR.status = 1; VR.ownVehicles = vehicleType;
                }
                return VR;
            }
            catch
            {
                VR.message = "Error Occured in fetching Own Vehicles List"; VR.ownVehicles = vehicleType; VR.status = 0;
                return VR;
            }
        }


        #endregion

        #region ServicePricing
        [Route("api/ServicePricing")]
        public ServicePricingResponse GET(int id)
        {
            ServicePricingResponse SR = new ServicePricingResponse();
            List<VSR_STN_ServicePricing_GetAllByServiceID_Result> ServicePricing = new List<VSR_STN_ServicePricing_GetAllByServiceID_Result>();
            try
            {
                ServicePricing = db.VSR_STN_ServicePricing_GetAllByServiceID(id).ToList();
                if (ServicePricing.Count() > 0)
                {
                    SR.status = 1; SR.ServicePricings = ServicePricing;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Service Prices"; SR.ServicePricings = ServicePricing; SR.status = 0;
                return SR;
            }
        }
        [HttpPost]
        [Route("api/ServicePricing")]
        public ServicePricingResponse Pricing([FromBody]PricingDetailsList pricingDetails)
        {
            ServicePricingResponse SR = new ServicePricingResponse();
            List<VSR_STN_ServicePricing_GetAllByServiceID_Result> ServicePricing = new List<VSR_STN_ServicePricing_GetAllByServiceID_Result>();
            try
            {
                string Details = JsonConvert.SerializeObject(pricingDetails.Details);
                int? ServiceTypeID = pricingDetails.Details[0].serviceTypeID;
                db.VSR_STN_ServicePricing_Save(ServiceTypeID, Details);
                int id;
                try { id = Convert.ToInt32(ServiceTypeID); } catch { id = 0; }
                ServicePricing = db.VSR_STN_ServicePricing_GetAllByServiceID(id).ToList();
                if (ServicePricing.Count() > 0)
                {
                    SR.status = 1; SR.ServicePricings = ServicePricing;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in Saving Service Prices"; SR.ServicePricings = ServicePricing; SR.status = 0;
                return SR;
            }
        }

        [HttpGet]
        [Route("api/ServicePricingByVehicleType")]
        public ServicePricingByVehicleTypeResponse ServicePricingByVehicleType(int id)
        {
            ServicePricingByVehicleTypeResponse SR = new ServicePricingByVehicleTypeResponse();
            List<VSR_STN_ServicePricing_GetAllByVehicleTypeID_Result> ServicePricing = new List<VSR_STN_ServicePricing_GetAllByVehicleTypeID_Result>();
            try
            {
                ServicePricing = db.VSR_STN_ServicePricing_GetAllByVehicleTypeID(id).ToList();
                if (ServicePricing.Count() > 0)
                {
                    SR.status = 1; SR.ServicePricings = ServicePricing;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Service Prices"; SR.ServicePricings = ServicePricing; SR.status = 0;
                return SR;
            }
        }


        [HttpGet]
        [Route("api/ServicePricingByVehicleTypeAndBay")]
        public ServicePricingByVehicleTypeAndBayResponse ServicePricingByVehicleTypeAndBay(int id, int bay)
        {
            ServicePricingByVehicleTypeAndBayResponse SR = new ServicePricingByVehicleTypeAndBayResponse();
            List<VSR_STN_ServicePricing_GetAllByVehicleTypeIDAndBayType_Result> ServicePricing = new List<VSR_STN_ServicePricing_GetAllByVehicleTypeIDAndBayType_Result>();
            try
            {
                ServicePricing = db.VSR_STN_ServicePricing_GetAllByVehicleTypeIDAndBayType(id, bay).ToList();
                if (ServicePricing.Count() > 0)
                {
                    SR.status = 1; SR.ServicePricings = ServicePricing;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Service Prices"; SR.ServicePricings = ServicePricing; SR.status = 0;
                return SR;
            }
        }

        #endregion

        #region dashboard
        [HttpGet]
        [Route("api/dashboardDetails")]
        public DashboardResponse dashboardDetails()
        {
            DashboardResponse SR = new DashboardResponse();
            List<VSR_Trn_ServiceEntry_GetDashboardData_Result> dash = new List<VSR_Trn_ServiceEntry_GetDashboardData_Result>();
            try
            {
                dash = db.VSR_Trn_ServiceEntry_GetDashboardData().ToList();
                if (dash.Count() > 0)
                {
                    SR.status = 1; SR.dashDetails = dash;
                }
                return SR;
            }
            catch
            {
                SR.dashDetails = dash; SR.status = 0;
                return SR;
            }
        }

        #endregion

        #region ServiceEntry
        [Route("api/getMaxNo")]
        public getMaxNoResponse getMaxNo()
        {
            getMaxNoResponse rsp = new getMaxNoResponse();
            try
            {
                rsp.status = 1;
                rsp.details = db.VSR_Trn_ServiceEntry_Head_getMaxEntryNo().ToList();
                return rsp;
            }
            catch { rsp.status = 0; return rsp; }
        }

        [HttpGet]
        [Route("api/SelectedServicesByServiceEntryId")]
        public SelectedServiceResponse SelectedServicesByServiceEntryId(int id)
        {
            SelectedServiceResponse SR = new SelectedServiceResponse();
            List<VSR_Trn_ServiceEntryDetails_GetByServeEntryID_Result> ServicePricing = new List<VSR_Trn_ServiceEntryDetails_GetByServeEntryID_Result>();
            try
            {
                ServicePricing = db.VSR_Trn_ServiceEntryDetails_GetByServeEntryID(id).ToList();
                if (ServicePricing.Count() > 0)
                {
                    SR.status = 1; SR.ServiceDetails = ServicePricing;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Service Prices"; SR.ServiceDetails = ServicePricing; SR.status = 0;
                return SR;
            }
        }

        [HttpPost]
        [Route("api/ServiceEntry")]
        public ServiceEntryResponse SaveServiceEntry([FromBody]ServiceEntry serviceEntryList)
        {

            try
            {
                string Details = JsonConvert.SerializeObject(serviceEntryList.serviceDetails);
                string vehicleno = serviceEntryList.vehicleNumber;
                int vehicletype = serviceEntryList.VehicleType;
                int partytype = serviceEntryList.partyType;
                int baytype = serviceEntryList.baytype;
                string url = serviceEntryList.base64img;
                string remarks = serviceEntryList.remarks;
                string customer = serviceEntryList.customername;
                decimal total = serviceEntryList.Total;
                decimal discount = serviceEntryList.discount;
                decimal netamt = serviceEntryList.netamount;
                //string base64Img = "";
                //int index = serviceEntryList.base64img.IndexOf(',');
                //base64Img = serviceEntryList.base64img.Substring(index + 1);
                //byte[] bytes = Convert.FromBase64String(base64Img);

                //Image image;
                //using (MemoryStream ms = new MemoryStream(bytes))
                //{
                //    image = Image.FromStream(ms);
                //}



                //var path = "";
                //if (!Directory.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/Images/"+ DateTime.Now.ToString("dd_MM_yyyy"))))
                //    Directory.CreateDirectory(System.Web.Hosting.HostingEnvironment.MapPath("~/Images/" + DateTime.Now.ToString("dd_MM_yyyy")));
                //path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Images/"  +DateTime.Now.ToString("dd_MM_yyyy") + "/"), "V_"+ DateTime.Now.ToString("dd_MM_yyyy_hhmmss") + ".png");
                //string url= "Images/" + DateTime.Now.ToString("dd_MM_yyyy") + "/V_" + DateTime.Now.ToString("dd_MM_yyyy_hhmmss") + ".png";
                //try { image.Save(path,ImageFormat.Png); } catch(Exception ex) { url = serviceEntryList.base64img; }
                int EntryStarNo = int.Parse(WebConfigurationManager.AppSettings["ServiceEntryStartNo"].ToString());
                ObjectResult<Nullable<int>> queryResult = db.VSR_Trn_ServiceEntry_Save(EntryStarNo, baytype, partytype, vehicleno, vehicletype, url, remarks, customer, total, discount, netamt, Details);
                int ID = 0;
                foreach (Nullable<int> result in queryResult)
                    ID = result.Value;
                ServiceEntryResponse SR = new ServiceEntryResponse();
                List<VSR_Trn_ServiceEntryDetails_GetByServeEntryID_Result> ServicePricing = new List<VSR_Trn_ServiceEntryDetails_GetByServeEntryID_Result>();
                ServicePricing = db.VSR_Trn_ServiceEntryDetails_GetByServeEntryID(ID).ToList();
                DataTable dt = ToDataTable(ServicePricing);

                // System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "openModal", "window.open('../Report/RDLCVwr.aspx?rt=gplqtn&ft=pdf&no=" + e.CommandArgument.ToString() + "' ,'_blank');", true);
                LocalReport report = new LocalReport();
                report.ReportPath = "Reports\\ServiceCenter\\serviceentryPrint.rdlc";
                //report.ReportEmbeddedResource = ("serviceentryPrint.rdlc");
                report.DataSources.Add(new ReportDataSource("DataSet1", dt));
                Export(report);

                //m_currentPageIndex = 0;
                //Print();
                SR.status = 1;
                SR.message = "Saved Successfully !!";
                SR.ServiceDetails = ServicePricing;
                return SR;
            }
            catch (Exception ex)
            {
                ServiceEntryResponse SR = new ServiceEntryResponse();
                SR.status = 0;
                SR.message = "Error Occured While Saving Details";
                return SR;
            }
        }



        [HttpPost]
        [Route("api/ServiceEntryWithoutPrint")]
        public ServiceEntryResponse ServiceEntryWithoutPrint([FromBody]ServiceEntry serviceEntryList)
        {

            try
            {
                string Details = JsonConvert.SerializeObject(serviceEntryList.serviceDetails);
                string vehicleno = serviceEntryList.vehicleNumber;
                int vehicletype = serviceEntryList.VehicleType;
                int partytype = serviceEntryList.partyType;
                int baytype = serviceEntryList.baytype;
                string url = serviceEntryList.base64img;
                string remarks = serviceEntryList.remarks;
                string customer = serviceEntryList.customername;
                decimal total = serviceEntryList.Total;
                decimal discount = serviceEntryList.discount;
                decimal netamt = serviceEntryList.netamount;
                //string base64Img = "";
                //int index = serviceEntryList.base64img.IndexOf(',');
                //base64Img = serviceEntryList.base64img.Substring(index + 1);
                //byte[] bytes = Convert.FromBase64String(base64Img);

                //Image image;
                //using (MemoryStream ms = new MemoryStream(bytes))
                //{
                //    image = Image.FromStream(ms);
                //}



                //var path = "";
                //if (!Directory.Exists(System.Web.Hosting.HostingEnvironment.MapPath("~/Images/"+ DateTime.Now.ToString("dd_MM_yyyy"))))
                //    Directory.CreateDirectory(System.Web.Hosting.HostingEnvironment.MapPath("~/Images/" + DateTime.Now.ToString("dd_MM_yyyy")));
                //path = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Images/"  +DateTime.Now.ToString("dd_MM_yyyy") + "/"), "V_"+ DateTime.Now.ToString("dd_MM_yyyy_hhmmss") + ".png");
                //string url= "Images/" + DateTime.Now.ToString("dd_MM_yyyy") + "/V_" + DateTime.Now.ToString("dd_MM_yyyy_hhmmss") + ".png";
                //try { image.Save(path,ImageFormat.Png); } catch(Exception ex) { url = serviceEntryList.base64img; }
                int EntryStarNo = int.Parse(WebConfigurationManager.AppSettings["ServiceEntryStartNo"].ToString());
                ObjectResult<Nullable<int>> queryResult = db.VSR_Trn_ServiceEntry_Save(EntryStarNo, baytype, partytype, vehicleno, vehicletype, url, remarks, customer, total, discount, netamt, Details);
                int ID = 0;
                foreach (Nullable<int> result in queryResult)
                    ID = result.Value;
                ServiceEntryResponse SR = new ServiceEntryResponse();
                List<VSR_Trn_ServiceEntryDetails_GetByServeEntryID_Result> ServicePricing = new List<VSR_Trn_ServiceEntryDetails_GetByServeEntryID_Result>();
                ServicePricing = db.VSR_Trn_ServiceEntryDetails_GetByServeEntryID(ID).ToList();
               
                SR.status = 1;
                SR.message = "Saved Successfully !!";
                SR.ServiceDetails = ServicePricing;
                return SR;
            }
            catch (Exception ex)
            {
                ServiceEntryResponse SR = new ServiceEntryResponse();
                SR.status = 0;
                SR.message = "Error Occured While Saving Details";
                return SR;
            }
        }



        [HttpGet]
        [Route("api/ServiceEntryshowopening")]
        public openingCountShow ServiceEntryshowopening()
        {
            openingCountShow op = new openingCountShow();
            try
            {
                ObjectResult<Nullable<int>> obj = db.VSR_Trn_ServiceEntry_IsShowOpening();
                foreach (var result in obj)
                    op.showopen = result.Value;
                op.status = 1;
                return op;
            }
            catch
            {
                op.status = 0;
                return op;
            }
        }

        [HttpPost]
        [Route("api/SaveopeningCount")]
        public openingCountShow SaveopeningCount([FromBody] PostOpening opn)
        {
            openingCountShow op = new openingCountShow();
            try
            {

                db.VSR_STN_OpeningCount_Save(opn.actualCount);
                ObjectResult<Nullable<int>> obj = db.VSR_Trn_ServiceEntry_IsShowOpening();
                foreach (var result in obj)
                    op.showopen = result.Value;
                op.status = 1;
                return op;
            }
            catch
            {
                op.status = 0;
                return op;
            }
        }
        public class PostOpening
        {
            public int actualCount { get; set; }
        }

        [Route("api/getAllEntries")]
        public AllservicesEntered getAllEntries()
        {
            List<VSR_Trn_ServiceEntry_GetAll_Result> lst = db.VSR_Trn_ServiceEntry_GetAll().ToList();
            AllservicesEntered SR = new AllservicesEntered();
            SR.entries = lst;
            SR.status = 1;
            return SR;
        }

        [Route("api/getServicesByEntryID")]
        public serviceDetails getServicesByEntryID(int Id)
        {
            List<VSR_Trn_ServiceEntryDetails_GetByServeEntryID_Result> lst = db.VSR_Trn_ServiceEntryDetails_GetByServeEntryID(Id).ToList();
            serviceDetails SR = new serviceDetails();
            SR.details = lst;
            SR.status = 1;
            return SR;
        }

        [Route("api/getDetailsForServiceEntry")]
        public ServiceEntryInitialLoad getDetailsForServiceEntry()
        {
            try
            {
               
                ServiceEntryInitialLoad SR = new ServiceEntryInitialLoad();
                SR.details = db.VSR_Trn_ServiceEntry_Head_getMaxEntryNo().ToList();
                SR.VehicleTypes = db.VSR_Mst_VehicleTypes_GetAll().ToList();
                SR.ownVehicles= db.VSR_Mst_OwnVehicles_GetAll().ToList();
                SR.ServiceDetails= db.VSR_Trn_ServiceEntryDetails_GetByServeEntryID(0).ToList();
                SR.status = 1;
                return SR;
            }
            catch(Exception Ex)
            {
                ServiceEntryInitialLoad SR = new ServiceEntryInitialLoad();
                SR.status = 0;
                SR.message = "Some Error Occured while Fetching Initial Data";
                return SR;
            }
        }



        #endregion

        #region ServiceTypes
        [Route("api/GetServiceTypes")]
        public ServiceResponse GetServiceTypes()
        {
            ServiceResponse SR = new ServiceResponse();
            List<VSR_Mst_ServiceTypes_GetAll_Result> ServiceType = new List<VSR_Mst_ServiceTypes_GetAll_Result>();
            try
            {
                ServiceType = db.VSR_Mst_ServiceTypes_GetAll().ToList();
                if (ServiceType.Count() > 0)
                {
                    SR.status = 1; SR.ServiceTypes = ServiceType;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Service Types"; SR.ServiceTypes = ServiceType; SR.status = 0;
                return SR;
            }
        }


        [HttpPost]
        [Route("api/PostServiceTypes")]
        public ServiceResponse PostServiceTypes(postData data)
        {
            ServiceResponse SR = new ServiceResponse();
            List<VSR_Mst_ServiceTypes_GetAll_Result> ServiceType = new List<VSR_Mst_ServiceTypes_GetAll_Result>();
            try
            {
                db.VSR_Mst_ServiceTypes_Save(data.serviceType, data.serviceTypeAr, data.description, data.serviceTypeId);
                ServiceType = db.VSR_Mst_ServiceTypes_GetAll().ToList();
                if (ServiceType.Count() > 0)
                {
                    SR.status = 1; SR.ServiceTypes = ServiceType; SR.message = "Saved Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.ServiceTypes = ServiceType; SR.status = 0;
                return SR;
            }
        }

        [HttpPost]
        [Route("api/DeleteServiceTypes")]
        public ServiceResponse DeleteServiceTypes(postData data)
        {
            ServiceResponse SR = new ServiceResponse();
            List<VSR_Mst_ServiceTypes_GetAll_Result> ServiceType = new List<VSR_Mst_ServiceTypes_GetAll_Result>();
            try
            {
                db.VSR_Mst_ServiceTypes_Delete(data.serviceTypeId);
                ServiceType = db.VSR_Mst_ServiceTypes_GetAll().ToList();
                if (ServiceType.Count() > 0)
                {
                    SR.status = 1; SR.ServiceTypes = ServiceType; SR.message = "Deleted Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.ServiceTypes = ServiceType; SR.status = 0;
                return SR;
            }
        }

        #endregion

        #region vehicletypes
        [Route("api/getVSR_VehicleTypes")]
        public VehicleTypesResponse getVSR_VehicleTypes()
        {
            VehicleTypesResponse SR = new VehicleTypesResponse();
            List<VSR_Mst_VehicleTypes_GetAll_Result> VehicleType = new List<VSR_Mst_VehicleTypes_GetAll_Result>();
            try
            {
                VehicleType = db.VSR_Mst_VehicleTypes_GetAll().ToList();
                if (VehicleType.Count() > 0)
                {
                    SR.status = 1; SR.VehicleTypes = VehicleType;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Service Types"; SR.VehicleTypes = VehicleType; SR.status = 0;
                return SR;
            }
        }


        [HttpPost]
        [Route("api/postVSR_VehicleTypes")]
        public VehicleTypesResponse postVSR_VehicleTypes(postVehicleTypeData data)
        {
            VehicleTypesResponse SR = new VehicleTypesResponse();
            List<VSR_Mst_VehicleTypes_GetAll_Result> VehicleType = new List<VSR_Mst_VehicleTypes_GetAll_Result>();
            try
            {
                db.VSR_Mst_VehicleTypes_Save(data.vehicleTypeNameEn, data.descriptionEn, data.id);
                VehicleType = db.VSR_Mst_VehicleTypes_GetAll().ToList();
                if (VehicleType.Count() > 0)
                {
                    SR.status = 1; SR.VehicleTypes = VehicleType; SR.message = "Saved Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.VehicleTypes = VehicleType; SR.status = 0;
                return SR;
            }
        }

        [HttpPost]
        [Route("api/DeleteVehicleTypes")]
        public VehicleTypesResponse DeleteVehicleTypes(postVehicleTypeData data)
        {
            VehicleTypesResponse SR = new VehicleTypesResponse();
            List<VSR_Mst_VehicleTypes_GetAll_Result> VehicleType = new List<VSR_Mst_VehicleTypes_GetAll_Result>();
            try
            {
                db.VSR_Mst_VehicleTypes_Delete(data.id);
                VehicleType = db.VSR_Mst_VehicleTypes_GetAll().ToList();
                if (VehicleType.Count() > 0)
                {
                    SR.status = 1; SR.VehicleTypes = VehicleType; SR.message = "Deleted Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.VehicleTypes = VehicleType; SR.status = 0;
                return SR;
            }
        }

        #endregion

        #region responsetypes

        public class ServiceEntryInitialLoad
        {
           public int status { get; set; }
           public List<VSR_Trn_ServiceEntry_Head_getMaxEntryNo_Result> details { get; set; }
            public List<VSR_Mst_VehicleTypes_GetAll_Result> VehicleTypes { get; set; }
            public List<VSR_Mst_OwnVehicles_GetAll_Result> ownVehicles { get; set; }
            public List<VSR_Trn_ServiceEntryDetails_GetByServeEntryID_Result> ServiceDetails { get; set; }
            public string message { get; set; }
        }

        public class DashboardResponse
        {
            public List<VSR_Trn_ServiceEntry_GetDashboardData_Result> dashDetails { get; set; }
            public int status { get; set; }
        }
        public class OwnVehiclesResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<VSR_Mst_OwnVehicles_GetAll_Result> ownVehicles { get; set; }
        }
        public class ServiceEntryResponse
        {
            public string message { get; set; }
            public int status { get; set; }
            public List<VSR_Trn_ServiceEntryDetails_GetByServeEntryID_Result> ServiceDetails { get; set; }

        }
        public class ServicePricingResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<VSR_STN_ServicePricing_GetAllByServiceID_Result> ServicePricings { get; set; }
        }

        public class ServicePricingByVehicleTypeResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<VSR_STN_ServicePricing_GetAllByVehicleTypeID_Result> ServicePricings { get; set; }
        }

        public class ServicePricingByVehicleTypeAndBayResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<VSR_STN_ServicePricing_GetAllByVehicleTypeIDAndBayType_Result> ServicePricings { get; set; }
        }

        public class SelectedServiceResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<VSR_Trn_ServiceEntryDetails_GetByServeEntryID_Result> ServiceDetails { get; set; }
        }

        public class AllservicesEntered
        {
            public List<VSR_Trn_ServiceEntry_GetAll_Result> entries { get; set; }
            public int status { get; set; }
        }
        public class PricingDetailsList
        {
            public List<PricingDetails> Details { get; set; }
        }

        public class PricingDetails
        {
            public string vehicleTypeNameAr { get; set; }
            public string vehicleTypeNameEn { get; set; }
            public string ownVehicle { get; set; }
            public string thirdParty { get; set; }
            public Nullable<int> serviceTypeID { get; set; }
            public int pricingID { get; set; }
            public int vehicleTypeID { get; set; }
        }

        public class ServiceEntry
        {
            public int partyType { get; set; }
            public string vehicleNumber { get; set; }
            public int VehicleType { get; set; }
            public int baytype { get; set; }
            public string base64img { get; set; }
            public List<serviceEntryDetails> serviceDetails { get; set; }
            public string remarks { get; set; }
            public string customername { get; set; }
            public decimal Total { get; set; }
            public decimal discount { get; set; }
            public decimal netamount { get; set; }
        }
        public class serviceEntryDetails
        {
            public int id { get; set; }
            public int serviceId { get; set; }
            public decimal amount { get; set; }
            public string serviceTypeNameEn { get; set; }
            public string serviceTypeNameAr { get; set; }
            public string entryDate { get; set; }
            public int serviceEntryID { get; set; }

        }
        public class getMaxNoResponse
        {
            public int status { get; set; }
            public List<VSR_Trn_ServiceEntry_Head_getMaxEntryNo_Result> details { get; set; }
        }
        public class openingCountShow
        {
            public int status { get; set; }
            public int showopen { get; set; }
        }

        public class serviceDetails
        {
            public List<VSR_Trn_ServiceEntryDetails_GetByServeEntryID_Result> details { get; set; }
            public int status { get; set; }
        }
        public class postData
        {
            public string serviceType { get; set; }
            public string description { get; set; }
            public string serviceTypeAr { get; set; }
            public int serviceTypeId { get; set; }
        }

        public class ServiceResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<VSR_Mst_ServiceTypes_GetAll_Result> ServiceTypes { get; set; }
        }

        public class postVehicleTypeData
        {
            public string vehicleTypeNameEn { get; set; }
            public string descriptionEn { get; set; }
            public int id { get; set; }
        }

        public class VehicleTypesResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<VSR_Mst_VehicleTypes_GetAll_Result> VehicleTypes { get; set; }
        }

        #endregion

        #region CommonMethods
        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;
        public static DataTable ToDataTable<T>( IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
        public static void PrintToPrinter(LocalReport report)
        {
            Export(report);

        }

        public static void Export(LocalReport report, bool print = true)
        {
            string deviceInfo =
             @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageHeight>8.5in</PageHeight>  
                <PageWidth>11in</PageWidth>                
                <MarginTop>0in</MarginTop>
                <MarginLeft>0.1in</MarginLeft>
                <MarginRight>0.1in</MarginRight>
                <MarginBottom>0in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;

            if (print)
            {
                Print();
            }
        }


        public static void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        public static Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        public static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        public static void DisposePrint()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

        #endregion
    }
}
