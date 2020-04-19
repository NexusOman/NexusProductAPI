using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NexusProductAPI.Models;
namespace NexusProductAPI.Controllers.HR_Payroll
{
    public class HRP_ConfigController : ApiController
    {
        NEXUSPRODUCTEntities db = new NEXUSPRODUCTEntities();
        #region SalarySetup
        [HttpGet]
        [Route("api/GetSalarySetups")]
        public EmployeeSalarySetupResponse GetSalarySetups(int id)
        {
            EmployeeSalarySetupResponse SR = new EmployeeSalarySetupResponse();
            List<HRP_Cnf_SalarySetup_GetAll_Result> docs = new List<HRP_Cnf_SalarySetup_GetAll_Result>();
            try
            {
                docs = db.HRP_Cnf_SalarySetup_GetAll(id).ToList();

                SR.status = 1; SR.SalList = docs;

                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Employee Documents"; SR.SalList = docs; SR.status = 0;
                return SR;
            }
        }

        [HttpPost]
        [Route("api/PostEmpSalarySetups")]
        public EmployeeSalarySetupResponse PostEmpSalarySetups(PostSalarySetups data)
        {
            EmployeeSalarySetupResponse SR = new EmployeeSalarySetupResponse();
            try
            {
                int empid = data.empid;
                string Details = JsonConvert.SerializeObject(data.list);
                db.HRP_Cnf_SalarySetup_Save(empid, Details);
                SR.SalList= db.HRP_Cnf_SalarySetup_GetAll(empid).ToList();
                SR.status = 1; SR.message = "Salary Configured Successfully!!";

                return SR;
            }
            catch (Exception ex)
            {
                SR.message = "Error Occured in Configuring Salary Details"; SR.status = 0;
                return SR;
            }
        }

        public class EmployeeSalarySetupResponse
        {
            public int status { get; set; }
            public List<HRP_Cnf_SalarySetup_GetAll_Result> SalList { get; set; }
            public string message = "";
        }
       
        public class PostSalarySetups
        {
            public List<HRP_Cnf_SalarySetup_GetAll_Result> list { get; set; }
            public int empid { get; set; }
        }

        #endregion

        #region SalaryIncrement

        [HttpGet]
        [Route("api/GetSalaryIncrementInitialMasters")]
        public InitialMasters GetSalaryIncrementInitialMasters()
        {
            InitialMasters SR = new InitialMasters();          
            try
            {
                SR.status = 1;
                SR.departments = db.HRP_Mst_Departments_GetAllActive().ToList();
                SR.designations = db.HRP_Mst_Designation_GetAll_Active().ToList();
                SR.employees = db.HRP_Mst_Employee_GetAll_ForSalhike().ToList();
                SR.worklocations = db.HRP_Mst_WorkLocation_GetAllActive().ToList();
                SR.salarycomponents = db.HRP_Mst_SalaryComponents_GetAllActive().ToList();
                SR.salarysetups = db.HRP_Cnf_SalarySetup_GetAll_Forhike().ToList();
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Masters Data!";  SR.status = 0;
                return SR;
            }
        }

        [HttpPost]
        [Route("api/PostEmpSalaryIncrement")]
        public EmployeeSalarySetupResponse PostEmpSalaryIncrement(saveIncrement data)
        {
            EmployeeSalarySetupResponse SR = new EmployeeSalarySetupResponse();
            try
            {
                int salarycomponentid = data.salarycomponentid;
                DateTime effectivedate = data.effectivedate;
                string Details = JsonConvert.SerializeObject(data.list);
                db.HRP_Cnf_SalaryIncrement_Save(effectivedate, salarycomponentid, Details);
                SR.status = 1; SR.message = "Saved Successfully!!";

                return SR;
            }
            catch (Exception ex)
            {
                SR.message = "Error Occured in Configuring Salary Details"; SR.status = 0;
                return SR;
            }
        }




        public class InitialMasters
        {
            public List<HRP_Mst_Designation_GetAll_Active_Result> designations { get; set; }
            public List<HRP_Mst_Departments_GetAllActive_Result> departments { get; set; }
            public List<HRP_Mst_WorkLocation_GetAllActive_Result> worklocations { get; set; }
            public List<HRP_Mst_Employee_GetAll_ForSalhike_Result> employees { get; set; }
            public List<HRP_Mst_SalaryComponents_GetAllActive_Result> salarycomponents { get; set; }
            public List<HRP_Cnf_SalarySetup_GetAll_Forhike_Result> salarysetups { get; set; }
            public int status { get; set; }
            public string message { get; set; }            
        }

        public class saveIncrement
        {
            public int salarycomponentid { get; set; }
            public DateTime effectivedate { get; set; }
            public List<Newsal> list { get; set; }
        }

        public class Newsal
        {
            public int id { get; set; }
            public string empid { get; set; }
            public string empname { get; set; }
            public decimal currAmt { get; set; }
            public decimal newAmt { get; set; }
            public string comments { get; set; }
        }

        #endregion

        #region ShiftConfig
        [HttpGet]
        [Route("api/GetShiftConfigData")]
        public ShiftConfig GetShiftConfigData(int year,int location)
        {
            ShiftConfig SR = new ShiftConfig();
            try
            {
                SR.status = 1;
                SR.head = db.HRP_Cnf_ShiftConfigHead_GetAll(year,location).ToList();
                SR.details = db.HRP_Cnf_ShiftConfigDetails_GetAll(year,location).ToList();
               
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Existing Data!"; SR.status = 0;
                return SR;
            }
        }

        [HttpPost]
        [Route("api/PostShiftConfigData")]
        public ShiftConfig PostShiftConfigData(saveShiftConfig data)
        {
            ShiftConfig SR = new ShiftConfig();
            try
            {
               
                string Details = JsonConvert.SerializeObject(data.details);
                db.HRP_Cnf_ShiftConfig_Save(data.head.year,data.head.workLocation,data.head.startdate,data.head.shiftdays,data.head.startshift, Details);
                SR.status = 1; SR.message = "Saved Successfully!!";

                return SR;
            }
            catch (Exception ex)
            {
                SR.message = "Error Occured in Configuring Shift Details"; SR.status = 0;
                return SR;
            }
        }

        public class saveShiftConfig
        {
            public HRP_Cnf_ShiftConfigHead_GetAll_Result head { get; set; }
            public List<HRP_Cnf_ShiftConfigDetails_GetAll_Result> details { get; set; }
        }

        public class ShiftConfig
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<HRP_Cnf_ShiftConfigHead_GetAll_Result> head { get; set; }
            public List<HRP_Cnf_ShiftConfigDetails_GetAll_Result> details { get; set; }
        }

        #endregion
    }
}
