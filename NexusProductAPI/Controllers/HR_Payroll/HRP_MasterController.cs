using NexusProductAPI.Models;
using System.Collections.Generic;
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
                
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Master Data"; SR.WorkLocation = WorkLocations; SR.status = 0;
                return SR;
            }
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

        }

        #endregion
    }
}
