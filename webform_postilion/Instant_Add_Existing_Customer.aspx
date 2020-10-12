<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Instant_Add_Existing_Customer.aspx.cs" Inherits="webform_postilion.Instant_Add_Existing_Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script>

        $(function () {
            $("#Button5").click(function () {
                ValidatorEnable(document.getElementById("RequiredFieldValidator1"), false);
                ValidatorEnable(document.getElementById("RequiredFieldValidator2"), false);
                ValidatorEnable(document.getElementById("RequiredFieldValidator3"), false);
                ValidatorEnable(document.getElementById("RequiredFieldValidator4"), false);
                ValidatorEnable(document.getElementById("RequiredFieldValidator5"), false);
                ValidatorEnable(document.getElementById("RequiredFieldValidator6"), false);
                ValidatorEnable(document.getElementById("RequiredFieldValidator7"), false);
                ValidatorEnable(document.getElementById("RequiredFieldValidator8"), false);
            });
        });
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
        function place(msg) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Please' + msg,
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
         function error(msg) {
             Swal.fire({
                 position: 'center',
                 icon: 'success',
                 title: 'ERROR :' + msg,
                 showConfirmButton: false,
                 timer: 1200
             })

         }
        </script>  
    <div class="form-horizontal">
        <h4>ADD EXISTING CUSTOMER</h4>
        <hr />
<div class="container">
    <div style="margin-top : 2%;" id="editors">
       <div class="row">
        <div class="form-group col-md-5">
            <asp:Label ID="Label1" runat="server" Text="CUSTOMER ID" class = "control-label col-md-5"></asp:Label>
          <div class="col-md-7">
              <asp:TextBox ID="TextBox1" runat="server" class = "form-control"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Error Correct Customer ID" ValidationExpression = "^[\s\S]{7,7}$" ForeColor="Red" ></asp:RegularExpressionValidator>
            </div>
        </div>

        <div class="form-group col-md-7">
          
           <div class="col-md-7">
         <asp:Button ID="Button1" runat="server" Text="PULL INFO" class="btn btn-success" OnClick="Button1_Click"/>
             
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
           
            <asp:Label ID="Label7" runat="server" Text="FIRST NAME" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox7" runat="server" class = "form-control"></asp:TextBox>
            
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredField" ForeColor="Red" ControlToValidate="TextBox7" Enabled="False"></asp:RequiredFieldValidator> </div>
        </div>
                <div class="form-group col-md-7">
           
            <asp:Label ID="Label16" runat="server" Text="DATE OF BIRTH" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                     <asp:TextBox ID="datepicker34" runat="server" class = "form-control" ReadOnly="False" autocomplete="off" ClientIdMode="Static"></asp:TextBox>
          
           </div>
        </div>
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label3" runat="server" Text="NAME ON CARD" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox2" runat="server" class = "form-control"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredField" ForeColor="Red"  ControlToValidate="TextBox2" Enabled="False"></asp:RequiredFieldValidator>
            </div>
        </div>
                <div class="form-group col-md-7">
           
            <asp:Label ID="Label4" runat="server" Text="LAST NAME" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox3" runat="server" class = "form-control"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredField" ForeColor="Red" ControlToValidate="TextBox3" Enabled="False"></asp:RequiredFieldValidator>
            </div>
        </div>
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label5" runat="server" Text="PREFERRED LANGUAGE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox4" runat="server" class = "form-control"></asp:TextBox>
          </div>
        </div>   <div class="form-group col-md-7">
           
            <asp:Label ID="Label25" runat="server" Text="TELEPHONE NUMBER" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox8" runat="server" class = "form-control"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredField" ForeColor="Red"  ControlToValidate="TextBox8" Enabled="False"></asp:RequiredFieldValidator>
            </div>
        </div>
              
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label8" runat="server" Text="EMAIL ADDRESS" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox6" runat="server" class = "form-control"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredField" ForeColor="Red" ControlToValidate="TextBox6" Enabled="False"></asp:RequiredFieldValidator>
                 </div>
        </div>
               <div class="form-group col-md-7">
           
            <asp:Label ID="Label6" runat="server" Text="MOBILE / CALL NUMBER" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox5" runat="server" class = "form-control"></asp:TextBox>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredField" ForeColor="Red" ControlToValidate="TextBox5" Enabled="False"></asp:RequiredFieldValidator>
            </div>
        </div>
              
            </div> 
         <div class="row">
         <div class="form-group col-md-6">
           
         <strong>    <asp:Label ID="Label26" runat="server" Text="PRIMARY / BILLING ADDRESS" class = "control-label col-md-8"></asp:Label></strong>
           
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
                 <asp:TextBox ID="TextBox11" runat="server" class = "form-control"></asp:TextBox>
            </div>
        </div>
               <div class="form-group col-md-7">
           
            <asp:Label ID="Label11" runat="server" Text="ADDRESS LINE 1" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox10" runat="server" class = "form-control"></asp:TextBox>
            </div>
        </div>
               
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label14" runat="server" Text="ADDRESS LINE 2" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox14" runat="server" class = "form-control"></asp:TextBox>
           </div>
        </div>
              <div class="form-group col-md-7">
           
            <asp:Label ID="Label13" runat="server" Text="ADDRESS LINE 2" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox13" runat="server" class = "form-control"></asp:TextBox>
          
            </div>
        </div>
               
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label17" runat="server" Text="CITY" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox16" runat="server" class = "form-control"></asp:TextBox>
            </div>
        </div>
              <div class="form-group col-md-7">
           
            <asp:Label ID="Label15" runat="server" Text="CITY" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox15" runat="server" class = "form-control"></asp:TextBox>
          
            </div>
        </div>
               
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label19" runat="server" Text="REGION/STATE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox18" runat="server" class = "form-control"></asp:TextBox>
            </div>
        </div>
              <div class="form-group col-md-7">
           
            <asp:Label ID="Label18" runat="server" Text="REGION/STATE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox17" runat="server" class = "form-control"></asp:TextBox>
          
            </div>
        </div>
             
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label21" runat="server" Text="PORTAL/ZIPCODE" class = "control-label col-md-5"></asp:Label>
        </div>
                <div class="form-group col-md-7">
           
            <asp:Label ID="Label20" runat="server" Text="PORTAL/ZIPCODE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox19" runat="server" class = "form-control"></asp:TextBox>
          
            </div>
        </div>
              
            </div> 
         <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label23" runat="server" Text="COUNTRY" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox22" runat="server" class = "form-control"></asp:TextBox>
            </div>
        </div>
               <div class="form-group col-md-7">
           
            <asp:Label ID="Label22" runat="server" Text="COUNTRY" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox21" runat="server" class = "form-control"></asp:TextBox>
          
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
</asp:Content>
