<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Add_User.aspx.cs" Inherits="webform_postilion.Add_User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/sweetalert2.all.min.js"></script>
    <script src="Scripts/sweetalert2.min.js"></script>
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
        <h4>ADD NEW USER</h4>
        <hr />

<div class="container">
    <div style="margin-top : 2%;" id="editors">
        <div class="row">
        <div class="form-group col-md-5">
            <asp:Label ID="Label1" runat="server" Text="USERNAME" class = "control-label col-md-5"></asp:Label>
          <div class="col-md-7">
              <asp:TextBox ID="username" runat="server" class = "form-control"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="RequiredField" ControlToValidate="username" ForeColor="Red"></asp:RequiredFieldValidator>
           </div>
        </div>

     
          </div>  
       <%--<div class="row">
        <div class="form-group col-md-5">
            <asp:Label ID="Label2" runat="server" Text="FIRST NAME" class = "control-label col-md-5"></asp:Label>
          <div class="col-md-7">
              <asp:TextBox ID="first" runat="server" class = "form-control"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredField" ControlToValidate="first" ForeColor="Red"></asp:RequiredFieldValidator>
          </div>
        </div>

     
          </div>  
         <div class="row">
        <div class="form-group col-md-5">
            <asp:Label ID="Label16" runat="server" Text="SURNAME" class = "control-label col-md-5"></asp:Label>
          <div class="col-md-7">
              <asp:TextBox ID="surname" runat="server" class = "form-control"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredField" ControlToValidate="surname" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>

     
          </div>  --%>
      <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label7" runat="server" Text="ROLE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:DropDownList ID="role" runat="server" class = "form-control" Enabled="TRUE" AutoPostBack="false">
                    <asp:ListItem>MAKER</asp:ListItem>
                    <asp:ListItem>CHECKER</asp:ListItem>
                    <asp:ListItem>Administrator</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
             
            </div> 
       <%--   <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label9" runat="server" Text="ENTER PASSWORD" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="password1" runat="server" TextMode="Password" class = "form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="RequiredField" ControlToValidate="password1" ForeColor="Red"></asp:RequiredFieldValidator>
          
            </div>
        </div>
             
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label18" runat="server" Text="REENTER PASSWORD" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="password2" runat="server" TextMode="Password" class = "form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="RequiredField" ControlToValidate="password2" ForeColor="Red"></asp:RequiredFieldValidator>
          
            </div>
        </div>
             
            </div> --%>
          <div class="row">
               <div class="form-group col-md-5">
           
            <asp:Label ID="Label13" runat="server" Text="BRANCH" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:DropDownList ID="DropDownList2" runat="server" class = "form-control">
                    
                 
                     </asp:DropDownList>
            </div>
        </div> 

          </div>
                
   
 </div>

       <div>
           <hr />
        </div>

  
       
        <div class="container">
            <div class="">
           
               <asp:Button ID="Button4" runat="server" Text="SAVE" class="btn btn-success" OnClick="Button4_Click"/>
           
            </div>
        </div>
    </div>
   
</div>
</asp:Content>
