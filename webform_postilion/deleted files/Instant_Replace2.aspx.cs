using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Windows.Forms;

namespace webform_postilion
{
    public partial class Instant_Replace2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Instant_Card_Result.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Instant_Replace1.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Card Replaced");
        }
    }
}