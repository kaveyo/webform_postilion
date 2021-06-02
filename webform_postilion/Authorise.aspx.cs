using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text.RegularExpressions;

namespace webform_postilion
{
    public partial class Authorise : System.Web.UI.Page
    {


        String statement = "REJECTED";
        String statement_accept = "CHANGE APPROVED";
        DateTime time = DateTime.Now;              // Use current time

        string format = "yyyy-MM-dd HH:mm:ss";
        ClassDatabase obj = new ClassDatabase();
        string pan;
        String hold_rsp_code;
        String branch_code;
        String cust_id;
        String overdraftlimit;
        String account_product;
        string account_type, currency, account_number;

        String customer_id;
        String mail_destination;
        String title;
        String first_name;
        String middle_initial;
        String last_name;
        String name_on_card;
        String mobile;
        int issuer_nr;
        String last_updated_date;
        String last_updated_user;
        String address_1_1;
        String city;
        String dob;
        String language;
        String national_id;
        String fax;
        String tel_nr;
        String address_1_2;
        String address_2_1;
        String address_2_2;
        String city2;
        String country_1;
        String country_2;
        String reason;

        string goods_nr_trans_lim , card_nu;
        string cash_nr_trans_lim;
        string paymnt_nr_trans_lim;
        string goods_lim;
        string cash_lim;
        string paymnt_lim;
        string cnp_lim;
        string deposit_credit_lim;
        string goods_offline_lim;
        string cash_offline_lim;
        string paymnt_offline_lim;
        string cnp_offline_lim;
        string weekly_goods_nr_trans_lim;
        string weekly_cash_nr_trans_lim;
        string weekly_paymnt_nr_trans_lim;
        string weekly_goods_lim;
        string weekly_cash_lim;
        string weekly_paymnt_lim;
        string weekly_cnp_lim;
        string weekly_deposit_credit_lim;
        string weekly_goods_offline_lim;
        string weekly_cash_offline_lim;
        string weekly_paymnt_offline_lim;
        string weekly_cnp_offline_lim;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void CloseLinkClicked(Object sender, EventArgs e)
        {
            var closeLink = (System.Web.UI.Control)sender;
            GridViewRow row = (GridViewRow)closeLink.NamingContainer;
            System.Web.UI.WebControls.TextBox lblValue = (System.Web.UI.WebControls.TextBox)row.FindControl("txt_id");



        }
        protected void Button4_Click(object sender, EventArgs e)
        {

            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM postilion_portal_changes where date >='" + (Convert.ToDateTime(datepicker34.Text)).ToString(format) + "' and date <='" + (Convert.ToDateTime(datepicker1.Text)).ToString(format) + "' and view_status = 0", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                GridView1.DataSource = dtbl;
                GridView1.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                GridView1.DataSource = dtbl;
                GridView1.DataBind();
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                GridView1.Rows[0].Cells[0].Text = "No Data Found ..!";
                GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            System.Web.UI.WebControls.Label str3 = Master.FindControl("Label3") as System.Web.UI.WebControls.Label;

            if (e.CommandName.Equals("reason"))
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                obj.conn.ConnectionString = obj.locate1;
                obj.conn.Open();
                SqlDataReader sdr;

                SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_portal_changes where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                using (sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        reason = (sdr["reason"].ToString());
                    }

                }
                obj.conn.Close();

                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme4('" + reason + "')", true);
            }
            if (e.CommandName.Equals("accept2"))
            {
                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                if (GridView1.Rows[crow].Cells[3].Text == "REMOVE LOCK LIMIT")
                {
                    System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            card_nu = (sdr["pan"].ToString());                         

                        }

                    }
                    obj.conn.Close();

                    obj.conn.ConnectionString = obj.locate;
                    obj.conn.Open();

                    string insertUser = " delete from fbc_card_locked_limits  where pan = '" + GridView1.Rows[crow].Cells[4].Text.Trim() + "' ";
                    obj.cmd.Connection = obj.conn;
                    obj.cmd.CommandText = insertUser;
                    obj.cmd.ExecuteNonQuery();
                    obj.cmd.CommandTimeout = 60;
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REMOVED CARD LIMIT')", true);
                    
