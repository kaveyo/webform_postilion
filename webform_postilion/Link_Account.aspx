<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Link_Account.aspx.cs" Inherits="webform_postilion.Link_Account" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h4> LINK ACCOUNT</h4>
        <hr />
<div class="container">
    <div style="margin-top : 2%;" id="editors">
       <div class="row">
        <div class="form-group col-md-5">
            <asp:Label ID="Label1" runat="server" Text="ACCOUNT NUMBER" class = "control-label col-md-5"></asp:Label>
          <div class="col-md-7">
              <asp:TextBox ID="TextBox1" runat="server" class = "form-control" ></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox1" ForeColor="Red" Enabled ="True"></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Error Correct Customer ID" ValidationExpression = "^[\s\S]{16,16}$" ForeColor="Red" Enable="True"></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="form-group col-md-7">
          
           <div class="col-md-7">
         <asp:Button ID="Button1" runat="server" Text="LINK" class="btn btn-success" OnClick="Button1_Click" />
             
           </div>
        </div>
          </div>  

        <div>

            <hr />

        </div>

      <%--  <h3> CREATE NEW ACCOUNT</h3>
        <div class="row">
         
          </div>  
           <div>

            <hr />

        </div>
      <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label7" runat="server" Text="ACCOUNT NUMBER" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox7" runat="server" class = "form-control"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox7" ForeColor="Red" Enabled ="false"></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator2"  runat="server" ControlToValidate="TextBox7" ErrorMessage="Error Correct ACCOUNT NUMBER" ValidationExpression = "^[\s\S]{16,16}$" ForeColor="Red" Enable =" false"></asp:RegularExpressionValidator>
           
             </div>
        </div>
                <div class="form-group col-md-7">
           
            <asp:Label ID="Label16" runat="server" Text="ACCOUNT TYPE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                   <asp:DropDownList ID="account_type" runat="server" class = "form-control" Enabled="true" >
                    <asp:ListItem>Savings :10</asp:ListItem>
                    <asp:ListItem>Home Ownership :11</asp:ListItem>
                        <asp:ListItem>Check/Cheque :20</asp:ListItem>
                        <asp:ListItem>FBC staff :21</asp:ListItem>
                    <asp:ListItem>Credit :30</asp:ListItem>
                       <asp:ListItem>Universal :40</asp:ListItem>
                        <asp:ListItem>Remittance Account :47</asp:ListItem>
                    <asp:ListItem>FCA :70</asp:ListItem>
                   </asp:DropDownList>
           </div>
        </div>
            </div> --%>
        <%-- <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label3" runat="server" Text="ACCOUNT PRODUCT" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                                   <asp:DropDownList ID="account_product" runat="server" class = "form-control" Enabled="true" >
                    <asp:ListItem>None</asp:ListItem>
                    <asp:ListItem>LOCAL</asp:ListItem>

                   </asp:DropDownList>
            </div>
        </div>
                <div class="form-group col-md-7">
           
            <asp:Label ID="Label4" runat="server" Text="CURRENCY" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                     <asp:DropDownList ID="currency" runat="server" class = "form-control" Enabled="true" >
                    <asp:ListItem>ZWL</asp:ListItem>
                    <asp:ListItem>USD</asp:ListItem>

                   </asp:DropDownList>
            </div>
        </div>
            </div> --%>

   
 </div>

       <div>
           <hr />
        </div>

  
       
        <div class="container">
            <div class="">
           
              <%-- <asp:Button ID="Button4" runat="server" Text="ADD" class="btn btn-success" OnClick="Button4_Click"/>--%>
             
               <div class="btn btn-danger" ><a href='Search_Account_Pan.aspx' style="color: #FFFFFF"> BACK</a></div>  
            </div>
        </div>
    </div>
    </div>
</asp:Content>
