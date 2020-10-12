using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webform_postilion
{
    public partial class Retail : System.Web.UI.Page
    {
        DateTime time = DateTime.Now;              // Use current time
        string format = "yyyy-MM-dd HH:mm:ss";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClassDatabase obj = new ClassDatabase();
            obj.conn.ConnectionString = obj.locate;
            String customer_id;
            if (TextBox1.Text != "")
            {
                customer_id = TextBox1.Text;
                PopulateGridview(customer_id);
            }
            if (TextBox2.Text != "")
            {
                obj.conn.Open();
                SqlDataReader sdr2;

                SqlCommand cmd2 = new SqlCommand("SELECT * FROM pc_customer_accounts_1_A where account_id = '" + TextBox2.Text + "' ", obj.conn);

                SqlDataAdapter dataAdp2 = new SqlDataAdapter(cmd2);

                using (sdr2 = cmd2.ExecuteReader())
                {
                    while (sdr2.Read())
                    {


                        PopulateGridview((sdr2["customer_id"].ToString()));

                    }

                }
                obj.conn.Close();
            }
            if (TextBox3.Text != "")
            {
                obj.conn.Open();
                SqlDataReader sdr2;

                SqlCommand cmd2 = new SqlCommand("SELECT * FROM pc_cards_1_A where pan = '" + TextBox3.Text + "' ", obj.conn);

                SqlDataAdapter dataAdp2 = new SqlDataAdapter(cmd2);

                using (sdr2 = cmd2.ExecuteReader())
                {
                    while (sdr2.Read())
                    {


                        PopulateGridview((sdr2["customer_id"].ToString()));

                    }

                }
                obj.conn.Close();
            }
           
        }
        void PopulateGridview(String cust_id)
        {
            ClassDatabase obj = new ClassDatabase();


            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(obj.locate))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT customer_id,c1_first_name,c1_name_on_card,postal_address_1,c1_last_name,tel_nr,mobile_nr FROM pc_customers_1_A where customer_id = '" + cust_id + "'", sqlCon);
                sqlDa.Fill(dtbl);
                sqlCon.Close();
            }
            if (dtbl.Rows.Count > 0)
            {
                gvPhoneBook.DataSource = dtbl;
                gvPhoneBook.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvPhoneBook.DataSource = dtbl;
                gvPhoneBook.DataBind();
                gvPhoneBook.Rows[0].Cells.Clear();
                gvPhoneBook.Rows[0].Cells.Add(new TableCell());
                gvPhoneBook.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvPhoneBook.Rows[0].Cells[0].Text = "No Data Found ..!";
                gvPhoneBook.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }
        protected void gvPhoneBook_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvPhoneBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //   ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('Deleted')", true);
           /* System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label str3 = Master.FindControl("Label3") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str4 = Master.FindControl("last_row") as System.Web.UI.WebControls.Label;
            String row = (Convert.ToDouble(str4.Text) + 1).ToString();

            ClassDatabase obj = new ClassDatabase();
            obj.conn.ConnectionString = obj.locate1;

            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
            {
                sqlCon.Open();
                string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','UNLINK USER','" + TextBox1.Text + "','0','" + str.Text + "','0','" + str2.Text + "' , '0')";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address,city) values ('UNLINK','" + row + "','" + TextBox10.Text + "','','" + customer_id_text.Text + "','" + DropDownList1.Text + "','','','','','','','','','','','','','','','','','','','','','')";

                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                sqlCmd2.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('UNLINKED')", true);
                sqlCon.Close();
            }*/

        }
    }
}