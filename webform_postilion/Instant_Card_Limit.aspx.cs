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
    public partial class Instant_Card_Limit : System.Web.UI.Page
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
                if (Request.QueryString["pan"] != "")
                {
                    obj.conn.Open();
                    SqlDataReader sdr;

                    SqlCommand cmd = new SqlCommand("SELECT * FROM pc_card_override_lim_2_A  where pan = '" + Request.QueryString["pan"] + "' ", obj.conn);

                    SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                    using (sdr = cmd.ExecuteReader())
                    {
                        if (sdr.Read())
                        {

                            NUMBER_OF_PURCHASE.Text = ((int)sdr["goods_nr_trans_lim"]).ToString();
                            Number_of_Cash_Withdrawals.Text = ((int)sdr["cash_nr_trans_lim"]).ToString();
                            Number_of_Payments.Text = ((int)sdr["paymnt_nr_trans_lim"]).ToString();
                            Purchase_Amount.Text = (Convert.ToInt64(sdr["goods_lim"])/100).ToString();
                            Cash_Amount.Text = (Convert.ToInt64(sdr["cash_lim"]) / 100).ToString();
                            Payment_Amount.Text = (Convert.ToInt64(sdr["paymnt_lim"]) / 100).ToString();
                            Card_Not_Present_Amount.Text = (Convert.ToInt64(sdr["cnp_lim"]) / 100).ToString();
                            Deposit_Amount_Available.Text = (Convert.ToInt64(sdr["deposit_credit_lim"]) / 100).ToString();
                            Purchase_Amount_off.Text = (Convert.ToInt64(sdr["goods_offline_lim"]) / 100).ToString();
                            Cash_Amount_off.Text = (Convert.ToInt64(sdr["cash_offline_lim"]) / 100).ToString();
                            Payment_Amount_off.Text = (Convert.ToInt64(sdr["paymnt_offline_lim"]) / 100).ToString();
                            Card_Not_Present_Amount_off.Text = (Convert.ToInt64(sdr["cnp_offline_lim"]) / 100).ToString();

                            // weekly

                            TextBox1.Text = (Convert.ToInt64(sdr["weekly_goods_nr_trans_lim"])).ToString();
                            TextBox2.Text = (Convert.ToInt64(sdr["weekly_cash_nr_trans_lim"])).ToString();
                            TextBox3.Text = (Convert.ToInt64(sdr["weekly_paymnt_nr_trans_lim"])).ToString();
                            TextBox4.Text = (Convert.ToInt64(sdr["weekly_goods_lim"]) / 100).ToString();
                            TextBox5.Text = (Convert.ToInt64(sdr["weekly_cash_lim"]) / 100).ToString();
                            TextBox6.Text = (Convert.ToInt64(sdr["weekly_paymnt_lim"]) / 100).ToString();
                            TextBox7.Text = (Convert.ToInt64(sdr["weekly_cnp_lim"]) / 100).ToString();
                            TextBox8.Text = (Convert.ToInt64(sdr["weekly_deposit_credit_lim"]) / 100).ToString();
                            TextBox9.Text = (Convert.ToInt64(sdr["weekly_goods_offline_lim"]) / 100).ToString();
                            TextBox10.Text = (Convert.ToInt64(sdr["weekly_cash_offline_lim"]) / 100).ToString();
                            TextBox11.Text = (Convert.ToInt64(sdr["weekly_paymnt_offline_lim"]) / 100).ToString();
                            TextBox12.Text = (Convert.ToInt64(sdr["weekly_cnp_offline_lim"]) / 100).ToString();
                        }

                    }
                    obj.conn.Close();
                    if (TextBox1.Text == "" || NUMBER_OF_PURCHASE.Text == "" && Request.QueryString["card_program"].Trim() != "")
                    {
                        obj.conn.Open();
                        SqlDataReader sdr2;

                        SqlCommand cmd2 = new SqlCommand("SELECT * FROM pc_card_programs  where card_program = '" + Request.QueryString["card_program"].Trim() + "' ", obj.conn);

                        SqlDataAdapter dataAdp2 = new SqlDataAdapter(cmd2);

                        using (sdr2 = cmd2.ExecuteReader())
                        {
                            if (sdr2.Read())
                            {

                                NUMBER_OF_PURCHASE.Text = ((int)sdr2["goods_nr_trans_lim"]).ToString();
                                Number_of_Cash_Withdrawals.Text = ((int)sdr2["cash_nr_trans_lim"]).ToString();
                                Number_of_Payments.Text = ((int)sdr2["paymnt_nr_trans_lim"]).ToString();
                                Purchase_Amount.Text = (Convert.ToInt64(sdr2["goods_lim"]) / 100).ToString();
                                Cash_Amount.Text = (Convert.ToInt64(sdr2["cash_lim"]) / 100).ToString();
                                Payment_Amount.Text = (Convert.ToInt64(sdr2["paymnt_lim"]) / 100).ToString();
                                Card_Not_Present_Amount.Text = (Convert.ToInt64(sdr2["cnp_lim"]) / 100).ToString();
                                Deposit_Amount_Available.Text = (Convert.ToInt64(sdr2["deposit_credit_lim"]) / 100).ToString();
                                Purchase_Amount_off.Text = (Convert.ToInt64(sdr2["goods_offline_lim"]) / 100).ToString();
                                Cash_Amount_off.Text = (Convert.ToInt64(sdr2["cash_offline_lim"]) / 100).ToString();
                                Payment_Amount_off.Text = (Convert.ToInt64(sdr2["paymnt_offline_lim"]) / 100).ToString();
                                Card_Not_Present_Amount_off.Text = (Convert.ToInt64(sdr2["cnp_offline_lim"]) / 100).ToString();

                                // weekly

                                TextBox1.Text = (Convert.ToInt64(sdr2["weekly_goods_nr_trans_lim"])).ToString();
                                TextBox2.Text = (Convert.ToInt64(sdr2["weekly_cash_nr_trans_lim"])).ToString();
                                TextBox3.Text = (Convert.ToInt64(sdr2["weekly_paymnt_nr_trans_lim"])).ToString();
                                TextBox4.Text = (Convert.ToInt64(sdr2["weekly_goods_lim"]) / 100).ToString();
                                TextBox5.Text = (Convert.ToInt64(sdr2["weekly_cash_lim"]) / 100).ToString();
                                TextBox6.Text = (Convert.ToInt64(sdr2["weekly_paymnt_lim"]) / 100).ToString();
                                TextBox7.Text = (Convert.ToInt64(sdr2["weekly_cnp_lim"]) / 100).ToString();
                                TextBox8.Text = (Convert.ToInt64(sdr2["weekly_deposit_credit_lim"]) / 100).ToString();
                                TextBox9.Text = (Convert.ToInt64(sdr2["weekly_goods_offline_lim"]) / 100).ToString();
                                TextBox10.Text = (Convert.ToInt64(sdr2["weekly_cash_offline_lim"]) / 100).ToString();
                                TextBox11.Text = (Convert.ToInt64(sdr2["weekly_paymnt_offline_lim"]) / 100).ToString();
                                TextBox12.Text = (Convert.ToInt64(sdr2["weekly_cnp_offline_lim"]) / 100).ToString();
                            }

                        }
                        obj.conn.Close();
                    }
                 /*   else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('CARD PROGRAM NOT SET ON CARD')", true);
                    }*/
                }
            }

        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            // daily limits

            System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label str3 = Master.FindControl("Label3") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str4 = Master.FindControl("last_row") as System.Web.UI.WebControls.Label;
            String row = (Convert.ToDouble(str4.Text) + 1).ToString();
            if (Convert.ToInt64(Card_Not_Present_Amount_off.Text) <= Convert.ToInt64(TextBox12.Text) && Convert.ToInt64(Payment_Amount_off.Text) <= Convert.ToInt64(TextBox11.Text) && Convert.ToInt64(Cash_Amount_off.Text) <= Convert.ToInt64(TextBox10.Text) && Convert.ToInt64(Purchase_Amount_off.Text) <= Convert.ToInt64(TextBox9.Text) && Convert.ToInt64(Deposit_Amount_Available.Text) <= Convert.ToInt64(TextBox8.Text) && Convert.ToInt64(Card_Not_Present_Amount.Text) <= Convert.ToInt64(TextBox7.Text) && Convert.ToInt64(Payment_Amount.Text) <= Convert.ToInt64(TextBox6.Text) && Convert.ToInt64(Cash_Amount.Text) <= Convert.ToInt64(TextBox5.Text) && Convert.ToInt64(Purchase_Amount.Text) <= Convert.ToInt64(TextBox4.Text) && Convert.ToInt64(Number_of_Payments.Text) <= Convert.ToInt64(TextBox3.Text) && Convert.ToInt64(Number_of_Cash_Withdrawals.Text) <= Convert.ToInt64(TextBox2.Text) && Convert.ToInt64(NUMBER_OF_PURCHASE.Text) <= Convert.ToInt64(TextBox1.Text))
            {
                // validate offline amount
                if (Convert.ToInt64(Purchase_Amount.Text) >= Convert.ToInt64(Purchase_Amount_off.Text) && Convert.ToInt64(Cash_Amount.Text) >= Convert.ToInt64(Cash_Amount_off.Text) && Convert.ToInt64(Payment_Amount.Text) >= Convert.ToInt64(Payment_Amount_off.Text) && Convert.ToInt64(Card_Not_Present_Amount.Text) >= Convert.ToInt64(Card_Not_Present_Amount_off.Text))
            {
                // validate weekly amountz
                if (Convert.ToInt64(Purchase_Amount.Text) <= Convert.ToInt64(TextBox4.Text) && Convert.ToInt64(Cash_Amount.Text) <= Convert.ToInt64(TextBox5.Text) && Convert.ToInt64(Payment_Amount.Text) <= Convert.ToInt64(TextBox6.Text) && Convert.ToInt64(Card_Not_Present_Amount.Text) <= Convert.ToInt64(TextBox7.Text))
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = " insert into postilion_portal_changes (maker,date,change_made,pan,account,branch,reason,checker,view_status) values ('" + str3.Text + "','" + time.ToString(format) + "','INSTANT CARD LIMIT','" + Request.QueryString["pan"] + "','','" + str.Text + "','REQUEST TO EDIT CARD LIMIT','" + str2.Text + "' , '0')";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        string query2 = " insert into postilion_hold_data (action,id,branch_code,pan,reason_for_reason ,goods_nr_trans_lim,cash_nr_trans_lim,paymnt_nr_trans_lim,goods_lim,cash_lim,paymnt_lim,cnp_lim,deposit_credit_lim,goods_offline_lim,cash_offline_lim,paymnt_offline_lim,cnp_offline_lim,weekly_goods_nr_trans_lim,weekly_cash_nr_trans_lim,weekly_paymnt_nr_trans_lim,weekly_goods_lim,weekly_cash_lim,weekly_paymnt_lim,weekly_cnp_lim,weekly_deposit_credit_lim,weekly_goods_offline_lim,weekly_cash_offline_lim,weekly_paymnt_offline_lim,weekly_cnp_offline_lim) values ('INSTANT CARD LIMIT','" + row + "','" + str.Text + "','" + Request.QueryString["pan"] + "','','" + Convert.ToInt64(NUMBER_OF_PURCHASE.Text) + "','" + Convert.ToInt64(Number_of_Cash_Withdrawals.Text) + "','" + Convert.ToInt64(Number_of_Payments.Text) + "' , '" + Convert.ToInt64(Purchase_Amount.Text + "00") + "','" + Convert.ToInt64(Cash_Amount.Text + "00") + "','" + Convert.ToInt64(Payment_Amount.Text + "00") + "','" + Convert.ToInt64(Card_Not_Present_Amount.Text + "00") + "','" + Convert.ToInt64(Deposit_Amount_Available.Text + "00") + "','" + Convert.ToInt64(Purchase_Amount_off.Text + "00") + "','" + Convert.ToInt64(Cash_Amount_off.Text + "00") + "','" + Convert.ToInt64(Payment_Amount_off.Text + "00") + "','" + Convert.ToInt64(Card_Not_Present_Amount_off.Text + "00") + "','" + Convert.ToInt64(TextBox1.Text) + "','" + Convert.ToInt64(TextBox2.Text) + "','" + Convert.ToInt64(TextBox3.Text) + "' , '" + Convert.ToInt64(TextBox4.Text + "00") + "','" + Convert.ToInt64(TextBox5.Text + "00") + "','" + Convert.ToInt64(TextBox6.Text + "00") + "','" + Convert.ToInt64(TextBox7.Text + "00") + "','" + Convert.ToInt64(TextBox8.Text + "00") + "','" + Convert.ToInt64(TextBox9.Text + "00") + "','" + Convert.ToInt64(TextBox10.Text + "00") + "','" + Convert.ToInt64(TextBox11.Text + "00") + "','" + Convert.ToInt64(TextBox12.Text + "00") + "')";

                        SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                        sqlCmd2.ExecuteNonQuery();


                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('SAVED')", true);
                        Button4.Enabled = false;
                        sqlCon.Close();
                    }
                }
                else { ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('Weekly Amounts Should Be Greater Than Daily Amounts')", true); }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('Corresponding Offline Transaction Amounts Should Be Less Overall Transaction Amounts')", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('Weekly Amounts Should Be Greater Than Daily Amounts')", true);
            }
        }

        protected void Button4_Click1(object sender, EventArgs e)
        {

        }
    }
}