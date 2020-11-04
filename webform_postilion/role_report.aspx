<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="role_report.aspx.cs" Inherits="webform_postilion.role_report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top:3%;">
          <div class="row">
          <div class="form-group col-md-12">           
          <h4>  <asp:Label ID="Label13" runat="server" Text="ROLE REPORT"  class = "control-label col-md-3 text-info text-center"></asp:Label>            
       </h4>
              </div>

              </div>
          <div class="row">
                           <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="1000px"></rsweb:ReportViewer>
          </div>
    </div>
</asp:Content>
