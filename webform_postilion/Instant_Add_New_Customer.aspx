<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Instant_Add_New_Customer.aspx.cs" Inherits="webform_postilion.Instant_Add_New_Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <script>
          function place(msg) {
              Swal.fire({
                  position: 'center',
                  icon: 'success',
                  title: 'Please ' + msg,
                  showConfirmButton: false,
                  timer: 1200
              })

          }
          function alertme(msg) {
              swal({
                  title: "ALERT",
                  //  text: "WRONG USERNAME OR PASSWORD",
                  text: msg,
                  icon: "success",
                  button: "OK"

              });
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
          function placed(msg) {
              Swal.fire({
                  position: 'center',
                  icon: 'success',
                  title: 'Please' + msg,
                  showConfirmButton: false,
                  timer: 1200
              })

          }
       </script>
     <div class="form-horizontal">
        <h4>ADD NEW CUSTOMER</h4>
        <hr />
<div class="container">
    <div style="margin-top : 2%;" id="editors">
          <div class="row">
        <div class="form-group col-md-5">
            <asp:Label ID="Label1" runat="server" Text="CUSTOMER ID" class = "control-label col-md-5"></asp:Label>
          <div class="col-md-7">
              <asp:TextBox ID="customer_d" runat="server" class = "form-control"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="RequiredField" ControlToValidate="customer_d" ForeColor="Red"></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="customer_d" ErrorMessage="Error Correct Customer ID" ValidationExpression = "^[\s\S]{16,16}$" ForeColor="Red" ></asp:RegularExpressionValidator>
            </div>
        </div>
     </div>  

        <div>

            <hr />

        </div>

        <h3> CUSTOMER DETAILS</h3>
        <div class="row">
        <div class="form-group col-md-5">
            <asp:Label ID="Label2" runat="server" Text="LINK ACCOUNTS TO CUSTOMER" class = "control-label col-md-5"></asp:Label>
          <div class="col-md-7">
              <asp:CheckBox ID="CheckBox1" runat="server" />
              </div>
        </div>

     
          </div>  
           <div>

            <hr />

        </div>
      <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label7" runat="server" Text="TITLE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:DropDownList ID="title" runat="server" class = "form-control" Enabled="TRUE" AutoPostBack="false">
                    <asp:ListItem>Mr</asp:ListItem>
                    <asp:ListItem>Mrs</asp:ListItem>
                    <asp:ListItem>Miss</asp:ListItem>
                     <asp:ListItem>Dr</asp:ListItem>
                    <asp:ListItem>Hon</asp:ListItem>
                    <asp:ListItem>Prof</asp:ListItem>

      </asp:DropDownList>
            </div>
        </div>
                <div class="form-group col-md-7">
           
            <asp:Label ID="Label16" runat="server" Text="DATE OF BIRTH" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
              <div class="col-md-7">
                     <asp:TextBox ID="datepicker34" runat="server" class = "form-control" ReadOnly="False" autocomplete="off" ClientIdMode="Static"></asp:TextBox>
          
           </div></div>
        </div>
            </div> 
          <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label9" runat="server" Text="FIRST NAME" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="first_name" runat="server" class = "form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="RequiredField" ControlToValidate="first_name" ForeColor="Red"></asp:RequiredFieldValidator>
          
            </div>
        </div>
                <div class="form-group col-md-7">
           
            <asp:Label ID="Label24" runat="server" Text="MIDDLE INITIALS" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="middle_initials" runat="server" class = "form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="RequiredField" ControlToValidate="middle_initials" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
            </div> 
          <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label27" runat="server" Text="PREFERRED LANGUAGE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                     <asp:DropDownList ID="language" runat="server" class = "form-control" Enabled="TRUE" AutoPostBack="false">
                    <asp:ListItem Value="ENG">ENGLISH</asp:ListItem>
                    <asp:ListItem Value="shona">SHONA</asp:ListItem>
                    <asp:ListItem Value="NDEBE">NDEBELE</asp:ListItem>


      </asp:DropDownList>
            </div>
        </div>
                <div class="form-group col-md-7">
           
            <asp:Label ID="Label28" runat="server" Text="NATIONAL ID" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="national_id" runat="server" class = "form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="RequiredField" ControlToValidate="national_id" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label3" runat="server" Text="NAME ON CARD" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="name_on_card" runat="server" class = "form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredField" ControlToValidate="name_on_card" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
                <div class="form-group col-md-7">
           
            <asp:Label ID="Label4" runat="server" Text="LAST NAME" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="last_name" runat="server" class = "form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredField" ControlToValidate="last_name" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label5" runat="server" Text="FAX NUMBER" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="fax_number" runat="server" class = "form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredField" ControlToValidate="fax_number" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>   <div class="form-group col-md-7">
           
            <asp:Label ID="Label25" runat="server" Text="TELEPHONE NUMBER" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="tel" runat="server" class = "form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredField" ControlToValidate="tel" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
              
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label8" runat="server" Text="EMAIL ADDRESS" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="email" runat="server" class = "form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredField" ControlToValidate="email" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
               <div class="form-group col-md-7">
           
            <asp:Label ID="Label6" runat="server" Text="MOBILE / CALL NUMBER" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="mobile" runat="server" class = "form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredField" ControlToValidate="mobile" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
              
            </div> 
         <div class="row">
         <div class="form-group col-md-6">
           
         <strong>  <asp:Label ID="Label26" runat="server" Text="PRIMARY / BILLING ADDRESS" class = "control-label col-md-8"></asp:Label>  </strong>
            <div class="col-md-7">
               
            </div>
        </div>
              <div class="form-group col-md-6">
           
         <strong> <asp:Label ID="Label10" runat="server" Text="ALTERNATE ADDRESS" class = "control-label col-md-8"></asp:Label>  </strong>
            <div class="col-md-7">
              
            </div>
        </div>
              
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label12" runat="server" Text="ADDRESS LINE 1" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="address_1_1" runat="server" class = "form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredField" ControlToValidate="address_1_1" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
               <div class="form-group col-md-7">
           
            <asp:Label ID="Label11" runat="server" Text="ADDRESS LINE 1" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="address_1_2" runat="server" class = "form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="RequiredField" ControlToValidate="address_1_2" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
               
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label14" runat="server" Text="ADDRESS LINE 2" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="address_2_1" runat="server" class = "form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="RequiredField" ControlToValidate="address_2_1" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
              <div class="form-group col-md-7">
           
            <asp:Label ID="Label13" runat="server" Text="ADDRESS LINE 2" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="address_2_2" runat="server" class = "form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="RequiredField" ControlToValidate="address_2_2" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
               
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label17" runat="server" Text="CITY" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="city_1" runat="server" class = "form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="RequiredField" ControlToValidate="city_1" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
              <div class="form-group col-md-7">
           
            <asp:Label ID="Label15" runat="server" Text="CITY" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="city_2" runat="server" class = "form-control"></asp:TextBox>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="RequiredField" ControlToValidate="city_2" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
               
            </div> 
   
 </div>

       <div>
           <hr />
        </div>

  
       
        <div class="container">
            <div class="">
           
               <asp:Button ID="Button4" runat="server" Text="OK" class="btn btn-success" OnClick="Button4_Click"/>
             
               <div class="btn btn-danger" ><a href='Instant_Card_Result.aspx' style="color: #FFFFFF"> BACK</a></div>  
            </div>
        </div>
    </div>
    </div>
     <script src="pikaday.js"></script>
    <script>



        var picker = new Pikaday(
            {
                field: document.getElementById('datepicker34'),
                format: 'YYYY-MM-DD'

            });

    </script>
</asp:Content>
