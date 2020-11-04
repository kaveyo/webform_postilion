using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
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
    public partial class Login : System.Web.UI.Page
    {
        ClassDatabase obj = new ClassDatabase();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String be = "";
            Session["checker_label"] = "";

            if (TextBox1.Text == "" && TextBox2.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('Enter All fields')", true);
            }
            else
            {

                try
                {
                    // set up domain context
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "FBC.CORP");

                    // find a user
                    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, TextBox1.Text);

                    if (user != null)
                    {
                        // check user lockout state
                        if (user.IsAccountLockedOut())
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('YOU ARE LOCKED OUT')", true);
                            return;
                        }
                        else
                        {

                            //Authenticate user

                            bool authentic = false;
                            try
                            {
                                DirectoryEntry entry = new DirectoryEntry("LDAP://10.170.8.20:389/OU=FBC,DC=fbc,DC=corp", TextBox1.Text, TextBox2.Text);
                                DirectoryEntry ldapConnection = new DirectoryEntry("FBC.CORP");
                                ldapConnection.Path = "LDAP://";
                                ldapConnection.Username = "Nyakudyap";// "Mashingat";
                                ldapConnection.Password = "legend45*";//"password1*"
                                ldapConnection.AuthenticationType = AuthenticationTypes.Secure;

                                //Login with user
                                object nativeObject = entry.NativeObject;
                                authentic = true;

                                if (authentic == true)
                                {
                                    //Navigate to home
                                    obj.conn.ConnectionString = obj.locate1;
                                    obj.conn.Open();
                                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT (*) FROM postilion_users  WHERE username = '" + TextBox1.Text.ToLower() + "' and role ='" + DropDownList1.Text + "' and active = 'active'" , obj.conn);
                                    DataTable dt = new DataTable();
                                    adapter.Fill(dt);
                                    if (dt.Rows[0][0].ToString() == "1")
                                    {
                                        if (DropDownList1.Text == "ADMINISTRATOR")
                                        {
                                           
                                            Response.Redirect("Add_User.aspx");
                                        }
                                        if (DropDownList1.Text == "MAKER")
                                        {
                                            Session["User"] = TextBox1.Text;
                                            Session["role"] = DropDownList1.Text;

                                            SqlDataReader sdr, sdr2;

                                            SqlCommand cmd = new SqlCommand("SELECT branch FROM postilion_users  where username = '" + TextBox1.Text.ToLower() + "' ", obj.conn);

                                            SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                                            using (sdr = cmd.ExecuteReader())
                                            {
                                                if (sdr.Read())
                                                {
                                                    be = (sdr["branch"].ToString());

                                                }

                                            }
                                            String checker = "CHECKER";
                                            SqlCommand cmd2 = new SqlCommand("SELECT * FROM postilion_users where branch = '" + be + "' and role = '" + checker + "' ", obj.conn);

                                            SqlDataAdapter dataAdp2 = new SqlDataAdapter(cmd2);

                                            using (sdr2 = cmd2.ExecuteReader())
                                            {
                                                if (sdr2.Read())
                                                {

                                                    Session["checker_label"] = (sdr2["username"].ToString());

                                                }

                                            }
                                            Session["branch"] = be;

                                            if (Session["checker_label"].ToString() == "")
                                            {
                                                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('MAKER IS IN A BRANCH WITH NO CHECKER ALLOCATED')", true);

                                            }
                                            else
                                            {
                                                Response.Redirect("Search_Account_Pan.aspx?acc=");
                                            }

                                        }
                                        if (DropDownList1.Text == "CHECKER")
                                        {
                                            Session["User"] = TextBox1.Text;
                                            Session["role"] = DropDownList1.Text;
                                            get_checker_branch(TextBox1.Text); SqlDataReader sdr, sdr2;

                                            SqlCommand cmd = new SqlCommand("SELECT branch FROM postilion_users  where username = '" + TextBox1.Text.ToLower() + "' ", obj.conn);

                                            SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                                            using (sdr = cmd.ExecuteReader())
                                            {
                                                if (sdr.Read())
                                                {

                                                    be = (sdr["branch"].ToString());

                                                }

                                            }
                                            String checker = "CHECKER";
                                            SqlCommand cmd2 = new SqlCommand("SELECT * FROM postilion_users  where branch = '" + be + "' and role = '" + checker + "' and active = 'active' ", obj.conn);

                                            SqlDataAdapter dataAdp2 = new SqlDataAdapter(cmd2);

                                            using (sdr2 = cmd2.ExecuteReader())
                                            {
                                                if (sdr2.Read())
                                                {

                                                    Session["checker_label"] = (sdr2["username"].ToString());

                                                }

                                            }

                                            Session["branch"] = be;
                                            Response.Redirect("Authorise.aspx");

                                        }
                                    }
                                    else {
                                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('WRONG CREDENTIALS OR YOUR USER IS INACTIVE')", true);

                                        return;
                                    }
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('FAILED TO LOGIN INSUFFICIENT LOGIN RIGHTS')", true);

                                    return ;
                                }

                            }
                            catch (DirectoryServicesCOMException ex)
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('FAILED TO LOGIN')", true);

                                return ;
                            }
                        }

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('FAILED TO LOGIN')", true);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('FAILED TO LOGIN')", true);
                    return ;
                }


                String Pass = encrypt(TextBox2.Text);
             

            }
        }
        void get_checker_branch(string username)
        {
            try
            {

             //   obj.conn.Open();
                SqlDataReader sdr,sdr2;

                SqlCommand cmd = new SqlCommand("SELECT * FROM postilion_users  where username = '" + username.ToLower() + "' ", obj.conn);

                SqlDataAdapter dataAdp = new SqlDataAdapter(cmd);

                using (sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {

                        Session["branch"] = (sdr["branch"].ToString());
                      
                    }

                }
                String checker = "CHECKER";
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM postilion_users  where branh = '" + Session["branch"].ToString() + "' and role = '"+checker+"' ", obj.conn);

                SqlDataAdapter dataAdp2 = new SqlDataAdapter(cmd2);

                using (sdr2 = cmd2.ExecuteReader())
                {
                    if (sdr2.Read())
                    {

                        Session["checker_label"] = (sdr2["username"].ToString());

                    }

                }
            //    obj.conn.Close();

                Response.Redirect("Search_Account_Pan.aspx");
            }
            catch (Exception ex)
            {

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
        /*      public string Decrypt(string cipherText)
              {
                  string EncryptionKey = "0123456789ABCDEFGHIlll90_o0MNOPQRSTUVWXYZ";
                  cipherText = cipherText.Replace(" ", "+");
                  byte[] cipherBytes = Convert.FromBase64String(cipherText);
                  using (Aes encryptor = Aes.Create())
                  {
                      Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
                  0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
              });
                      encryptor.Key = pdb.GetBytes(32);
                      encryptor.IV = pdb.GetBytes(16);
                      using (MemoryStream ms = new MemoryStream())
                      {
                          using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                          {
                              cs.Write(cipherBytes, 0, cipherBytes.Length);
                              cs.Close();
                          }
                          cipherText = Encoding.Unicode.GetString(ms.ToArray());
                      }
                  }
                  return cipherText;
              }*/
        public void action()
        {
            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('EXECUTED')", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           // ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "myFunction()", true);

            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('EXECUTED')", true);
        }
    }
}