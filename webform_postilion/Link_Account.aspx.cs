using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webform_postilion
{
    public partial class Link_Account : System.Web.UI.Page
    {
        string pan;
        DateTime time = DateTime.Now;              // Use current time
        string format = "yyyy-MM-dd HH:mm:ss";
        protected void Page_Load(object sender, EventArgs e)
        {
       
            if (!IsPostBack)
            {
                pan = Request.QueryString["pan"];

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                RequiredFieldValidator2.Enabled = true;
                RegularExpressionValidator1.Enabled = true;
                Label str = Master.FindControl("branch_label") as Label;
                Label str2 = Master.FindControl("checker_label") as Label;

                Label str3 = Master.FindControl("Label3") as Label;
                Label str4 = Master.FindControl("last_row") as Label;
                String row = (Convert.ToDouble(str4.Text) + 1).ToString();

                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;
                try
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','LINK ACCOUNT','" + Request.QueryString["pan"] + "','" + TextBox1.Text + "','" + str.Text + "','REQUEST TO LINK ACCOUNT TO CARD','" + str2.Text + "' , '0')";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address_1_1,city) values ('LINK ACCOUNT','" + row + "','','','','','" + TextBox1.Text + "','" + Request.QueryString["pan"] + "','','','','','','','','','','','','','','','','','','','')";

                        SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                        sqlCmd2.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('LINKED')", true);
                        Button1.Enabled = false;
                       
                        //ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('UNLINKED')", true);
                        sqlCon.Close();
                    }
                }
                catch (Exception)
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "error('Error inserting into portal tables')", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER ACCOUNT NUMBER')", true);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
          /*  if (TextBox7.Text != "")
            {
                RequiredFieldValidator1.Enabled = true;
                RegularExpressionValidator2.Enabled = true;

                Label str = Master.FindControl("branch_label") as Label;
                Label str2 = Master.FindControl("checker_label") as Label;

                Label str3 = Master.FindControl("Label3") as Label;
                Label str4 = Master.FindControl("last_row") as Label;
                String row = (Convert.ToDouble(str4.Text) + 1).ToString();

                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;
                try
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','LINK ACCOUNT','" + Request.QueryString["pan"] + "','" + TextBox7.Text + "','" + str.Text + "','REQUEST TO LINK ACCOUNT TO CARD','" + str2.Text + "' , '0')";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address_1_1,city) values ('LINK ACCOUNT','" + row + "','','','','','" + TextBox7.Text + "','" + Request.QueryString["pan"] + "','','','','','','','','" + currency.Text + "','','','','" + account_product.Text + "','','','" + account_type.Text + "','','','','')";

                        SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                        sqlCmd2.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('LINKED')", true);
                        Button1.Enabled = false;
                        Button4.Enabled = false;
                        //ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('UNLINKED')", true);
                        sqlCon.Close();
                    }
                }
                catch (Exception)
                {

                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "error('Error inserting into portal tables')", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER ACCOUNT NUMBER')", true);
            }*/
        }
    }
}