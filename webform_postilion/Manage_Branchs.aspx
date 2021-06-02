<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Manage_Branchs.aspx.cs" Inherits="webform_postilion.Manage_Branchs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/sweetalert2.all.min.js"></script>
    <script src="Scripts/sweetalert2.min.js"></script>
    <script>
        function alertme( msg) {
            swal({
                title: "ALERT",
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
        <h4>MANAGE BRANCHES </h4>
        <hr />
           
           
<div class="container">
          <div style="margin-top : 2%;" id="editors">
     
       <div class="row">
        <div class="form-group col-md-5">
            <asp:Label ID="Label2" runat="server" Text="BRANCH" class = "control-label col-md-5"></asp:Label>
              <div class="col-md-7">
              <asp:DropDownList ID="DropDownList2" runat="server" class = "form-control">                  
                 
                     </asp:DropDownList>
              </div>
                <div class="form-group col-md-5">
          <div class="col-md-7">
            </div>
        </div>
        </div>
                          
     
             <div class="form-group col-md-2">
            
          <div class="col-md-7">
                <asp:Button ID="Button1" runat="server" Text="SEARCH BRANCH" class="btn btn-success" OnClick="Button1_Click" />
           
          </div>
        </div>
          </div>  
         </div>
        
       <div class="row">
         <div class="form-group col-md-5">
           
           
        <div class="col-md-7">
             <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" OnRowCommand="GridView1_RowCommand" Width="1025px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px">
             <AlternatingRowStyle BackColor="#DCDCDC" />
             <Columns>
                 <asp:BoundField AccessibleHeaderText="IDENTITY" DataField="id" HeaderText="IDENTITY" />
                 <asp:BoundField DataField="id" HeaderText="ID" />
                 <asp:BoundField DataField="branch" HeaderText="BRANCH" />
                 <asp:BoundField DataField="checker" HeaderText="APPROVED" />
                 <asp:ButtonField ButtonType="Button" CommandName="accept2"   HeaderText="MAKE AUTHORISER" Text='CHANGE' />
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
