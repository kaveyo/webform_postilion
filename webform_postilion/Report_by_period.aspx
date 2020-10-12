<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Report_by_period.aspx.cs" Inherits="webform_postilion.Report_by_period" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function error(msg) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Error : ' + msg,
                showConfirmButton: false,
                timer: 1200
            })

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
      
    <div style="margin-top:3%;">
           <div class="form-group col-md-3">
                <asp:Label ID="Label1" runat="server" Text="FROM DATE" class = "control-label col-md-3"></asp:Label>
                 <div class="col-md-9">

                 <asp:TextBox ID="datepicker34" runat="server" class = "form-control" ReadOnly="False" autocomplete="off" ClientIdMode="Static"></asp:TextBox>
                 </div>
         </div>
         <div class="form-group col-md-3">
               <asp:Label ID="Label2" runat="server" Text="TO DATE" class = "control-label col-md-3"></asp:Label>
          <div class="col-md-9">
              <asp:TextBox ID="datepicker1" runat="server" class = "form-control" autocomplete="off"  ReadOnly="False" ClientIdMode="Static"></asp:TextBox>
          </div>
          </div>
          <div class="form-group col-md-3">
           
            <asp:Label ID="Label13" runat="server" Text="BRANCH" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:DropDownList ID="DropDownList2" runat="server" class = "form-control">
              
                     </asp:DropDownList>
            </div>
        </div>
         <div class="form-group col-md-3">
              <asp:Button ID="Button4" runat="server" Text="Search" class="btn btn-success" OnClick="Button4_Click" autopostback="false"/>
          </div>
    <div class="row">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="966px"></rsweb:ReportViewer>
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
