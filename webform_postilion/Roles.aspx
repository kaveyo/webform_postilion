<%@ Page Title="" Language="C#" MasterPageFile="~/Site2.Master" AutoEventWireup="true" CodeBehind="Roles.aspx.cs" Inherits="webform_postilion.Roles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <script src="Scripts/jquery.min.js"></script>
    <script src="Scripts/jquery-3.3.1.js"></script>
    <script src="Scripts/sweetalert2.all.min.js"></script>
    <script src="Scripts/sweetalert2.min.js"></script>
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
        function SelectAllCheckboxes(chk) {
            var totalRows = $("#<%=GridView1.ClientID%> tr").length;
            var selected = 0;
            
     $('#<%=GridView1.ClientID%>').find("input:checkbox").each(function () {
         if (this != chk) {
             this.checked = chk.checked;
             selected += 1;
         }
     });
        }
        function CheckedCheckboxes(chk) {
            if (chk.checked) {
                var totalRows = $('#<%=GridView1.ClientID %> :checkboxes').length;
                var checked = $('#<%=GridView1.ClientID %> :checkbox:checked').length;
                if (checked == (totalRows - 1)) {
                    $('#<%=GridView1.ClientID %>').find("input:checkbox").each(function () {
                        this.checked = true;
                    });
                }
                else
                {
                    $('#<%=GridView1.ClientID %>').find('input:checkbox:first').removeAttr('checked');
                }
            }
            else {
                 $('#<%=GridView1.ClientID %>').find('input:checkbox:first').removeAttr('checked');
             }
         }
    </script>
    <div class="form-horizontal">
        <h4>EDIT ROLES</h4>
        <hr />               
        
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
               
        
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:postcard_portal_testConnectionString4 %>" SelectCommand="SELECT [id], [action], [branch_users], [convenience_users] FROM [postilion_role]"></asp:SqlDataSource>
      
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:postcard_portal_testConnectionString3 %>" SelectCommand="SELECT [id], [action] FROM [postilion_role]"></asp:SqlDataSource>
       <div class="table-responsive">
           <asp:GridView ID="GridView1" runat="server" CssClass="table table-responsive thead-dark" AutoGenerateColumns="False" DataKeyNames="id">
            
            <Columns>

                <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False"  ReadOnly="True" SortExpression="id">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="action" HeaderText="ACTION METHOD" SortExpression="action">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="BANK USERS">
                    <HeaderTemplate>
                        ASSIGN ROLE
                        <asp:CheckBox ID="CheckBox3" runat="server" onclick="javascript:SelectAllCheckboxes(this);" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server"  onclick="javascript:CheckedCheckboxes(this);" Checked='<%# Eval(DropDownList2.Text).ToString()=="1" ? true : false %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
              
            </Columns>
            <HeaderStyle CssClass=”thead-dark” />
        </asp:GridView>
        <%--<asp:GridView ID="GridView1" runat="server" CssClass="table table-responsive thead-dark" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource2">
            
            <Columns>

                <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False"  ReadOnly="True" SortExpression="id">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="action" HeaderText="ACTION METHOD" SortExpression="action">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="BANK USERS">
                    <HeaderTemplate>
                        BRANCH USERS
                        <asp:CheckBox ID="CheckBox3" runat="server" onclick="javascript:SelectAllCheckboxes(this);" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server"  onclick="javascript:CheckedCheckboxes(this);" Checked='<%# Eval("branch_users").ToString()=="1" ? true : false %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CONVENIENCE USERS">
                    <HeaderTemplate>
                        CONVENIENCE USERS<asp:CheckBox ID="CheckBox4" runat="server" OnClientClick="HeaderCheckBoxClick(this);" onclick="javascript:SelectAllCheckboxes(this);" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" onclick="javascript:CheckedCheckboxes(this);" Checked='<%# Eval("convenience_users").ToString()=="1" ? true : false %>' />
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
            <HeaderStyle CssClass=”thead-dark” />
        </asp:GridView>--%>
        
           </div>
        </div>
    <div class="container">
            <div class="">
           
               <asp:Button ID="Button4" runat="server" Text="SAVE" class="btn btn-success" OnClick="Button4_Click"  />
           
            </div>
        </div>

    <script type="text/javascript" language="javascript">

        function HeaderCheckBoxClick(checkbox) {
            var gridView = document.getElementById("GridView1");
            for (i = 1; i < gridView.rows.length; i++) {
                gridView.rows[i].cells[2].getElementsByTagName("INPUT")[i].checked
                    = checkbox.checked;
                gridView.rows[i].cells[3].getElementsByTagName("INPUT")[0].checked
                    = checkbox.checked;
               
            }
        }
        
        
    </script>
</asp:Content>
