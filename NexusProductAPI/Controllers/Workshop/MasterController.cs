using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NexusProductAPI.Models;
using NexusProductAPI.App_Class;

namespace NexusProductAPI.Controllers.Workshop
{
    public class MasterController : ApiController
    {
        NEXUSPRODUCTEntities db = new NEXUSPRODUCTEntities();


        #region Workshop

        [HttpGet]
        [Route("api/GovernorateList")]
        public GovernorateResponse GovernorateList()
        {
            GovernorateResponse Res = new GovernorateResponse();
            List<CMN_Mst_Governorate_GetList_Result> Governorate = new List<CMN_Mst_Governorate_GetList_Result>();
            try
            {
                Governorate = db.CMN_Mst_Governorate_GetList().ToList();
                if (Governorate.Count() > 0)
                {
                    Res.status = 1; Res.Governorate = Governorate;
                }
                return Res;
            }
            catch
            {
                Res.message = "Error Occured in fetching Governorate List"; Res.Governorate = Governorate; Res.status = 0;
                return Res;
            }
        }
        public class GovernorateResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<CMN_Mst_Governorate_GetList_Result> Governorate { get; set; }
        }

        public class WilayathResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<CMN_Mst_Wilayath_GetList_Result> Wilayath { get; set; }
        }

        [HttpGet]
        [Route("api/WilayathList")]
        public WilayathResponse WilayathList()
        {
            WilayathResponse Res = new WilayathResponse();
            List<CMN_Mst_Wilayath_GetList_Result> Wilayath = new List<CMN_Mst_Wilayath_GetList_Result>();
            try
            {
                Wilayath = db.CMN_Mst_Wilayath_GetList().ToList();
                if (Wilayath.Count() > 0)
                {
                    Res.status = 1; Res.Wilayath = Wilayath;
                }
                return Res;
            }
            catch
            {
                Res.message = "Error Occured in fetching Wilayath List"; Res.Wilayath = Wilayath; Res.status = 0;
                return Res;
            }
        }

        public class WorkshopResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<CMN_Mst_LocationGroup_GetList_Result> Workshop { get; set; }
        }

        [HttpGet]
        [Route("api/WorkshopList")]
        public WorkshopResponse WorkshopList()
        {
            WorkshopResponse Res = new WorkshopResponse();
            List<CMN_Mst_LocationGroup_GetList_Result> Workshop = new List<CMN_Mst_LocationGroup_GetList_Result>();
            try
            {
                Workshop = db.CMN_Mst_LocationGroup_GetList().ToList();
                if (Workshop.Count() > 0)
                {
                    Res.status = 1; Res.Workshop = Workshop;
                }
                return Res;
            }
            catch (Exception ex)
            {
                Res.message = "Error Occured in fetching Workshop(s)"; Res.Workshop = Workshop; Res.status = 0;
                return Res;
            }
        }

        [HttpPost]
        [Route("api/PostWorkshop")]
        public WorkshopResponse PostWorkshop(object obj)
        {
            WorkshopResponse SR = new WorkshopResponse();

            CMN_Mst_LocationGroup_GetList_Result data = obj.GetData<CMN_Mst_LocationGroup_GetList_Result>();
            string oper = obj.GetOperation();

            List<CMN_Mst_LocationGroup_GetList_Result> Workshop = new List<CMN_Mst_LocationGroup_GetList_Result>();
            try
            {
                db.CMN_Mst_LocationGroup_DML_Oper(data.ID, data.text, data.workshopNameAr
                    , 0, data.governorateCDE, data.willayatCDE, data.coOrdinates, data.contactPerson,
                    data.contactNo, data.contactEmail, data.status, oper);

                Workshop = db.CMN_Mst_LocationGroup_GetList().ToList();
                if (Workshop.Count() > 0)
                {
                    SR.status = 1; SR.Workshop = Workshop; SR.message = "Success.!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.Workshop = Workshop; SR.status = 0;
                return SR;
            }
        }

        #endregion Workshop

        #region Technician Types

        public class TechnicianTypes
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<WSP_Mst_TechnicianTypes_GetList_Result> technicianTypes { get; set; }
        }

        [HttpGet]
        [Route("api/TechnicianTypesList")]
        public TechnicianTypes TechnicianTypesList()
        {
            TechnicianTypes Res = new TechnicianTypes();
            List<WSP_Mst_TechnicianTypes_GetList_Result> technicianTypes = new List<WSP_Mst_TechnicianTypes_GetList_Result>();
            try
            {
                technicianTypes = db.WSP_Mst_TechnicianTypes_GetList().ToList();
                if (technicianTypes.Count() > 0)
                {
                    Res.status = 1; Res.technicianTypes = technicianTypes;
                }
                return Res;
            }
            catch (Exception ex)
            {
                Res.message = "Error Occured in fetching Workshop(s)"; Res.technicianTypes = technicianTypes; Res.status = 0;
                return Res;
            }
        }

        [HttpPost]
        [Route("api/PostTechnicianTypes")]
        public TechnicianTypes PostTechnicianTypes(object obj)
        {
            TechnicianTypes SR = new TechnicianTypes();

            WSP_Mst_TechnicianTypes_GetList_Result data = obj.GetData<WSP_Mst_TechnicianTypes_GetList_Result>();
            string oper = obj.GetOperation();

            List<WSP_Mst_TechnicianTypes_GetList_Result> technicianTypes = new List<WSP_Mst_TechnicianTypes_GetList_Result>();
            try
            {
                db.WSP_Mst_TechnicianTypes_DML_Oper(data.id, data.text, data.techTypeNameAr, data.chargePerHr, data.active, oper);

                technicianTypes = db.WSP_Mst_TechnicianTypes_GetList().ToList();
                if (technicianTypes.Count() > 0)
                {
                    SR.status = 1; SR.technicianTypes = technicianTypes; SR.message = "Success.!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.technicianTypes = technicianTypes; SR.status = 0;
                return SR;
            }
        }

        #endregion Technician Types

        #region Technician

        public class Technicians
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<WSP_Mst_Technician_GetList_Result> technicians { get; set; }
        }

        [HttpGet]
        [Route("api/TechniciansList")]
        public Technicians TechniciansList()
        {
            Technicians Res = new Technicians();
            List<WSP_Mst_Technician_GetList_Result> technicians = new List<WSP_Mst_Technician_GetList_Result>();
            try
            {
                technicians = db.WSP_Mst_Technician_GetList().ToList();
                if (technicians.Count() > 0)
                {
                    Res.status = 1; Res.technicians = technicians;
                }
                return Res;
            }
            catch (Exception ex)
            {
                Res.message = "Error Occured in fetching Workshop(s)"; Res.technicians = technicians; Res.status = 0;
                return Res;
            }
        }

        [HttpPost]
        [Route("api/PostTechnicians")]
        public Technicians PostTechnicians(object obj)
        {
            Technicians SR = new Technicians();

            WSP_Mst_Technician_GetList_Result data = obj.GetData<WSP_Mst_Technician_GetList_Result>();
            string oper = obj.GetOperation();

            List<WSP_Mst_Technician_GetList_Result> technicians = new List<WSP_Mst_Technician_GetList_Result>();
            try
            {
                db.WSP_Mst_Technician_DML_Oper(data.id, data.empID, data.technicianTypeCDE, data.workshopCDE, data.text, data.active, oper);

                technicians = db.WSP_Mst_Technician_GetList().ToList();
                if (technicians.Count() > 0)
                {
                    SR.status = 1; SR.technicians = technicians; SR.message = "Success.!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.technicians = technicians; SR.status = 0;
                return SR;
            }
        }

        #endregion Technician

        #region UOM

        public class UOM
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<WSP_Mst_UOM_GetList_Result> uom { get; set; }
        }

        [HttpGet]
        [Route("api/UOMList")]
        public UOM UOMList()
        {
            UOM Res = new UOM();
            List<WSP_Mst_UOM_GetList_Result> uom = new List<WSP_Mst_UOM_GetList_Result>();
            try
            {
                uom = db.WSP_Mst_UOM_GetList().ToList();
                if (uom.Count() > 0)
                {
                    Res.status = 1; Res.uom = uom;
                }
                return Res;
            }
            catch (Exception ex)
            {
                Res.message = "Error Occured in fetching Workshop(s)"; Res.uom = uom; Res.status = 0;
                return Res;
            }
        }

        [HttpPost]
        [Route("api/PostUOM")]
        public UOM PostUOM(object obj)
        {
            UOM SR = new UOM();

            WSP_Mst_UOM_GetList_Result data = obj.GetData<WSP_Mst_UOM_GetList_Result>();
            string oper = obj.GetOperation();

            List<WSP_Mst_UOM_GetList_Result> uom = new List<WSP_Mst_UOM_GetList_Result>();
            try
            {
                db.WSP_Mst_UOM_DML_Oper(data.id, data.uOM_Code, data.text, data.uOM_NameAr, data.active, oper);

                uom = db.WSP_Mst_UOM_GetList().ToList();
                if (uom.Count() > 0)
                {
                    SR.status = 1; SR.uom = uom; SR.message = "Success.!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.uom = uom; SR.status = 0;
                return SR;
            }
        }

        #endregion UOM

        #region ItemMaster

        public class ItemMaster
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<WSP_Mst_ItemMaster_GetList_Result> itemMaster { get; set; }
        }

        [HttpGet]
        [Route("api/ItemMasterList")]
        public ItemMaster ItemMasterList()
        {
            ItemMaster Res = new ItemMaster();
            List<WSP_Mst_ItemMaster_GetList_Result> itemMaster = new List<WSP_Mst_ItemMaster_GetList_Result>();
            try
            {
                itemMaster = db.WSP_Mst_ItemMaster_GetList().ToList();
                if (itemMaster.Count() > 0)
                {
                    Res.status = 1; Res.itemMaster = itemMaster;
                }
                return Res;
            }
            catch (Exception ex)
            {
                Res.message = "Error Occured in fetching Workshop(s)"; Res.itemMaster = itemMaster; Res.status = 0;
                return Res;
            }
        }

        [HttpPost]
        [Route("api/PostItemMaster")]
        public ItemMaster PostItemMaster(object obj)
        {
            ItemMaster SR = new ItemMaster();

            WSP_Mst_ItemMaster_GetList_Result data = obj.GetData<WSP_Mst_ItemMaster_GetList_Result>();
            string oper = obj.GetOperation();

            List<WSP_Mst_ItemMaster_GetList_Result> itemMaster = new List<WSP_Mst_ItemMaster_GetList_Result>();
            try
            {
                db.WSP_Mst_ItemMaster_DML_Oper(data.id, data.itemCode, data.text, data.itemNameAr, data.price, data.uOMCDE, data.active, oper);

                itemMaster = db.WSP_Mst_ItemMaster_GetList().ToList();
                if (itemMaster.Count() > 0)
                {
                    SR.status = 1; SR.itemMaster = itemMaster; SR.message = "Success.!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.itemMaster = itemMaster; SR.status = 0;
                return SR;
            }
        }

        #endregion ItemMaster

        #region ServiceTypes

        public class ServiceTypes
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<WSP_Mst_ServiceTypes_GetList_Result> serviceTypes { get; set; }
        }

        [HttpGet]
        [Route("api/GetServiceTypes")]
        public ServiceTypes PostServiceTypes()
        {
            ServiceTypes Res = new ServiceTypes();
            List<WSP_Mst_ServiceTypes_GetList_Result> serviceTypes = new List<WSP_Mst_ServiceTypes_GetList_Result>();
            try
            {
                serviceTypes = db.WSP_Mst_ServiceTypes_GetList().ToList();
                if (serviceTypes.Count() > 0)
                {
                    Res.status = 1; Res.serviceTypes = serviceTypes;
                }
                return Res;
            }
            catch (Exception ex)
            {
                Res.message = "Error Occured in fetching ServiceType(s)"; Res.serviceTypes = serviceTypes; Res.status = 0;
                return Res;
            }
        }

        [HttpPost]
        [Route("api/PostServiceTypes")]
        public ServiceTypes PostServiceTypes(object obj)
        {
            ServiceTypes SR = new ServiceTypes();

            WSP_Mst_ServiceTypes_GetList_Result data = obj.GetData<WSP_Mst_ServiceTypes_GetList_Result>();
            string oper = obj.GetOperation();

            List<WSP_Mst_ServiceTypes_GetList_Result> serviceTypes = new List<WSP_Mst_ServiceTypes_GetList_Result>();
            try
            {
                db.WSP_Mst_ServiceTypes_DML_Oper(data.id, data.text, data.serviceTypeNameAr, data.kilometre, data.active, oper);

                serviceTypes = db.WSP_Mst_ServiceTypes_GetList().ToList();
                if (serviceTypes.Count() > 0)
                {
                    SR.status = 1; SR.serviceTypes = serviceTypes; SR.message = "Success.!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.serviceTypes = serviceTypes; SR.status = 0;
                return SR;
            }
        }

        #endregion ServiceTypes

        #region VehicleType

        public class VehicleType
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<WSP_Mst_VehicleType_GetList_Result> vehicleType { get; set; }
        }

        [HttpGet]
        [Route("api/GetVehicleType")]
        public VehicleType PostVehicleType()
        {
            VehicleType Res = new VehicleType();
            List<WSP_Mst_VehicleType_GetList_Result> vehicleType = new List<WSP_Mst_VehicleType_GetList_Result>();
            try
            {
                vehicleType = db.WSP_Mst_VehicleType_GetList().ToList();
                if (vehicleType.Count() > 0)
                {
                    Res.status = 1; Res.vehicleType = vehicleType;
                }
                return Res;
            }
            catch (Exception ex)
            {
                Res.message = "Error Occured in fetching ServiceType(s)"; Res.vehicleType = vehicleType; Res.status = 0;
                return Res;
            }
        }

        [HttpPost]
        [Route("api/PostVehicleType")]
        public VehicleType PostVehicleType(object obj)
        {
            VehicleType SR = new VehicleType();

            WSP_Mst_VehicleType_GetList_Result data = obj.GetData<WSP_Mst_VehicleType_GetList_Result>();
            string oper = obj.GetOperation();

            List<WSP_Mst_VehicleType_GetList_Result> vehicleType = new List<WSP_Mst_VehicleType_GetList_Result>();
            try
            {
                db.WSP_Mst_VehicleType_DML_Oper(data.id, data.text, data.vehicleTypeNameAr, data.active, oper);

                vehicleType = db.WSP_Mst_VehicleType_GetList().ToList();
                if (vehicleType.Count() > 0)
                {
                    SR.status = 1; SR.vehicleType = vehicleType; SR.message = "Success.!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.vehicleType = vehicleType; SR.status = 0;
                return SR;
            }
        }

        #endregion VehicleType

        #region VehicleSubType

        public class VehicleSubType
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<WSP_Mst_VehicleSubType_GetList_Result> vehicleSubType { get; set; }
        }

        [HttpGet]
        [Route("api/GetVehicleSubType")]
        public VehicleSubType GetVehicleSubType()
        {
            VehicleSubType Res = new VehicleSubType();
            List<WSP_Mst_VehicleSubType_GetList_Result> vehicleSubType = new List<WSP_Mst_VehicleSubType_GetList_Result>();
            try
            {
                vehicleSubType = db.WSP_Mst_VehicleSubType_GetList().ToList();
                if (vehicleSubType.Count() > 0)
                {
                    Res.status = 1; Res.vehicleSubType = vehicleSubType;
                }
                return Res;
            }
            catch (Exception ex)
            {
                Res.message = "Error Occured in fetching ServiceType(s)"; Res.vehicleSubType = vehicleSubType; Res.status = 0;
                return Res;
            }
        }

        [HttpPost]
        [Route("api/PostVehicleSubType")]
        public VehicleSubType PostVehicleSubType(object obj)
        {
            VehicleSubType SR = new VehicleSubType();

            WSP_Mst_VehicleSubType_GetList_Result data = obj.GetData<WSP_Mst_VehicleSubType_GetList_Result>();
            string oper = obj.GetOperation();

            List<WSP_Mst_VehicleSubType_GetList_Result> vehicleSubType = new List<WSP_Mst_VehicleSubType_GetList_Result>();
            try
            {
                db.WSP_Mst_VehicleSubType_DML_Oper(data.id, data.vehicleTypeCDE, data.text, data.vehicleSubTypeNameAr, data.active, oper);

                vehicleSubType = db.WSP_Mst_VehicleSubType_GetList().ToList();
                if (vehicleSubType.Count() > 0)
                {
                    SR.status = 1; SR.vehicleSubType = vehicleSubType; SR.message = "Success.!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.vehicleSubType = vehicleSubType; SR.status = 0;
                return SR;
            }
        }

        #endregion VehicleSubType

        #region Brands
        public class Brands
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<WSP_Mst_Brands_GetList_Result> brands { get; set; }
        }

        [HttpGet]
        [Route("api/GetBrands")]
        public Brands GetBrands()
        {
            Brands Res = new Brands();
            List<WSP_Mst_Brands_GetList_Result> brands = new List<WSP_Mst_Brands_GetList_Result>();
            try
            {
                brands = db.WSP_Mst_Brands_GetList().ToList();
                if (brands.Count() > 0)
                {
                    Res.status = 1; Res.brands = brands;
                }
                return Res;
            }
            catch (Exception ex)
            {
                Res.message = "Error Occured in fetching Brand(s)"; Res.brands = brands; Res.status = 0;
                return Res;
            }
        }

        [HttpPost]
        [Route("api/PostBrands")]
        public Brands PostBrands(object obj)
        {
            Brands SR = new Brands();

            WSP_Mst_Brands_GetList_Result data = obj.GetData<WSP_Mst_Brands_GetList_Result>();
            string oper = obj.GetOperation();

            List<WSP_Mst_Brands_GetList_Result> brands = new List<WSP_Mst_Brands_GetList_Result>();
            try
            {
                db.WSP_Mst_Brands_DML_Oper(data.id, data.text, data.brandNameAr, data.active, oper);

                brands = db.WSP_Mst_Brands_GetList().ToList();
                if (brands.Count() > 0)
                {
                    SR.status = 1; SR.brands = brands; SR.message = "Success.!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.brands = brands; SR.status = 0;
                return SR;
            }
        }

        #endregion Brands

        #region Vehicles
        public class Vehicles
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<WSP_Mst_Vehicles_GetList_Result> vehicles { get; set; }
        }

        [HttpGet]
        [Route("api/GetVehicles")]
        public Vehicles GetVehicles()
        {
            Vehicles Res = new Vehicles();
            List<WSP_Mst_Vehicles_GetList_Result> vehicles = new List<WSP_Mst_Vehicles_GetList_Result>();
            try
            {
                vehicles = db.WSP_Mst_Vehicles_GetList().ToList();
                if (vehicles.Count() > 0)
                {
                    Res.status = 1; Res.vehicles = vehicles;
                }
                return Res;
            }
            catch (Exception ex)
            {
                Res.message = "Error Occured in fetching Brand(s)"; Res.vehicles = vehicles; Res.status = 0;
                return Res;
            }
        }

        [HttpPost]
        [Route("api/PostVehicles")]
        public Vehicles PostVehicles(object obj)
        {
            Vehicles SR = new Vehicles();

            WSP_Mst_Vehicles_GetList_Result data = obj.GetData<WSP_Mst_Vehicles_GetList_Result>();
            string oper = obj.GetOperation();

            List<WSP_Mst_Vehicles_GetList_Result> vehicles = new List<WSP_Mst_Vehicles_GetList_Result>();
            try
            {
                db.WSP_Mst_Vehicles_DML_Oper(data.id, data.vehicleTypeCDE, data.vehicleSubTypeCDE, data.text
                    , data.fleetNo, data.regExpiryDate, data.description, data.brandCDE, data.yearOfManufact, data.firstRegDate, data.engineNo
                    , data.chasisNo, data.purchaseDate, data.purchaseValue, data.serviceInterval_KM, data.serviceInterval_Months
                    , data.status, data.active, oper);

                vehicles = db.WSP_Mst_Vehicles_GetList().ToList();
                if (vehicles.Count() > 0)
                {
                    SR.status = 1; SR.vehicles = vehicles; SR.message = "Success.!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.vehicles = vehicles; SR.status = 0;
                return SR;
            }
        }

        #endregion Vehicles

        #region Customers
        public class Customers
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<WSP_Mst_Customers_GetList_Result> customers { get; set; }
        }

        [HttpGet]
        [Route("api/GetCustomers")]
        public Customers GetCustomers()
        {
            Customers Res = new Customers();
            List<WSP_Mst_Customers_GetList_Result> customers = new List<WSP_Mst_Customers_GetList_Result>();
            try
            {
                customers = db.WSP_Mst_Customers_GetList().ToList();
                if (customers.Count() > 0)
                {
                    Res.status = 1; Res.customers = customers;
                }
                return Res;
            }
            catch (Exception ex)
            {
                Res.message = "Error Occured in fetching Brand(s)"; Res.customers = customers; Res.status = 0;
                return Res;
            }
        }

        [HttpPost]
        [Route("api/PostCustomers")]
        public Customers PostCustomers(object obj)
        {
            Customers SR = new Customers();

            WSP_Mst_Customers_GetList_Result data = obj.GetData<WSP_Mst_Customers_GetList_Result>();
            string oper = obj.GetOperation();

            List<WSP_Mst_Customers_GetList_Result> customers = new List<WSP_Mst_Customers_GetList_Result>();
            try
            {
                db.WSP_Mst_Customers_DML_Oper(data.id, data.type, data.uniqueIdNo, data.locationCDE, data.text
                    , data.contactPerson, data.contactNo, data.contactEmail, data.active, oper);

                customers = db.WSP_Mst_Customers_GetList().ToList();
                if (customers.Count() > 0)
                {
                    SR.status = 1; SR.customers = customers; SR.message = "Success.!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.customers = customers; SR.status = 0;
                return SR;
            }
        }

        #endregion Customers

        #region Services
        public class Services
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<WSP_Mst_Services_GetList_Result> services { get; set; }
        }

        [HttpGet]
        [Route("api/GetServices")]
        public Services GetServices()
        {
            Services Res = new Services();
            List<WSP_Mst_Services_GetList_Result> services = new List<WSP_Mst_Services_GetList_Result>();
            try
            {
                services = db.WSP_Mst_Services_GetList().ToList();
                if (services.Count() > 0)
                {
                    Res.status = 1; Res.services = services;
                }
                return Res;
            }
            catch (Exception ex)
            {
                Res.message = "Error Occured in fetching Service(s)"; Res.services = services; Res.status = 0;
                return Res;
            }
        }

        [HttpPost]
        [Route("api/PostServices")]
        public Services PostServices(object obj)
        {
            Services SR = new Services();

            WSP_Mst_Services_GetList_Result data = obj.GetData<WSP_Mst_Services_GetList_Result>();
            string oper = obj.GetOperation();

            List<WSP_Mst_Services_GetList_Result> services = new List<WSP_Mst_Services_GetList_Result>();
            try
            {
                db.WSP_Mst_Services_DML_Oper(data.id, data.serviceTypeCDE, data.text, data.serviceNameAr, data.serviceCode
                    , data.isItemRequired, data.active, oper);

                services = db.WSP_Mst_Services_GetList().ToList();
                if (services.Count() > 0)
                {
                    SR.status = 1; SR.services = services; SR.message = "Success.!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.services = services; SR.status = 0;
                return SR;
            }
        }

        #endregion Services

    }

}
