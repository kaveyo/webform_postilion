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
    
    public partial class Add_User : System.Web.UI.Page
    {
        DateTime time = DateTime.Now;              // Use current time
        string format = "yyyy-MM-dd HH:mm:ss";

        protected void Page_Load(object sender, EventArgs e)
        {
         
            if (!IsPostBack) {
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
            bool userExists = false;
           
            using (var ctx = new PrincipalContext(ContextType.Domain))
            {
                using (var user = UserPrincipal.FindByIdentity(ctx, username.Text.ToLower()))
                {
                    if (user != null)
                    {
                        
                        userExists = true;
                       // ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('FULL NAME :'+'"+user.DisplayName+"')", true);
                        ClassDatabase obj = new ClassDatabase();
                        obj.conn.ConnectionString = obj.locate1;
                      

                        obj.conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT (*) FROM postilion_users  WHERE username = '" + username.Text.ToLower() + "' ", obj.conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows[0][0].ToString() != "1")
                        {


                            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                            {
                                sqlCon.Open();
                                string query = " insert into postilion_users(username,first_name,branch,role,active) values ('" + username.Text.ToLower() + "','" + user.DisplayName.ToLower() + "','" + DropDownList2.Text.Substring(0, 3) + "','" + role.Text + "','active')";

                                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.ExecuteNonQuery();

                                string query2 =" insert into postilion_user_list(username,role,create_date,last_updated,last_login,status,branch) values ('" + username.Text.ToLower() + "','" + role.Text + "','" + time.ToString(format) + "','" + time.ToString(format) + "','','active','"+DropDownList2.Text.Substring(0, 3) + "')";

                                SqlCommand sqlCmd2 = new SqlCommand(query2, sqlCon);

                                sqlCmd2.ExecuteNonQuery();

                            
                            }

                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('NEW USER ADDED :'+'" + user.DisplayName + "')", true);

                            username.Text = "";
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER ALREADY EXIST')", true);

                        }
                        user.Dispose();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('NEW USER DOES NOT EXIST')", true);

                    }
                }
            }

                       

          /*  System.Web.UI.WebControls.Label str = Master.FindControl("branch_label") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str2 = Master.FindControl("checker_label") as System.Web.UI.WebControls.Label;

            System.Web.UI.WebControls.Label str3 = Master.FindControl("Label3") as System.Web.UI.WebControls.Label;
            System.Web.UI.WebControls.Label str4 = Master.FindControl("last_row") as System.Web.UI.WebControls.Label;

            const int big = 8;
            if (username.Text != "" && first.Text != "" && surname.Text != "" && password1.Text != "" && DropDownList2.Text.Substring(0, 3) != "" && DropDownList2.Text != "None")
            {
                try
                {
                    // set up domain context
                    PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "FBC.CORP");

                    // find a user
                    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, username.Text);

                    if (user != null)
                    {
                        // check user lockout state
                        if (user.IsAccountLockedOut())
                        {
                             Session["Message"] = "You are locked out";
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('YOU ARE LOCKED OUT')", true);

                            return ;
                        }
                        else
                        {

                            //Authenticate user

                            bool authentic = false;
                            try
                            {
                                DirectoryEntry entry = new DirectoryEntry("LDAP://10.170.8.20:389/OU=FBC,DC=fbc,DC=corp", username, password);
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
                                    Session["USER"] = username;
                                    return View("HomePage2");
                                }
                                else
                                {
                                    //MsgBox("Insufficient rights to login!", this.Page, this);
                                    // Session["Message"] = "You are locked out";
                                    ViewBag.Message = "FAILED TO LOGIN INSUFFICIENT LOGIN RIGHTS";
                                    return View();
                                }

                            }
                            catch (DirectoryServicesCOMException ex)
                            {
                                // MsgBox("Login failure. " + ex.Message, this.Page, this);
                                Session["Message"] = "You are locked out";
                                ViewBag.Message = "FAILED TO LOGIN";
                                return View();
                            }
                        }

                    }
                    else
                    {
                        Session["Message"] = "You are locked out";
                        ViewBag.Message = "FAILED TO LOGIN USER NOT AVAILABLE";
                        return View();
                        // MsgBox("Could not locate user " + Session["Mutumwa"].ToString() + " from FBC.CORP Domain", this.Page, this);
                    }
                }
                catch (Exception ex)
                {
                    // MsgBox("An excaption have been caught. Exception: " + ex.Message, this.Page, this);
                    Session["Message"] = "You are locked out";
                    ViewBag.Message = "FAILED TO LOGIN" + ex.ToString();
                    return View();
                }

                bool isDigitPresent = password1.Text.Any(c => char.IsDigit(c));

                if (password1.Text == password2.Text)
                {
                    if (password1.Text.Length >= big && isDigitPresent  )
                    {
                        
                        ClassDatabase obj = new ClassDatabase();
                        obj.conn.ConnectionString = obj.locate1;
                        obj.conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT (*) FROM postilion_users  WHERE username = '" + username.Text + "' ", obj.conn);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        if (dt.Rows[0][0].ToString() != "1")
                        {


                            string insertUser = " insert into postilion_users(username,first_name,last_name,password,branch,role) values ('" + username.Text.ToLower() + "','" + first.Text.ToLower() + "','"+surname.Text.ToLower() + "','" + encrypt(password1.Text) + "','" + DropDownList2.Text.Substring(0, 3) + "','" + role.Text + "')";
                            obj.cmd.Connection = obj.conn;
                            obj.cmd.CommandText = insertUser;
                            obj.cmd.ExecuteNonQuery();
                            obj.cmd.CommandTimeout = 60;

                            string insertUser_list = " insert into postilion_user_list(username,role,create_date,last_updated,late_login,status,branch) values ('" + username.Text.ToLower() + "','" + DropDownList2.Text + "','" + time.ToString(format) + "','','" + DropDownList2.Text.Substring(0, 3) + "','" + role.Text + "')";
                            obj.cmd.Connection = obj.conn;
                            obj.cmd.CommandText = insertUser_list;
                            obj.cmd.ExecuteNonQuery();
                            obj.cmd.CommandTimeout = 60;

                            obj.conn.Close();

                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('NEW USER ADDED')", true);

                            username.Text = "";
                            first.Text = "";
                            surname.Text = "";
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER ALREADY EXIST USE ANOTHER USERNAME')", true);

                        }


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
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER ALL FIELDS')", true);

            }*/
        }
    }
}