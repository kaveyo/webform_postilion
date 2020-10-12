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