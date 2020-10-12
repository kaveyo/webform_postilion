using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace webform_postilion
{
    public partial class Update_User : System.Web.UI.Page
    {

        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 id = Request.QueryString["id"];
              
                filldrop();
            }
        }
        private void filldrop()
        {
            DropDownList2.DataSource = getBranches();
            DropDownList2.DataTextField = "branch";
            DropDownList2.DataValueField = "branch";
            DropDownList2.DataBind();

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
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (DropDownList2.Enabled == false)
            {
                DropDownList2.Enabled = true;
            }
            else
            {
                DropDownList2.Enabled = false;
            }
        }
        public string encrypt(string encryptString)
        {
            string EncryptionKey = "0123456789ABCDEFGHIlll90_o0MNOPQRSTUVWXYZ";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            
            const int big = 8;
            if (password1.Enabled == true && role.Enabled == false && DropDownList2.Enabled == false)
            {
                bool isDigitPresent = password1.Text.Any(c => char.IsDigit(c));

                if (password1.Text == password2.Text)
                {
                    if (password1.Text.Length >= big && isDigitPresent)
                    {

                        ClassDatabase obj = new ClassDatabase();
                        obj.conn.ConnectionString = obj.locate1;
                        obj.conn.Open();
      
                            string insertUser = "update postilion_users set password = '"+ encrypt(password1.Text) + "' where user_id = '" + Request.QueryString["id"] + "'";
                            obj.cmd.Connection = obj.conn;
                            obj.cmd.CommandText = insertUser;
                            obj.cmd.ExecuteNonQuery();
                            obj.cmd.CommandTimeout = 60;

                            obj.conn.Close();

                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER UPDATED')", true);

                         
                            password1.Text = "";
                            password2.Text = "";
                     /*   }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER NOT FOUND')", true);

                        }*/


                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('PASSWORD TOO SHORT AND ALSO INCLUDE A NUMBER ')", true);

                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER SAME PASSWORD')", true);

                }
            }
            if (password1.Enabled == true && role.Enabled == true && DropDownList2.Enabled == true)
            {
                bool isDigitPresent = password1.Text.Any(c => char.IsDigit(c));

                if (password1.Text == password2.Text)
                {
                    if (password1.Text.Length >= big && isDigitPresent)
                    {

                        ClassDatabase obj = new ClassDatabase();
                        obj.conn.ConnectionString = obj.locate1;
                        obj.conn.Open();
                        /*    SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT (*) FROM postilion_users  WHERE first_name = '" + password1.Text + "' and last_name = '"+password1.Text+"' ", obj.conn);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows[0][0].ToString() != "0")
                            {

    */
                        string insertUser = "update postilion_users set password = '" + encrypt(password1.Text) + "',branch = '" + DropDownList2.Text.Substring(0,3) + "',role = '" + role.Text + "' where user_id = '" + Request.QueryString["id"] + "'";
                        obj.cmd.Connection = obj.conn;
                        obj.cmd.CommandText = insertUser;
                        obj.cmd.ExecuteNonQuery();
                        obj.cmd.CommandTimeout = 60;

                        obj.conn.Close();

                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER UPDATED')", true);


                        password1.Text = "";
                        password1.Text = "";
                        /*   }
                           else
                           {
                               ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER NOT FOUND')", true);

                           }*/


                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('PASSWORD TOO SHORT AND ALSO INCLUDE A NUMBER ')", true);

                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER SAME PASSWORD')", true);

                }
            }
            if (password1.Enabled == true && role.Enabled == true && DropDownList2.Enabled == false)
            {
                bool isDigitPresent = password1.Text.Any(c => char.IsDigit(c));

                if (password1.Text == password2.Text)
                {
                    if (password1.Text.Length >= big && isDigitPresent)
                    {

                        ClassDatabase obj = new ClassDatabase();
                        obj.conn.ConnectionString = obj.locate1;
                        obj.conn.Open();
                        /*    SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT (*) FROM postilion_users  WHERE first_name = '" + password1.Text + "' and last_name = '"+password1.Text+"' ", obj.conn);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows[0][0].ToString() != "0")
                            {

    */
                        string insertUser = "update postilion_users set password = '" + encrypt(password1.Text) + "' , role = '" + role.Text + "' where user_id = '" + Request.QueryString["id"] + "'";
                        obj.cmd.Connection = obj.conn;
                        obj.cmd.CommandText = insertUser;
                        obj.cmd.ExecuteNonQuery();
                        obj.cmd.CommandTimeout = 60;

                        obj.conn.Close();

                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER UPDATED')", true);


                        password1.Text = "";
                        password1.Text = "";
                        /*   }
                           else
                           {
                               ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER NOT FOUND')", true);

                           }*/


                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('PASSWORD TOO SHORT AND ALSO INCLUDE A NUMBER ')", true);

                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER SAME PASSWORD')", true);

                }
            }
            if (password1.Enabled == true && role.Enabled == false && DropDownList2.Enabled == true)
            {
                bool isDigitPresent = password1.Text.Any(c => char.IsDigit(c));

                if (password1.Text == password2.Text)
                {
                    if (password1.Text.Length >= big && isDigitPresent)
                    {

                        ClassDatabase obj = new ClassDatabase();
                        obj.conn.ConnectionString = obj.locate1;
                        obj.conn.Open();
                        /*    SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT (*) FROM postilion_users  WHERE first_name = '" + password1.Text + "' and last_name = '"+password1.Text+"' ", obj.conn);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows[0][0].ToString() != "0")
                            {

    */
                        string insertUser = "update postilion_users set password = '" + encrypt(password1.Text) + "' , branch = '" + DropDownList2.Text.Substring(0, 3) + "' where user_id = '" + Request.QueryString["id"] + "'";
                        obj.cmd.Connection = obj.conn;
                        obj.cmd.CommandText = insertUser;
                        obj.cmd.ExecuteNonQuery();
                        obj.cmd.CommandTimeout = 60;

                        obj.conn.Close();

                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER UPDATED')", true);


                        password1.Text = "";
                        password1.Text = "";
                        /*   }
                           else
                           {
                               ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER NOT FOUND')", true);

                           }*/


                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('PASSWORD TOO SHORT AND ALSO INCLUDE A NUMBER ')", true);

                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER SAME PASSWORD')", true);

                }
            }

            if (password1.Enabled == false && role.Enabled == false && DropDownList2.Enabled == false)
            {
                
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('SELECT OPTION WHICH YOU WANT TO UPDATE')", true);

            }
            if (password1.Enabled == false && role.Enabled == true && DropDownList2.Enabled == true)
            {
                 

                        ClassDatabase obj = new ClassDatabase();
                        obj.conn.ConnectionString = obj.locate1;
                        obj.conn.Open();
                        /*    SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT (*) FROM postilion_users  WHERE first_name = '" + password1.Text + "' and last_name = '"+password1.Text+"' ", obj.conn);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows[0][0].ToString() != "0")
                            {

    */
                        string insertUser = "update postilion_users set branch = '" + DropDownList2.Text.Substring(0, 3) + "',role = '" + role.Text + "' where user_id = '" + Request.QueryString["id"] + "'";
                        obj.cmd.Connection = obj.conn;
                        obj.cmd.CommandText = insertUser;
                        obj.cmd.ExecuteNonQuery();
                        obj.cmd.CommandTimeout = 60;

                        obj.conn.Close();

                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER UPDATED')", true);


            }
            if (password1.Enabled == false && role.Enabled == true && DropDownList2.Enabled == false)
            {
                

                        ClassDatabase obj = new ClassDatabase();
                        obj.conn.ConnectionString = obj.locate1;
                        obj.conn.Open();
                        /*    SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT (*) FROM postilion_users  WHERE first_name = '" + password1.Text + "' and last_name = '"+password1.Text+"' ", obj.conn);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows[0][0].ToString() != "0")
                            {

    */
                        string insertUser = "update postilion_users set role = '" + role.Text + "' where user_id = '" + Request.QueryString["id"] + "'";
                        obj.cmd.Connection = obj.conn;
                        obj.cmd.CommandText = insertUser;
                        obj.cmd.ExecuteNonQuery();
                        obj.cmd.CommandTimeout = 60;

                        obj.conn.Close();

                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER UPDATED')", true);

                 
            }
            if (password1.Enabled == false && role.Enabled == false && DropDownList2.Enabled == true)
            {
               

                        ClassDatabase obj = new ClassDatabase();
                        obj.conn.ConnectionString = obj.locate1;
                        obj.conn.Open();

                        string insertUser = "update postilion_users set branch = '" + DropDownList2.Text.Substring(0, 3) + "' where user_id = '" + Request.QueryString["id"] + "'";
                        obj.cmd.Connection = obj.conn;
                        obj.cmd.CommandText = insertUser;
                        obj.cmd.ExecuteNonQuery();
                        obj.cmd.CommandTimeout = 60;

                        obj.conn.Close();

                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER UPDATED')", true);


                    
            }
      
          /*  else if(password1.Text == "" || password2.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER ALL FIELDS')", true);

            }*/
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (role.Enabled == false)
            {
                role.Enabled = true;
            }
            else
            {
                role.Enabled = false;
            }
        }

        protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (password1.Enabled == false)
            {
                password1.Enabled = true;
                password2.Enabled = true;
                RequiredFieldValidator1.Enabled = true;
                RequiredFieldValidator2.Enabled = true;

            }
            else
            {
                password1.Enabled = false;
                password2.Enabled = false;
                RequiredFieldValidator1.Enabled = false;
                RequiredFieldValidator2.Enabled = false;

            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Delete_User.aspx");
        }
    }
    }
