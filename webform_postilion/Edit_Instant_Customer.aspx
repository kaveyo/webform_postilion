<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit_Instant_Customer.aspx.cs" Inherits="webform_postilion.Edit_Instant_Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="form-horizontal">
        <h4>Customer Details</h4>
        <hr />
      

    <div style="margin-top : 5%;" id="editors">
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="PHONE NUMBER" class = "control-label col-md-2"></asp:Label>
          <div class="col-md-10">
             
               <asp:TextBox ID="mobile" runat="server" class = "form-control"></asp:TextBox>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="mobile" ErrorMessage="USE FORMAT 263XXXXXXXXX" ForeColor="Red" ValidationExpression="([0-9]{3}|[0-9]{3}\(0\)|\(\[0-9]{2}\)\(0\)|00[0-9]{2}|0)([0-9]{9})"></asp:RegularExpressionValidator>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredField" ControlToValidate="mobile" ForeColor="Red"></asp:RequiredFieldValidator>
           
            </div>
        </div>

        <div class="form-group">
          
            <asp:Label ID="Label2" runat="server" Text="ID NUMBER" class = "control-label col-md-2"></asp:Label>
            <div class="col-md-10">
              
                     <asp:TextBox ID="national_id" runat="server" class = "form-control"></asp:TextBox>
               
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="national_id" ErrorMessage="USE FORMAT 123456789z12" ForeColor="Red" ValidationExpression="(^\d{2})(\d{4,7})([A-Z-a-z]{1}(\d{2}$))"></asp:RegularExpressionValidator>
            
          <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="RequiredField" ControlToValidate="national_id" ForeColor="Red"></asp:RequiredFieldValidator>
           
          </div>
        </div>

        <div class="form-group">
           
            <asp:Label ID="Label3" runat="server" Text="NAME" class = "control-label col-md-2"></asp:Label>
            <div class="col-md-10">
                 <asp:TextBox ID="name" runat="server" class = "form-control" ></asp:TextBox>
          
            </div>
        </div>
        <div class="form-group">
           
            <asp:Label ID="Label5" runat="server" Text="SURNAME" class = "control-label col-md-2"></asp:Label>
            <div class="col-md-10">
                 <asp:TextBox ID="surname" runat="server" class = "form-control" ></asp:TextBox>
          
            </div>
        </div>
        <div class="form-group">
           
            <asp:Label ID="Label4" runat="server" Text="ADDRESS" class = "control-label col-md-2"></asp:Label>
            <div class="col-md-10">
                 <asp:TextBox ID="address" runat="server" class = "form-control" ></asp:TextBox>
          
            </div>
        </div>
        </div>

         <div>
           <hr />
        </div>

         
        <div class="container">
            <div class="">
           
               <asp:Button ID="Button4" runat="server" Text="SAVE" class="btn btn-success" OnClick="Button4_Click" />
               <div class="btn btn-danger" ><a href='Instant_Search_Account.aspx' style="color: #FFFFFF"> BACK</a></div>  
           
            </div>
        </div>
     </div>
</asp:Content>
