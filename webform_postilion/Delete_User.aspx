<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Delete_User.aspx.cs" Inherits="webform_postilion.Delete_User" %>
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

        function deleted(id) {
            
            Swal.fire({
                title: 'Are you sure?' ,
                text: "You won't be able to revert this!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Yes, delete it!'
            }).then((result) => {
                if (result.value) {
                    $.ajax({
                        type: "POST",
                        url: "Delete_User.aspx/DeleteClick",
                        data: "{id:" + id + "}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (r) {
                            Swal("DELETED", r.d, "success");
                        }
                    });
                }
            })
        }
        

      
        
    
    </script>
    <div class="form-horizontal">
        <h4>DELETE USER</h4>
        <hr />
           
           
<div class="container">
    <div style="margin-top : 2%;" id="editors">
     
       <div class="row">
        <div class="form-group col-md-5">
            <asp:Label ID="Label2" runat="server" Text="USERNAME" class = "control-label col-md-5"></asp:Label>
          <div class="col-md-7">
              <asp:TextBox ID="first" runat="server" class = "form-control"></asp:TextBox>
              </div>
                <div class="form-group col-md-5">
          <div class="col-md-7">
            </div>
        </div>
        </div>
                          
          <%--   <div class="form-group col-md-5">
            <asp:Label ID="Label1" runat="server" Text="SURNAME" class = "control-label col-md-5"></asp:Label>
          <div class="col-md-7">
              <asp:TextBox ID="surname" runat="server" class = "form-control"></asp:TextBox>
           </div>
        </div>--%>
             <div class="form-group col-md-2">
            
          <div class="col-md-7">
                <asp:Button ID="Button1" runat="server" Text="SEARCH" class="btn btn-success" OnClick="Button4_Click" />
           
          </div>
        </div>
          </div>  
         </div>
     
     <%-- <div class="row">
         <div class="form-group col-md-5">
           
            <asp:Label ID="Label7" runat="server" Text="ROLE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:DropDownList ID="role" runat="server" class = "form-control" Enabled="TRUE" AutoPostBack="false">
                    <asp:ListItem>MAKER</asp:ListItem>
                    <asp:ListItem>CHECKER</asp:ListItem>
                    

      </asp:DropDownList>
            </div>
        </div>
             
            </div> --%>
        
       
     
       <div class="row">
         <div class="form-group col-md-5">
           
           
        <div class="col-md-7">
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" OnRowCommand="GridView1_RowCommand" Width="1025px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px">
             <AlternatingRowStyle BackColor="#DCDCDC" />
             <Columns>
                 <asp:BoundField AccessibleHeaderText="IDENTITY" DataField="user_id" HeaderText="IDENTITY" />
                 <asp:BoundField DataField="username" HeaderText="USERNAME" />
                 <asp:BoundField DataField="first_name" HeaderText="FIRST NAME" />
                 <asp:BoundField DataField="active" HeaderText="STATUS" />
                 <asp:BoundField DataField="branch" HeaderText="BRANCH" />
                 <asp:BoundField DataField="role" HeaderText="ROLE" />
                 <asp:ButtonField ButtonType="Button" CommandName="accept2"   HeaderText="UPDATE" Text="UPDATE" />
                 <asp:ButtonField ButtonType="Button" CommandName="reject2" HeaderText="DELETE" Text="DELETE" />
             </Columns>
             <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
             <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
             <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
             <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
             <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
             <SortedAscendingCellStyle BackColor="#F1F1F1" />
             <SortedAscendingHeaderStyle BackColor="#0000A9" />
             <SortedDescendingCellStyle BackColor="#CAC9C9" />
             <SortedDescendingHeaderStyle BackColor="#000065" />
         </asp:GridView>
            </div> 
            </div>
    </div>
        </div>
   
</div>


 
</asp:Content>
