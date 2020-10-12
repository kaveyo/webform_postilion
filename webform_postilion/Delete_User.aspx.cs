using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace webform_postilion
{
    public partial class Delete_User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string DeleteClick( string id)
        {
            //Do your Stuff Here.
               ClassDatabase obj = new ClassDatabase();
               obj.conn.ConnectionString = obj.locate1;
               obj.conn.Open();

                       string insertUser = " delete from postilion_users  where user_id = '" + id + "' ";
                       obj.cmd.Connection = obj.conn;
                       obj.cmd.CommandText = insertUser;
                       obj.cmd.ExecuteNonQuery();
                       obj.cmd.CommandTimeout = 60;

                       obj.conn.Close();

                      

           // MessageBox.Show("Message"+id);
            return "DONE";
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.Equals("accept2"))
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());

                  Response.Redirect("Update_User.aspx?id=" + GridView1.Rows[crow].Cells[0].Text);
                
            }
            if (e.CommandName.Equals("reject2"))
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());

                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "deleted('"+ GridView1.Rows[crow].Cells[0].Text + "');", true);

            }
        }
            protected void Button4_Click(object sender, EventArgs e)
        {
            if (first.Text !="" || surname.Text !="") {
                  ClassDatabase obj = new ClassDatabase();
                  obj.conn.ConnectionString = obj.locate1;
                  obj.conn.Open();
              /*    SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT (*) FROM postilion_users  WHERE first_name = '" + first.Text + "' and last_name = '" + surname.Text + "' ", obj.conn);
                  DataTable dt = new DataTable();
                  adapter.Fill(dt);
                  if (dt.Rows[0][0].ToString() != "0")
                  {
                      string insertUser = " delete from postilion_users  where first_name = '" + first.Text + "' and last_name = '" + surname.Text + "'";
                      obj.cmd.Connection = obj.conn;
                      obj.cmd.CommandText = insertUser;
                      obj.cmd.ExecuteNonQuery();
                      obj.cmd.CommandTimeout = 60;

                      obj.conn.Close();

                      ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER DELETED')", true);

                      first.Text = "";
                      surname.Text = "";
                  }*/
                DataTable dtbl = new DataTable();
                using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM postilion_users where role != 'ADMINISTRATOR' and first_name ='" + first.Text.ToLower() + "' or last_name ='" + surname.Text.ToLower() + "'", sqlCon);
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
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER AT LEAST ONE FIELD')", true);
            }
        }
    }
}