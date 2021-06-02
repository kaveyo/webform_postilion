<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account_Card_Result.aspx.cs" Inherits="webform_postilion.Account_Card_Result" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <script>
        /*function alertme( msg) {
            Swal.fire({
                title: 'Are you sure?',<a href="Account_Card_Result.aspx">Account_Card_Result.aspx</a>
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

           function deleted(id) {

               Swal.fire({
                   title: 'Message!',
                   text: "DATA NOT FOUND!",
                   icon: 'warning',
                   showCancelButton: false,
                   confirmButtonColor: '#3085d6',
                   cancelButtonColor: '#d33',
                   confirmButtonText: 'OK'
               }).then((result) => {
                   if (result.value) {
                       $.ajax({
                           type: "POST",
                           url: "Account_Card_Result.aspx/DeleteClick",
                           data: "{id:" + id + "}",
                           contentType: "application/json; charset=utf-8",
                           dataType: "json",
                           success: function (r) {
                                                              
                               window.location.assign("/Search_Account_Pan.aspx");
                           }
                       });
                   }
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
          
               function alertMessage() {
                   alert('ALERT!');
                }
           function notfound(id) {

               Swal.fire({
                   title: 'DATA NOT FOUND',
                   text: "CHECK IF INSERT INFO IN CORRECT",
                   icon: 'warning',
                   showCancelButton: true,
                   confirmButtonColor: '#3085d6',
                   cancelButtonColor: '#d33',
                   confirmButtonText: 'Yes, delete it!'
               }).then((result) => {
                   if (result.value) {
                       $.ajax({
                           type: "POST",
                           url: "Login.aspx",
                           data: "{id:" + id + "}",
                           contentType: "application/json; charset=utf-8",
                           dataType: "json",
                           success: function (r) {
                               Swal("Data Transfered SuccessFully", r.d, "success");
                           }
                       });
                   }
               })
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
         
            <asp:Label ID="Label12" runat="server" Text="COMPANY CARD" class = "control-label col-md-5" Enabled="False" Visible="False"></asp:Label>
            <div class="col-md-7">
                <asp:CheckBox ID="CheckBox2" runat="server" Enabled="False" Visible="False"/>
                </div>
        </div>
                <div class="form-group col-md-7">
           
            <asp:Label ID="Label16" runat="server" Text="COMPANY NAME" class = "control-label col-md-5" Visible="False"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox12" runat="server" class = "form-control" EnableTheming="True" ReadOnly="True" Enabled="False" Visible="False"></asp:TextBox>
          
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
                 <asp:TextBox ID="TextBox10" runat="server" class = "form-control" ReadOnly="True" Visible="False"></asp:TextBox>
                <asp:DropDownList ID="DropDownList2" runat="server" class = "form-control" Enabled="False">
                      </asp:DropDownList>
               <!-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox10" Enabled="False" ForeColor="Red"></asp:RequiredFieldValidator>  
              <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer"  ForeColor="Red" ControlToValidate ="TextBox10" ErrorMessage="Enter Branch Code" />
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
<asp:ListItem>Expired card, pick-up:33</asp:ListItem>
<asp:ListItem>Lost card, pick-up:41</asp:ListItem>
<asp:ListItem>No universal account:42</asp:ListItem>
<asp:ListItem>Stolen card, pick-up:43</asp:ListItem>
<asp:ListItem>Expired card:54</asp:ListItem>


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
                 OnRowDeleting="gvPhoneBook_RowDeleting" OnRowCommand="gvPhoneBook_RowCommand" >
                
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
                            <asp:Button ID="Button_unlink" runat="server" Text="UNLINK CUSTOMER" CommandName="Delete" class="btn btn-danger"   />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtContact" Text='' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtREASONFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                            <asp:TemplateField HeaderText="EDIT CUSTOMER DETAILS">
                        <ItemTemplate>
                            <asp:Button ID="Button_edit" runat="server" Text="EDIT DETAILS"  CommandName="CUST_id" CommandArgument='<%# Eval("customer_id") %>' class="btn btn-danger" />
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
        <div>
           <hr />
        </div>
        
         <h2> LINKED ACCOUNTS </h2>
 
        <div>
             <asp:GridView ID="gvPhoneBook2" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="1066px"  AutoGenerateColumns="false" DataKeyNames="account_id" 
                  OnRowDeleting="gvPhoneBook_RowDeleting2" OnRowCommand="gvPhoneBook_RowCommand">
                
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
                    <asp:TemplateField HeaderText="ACCOUNT NUMBER">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("account_id") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="account_id" Text='<%# Eval("account_id") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtaccount_idFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ACCOUNT TYPE">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("account_type") %>' ToolTip="10: Savings   , 20: Check/Cheque , 21: FBC STAFF  " runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="account_type" Text='<%# Eval("account_type") %>'  runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtaccount_typeFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="LAST UPDATED USER">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("last_updated_user") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="account_product" Text='<%# Eval("last_updated_user") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtlast_updated_userFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                                                                       
                     <asp:TemplateField HeaderText="UNLINK">
                        <ItemTemplate>
                            <%--<asp:Button ID="Button8" runat="server" Text="UNLINK ACCOUNT" CommandName="Delete" class="btn btn-danger" />--%>
                             <asp:Button ID="Button_acc" runat="server" Text="UNLINK ACCOUNT" CommandName="reason" class="btn btn-danger" />
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
             <!-- Modal reason -->
 <div id="myModal" class="modal fade" role="dialog">
    <div class="modal-dialog">

        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">               

                <h4 class="modal-title">ENTER REASON</h4>
            </div>
            <div class="modal-body">

                  <asp:TextBox ID="reason_textbox" runat="server" class="form-control p-0 border-0" placeholder ="Phone Number" TextMode="Phone" ></asp:TextBox>
		              
            </div>
            <div class="modal-footer">
                <asp:Button ID="Button6" runat="server" Text="SAVE" class="btn btn-default"  OnClick="Button2_Click" />
            </div>
        </div>
    </div>
</div> <!--End Modal reason --> 

        <div class="container">
            <div class="">
                <div class="row">
                    <div class="col-md-10">
                           <asp:Button ID="Button7" runat="server" Text="PLACE / REMOVE HOLD" class="btn btn-danger" data-toggle="modal" data-target="#myModal" OnClientClick="return false;" OnClick="Button7_Click1" Visible="False" />
                          <asp:Button ID="Button1" runat="server" Text="EDIT" class="btn btn-info" OnClick="Button1_Click"  />
                          <asp:Button ID="Button2" runat="server" Text="ACTIVATE / DEACTIVATE" class="btn btn-primary" OnClick="Button2_Click"/>
                         <asp:Button ID="Button3" runat="server" Text="LINK ACCOUNT" class="btn btn-info" OnClick="Button3_Click"  /> 
                         <asp:Button ID="Button11" runat="server" Text="OVERRIDE LIMITS" class="btn btn-danger" OnClick="Button11_Click1"  />
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
