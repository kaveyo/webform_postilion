<%@ Page EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="webform_postilion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/css/main.css" rel="stylesheet" />
    <link href="Content/css/util.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/jquery-3.3.1.slim.js"></script>
    <script src="Scripts/jquery-3.3.1.slim.min.js"></script>
    <script src="Scripts/jquery-3.3.1.js"></script>
<link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
<link href="Content/bootstrap.css" rel="stylesheet" />
<link href="Content/bootstrap.min.css" rel="stylesheet" />
<link href="Content/Site.css" rel="stylesheet" />
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
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <div class="container">

     
        <div class="row" style="margin-top :5%">
             <div class="login100-form-avatar">
						<img src="Content/images/avatar-01.jpg" alt="AVATAR"/>
                      
					</div>
            <div>
                <hr />
             </div>
            <div class="col-md-4 col-md-offset-4">
                
                <div class="login-panel panel panel-default">
                       
                    <div class="panel-heading">
                        <h3 class="panel-title">Please Sign In</h3>
                    </div>
                    <div class="panel-body" style="margin-top: auto; margin-bottom: auto;">
                        <form role="form">
                            <fieldset>
                                <div class="form-group">
                                    <!--input class="form-control" placeholder="Username" name="usernamme" type="text" autofocus-->

                                    
                                    <asp:Label ID="Label1" runat="server" Text="USERNAME" class = "control-label col-md-2" ></asp:Label>
                                   <asp:TextBox ID="TextBox1" runat="server" class = "form-control" ></asp:TextBox>
                                 <!--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" class = "text-danger" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate ="TextBox1"></asp:RequiredFieldValidator>
                                   -->


                                </div>
                                <div class="form-group">
                                    <!--input class="form-control" placeholder="Password" name="password" type="password" value=""-->

                                    <asp:Label ID="Label2" runat="server" Text="PASSWORD" class = "control-label col-md-2" ></asp:Label>
                                   <asp:TextBox ID="TextBox2" runat="server" class = "form-control" TextMode="Password" ></asp:TextBox>
                                 <!--  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" class = "text-danger" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate ="TextBox2"></asp:RequiredFieldValidator>
                                   -->

                                </div>
                                <div class="form-group">
                                        <asp:Label ID="Label3" runat="server" Text="ROLE" class = "control-label col-md-2" ></asp:Label>
                                
                                  <asp:DropDownList ID="DropDownList1" runat="server" class = "form-control">
                                      <asp:ListItem>MAKER</asp:ListItem>
                                      <asp:ListItem>CHECKER</asp:ListItem>
                                      <asp:ListItem>ADMINISTRATOR</asp:ListItem>
                                  </asp:DropDownList>
                                </div>
                                <div>
                                <asp:Button ID="Button1" runat="server" Text="LOGIN" class="btn btn-lg btn-primary btn-block" OnClick="Button1_Click" />
                                </div>
                                    <div style="margin-top:2%;">
                                <asp:Button ID="Button2" runat="server" Text="ADMIN LOGIN" class="btn btn-lg btn-block btn-danger"  Visible="False" OnClick="Button2_Click" />
                                </div>
                            
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>

        </div>
    </div>
    </form>
</body>
</html>
