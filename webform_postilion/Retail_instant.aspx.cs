using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace webform_postilion
{
    public partial class Retail_instant : System.Web.UI.Page
    {


        DateTime time = DateTime.Now;              // Use current time
        string format = "yyyy-MM-dd HH:mm:ss";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*  ClassDatabase obj = new ClassDatabase();
              obj.conn.ConnectionString = obj.locate;
              String customer_id;

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
                  obj.conn.Close();*/
            if (TextBox2.Text != "" )
            {
                PopulateGridview(TextBox2.Text);
            }
            else
            {

                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER ACCOUNT OR CARD NUMBER')", true);

            }
        }
            void PopulateGridview(String cust_id)
            {
                ClassDatabase obj2 = new ClassDatabase();


                DataTable dtbl = new DataTable();
                using (SqlConnection sqlCon = new SqlConnection(obj2.locate))
                {
                    sqlCon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT customer_id,c1_first_name,c1_name_on_card,postal_address_1,c1_last_name,tel_nr,mobile_nr FROM pc_customers_2_A where customer_id = '" + cust_id + "'", sqlCon);
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
        { }
        }
    }
