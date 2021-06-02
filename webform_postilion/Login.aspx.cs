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
        DateTime time = DateTime.Now;
        List<Model.postilion_role> Roles = new List<Model.postilion_role>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String be = "";
            Session["checker_label"] = "";
            string major_branch = "";
            string person_branch = "";

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
                            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                            {
                                sqlCon.Open();
                                string query = "INSERT into postilion_user_log (username , action, date ) VALUES ('" + TextBox1.Text + "', 'FAILED TO LOG IN','" + time + "')";
                                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                                sqlCmd.ExecuteNonQuery();
                                sqlCon.Close();
                            }
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
                                       /* if (DropDownList1.Text == "ADMINISTRATOR")
                                        {
                                            Session["User"] = TextBox1.Text;
                                            Session["role"] = DropDownList1.Text;
                                            Response.Redirect("Add_User.aspx");
                                        }*/
                                        if (DropDownList1.Text == "MAKER" || DropDownList1.Text == "ADMINISTRATOR")
                                        {
                                            Session["User"] = TextBox1.Text;
                                            Session["role"] = DropDownList1.Text;

                                            SqlDataReader sdr, sdr2, sdr3, sdr4;

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
                                            SqlCommand cmd3 = new SqlCommand("SELECT * FROM postilion_branch where branch LIKE '" + be + "%'", obj.conn);

                                            SqlDataAdapter dataAdp3 = new SqlDataAdapter(cmd3);

                                            using (sdr3 = cmd3.ExecuteReader())
                                            {
                                                if (sdr3.Read())
                                                {

                                                      major_branch = (sdr3["checker"].ToString());
                                                    person_branch = (sdr3["branch"].ToString());
                                                }

                                            }
                                            Session["major_branch"] = major_branch;
                                            Session["branch"] = be;


                                            DataTable val = new DataTable();
                                            // SqlCommand cmd4 = new SqlCommand("SELECT id , convenience_users FROM postilion_role", obj.conn);
                                            SqlCommand cmd4 = new SqlCommand("SELECT ["+person_branch.Trim()+"] FROM postilion_role ", obj.conn);
                                            SqlDataAdapter dataAdp4 = new SqlDataAdapter(cmd4);

                                            dataAdp4.Fill(val);

                                            if (val.Rows.Count > 0)

                                            {

                                                for (int i = 0; i < val.Rows.Count; i++)
                                                {

                                                    Model.postilion_role role_ = new Model.postilion_role();
                                                    role_.id = (int)val.Rows[i][person_branch.Trim()];
                                                    /*
                                                      role_.id = (int)val.Rows[i]["id"];
                                                      role_.C099_MICROPLAN_FINANCIAL_SERVICES = (int)val.Rows[i]["099 MICROPLAN FINANCIAL SERVICES"];
                                                      role_.C051_TREASURY_DEPARTMENT = (int)val.Rows[i]["051 TREASURY DEPARTMENT"];
                                                      role_.C013_KWEKWE_BRANCH = (int)val.Rows[i]["013 KWEKWE BRANCH"];
                                                      role_.C870_BS_BULAWAYO_BRANCH = (int)val.Rows[i]["870 BS BULAWAYO BRANCH"];
                                                      role_.C882_BS_GWERU_BRANCH = (int)val.Rows[i]["882 BS GWERU BRANCH"];
                                                      role_.C016_CENTRAL_CASH_DEPOT = (int)val.Rows[i]["016 CENTRAL CASH DEPOT"];
                                                      role_.C006_BATANAI_GARDENS_BRANCH = (int)val.Rows[i]["006 BATANAI GARDENS BRANCH"];
                                                      role_.C055_TRADE_FINANCE_DEPARTMENT = (int)val.Rows[i]["055 TRADE FINANCE DEPARTMENT"];
                                                      role_.C864_BS_TREASURY_BRANCH = (int)val.Rows[i]["864 BS TREASURY BRANCH"];
                                                      role_.C860_BS_REGIONAL_OFFICE = (int)val.Rows[i]["860 BS REGIONAL OFFICE"];
                                                      role_.C020_FBC_CENTRE_BRANCH = (int)val.Rows[i]["020 FBC CENTRE BRANCH"];
                                                      role_.C850_BANK_REGIONAL_OFFICE = (int)val.Rows[i]["850 BANK REGIONAL OFFICE"];
                                                      role_.C861_BS_LEOPOLD_TAKAWIRA_BRANCH = (int)val.Rows[i]["861 BS LEOPOLD TAKAWIRA BRANCH"];
                                                      role_.C027_BORROWDALE_BRANCH = (int)val.Rows[i]["027 BORROWDALE BRANCH"];
                                                      role_.C005_JASON_MOYO_STREET_BRANCH = (int)val.Rows[i]["005 JASON MOYO STREET BRANCH"];
                                                      role_.C001_SAMORA_MACHEL_AVENUE_BRANCH = (int)val.Rows[i]["001 SAMORA MACHEL AVENUE BRANCH"];
                                                      role_.C000_HEAD_OFFICE_BRANCH = (int)val.Rows[i]["000 HEAD OFFICE BRANCH"];
                                                      role_.C009_MUTARE_BRANCH = (int)val.Rows[i]["009 MUTARE BRANCH"];
                                                      role_.C007_CUSTODIAL_SERVICES = (int)val.Rows[i]["007 CUSTODIAL SERVICES"];
                                                      role_.C880_BS_MUTARE_BRANCH = (int)val.Rows[i]["880 BS MUTARE BRANCH"];
                                                      role_.C029_FBC_BUSINESS_BANKING_DIVISION = (int)val.Rows[i]["029 FBC BUSINESS BANKING DIVISION"];
                                                      role_.C008_ZVISHAVANE_BRANCH = (int)val.Rows[i]["008 ZVISHAVANE BRANCH"];
                                                      role_.C012_VICTORIA_FALLS_BRANCH = (int)val.Rows[i]["012 VICTORIA FALLS BRANCH"];
                                                      role_.C026_BEITBRIDGE_BRANCH = (int)val.Rows[i]["026 BEITBRIDGE BRANCH"];
                                                      role_.C011_CHINHOYI_BRANCH = (int)val.Rows[i]["011 CHINHOYI BRANCH"];
                                                      role_.C866_BS_PROJECTS__BRANCH = (int)val.Rows[i]["866 BS PROJECTS  BRANCH"];
                                                      role_.C018_BULAWAYO_CENTRAL_CASH = (int)val.Rows[i]["018 BULAWAYO CENTRAL CASH"];
                                                      role_.C028_GRANITE_SIDE_BRANCH = (int)val.Rows[i]["028 GRANITE SIDE BRANCH"];
                                                      role_.C014_MASVINGO_BRANCH = (int)val.Rows[i]["014 MASVINGO BRANCH"];
                                                      role_.C010_GWERU_BRANCH = (int)val.Rows[i]["010 GWERU BRANCH"];
                                                      role_.C002_NELSON_MANDELA_AVENUE_BRANCH = (int)val.Rows[i]["002 NELSON MANDELA AVENUE BRANCH"];
                                                      role_.C883_BS_KWEKWE_BRANCH = (int)val.Rows[i]["883 BS KWEKWE BRANCH"];
                                                      role_.C863_BS_MORTGAGES_BRANCH = (int)val.Rows[i]["863 BS MORTGAGES BRANCH"];
                                                      role_.C862_BS_FBC_CENTRE_BRANCH = (int)val.Rows[i]["862 BS FBC CENTRE BRANCH"];
                                                      role_.C881_BS_MASVINGO_BRANCH = (int)val.Rows[i]["881 BS MASVINGO BRANCH"];
                                                      role_.C021_MSASA_BRANCH = (int)val.Rows[i]["021 MSASA BRANCH"];
                                                      role_.C019_CONVENIENCE_BANKING_BRANCH = (int)val.Rows[i]["019 CONVENIENCE BANKING BRANCH"];
                                                      role_.C003_SOUTHERTON_BRANCH = (int)val.Rows[i]["003 SOUTHERTON BRANCH"];
                                                      role_.C865_BUSINESS_BANKING_BRANCH = (int)val.Rows[i]["865 BUSINESS BANKING BRANCH"];
                                                      role_.C004_FBC_PRIVATE_BANK__HARARE = (int)val.Rows[i]["004 FBC PRIVATE BANK, HARARE"];
                                                      role_.C022_CHITUNGWIZA_BRANCH = (int)val.Rows[i]["022 CHITUNGWIZA BRANCH"];
                                                      role_.C015_CENTRAL_PROCESSING_CENTRE = (int)val.Rows[i]["015 CENTRAL PROCESSING CENTRE"];
                                                      role_.C017_BULAWAYO_PRIVATE__BANKING_CENTRE = (int)val.Rows[i]["017 BULAWAYO PRIVATE  BANKING CENTRE"];
                                                      role_.C030_HEAD_OFFICE_BRANCH = (int)val.Rows[i]["030 HEAD OFFICE BRANCH"];
                                                      role_.C031_CORPORATE_AND_INSTITUTIONAL_BANKING = (int)val.Rows[i]["031 CORPORATE AND INSTITUTIONAL BANKING"];
                                                      role_.C960_BUREAU_DE_CHANGE_REGIONAL_OFFICE = (int)val.Rows[i]["960 BUREAU DE CHANGE REGIONAL OFFICE"];
                                                      role_.C961_KWAME_NKRUMAH_BUREAU_DE_CHANGE = (int)val.Rows[i]["961 KWAME NKRUMAH BUREAU DE CHANGE"];
                                                      role_.C962_JASON_MOYO_BUREAU_DE_CHANGE = (int)val.Rows[i]["962 JASON MOYO BUREAU DE CHANGE"];
                                                      role_.C964_KWAME_NKRUMAH_BUREAU_DE_CHANGE = (int)val.Rows[i]["964 KWAME NKRUMAH BUREAU DE CHANGE"];
                                                      role_.C032_FBC_VIRTUAL = (int)val.Rows[i]["032 FBC VIRTUAL"];

                                                    */
                                                      Roles.Add(role_);

                                                }

                                            }




                                            Session["Roles"] = Roles;

                                            if (Session["checker_label"].ToString() == "")
                                            {
                                                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('MAKER IS IN A BRANCH WITH NO CHECKER ALLOCATED')", true);

                                            }
                                            else
                                            {
                                                using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                                                {
                                                    sqlCon.Open();
                                                    string query = "INSERT into postilion_user_log (username , action, date ) VALUES ('" + TextBox1.Text + "', 'LOGGED IN','" + time + "')";
                                                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                                                    sqlCmd.ExecuteNonQuery();
                                                    sqlCon.Close();
                                                }
                                                Response.Redirect("Search_Account_Pan.aspx?acc=");
                                            }

                                        }
                                        if (DropDownList1.Text == "CHECKER" || DropDownList1.Text == "ADMINISTRATOR")
                                        {
                                            Session["User"] = TextBox1.Text;
                                            Session["role"] = DropDownList1.Text;
                                            get_checker_branch(TextBox1.Text); SqlDataReader sdr, sdr2,sdr4;

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
                                            SqlCommand cmd2 = new SqlCommand("SELECT * FROM postilion_users  where branch = '" + be + "' and username = '"+TextBox1.Text+"' and role = '" + checker + "' and active = 'active' ", obj.conn);

                                            SqlDataAdapter dataAdp2 = new SqlDataAdapter(cmd2);

                                            using (sdr2 = cmd2.ExecuteReader())
                                            {
                                                if (sdr2.Read())
                                                {

                                                    Session["checker_label"] = (sdr2["username"].ToString());

                                                }

                                            }
                                            SqlCommand cmd4 = new SqlCommand("SELECT * FROM postilion_branch where branch LIKE '" + be + "%'", obj.conn);

                                            SqlDataAdapter dataAdp3 = new SqlDataAdapter(cmd4);

                                            using (sdr4 = cmd4.ExecuteReader())
                                            {
                                                if (sdr4.Read())
                                                {

                                                    Session["major_branch"] = (sdr4["checker"].ToString());

                                                }

                                            }
                                            Session["branch"] = be;
                                            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                                            {
                                                sqlCon.Open();
                                                string query = "INSERT into postilion_user_log (username , action, date ) VALUES ('" + TextBox1.Text + "', 'LOGGED IN','" + time + "')";
                                                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                                                sqlCmd.ExecuteNonQuery();
                                                sqlCon.Close();
                                            }
                                            using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                                            {
                                                sqlCon.Open();
                                                string query = "INSERT into postilion_user_log (username , action, date ) VALUES ('" + TextBox1.Text + "', 'LOGGED IN','" + time + "')";
                                                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                                                sqlCmd.ExecuteNonQuery();
                                                sqlCon.Close();
                                            }
                                            Response.Redirect("Authorise.aspx");

                                        }
                                    }
                                    else {
                                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                                        {
                                            sqlCon.Open();
                                            string query = "INSERT into postilion_user_log (username , action, date ) VALUES ('" + TextBox1.Text + "', 'FAILED TO LOG IN','" + time + "')";
                                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                                            sqlCmd.ExecuteNonQuery();
                                            sqlCon.Close();
                                        }
                                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('WRONG CREDENTIALS OR YOUR USER IS INACTIVE')", true);

                                        return;
                                    }
                                }
                                else
                                {
                                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                                    {
                                        sqlCon.Open();
                                        string query = "INSERT into postilion_user_log (username , action, date ) VALUES ('" + TextBox1.Text + "', 'FAILED TO LOG IN','" + time + "')";
                                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                                        sqlCmd.ExecuteNonQuery();
                                        sqlCon.Close();
                                    }
                                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('FAILED TO LOGIN INSUFFICIENT LOGIN RIGHTS')", true);

                                    return ;
                                }

                            }
                            catch (DirectoryServicesCOMException ex)
                            {
                                using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                                {
                                    sqlCon.Open();
                                    string query = "INSERT into postilion_user_log (username , action, date ) VALUES ('" + TextBox1.Text + "', 'FAILED TO LOG IN','" + time + "')";
                                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                                    sqlCmd.ExecuteNonQuery();
                                    sqlCon.Close();
                                }
                                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('FAILED TO LOGIN')", true);

                                return ;
                            }
                        }

                    }
                    else
                    {
                        using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                        {
                            sqlCon.Open();
                            string query = "INSERT into postilion_user_log (username , action, date ) VALUES ('" + TextBox1.Text + "', 'FAILED TO LOG IN','" + time + "')";
                            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                            sqlCmd.ExecuteNonQuery();
                            sqlCon.Close();
                        }
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('FAILED TO LOGIN')", true);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                    {
                        sqlCon.Open();
                        string query = "INSERT into postilion_user_log (username , action, date ) VALUES ('" + TextBox1.Text + "', 'FAILED TO LOG IN','" + time + "')";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }
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
                using (SqlConnection sqlCon = new SqlConnection(obj.locate1))
                {
                    sqlCon.Open();
                    string query = "INSERT into postilion_user_log (username , action, date ) VALUES ('" + TextBox1.Text + "', 'LOGGED IN','" + time + "')";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.ExecuteNonQuery();
                    sqlCon.Close();
                }
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