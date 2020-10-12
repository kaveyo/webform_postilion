using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace webform_postilion
{
    public partial class Replace1 : System.Web.UI.Page
    {
        DateTime time = DateTime.Now;              // Use current time
        string format = "yyyy-MM-dd HH:mm:ss";
        ClassDatabase obj = new ClassDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label str3 = Master.FindControl("Label3") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str4 = Master.FindControl("last_row") as System.Web.UI.WebControls.Label;

            String row = (Convert.ToDouble(str4.Text) + 1).ToString();



            if (true)
            {
                using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                {

                    sqlCon.Open();
                    // string query = "UPDATE pc_cards_1_A SET card_status = 0 WHERE customer_id = '"+customer_id_text.Text+"'";
                    string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','REISSUE CARD','" + Request.QueryString["pan"] + "','','" + str.Text + "','','" + str2.Text + "' , '0')";

                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.ExecuteNonQuery();

                    string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address,city) values ('REISSUE CARD','" + row + "','','" + Request.QueryString["hold_response"] + "','','','','" + Request.QueryString["pan"] + "' , '','" + Request.QueryString["reason"] + "','" + Request.QueryString["mail"] + "','" + Request.QueryString["card_sep"] + "','','" + DropDownList1.Text + "','" + TextBox12.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "' , '" + TextBox4.Text + "','','','','','','','','' , '')";

                    SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                    sqlCmd2.ExecuteNonQuery();
                    TextBox3.Text = "0";
                    //  MessageBox.Show("CARD REISSUED");
                    sqlCon.Close();
                }

            }
            else
            {
                MessageBox.Show("CARD REISSUE");
            }
            Response.Redirect("Replace2.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Replace.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Account_Card_Result.aspx");
        }
    }
}