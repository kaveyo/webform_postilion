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


namespace webform_postilion
{
    public partial class SiteMaster : MasterPage
    {
        ClassDatabase obj = new ClassDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (Label2.Text != "" && Label2.Text == "MAKER")
            {
          
              //  HyperLink5.Enabled = false;
               // HyperLink6.Enabled = false;
                HyperLink7.Enabled = false;
                //  Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme_site()", true);
            }
            if (Label2.Text != "" && Label2.Text == "CHECKER")
            {
                HyperLink1.Enabled = false;
                HyperLink2.Enabled = false;
                HyperLink3.Enabled = false;
                HyperLink4.Enabled = false;
               // HyperLink5.Enabled = false;
              //  HyperLink6.Enabled = false;
                // Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme2()", true);
            }
            if (Label2.Text == "ADMIN")
            {
                checker_label.Text = "ADMIN";
                HyperLink1.Enabled = false;
                HyperLink2.Enabled = false;
                HyperLink3.Enabled = false;
                HyperLink4.Enabled = false;
                HyperLink7.Enabled = false;
             
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "admin()", true);
            }
            if (IsPostBack)
            {
                
                if (Label2.Text != "" && Label2.Text == "MAKER")
            {
             
                 //   HyperLink5.Enabled = false;
                 //   HyperLink6.Enabled = false;
                    HyperLink7.Enabled = false;
                    //  Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme_site()", true);
                }
            if (Label2.Text != "" && Label2.Text == "CHECKER")
                {
                    HyperLink1.Enabled = false;
                    HyperLink2.Enabled = false;
                    HyperLink3.Enabled = false;
                    HyperLink4.Enabled = false;
                //    HyperLink5.Enabled = false;
                 //   HyperLink6.Enabled = false;
                    // Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme2()", true);
                }
            if (Label2.Text == "ADMIN")
            {
                checker_label.Text = "ADMIN";
                    HyperLink1.Enabled = false;
                    HyperLink2.Enabled = false;
                    HyperLink3.Enabled = false;
                    HyperLink4.Enabled = false;
                    HyperLink7.Enabled = false;
                  
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "admin()", true);
                }
            }
            if (!IsPostBack)
            {
            
                if (Session["User"].ToString() != "" && Session["role"].ToString() != "" )
                {
                    Label2.Text = Session["role"].ToString();
                Label3.Text = Session["User"].ToString();
                   
                        checker_label.Text = Session["checker_label"].ToString();
                    
                branch_label.Text = Session["branch"].ToString();
          
                if (Label2.Text != "" && Label2.Text == "MAKER")
                {
                
                  //  HyperLink5.Enabled = false;
                  //  HyperLink6.Enabled = false;
                        HyperLink7.Enabled = false;
                        //  Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme_site()", true);
                    }
                if (Label2.Text != "" && Label2.Text == "CHECKER")
                {
                    HyperLink1.Enabled = false;
                    HyperLink2.Enabled = false;
                    HyperLink3.Enabled = false;
                    HyperLink4.Enabled = false;
                 //   HyperLink5.Enabled = false;
                 //   HyperLink6.Enabled = false;
                    // Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme2()", true);
                }

                if (Label2.Text != "" && Label2.Text == "ADMIN")
                {
                    checker_label.Text = "ADMIN";
                    HyperLink1.Enabled = false;
                    HyperLink2.Enabled = false;
                    HyperLink3.Enabled = false;
                    HyperLink4.Enabled = false;
                        HyperLink7.Enabled = false;
                       
                        //   Page.ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "admin()", true);
                    }
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
                    MessageBox.Show(ex.Message);
                }

               
            }
        }
        protected void login_ServerClick(object sender, EventArgs e)
        {
            //  ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + "Hello" + "')", true);
          //  MessageBox.Show("Loging out");
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();

            Response.Redirect("Login.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}