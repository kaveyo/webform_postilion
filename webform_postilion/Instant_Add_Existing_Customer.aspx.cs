using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;

namespace webform_postilion
{
    public partial class Instant_Add_Existing_Customer : System.Web.UI.Page
    {
        DateTime time = DateTime.Now;              // Use current time
        string format = "yyyy-MM-dd HH:mm:ss";
        ClassDatabase obj = new ClassDatabase();
        String pan;
        protected void Page_Load(object sender, EventArgs e)
        {
            datepicker34.Attributes.Add("readonly", "readonly");
            TextBox7.Attributes.Add("readonly", "readonly");
            TextBox8.Attributes.Add("readonly", "readonly");
            TextBox10.Attributes.Add("readonly", "readonly");
            TextBox11.Attributes.Add("readonly", "readonly");
            TextBox14.Attributes.Add("readonly", "readonly");
            TextBox13.Attributes.Add("readonly", "readonly");
            TextBox15.Attributes.Add("readonly", "readonly");
            TextBox16.Attributes.Add("readonly", "readonly");
            TextBox17.Attributes.Add("readonly", "readonly");
            TextBox18.Attributes.Add("readonly", "readonly");
            TextBox19.Attributes.Add("readonly", "readonly");
            TextBox22.Attributes.Add("readonly", "readonly");
            TextBox21.Attributes.Add("readonly", "readonly");
            TextBox2.Attributes.Add("readonly", "readonly");
            TextBox3.Attributes.Add("readonly", "readonly");
            TextBox4.Attributes.Add("readonly", "readonly");
            TextBox5.Attributes.Add("readonly", "readonly");
            TextBox6.Attributes.Add("readonly", "readonly");
            pan = Request.QueryString["pan"];

            if (!IsPostBack)
            {
                pan = Request.QueryString["pan"];


            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Instant_Card_Result.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (TextBox1.Text == "")
            {

                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER CUSTOMER ID')", true);
               // ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "place('ENTER CUSTOMER ID')", true);

            }
            else
            {
                try
                {

                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM pc_customers_2_A  where customer_id = '" + TextBox1.Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {

                            TextBox7.Text = (sdr["c1_first_name"].ToString());
                            datepicker34.Text = DateTime.ParseExact(sdr["date_of_birth"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture).ToString("yyyy-MM-dd");
                            TextBox2.Text = (sdr["c1_name_on_card"].ToString());
                            TextBox3.Text = (sdr["c1_last_name"].ToString());
                            TextBox4.Text = (sdr["preferred_lang"]).ToString();
                            TextBox6.Text = (sdr["email_address"]).ToString();
                            TextBox5.Text = (sdr["mobile_nr"]).ToString();
                            TextBox8.Text = (sdr["tel_nr"].ToString());
                            TextBox11.Text = (sdr["postal_address_1"].ToString());
                            TextBox22.Text = (sdr["postal_country"]).ToString();
                            TextBox16.Text = (sdr["postal_city"]).ToString();
                        }

                    }
                    obj.conn.Close();
                }
                catch (Exception ex)
                {
                    //  MessageBox.Show(ex.Message);

                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ERROR RETRIEVING INFO')", true);
                  //  ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "error('ERROR RETRIEVING INFO')", true);
                }
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label str3 = Master.FindControl("Label3") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str4 = Master.FindControl("last_row") as System.Web.UI.WebControls.Label;
            String row = (Convert.ToDouble(str4.Text) + 1).ToString();
           
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','ADD EXISTING CUSTOMER INSTANT','" + TextBox1.Text + "','0','" + str.Text + "','REQUEST TO ADD EXISTING CUSTOMER','" + str2.Text + "' , '0')";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address_1_1,city) values ('ADD EXISTING CUSTOMER INSTANT','" + row + "','" + str.Text + "','','" + TextBox1.Text + "','','','' , '','','','','','','" + TextBox7.Text + "','" + datepicker34.Text + "','" + TextBox3.Text + "' , '" + TextBox2.Text + "','','','" + TextBox5.Text + "','','','','','" + TextBox11.Text + "' , '" + TextBox16.Text + "')";

                        SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                        sqlCmd2.ExecuteNonQuery();
                //  TextBox3.Text = "1";

                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('SAVED')", true);
              //  ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('SAVED')", true);
                        sqlCon.Close();
                    }
               
            
        }
    }
}