using NexusProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NexusProductAPI.Controllers.UserModule
{
    public class LoginController : ApiController
    {
        NEXUSPRODUCTEntities db = new NEXUSPRODUCTEntities();
        [Route("api/Login")]
        public LoginResponse GET(string UserName, string Password)
        {
            LoginResponse LR = new LoginResponse();
            List<CMN_Mst_User_Authenticate_Result> UserDetail = new List<CMN_Mst_User_Authenticate_Result>();
            try
            {
                UserDetail = db.CMN_Mst_User_Authenticate(UserName, Password).ToList();
                if (UserDetail.Count() > 0)
                {
                    LR.status = 1; LR.UserDetails = UserDetail;
                }
                return LR;
            }
            catch
            {
                LR.message = "Not a Valid User"; LR.UserDetails = UserDetail; LR.status = 0;
                return LR;
            }
        }

        public class LoginResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public List<CMN_Mst_User_Authenticate_Result> UserDetails { get; set; }
        }
    }
}
