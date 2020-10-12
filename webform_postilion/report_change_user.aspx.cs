using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace webform_postilion
{
    public partial class report_change_user : System.Web.UI.Page
    {
        // Use current time
        string format = "yyyy-MM-dd HH:mm:ss";
        ClassDatabase obj = new ClassDatabase();
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

        public string getbranch()
        {
            System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;

            return str.Text;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
           
            ClassDatabase obj = new ClassDatabase();
            obj.conn.ConnectionString = obj.locate1;

            if (DropDownList2.Text.Substring(0, 3) == "ALL") {
                if (DropDownList1.Text != "") {
                    obj.conn.Open();
                    // SqlDataReader sdr;

                    string loadToReport = "SELECT * FROM postilion_portal_changes where maker = '" + DropDownList1.Text + "'";

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
                    obj.conn.Close();
                }
                else
                {
                    //  MessageBox.Show("Error");
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('SELECT MAKER')", true);

                }
            }
            if(DropDownList2.Text.Substring(0, 3) != "ALL")
            {
                if (DropDownList1.Text != "")
                {
                    obj.conn.Open();
                    // SqlDataReader sdr;

                    string loadToReport = "SELECT * FROM postilion_portal_changes where maker = '" + DropDownList1.Text + "' and branch = '" + DropDownList2.Text.Substring(0, 3) + "'";

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
                    obj.conn.Close();
                }
                else
                {
                   // MessageBox.Show("Error");
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('SELECT MAKER')", true);

                }
            }
        }

       

        protected void Button1_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show(DropDownList2.Text);
            if (DropDownList2.Text.Substring(0, 3) != "ALL") {
                obj.conn.ConnectionString = obj.locate1;
                obj.conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT maker FROM postilion_portal_changes where branch = '" + DropDownList2.Text.Substring(0, 3) + "'", obj.conn);
                DropDownList1.DataSource = cmd.ExecuteReader();

                DropDownList1.DataTextField = "maker";
                DropDownList1.DataValueField = "maker";
                DropDownList1.DataBind();
                obj.conn.Close();
            }
            else
            {
                obj.conn.ConnectionString = obj.locate1;
                obj.conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT DISTINCT maker FROM postilion_portal_changes ", obj.conn);
                DropDownList1.DataSource = cmd.ExecuteReader();

                DropDownList1.DataTextField = "maker";
                DropDownList1.DataValueField = "maker";
                DropDownList1.DataBind();
                obj.conn.Close();
            }
        }
    }
}