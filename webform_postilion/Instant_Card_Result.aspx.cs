using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace webform_postilion
{
    public partial class Instant_Card_Result : System.Web.UI.Page
    {
        DateTime time = DateTime.Now;              // Use current time
        string format = "yyyy-MM-dd HH:mm:ss";
        ClassDatabase obj = new ClassDatabase();
        ClassDatabase obj2 = new ClassDatabase();
        Boolean p = true;
        string branches,branch_1 ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
           
                  
               
                String card = Request.QueryString["card"];
            
                obj.conn.ConnectionString = obj.locate;
                obj2.conn.ConnectionString = obj2.locate1;

                if (Request.QueryString["card"] != "")
                {
                  //  try
                   // {

                        obj.conn.Open();
                        SqlDataReader sdr;

                        SqlCommand cmd = new SqlCommand("SELECT last_updated_date,date_activated,pan,seq_nr,card_status,card_program,issuer_nr,branch_code,date_issued,customer_id,hold_rsp_code,last_updated_user FROM pc_cards_2_A  where pan = '" + Request.QueryString["card"] + "' ", obj.conn);

                        SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                        using (sdr = cmd.ExecuteReader())
                        {
                            if (sdr.Read())
                            {

                                TextBox1.Text = (sdr["pan"].ToString());
                                TextBox2.Text = (sdr["seq_nr"].ToString());
                                TextBox3.Text = (sdr["card_status"].ToString());
                                TextBox4.Text = (sdr["date_activated"]).ToString();
                                TextBox6.Text = (sdr["last_updated_date"]).ToString();
                                TextBox5.Text = (sdr["last_updated_user"]).ToString();
                                DropDownList1.Text = get_response((sdr["hold_rsp_code"]).ToString());
                                TextBox9.Text = (sdr["date_issued"].ToString());
                            //  TextBox10.Text = (sdr["branch_code"].ToString());
                            branch_1 = (sdr["branch_code"].ToString());
                            if (branch_1 != null && branch_1 != "" && !String.IsNullOrEmpty(branch_1))
                            {
                                branches = (branch_1).Substring(0, 3);
                            }
                            else
                            {
                                branches = "";
                            }

                                TextBox11.Text = (sdr["card_program"]).ToString();
                                PopulateGridview((sdr["customer_id"]).ToString());
                                customer_id_text.Text = (sdr["customer_id"]).ToString();
                            }


                        }
                        obj.conn.Close();
                  /*  }
                    catch (Exception ex)
                    {
                       //   MessageBox.Show(ex.Message);
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "place(ex.Message)", true);
                    }*/

                    if (TextBox1.Text == "" && TextBox3.Text == "" && TextBox5.Text == "" && TextBox9.Text == "" )
                    {

                                          
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "deleted('1');", true);

                      
                        /*ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('DATA NOT FOUND')", true);

                        ScriptManager.RegisterStartupScript(this, GetType(), "DATA NOT FOUND", "alertMessage();", true);
                        Response.Redirect("Instant_Search_Account.aspx");*/
                    }
                }
              //  MessageBox.Show(branches);
                filldrop();
            }
        }
        [WebMethod]
        public static string DeleteClick(string id)
        {
            return "DONE";
        }
        public string getSimilar_branch(string v)
        {
            string result = "None";
           if(v != null && v != "" && !String.IsNullOrEmpty(v)) {

                if (v.Trim().Length < 3)
                {
                    v = "0" + v;

                    obj2.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("select * from postilion_branch where branch like '" + v.Trim() + "%' ", obj2.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {

                            result = (sdr["branch"].ToString());

                        }

                    }
                    obj.conn.Close();
                    return result;
                }
                else
                {
                    obj2.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("select * from postilion_branch where branch like '" + v.Trim() + "%' ", obj2.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {

                            result = (sdr["branch"].ToString());

                        }

                    }
                    obj.conn.Close();
                    return result;
                }
            }
          
            else {
                string nono = "None";
                obj2.conn.Open();
                SqlDataReader sdr;

                SqlCommand cmd = new SqlCommand("select * from postilion_branch where branch like '" + nono + "%' ", obj2.conn);

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                using (sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {

                        result = (sdr["branch"].ToString());

                    }

                }
                obj.conn.Close();
                return result;
            }
        
        }
        private void filldrop()
        {
            DropDownList2.DataSource = getBranches();
            DropDownList2.DataTextField = "branch";
            DropDownList2.DataValueField = "branch";

            DropDownList2.DataBind();
            DropDownList2.SelectedValue = DropDownList2.Items.FindByText(getSimilar_branch(branches)).Value;
          //  DropDownList2.SelectedValue = DropDownList2.Items.FindByText("none").Value;
        }
        private DataTable getBranches()
        {
            ClassDatabase obj = new ClassDatabase();

            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM postilion_branch ", sqlCon);

                sqlDa.Fill(dtbl);
                sqlCon.Close();
            }
            dtbl.DefaultView.Sort = "branch ASC";
            return dtbl;
        }
        void PopulateGridview(String cust_id)
        {
            ClassDatabase obj = new ClassDatabase();
            // String var = "2517178";

            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(obj.locate))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT customer_id,c1_first_name,c1_name_on_card,postal_address_1,c1_last_name FROM pc_customers_2_A where customer_id = '" + cust_id + "'", sqlCon);
                // SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT customer_id,c1_first_name,c1_name_on_card,postal_address_1,c1_last_name FROM pc_customers_1_A where customer_id = '" + var+"' ", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                gvPhoneBook.DataSource = dtbl;
                gvPhoneBook.DataBind();
                Button9.Enabled = false;
                Button10.Enabled = false;
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvPhoneBook.DataSource = dtbl;
                gvPhoneBook.DataBind();
                gvPhoneBook.Rows[0].Cells.Clear();
                gvPhoneBook.Rows[0].Cells.Add(new TableCell());
                gvPhoneBook.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvPhoneBook.Rows[0].Cells[0].Text = "No Customer Linked to the Card ..!";
                gvPhoneBook.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }
        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Instant_Search_Account.aspx");
        }

   

        protected void Button10_Click(object sender, EventArgs e)
        {
            Response.Redirect("Instant_Add_New_Customer.aspx?pan=" + TextBox1.Text);
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Response.Redirect("Instant_Add_Existing_Customer.aspx?pan=" + TextBox1.Text);
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (DropDownList1.Enabled != false) { 
            System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label str3 = Master.FindControl("Label3") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str4 = Master.FindControl("last_row") as System.Web.UI.WebControls.Label;

                if (str.Text == "019") { 
            String row = (Convert.ToDouble(str4.Text) + 1).ToString();

                if (DropDownList1.Text != "None")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                {
                    sqlCon.Open();
                    // string query = "UPDATE pc_cards_1_A SET card_status = 0 WHERE customer_id = '"+customer_id_text.Text+"'";
                    string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','PLACE HOLD CARD INSTANT','" + TextBox1.Text + "','','" + str.Text + "','REQUEST TO PLACE HOLD ON CARD','" + str2.Text + "' , '0')";

                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.ExecuteNonQuery();

                    string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address_1_1,city) values ('PLACE HOLD CARD INSTANT','" + row + "','','"+DropDownList1.Text+"','" + customer_id_text.Text + "','','','' , '','','','','','','','','' , '','','','','','','','','' , '')";

                    SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                    sqlCmd2.ExecuteNonQuery();
                    TextBox3.Text = "0";

                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('PLACED HOLD')", true);
                     //   ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "place('PLACE HOLD')", true);
                }

            }
            else
            {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        // string query = "UPDATE pc_cards_1_A SET card_status = 0 WHERE customer_id = '"+customer_id_text.Text+"'";
                        string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','REMOVE HOLD CARD INSTANT','" + TextBox1.Text + "','','" + str.Text + "','REQUEST TO REMOVE HOLD ON CARD','" + str2.Text + "' , '0')";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();

                        string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address_1_1,city) values ('REMOVE HOLD CARD INSTANT','" + row + "','','" + DropDownList1.Text + "','" + customer_id_text.Text + "','','','' , '','','','','','','','','' , '','','','','','','','','' , '')";

                        SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                        sqlCmd2.ExecuteNonQuery();
                        TextBox3.Text = "0";

                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REMOVED HOLD ON ACCOUNT')", true);
                      //  ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "place('REMOVE HOLD ACCOUNT')", true);

                    }
              }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('YOU DO NOT HAVE RIGHTS !')", true);
            }

        }
    }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox10.ReadOnly = false;
            DropDownList1.Enabled = true;
            DropDownList2.Enabled = true;
            RequiredFieldValidator1.Enabled = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label str3 = Master.FindControl("Label3") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str4 = Master.FindControl("last_row") as System.Web.UI.WebControls.Label;

            String row = (Convert.ToDouble(str4.Text) + 1).ToString();


            //   ClassDatabase obj = new ClassDatabase();
            obj.conn.ConnectionString = obj.locate1;
            // Boolean value = p;
            if (TextBox3.Text == "1")
            {

                //   try
                //   {
                using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                {
                    sqlCon.Open();
                    // string query = "UPDATE pc_cards_1_A SET card_status = 0 WHERE customer_id = '"+customer_id_text.Text+"'";
                    string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','DEACTIVATE INSTANT','" + TextBox1.Text + "','','" + str.Text + "','REQUEST TO DEACTIVATE CARD','" + str2.Text + "' , '0')";

                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.ExecuteNonQuery();

                    string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address_1_1,city) values ('DEACTIVATE INSTANT','" + row + "','','','" + customer_id_text.Text + "','','','' , '','','','','','','','','' , '','','','','','','','','' , '')";

                    SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                    sqlCmd2.ExecuteNonQuery();
                    TextBox3.Text = "0";

                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('DEACTIVATED')", true);
                   // ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "activate('DEACTIVATED')", true);

                }
                Button2.Enabled = false;
            }
            else
            {


                try
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        //   string query = "UPDATE pc_cards_1_A SET card_status = 1 WHERE customer_id = '" + customer_id_text.Text + "'";
                        string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','ACTIVATE INSTANT','" + TextBox1.Text + "','0','" + str.Text + "','REQUEST TO ACTIVATE CARD','" + str2.Text + "' , '0')";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address_1_1,city) values ('ACTIVATE INSTANT','" + row + "','','','" + customer_id_text.Text + "','','','' , '','','','','','','','','' , '','','','','','','','','' , '')";

                        SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                        sqlCmd2.ExecuteNonQuery();
                        TextBox3.Text = "1";

                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ACTIVATED')", true);
                        Button2.Enabled = false;
                       // ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "activate('ACTIVATED')", true);
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save(ex.Message)", true);
                }
                Button2.Enabled = false;
            }
        }
        private string get_response(string v)
        {
            List<String> response = new List<String>();


            response.Add("Account closed :45");
            response.Add("Approved or completed successfully:00");
            response.Add("Refer to card issuer:01");
            response.Add("Refer to card issuer, special condition:02");
            response.Add("Invalid merchant:03");
            response.Add("Pick-up card:04");
            response.Add("Do not honor:05");
            response.Add("Error:06");
            response.Add("Pick-up card, special condition:07");
            response.Add("Honor with identification:08");
            response.Add("Request in progress:09");
            response.Add("Approved, partial:10");
            response.Add("Approved, VIP:11");
            response.Add("Invalid transaction:12");
            response.Add("Invalid amount:13");
            response.Add("Invalid card number:14");
            response.Add("No such issuer:15");
            response.Add("Approved, update track 3:16");
            response.Add("Customer cancellation:17");
            response.Add("Customer dispute:18");
            response.Add("Re-enter transaction:19");
            response.Add("Invalid response:20");
            response.Add("No action taken:21");
            response.Add("Suspected malfunction:22");
            response.Add("Unacceptable transaction fee:23");
            response.Add("File update not supported:24");
            response.Add("Unable to locate record:25");
            response.Add("Duplicate record:26");
            response.Add("File update field edit error:27");
            response.Add("File update file locked:28");
            response.Add("File update failed:29");
            response.Add("Format error:30");
            response.Add("Bank not supported:31");
            response.Add("Completed partially:32");
            response.Add("Expired card, pick-up:33");
            response.Add("Suspected fraud, pick-up:34");
            response.Add("Contact acquirer, pick-up:35");
            response.Add("Restricted card, pick-up:36");
            response.Add("Call acquirer security, pick-up:37");
            response.Add("PIN tries exceeded, pick-up:38");
            response.Add("No credit account:39");
            response.Add("Function not supported:40");
            response.Add("Lost card, pick-up:41");
            response.Add("No universal account:42");
            response.Add("Stolen card, pick-up:43");
            response.Add("No investment account:44");
            response.Add("Identification required:46");
            response.Add("Identification cross-check required:47");
            response.Add("No customer record:48");
            response.Add("Reserved for future Realtime use:49");
            response.Add("Not sufficient funds:51");
            response.Add("No check account:52");
            response.Add("No savings account:53");
            response.Add("Expired card:54");
            response.Add("Incorrect PIN:55");
            response.Add("No card record:56");
            response.Add("Transaction not permitted to cardholder:57");
            response.Add("Transaction not permitted on terminal:58");
            response.Add("Suspected fraud:59");
            response.Add("Contact acquirer:60");
            response.Add("Exceeds withdrawal limit:61");
            response.Add("Restricted card:62");
            response.Add("Security violation:63");
            response.Add("Original amount incorrect:64");
            response.Add("Exceeds withdrawal frequency:65");
            response.Add("Call acquirer security:66");
            response.Add("Hard capture:67");
            response.Add("Response received too late:68");
            response.Add("Advice received too late:69");
            response.Add("Reserved for future Realtime use:70");
            response.Add("PIN tries exceeded:75");
            response.Add("Reserved for future Realtime use:76");
            response.Add("Intervene, bank approval required:77");
            response.Add("Intervene, bank approval required for partial amount:78");
            response.Add("Reserved for client-specific use (declined):79 to 89");
            response.Add("Cut-off in progress:90");
            response.Add("Issuer or switch inoperative:91");
            response.Add("Routing error:92");
            response.Add("Violation of law:93");
            response.Add("Duplicate transaction:94");
            response.Add("Reconcile error:95");
            response.Add("System malfunction:96");
            response.Add("Reserved for future Realtime use:97");
            response.Add("Exceeds cash limit:98");
            response.Add("Reserved for future Realtime use:99");
            response.Add("ATC not incremented:A1");
            response.Add("ATC limit exceeded:A2");
            response.Add("ATC configuration error:A3");
            response.Add("CVR check failure:A4");
            response.Add("CVR configuration error:A5");
            response.Add("TVR check failure:A6");
            response.Add("TVR configuration error:A7");
            response.Add("Unacceptable PIN:C Zero");
            response.Add("PIN Change failed:C1");
            response.Add("PIN Unblock failed:C2");
            response.Add("MAC Error:D1");
            response.Add("Prepay error:E1");
            if (v == "")
            {
                return "None";
            }
            else
            {
                return response.FirstOrDefault(stringToCheck => stringToCheck.Contains(v));
            }
        }
        protected void gvPhoneBook_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvPhoneBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label str3 = Master.FindControl("Label3") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str4 = Master.FindControl("last_row") as System.Web.UI.WebControls.Label;
            if (str.Text == "019") {
                String row = (Convert.ToDouble(str4.Text) + 1).ToString();

                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;
                /* try
                 {*/
                using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                {
                    sqlCon.Open();
                    //   string query = "UPDATE pc_cards_1_A SET card_status = 1 WHERE customer_id = '" + customer_id_text.Text + "'";
                    string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','UNLINK USER INSTANT FROM CARD','" + TextBox1.Text + "','0','" + str.Text + "','REQUEST TO UNLINK USER','" + str2.Text + "' , '0')";

                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address_1_1,city) values ('UNLINK USER INSTANT FROM CARD','" + row + "','" + TextBox10.Text + "','','" + customer_id_text.Text + "','" + DropDownList1.Text + "','','' , '','','','','','','','','' , '','','','','','','','','' , '')";

                    SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                    sqlCmd2.ExecuteNonQuery();
                    //  TextBox3.Text = "1";

                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('UNLINKED')", true);
                    // ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('UNLINKED')", true);
                    sqlCon.Close();
                }
            
        }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('YOU DO NOT HAVE RIGHTS !')", true);
        }
        
    }
        public String action_(String money)
        {
            // Response.Write("<script>alert('hie' + '"+money+"' );</script>");
            Response.Write("<script>alert('" + money + "'+ 'hie' );</script>");
            return "";
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label str3 = Master.FindControl("Label3") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str4 = Master.FindControl("last_row") as System.Web.UI.WebControls.Label;
            String row = (Convert.ToDouble(str4.Text) + 1).ToString();
          
                if (TextBox10.Text != "" && DropDownList1.Enabled == true)
                {
                    
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            //   string query = "UPDATE pc_cards_1_A SET card_status = 1 WHERE customer_id = '" + customer_id_text.Text + "'";
                            string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','EDIT CARD INSTANT','" + TextBox1.Text + "','0','" + str.Text + "','REQUEST TO EDIT CARD','" + str2.Text + "' , '0')";

                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address_1_1,city) values ('EDIT CARD INSTANT','" + row + "','" + TextBox10.Text + "','','" + customer_id_text.Text + "','" + DropDownList1.Text + "','','' , '','','','','','','','','' , '','','','','','','','','' , '')";

                            SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                            sqlCmd2.ExecuteNonQuery();
                    //  TextBox3.Text = "1";

                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('SAVED')", true);
                    //ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('SAVED')", true);
                            sqlCon.Close();

                        }

                Button4.Enabled = false;
            }
                else
                {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER EMPTY FIELDS AND EDIT DATA BEFORE SAVING')", true);
               // ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('Enter Empty Fields')", true);
                }
            

        }

       
    }
}