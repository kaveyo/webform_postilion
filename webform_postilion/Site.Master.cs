using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using System.Data;

using System.IO;

using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using System.Web.Configuration;

namespace webform_postilion
{
   
    public partial class SiteMaster : MasterPage
    {
        ClassDatabase obj = new ClassDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
           
                List<Model.postilion_role> objlt = (List<Model.postilion_role>)Session["Roles"];

                Console.WriteLine(objlt);

            if (HttpContext.Current.Session["Roles"]  != null)
            {
                var list2 = HttpContext.Current.Session["Roles"] as List<Model.postilion_role>;

              //  System.Diagnostics.Debug.WriteLine("Cats1>>" + list2[0].id + list2[0].convenience_users);

            }
           

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


            if (Label2.Text != "" && Label2.Text == "MAKER")
            {
          
                HyperLink5.Enabled = false;             
               // HyperLink7.Enabled = false;
                //  Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme_site()", true);
            }
            if (Label2.Text != "" && Label2.Text == "CHECKER")
            {
              /*  HyperLink1.Enabled = false;
                HyperLink2.Enabled = false;
                HyperLink3.Enabled = false;
                HyperLink4.Enabled = false;*/
                HyperLink5.Enabled = false;
             
            }
           /* if (Label2.Text == "ADMIN")
            {
                checker_label.Text = "ADMIN";
                HyperLink1.Enabled = false;
                HyperLink2.Enabled = false;
                HyperLink3.Enabled = false;
                HyperLink4.Enabled = false;
                HyperLink7.Enabled = false;
             
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "admin()", true);
            }*/
            if (IsPostBack)
            {
                
                if (Label2.Text != "" && Label2.Text == "MAKER")
            {
             
                    HyperLink5.Enabled = false;
                 //   HyperLink6.Enabled = false;
                   // HyperLink7.Enabled = false;
                    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme_site()", true);
                }
            if (Label2.Text != "" && Label2.Text == "CHECKER")
                {
                    /*HyperLink1.Enabled = false;
                    HyperLink2.Enabled = false;
                    HyperLink3.Enabled = false;
                    HyperLink4.Enabled = false;*/
                    HyperLink5.Enabled = false;
                 //   HyperLink6.Enabled = false;
                    // Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme2()", true);
                }
           /* if (Label2.Text == "ADMIN")
            {
                checker_label.Text = "ADMIN";
                    HyperLink1.Enabled = false;
                    HyperLink2.Enabled = false;
                    HyperLink3.Enabled = false;
                    HyperLink4.Enabled = false;
                    HyperLink7.Enabled = false;
                  
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "admin()", true);
                }*/
            }
            if (!IsPostBack)
            {

                if (Session["major_branch"].ToString() != "")
                {
                    major_branch.Text = Session["major_branch"].ToString();
                }

                if (Session["User"].ToString() != "" && Session["role"].ToString() != "" )
                {
                    Label2.Text = Session["role"].ToString();
                    Label3.Text = Session["User"].ToString();
                   
                    checker_label.Text = Session["checker_label"].ToString();
                    
                    branch_label.Text = Session["branch"].ToString();
                    


                if (Label2.Text != "" && Label2.Text == "MAKER")
                {
                
                    HyperLink5.Enabled = false;
                  //  HyperLink6.Enabled = false;
                     //   HyperLink7.Enabled = false;
                        //  Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme_site()", true);
                    }
                if (Label2.Text != "" && Label2.Text == "CHECKER")
                {
                    /*HyperLink1.Enabled = false;
                    HyperLink2.Enabled = false;
                    HyperLink3.Enabled = false;
                    HyperLink4.Enabled = false;*/
                    HyperLink5.Enabled = false;
                 //   HyperLink6.Enabled = false;
                    // Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme2()", true);
                }

               /* if (Label2.Text != "" && Label2.Text == "ADMIN")
                {
                    checker_label.Text = "ADMIN";
                    HyperLink1.Enabled = false;
                    HyperLink2.Enabled = false;
                    HyperLink3.Enabled = false;
                    HyperLink4.Enabled = false;
                        HyperLink7.Enabled = false;
                       
                        //   Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "admin()", true);
                    }*/
            }
               
                try
                {
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();

                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand(" SELECT TOP 1 * FROM postilion_portal_changes ORDER BY id DESC", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {

                            last_row.Text = (sdr["id"].ToString());

                        }

                    }

                    obj.conn.Close();
                }
                catch (Exception ex)
                {
                   Console.WriteLine( ex.StackTrace);
                }

               
            }
        }
        protected void login_ServerClick(object sender, EventArgs e)
        {
            
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            DateTime time = DateTime.Now;              // Use current time
            string format = "yyyy-MM-dd HH:mm:ss";

            ClassDatabase obj = new ClassDatabase();
            ClassDatabase obj2 = new ClassDatabase();
          
            obj.conn.ConnectionString = obj.locate1;
            obj.conn.Open();

            string insertUser = "update postilion_user_list set last_login = '" + time.ToString(format) + "' where username = '" + Label3.Text + "' and branch = '"+branch_label.Text+"'";
            obj.cmd.Connection = obj.conn;
            obj.cmd.CommandText = insertUser;
            obj.cmd.ExecuteNonQuery();
            obj.cmd.CommandTimeout = 60;

           
            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
            {
                sqlCon.Open();
                string query = "INSERT into postilion_user_log (username , action, date ) VALUES ('" + Label3.Text + "', 'LOGGED OUT','" + time + "')";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                sqlCon.Close();
            }
            obj.conn.Close();
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}