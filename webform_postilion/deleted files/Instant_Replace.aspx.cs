using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webform_postilion
{
    public partial class Instant_Replace : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = Request.QueryString["pan"];

            TextBox2.Text = Request.QueryString["card_seq"];
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("Instant_Replace1.aspx?pan=" + TextBox1.Text + "&card_sep=" + TextBox2.Text + "&reason=" + RadioButtonList1.Text + "&hold_response=" + DropDownList2.Text + "&mail=" + RadioButtonList2.Text);
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Instant_Card_Result.aspx");
        }
    }
}