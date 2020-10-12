<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search_Account_Pan.aspx.cs" Inherits="webform_postilion.Search_Account_Pan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script>
         function place(msg) {
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
                 title: 'Error : ' + msg,
                 showConfirmButton: false,
                 timer: 1200
             })

         }
         function save(msg) {
             Swal.fire({
                 position: 'center',
                 icon: 'success',
                 title: 'Message ' + msg,
                 showConfirmButton: false,
                 timer: 1200
             })

         }
         function Delete(msg) {
             Swal.fire({
                 position: 'center',
                 icon: 'success',
                 title: 'You Have Successfully ' + msg,
                 showConfirmButton: false,
                 timer: 1200
             })
         }

         $(document).ready(function () {
             $('#CheckBox1').click(function () {

                 $.ajax({
                     url: 'Account_Results/checked_',
                     method: 'post'
                 });
             });
         });
         </script>
     
 <div class="form-horizontal">
        <h4>CUSTOMER ACCOUNT NUMBER OR CUSTOMER ID</h4>
        <hr />


        <div class="form-group">
            <asp:Label ID="Label1" runat="server" Text="CUSTOMER ID" class = "control-label col-md-2"></asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBox1" runat="server" class = "form-control"></asp:TextBox>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox1" ErrorMessage="Enter Correct Customer ID" ValidationExpression = "^[\s\S]{7,7}$" ForeColor="Red" ></asp:RegularExpressionValidator>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
   </div>
        </div>

        <div class="form-group">
            
            <asp:Label ID="Label2" runat="server" Text="ACCOUNT NUMBER" class = "control-label col-md-2"></asp:Label>
            <div class="col-md-10">
                
                <asp:TextBox ID="TextBox2" runat="server" class = "form-control"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Enter Correct Account number With Branch Code " ValidationExpression = "^[\s\S]{16,16}$" ForeColor="Red" ></asp:RegularExpressionValidator>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBox2" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
           </div>
        </div>

        <div class="form-group">
            
            <asp:Label ID="Label3" runat="server" Text="CARD NUMBER" class = "control-label col-md-2"></asp:Label>
            <div class="col-md-10">
              
                <asp:TextBox ID="TextBox3" runat="server" class = "form-control"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox3" ErrorMessage="Enter Correct card number" ValidationExpression = "^[\s\S]{16,16}$" ForeColor="Red" ></asp:RegularExpressionValidator>
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
