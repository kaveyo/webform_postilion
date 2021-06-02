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
    public partial class Manage_Branchs : System.Web.UI.Page
    {

        ClassDatabase obj = new ClassDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_grid();

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
        private void Load_grid()
        {
            obj.conn.ConnectionString = obj.locate1;
            obj.conn.Open();
          
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM postilion_branch", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {

                dtbl.DefaultView.Sort = "branch ASC";
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
            obj.conn.Close();
        }

        private void Load_grid2(string branch)
        {
            obj.conn.ConnectionString = obj.locate1;
            obj.conn.Open();

            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM postilion_branch where branch = '"+branch+"'", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {

                dtbl.DefaultView.Sort = "branch ASC";
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
            obj.conn.Close();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           // obj.conn.ConnectionString = obj.locate1;
          //  obj.conn.Open();
            if (e.CommandName.Equals("accept2"))
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());

                if (GridView1.Rows[crow].Cells[3].Text.Trim() == "0")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_branch SET checker = '1' where id = '"+ GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                        //  MessageBox.Show("EDITED CARD INSTANT");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('UPDATED !')", true);
                       
                    }

                    Load_grid();
                }
                else
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_branch SET checker = '0' where id = '" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                        //  MessageBox.Show("EDITED CARD INSTANT");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('UPDATED !')", true);
                        
                    }

                    Load_grid();
                }
            }
            obj.conn.Close();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Load_grid2(DropDownList2.Text.Trim());
        }
    }
    
}