using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NexusProductAPI.Models;
using System.IO;
namespace NexusProductAPI.Controllers.Common
{
    public class CommonController : ApiController
    {
        NEXUSPRODUCTEntities db = new NEXUSPRODUCTEntities();


        [HttpPost]
        [Route("api/GenFileUpload")]
        public FileUploadResponse GenFileUpload()
        {
            try
            {
                string filename = "";
                int iUploadedCnt = 0;
                System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
                System.Web.HttpPostedFile hpf;

                // DEFINE THE PATH WHERE WE WANT TO SAVE THE FILES.
                string srvPath = "", sPath = "", modulePath = "";
                modulePath = System.Web.HttpContext.Current.Request.Params["modulePath"]?.ToString().Trim() ?? string.Empty;
                modulePath = modulePath.Trim() == "/" ? "\\" : modulePath.Replace("/", "\\") + "\\";
                srvPath = System.Web.Hosting.HostingEnvironment.MapPath("~/");
                sPath = srvPath + "GenFileUpload" + modulePath;

                if (!(Directory.Exists(sPath)))
                {
                    Directory.CreateDirectory(sPath);
                }

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

    }

    public class FileUploadResponse
    {
        public int status { get; set; }
        public string filename { get; set; }
        public string Message { get; set; }
    }
}
