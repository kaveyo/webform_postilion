<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Authoriser_final.aspx.cs" Inherits="webform_postilion.Authoriser_final" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Authoriser</title>
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
        <div>
        </div>
    </form>
</body>
</html>
