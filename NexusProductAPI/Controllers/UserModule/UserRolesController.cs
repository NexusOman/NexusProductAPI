using Newtonsoft.Json;
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

        [HttpPost]
        [Route("api/RoleToMenu")]
        public UserRolesResponse RoleToMenu(PostRoleToMenu data)
        {
            UserRolesResponse SR = new UserRolesResponse();
            List<CMN_Mst_UserRoles_GetAll_Result> Roles = new List<CMN_Mst_UserRoles_GetAll_Result>();
            try
            {
                List<CMN_STN_RoleToMenu_GetAll_Result> RoleToMenu = new List<CMN_STN_RoleToMenu_GetAll_Result>();
                foreach(var row in data.MenuItems)
                {
                    int ModuleID = data.Menu.Find(x => x.id == row.menuID).moduleID;
                    RoleToMenu.Add(new CMN_STN_RoleToMenu_GetAll_Result
                    {
                        RoleID = data.RoleId,
                        MenuItemID = row.id,
                        MenuID = row.menuID,
                        ModuleID=ModuleID,
                        IsView = true
                    });
                }
                foreach(var row in data.Menu)
                {
                    if(row.isdirect==true && row.cchecked==true)
                        {
                        RoleToMenu.Add(new CMN_STN_RoleToMenu_GetAll_Result
                        {
                            RoleID = data.RoleId,
                            MenuItemID = 0,
                            MenuID = row.id,
                            ModuleID = row.moduleID,
                            IsView = true
                        });
                    }
                }
               string Details=  JsonConvert.SerializeObject(RoleToMenu);
                db.CMN_STN_RoleToMenu_Save(data.RoleId,Details);
                Roles = db.CMN_Mst_UserRoles_GetAll().ToList();
                if (Roles.Count() > 0)
                {
                    SR.status = 1; SR.Roles = Roles; SR.message = "Saved Successfully!!";
                }
                return SR;
            }
            catch(Exception ex)
            {
                SR.message = "Error Occured "; SR.Roles = Roles; SR.status = 0;
                return SR;
            }
        }

        [Route("api/GetAllMenusByRole")]
        public MenusByRoleRespone GetAllMenusByRole(int roleid)
        {
            MenusByRoleRespone SR = new MenusByRoleRespone();
            
            try
            {
                SR.status = 1;
                SR.menuItems = db.CMN_Utl_MenuItems_GetAll_ByRoleID(roleid).ToList();
                SR.menus= db.CMN_Utl_Menu_GetAll_ByRoleID(roleid).ToList();
                SR.modules= db.CMN_Utl_Modules_GetAll_ByRoleID(roleid).ToList();
                return SR;
            }
            catch
            {
                SR.message = "Error Occured ";  SR.status = 0;
                return SR;
            }
        }



        public class MenusByRoleRespone
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<CMN_Utl_MenuItems_GetAll_ByRoleID_Result> menuItems { get; set; }
            public List<CMN_Utl_Menu_GetAll_ByRoleID_Result> menus { get; set; }
            public List<CMN_Utl_Modules_GetAll_ByRoleID_Result> modules { get; set; }
        }

        public class PostRoleToMenu
        {
            public int RoleId { get; set; }
            public List<CMN_Utl_MenuItems_GetAll_Result> MenuItems { get; set; }
            public List<CMN_Utl_Menu_GetAll_Result> Menu { get; set; }
         
        }

        public class UserRolesResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<CMN_Mst_UserRoles_GetAll_Result> Roles { get; set; }
        }

    }
}
