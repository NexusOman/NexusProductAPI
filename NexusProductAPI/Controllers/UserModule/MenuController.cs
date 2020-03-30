using NexusProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NexusProductAPI.Controllers.UserModule
{
    public class MenuController : ApiController
    {
        NEXUSPRODUCTEntities db = new NEXUSPRODUCTEntities();
        #region Menus
        [Route("api/getMenuDetails")]
        public MenuResponse getMenuDetails()
        {
            try
            {

                MenuResponse SR = new MenuResponse();
                SR.Modules = db.CMN_Utl_Modules_GetAll().ToList();
                SR.Menus = db.CMN_Utl_Menu_GetAll().ToList();
                SR.MenuItems = db.CMN_Utl_MenuItems_GetAll().ToList();                
                SR.status = 1;
                return SR;
            }
            catch (Exception Ex)
            {
                MenuResponse SR = new MenuResponse();
                SR.status = 0;
                SR.message = "Some Error Occured while Fetching Initial Data";
                return SR;
            }
        }


        public class MenuResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<CMN_Utl_Modules_GetAll_Result> Modules { get; set; }
            public List<CMN_Utl_Menu_GetAll_Result> Menus { get; set; }
            public List<CMN_Utl_MenuItems_GetAll_Result> MenuItems { get; set; }
        }
        #endregion
    }
}
