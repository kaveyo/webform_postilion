<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Instant_Reissue.aspx.cs" Inherits="webform_postilion.Instant_Reissue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="form-horizontal">
        <h4>Instant Re-issue</h4>
        <hr />
<div class="container">
    <div style="margin-top : 5%;" id="editors">
        <div class="row">
        <div class="form-group col-md-5">
            <asp:Label ID="Label1" runat="server" Text="CARD NUMBER" class = "control-label col-md-5"></asp:Label>
          <div class="col-md-7">
              <asp:TextBox ID="TextBox1" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
            <!--     <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Error Correct Customer ID" ValidationExpression = "^[\s\S]{16,16}$" ForeColor="Red" ></asp:RegularExpressionValidator>
            -->
            </div>
        </div>

        <div class="form-group col-md-7">
          
            <asp:Label ID="Label2" runat="server" Text="CARD SEQUENCE NUMBER" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:TextBox ID="TextBox2" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
            <!--       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>
              <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox2" ErrorMessage="Error Correct Customer ID" ValidationExpression = "^[\s\S]{7,7}$" ForeColor="Red" ></asp:RegularExpressionValidator>
            -->
          </div>
        </div>
          </div>  
        <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label7" runat="server" Text="EXPIRY DATE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox7" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
          
            </div>
        </div>
                <div class="form-group col-md-7">
           
            <asp:Label ID="Label16" runat="server" Text="EXPIRY DAY" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox12" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
          
            </div>
        </div>
            </div>
         <div class="row">
            <div class="form-group col-md-5">
           
            <asp:Label ID="Label3" runat="server" Text="REASON FOR RE-ISSUE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem>LOST OR STOLEN</asp:ListItem>
                    <asp:ListItem>OTHER</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="SELECT CHOICE" ControlToValidate="RadioButtonList1"></asp:RequiredFieldValidator>
            </div>
        </div>
            
        <div class="form-group col-md-7">
           
            <asp:Label ID="Label13" runat="server" Text="HOLD RESPONSE CODE :" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:DropDownList ID="DropDownList2" runat="server" class = "form-control"></asp:DropDownList>
           
         
               
            </div>
        </div>
             </div>

             <div class="row">

          <div class="form-group col-md-5">
           
            <asp:Label ID="Label8" runat="server" Text="MAIL DESTINATION" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:RadioButtonList ID="RadioButtonList2" runat="server">
                    <asp:ListItem>MAIL CARD TO CUSTOMER</asp:ListItem>
                    <asp:ListItem>MAIL CARD TO ISSUER</asp:ListItem>
                </asp:RadioButtonList> 
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="SELECT CHOICE" ControlToValidate="RadioButtonList2"></asp:RequiredFieldValidator>
           
            </div>
        </div>
        <div class="form-group col-md-7">
           
            <asp:Label ID="Label15" runat="server" Text="TEMPORARY CARD GIVEN TO CUSTOMER" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:CheckBox ID="CheckBox1" runat="server" />
             
            </div>
        </div>
    </div>
 </div>

       <div>
           <hr />
        </div>

  
       
        <div class="container">
            <div class="">
           
               <asp:Button ID="Button4" runat="server" Text="NEXT" class="btn btn-success" OnClick="Button4_Click"/>
             
               <div class="btn btn-danger" ><a href='Instant_Card_Result.aspx' style="color: #FFFFFF"> BACK</a></div>  
            </div>
        </div>
    </div>
    </div>
           </div>
</asp:Content>
