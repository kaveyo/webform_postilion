using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webform_postilion
{
    public partial class Instant_Search_Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextBox2.Text != "" && TextBox3.Text == "")
            {
                Response.Redirect("Instant_Account_Result.aspx?acc=" + TextBox2.Text);
            }
            else if (TextBox3.Text != "" && TextBox2.Text == "")
            {
                Response.Redirect("Instant_Card_Result.aspx?card=" + TextBox3.Text);
            }else if (TextBox3.Text == "" && TextBox2.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER ACCOUNT OR CARD NUMBER')", true);
            }
            else if (TextBox3.Text != "" && TextBox2.Text != "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER ONE FIELD ONLY')", true);
            }

        }
    }
}