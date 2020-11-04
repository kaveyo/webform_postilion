<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Authorise.aspx.cs" Inherits="webform_postilion.Authorise" %>
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
        function alertme(msg) {
            swal({
                title: "ALERT",

                text: msg,
                icon: "success",
                button: "OK"

            });
        }
    </script>

    <div class="form-horizontal">
     <h4>Authorise Alterations</h4>
        <hr />
 <div class="container">
  
   <div class="form-group text-center center-block">
              <asp:Button ID="Button1" runat="server" Text="LOAD ALL ALTERATIONS" class="btn btn-info" autopostback="false" OnClick="Button1_Click"/>
          </div>

     <div class="row">                           
          <div class="form-group col-md-5">
                <asp:Label ID="Label1" runat="server" Text="FROM DATE" class = "control-label col-md-5"></asp:Label>
                 <div class="col-md-7">

              <asp:TextBox ID="datepicker34" runat="server" class = "form-control" ReadOnly="False" autocomplete="off" ClientIdMode="Static"></asp:TextBox>
           </div>
              </div>

         <div class="form-group col-md-5">
               <asp:Label ID="Label2" runat="server" Text="TO DATE" class = "control-label col-md-5"></asp:Label>
          <div class="col-md-7">
              <asp:TextBox ID="datepicker1" runat="server" class = "form-control" autocomplete="off"  ReadOnly="False" ClientIdMode="Static"></asp:TextBox>
          </div>
</div>
         <div class="form-group col-md-2">
              <asp:Button ID="Button4" runat="server" Text="Search" class="btn btn-success" OnClick="Button4_Click" autopostback="false"/>
          </div>
     <div style="overflow-y: scroll;height: 300px; width: 1090px;">
          

         <br />
         <br />
         <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:postcard_portal_testConnectionString2 %>" SelectCommand="SELECT [id], [maker], [date], [change_made], [pan], [account], [branch], [reason] FROM [postilion_portal_changes]"></asp:SqlDataSource>
         <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" GridLines="Vertical" OnRowCommand="GridView1_RowCommand" Width="1025px" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px">
             <AlternatingRowStyle BackColor="#DCDCDC" />
             <Columns>
                 <asp:BoundField AccessibleHeaderText="IDENTITY" DataField="id" HeaderText="IDENTITY" />
                 <asp:BoundField DataField="maker" HeaderText="MAKER" />
                 <asp:BoundField DataField="date" HeaderText="DATETIME" />
                 <asp:BoundField DataField="change_made" HeaderText="CHANGES MADE" />
                 <asp:BoundField DataField="pan" HeaderText="CARD NUMBER" />
                 <asp:BoundField DataField="account" HeaderText="ACCOUNT NUMBER" />
                 <asp:BoundField DataField="branch" HeaderText="BRANCH" />
                 <asp:BoundField DataField="reason" HeaderText="REASON OF ALTERATION" />
                <%-- <asp:ButtonField ButtonType="Button" CommandName="reason" HeaderText="REASON" Text="REASON" />--%>
                 <asp:ButtonField ButtonType="Button" CommandName="accept2" HeaderText="ACCEPT" Text="ACCEPT" />
                 <asp:ButtonField ButtonType="Button" CommandName="reject2" HeaderText="REJECT" Text="REJECT" />
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
         <div>
           <hr />
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

        var picker = new Pikaday(
            {
                field: document.getElementById('datepicker1'),
                format: 'YYYY-MM-DD'

            });

    </script>

</asp:Content>
