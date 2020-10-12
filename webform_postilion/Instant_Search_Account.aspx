<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Instant_Search_Account.aspx.cs" Inherits="webform_postilion.Instant_Search_Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function alertme(msg) {
            Swal.fire(
                'WARNING!',
                msg+"!",
                'success'
            )
        }
    </script>
    <div class="form-horizontal">
        <h4>INSTANT SEARCH CARD NUMBER OR ACCOUNT NUMBER</h4>
        <hr />

        <div class="form-group">
            
            <asp:Label ID="Label2" runat="server" Text="ACCOUNT NUMBER" class = "control-label col-md-2"></asp:Label>
            <div class="col-md-10">
                
                <asp:TextBox ID="TextBox2" runat="server" class = "form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="ENTER VALID ACCOUNT NUMBER" ValidationExpression = "^[\s\S]{16,16}$" ForeColor="Red" ControlToValidate="TextBox2"></asp:RegularExpressionValidator>
          <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
               
                </div>
        </div>

        <div class="form-group">
            
            <asp:Label ID="Label3" runat="server" Text="CARD NUMBER" class = "control-label col-md-2"></asp:Label>
            <div class="col-md-10">
              
                <asp:TextBox ID="TextBox3" runat="server" class = "form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="ENTER VALID CARD NUMBER" ValidationExpression = "^[\s\S]{16,16}$" ForeColor="Red" ControlToValidate="TextBox3"></asp:RegularExpressionValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBox3" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
            </div>
        </div>
                     
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="Button1" runat="server" Text="SEARCH" class="btn btn-default" OnClick="Button1_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
