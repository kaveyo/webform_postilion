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
    public partial class User_Listing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                filldrop();

                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;


                obj.conn.Open();
                string loadToReport = "SELECT * FROM postilion_user_list";

                SqlCommand cmd = new SqlCommand(loadToReport, obj.conn);
                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                DataTable DataSet01 = new DataTable();
                dataAdp.Fill(DataSet01);
                ReportDataSource datasource = new ReportDataSource("DataSet2", DataSet01);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("user_list.rdlc");
                /* ReportDataSource datasource = newReportDataSource("RDLC", ds.Tables[0]);*/
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
            }
        }
        private void filldrop()
        {
            DropDownList2.DataSource = getBranches();
            DropDownList2.DataTextField = "branch";
            DropDownList2.DataValueField = "branch";
            DropDownList2.DataBind();

        }

        private DataTable getBranches()
        {
            ClassDatabase obj = new ClassDatabase();


            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM postilion_branch ", sqlCon);

                sqlDa.Fill(dtbl);
                sqlCon.Close();
            }
            dtbl.DefaultView.Sort = "branch ASC";
            return dtbl;
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (DropDownList2.Text.Substring(0, 3) == "ALL")
            {
                // System.Windows.Forms.MessageBox.Show("eecute");
                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;


                obj.conn.Open();
                string loadToReport = "SELECT * FROM postilion_user_list";

                SqlCommand cmd = new SqlCommand(loadToReport, obj.conn);
                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                DataTable DataSet01 = new DataTable();
                dataAdp.Fill(DataSet01);
                ReportDataSource datasource = new ReportDataSource("DataSet2", DataSet01);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("user_list.rdlc");
                /* ReportDataSource datasource = newReportDataSource("RDLC", ds.Tables[0]);*/
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);

            }
            else if (DropDownList2.Text.Substring(0, 3) != "ALL")
            {
                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;

                obj.conn.Open();
                // SqlDataReader sdr;

                string loadToReport = "SELECT * FROM postilion_user_list where branch ='" + DropDownList2.Text.Substring(0, 3) + "' ";

                SqlCommand cmd = new SqlCommand(loadToReport, obj.conn);
                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                DataTable DataSet01 = new DataTable();
                dataAdp.Fill(DataSet01);
                ReportDataSource datasource = new ReportDataSource("DataSet2", DataSet01);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("user_list.rdlc");
                /*   ReportDataSource datasource = newReportDataSource("RDLC", ds.Tables[0]);*/
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
            }
        }
    }
}