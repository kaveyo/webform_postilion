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
    public partial class ADD_BRANCH : System.Web.UI.Page
    {
        ClassDatabase obj = new ClassDatabase();
        ClassDatabase obj2 = new ClassDatabase();
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
            {
                sqlCon.Open();
                string query = " insert into postilion_branch (branch,checker) values ('" + TextBox3.Text+" "+TextBox1.Text + "','0')";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }

            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
            {
                sqlCon.Open();
                string query = " alter table postilion_role add ["+ TextBox3.Text + " " + TextBox1.Text + "] int default 0 NOT NULL";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }

            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('BRANCH ADDED')", true);

            Button1.Enabled = false;
        }
    }
}