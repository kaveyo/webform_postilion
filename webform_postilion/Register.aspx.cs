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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
               
            
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            const int big = 8;
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {
               
                    if (TextBox4.Text == TextBox12.Text)
                    {
                        if (TextBox4.Text.Length >= big)
                        {
                          //  try
                          //  {
                                ClassDatabase obj = new ClassDatabase();
                                obj.conn.ConnectionString = obj.locate1;
                                obj.conn.Open();
                            SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT (*) FROM postilion_users  WHERE username = '" + TextBox1.Text + "' ", obj.conn);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows[0][0].ToString() != "1")
                            {


                                string insertUser = " insert into postilion_users(username,fullname,password,branch,role) values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + encrypt(TextBox4.Text) + "','" + DropDownList2.Text + "','" + DropDownList1.Text + "')";
                                obj.cmd.Connection = obj.conn;
                                obj.cmd.CommandText = insertUser;
                                obj.cmd.ExecuteNonQuery();
                                obj.cmd.CommandTimeout = 60;

                                obj.conn.Close();

                                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('NEW USER ADDED')", true);



                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER ALREADY EXIST USE ANOTHER USERNAME')", true);

                            }
                     

                            

                        /*    }
                            catch (Exception ex)
                            {
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ERROR '"+ex+"'')", true);

                           
                            }*/
                        }
                        else
                        {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('PASSWORD TOO SHORT')", true);

                        }
                    }
                    else
                   {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER SAME PASSWORD')", true);

                   

                    }
                
              

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER USERNAME AND PASSWORD')", true);

               
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
        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox4.Text = "";
            TextBox12.Text = "";
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER USERNAME FIRST')", true);
            }
            else
            {
                if(TextBox4.Text == "" || TextBox12.Text == "")
                {
                  
                        ClassDatabase obj = new ClassDatabase();
                        obj.conn.ConnectionString = obj.locate1;
                        obj.conn.Open();
                        string updatePassword = " update postilion_users set branch='" + DropDownList2.Text + "',role ='" + DropDownList1.Text + "' WHERE username = '" + TextBox1.Text + "'";
                        obj.cmd.Connection = obj.conn;
                        obj.cmd.CommandText = updatePassword;
                        obj.cmd.ExecuteNonQuery();

                        obj.conn.Close();

                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('CHANGED USER INFO')", true);
                    
                }
                if (TextBox4.Text != "" || TextBox12.Text != "")
                {
                    if (TextBox4.Text == TextBox12.Text)
                    {
                        if (TextBox4.Text.Length >=8)
                        {
                            String output = user(TextBox1.Text);
                            if (output == "1")
                            {
                                ClassDatabase obj = new ClassDatabase();
                                obj.conn.ConnectionString = obj.locate1;
                                obj.conn.Open();
                                string updatePassword = " update postilion_users set password = '" + encrypt(TextBox4.Text) + "' ,branch='" + DropDownList2.Text + "',role ='" + DropDownList1.Text + "' WHERE username = '" + TextBox1.Text + "'";
                                obj.cmd.Connection = obj.conn;
                                obj.cmd.CommandText = updatePassword;
                                obj.cmd.ExecuteNonQuery();

                                obj.conn.Close();

                                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('CHANGED USER INFO')", true);
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER DOES NOT EXIST')", true);
                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('PASSWORD TOO SHORT')", true);
                        }
                       
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER SAME PASSWORD')", true);
                    }
                }

            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "")
            {
                String output = user(TextBox1.Text);
                if (output == "1")
                {
                    ClassDatabase obj = new ClassDatabase();
                    obj.conn.ConnectionString = obj.locate1;
                    obj.conn.Open();

                    string DeleteItem = " delete from postilion_users where username = '" + TextBox1.Text + "' and branch = '" + DropDownList2.Text + "' and role = '" + DropDownList1.Text + "' ";

                    obj.cmd.Connection = obj.conn;
                    obj.cmd.CommandText = DeleteItem;
                   int a = obj.cmd.ExecuteNonQuery();

                    obj.conn.Close();
                    if (a==1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('successfully done')", true);
                    }
                    else
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('NOT SUCCESSFUL CHECK IF BRANCH AND ROLE ARE CORRECT')", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('USER DOES NOT EXIST')", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "randomtext", "alertme('ENTER USERNAME AND SELECT BRANCH AND ROLE OF USER')", true);
            }
         

        }
        string user(String user_passed)
        {
            ClassDatabase obj = new ClassDatabase();
            obj.conn.ConnectionString = obj.locate1;
            obj.conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT (*) FROM postilion_users  WHERE username = '" + user_passed + "' ", obj.conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows[0][0].ToString() != "1")
            {
                return "0";
            }
            else
                return "1";
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Session["User"] = "ADMIN";
            Session["role"] = "ADMIN";
            Session["checker_label"] = "ADMIN";
            Session["branch"] = "UNIVERSAL";
            Response.Redirect("Report_by_period.aspx");
        }
    }
}