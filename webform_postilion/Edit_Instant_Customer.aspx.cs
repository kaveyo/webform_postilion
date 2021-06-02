using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webform_postilion
{
    public partial class Edit_Instant_Customer : System.Web.UI.Page
    {
        DateTime time = DateTime.Now;              // Use current time
        string format = "yyyy-MM-dd HH:mm:ss";
        ClassDatabase obj = new ClassDatabase();
        ClassDatabase obj2 = new ClassDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                obj.conn.ConnectionString = obj.locate;
                obj2.conn.ConnectionString = obj2.locate1;
                if (Request.QueryString["CUST_id"] != "")
                {

                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM pc_customers_2_A  where customer_id = '" + Request.QueryString["CUST_id"] + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {

                            name.Text = (sdr["c1_first_name"].ToString());
                            surname.Text = (sdr["c1_last_name"].ToString());
                            address.Text = (sdr["postal_address_1"].ToString());
                            mobile.Text = (sdr["mobile_nr"].ToString());
                            national_id.Text = (sdr["national_id_nr"]).ToString();


                        }

                    }
                    obj.conn.Close();

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



            // String date = (DateTime.ParseExact(datepicker34.Text, "ddd MMM dd yyyy", CultureInfo.InvariantCulture)).ToString("yyyyMMdd");

            if (mobile.Text == "" || address.Text == "" || national_id.Text == "" || name.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER ALL FIELDS')", true);

            }
            else
            {

                using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                {
                    sqlCon.Open();
                    string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','EDIT_CUSTOMER_DETAILS_INSTANT','" + Request.QueryString["CUST_id"] + "','','" + str.Text + "','REQUEST TO EDIT CUSTOMER DETAILS','" + str2.Text + "' , '0')";

                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    string query2 = " insert into postilion_hold_data (action,id,branch_code,customer_id ,first_name,mobile,national_id ,address_1_1,last_name   ,name_on_card) values ('EDIT_CUSTOMER_DETAILS_INSTANT','" + row + "','" + str.Text + "','" + Request.QueryString["CUST_id"] + "','" + name.Text + "','" + mobile.Text + "','" + national_id.Text + "','" + address.Text + "','" + surname.Text + "','" + name.Text + " " + surname.Text + "')";

                    SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                    sqlCmd2.ExecuteNonQuery();


                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('SAVED')", true);
                    // ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('SAVED')", true);
                    Button4.Enabled = false;
                    sqlCon.Close();
                }

            }
        }
    }
}