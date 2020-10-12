<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReIssue1.aspx.cs" Inherits="webform_postilion.ReIssue1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="form-horizontal">
        <h4>Re-issue 2</h4>
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
                    <div class="form-group col-md-12">
           
                    <asp:Label ID="Label7" runat="server" Text="TITLE" class = "control-label col-md-2"></asp:Label>
                    <div class="col-md-10">
                    <asp:DropDownList ID="DropDownList1" runat="server" class = "form-control"></asp:DropDownList>
           
                    </div>
                </div>
                <div class="form-group col-md-12">
           
                    <asp:Label ID="Label16" runat="server" Text="FIRST NAME:" class = "control-label col-md-2"></asp:Label>
                    <div class="col-md-10">
                            <asp:TextBox ID="TextBox12" runat="server" class = "form-control"></asp:TextBox>
                    </div>
                </div>
             <div class="form-group col-md-12">
           
            <asp:Label ID="Label2" runat="server" Text="MIDDLE INITIALS" class = "control-label col-md-2"></asp:Label>
            <div class="col-md-10">
                 <asp:TextBox ID="TextBox2" runat="server" class = "form-control"></asp:TextBox>
          
            </div>
        </div>
              <div class="form-group col-md-12">
           
                    <asp:Label ID="Label3" runat="server" Text="LAST NAME" class = "control-label col-md-2"></asp:Label>
                    <div class="col-md-10">
                            <asp:TextBox ID="TextBox3" runat="server" class = "form-control"></asp:TextBox>
                    </div>
                </div>
             <div class="form-group col-md-12">
           
            <asp:Label ID="Label4" runat="server" Text="NAME ON CARD" class = "control-label col-md-2"></asp:Label>
            <div class="col-md-10">
                 <asp:TextBox ID="TextBox4" runat="server" class = "form-control"></asp:TextBox>
          
            </div>
        </div>
               <div class="form-group col-md-12">
           
            <asp:Label ID="Label5" runat="server" Text="MULTIPLE CARDHOLDERS" class = "control-label col-md-2"></asp:Label>
            <div class="col-md-10">
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
            <asp:Button ID="Button2" runat="server" Text="PREVIOUS" class="btn btn-danger" OnClick="Button2_Click" />
             
               <asp:Button ID="Button4" runat="server" Text="NEXT" class="btn btn-success" OnClick="Button4_Click"/>
              
             
               <div class="btn btn-danger" ><a href='Account_Card_Result.aspx' style="color: #FFFFFF"> BACK</a></div>  
            </div>
        </div>
    </div>
    </div>
           </div>
</asp:Content>
