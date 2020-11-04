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

        string id,username;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 id = Request.QueryString["id"];
                 username = Request.QueryString["username"];
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
         
            if (role.Enabled == true && DropDownList2.Enabled == true && status.Enabled == true)
            {
               // bool isDigitPresent = password1.Text.Any(c => char.IsDigit(c));

                    

                        ClassDatabase obj = new ClassDatabase();
                        obj.conn.ConnectionString = obj.locate1;
                        obj.conn.Open();

                        string insertUser = "update postilion_users set branch = '" + DropDownList2.Text.Substring(0,3) + "',role = '" + role.Text + "', active = '"+status.Text+"' where user_id = '" + Request.QueryString["id"] + "'";
                        obj.cmd.Connection = obj.conn;
                        obj.cmd.CommandText = insertUser;
                        obj.cmd.ExecuteNonQuery();
                        obj.cmd.CommandTimeout = 60;
                        
                        string insertUser2 = "update postilion_user_list set  branch = '" + DropDownList2.Text.Substring(0, 3) + "',role = '" + role.Text + "',status = '" + status.Text + "'  where username = '" + Request.QueryString["username"] + "'";
                        obj.cmd.Connection = obj.conn;
                        obj.cmd.CommandText = insertUser2;
                        obj.cmd.ExecuteNonQuery();
                        obj.cmd.CommandTimeout = 60;
                        obj.conn.Close();

                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER UPDATED')", true);

                   
              
            }
            if ( role.Enabled == true && DropDownList2.Enabled == false && status.Enabled == true)
            {

                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;
                obj.conn.Open();

                string insertUser = "update postilion_users set role = '" + role.Text + "', active = '" + status.Text + "' where user_id = '" + Request.QueryString["id"] + "'";
                obj.cmd.Connection = obj.conn;
                obj.cmd.CommandText = insertUser;
                obj.cmd.ExecuteNonQuery();
                obj.cmd.CommandTimeout = 60;

                string insertUser2 = "update postilion_user_list set role = '" + role.Text + "',status = '" + status.Text + "'  where username = '" + Request.QueryString["username"] + "'";
                obj.cmd.Connection = obj.conn;
                obj.cmd.CommandText = insertUser2;
                obj.cmd.ExecuteNonQuery();
                obj.cmd.CommandTimeout = 60;
                obj.conn.Close();

                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER UPDATED')", true);



            }
            if ( role.Enabled == false && DropDownList2.Enabled == true && status.Enabled == true)
            {
                //  bool isDigitPresent = password1.Text.Any(c => char.IsDigit(c));


                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;
                obj.conn.Open();

                string insertUser = "update postilion_users set branch = '" + DropDownList2.Text.Substring(0, 3) + "', active = '" + status.Text + "' where user_id = '" + Request.QueryString["id"] + "'";
                obj.cmd.Connection = obj.conn;
                obj.cmd.CommandText = insertUser;
                obj.cmd.ExecuteNonQuery();
                obj.cmd.CommandTimeout = 60;

                string insertUser2 = "update postilion_user_list set  branch = '" + DropDownList2.Text.Substring(0, 3) + "',status = '" + status.Text + "'  where username = '" + Request.QueryString["username"] + "'";
                obj.cmd.Connection = obj.conn;
                obj.cmd.CommandText = insertUser2;
                obj.cmd.ExecuteNonQuery();
                obj.cmd.CommandTimeout = 60;
                obj.conn.Close();

                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER UPDATED')", true);




            }

            if (role.Enabled == false && DropDownList2.Enabled == false && status.Enabled == false)
            {
                
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('SELECT OPTION WHICH YOU WANT TO UPDATE')", true);

            }
            if (role.Enabled == true && DropDownList2.Enabled == true && status.Enabled == false)
            {

                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;
                obj.conn.Open();

                string insertUser = "update postilion_users set branch = '" + DropDownList2.Text.Substring(0, 3) + "',role = '" + role.Text + "' where user_id = '" + Request.QueryString["id"] + "'";
                obj.cmd.Connection = obj.conn;
                obj.cmd.CommandText = insertUser;
                obj.cmd.ExecuteNonQuery();
                obj.cmd.CommandTimeout = 60;

                string insertUser2 = "update postilion_user_list set  branch = '" + DropDownList2.Text.Substring(0, 3) + "',role = '" + role.Text + "' where username = '" + Request.QueryString["username"] + "'";
                obj.cmd.Connection = obj.conn;
                obj.cmd.CommandText = insertUser2;
                obj.cmd.ExecuteNonQuery();
                obj.cmd.CommandTimeout = 60;
                obj.conn.Close();

                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER UPDATED')", true);


            }
            
            if (role.Enabled == false && DropDownList2.Enabled == true && status.Enabled == false)
            {


                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;
                obj.conn.Open();

                string insertUser = "update postilion_users set branch = '" + DropDownList2.Text.Substring(0, 3) + "' where user_id = '" + Request.QueryString["id"] + "'";
                obj.cmd.Connection = obj.conn;
                obj.cmd.CommandText = insertUser;
                obj.cmd.ExecuteNonQuery();
                obj.cmd.CommandTimeout = 60;

                string insertUser2 = "update postilion_user_list set  branch = '" + DropDownList2.Text.Substring(0, 3) + "' where username = '" + Request.QueryString["username"] + "'";
                obj.cmd.Connection = obj.conn;
                obj.cmd.CommandText = insertUser2;
                obj.cmd.ExecuteNonQuery();
                obj.cmd.CommandTimeout = 60;
                obj.conn.Close();

                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER UPDATED')", true);


            }

            if (role.Enabled == false && DropDownList2.Enabled == false && status.Enabled == true)
            {
                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;
                obj.conn.Open();

                string insertUser = "update postilion_users set active = '" + status.Text + "' where user_id = '" + Request.QueryString["id"] + "'";
                obj.cmd.Connection = obj.conn;
                obj.cmd.CommandText = insertUser;
                obj.cmd.ExecuteNonQuery();
                obj.cmd.CommandTimeout = 60;

                string insertUser2 = "update postilion_user_list set status = '" + status.Text + "'  where username = '" + Request.QueryString["username"] + "'";
                obj.cmd.Connection = obj.conn;
                obj.cmd.CommandText = insertUser2;
                obj.cmd.ExecuteNonQuery();
                obj.cmd.CommandTimeout = 60;
                obj.conn.Close();

                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER UPDATED')", true);


            }
            if (role.Enabled == true && DropDownList2.Enabled == false && status.Enabled == false)
            {

                ClassDatabase obj = new ClassDatabase();
                obj.conn.ConnectionString = obj.locate1;
                obj.conn.Open();

                string insertUser = "update postilion_users set role = '" + role.Text + "' where user_id = '" + Request.QueryString["id"] + "'";
                obj.cmd.Connection = obj.conn;
                obj.cmd.CommandText = insertUser;
                obj.cmd.ExecuteNonQuery();
                obj.cmd.CommandTimeout = 60;

                string insertUser2 = "update postilion_user_list set role = '" + role.Text + "' where username = '" + Request.QueryString["username"] + "'";
                obj.cmd.Connection = obj.conn;
                obj.cmd.CommandText = insertUser2;
                obj.cmd.ExecuteNonQuery();
                obj.cmd.CommandTimeout = 60;
                obj.conn.Close();

                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER UPDATED')", true);


            }
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

     /*   protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
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
        }*/

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Delete_User.aspx");
        }

        protected void CheckBox2_CheckedChanged3(object sender, EventArgs e)
        {
            if (status.Enabled == false)
            {
                status.Enabled = true;
            }
            else
            {
                status.Enabled = false;
            }
        }
    }
    }
