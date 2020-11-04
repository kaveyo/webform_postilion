using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webform_postilion
{
    public partial class role_report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;


                obj.conn.Open();
                string loadToReport = "SELECT * FROM postilion_roles ";

                SqlCommand cmd = new SqlCommand(loadToReport, obj.conn);
                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                DataTable DataSet01 = new DataTable();
                dataAdp.Fill(DataSet01);
                ReportDataSource datasource = new ReportDataSource("DataSet3", DataSet01);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("role_report.rdlc");
                /* ReportDataSource datasource = newReportDataSource("RDLC", ds.Tables[0]);*/
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                obj.conn.Close();
            }
        }
    }
}