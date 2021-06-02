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
    public partial class Roles : System.Web.UI.Page
    {
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
        protected void Button4_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow gvrow in GridView1.Rows)
            {
                CheckBox chk = ((CheckBox)gvrow.FindControl("CheckBox1") as CheckBox);
                CheckBox chk2 = ((CheckBox)gvrow.FindControl("CheckBox2") as CheckBox);
                if (chk.Checked)
                {
                    if (gvrow.Cells[0].Text != "-1")
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_role SET ["+DropDownList2.Text.Trim()+"] = '1' where id = '" + gvrow.Cells[0].Text + "'";

                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();

                        }
                    }
                    else
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_role SET ["+DropDownList2.Text.Trim()+"] = '1' where id <> '-1'";

                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();

                        }
                    }
                }
                if (!chk.Checked)
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_role SET ["+DropDownList2.Text.Trim()+"] = '0' where id = '" + gvrow.Cells[0].Text + "'";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                    }
                }
              /*  if (chk2.Checked)
                {
                    if (gvrow.Cells[0].Text != "-1")
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_role SET convenience_users = '1' where id = '" + gvrow.Cells[0].Text + "'";

                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_role SET convenience_users = '1' where id <> '-1'";

                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();

                        }
                    }
                }
                if (!chk2.Checked)
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_role SET convenience_users = '0' where id = '" + gvrow.Cells[0].Text + "'";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                   }
                }*/

            }
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('SAVED !')", true);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
            {
                sqlCon.Open();
             // SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT id,action,'" + DropDownList2.Text+"' FROM postilion_role", sqlCon);
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM postilion_role", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                GridView1.DataSource = dtbl;
                GridView1.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                GridView1.DataSource = dtbl;
                GridView1.DataBind();
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                GridView1.Rows[0].Cells[0].Text = "No Data Found ..!";
                GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }
    }
}