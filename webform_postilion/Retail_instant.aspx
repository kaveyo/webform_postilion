<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Retail_instant.aspx.cs" Inherits="webform_postilion.Retail_instant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <script>
        function alertme( msg) {
            swal({
                title: "ALERT",
                //  text: "WRONG USERNAME OR PASSWORD",
                text: msg,
                icon: "success",
                button: "OK"

            });
        }
    </script>
     <div class="form-horizontal">
        <h4>RETAIL INSTANT CUSTOMER</h4>
        <hr />


      <%--  <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="CUSTOMER ID" class = "control-label col-md-2"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBox1" runat="server" class = "form-control"></asp:TextBox>
   </div>
        </div>--%>

        <div class="form-group">
            
            <asp:Label ID="Label2" runat="server" Text="ACCOUNT NUMBER / CARD NUMBER" class = "control-label col-md-2"></asp:Label>
            <div class="col-md-10">
                
                <asp:TextBox ID="TextBox2" runat="server" class = "form-control"></asp:TextBox>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox2" ErrorMessage="Enter Correct card/account number" ValidationExpression = "^[\s\S]{16,16}$" ForeColor="Red" ></asp:RegularExpressionValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBox2" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
           </div>
        </div>

     <%--   <div class="form-group">
            
            <asp:Label ID="Label3" runat="server" Text="CARD NUMBER" class = "control-label col-md-2"></asp:Label>
            <div class="col-md-10">
              
                <asp:TextBox ID="TextBox3" runat="server" class = "form-control"></asp:TextBox>
            </div>
        </div>--%>




        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="Button1" runat="server" Text="SEARCH" class="btn btn-default" OnClick="Button1_Click" />
            </div>
        </div>
    </div>
      <div>
           <hr />
        </div>

        <h2> CUSTOMER </h2>
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
                    <asp:TemplateField HeaderText="TELEPHONE NUMBER">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("tel_nr") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtTEL" Text='<%# Eval("tel_nr") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtTELFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="PHONE NUMBER">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("mobile_nr") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtMOB" Text='<%# Eval("mobile_nr") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="txtMOBFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                                   
                </Columns>
            </asp:GridView>
</asp:Content>
