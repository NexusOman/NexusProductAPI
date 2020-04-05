using NexusProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NexusProductAPI.Controllers.UserModule
{
    public class UserRolesController : ApiController
    {
        NEXUSPRODUCTEntities db = new NEXUSPRODUCTEntities();
        [Route("api/GetAllRoles")]
        public UserRolesResponse GetAllRoles()
        {
            UserRolesResponse SR = new UserRolesResponse();
            List<CMN_Mst_UserRoles_GetAll_Result> Roles = new List<CMN_Mst_UserRoles_GetAll_Result>();
            try
            {
                Roles = db.CMN_Mst_UserRoles_GetAll().ToList();
                if (Roles.Count() > 0)
                {
                    SR.status = 1; SR.Roles = Roles;
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured in fetching Roles"; SR.Roles = Roles; SR.status = 0;
                return SR;
            }
        }


        [HttpPost]
        [Route("api/PostRoles")]
        public UserRolesResponse PostRoles(CMN_Mst_UserRoles_GetAll_Result data)
        {
            UserRolesResponse SR = new UserRolesResponse();
            List<CMN_Mst_UserRoles_GetAll_Result> Roles = new List<CMN_Mst_UserRoles_GetAll_Result>();
            try
            {
                db.CMN_Mst_UserRoles_Save(data.userrolenameen);
                Roles = db.CMN_Mst_UserRoles_GetAll().ToList();
                if (Roles.Count() > 0)
                {
                    SR.status = 1; SR.Roles = Roles; SR.message = "Saved Successfully!!";
                }
                return SR;
            }
            catch
            {
                SR.message = "Error Occured "; SR.Roles = Roles; SR.status = 0;
                return SR;
            }
        }

        public class UserRolesResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<CMN_Mst_UserRoles_GetAll_Result> Roles { get; set; }
        }

    }
}
