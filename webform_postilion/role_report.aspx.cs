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
                /* ClassDatabase obj = new ClassDatabase();
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
                 *//* ReportDataSource datasource = newReportDataSource("RDLC", ds.Tables[0]);*//*
                 ReportViewer1.LocalReport.DataSources.Clear();
                 ReportViewer1.LocalReport.DataSources.Add(datasource);
                 obj.conn.Close();*/

                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;
                obj.conn.Open();
                //string loadToReport = "SELECT id,branch,checker,CASE WHEN checker = 0 THEN 'MAKER : ACTIVIATE ACCOUNT AND CARD , ADD CUSTOMER TO CARD , CHANGE ACCOUNT PRODUCT ON ACCOUNT' WHEN checker = 1 THEN 'MAKER : ACTIVIATE ACCOUNT AND CARD , ADD CUSTOMER TO CARD , CHANGE ACCOUNT PRODUCT ON ACCOUNT , LINK ACCOUNT TO CARD , PLACE HOLD RESPONSE ON CARD AND ACCOUNT' END AS MAKER,CASE WHEN checker = 0 THEN 'CHECKER : AUTHORISE ALL CHANGES EXCEPT FOR LINKING ACCOUNT AND PLACING HOLD RESPONSES ON ACCOUNT AND CARD' WHEN checker = 1 THEN 'CHECKER : AUTHORISE ALL CHANGES'END AS CHECKER,CASE WHEN checker > -1 THEN 'MANAGES USERS I.E. ADDING , DELELING , UPDATING USER PROFILES AND GENERATE REPORTS' END AS ADMINISTRATOR FROM postilion_branch";

                string loadToReport = "SELECT id,branch,checker,CASE WHEN checker = 0 THEN STUFF((select DISTINCT ',' + action from postilion_role where branch_users = '1' FOR XML PATH('')),1,1,'' ) WHEN checker = 1 THEN STUFF((select DISTINCT ',' + action from postilion_role where convenience_users = '1' FOR XML PATH('')),1,1,'' )  END AS MAKER, CASE WHEN checker = 0 THEN 'CHECKER : AUTHORISE ALL CHANGES MADE BY MAKER IN THE SAME BRANCH' WHEN checker = 1 THEN 'CHECKER : AUTHORISE ALL CHANGES MADE BY MAKER IN THE SAME BRANCH' END AS CHECKER, CASE WHEN checker > -1 THEN  'MANAGES USERS I.E. ADDING , DELELING ,USERS ROLES, UPDATING USER PROFILES AND GENERATE REPORTS' END AS ADMINISTRATOR  FROM postilion_branch";
                SqlCommand cmd = new SqlCommand(loadToReport, obj.conn);
                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                DataTable DataSet01 = new DataTable();
                dataAdp.Fill(DataSet01);
                ReportDataSource datasource = new ReportDataSource("DataSet1", DataSet01);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("role_report.rdlc");
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
                obj.conn.Close();
            }
        }
    }
}