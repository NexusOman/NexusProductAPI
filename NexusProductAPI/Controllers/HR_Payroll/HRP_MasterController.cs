using Newtonsoft.Json;
using NexusProductAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Http;

namespace NexusProductAPI.Controllers.HR_Payroll
{
    public class HRP_MasterController : ApiController
    {
        NEXUSPRODUCTEntities db = new NEXUSPRODUCTEntities();
        #region BloodGroups
        [Route("api/GetBloodGroups")]
        public BloodGroupResponse GetBloodGroups()
        {
            BloodGroupResponse SR = new BloodGroupResponse();
            List<HRP_Mst_BloodGroups_GetAll_Result> BloodGroup = new List<HRP_Mst_BloodGroups_GetAll_Result>();
            try
            {
                BloodGroup = db.HRP_Mst_BloodGroups_GetAll().ToList();
                if (BloodGroup.Count() > 0)
                {
                    SR.status = 1; SR.BloodGroups = BloodGroup;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Service Types"; SR.BloodGroups = BloodGroup; SR.status = 0;
                return SR;
            }
        }


        [HttpPost]
        [Route("api/PostBloodGroups")]
        public BloodGroupResponse PostBloodGroups(HRP_Mst_BloodGroups_GetAll_Result data)
        {
            BloodGroupResponse SR = new BloodGroupResponse();
            List<HRP_Mst_BloodGroups_GetAll_Result> BloodGroup = new List<HRP_Mst_BloodGroups_GetAll_Result>();
            try
            {
                db.HRP_Mst_BloodGroups_Save(data.bgcode, data.bgcodeName, data.id);
                BloodGroup = db.HRP_Mst_BloodGroups_GetAll().ToList();
                if (BloodGroup.Count() > 0)
                {
                    SR.status = 1; SR.BloodGroups = BloodGroup; SR.message = "Saved Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.BloodGroups = BloodGroup; SR.status = 0;
                return SR;
            }
        }

        [HttpPost]
        [Route("api/DeleteBloodGroups")]
        public BloodGroupResponse DeleteBloodGroups(HRP_Mst_BloodGroups_GetAll_Result data)
        {
            BloodGroupResponse SR = new BloodGroupResponse();
            List<HRP_Mst_BloodGroups_GetAll_Result> BloodGroup = new List<HRP_Mst_BloodGroups_GetAll_Result>();
            try
            {
                db.HRP_Mst_BloodGroups_Delete(data.id);
                BloodGroup = db.HRP_Mst_BloodGroups_GetAll().ToList();
                if (BloodGroup.Count() > 0)
                {
                    SR.status = 1; SR.BloodGroups = BloodGroup; SR.message = "Deleted Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.BloodGroups = BloodGroup; SR.status = 0;
                return SR;
            }
        }
        public class BloodGroupResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<HRP_Mst_BloodGroups_GetAll_Result> BloodGroups { get; set; }
        }

        #endregion

        #region Country
        [Route("api/GetCountry")]
        public CountryResponse GetCountry()
        {
            CountryResponse SR = new CountryResponse();
            List<HRP_Mst_Country_GetAll_Result> Countrys = new List<HRP_Mst_Country_GetAll_Result>();
            try
            {
                Countrys = db.HRP_Mst_Country_GetAll().ToList();
                if (Countrys.Count() > 0)
                {
                    SR.status = 1; SR.Country = Countrys;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Service Types"; SR.Country = Countrys; SR.status = 0;
                return SR;
            }
        }


        [HttpPost]
        [Route("api/PostCountry")]
        public CountryResponse PostCountry(HRP_Mst_Country_GetAll_Result data)
        {
            CountryResponse SR = new CountryResponse();
            List<HRP_Mst_Country_GetAll_Result> Countrys = new List<HRP_Mst_Country_GetAll_Result>();
            try
            {
                db.HRP_Mst_Country_Save(data.countrycode, data.countryname, data.id);
                Countrys = db.HRP_Mst_Country_GetAll().ToList();
                if (Countrys.Count() > 0)
                {
                    SR.status = 1; SR.Country = Countrys; SR.message = "Saved Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.Country = Countrys; SR.status = 0;
                return SR;
            }
        }

        [HttpPost]
        [Route("api/DeleteCountry")]
        public CountryResponse DeleteCountry(HRP_Mst_Country_GetAll_Result data)
        {
            CountryResponse SR = new CountryResponse();
            List<HRP_Mst_Country_GetAll_Result> Countrys = new List<HRP_Mst_Country_GetAll_Result>();
            try
            {
                db.HRP_Mst_Country_Delete(data.id);
                Countrys = db.HRP_Mst_Country_GetAll().ToList();
                if (Countrys.Count() > 0)
                {
                    SR.status = 1; SR.Country = Countrys; SR.message = "Deleted Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.Country = Countrys; SR.status = 0;
                return SR;
            }
        }
        public class CountryResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<HRP_Mst_Country_GetAll_Result> Country { get; set; }
        }


        #endregion

        #region Designation
        [Route("api/GetDesignation")]
        public DesignationResponse GetDesignation()
        {
            DesignationResponse SR = new DesignationResponse();
            List<HRP_Mst_Designation_GetAll_Result> Designations = new List<HRP_Mst_Designation_GetAll_Result>();
            try
            {
                Designations = db.HRP_Mst_Designation_GetAll().ToList();
                if (Designations.Count() > 0)
                {
                    SR.status = 1; SR.Designation = Designations;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Designations"; SR.Designation = Designations; SR.status = 0;
                return SR;
            }
        }


        [HttpPost]
        [Route("api/PostDesignation")]
        public DesignationResponse PostDesignation(HRP_Mst_Designation_GetAll_Result data)
        {
            DesignationResponse SR = new DesignationResponse();
            List<HRP_Mst_Designation_GetAll_Result> Designations = new List<HRP_Mst_Designation_GetAll_Result>();
            try
            {
                db.HRP_Mst_Designation_Save(data.designationcode, data.designationname, data.id);
                Designations = db.HRP_Mst_Designation_GetAll().ToList();
                if (Designations.Count() > 0)
                {
                    SR.status = 1; SR.Designation = Designations; SR.message = "Saved Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.Designation = Designations; SR.status = 0;
                return SR;
            }
        }

        [HttpPost]
        [Route("api/DeleteDesignation")]
        public DesignationResponse DeleteDesignation(HRP_Mst_Designation_GetAll_Result data)
        {
            DesignationResponse SR = new DesignationResponse();
            List<HRP_Mst_Designation_GetAll_Result> Designations = new List<HRP_Mst_Designation_GetAll_Result>();
            try
            {
                db.HRP_Mst_Designation_Delete(data.id);
                Designations = db.HRP_Mst_Designation_GetAll().ToList();
                if (Designations.Count() > 0)
                {
                    SR.status = 1; SR.Designation = Designations; SR.message = "Deleted Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.Designation = Designations; SR.status = 0;
                return SR;
            }
        }
        public class DesignationResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<HRP_Mst_Designation_GetAll_Result> Designation { get; set; }
        }


        #endregion

        #region Departments
        [Route("api/GetDepartments")]
        public DepartmentsResponse GetDepartments()
        {
            DepartmentsResponse SR = new DepartmentsResponse();
            List<HRP_Mst_Departments_GetAll_Result> Departmentss = new List<HRP_Mst_Departments_GetAll_Result>();
            try
            {
                Departmentss = db.HRP_Mst_Departments_GetAll().ToList();
                if (Departmentss.Count() > 0)
                {
                    SR.status = 1; SR.Departments = Departmentss;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Departmentss"; SR.Departments = Departmentss; SR.status = 0;
                return SR;
            }
        }


        [HttpPost]
        [Route("api/PostDepartments")]
        public DepartmentsResponse PostDepartments(HRP_Mst_Departments_GetAll_Result data)
        {
            DepartmentsResponse SR = new DepartmentsResponse();
            List<HRP_Mst_Departments_GetAll_Result> Departmentss = new List<HRP_Mst_Departments_GetAll_Result>();
            try
            {
                db.HRP_Mst_Departments_Save(data.departmentcode, data.departmentname, data.id);
                Departmentss = db.HRP_Mst_Departments_GetAll().ToList();
                if (Departmentss.Count() > 0)
                {
                    SR.status = 1; SR.Departments = Departmentss; SR.message = "Saved Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.Departments = Departmentss; SR.status = 0;
                return SR;
            }
        }

        [HttpPost]
        [Route("api/DeleteDepartments")]
        public DepartmentsResponse DeleteDepartments(HRP_Mst_Departments_GetAll_Result data)
        {
            DepartmentsResponse SR = new DepartmentsResponse();
            List<HRP_Mst_Departments_GetAll_Result> Departmentss = new List<HRP_Mst_Departments_GetAll_Result>();
            try
            {
                db.HRP_Mst_Departments_Delete(data.id);
                Departmentss = db.HRP_Mst_Departments_GetAll().ToList();
                if (Departmentss.Count() > 0)
                {
                    SR.status = 1; SR.Departments = Departmentss; SR.message = "Deleted Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.Departments = Departmentss; SR.status = 0;
                return SR;
            }
        }
        public class DepartmentsResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<HRP_Mst_Departments_GetAll_Result> Departments { get; set; }
        }


        #endregion

        #region Bank
        [Route("api/GetBank")]
        public BankResponse GetBank()
        {
            BankResponse SR = new BankResponse();
            List<HRP_Mst_Bank_GetAll_Result> Banks = new List<HRP_Mst_Bank_GetAll_Result>();
            try
            {
                Banks = db.HRP_Mst_Bank_GetAll().ToList();
                if (Banks.Count() > 0)
                {
                    SR.status = 1; SR.Bank = Banks;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Banks"; SR.Bank = Banks; SR.status = 0;
                return SR;
            }
        }


        [HttpPost]
        [Route("api/PostBank")]
        public BankResponse PostBank(HRP_Mst_Bank_GetAll_Result data)
        {
            BankResponse SR = new BankResponse();
            List<HRP_Mst_Bank_GetAll_Result> Banks = new List<HRP_Mst_Bank_GetAll_Result>();
            try
            {
                db.HRP_Mst_Bank_Save(data.bankcode, data.bankname, data.id);
                Banks = db.HRP_Mst_Bank_GetAll().ToList();
                if (Banks.Count() > 0)
                {
                    SR.status = 1; SR.Bank = Banks; SR.message = "Saved Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.Bank = Banks; SR.status = 0;
                return SR;
            }
        }

        [HttpPost]
        [Route("api/DeleteBank")]
        public BankResponse DeleteBank(HRP_Mst_Bank_GetAll_Result data)
        {
            BankResponse SR = new BankResponse();
            List<HRP_Mst_Bank_GetAll_Result> Banks = new List<HRP_Mst_Bank_GetAll_Result>();
            try
            {
                db.HRP_Mst_Bank_Delete(data.id);
                Banks = db.HRP_Mst_Bank_GetAll().ToList();
                if (Banks.Count() > 0)
                {
                    SR.status = 1; SR.Bank = Banks; SR.message = "Deleted Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.Bank = Banks; SR.status = 0;
                return SR;
            }
        }
        public class BankResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<HRP_Mst_Bank_GetAll_Result> Bank { get; set; }
        }


        #endregion

        #region EmpDocs
        [Route("api/GetEmpDocs")]
        public EmpDocsResponse GetEmpDocs()
        {
            EmpDocsResponse SR = new EmpDocsResponse();
            List<HRP_Mst_EmpDocs_GetAll_Result> EmpDocss = new List<HRP_Mst_EmpDocs_GetAll_Result>();
            try
            {
                EmpDocss = db.HRP_Mst_EmpDocs_GetAll().ToList();
                if (EmpDocss.Count() > 0)
                {
                    SR.status = 1; SR.EmpDocs = EmpDocss;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Employee Document Types"; SR.EmpDocs = EmpDocss; SR.status = 0;
                return SR;
            }
        }


        [HttpPost]
        [Route("api/PostEmpDocs")]
        public EmpDocsResponse PostEmpDocs(HRP_Mst_EmpDocs_GetAll_Result data)
        {
            EmpDocsResponse SR = new EmpDocsResponse();
            List<HRP_Mst_EmpDocs_GetAll_Result> EmpDocss = new List<HRP_Mst_EmpDocs_GetAll_Result>();
            try
            {
                db.HRP_Mst_EmpDocs_Save(data.empdoccode, data.empdocname, data.id);
                EmpDocss = db.HRP_Mst_EmpDocs_GetAll().ToList();
                if (EmpDocss.Count() > 0)
                {
                    SR.status = 1; SR.EmpDocs = EmpDocss; SR.message = "Saved Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.EmpDocs = EmpDocss; SR.status = 0;
                return SR;
            }
        }

        [HttpPost]
        [Route("api/DeleteEmpDocs")]
        public EmpDocsResponse DeleteEmpDocs(HRP_Mst_EmpDocs_GetAll_Result data)
        {
            EmpDocsResponse SR = new EmpDocsResponse();
            List<HRP_Mst_EmpDocs_GetAll_Result> EmpDocss = new List<HRP_Mst_EmpDocs_GetAll_Result>();
            try
            {
                db.HRP_Mst_EmpDocs_Delete(data.id);
                EmpDocss = db.HRP_Mst_EmpDocs_GetAll().ToList();
                if (EmpDocss.Count() > 0)
                {
                    SR.status = 1; SR.EmpDocs = EmpDocss; SR.message = "Deleted Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.EmpDocs = EmpDocss; SR.status = 0;
                return SR;
            }
        }
        public class EmpDocsResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<HRP_Mst_EmpDocs_GetAll_Result> EmpDocs { get; set; }
        }


        #endregion

        #region Subcontractors
        [Route("api/GetSubcontractors")]
        public SubcontractorsResponse GetSubcontractors()
        {
            SubcontractorsResponse SR = new SubcontractorsResponse();
            List<HRP_Mst_Subcontractors_GetAll_Result> Subcontractorss = new List<HRP_Mst_Subcontractors_GetAll_Result>();
            try
            {
                Subcontractorss = db.HRP_Mst_Subcontractors_GetAll().ToList();
                if (Subcontractorss.Count() > 0)
                {
                    SR.status = 1; SR.Subcontractors = Subcontractorss;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Employee Document Types"; SR.Subcontractors = Subcontractorss; SR.status = 0;
                return SR;
            }
        }


        [HttpPost]
        [Route("api/PostSubcontractors")]
        public SubcontractorsResponse PostSubcontractors(HRP_Mst_Subcontractors_GetAll_Result data)
        {
            SubcontractorsResponse SR = new SubcontractorsResponse();
            List<HRP_Mst_Subcontractors_GetAll_Result> Subcontractorss = new List<HRP_Mst_Subcontractors_GetAll_Result>();
            try
            {
                db.HRP_Mst_Subcontractors_Save(data.subcontractorcode, data.subcontractorname,data.contactperson,data.contactnumber,data.contactemail, data.id);
                Subcontractorss = db.HRP_Mst_Subcontractors_GetAll().ToList();
                if (Subcontractorss.Count() > 0)
                {
                    SR.status = 1; SR.Subcontractors = Subcontractorss; SR.message = "Saved Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.Subcontractors = Subcontractorss; SR.status = 0;
                return SR;
            }
        }

        [HttpPost]
        [Route("api/DeleteSubcontractors")]
        public SubcontractorsResponse DeleteSubcontractors(HRP_Mst_Subcontractors_GetAll_Result data)
        {
            SubcontractorsResponse SR = new SubcontractorsResponse();
            List<HRP_Mst_Subcontractors_GetAll_Result> Subcontractorss = new List<HRP_Mst_Subcontractors_GetAll_Result>();
            try
            {
                db.HRP_Mst_Subcontractors_Delete(data.id);
                Subcontractorss = db.HRP_Mst_Subcontractors_GetAll().ToList();
                if (Subcontractorss.Count() > 0)
                {
                    SR.status = 1; SR.Subcontractors = Subcontractorss; SR.message = "Deleted Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.Subcontractors = Subcontractorss; SR.status = 0;
                return SR;
            }
        }
        public class SubcontractorsResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<HRP_Mst_Subcontractors_GetAll_Result> Subcontractors { get; set; }
        }


        #endregion

        #region WorkLocation
        [Route("api/GetWorkLocation")]
        public WorkLocationResponse GetWorkLocation()
        {
            WorkLocationResponse SR = new WorkLocationResponse();
            List<HRP_Mst_WorkLocation_GetAll_Result> WorkLocations = new List<HRP_Mst_WorkLocation_GetAll_Result>();
            try
            {
                WorkLocations = db.HRP_Mst_WorkLocation_GetAll().ToList();
                if (WorkLocations.Count() > 0)
                {
                    SR.status = 1; SR.WorkLocation = WorkLocations;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Employee Document Types"; SR.WorkLocation = WorkLocations; SR.status = 0;
                return SR;
            }
        }


        [HttpPost]
        [Route("api/PostWorkLocation")]
        public WorkLocationResponse PostWorkLocation(HRP_Mst_WorkLocation_GetAll_Result data)
        {
            WorkLocationResponse SR = new WorkLocationResponse();
            List<HRP_Mst_WorkLocation_GetAll_Result> WorkLocations = new List<HRP_Mst_WorkLocation_GetAll_Result>();
            try
            {
                db.HRP_Mst_WorkLocation_Save(data.worklocationcode, data.worklocationname, data.contactperson, data.contactnumber, data.contactemail, data.id);
                WorkLocations = db.HRP_Mst_WorkLocation_GetAll().ToList();
                if (WorkLocations.Count() > 0)
                {
                    SR.status = 1; SR.WorkLocation = WorkLocations; SR.message = "Saved Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.WorkLocation = WorkLocations; SR.status = 0;
                return SR;
            }
        }

        [HttpPost]
        [Route("api/DeleteWorkLocation")]
        public WorkLocationResponse DeleteWorkLocation(HRP_Mst_WorkLocation_GetAll_Result data)
        {
            WorkLocationResponse SR = new WorkLocationResponse();
            List<HRP_Mst_WorkLocation_GetAll_Result> WorkLocations = new List<HRP_Mst_WorkLocation_GetAll_Result>();
            try
            {
                db.HRP_Mst_WorkLocation_Delete(data.id);
                WorkLocations = db.HRP_Mst_WorkLocation_GetAll().ToList();
                if (WorkLocations.Count() > 0)
                {
                    SR.status = 1; SR.WorkLocation = WorkLocations; SR.message = "Deleted Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.WorkLocation = WorkLocations; SR.status = 0;
                return SR;
            }
        }
        public class WorkLocationResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<HRP_Mst_WorkLocation_GetAll_Result> WorkLocation { get; set; }
        }


        #endregion

        #region EmployeeMaster

        [Route("api/GetMasterLists")]
        public EmployeeInitResponse GetMasterLists()
        {
            EmployeeInitResponse SR = new EmployeeInitResponse();
            List<HRP_Mst_WorkLocation_GetAll_Result> WorkLocations = new List<HRP_Mst_WorkLocation_GetAll_Result>();
            try
            {
                WorkLocations = db.HRP_Mst_WorkLocation_GetAll().ToList();
                if (WorkLocations.Count() > 0)
                {
                    SR.status = 1; SR.WorkLocation = WorkLocations;
                }
                SR.Bank = db.HRP_Mst_Bank_GetAll().ToList();
                SR.BloodGroups = db.HRP_Mst_BloodGroups_GetAll().ToList();
                SR.Country = db.HRP_Mst_Country_GetAll().ToList();
                SR.Departments = db.HRP_Mst_Departments_GetAll().ToList();
                SR.Designation = db.HRP_Mst_Designation_GetAll().ToList();
                SR.Subcontractors = db.HRP_Mst_Subcontractors_GetAll().ToList();
                SR.Employees = db.HRP_Mst_Employee_GetAll().ToList();
                SR.doctypes = db.HRP_Mst_EmpDocs_GetAll().ToList();
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Master Data"; SR.WorkLocation = WorkLocations; SR.status = 0;
                return SR;
            }
        }

        [Route("api/GetEmployees")]
        public EmployeeResponse GetEmployees()
        {
            EmployeeResponse SR = new EmployeeResponse();
            List<HRP_Mst_Employee_GetAll_Result> Employees = new List<HRP_Mst_Employee_GetAll_Result>();
            try
            {
                Employees = db.HRP_Mst_Employee_GetAll().ToList();
                if (Employees.Count() > 0)
                {
                    SR.status = 1; SR.employees = Employees;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Employee Document Types"; SR.employees = Employees; SR.status = 0;
                return SR;
            }
        }


        [HttpPost]
        [Route("api/PostEmployees")]
        public EmployeeResponse PostEmployees(HRP_Mst_Employee_GetAll_Result data)
        {
            EmployeeResponse SR = new EmployeeResponse();
            List<HRP_Mst_Employee_GetAll_Result> Employee = new List<HRP_Mst_Employee_GetAll_Result>();
            try
            {

               var queryResult = db.HRP_Mst_Employee_Save(data.empid, data.empname, data.gender, data.nationality, data.primaryidno, DateTime.ParseExact(data.dob, "dd/MM/yyyy", null)
                    , data.phone, data.email, DateTime.ParseExact(data.doj, "dd/MM/yyyy", null), data.designation, data.department, data.worklocation,
                    data.emptype, data.subcontractorid, data.timing, data.reportingto, data.bank, data.branch, data.swiftcode, data.accno,data.bloodgroup, data.id);
                foreach (Nullable<int> result in queryResult)
                    SR.empid = result.Value;
                Employee = db.HRP_Mst_Employee_GetAll().ToList();
                if (Employee.Count() > 0)
                {
                    SR.status = 1; SR.employees = Employee; SR.message = "Saved Successfully!!";
                }
                return SR;
            }
            catch(Exception Ex)
            {
                SR.message = "Error Occured "; SR.employees = Employee; SR.status = 0;
                return SR;
            }
        }

        [HttpPost]
        [Route("api/DeleteEmployee")]
        public EmployeeResponse DeleteEmployee(HRP_Mst_Employee_GetAll_Result data)
        {
            EmployeeResponse SR = new EmployeeResponse();
            List<HRP_Mst_Employee_GetAll_Result> employees = new List<HRP_Mst_Employee_GetAll_Result>();
            try
            {
                db.HRP_Mst_Subcontractors_Delete(data.id);
                employees = db.HRP_Mst_Employee_GetAll().ToList();
                if (employees.Count() > 0)
                {
                    SR.status = 1; SR.employees = employees; SR.message = "Deleted Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.employees = employees; SR.status = 0;
                return SR;
            }
        }

        [HttpGet]
        [Route("api/GetEmployeeDocs")]
        public EmployeeDocumentsResponse GetEmployeeDocs(int id)
        {
            EmployeeDocumentsResponse SR = new EmployeeDocumentsResponse();
            List<HRP_Mst_EmployeeDocuments_GetAll_Result> docs = new List<HRP_Mst_EmployeeDocuments_GetAll_Result>();
            try
            {
                docs = db.HRP_Mst_EmployeeDocuments_GetAll(id).ToList();
               
                    SR.status = 1; SR.DocList = docs;
                
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Employee Documents"; SR.DocList = docs; SR.status = 0;
                return SR;
            }
        }

        [HttpPost]
        [Route("api/PostEmpDocuments")]
        public EmpDocsPostResponse PostEmpDocuments(PostEmployeeDocs data)
        {
            EmpDocsPostResponse SR = new EmpDocsPostResponse();
            try
            {
                int empid = data.empid;
                string Details = JsonConvert.SerializeObject(data.Docs);
                db.HRP_Mst_EmployeeDocuments_Save(empid, Details);
              
                    SR.status = 1;  SR.message = "Documents Saved Successfully!!";
                
                return SR;
            }
            catch(Exception ex)
            {
                SR.message = "Error Occured in Saving Documents"; SR.status = 0;
                return SR;
            }
        }



        public class EmployeeDocumentsResponse
        {
            public int status { get; set; }
            public List<HRP_Mst_EmployeeDocuments_GetAll_Result> DocList { get; set; }
            public string message = "";
        }
        public class EmpDocsPostResponse
        {
            public int status { get; set; }
            public string message { get; set; }
        }

        public class PostEmployeeDocs
        {
            public List<HRP_Mst_EmployeeDocuments_GetAll_Result> Docs { get; set; }
            public int empid { get; set; }
        }

        public class EmployeeInitResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<HRP_Mst_BloodGroups_GetAll_Result> BloodGroups { get; set; }
            public List<HRP_Mst_Country_GetAll_Result> Country { get; set; }
            public List<HRP_Mst_Designation_GetAll_Result> Designation { get; set; }
            public List<HRP_Mst_Departments_GetAll_Result> Departments { get; set; }
            public List<HRP_Mst_Bank_GetAll_Result> Bank { get; set; }
            public List<HRP_Mst_Subcontractors_GetAll_Result> Subcontractors { get; set; }
            public List<HRP_Mst_WorkLocation_GetAll_Result> WorkLocation { get; set; }
            public List<HRP_Mst_Employee_GetAll_Result> Employees { get; set; }
            public List<HRP_Mst_EmpDocs_GetAll_Result> doctypes { get; set; }
        }
        public class EmployeeResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public int empid { get; set; }
            public List<HRP_Mst_Employee_GetAll_Result> employees { get; set; }
        }
        #endregion


        #region FileUpload

        [HttpPost]
        [Route("api/EmpFileUpload")]
        public FileUploadResponse EmpFileUpload()
        {
            try
            {
                string filename = "";
                int iUploadedCnt = 0;
                System.Web.HttpPostedFile hpf;
                // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
                string srvPath = "", sPath = "";
                srvPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");
                sPath = srvPath + "\\" + "EmpDocs\\";
                bool folderExists = Directory.Exists(sPath);
                if (!folderExists)
                    Directory.CreateDirectory(sPath);
                System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
                // CHECK THE FILE COUNT.
                for (int iCnt = 0; iCnt <= hfc.Count - 1; iCnt++)
                {
                    hpf = hfc[iCnt];

                    if (hpf.ContentLength > 0)
                    {
                        // CHECK IF THE SELECTED FILE(S) ALREADY EXISTS IN FOLDER. (AVOID DUPLICATE)
                        if (!File.Exists(sPath + Path.GetFileName(hpf.FileName)))
                        {
                            // SAVE THE FILES IN THE FOLDER.
                            //hpf.SaveAs(sPath + Path.GetFileName(hpf.FileName));
                            string extension = Path.GetExtension(Path.GetFileName(hpf.FileName));
                            filename = System.DateTime.Now.ToString("ddMMyyhhmmss") + extension;
                            hpf.SaveAs(sPath + Path.GetFileName(filename));
                            //fileSave = System.DateTime.Now.ToString("ddMMyyhhmmss") + ".";

                            //filename = sPath + Path.GetFileName(hpf.FileName);

                            iUploadedCnt = iUploadedCnt + 1;
                        }
                    }
                }

                // RETURN A MESSAGE (OPTIONAL).
                if (iUploadedCnt > 0)
                {
                    //return iUploadedCnt + " Files Uploaded Successfully"+ Path.GetFileName(hpf.FileName);
                    FileUploadResponse fr = new FileUploadResponse();
                    fr.filename = filename;
                    fr.status = 1;
                    fr.Message = "File uploaded Successfully!!";
                    return fr;
                }
                else
                {
                    //return "Upload Failed";
                    FileUploadResponse fr = new FileUploadResponse();
                    fr.filename = filename;
                    fr.status = 0;
                    fr.Message = "Upload Failed!!";
                    return fr;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public class FileUploadResponse
        {
            public int status { get; set; }
            public string filename { get; set; }
            public string Message { get; set; }
        }

        #endregion
    }
}