                    String action = "REMOVE LOCK LIMIT";

                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '" + str3.Text.Trim() + "' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }
                    obj.conn.Close();
                    return;
                    
                }
                if (GridView1.Rows[crow].Cells[3].Text == "LOCK LIMIT")
                {
                    System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            card_nu = (sdr["pan"].ToString());

                        }

                    }
                    obj.conn.Close();

                    obj.conn.ConnectionString = obj.locate;
                    obj.conn.Open();

                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "INSERT into fbc_card_locked_limits (pan ) VALUES ('" + GridView1.Rows[crow].Cells[4].Text.Trim() + "')";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('LOCKED CARD LIMIT')", true);
                    }

                    String action = "LOCK LIMIT";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '" + str3.Text.Trim() + "' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }
                    obj.conn.Close();
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "CARD LIMIT")
                {
                    System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            card_nu = (sdr["pan"].ToString());
                            goods_nr_trans_lim = (sdr["goods_nr_trans_lim"].ToString());
                            cash_nr_trans_lim = (sdr["cash_nr_trans_lim"].ToString());
                            paymnt_nr_trans_lim = (sdr["paymnt_nr_trans_lim"].ToString());
                            goods_lim = (sdr["goods_lim"].ToString());
                            cash_lim = (sdr["cash_lim"].ToString());
                            paymnt_lim = (sdr["paymnt_lim"].ToString());
                            cnp_lim = (sdr["cnp_lim"].ToString());
                            deposit_credit_lim = (sdr["deposit_credit_lim"].ToString());
                            goods_offline_lim = (sdr["goods_offline_lim"].ToString());
                            cash_offline_lim = (sdr["cash_offline_lim"].ToString());
                            paymnt_offline_lim = (sdr["paymnt_offline_lim"].ToString());
                            cnp_offline_lim = (sdr["cnp_offline_lim"].ToString());
                            weekly_goods_nr_trans_lim = (sdr["weekly_goods_nr_trans_lim"].ToString());
                            weekly_cash_nr_trans_lim = (sdr["weekly_cash_nr_trans_lim"].ToString());
                            weekly_paymnt_nr_trans_lim = (sdr["weekly_paymnt_nr_trans_lim"].ToString());
                            weekly_goods_lim = (sdr["weekly_goods_lim"].ToString());
                            weekly_cash_lim = (sdr["weekly_cash_lim"].ToString());
                            weekly_paymnt_lim = (sdr["weekly_paymnt_lim"].ToString());
                            weekly_cnp_lim = (sdr["weekly_cnp_lim"].ToString());
                            weekly_deposit_credit_lim = (sdr["weekly_deposit_credit_lim"].ToString());
                            weekly_goods_offline_lim = (sdr["weekly_goods_offline_lim"].ToString());
                            weekly_cash_offline_lim = (sdr["weekly_cash_offline_lim"].ToString());
                            weekly_paymnt_offline_lim = (sdr["weekly_paymnt_offline_lim"].ToString());
                            weekly_cnp_offline_lim = (sdr["weekly_cnp_offline_lim"].ToString());

                        }

                    }
                    obj.conn.Close();

                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "UPDATE pc_card_override_lim_1_A SET goods_nr_trans_lim	= '" + goods_nr_trans_lim + "' ,cash_nr_trans_lim	= '" + cash_nr_trans_lim + "' ,paymnt_nr_trans_lim	= '" + paymnt_nr_trans_lim + "' ,goods_lim	= '" + goods_lim + "' ,cash_lim	= '" + cash_lim + "' ,paymnt_lim	= '" + paymnt_lim + "' ,cnp_lim	= '" + cnp_lim + "' ,deposit_credit_lim	= '" + deposit_credit_lim + "' ,goods_offline_lim	= '" + goods_offline_lim + "' ,cash_offline_lim	= '" + cash_offline_lim + "' ,paymnt_offline_lim	= '" + paymnt_offline_lim + "' ,cnp_offline_lim	= '" + cnp_offline_lim + "' ,weekly_goods_nr_trans_lim	= '" + weekly_goods_nr_trans_lim + "' ,weekly_cash_nr_trans_lim	= '" + weekly_cash_nr_trans_lim + "' ,weekly_paymnt_nr_trans_lim	= '" + weekly_paymnt_nr_trans_lim + "' ,weekly_goods_lim	= '" + weekly_goods_lim + "' ,weekly_cash_lim	= '" + weekly_cash_lim + "' ,weekly_paymnt_lim	= '" + weekly_paymnt_lim + "' ,weekly_cnp_lim	= '" + weekly_cnp_lim + "' ,weekly_deposit_credit_lim	= '" + weekly_deposit_credit_lim + "' ,weekly_goods_offline_lim	= '" + weekly_goods_offline_lim + "' ,weekly_cash_offline_lim	= '" + weekly_cash_offline_lim + "' ,weekly_paymnt_offline_lim	= '" + weekly_paymnt_offline_lim + "' ,weekly_cnp_offline_lim	= '" + weekly_cnp_offline_lim + "' ,last_updated_date	= '" + time.ToString(format) + "' ,last_updated_user	= '" + str2.Text + "' ,date_deleted = NULL WHERE pan = '" + card_nu + "'";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('EDITED CARD LIMIT')", true);
                    }
                    String action = "CARD LIMIT";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }

                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "INSTANT CARD LIMIT")
                {
                    System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            card_nu = (sdr["pan"].ToString());
                            goods_nr_trans_lim = (sdr["goods_nr_trans_lim"].ToString());
                            cash_nr_trans_lim = (sdr["cash_nr_trans_lim"].ToString());
                            paymnt_nr_trans_lim = (sdr["paymnt_nr_trans_lim"].ToString());
                            goods_lim = (sdr["goods_lim"].ToString());
                            cash_lim = (sdr["cash_lim"].ToString());
                            paymnt_lim = (sdr["paymnt_lim"].ToString());
                            cnp_lim = (sdr["cnp_lim"].ToString());
                            deposit_credit_lim = (sdr["deposit_credit_lim"].ToString());
                            goods_offline_lim = (sdr["goods_offline_lim"].ToString());
                            cash_offline_lim = (sdr["cash_offline_lim"].ToString());
                            paymnt_offline_lim = (sdr["paymnt_offline_lim"].ToString());
                            cnp_offline_lim = (sdr["cnp_offline_lim"].ToString());
                            weekly_goods_nr_trans_lim = (sdr["weekly_goods_nr_trans_lim"].ToString());
                            weekly_cash_nr_trans_lim = (sdr["weekly_cash_nr_trans_lim"].ToString());
                            weekly_paymnt_nr_trans_lim = (sdr["weekly_paymnt_nr_trans_lim"].ToString());
                            weekly_goods_lim = (sdr["weekly_goods_lim"].ToString());
                            weekly_cash_lim = (sdr["weekly_cash_lim"].ToString());
                            weekly_paymnt_lim = (sdr["weekly_paymnt_lim"].ToString());
                            weekly_cnp_lim = (sdr["weekly_cnp_lim"].ToString());
                            weekly_deposit_credit_lim = (sdr["weekly_deposit_credit_lim"].ToString());
                            weekly_goods_offline_lim = (sdr["weekly_goods_offline_lim"].ToString());
                            weekly_cash_offline_lim = (sdr["weekly_cash_offline_lim"].ToString());
                            weekly_paymnt_offline_lim = (sdr["weekly_paymnt_offline_lim"].ToString());
                            weekly_cnp_offline_lim = (sdr["weekly_cnp_offline_lim"].ToString());

                        }

                    }
                    obj.conn.Close();

                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "UPDATE pc_card_override_lim_2_A SET goods_nr_trans_lim	= '" + goods_nr_trans_lim + "' ,cash_nr_trans_lim	= '" + cash_nr_trans_lim + "' ,paymnt_nr_trans_lim	= '" + paymnt_nr_trans_lim + "' ,goods_lim	= '" + goods_lim + "' ,cash_lim	= '" + cash_lim + "' ,paymnt_lim	= '" + paymnt_lim + "' ,cnp_lim	= '" + cnp_lim + "' ,deposit_credit_lim	= '" + deposit_credit_lim + "' ,goods_offline_lim	= '" + goods_offline_lim + "' ,cash_offline_lim	= '" + cash_offline_lim + "' ,paymnt_offline_lim	= '" + paymnt_offline_lim + "' ,cnp_offline_lim	= '" + cnp_offline_lim + "' ,weekly_goods_nr_trans_lim	= '" + weekly_goods_nr_trans_lim + "' ,weekly_cash_nr_trans_lim	= '" + weekly_cash_nr_trans_lim + "' ,weekly_paymnt_nr_trans_lim	= '" + weekly_paymnt_nr_trans_lim + "' ,weekly_goods_lim	= '" + weekly_goods_lim + "' ,weekly_cash_lim	= '" + weekly_cash_lim + "' ,weekly_paymnt_lim	= '" + weekly_paymnt_lim + "' ,weekly_cnp_lim	= '" + weekly_cnp_lim + "' ,weekly_deposit_credit_lim	= '" + weekly_deposit_credit_lim + "' ,weekly_goods_offline_lim	= '" + weekly_goods_offline_lim + "' ,weekly_cash_offline_lim	= '" + weekly_cash_offline_lim + "' ,weekly_paymnt_offline_lim	= '" + weekly_paymnt_offline_lim + "' ,weekly_cnp_offline_lim	= '" + weekly_cnp_offline_lim + "',last_updated_date	= '" + time.ToString(format) + "' ,last_updated_user	= '" + str2.Text + "' ,date_deleted = NULL WHERE pan = '" + card_nu + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('EDITED CARD LIMIT')", true);
                    }
                    String action = "INSTANT CARD LIMIT";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }

                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "EDIT_CUSTOMER_DETAILS_INSTANT")
                {
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {

                            cust_id = (sdr["customer_id"].ToString());
                            mobile = (sdr["mobile"].ToString());
                            address_1_1 = (sdr["address_1_1"].ToString());
                            national_id = (sdr["national_id"].ToString());
                            first_name = (sdr["first_name"].ToString());
                            last_name = (sdr["last_name"].ToString());
                            name_on_card = (sdr["name_on_card"].ToString());
                        }

                    }
                    obj.conn.Close();

                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "UPDATE pc_customers_2_A SET c1_first_name = '" + cust_id + "' , mobile_nr = '" + mobile + "', postal_address_1 = '" + address_1_1 + "', national_id_nr = '" + national_id + "',c1_last_name ='" + last_name + "' ,c1_name_on_card ='" + name_on_card + "' WHERE customer_id = '" + cust_id + "'";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('EDITED CUSTOMER DETAILS')", true);
                    }
                    String action = "EDIT_CUSTOMER_DETAILS_INSTANT";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }

                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "EDIT_CUSTOMER_DETAILS_ACCOUNT")
                {
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {

                            cust_id = (sdr["customer_id"].ToString());
                            mobile = (sdr["mobile"].ToString());
                            address_1_1 = (sdr["address_1_1"].ToString());
                            national_id = (sdr["national_id"].ToString());
                            first_name = (sdr["first_name"].ToString());
                            last_name = (sdr["last_name"].ToString());
                            name_on_card = (sdr["name_on_card"].ToString());
                        }

                    }
                    obj.conn.Close();
                   
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                        {
                            sqlCon.Open();
                            string query = "UPDATE pc_customers_1_A SET c1_first_name = '" + cust_id + "' , mobile_nr = '"+mobile+"', postal_address_1 = '"+address_1_1+"', national_id_nr = '"+national_id+ "',c1_last_name ='"+last_name+"' ,c1_name_on_card ='"+name_on_card+"' WHERE customer_id = '" + cust_id + "'";

                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('EDITED CUSTOMER DETAILS')", true);
                        }
                        String action = "EDIT_CUSTOMER_DETAILS_ACCOUNT";
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            load_to_grid();
                        }
                  
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "PLACE HOLD ACCOUNT")
                {
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            hold_rsp_code = (sdr["hold_rsp_code"].ToString());
                        }

                    }
                    obj.conn.Close();
                    string name = hold_rsp_code.Split(':')[1];


                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "UPDATE pc_accounts_1_A SET hold_rsp_code = '" + name + "' WHERE account_id = '" + GridView1.Rows[crow].Cells[5].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();

                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('PLACED HOLD')", true);

                    }
                    String action = "PLACE HOLD ACCOUNT";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and account ='" + GridView1.Rows[crow].Cells[5].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }

                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "REMOVE HOLD ACCOUNT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "UPDATE pc_accounts_1_A SET hold_rsp_code = NULL where account_id  = '" + GridView1.Rows[crow].Cells[5].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //   MessageBox.Show("REMOVED HOLD ACCOUNT");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REMOVED HOLD ACCOUNT')", true);
                    }
                    String action = "REMOVE HOLD ACCOUNT";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and account ='" + GridView1.Rows[crow].Cells[5].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "PLACE HOLD ACCOUNT INSTANT")
                {
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            hold_rsp_code = (sdr["hold_rsp_code"].ToString());
                        }

                    }
                    obj.conn.Close();
                    string name = hold_rsp_code.Split(':')[1];
                    //    MessageBox.Show(name);



                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "UPDATE pc_accounts_2_A SET hold_rsp_code = '" + name + "' WHERE account_id = '" + GridView1.Rows[crow].Cells[5].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //   MessageBox.Show("PLACE HOLD ACCOUNT INSTANT");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('PLACED HOLD ON INSTANT ACCOUNT')", true);
                    }
                    String action = "PLACE HOLD ACCOUNT INSTANT";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and account ='" + GridView1.Rows[crow].Cells[5].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "REMOVE HOLD ACCOUNT INSTANT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "UPDATE pc_accounts_2_A SET hold_rsp_code = NULL where account_id  = '" + GridView1.Rows[crow].Cells[5].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //  MessageBox.Show("REMOVE HOLD ACCOUNT INSTANT");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REMOVED HOLD ACCOUNT INSTANT')", true);
                    }
                    String action = "REMOVE HOLD ACCOUNT INSTANT";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and account ='" + GridView1.Rows[crow].Cells[5].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "PLACE HOLD CARD")
                {
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            hold_rsp_code = (sdr["hold_rsp_code"].ToString());
                        }

                    }
                    obj.conn.Close();
                    string name = hold_rsp_code.Split(':')[1];
                    //  MessageBox.Show(name);



                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "UPDATE pc_cards_1_A SET hold_rsp_code = '" + name + "' WHERE pan = '" + GridView1.Rows[crow].Cells[4].Text + "'";
                        //  string query = "DELETE FROM pc_customers_1_A WHERE customer_id = @customer_id";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        // MessageBox.Show("PLACED HOLD");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('PLACED HOLD')", true);
                    }
                    String action = "PLACE HOLD";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }
                    return;

                }
                if (GridView1.Rows[crow].Cells[3].Text == "REMOVE HOLD CARD")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "UPDATE pc_cards_1_A SET hold_rsp_code = NULL WHERE pan = '" + GridView1.Rows[crow].Cells[4].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //  MessageBox.Show("REMOVED HOLD CARD");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REMOVED HOLD CARD')", true);
                    }
                    String action = "REMOVE HOLD CARD";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "PLACE HOLD CARD INSTANT")
                {
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            hold_rsp_code = (sdr["hold_rsp_code"].ToString());
                        }

                    }
                    obj.conn.Close();
                    string name = hold_rsp_code.Split(':')[1];
                    //  MessageBox.Show(name);



                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "UPDATE pc_cards_2_A SET hold_rsp_code = '" + name + "' WHERE pan = '" + GridView1.Rows[crow].Cells[4].Text + "'";
                        //  string query = "DELETE FROM pc_customers_1_A WHERE customer_id = @customer_id";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //  MessageBox.Show("PLACED HOLD CARD INSTANT");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('PLACED HOLD ON INSTANT CARD)", true);
                    }
                    String action = "PLACE HOLD CARD INSTANT";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and account ='" + GridView1.Rows[crow].Cells[5].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "REMOVE HOLD CARD INSTANT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "UPDATE pc_cards_2_A SET hold_rsp_code = NULL WHERE pan = '" + GridView1.Rows[crow].Cells[4].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //   MessageBox.Show("REMOVE HOLD CARD INSTANT");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REMOVED HOLD ON INSTANT CARD')", true);
                    }
                    String action = "REMOVE HOLD CARD INSTANT";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }

                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "EDIT ACCOUNT")
                {
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            overdraftlimit = (sdr["overdraft_limit"].ToString());
                            account_product = (sdr["account_product"].ToString());
                        }

                    }
                    obj.conn.Close();

                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        if (overdraftlimit != "")
                        {
                            sqlCon.Open();
                            string query = "UPDATE pc_accounts_1_A SET overdraft_limit = '" + Convert.ToInt32(overdraftlimit) + "',account_product = '" + account_product.Trim() + "' WHERE account_id = '" + GridView1.Rows[crow].Cells[5].Text.Trim() + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            //  MessageBox.Show("EDIT ACCOUNT");
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ACCOUNT EDITED')", true);
                        }
                        if (overdraftlimit == "")
                        {
                            sqlCon.Open();
                            string query = "UPDATE pc_accounts_1_A SET account_product = '" + account_product.Trim() + "' WHERE account_id = '" + GridView1.Rows[crow].Cells[5].Text.Trim() + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            //  MessageBox.Show("EDIT ACCOUNT");
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ACCOUNT EDITED')", true);
                        }
                    }
                    String action = "EDIT ACCOUNT";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and account ='" + GridView1.Rows[crow].Cells[5].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "EDIT ACCOUNT INSTANT")
                {
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {

                            account_product = (sdr["account_product"].ToString());
                        }

                    }
                    obj.conn.Close();

                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "UPDATE pc_accounts_2_A SET account_product = '" + account_product.Trim() + "' WHERE account_id = '" + GridView1.Rows[crow].Cells[5].Text.Trim() + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //   MessageBox.Show("EDIT ACCOUNT INSTANT");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('EDITED INSTANT ACCOUNT')", true);
                    }
                    String action = "EDIT ACCOUNT INSTANT";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and account ='" + GridView1.Rows[crow].Cells[5].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "ACTIVATE")
                {

                    try
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                        {
                            sqlCon.Open();
                            string query = "UPDATE pc_cards_1_A SET card_status = 1 WHERE pan = '" + GridView1.Rows[crow].Cells[4].Text + "'";
                            //  string query = "DELETE FROM pc_customers_1_A WHERE customer_id = @customer_id";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            //  MessageBox.Show("ACTIVATED");
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ACTIVATED')", true);
                        }
                        String action = "ACTIVATE";
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            load_to_grid();
                        }
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save(ex.Message)", true);
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "ACTIVATE INSTANT")
                {
                    try
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                        {
                            sqlCon.Open();
                            string query = "UPDATE pc_cards_2_A SET card_status = 1 WHERE pan = '" + GridView1.Rows[crow].Cells[4].Text + "'";
                            //  string query = "DELETE FROM pc_customers_1_A WHERE customer_id = @customer_id";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            //  MessageBox.Show("ACTIVATED");
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ACTIVATED')", true);
                        }
                        String action = "ACTIVATE INSTANT";
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            load_to_grid();
                        }
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save(ex.Message)", true);
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "DEACTIVATE")
                {
                    try
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                        {
                            sqlCon.Open();
                            string query = "UPDATE pc_cards_1_A SET card_status = 0 WHERE pan = '" + GridView1.Rows[crow].Cells[4].Text + "'";
                            //  string query = "DELETE FROM pc_customers_1_A WHERE customer_id = @customer_id";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            //  MessageBox.Show("DEACTIVATED");
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('DEACTIVATED')", true);
                        }
                        String action = "DEACTIVATE";
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            load_to_grid();
                        }
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save(ex.Message)", true);
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "DEACTIVATE INSTANT")
                {
                    try
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                        {
                            sqlCon.Open();
                            string query = "UPDATE pc_cards_2_A SET card_status = 0 WHERE pan = '" + GridView1.Rows[crow].Cells[4].Text + "'";
                            //  string query = "DELETE FROM pc_customers_1_A WHERE customer_id = @customer_id";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            // MessageBox.Show("DEACTIVATED");
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('DEACTIVATED')", true);
                        }
                        String action = "DEACTIVATE INSTANT";
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            load_to_grid();
                        }
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save(ex.Message)", true);
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "EDIT CARD")
                {
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            hold_rsp_code = (sdr["place_hold"].ToString());
                            // MessageBox.Show(hold_rsp_code.Substring(hold_rsp_code.LastIndexOf(':') + 1));
                            if (sdr["branch_code"].ToString().Contains('-'))
                            {
                                branch_code = (sdr["branch_code"].ToString());
                            }
                            else
                            {
                                branch_code = (sdr["branch_code"].ToString().Substring(0,3));
                            }
                        }

                    }
                    obj.conn.Close();
                   /* try
                    {*/
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                        {

                            sqlCon.Open();
                            string query = "UPDATE pc_cards_1_A SET branch_code = '" + branch_code + "' ,hold_rsp_code = '" + hold_rsp_code.Substring(hold_rsp_code.LastIndexOf(':') + 1) + "' WHERE pan = '" + GridView1.Rows[crow].Cells[4].Text + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            //   MessageBox.Show("EDITED CARD");
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('EDITED CARD')", true);
                        }
                        String action = "EDIT CARD";
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            load_to_grid();
                        }
                   /* }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save(ex.Message)", true);
                    }*/
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "EDIT CARD INSTANT")
                {
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            hold_rsp_code = (sdr["place_hold"].ToString());
                            if (sdr["branch_code"].ToString().Contains('-'))
                            {
                                branch_code = (sdr["branch_code"].ToString());
                            }
                            else
                            {
                                branch_code = (sdr["branch_code"].ToString().Substring(0, 3));
                            }
                        }

                    }
                    obj.conn.Close();
                    try
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                        {
                            sqlCon.Open();
                            string query = "UPDATE pc_cards_2_A SET branch_code = '" + branch_code + "',hold_rsp_code = '" + hold_rsp_code.Substring(hold_rsp_code.LastIndexOf(':') + 1) + "' WHERE pan = '" + GridView1.Rows[crow].Cells[4].Text + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            //  MessageBox.Show("EDITED CARD INSTANT");
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('EDITED CARD INSTANT')", true);
                        }
                        String action = "EDIT CARD INSTANT";
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            load_to_grid();
                        }
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save(ex.Message)", true);
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "UNLINK USER FROM ACCOUNT")
                {
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {

                            cust_id = (sdr["customer_id"].ToString());
                        }

                    }
                    obj.conn.Close();
                    try
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                        {
                            sqlCon.Open();
                            string query = "DELETE FROM pc_customer_accounts_1_A WHERE customer_id = '" + cust_id + "'";

                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            //   MessageBox.Show("UNLINKED ACCOUNT");
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('UNLINKED USER')", true);
                        }
                        String action = "UNLINK USER FROM ACCOUNT";
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "' WHERE change_made = '" + action + "' and account ='" + GridView1.Rows[crow].Cells[5].Text + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            load_to_grid();
                        }
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save(ex.Message)", true);
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "UNLINK ACCOUNT FROM CARD")
                {
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {

                            account_number = (sdr["account_id"].ToString());
                        }

                    }
                    obj.conn.Close();
                    /*  try
                      {*/
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "Update pc_card_accounts_1_A set date_deleted = '" + time.ToString(format) + "',last_updated_date = '" + time.ToString(format) + "',last_updated_user = '" + GridView1.Rows[crow].Cells[1].Text + "' WHERE account_id = '" + account_number + "'";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //   MessageBox.Show("UNLINKED ACCOUNT");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('UNLINKED ACCOUNT')", true);
                    }
                    String action = "UNLINK ACCOUNT FROM CARD";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }
                    /*   }
                       catch (Exception ex)
                       {
                           ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save(ex.Message)", true);
                       }*/
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "UNLINK USER INSTANT FROM ACCOUNT")
                {
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {

                            cust_id = (sdr["customer_id"].ToString());
                        }

                    }
                    obj.conn.Close();
                    try
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                        {
                            sqlCon.Open();
                            string query = "DELETE FROM pc_customer_accounts_2_A WHERE customer_id = '" + cust_id + "'";

                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            // MessageBox.Show("UNLINKED ACCOUNT");
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('UNLINKED ACCOUNT')", true);
                        }
                        String action = "UNLINK USER FROM ACCOUNT";
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "' WHERE change_made = '" + action + "' and account ='" + GridView1.Rows[crow].Cells[5].Text + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            load_to_grid();
                        }
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save(ex.Message)", true);
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "UNLINK USER FROM CARD")
                {
                    try
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                        {
                            sqlCon.Open();
                            string query = "UPDATE pc_cards_1_A SET customer_id = null WHERE pan = '" + GridView1.Rows[crow].Cells[4].Text + "'";

                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            // MessageBox.Show("UNLICKED CARD");
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('UNLINKED CARD')", true);
                        }
                        String action = "UNLINK USER FROM CARD";
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            load_to_grid();
                        }
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save(ex.Message)", true);
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "UNLINK USER INSTANT FROM CARD")
                {
                    try
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                        {
                            sqlCon.Open();
                            string query = "UPDATE pc_cards_2_A SET customer_id = null WHERE pan = '" + GridView1.Rows[crow].Cells[4].Text + "'";

                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            // MessageBox.Show("UNLICKED CARD");
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('UNLINKED CARD')", true);
                        }
                        String action = "UNLINK USER INSTANT FROM CARD";
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            load_to_grid();
                        }
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save(ex.Message)", true);
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "ADD EXISTING CUSTOMER")
                {
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {

                            cust_id = (sdr["customer_id"].ToString());
                        }

                    }
                    obj.conn.Close();
                    try
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                        {
                            sqlCon.Open();
                            string query = "UPDATE pc_cards_1_A SET customer_id = '" + cust_id + "' WHERE pan = '" + GridView1.Rows[crow].Cells[4].Text + "'";

                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            // MessageBox.Show("ADD EXISTING CUSTOMER");
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ADD EXISTING CUSTOMER')", true);
                        }
                        String action = "ADD EXISTING CUSTOMER";
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            load_to_grid();
                        }
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save(ex.Message)", true);
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "ADD EXISTING CUSTOMER INSTANT")
                {
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {

                            cust_id = (sdr["customer_id"].ToString());
                        }

                    }
                    obj.conn.Close();
                    try
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                        {
                            sqlCon.Open();
                            string query = "UPDATE pc_cards_2_A SET customer_id = '" + cust_id + "' WHERE pan = '" + GridView1.Rows[crow].Cells[4].Text + "'";

                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            // MessageBox.Show("ADD EXISTING CUSTOMER");
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ADD EXISTING CUSTOMER')", true);
                        }
                        String action = "ADD EXISTING CUSTOMER";
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            load_to_grid();
                        }
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "save(ex.Message)", true);
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "ADD NEW CUSTOMER")
                {
                    System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            customer_id = (sdr["customer_id"].ToString());
                            mail_destination = (sdr["mail_destination"].ToString());
                            title = (sdr["title"].ToString());
                            first_name = (sdr["first_name"].ToString());
                            middle_initial = (sdr["middle_initial"].ToString());
                            last_name = (sdr["last_name"].ToString());
                            name_on_card = (sdr["name_on_card"].ToString());
                            mobile = (sdr["mobile"].ToString());
                            issuer_nr = (Convert.ToInt32(sdr["issuer_nr"].ToString()));
                            address_1_1 = (sdr["address_1_1"].ToString());
                            city = (sdr["city"].ToString());
                            dob = (sdr["dob"].ToString());
                            language = (sdr["language"].ToString());
                            national_id = (sdr["national_id"].ToString());
                            fax = (sdr["fax"].ToString());
                            tel_nr = (sdr["tel_nr"].ToString());
                            address_1_2 = (sdr["address_1_2"].ToString());
                            address_2_1 = (sdr["address_2_1"].ToString());
                            address_2_2 = (sdr["address_2_2"].ToString());
                            city2 = (sdr["city2"].ToString());
                            country_1 = (sdr["country_1"].ToString());
                            country_2 = (sdr["country_2"].ToString());

                        }

                    }
                    obj.conn.Close();


                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "INSERT into pc_customers_1_A (issuer_nr, customer_id  , national_id_nr  , c1_title , c1_first_name , c1_initials  , c1_last_name  , c1_name_on_card  , tel_nr , mobile_nr , fax_nr, email_address , postal_address_1 , postal_address_2 , postal_city  , postal_country  , other_address_1 , other_address_2, other_city,other_country, date_of_birth, preferred_lang , last_updated_date , last_updated_user,vip ) VALUES ('" + issuer_nr + "','" + customer_id.Trim() + "','" + national_id.Trim() + "','" + title.Trim() + "','" + first_name.Trim() + "','" + middle_initial.Trim() + "','" + last_name.Trim() + "','" + name_on_card + "','" + tel_nr.Trim() + "','" + mobile.Trim() + "','" + fax.Trim() + "','" + mail_destination.Trim() + "','" + address_1_1 + "','" + address_1_2 + "','" + city.Trim() + "','" + country_1.Trim() + "','" + address_2_1 + "','" + address_2_2 + "','" + city2.Trim() + "','" + country_2.Trim() + "','" + dob.Trim() + "','" + language.Trim() + "','" + time.ToString(format).Trim() + "','" + str2.Text.Trim() + "','0')";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //  MessageBox.Show("ADDED NEW CUSTOMER");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ADDED NEW CUSTOMER')", true);
                    }


                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "UPDATE pc_cards_1_A SET customer_id = '" + customer_id + "' WHERE pan = '" + GridView1.Rows[crow].Cells[4].Text + "'";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //  MessageBox.Show("ADDED NEW CUSTOMER");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ADDED NEW CUSTOMER')", true);
                    }
                    String action = "ADD NEW CUSTOMER";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "ADD NEW CUSTOMER INSTANT")
                {
                    System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            customer_id = (sdr["customer_id"].ToString());
                            mail_destination = (sdr["mail_destination"].ToString());
                            title = (sdr["title"].ToString());
                            first_name = (sdr["first_name"].ToString());
                            middle_initial = (sdr["middle_initial"].ToString());
                            last_name = (sdr["last_name"].ToString());
                            name_on_card = (sdr["name_on_card"].ToString());
                            mobile = (sdr["mobile"].ToString());
                            issuer_nr = (Convert.ToInt32(sdr["issuer_nr"].ToString()));
                            address_1_1 = (sdr["address_1_1"].ToString());
                            city = (sdr["city"].ToString());
                            dob = (sdr["dob"].ToString());
                            language = (sdr["language"].ToString());
                            national_id = (sdr["national_id"].ToString());
                            fax = (sdr["fax"].ToString());
                            tel_nr = (sdr["tel_nr"].ToString());
                            address_1_2 = (sdr["address_1_2"].ToString());
                            address_2_1 = (sdr["address_2_1"].ToString());
                            address_2_2 = (sdr["address_2_2"].ToString());
                            city2 = (sdr["city2"].ToString());
                            country_1 = (sdr["country_1"].ToString());
                            country_2 = (sdr["country_2"].ToString());

                        }

                    }
                    obj.conn.Close();

                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "INSERT into pc_customers_2_A (issuer_nr, customer_id  , national_id_nr  , c1_title , c1_first_name , c1_initials  , c1_last_name  , c1_name_on_card  , tel_nr , mobile_nr , fax_nr, email_address , postal_address_1 , postal_address_2 , postal_city  , postal_country  , other_address_1 , other_address_2, other_city,other_country, date_of_birth, preferred_lang , last_updated_date , last_updated_user,vip ) VALUES ('2','" + customer_id.Trim() + "','" + national_id.Trim() + "','" + title.Trim() + "','" + first_name.Trim() + "','" + middle_initial.Trim() + "','" + last_name.Trim() + "','" + name_on_card + "','" + tel_nr.Trim() + "','" + mobile.Trim() + "','" + fax.Trim() + "','" + mail_destination.Trim() + "','" + address_1_1 + "','" + address_1_2 + "','" + city.Trim() + "','" + country_1.Trim() + "','" + address_2_1 + "','" + address_2_2 + "','" + city2.Trim() + "','" + country_2.Trim() + "','" + dob.Trim() + "','" + language.Trim() + "','" + time.ToString(format).Trim() + "','" + str2.Text.Trim() + "','0')";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        // MessageBox.Show("ADDED NEW CUSTOMER");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ADDED NEW CUSTOMER')", true);
                    }


                    using (SqlConnection sqlCon = new SqlConnection(obj.locate))
                    {
                        sqlCon.Open();
                        string query = "UPDATE pc_cards_2_A SET customer_id = '" + customer_id + "' WHERE pan = '" + GridView1.Rows[crow].Cells[4].Text + "'";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //  MessageBox.Show("ADDED NEW CUSTOMER");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ADDED NEW CUSTOMER')", true);
                    }
                    String action = "ADD NEW CUSTOMER INSTANT";
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "LINK ACCOUNT")
                {
                    System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + GridView1.Rows[crow].Cells[0].Text + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            account_number = (sdr["account_id"].ToString());
                            account_product = (sdr["account_product"].ToString());
                            account_type = (sdr["account_type"].ToString());
                            currency = (sdr["other"].ToString()).Trim();
                            pan = (sdr["pan"].ToString());

                        }
                    }
                    obj.conn.Close();

                    // Link existing account
                    if (currency == "")
                    {
                        obj.conn.ConnectionString = obj.locate;
                        obj.conn.Open();
                        SqlDataReader sdr3;

                        SqlCommand cmd3 = new SqlCommand("SELECT * FROM pc_accounts_1_A where account_id = '" + account_number + "' ", obj.conn);

                        SqlDataAdapter dataAdp3 = new SqlDataAdapter(cmd3);

                        using (sdr3 = cmd3.ExecuteReader())
                        {
                            if (sdr3.Read())
                            {
                                account_product = (sdr3["account_product"].ToString());
                                account_type = (sdr3["account_type"].ToString());
                                currency = (sdr3["currency_code"].ToString());
                                // pan = (sdr3["pan"].ToString());
                                account_number = (sdr3["account_id"].ToString());

                            }

                        }
                        obj.conn.Close();

                        obj.conn.ConnectionString = obj.locate;
                        obj.conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT(*) FROM pc_card_accounts_1_A where account_id = '" + account_number + "'", obj.conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (Convert.ToInt16(dt.Rows[0][0].ToString()) > 0)
                        {
                            string query = "Update pc_card_accounts_1_A set date_deleted = NULL,last_updated_date = '" + time.ToString(format) + "',last_updated_user = '" + GridView1.Rows[crow].Cells[1].Text + "' where account_id = '" + GridView1.Rows[crow].Cells[5].Text + "'";
                            SqlCommand sqlCmd = new SqlCommand(query, obj.conn);
                            sqlCmd.ExecuteNonQuery();
                            // MessageBox.Show("ADDED NEW CUSTOMER");

                            String action = "LINK ACCOUNT";
                            using (SqlConnection sqlCon6 = new SqlConnection(obj.locate1))
                            {
                                sqlCon6.Open();
                                string query6 = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                                SqlCommand sqlCmd6 = new SqlCommand(query6, sqlCon6);
                                sqlCmd6.ExecuteNonQuery();
                                load_to_grid();
                            }
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('LINKED ACCOUNT')", true);

                        }
                        else
                        {

                            string query = "INSERT into pc_card_accounts_1_A (issuer_nr, account_id , account_type  ,  last_updated_date , last_updated_user ,pan ,account_type_nominated,account_type_qualifier,seq_nr) VALUES ('1','" + account_number.Trim() + "','" + account_type.Trim() + "','" + time.ToString(format).Trim() + "','" + GridView1.Rows[crow].Cells[1].Text.Trim() + "','" + pan + "','" + account_type.Trim() + "','1','001')";
                            SqlCommand sqlCmd = new SqlCommand(query, obj.conn);
                            sqlCmd.ExecuteNonQuery();
                            // MessageBox.Show("ADDED NEW CUSTOMER");

                            String action = "LINK ACCOUNT";
                            using (SqlConnection sqlCon6 = new SqlConnection(obj.locate1))
                            {
                                sqlCon6.Open();
                                string query6 = "UPDATE postilion_portal_changes set view_status = 1,change_made = '" + statement_accept + "', date_of_auth = '" + time.ToString(format) + "', approval_statement = 'AUTHORISED' , checker = '"+str3.Text.Trim()+"' WHERE change_made = '" + action + "' and pan ='" + GridView1.Rows[crow].Cells[4].Text + "'";
                                SqlCommand sqlCmd6 = new SqlCommand(query6, sqlCon6);
                                sqlCmd6.ExecuteNonQuery();
                                load_to_grid();
                            }
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('LINKED ACCOUNT')", true);

                            return;
                        }
                        obj.conn.Close();

                    }


                }

            }
            if (e.CommandName.Equals("reject2"))
            {

                int crow;
                crow = Convert.ToInt32(e.CommandArgument.ToString());
                if (GridView1.Rows[crow].Cells[3].Text == "LOCK LIMIT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '" + str3.Text.Trim() + "' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //   MessageBox.Show("REJECTED");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "REMOVE LOCK LIMIT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '" + str3.Text.Trim() + "' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //   MessageBox.Show("REJECTED");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "CARD LIMIT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //   MessageBox.Show("REJECTED");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "INSTANT CARD LIMIT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //   MessageBox.Show("REJECTED");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "EDIT_CUSTOMER_DETAILS_INSTANT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //   MessageBox.Show("REJECTED");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "EDIT_CUSTOMER_DETAILS_ACCOUNT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //   MessageBox.Show("REJECTED");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "PLACE HOLD ACCOUNT")
                {

                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        //   MessageBox.Show("REJECTED");
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "REMOVE HOLD ACCOUNT")
                {
                    // MessageBox.Show("here");
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }

                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "PLACE HOLD ACCOUNT INSTANT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "UNLINK ACCOUNT FROM CARD")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "LINK ACCOUNT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "REMOVE HOLD ACCOUNT INSTANT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "PLACE HOLD CARD")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "REMOVE HOLD CARD")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "PLACE HOLD CARD INSTANT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "REMOVE HOLD CARD INSTANT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "EDIT ACCOUNT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "', approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "EDIT ACCOUNT INSTANT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "ACTIVATE")
                {

                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "ACTIVATE INSTANT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "DEACTIVATE")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "DEACTIVATE INSTANT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "UNLINK USER FROM ACCOUNT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "UNLINK USER INSTANT FROM ACCOUNT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "UNLINK USER FROM CARD")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "UNLINK USER INSTANT FROM CARD")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "EDIT CARD")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "EDIT CARD INSTANT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "REISSUE CARD")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "REISSUE CARD INSTANT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "ADD EXISTING CUSTOMER")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "ADD EXISTING CUSTOMER INSTANT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "ADD NEW CUSTOMER")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "ADD NEW CUSTOMER INSTANT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "REPLACE CARD")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "REPLACE CARD INSTANT")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }
                if (GridView1.Rows[crow].Cells[3].Text == "DELETE CUSTOMER RETAIL")
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "UPDATE postilion_portal_changes set view_status = 1 ,date_of_auth = '" + time.ToString(format) + "',  approval_statement = '" + statement + "' , checker = '"+str3.Text.Trim()+"' WHERE id ='" + GridView1.Rows[crow].Cells[0].Text + "'";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('REJECTED')", true);
                        load_to_grid();
                    }
                    return;
                }

            }
        }


        public void load_to_grid()
        {

            System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label str3 = Master.FindControl("label3") as System.Web.UI.WebControls.Label;
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
            {
                sqlCon.Open();
                //   SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM postilion_portal_changes where date >='" + (Convert.ToDateTime(datepicker34.Text)).ToString(format) + "' and date <='" + (Convert.ToDateTime(datepicker1.Text)).ToString(format) + "' and view_status = 0 and branch = '"+ str.Text + "'" , sqlCon);
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM postilion_portal_changes where view_status = 0 and maker <> '"+str3.Text.Trim()+"' and branch = '" + str.Text + "' order by id desc", sqlCon);

                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                GridView1.DataSource = dtbl;
                GridView1.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                GridView1.DataSource = dtbl;
                GridView1.DataBind();
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                GridView1.Rows[0].Cells[0].Text = "No Data Found ..!";
                GridView1.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }
        }
        public void fetch_data(String id_rec)
        {
            try
            {

                obj.conn.Open();
                SqlDataReader sdr;

                SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_hold_data where id = '" + id_rec + "' ", obj.conn);

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                using (sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {

                        String action = (sdr["action"].ToString());
                        String id = (sdr["id"].ToString());
                        String branch_code = (sdr["branch_code"].ToString());
                        String hold_rsp_code = (sdr["hold_rsp_code"].ToString());
                        String customer_id = (sdr["customer_id"].ToString());
                        String place_hold = (sdr["place_hold"].ToString());
                        String account_id = (sdr["account_id"].ToString());
                        String pan = (sdr["pan"].ToString());
                        String card_status = (sdr["card_status"].ToString());
                        String reason_for_reason = (sdr["reason_for_reason"].ToString());
                        String mail_destination = (sdr["mail_destination"].ToString());
                        String seq_nr = (sdr["seq_nr"].ToString());
                        String expiry_date = (sdr["expiry_date"].ToString());
                        String title = (sdr["title"].ToString());
                        String first_name = (sdr["first_name"].ToString());
                        String middle_initial = (sdr["middle_initial"].ToString());
                        String last_name = (sdr["last_name"].ToString());
                        String name_on_card = (sdr["name_on_card"].ToString());
                        String other = (sdr["other"].ToString());
                        String account_product = (sdr["account_product"].ToString());
                        String mobile = (sdr["mobile"].ToString());
                        String issuer_nr = (sdr["issuer_nr"].ToString());
                        String account_type = (sdr["account_type"].ToString());
                        String last_updated_date = (sdr["last_updated_date"].ToString());
                        String last_updated_user = (sdr["last_updated_user"].ToString());
                        String address = (sdr["address"].ToString());
                        String city = (sdr["city"].ToString());

                    }

                }
                obj.conn.Close();
                //   MessageBox.Show("Hold response :"+hold_rsp_code);
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ERROR')", true);

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            load_to_grid();
        }
    }
}