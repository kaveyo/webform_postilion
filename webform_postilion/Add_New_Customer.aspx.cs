using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Globalization;

namespace webform_postilion
{
    public partial class Add_New_Customer : System.Web.UI.Page
    {
        DateTime time = DateTime.Now;              // Use current time
        string format = "yyyy-MM-dd HH:mm:ss";
        ClassDatabase obj = new ClassDatabase();
        String pan;
        int issue_nr = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            pan = Request.QueryString["pan"];
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Account_Card_Result.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "place('ENTER ALL FIELDS')", true);

            System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label str3 = Master.FindControl("Label3") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str4 = Master.FindControl("last_row") as System.Web.UI.WebControls.Label;
            String row = (Convert.ToDouble(str4.Text) + 1).ToString();



          String date =  (DateTime.ParseExact(datepicker34.Text, "ddd MMM dd yyyy", CultureInfo.InvariantCulture)).ToString("yyyyMMdd");

            if (customer_d.Text == "" || mobile.Text == "" || address_1_1.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER REQUIRED FIELDS')", true);
                //ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "placed('ENTER REQUIRED FIELDS')", true);

               // RequiredFieldValidator1.Enabled = true;
               // RequiredFieldValidator2.Enabled = true;
                RequiredFieldValidator3.Enabled = true;
                RequiredFieldValidator4.Enabled = true;
                RequiredFieldValidator5.Enabled = true;
                RequiredFieldValidator6.Enabled = true;
                RequiredFieldValidator7.Enabled = true;
                RequiredFieldValidator8.Enabled = true;
            }
            else
            {
               
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','ADD NEW CUSTOMER','"+pan+"','','" + str.Text + "','REQUEST TO ADD NEW CUSTOMER','" + str2.Text + "' , '0')";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address_1_1,city,dob,language,national_id,fax,tel_nr,address_1_2,address_2_1,address_2_2,city2,country_1,country_2) values ('ADD NEW CUSTOMER','" + row + "','" + str.Text + "','','"+customer_d.Text+"','','','"+pan+ "' , '','','"+email.Text + "','','','"+title.Text + "','"+first_name.Text + "','"+middle_initials.Text + "','" + last_name.Text + "' , '" + name_on_card.Text + "','','','" + mobile.Text + "','"+ issue_nr + "','','','','" + address_1_1.Text + "' , '" + city_1.Text + "','"+date+"','"+language.Text + "','"+national_id.Text + "' , '"+fax_number.Text + "','"+tel.Text + "','"+ address_1_2.Text + "','"+ address_2_1.Text + "','"+ address_2_2.Text + "','"+ city_2.Text + "','ZWE','ZWE')";

                        SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                        sqlCmd2.ExecuteNonQuery();


                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('SAVED')", true);
                   // ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('SAVED')", true);
                        sqlCon.Close();
                    }
      
            }
        }
    }
}