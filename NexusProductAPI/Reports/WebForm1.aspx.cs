using Microsoft.Reporting.WebForms;
using NexusProductAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NexusProductAPI.Reports
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        NEXUSPRODUCTEntities db = new NEXUSPRODUCTEntities();
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
                    case "srv":
                        rptVwr.LocalReport.ReportPath = Server.MapPath("print.rdlc");
                        int id= int.Parse(Request["id"].ToString());
                        List<VSR_Trn_ServiceEntryDetails_GetByServeEntryID_Result> ServicePricing = new List<VSR_Trn_ServiceEntryDetails_GetByServeEntryID_Result>();
                        ServicePricing = db.VSR_Trn_ServiceEntryDetails_GetByServeEntryID(id).ToList();
                        dtMainReport = ToDataTable(ServicePricing);
                        datasource = new ReportDataSource("DataSet1", dtMainReport);
                        rptVwr.LocalReport.DataSources.Clear();
                        rptVwr.LocalReport.DataSources.Add(datasource);

                        rptVwr.LocalReport.DisplayName = "Print" ;
                        strRptName = "Print" ;
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

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}