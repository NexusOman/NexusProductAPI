using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NexusProductAPI
{
    public partial class RptTest : System.Web.UI.Page
    {
      
        DataTable dtMainReport = new DataTable();
        ReportDataSource datasource;
        string strRptName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateReport();
            }
        }

        private void GenerateReport()
        {
            try
            {
                rptVwr.ProcessingMode = ProcessingMode.Local;

                switch (Request["rt"].ToString())
                {
                    case "gplrfq":
                        rptVwr.LocalReport.ReportPath = Server.MapPath("gplrfq.rdlc");
                        dtMainReport = (DataTable)HttpContext.Current.Session["Datasource"];
                        datasource = new ReportDataSource("DataSet1", dtMainReport);
                        rptVwr.LocalReport.DataSources.Clear();
                        rptVwr.LocalReport.DataSources.Add(datasource);

                        rptVwr.LocalReport.DisplayName = "GplRFQ_" + dtMainReport.Rows[0]["GplRfqNo"].ToString().Replace("/", "_");
                        strRptName = "GPLRFQ_" + dtMainReport.Rows[0]["GplRfqNo"].ToString().Replace("/", "_");
                        break;
                   

                }

                //crDoc.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                if (Request["ft"].ToString() == "pdf")
                {
                    Warning[] warnings;
                    string[] streamIds;
                    string mimeType = string.Empty;
                    string encoding = string.Empty;
                    string extension = string.Empty;

                    byte[] bytes = rptVwr.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                    // Now that you have all the bytes representing the PDF report, buffer it and send it to the client.
                    Response.Buffer = true;
                    Response.Clear();
                    Response.ContentType = mimeType;
                    //Response.AddHeader("content-disposition", "attachment; filename=" + fileName + "." + extension);
                    Response.AddHeader("content-disposition", "inline; filename=" + strRptName + "." + extension);
                    Response.BinaryWrite(bytes); // create the file
                    Response.Flush(); // send it to the client to download
                }
            }
            catch (Exception ex)
            { }
            finally { }
        }
    }
}