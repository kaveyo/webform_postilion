using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace webform_postilion
{
    public partial class Report_by_period : System.Web.UI.Page
    {
        string format = "yyyy-MM-dd HH:mm:ss";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                filldrop();
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
            //System.Windows.Forms.MessageBox.Show(datepicker1.Text + datepicker34.Text);
            if(datepicker1.Text == "" && datepicker34.Text == "")
            {
              //  System.Windows.Forms.MessageBox.Show("Error");

                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('Enter date fields')", true);
              //  ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER DATE FIELDS')", true);

            }
            if (DropDownList2.Text.Substring(0, 3) == "ALL" && datepicker1.Text != "" && datepicker34.Text != "" )
            {
               // System.Windows.Forms.MessageBox.Show("eecute");
                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;


                obj.conn.Open();
                string loadToReport = "SELECT * FROM postilion_portal_changes where date between'" + (Convert.ToDateTime(datepicker34.Text)).ToString(format) + "'and '" + (Convert.ToDateTime(datepicker1.Text)).ToString(format) + "'";

                SqlCommand cmd = new SqlCommand(loadToReport, obj.conn);
                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                DataTable DataSet01 = new DataTable();
                dataAdp.Fill(DataSet01);
                ReportDataSource datasource = new ReportDataSource("DataSet1", DataSet01);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report_by_date.rdlc");
                /* ReportDataSource datasource = newReportDataSource("RDLC", ds.Tables[0]);*/
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);

            }
            else if(DropDownList2.Text.Substring(0, 3) != "ALL" && datepicker1.Text != "" && datepicker34.Text != "")
            {
                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;
                
                obj.conn.Open();
                // SqlDataReader sdr;

                string loadToReport = "SELECT * FROM postilion_portal_changes where date between'" + (Convert.ToDateTime(datepicker34.Text)).ToString(format) + "'and '" + (Convert.ToDateTime(datepicker1.Text)).ToString(format) + "' and branch ='"+DropDownList2.Text.Substring(0, 3)+"' ";

                SqlCommand cmd = new SqlCommand(loadToReport, obj.conn);
                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);
                DataTable DataSet01 = new DataTable();
                dataAdp.Fill(DataSet01);
                ReportDataSource datasource = new ReportDataSource("DataSet1", DataSet01);
                ReportViewer1.ProcessingMode = ProcessingMode.Local;
                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Report_by_date.rdlc");
                /*   ReportDataSource datasource = newReportDataSource("RDLC", ds.Tables[0]);*/
                ReportViewer1.LocalReport.DataSources.Clear();
                ReportViewer1.LocalReport.DataSources.Add(datasource);
            }
        }
    }
}