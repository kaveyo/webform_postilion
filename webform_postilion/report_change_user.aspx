<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="report_change_user.aspx.cs" Inherits="webform_postilion.report_change_user" %>
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
            Swal.fire(
                'WARNING!',
                msg + "!",
                'success'
            )
        }
    </script>
    <div class="row " style="margin-top:3%;">
         <div class="form-group col-md-4">
               <asp:Label ID="Label2" runat="server" Text="SELECT USER" class = "control-label col-md-6"></asp:Label>
               <asp:DropDownList ID="DropDownList1" runat="server" class = "form-control col-md-6" Enabled="True" >
                   
                </asp:DropDownList>
          
       </div>
         <div class="form-group col-md-3">
           
            <asp:Label ID="Label13" runat="server" Text="BRANCH" class = "control-label col-md-4"></asp:Label>
            <div class="col-md-8">
                 <asp:DropDownList ID="DropDownList2" runat="server" class = "form-control">
              
                     </asp:DropDownList>
            </div>
        </div>
        <div class="form-group col-md-3">
              <asp:Button ID="Button1" runat="server" Text="REFRESH" class="btn btn-success"  autopostback="false" OnClick="Button1_Click"/>
          </div>
         <div class="form-group col-md-2">
              <asp:Button ID="Button4" runat="server" Text="Search" class="btn btn-success" OnClick="Button4_Click" autopostback="false"/>
          </div>
    </div>
    
     <div class="row">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="966px"></rsweb:ReportViewer>
    </div>
</asp:Content>
