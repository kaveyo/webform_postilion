<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="webform_postilion.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
     <script src="Scripts/sweetalert2.all.js"></script>
    <script src="Scripts/sweetalert2.all.min.js"></script>
    <link href="Scripts/sweetalert2.css" rel="stylesheet" />
    <script src="Scripts/sweetalert2.js"></script>
    <link href="Scripts/sweetalert2.min.css" rel="stylesheet" />
    <script src="Scripts/sweetalert2.min.js"></script>
    <!-- Bootstrap Core CSS -->
    <link href="Content/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
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
    </script>
    <!-- MetisMenu CSS -->
    <link href="Content/vendor/metisMenu/metisMenu.min.css" rel="stylesheet">
    <link href="Content/vendor/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="Content/dist/css/sb-admin-2.css" rel="stylesheet">

    <!-- Morris Charts CSS -->
    <link href="Content/vendor/morrisjs/morris.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="Content/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
</head>
<body>
                 <div class="login100-form-avatar row text-center" style="margin-top:5%">
						<img src="Content/images/avatar-01.jpg" alt="AVATAR"/>
                      
					</div>
    <form id="form1" runat="server">
        <div style="margin-top:6%">
        <div>

             <div class="form-group col-md-5">
            <asp:Label ID="Label1" runat="server" Text="USERNAME" class = "control-label col-md-5"></asp:Label>
          <div class="col-md-7">
              <asp:TextBox ID="TextBox1" runat="server" class = "form-control" ></asp:TextBox>
            </div>
        </div>

        <div class="form-group col-md-7">
          
            <asp:Label ID="Label2" runat="server" Text="FULL NAME" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:TextBox ID="TextBox2" runat="server" class = "form-control"></asp:TextBox>
          </div>
        </div>
          </div>  
        <div class="row">
        <div class="form-group col-md-5">
         
            <asp:Label ID="Label12" runat="server" Text="PASSWORD" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"  class ="form-control"></asp:TextBox>
          
                </div>
        </div>
                <div class="form-group col-md-7">
           
            <asp:Label ID="Label16" runat="server" Text="REENTER PASSWORD" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox12" runat="server" TextMode="Password"  class = "form-control"></asp:TextBox>
          
            </div>
        </div>
            </div>
         <div class="row">
        <div class="form-group col-md-5">
           
            <asp:Label ID="Label3" runat="server" Text="ROLE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:DropDownList ID="DropDownList1" runat="server" class = "form-control">
                    <asp:ListItem>MAKER</asp:ListItem>
                    <asp:ListItem>CHECKER</asp:ListItem>
                </asp:DropDownList>
          
            </div>
        </div>
            
        <div class="form-group col-md-7">
           
            <asp:Label ID="Label13" runat="server" Text="BRANCH" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:DropDownList ID="DropDownList2" runat="server" class = "form-control">
                    
                 
                     </asp:DropDownList>
            </div>
        </div>
             </div>

             <div class="row">

        <div class="form-group text-center">
           
           
                <div class="row" style="margin-top:5%;">
                    <div class="col-md-10">
                        
                <asp:Button ID="Button2" runat="server" Text="REPORTS" class="btn btn-info" OnClick="Button2_Click"  />
                        <asp:Button ID="Button9" runat="server" Text="SAVE" class="btn btn-success" OnClick="Button9_Click"/>
                 <asp:Button ID="Button10" runat="server" Text="UPDATE USER INFO" class="btn btn-success" OnClick="Button10_Click" ToolTip="IF YOU WANT TO UPDATE PASSWORD YOU HAVE TO ENTER NEW PASSWORD INTO THE PASSWORD  FIELD" />
                <asp:Button ID="Button6" runat="server" Text="DELETE USER" class="btn btn-danger" OnClick="Button6_Click" />
                     <asp:Button ID="Button1" runat="server" Text="CLEAR" class="btn btn-success" OnClick="Button1_Click" />        
               <div class="btn btn-danger" ><a href='Login.aspx' style="color: #FFFFFF"> BACK</a></div>  
                    </div>
                </div>
        </div>
        </div>
            </div>
    </form>
</body>
</html>
