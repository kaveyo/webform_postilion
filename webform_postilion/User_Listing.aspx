<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="User_Listing.aspx.cs" Inherits="webform_postilion.User_Listing" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top:3%;">
          <div class="row">
          <div class="form-group col-md-7">
           
            <asp:Label ID="Label13" runat="server" Text="BRANCH" class = "control-label col-md-3"></asp:Label>
            <div class="col-md-7">
                 <asp:DropDownList ID="DropDownList2" runat="server" class = "form-control">
              
                     </asp:DropDownList>
            </div>
        </div>
          <div class="form-group col-md-5">
              <asp:Button ID="Button4" runat="server" Text="Search" class="btn btn-success" OnClick="Button4_Click" autopostback="false"/>
          </div>
              </div>
          <div class="row">
              <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="966px"></rsweb:ReportViewer>
          </div>
    </div>
</asp:Content>
