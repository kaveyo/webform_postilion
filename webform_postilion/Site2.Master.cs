using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webform_postilion
{
    public partial class Site2 : System.Web.UI.MasterPage
    {
        DateTime time = DateTime.Now;              // Use current time
        string format = "yyyy-MM-dd HH:mm:ss";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Context.Session != null)

            {

                if (Session.IsNewSession)

                {

                    HttpCookie newSessionIdCookie = Request.Cookies["ASP.NET_SessionId"];

                    if (newSessionIdCookie != null)

                    {

                        string newSessionIdCookieValue = newSessionIdCookie.Value;

                        if (newSessionIdCookieValue != string.Empty)

                        {

                            // This means Session was timed Out and New Session was started

                            Response.Redirect("Login.aspx");

                        }

                    }

                }

            }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            ClassDatabase obj = new ClassDatabase();
            ClassDatabase obj2 = new ClassDatabase();
            System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label str3 = Master.FindControl("Label3") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str4 = Master.FindControl("last_row") as System.Web.UI.WebControls.Label;
            String row = (Convert.ToDouble(str4.Text) + 1).ToString();
            String reason = "ACTIVATION OF CARD";

            obj.conn.ConnectionString = obj.locate1;
            obj.conn.Open();

            string insertUser = "update postilion_user_list set last_login = '" + time.ToString(format) + "' where username = '" + str3.Text + "' and branch = '"+str.Text+"'";
            obj.cmd.Connection = obj.conn;
            obj.cmd.CommandText = insertUser;
            obj.cmd.ExecuteNonQuery();
            obj.cmd.CommandTimeout = 60;

            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
            {
                sqlCon.Open();
                string query = "INSERT into postilion_user_log (username , action, date ) VALUES ('" + str3.Text + "', 'LOGGED OUT','" + time + "')";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            obj.conn.Close();
            
            Response.Redirect("Login.aspx");
        }
     }
}