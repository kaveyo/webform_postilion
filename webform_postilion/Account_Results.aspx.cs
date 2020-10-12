using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Data;

namespace webform_postilion
{
    public partial class Account_Results : System.Web.UI.Page
    {
        DateTime time = DateTime.Now;              // Use current time
        string format = "yyyy-MM-dd HH:mm:ss";
        ClassDatabase obj = new ClassDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {

          /*  System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

            if(str2.Text != "MAKER" && str2.Text != "CHECKER")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('YOU ARE NOT MAKER!!!')", true);
                Response.Redirect("Authorise.aspx");
            }*/

            if (!IsPostBack)
            {
                if (Request.QueryString["acc"] != "")
                {
                    obj.conn.ConnectionString = obj.locate;


                    obj.conn.Open();
                    SqlDataReader sdr2;

                   SqlCommand cmd2 = new SqlCommand("SELECT * FROM pc_account_balances_1_A where account_id = '" + Request.QueryString["acc"] + "' ", obj.conn);

                    SqlDataAdapter dataAdp2 = new SqlDataAdapter(cmd2);

                    using (sdr2 = cmd2.ExecuteReader())
                    {
                        while (sdr2.Read())
                        {
                           

                            TextBox7.Text = Convert.ToString((Convert.ToDecimal(sdr2["ledger_balance"].ToString()) / 100));
                            TextBox8.Text = Convert.ToString((Convert.ToDecimal(sdr2["available_balance"].ToString()) / 100));
                           

                        }

                    }
                    obj.conn.Close();
                }
            
            
                if (Request.QueryString["acc"] != "")
                {
                    String acc = Request.QueryString["acc"];
                 
                    obj.conn.ConnectionString = obj.locate;

                    try
                    {

                        obj.conn.Open();
                        SqlDataReader sdr;

                        SqlCommand cmd = new SqlCommand("SELECT * FROM pc_accounts_1_A where account_id = '" + Request.QueryString["acc"] + "' ", obj.conn);

                        SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                        using (sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {

                                TextBox1.Text = (sdr["account_id"].ToString());
                                TextBox2.Text = (sdr["last_updated_date"].ToString());
                                TextBox3.Text = (sdr["last_updated_user"].ToString());
                                DropDownList1.Text = get_response((sdr["account_product"]).ToString());
                                DropDownList2.Text = get_response_hold((sdr["hold_rsp_code"]).ToString());
                                TextBox4.Text = (sdr["account_type"]).ToString();
                                TextBox5.Text = (sdr["currency_code"]).ToString();
                                TextBox6.Text = (sdr["overdraft_limit"].ToString());

                            }

                        }

                     

                        PopulateGridview(Request.QueryString["acc"]);
                        obj.conn.Close();
                    }

                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('Error retrieving info from pc_accounts')", true);
                    }
                    
                }
                
            }
        }

        void PopulateGridview(String acc)
        {
            ClassDatabase obj = new ClassDatabase();


            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(obj.locate))
            {
                sqlCon.Open();
               SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM pc_customer_accounts_1_A join pc_customers_1_A on pc_customer_accounts_1_A.customer_id = pc_customers_1_A.customer_id where pc_customer_accounts_1_A.account_id = '" + acc + "'", sqlCon);

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
                gvPhoneBook.Rows[0].Cells[0].Text = "No Customer Linked to the Account ..!";
                gvPhoneBook.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!DropDownList1.Enabled) {
                DropDownList1.Enabled = true;
                DropDownList2.Enabled = true;
                CheckBox1.Enabled = true;
                 Button6.Enabled = true;
                
            }
          /*  if (gvPhoneBook.Rows[0].Cells[0].Text == "No Customer Linked to the Account ..!")
            {
                gvPhoneBook.Rows[0].Cells[1].Enabled = false;
            
            }*/
            //  Response.Redirect("Account_Edit.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search_Account_Pan.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            obj.conn.ConnectionString = obj.locate1;
            System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label str3 = Master.FindControl("Label3") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str4 = Master.FindControl("last_row") as System.Web.UI.WebControls.Label;

            String row = (Convert.ToDouble(str4.Text) + 1).ToString();
            if (DropDownList2.Enabled == true)
            {
                if (DropDownList2.Text != "None")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        // string query = "UPDATE pc_cards_1_A SET card_status = 0 WHERE customer_id = '"+customer_id_text.Text+"'";
                        string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','PLACE HOLD ACCOUNT','','" + TextBox1.Text + "','" + str.Text + "','REQUEST TO PLACE HOLD ON ACCOUNT','" + str2.Text + "' , '0')";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();

                        string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address_1_1,city) values ('PLACE HOLD ACCOUNT','" + row + "','','"+DropDownList2.Text+"','','','" + TextBox1.Text + "','' , '','','','','','','','','' , '','','','','','','','','' , '')";

                        SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                        sqlCmd2.ExecuteNonQuery();
                        TextBox3.Text = "0";
                        //   MessageBox.Show("PLACE HOLD ACCOUNT");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('PLACED HOLD ON ACCOUNT')", true);

