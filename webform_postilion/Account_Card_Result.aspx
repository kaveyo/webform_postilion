﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account_Card_Result.aspx.cs" Inherits="webform_postilion.Account_Card_Result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <script>
        /*function alertme( msg) {
            Swal.fire({
                title: 'Are you sure?',
                text: "You won't be able to revert this!",
                icon: 'warning',
                html: '<a href = "Login.aspx/action">links</a>',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: '<a href="Replace.aspx/action" style="color: #FFFFFF"> BACK</a> Yes, UNLINK!'
            }).then((result) => {
                if (result.value) {
                    Swal.fire(
                        alert("hello"),
                        'UNLINKED!',
                        'SUCCESSFULLY UNLINKED.',
                        'success'
                    )
                    try {
                        $.ajax({
                            type: "POST",
                            url:'Account_Card_Result/action_',
                            data: "{'money':'msg'}",
                            contentType: "applicatiion/json; charset=utf-8",
                            dataType: "json",

                        });
                    } catch (err) {

                    }

                }
            })
        
           }*/
           function place(msg) {
               Swal.fire({
                   position: 'center',
                   icon: 'success',
                   title: 'You Have Successfully '+msg,
                   showConfirmButton: false,
                   timer: 1200
               })

           }
           
               function alertme( msg) {
                   swal({
                       title: "ALERT",

                       text: msg,
                       icon: "success",
                       button: "OK"

                   });
        }
    
           function activate(msg) {
               Swal.fire({
                   position: 'center',
                   icon: 'success',
                   title: 'You Have Successfully ' + msg,
                   showConfirmButton: false,
                   timer: 1200
               })

           }
           function error(msg) {
               Swal.fire({
                   position: 'center',
                   icon: 'success',
                   title:  msg,
                   showConfirmButton: false,
                   timer: 1200
               })

           }
           function save(msg) {
               Swal.fire(
                   msg+"!",
                   
                   
               )

           }
       </script>
       <div class="form-horizontal">
        <h4>Normal Accounts</h4>
        <hr />
<div class="container">
    <div style="margin-top : 5%;" id="editors">
        <div class="row">
        <div class="form-group col-md-5">
            <asp:Label ID="Label1" runat="server" Text="CARD NUMBER" class = "control-label col-md-5"></asp:Label>
          <div class="col-md-7">
              <asp:TextBox ID="TextBox1" runat="server" class = "form-control" ReadOnly="True" MaxLength="16" ></asp:TextBox>
       
          </div>
        </div>

        <div class="form-group col-md-7">
          
            <asp:Label ID="Label2" runat="server" Text="CARD SEQUENCE NUMBER" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:TextBox ID="TextBox2" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
          </div>
        </div>
          </div>  
        <div class="row">
        <div class="form-group col-md-5">
         
            <asp:Label ID="Label12" runat="server" Text="COMPANY CARD" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:CheckBox ID="CheckBox2" runat="server"/>
                </div>
        </div>
                <div class="form-group col-md-7">
           
            <asp:Label ID="Label16" runat="server" Text="COMPANY NAME" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox12" runat="server" class = "form-control" EnableTheming="True" ReadOnly="True"></asp:TextBox>
          
            </div>
        </div>
            </div>
         <div class="row">
        <div class="form-group col-md-5">
           
            <asp:Label ID="Label3" runat="server" Text="CARD STATUS" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox3" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
          
            </div>
        </div>
            
        <div class="form-group col-md-7">
           
            <asp:Label ID="Label13" runat="server" Text="CARD ISSUED :" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox9" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
          
            </div>
        </div>
             </div>

             <div class="row">

        <div class="form-group col-md-5">
           
            <asp:Label ID="Label14" runat="server" Text="BRANCH CODE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox10" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox10" Enabled="False" ForeColor="Red"></asp:RequiredFieldValidator>  
          <!--      <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer"  ForeColor="Red" ControlToValidate ="TextBox10" ErrorMessage="Enter Branch Code" />
          <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "TextBox10" ForeColor="Red" ID="RegularExpressionValidator1" ValidationExpression = "^[\s\S]{3,3}$" runat="server" ErrorMessage="Enter valid branch code"></asp:RegularExpressionValidator> -->
              
              </div>
        </div>
        <div class="form-group col-md-7">
           
            <asp:Label ID="Label15" runat="server" Text="CARD PROGRAM" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox11" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
          
            </div>
        </div>
    </div>
         <div class="row">
        <div class="form-group col-md-5">
         
            <asp:Label ID="Label4" runat="server" Text="HOLD RESPONSE CODE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:DropDownList ID="DropDownList1" runat="server" class = "form-control" Enabled="False" AutoPostBack="false">
                    <asp:ListItem>Account closed :45</asp:ListItem>
                    <asp:ListItem>None</asp:ListItem>
                    <asp:ListItem>Approved or completed successfully:00</asp:ListItem>
