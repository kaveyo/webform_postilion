using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webform_postilion
{
    public partial class Search_Account_Pan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (HttpContext.Current.Session["Roles"] != null)
                {
                    var list2 = HttpContext.Current.Session["Roles"] as List<Model.postilion_role>;

                  /*  if (list2[0].convenience_users == 0 || list2[0].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[1].convenience_users == 0 || list2[1].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[2].convenience_users == 0 || list2[2].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[3].convenience_users == 0 || list2[3].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[4].convenience_users == 0 || list2[4].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[5].convenience_users == 0 || list2[5].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[6].convenience_users == 0 || list2[6].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[7].convenience_users == 0 || list2[7].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[8].convenience_users == 0 || list2[8].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[9].convenience_users == 0 || list2[9].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[10].convenience_users == 0 || list2[10].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[11].convenience_users == 0 || list2[11].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[12].convenience_users == 0 || list2[12].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[13].convenience_users == 0 || list2[13].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[14].convenience_users == 0 || list2[14].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[15].convenience_users == 0 || list2[15].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[16].convenience_users == 0 || list2[16].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[17].convenience_users == 0 || list2[17].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[18].convenience_users == 0 || list2[18].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[19].convenience_users == 0 || list2[19].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[20].convenience_users == 0 || list2[20].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[21].convenience_users == 0 || list2[21].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[22].convenience_users == 0 || list2[22].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[23].convenience_users == 0 || list2[23].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[24].convenience_users == 0 || list2[24].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[25].convenience_users == 0 || list2[25].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[26].convenience_users == 0 || list2[26].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[27].convenience_users == 0 || list2[27].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }
                    if (list2[28].convenience_users == 0 || list2[28].branch_users == 0)
                    {
                        Button1.Enabled = false;
                    }*/
                   
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
             if (TextBox1.Text == "" && TextBox2.Text == "" && TextBox3.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "error('Enter one field')", true);

            }
             if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "error('Enter one field')", true);

            }
             if (TextBox1.Text != "" && TextBox2.Text != "" )
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "error('Enter one field')", true);

            }
            if (TextBox2.Text != "" && TextBox3.Text != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "error('Enter one field')", true);

            }
            if (TextBox1.Text != "" && TextBox3.Text != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "error('Enter one field')", true);

            }
            if (TextBox1.Text != "" && TextBox2.Text == "" && TextBox3.Text == "")
            {

                Response.Redirect("Account_Card_Result.aspx?cust_id=" + TextBox1.Text);
            }
            if (TextBox1.Text == "" && TextBox2.Text != "" && TextBox3.Text == "")
            {

                // Response.Redirect("Account_Results.aspx?acc=" + TextBox2.Text + "&cust_id=" + TextBox1.Text);
                Response.Redirect("Account_Results.aspx?acc=" + TextBox2.Text);

            }
            if (TextBox1.Text == "" && TextBox2.Text == "" && TextBox3.Text != "")
            {
                Response.Redirect("Account_Card_Result.aspx?card=" + TextBox3.Text);
            }
        }
    }
}