                       // ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('PLACED HOLD ON ACCOUNT')", true);
                    }
                }
                else
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','REMOVE HOLD ACCOUNT','','" + TextBox1.Text + "','" + str.Text + "','REQUEST TO REMOVE HOLD ON ACCOUNT','" + str2.Text + "' , '0')";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();

                        string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address_1_1,city) values ('REMOVE HOLD ACCOUNT','" + row + "','','"+DropDownList2.Text+"','','','" + TextBox1.Text + "','' , '','','','','','','','','' , '','','','','','','','','' , '')";

                        SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                        sqlCmd2.ExecuteNonQuery();
                        TextBox3.Text = "0";
                        //  MessageBox.Show("REMOVED HOLD ACCOUNT");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REMOVED HOLD ON ACCOUNT')", true);

                       // ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('REMOVED HOLD ON ACCOUNT')", true);
                    }
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

            if (DropDownList1.Enabled == true && Button6.Text == "Allow")

            {
              
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        //   string query = "UPDATE pc_cards_1_A SET card_status = 1 WHERE customer_id = '" + customer_id_text.Text + "'";
                        string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','EDIT ACCOUNT','','" + TextBox1.Text + "','" + str.Text + "','REQUEST TO EDIT ACCOUNT','" + str2.Text + "' , '0')";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address_1_1,city) values ('EDIT ACCOUNT','" + row + "','" + str.Text + "','"+DropDownList2.Text+"','','','"+TextBox1.Text+"','' , '','','','','','','','','' , '','','"+DropDownList1.Text+ "','','','','','','' , '')";

                        SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                        sqlCmd2.ExecuteNonQuery();
                    //  TextBox3.Text = "1";
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('SAVED')", true);

                   // ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('SAVED')", true);
                        sqlCon.Close();
                    }
            

            }
            else if (DropDownList1.Enabled && Button6.Text == "DISALLOW") { 
                if (TextBox6.Text != "")
                {
                    try
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','EDIT ACCOUNT','','" + TextBox1.Text + "','" + str.Text + "','REQUEST TO EDIT ACCOUNT','" + str2.Text + "' , '0')";

                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address_1_1,city,overdraft_limit) values ('EDIT ACCOUNT','" + row + "','" + str.Text + "','" + DropDownList2.Text + "','','','"+TextBox1.Text+"','' , '','','','','','','','','' , '','','" + DropDownList1.Text + "','','','','','','' , '','" + TextBox6.Text + "')";

                            SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                            sqlCmd2.ExecuteNonQuery();
                            //  TextBox3.Text = "1";
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('SAVED')", true);

                            //ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('SAVED')", true);
                            sqlCon.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save(ex.Message)", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER EMPTY FIELDS')", true);

                  //  ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('Enter Empty Fields')", true);
                }
            }
        }
        public void checked_()
        {
            TextBox6.ReadOnly = false;
        }
        private string get_response(string v)
        {
           
            if (v == "")
            {
                return "None";
            }
            else
            {
                return v;
            }
        }
        private string get_response_hold(string v)
        {
            List<String> response = new List<String>();


            response.Add("Account closed : 45");
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
       
        protected void gvPhoneBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {  
            
            if (e.CommandName.Equals("Delete") && gvPhoneBook.Rows[0].Cells[0].Text != "No Customer Linked to the Account ..!")
            {
               // MessageBox.Show(gvPhoneBook.Rows[0].Cells[0].Text);
                System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;
                System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

                System.Web.UI.WebControls.Label str3 = Master.FindControl("Label3") as System.Web.UI.WebControls.Label;
                System.Web.UI.WebControls.Label str4 = Master.FindControl("last_row") as System.Web.UI.WebControls.Label;
                String row = (Convert.ToDouble(str4.Text) + 1).ToString();


                string customer_id = e.CommandArgument.ToString();
               

                            

                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;

                using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                {
                    sqlCon.Open();
                    string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','UNLINK USER FROM ACCOUNT','','" + TextBox1.Text + "','" + str.Text + "','0','" + str2.Text + "' , '0')";

                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address_1_1,city) values ('UNLINK USER FROM ACCOUNT','" + row + "','','','" + customer_id + "','" + DropDownList1.Text + "','','','','','','','','','','','','','','','','','','','','','')";

                    SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                    sqlCmd2.ExecuteNonQuery();
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('UNLINKED')", true);

                  //  ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('UNLINKED')", true);
                    sqlCon.Close();
                }
            }
        }
            protected void gvPhoneBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
          /*  //   ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('Deleted')", true);
            System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label str3 = Master.FindControl("Label3") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str4 = Master.FindControl("last_row") as System.Web.UI.WebControls.Label;
            String row = (Convert.ToDouble(str4.Text) + 1).ToString();

            int crow;
            crow = Convert.ToInt32(e.CommandArgument.ToString());

            ClassDatabase obj = new ClassDatabase();
            obj.conn.ConnectionString = obj.locate1;

            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
            {
                sqlCon.Open();
                string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','UNLINK USER FROM ACCOUNT','','" + TextBox1.Text + "','" + str.Text + "','0','" + str2.Text + "' , '0')";

                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                string query2 = " insert into postilion_hold_data (action,id,branch_code,hold_rsp_code,customer_id ,place_hold ,account_id ,pan,card_status ,reason_for_reason ,mail_destination ,seq_nr ,expiry_date ,title,first_name,middle_initial,last_name,name_on_card,other,account_product,mobile,issuer_nr,account_type,last_updated_date,last_updated_user,address,city) values ('UNLINK USER FROM ACCOUNT','" + row + "','','','','" + DropDownList1.Text + "','','','','','','','','','','','','','','','','','','','','','')";

                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                sqlCmd2.ExecuteNonQuery();
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save('UNLINKED')", true);
                sqlCon.Close();
            }*/

        }
        protected void Button6_Click(object sender, EventArgs e)
        {
            if (Button6.Text == "Allow")
            {
                TextBox6.ReadOnly = false;
                Button6.Text = "DISALLOW";
                RequiredFieldValidator1.Enabled = true;
            }
            else
            {
                TextBox6.ReadOnly = true;
                Button6.Text = "Allow";
                TextBox6.Text = "";
                RequiredFieldValidator1.Enabled = false;
            }
        }
       
            }
        }