<asp:ListItem>Refer to card issuer:01</asp:ListItem>
<asp:ListItem>Refer to card issuer, special condition:02</asp:ListItem>
<asp:ListItem>Invalid merchant:03</asp:ListItem>
<asp:ListItem>Pick-up card:04</asp:ListItem>
<asp:ListItem>Do not honor:05</asp:ListItem>
<asp:ListItem>Error:06</asp:ListItem>
<asp:ListItem>Pick-up card, special condition:07</asp:ListItem>
<asp:ListItem>Honor with identification:08</asp:ListItem>
<asp:ListItem>Request in progress:09</asp:ListItem>
<asp:ListItem>Approved, partial:10</asp:ListItem>
<asp:ListItem>Approved, VIP:11</asp:ListItem>
<asp:ListItem>Invalid transaction:12</asp:ListItem>
<asp:ListItem>Invalid amount:13</asp:ListItem>
<asp:ListItem>Invalid card number:14</asp:ListItem>
<asp:ListItem>No such issuer:15</asp:ListItem>
<asp:ListItem>Approved, update track 3:16</asp:ListItem>
<asp:ListItem>Customer cancellation:17</asp:ListItem>
<asp:ListItem>Customer dispute:18</asp:ListItem>
<asp:ListItem>Re-enter transaction:19</asp:ListItem>
<asp:ListItem>Invalid response:20</asp:ListItem>
<asp:ListItem>No action taken:21</asp:ListItem>
<asp:ListItem>Suspected malfunction:22</asp:ListItem>
<asp:ListItem>Unacceptable transaction fee:23</asp:ListItem>
<asp:ListItem>File update not supported:24</asp:ListItem>
<asp:ListItem>Unable to locate record:25</asp:ListItem>
<asp:ListItem>Duplicate record:26</asp:ListItem>
<asp:ListItem>File update field edit error:27</asp:ListItem>
<asp:ListItem>File update file locked:28</asp:ListItem>
<asp:ListItem>File update failed:29</asp:ListItem>
<asp:ListItem>Format error:30</asp:ListItem>
<asp:ListItem>Bank not supported:31</asp:ListItem>
<asp:ListItem>Completed partially:32</asp:ListItem>
<asp:ListItem>Expired card, pick-up:33</asp:ListItem>
<asp:ListItem>Suspected fraud, pick-up:34</asp:ListItem>
<asp:ListItem>Contact acquirer, pick-up:35</asp:ListItem>
<asp:ListItem>Restricted card, pick-up:36</asp:ListItem>
<asp:ListItem>Call acquirer security, pick-up:37</asp:ListItem>
<asp:ListItem>PIN tries exceeded, pick-up:38</asp:ListItem>
<asp:ListItem>No credit account:39</asp:ListItem>
<asp:ListItem>Function not supported:40</asp:ListItem>
<asp:ListItem>Lost card, pick-up:41</asp:ListItem>
<asp:ListItem>No universal account:42</asp:ListItem>
<asp:ListItem>Stolen card, pick-up:43</asp:ListItem>
<asp:ListItem>No investment account:44</asp:ListItem>
<asp:ListItem>Identification required:46</asp:ListItem>
<asp:ListItem>Identification cross-check required:47</asp:ListItem>
<asp:ListItem>No customer record:48</asp:ListItem>
<asp:ListItem>Reserved for future Realtime use:49</asp:ListItem>
<asp:ListItem>Not sufficient funds:51</asp:ListItem>
<asp:ListItem>No check account:52</asp:ListItem>
<asp:ListItem>No savings account:53</asp:ListItem>
<asp:ListItem>Expired card:54</asp:ListItem>
<asp:ListItem>Incorrect PIN:55</asp:ListItem>
<asp:ListItem>No card record:56</asp:ListItem>
<asp:ListItem>Transaction not permitted to cardholder:57</asp:ListItem>
<asp:ListItem>Transaction not permitted on terminal:58</asp:ListItem>
<asp:ListItem>Suspected fraud:59</asp:ListItem>
<asp:ListItem>Contact acquirer:60</asp:ListItem>
<asp:ListItem>Exceeds withdrawal limit:61</asp:ListItem>
<asp:ListItem>Restricted card:62</asp:ListItem>
<asp:ListItem>Security violation:63</asp:ListItem>
<asp:ListItem>Original amount incorrect:64</asp:ListItem>
<asp:ListItem>Exceeds withdrawal frequency:65</asp:ListItem>
<asp:ListItem>Call acquirer security:66</asp:ListItem>
<asp:ListItem>Hard capture:67</asp:ListItem>
<asp:ListItem>Response received too late:68</asp:ListItem>
<asp:ListItem>Advice received too late:69</asp:ListItem>
<asp:ListItem>Reserved for future Realtime use:70</asp:ListItem>
<asp:ListItem>PIN tries exceeded:75</asp:ListItem>
<asp:ListItem>Reserved for future Realtime use:76</asp:ListItem>
<asp:ListItem>Intervene, bank approval required:77</asp:ListItem>
<asp:ListItem>Intervene, bank approval required for partial amount:78</asp:ListItem>
<asp:ListItem>Reserved for client-specific use (declined):79 to 89</asp:ListItem>
<asp:ListItem>Cut-off in progress:90</asp:ListItem>
<asp:ListItem>Issuer or switch inoperative:91</asp:ListItem>
<asp:ListItem>Routing error:92</asp:ListItem>
<asp:ListItem>Violation of law:93</asp:ListItem>
<asp:ListItem>Duplicate transaction:94</asp:ListItem>
<asp:ListItem>Reconcile error:95</asp:ListItem>
<asp:ListItem>System malfunction:96</asp:ListItem>
<asp:ListItem>Reserved for future Realtime use:97</asp:ListItem>
<asp:ListItem>Exceeds cash limit:98</asp:ListItem>
<asp:ListItem>Reserved for future Realtime use:99</asp:ListItem>
<asp:ListItem>ATC not incremented:A1</asp:ListItem>
<asp:ListItem>ATC limit exceeded:A2</asp:ListItem>
<asp:ListItem>ATC configuration error:A3</asp:ListItem>
<asp:ListItem>CVR check failure:A4</asp:ListItem>
<asp:ListItem>CVR configuration error:A5</asp:ListItem>
<asp:ListItem>TVR check failure:A6</asp:ListItem>
<asp:ListItem>TVR configuration error:A7</asp:ListItem>
<asp:ListItem>Unacceptable PIN:C Zero</asp:ListItem>
<asp:ListItem>PIN Change failed:C1</asp:ListItem>
<asp:ListItem>PIN Unblock failed:C2</asp:ListItem>
<asp:ListItem>MAC Error:D1</asp:ListItem>
<asp:ListItem>Prepay error:E1</asp:ListItem>
      </asp:DropDownList>
           
          </div>
        </div>
        <div class="form-group col-md-7">
       
            <asp:Label ID="Label5" runat="server" Text="CARD ACTIVATED" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:TextBox ID="TextBox4" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
           </div>
        </div>
             </div>

         <div class="row">
        <div class="form-group col-md-5">
         
            <asp:Label ID="Label6" runat="server" Text="LAST UPDATED USER" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:TextBox ID="TextBox5" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
         </div>
        </div>
   
        <div class="form-group col-md-7">
          
            <asp:Label ID="Label9" runat="server" Text="LAST UPDATED DATE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:TextBox ID="TextBox6" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
           </div>
        </div>
             </div>

       <div>
           <hr />
        </div>
        
         <h2> CUSTOMER </h2>
 
        <div>
             <asp:GridView ID="gvPhoneBook" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="1066px"  AutoGenerateColumns="false" DataKeyNames="customer_id" 
                 OnSelectedIndexChanged="gvPhoneBook_SelectedIndexChanged" OnRowDeleting="gvPhoneBook_RowDeleting" >
                
                <%-- Theme Properties --%>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />  
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
                
                <Columns>
                    <asp:TemplateField HeaderText="TYPE">
                        <ItemTemplate>
                            <asp:Label Text='primary' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txt_id" Text='primary' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtIDFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CUSTOMER ID">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("customer_id") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="customer_id" Text='<%# Eval("customer_id") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtMAKERFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NAME">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("c1_last_name") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtContact" Text='<%# Eval("c1_last_name") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtDATETIMEFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NAME ON CARD">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("c1_name_on_card") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtEmail" Text='<%# Eval("c1_name_on_card") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCHANGE_MADEFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="ADDRESS">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("postal_address_1") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtContact" Text='<%# Eval("postal_address_1") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtCARD_NUMBERFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                   
                   
                     <asp:TemplateField HeaderText="UNLINK">
                        <ItemTemplate>
                            <asp:Button ID="Button8" runat="server" Text="UNLINK CUSTOMER" CommandName="Delete" class="btn btn-danger" OnClick="Button8_Click"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtContact" Text='' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtREASONFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                  
                </Columns>
            </asp:GridView>
        </div>
       
        <div class="container">
            <div class="">
                <div class="row">
                    <div class="col-md-10">
                           <asp:Button ID="Button7" runat="server" Text="PLACE / REMOVE HOLD" class="btn btn-danger" OnClick="Button7_Click1" />
                          <asp:Button ID="Button1" runat="server" Text="EDIT" class="btn btn-info" OnClick="Button1_Click"  />
                          <asp:Button ID="Button2" runat="server" Text="ACTIVATE / DEACTIVATE" class="btn btn-primary" OnClick="Button2_Click"/>
                         <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="Button" Visible="False" />
                    </div>
                </div>
                <div> <hr /></div>
                <div class="row">
                    <div class="col-md-10">
                        <asp:Button ID="Button9" runat="server" Text="ADD EXISTING CUSTOMER" class="btn btn-success" OnClick="Button9_Click1" />
                 <asp:Button ID="Button10" runat="server" Text="ADD NEW CUSTOMER" class="btn btn-success" OnClick="Button10_Click"/>
               
               <asp:Button ID="Button4" runat="server" Text="SAVE" class="btn btn-success" OnClick="Button4_Click"/>
                      <div class="btn btn-danger" ><a href='Search_Account_Pan.aspx' style="color: #FFFFFF"> BACK</a></div>  
           
                        </div>
                </div>

                <asp:TextBox ID="customer_id_text" runat="server" Visible="False"></asp:TextBox> 
                 
             
            </div>
        </div>
    </div>
    </div>
           </div>

</asp:Content>
