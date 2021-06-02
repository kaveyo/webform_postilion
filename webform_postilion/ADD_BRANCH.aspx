<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="ADD_BRANCH.aspx.cs" Inherits="webform_postilion.ADD_BRANCH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function alertme(msg) {
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
        <h4>ADD BRANCH</h4>
        <hr /> <hr/>

          <h5>ENTER BRANCH NAME</h5>

          <div style="margin-top : 2%;" id="editors">
     <div class="container">
         <div class="form-group col-md-7">
            <asp:Label ID="Label3" runat="server" Text="BRANCH" class = "control-label col-md-5"></asp:Label>
              <div class="col-md-7">
              <asp:DropDownList ID="DropDownList2" runat="server" class = "form-control">                  
                 
                     </asp:DropDownList>
              </div>
                <div class="form-group col-md-5">
          <div class="col-md-7">
            </div>
        </div>
        </div>  
        <div class="form-group col-md-7">
                  <asp:Label ID="Label1" runat="server" Text="UNIQUE BRANCH NUMBER" class = "control-label col-md-5"></asp:Label>
             <div class="col-md-7">
                  <asp:TextBox ID="TextBox3" runat="server" class = "form-control" ></asp:TextBox>
                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="ENTER THREE DIGIT NUMBER" ValidationExpression = "^[\s\S]{3,3}$" ForeColor="Red" ></asp:RegularExpressionValidator>
           <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox3" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
               
                    </div>
              </div> 
          
            <div class="form-group col-md-7">
              
                  <asp:Label ID="Label2" runat="server" Text="BRANCH NAME" class = "control-label col-md-5"></asp:Label>
                 <div class="col-md-7">
                  <asp:TextBox ID="TextBox1" runat="server" class = "form-control"></asp:TextBox>                 
                     </div>                  
             </div> 
         
        
             <div class="form-group col-md-7">
            
          <div class="col-md-12">
                <asp:Button ID="Button1" runat="server" Text="ADD BRANCH" class="btn btn-success" OnClick="Button1_Click"  />           
          </div>
       
         </div>
           
         </div>
         </div>
     </div>
</asp:Content>
