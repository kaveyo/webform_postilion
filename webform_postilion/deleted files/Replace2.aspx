<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Replace2.aspx.cs" Inherits="webform_postilion.Replace2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <h4>REPLACE 3</h4>
        <hr />
<div class="container">
    <div style="margin-top : 2%;" id="editors">
   
        <div class="row">
                 
               <div class="form-group col-md-12">
           
            <asp:Label ID="Label5" runat="server" Text="INSTANT ISSUE THIS CARD" class = "control-label col-md-2"></asp:Label>
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
             
               <asp:Button ID="Button4" runat="server" Text="FINISH" class="btn btn-success" OnClick="Button4_Click"/>
              
             
               <div class="btn btn-danger" ><a href='Search_Account_Pan.aspx' style="color: #FFFFFF"> BACK</a></div>  
            </div>
        </div>
    </div>
    </div>
           </div>
</asp:Content>
