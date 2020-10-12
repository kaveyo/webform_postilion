<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Update_User.aspx.cs" Inherits="webform_postilion.Update_User" %>
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
        <h4>UPDATE USER</h4>
        <hr />

<div class="container">
    <div style="margin-top : 2%;" id="editors">
       
       <%--<div class="row">
        <div class="form-group col-md-5">
            <asp:Label ID="Label2" runat="server" Text="FIRST NAME" class = "control-label col-md-5"></asp:Label>
          <div class="col-md-7">
              <asp:TextBox ID="first" runat="server" class = "form-control"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredField" ControlToValidate="first" ForeColor="Red"></asp:RequiredFieldValidator>
          </div>
        </div>

     
          </div>  --%>
        <%-- <div class="row">
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
                <asp:DropDownList ID="role" runat="server" class = "form-control" Enabled="False" AutoPostBack="false">
                    <asp:ListItem>MAKER</asp:ListItem>
                    <asp:ListItem>CHECKER</asp:ListItem>
                    
           </asp:DropDownList>
                        <asp:CheckBox ID="CheckBox2" Text="Update Role" runat="server" OnCheckedChanged="CheckBox2_CheckedChanged" AutoPostBack="true"/>
         
            </div>
        </div>
             
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label1" runat="server" Text="CHANGE USER PASSWORD" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                    <asp:CheckBox ID="password_checker" Text="Update Password" runat="server" OnCheckedChanged="CheckBox3_CheckedChanged" AutoPostBack="true"/>
                           
            </div>
        </div>
             
            </div> 
          <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label9" runat="server" Text="ENTER PASSWORD" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="password1" runat="server" TextMode="Password" class = "form-control" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredField" ControlToValidate="password1" ForeColor="Red" Enabled="False"></asp:RequiredFieldValidator>
          
            </div>
        </div>
             
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label18" runat="server" Text="REENTER PASSWORD" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="password2" runat="server" TextMode="Password" class = "form-control" Enabled="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredField" ControlToValidate="password2" ForeColor="Red" Enabled="False"></asp:RequiredFieldValidator>
          
            </div>
        </div>
             
            </div> 
          <div class="row">
               <div class="form-group col-md-5">
           
            <asp:Label ID="Label13" runat="server" Text="BRANCH" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:DropDownList ID="DropDownList2" runat="server" class = "form-control" Enabled="False">
                    
                     </asp:DropDownList>

                <asp:CheckBox ID="CheckBox1" Text="Update Branch" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="true"/>
            </div>
        </div> 

          </div>
                
   
 </div>

       <div>
           <hr />
        </div>

  
       
        <div class="container">
            <div class="">
           
               <asp:Button ID="Button4" runat="server" Text="UPDATE" class="btn btn-success" OnClick="Button4_Click" />
              <div></div> <asp:Button ID="Button1" runat="server" Text="BACK" class="btn btn-success" OnClick="Back_Click" />
            </div>
        </div>
    </div>
   
      </div>
</asp:Content>
