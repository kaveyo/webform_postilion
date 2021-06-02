<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webform101.aspx.cs" Inherits="webform_postilion.webform101" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
          
    <title>Postilion Portal System</title>
    <link href="Content/vendor/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="Content/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/css/pikaday.js"></script>
    <link href="Scripts/css/pikaday.css" rel="stylesheet" />  
    <script src="Scripts/sweetalert2.all.js"></script>
    <script src="Scripts/sweetalert2.all.min.js"></script>
    <link href="Scripts/sweetalert2.css" rel="stylesheet" />
    <script src="Scripts/sweetalert2.js"></script>
    <link href="Scripts/sweetalert2.min.css" rel="stylesheet" />
    <script src="Scripts/sweetalert2.min.js"></script>
       <%--<script src="Scripts/jquery.min.js"></script>--%>
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
        function alertme4(msg) {
            swal({
                title: "REASON",
                //  text: "WRONG USERNAME OR PASSWORD",
                text: msg,
                icon: "success",
                button: "OK"

            });
        }
    </script>
   
    <!-- Bootstrap Core CSS -->
    <link href="Content/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- MetisMenu CSS -->
    <link href="Content/vendor/metisMenu/metisMenu.min.css" rel="stylesheet">
    <link href="Content/vendor/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="Content/dist/css/sb-admin-2.css" rel="stylesheet">

    <!-- Morris Charts CSS -->
    <link href="Content/vendor/morrisjs/morris.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="Content/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <style>
         
        .pointing{
            pointer-events:none; cursor:default
        }
        .kaveyo2 {
            padding-left: 0;
            margin-bottom: 0;
            list-style: none;
        }

            .kaveyo2 > li {
                position: relative;
                display: block;
            }

                .kaveyo2 > li > a {
                    position: relative;
                    display: block;
                    padding: 10px 15px;
                }

                    .kaveyo2 > li > a:hover,
                    .kaveyo2 > li > a:focus {
                        text-decoration: none;
                        background-color: #eee;
                    }

                .kaveyo2 > li.disabled > a {
                    color: #777;
                }

                    .kaveyo2 > li.disabled > a:hover,
                    .kaveyo2 > li.disabled > a:focus {
                        color: #777;
                        text-decoration: none;
                        cursor: not-allowed;
                        background-color: transparent;
                    }

            .kaveyo2 .open > a,
            .kaveyo2 .open > a:hover,
            .kaveyo2 .open > a:focus {
                background-color: #eee;
                border-color: #337ab7;
            }

            .kaveyo2 .kaveyo2-divider {
                height: 1px;
                margin: 9px 0;
                overflow: hidden;
                background-color: #e5e5e5;
            }

            .kaveyo2 > li > a > img {
                max-width: none;
            }

        .kaveyo {
            margin-right: 0;
        }

            .kaveyo li {
                display: inline-block;
            }

                .kaveyo li:last-child {
                    margin-right: 15px;
                }

                .kaveyo li a {
                    padding: 15px;
                    min-height: 50px;
                }

            .kaveyo .dropdown-menu li {
                display: block;
            }

                .kaveyo .dropdown-menu li:last-child {
                    margin-right: 0;
                }

                .kaveyo .dropdown-menu li a {
                    padding: 3px 20px;
                    min-height: 0;
                }

                    .kaveyo .dropdown-menu li a div {
                        white-space: normal;
                    }

            .kaveyo .dropdown-messages,
            .kaveyo .dropdown-tasks,
            .kaveyo .dropdown-alerts {
                width: 310px;
                min-width: 0;
            }

            .kaveyo .dropdown-messages {
                margin-left: 5px;
            }

            .kaveyo .dropdown-tasks {
                margin-left: -59px;
            }

            .kaveyo .dropdown-alerts {
                margin-left: -123px;
            }

            .kaveyo .dropdown-user {
                right: 0;
                left: auto;
            }
    </style>
    
    <script>
        function alertme_site() {

            document.getElementById("click_point").style.pointerEvents = "none";
            document.getElementById("click_point").style.cursor = "default";
            document.getElementById("2").style.pointerEvents = "none";
            document.getElementById("2").style.cursor = "default";


        }
        function admin() {
            document.getElementById("5").style.pointerEvents = "none";
            document.getElementById("5").style.cursor = "default";
            document.getElementById("click_point").style.pointerEvents = "none";
            document.getElementById("click_point").style.cursor = "default";
            document.getElementById("1").style.pointerEvents = "none";
            document.getElementById("1").style.cursor = "default";
            document.getElementById("3").style.pointerEvents = "none";
            document.getElementById("3").style.cursor = "default";
            document.getElementById("4").style.pointerEvents = "none";
            document.getElementById("4").style.cursor = "default";

        }
        function alertme2() {
            document.getElementById("5").style.pointerEvents = "none";
            document.getElementById("5").style.cursor = "default";
            document.getElementById("1").style.pointerEvents = "none";
            document.getElementById("1").style.cursor = "default";
            document.getElementById("2").style.pointerEvents = "none";
            document.getElementById("2").style.cursor = "default";
            document.getElementById("3").style.pointerEvents = "none";
            document.getElementById("3").style.cursor = "default";
            document.getElementById("4").style.pointerEvents = "none";
            document.getElementById("4").style.cursor = "default";

            document.getElementById("datepicker").datepicker();
        }

        $(function () {
            $("#datepicker1").datepicker();
        });


    </script>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" /></head>
<body>

    <form id="form1" runat="server">
          <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
        
        <script>

            function place(msg) {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: 'You Have Successfully ' + msg,
                    showConfirmButton: false,
                    timer: 1200
                })

            }

            function deleted(id) {

                Swal.fire({
                    title: 'Message!',
                    text: "DATA NOT FOUND!",
                    icon: 'warning',
                    showCancelButton: false,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'OK'
                }).then((result) => {
                    if (result.value) {
                        $.ajax({
                            type: "POST",
                            url: "Account_Card_Result.aspx/DeleteClick",
                            data: "{id:" + id + "}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (r) {

                                window.location.assign("/Search_Account_Pan.aspx");
                            }
                        });
                    }
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

            function activate(msg) {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: 'You Have Successfully ' + msg,
                    showConfirmButton: false,
                    timer: 1200
                })

            }
            function error(msg) {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    title: msg,
                    showConfirmButton: false,
                    timer: 1200
                })

            }
            function save(msg) {
                Swal.fire(
                    msg + "!",

                )

            }

            function alertMessage() {
                alert('ALERT!');
            }
            function notfound(id) {

                Swal.fire({
                    title: 'DATA NOT FOUND',
                    text: "CHECK IF INSERT INFO IN CORRECT",
                    icon: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes, delete it!'
                }).then((result) => {
                    if (result.value) {
                        $.ajax({
                            type: "POST",
                            url: "Login.aspx",
                            data: "{id:" + id + "}",
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (r) {
                                Swal("Data Transfered SuccessFully", r.d, "success");
                            }
                        });
                    }
                })
            }
        </script>
     

              
             <div id="wrapper">

        <!-- Navigation -->
        <nav class="navbar navbar-default navbar-static-top" role="navigation" style="margin-bottom: 0">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" >POSTILION PORTAL</a>
                <div class="navbar-brand text-center alert-danger"><asp:Label ID="Label7" runat="server" Text=""></asp:Label></div>
      
           </div>
           
            
            <!-- /.dropdown -->
            <ul class="kaveyo kaveyo2 navbar-right">
                <li class="navbar-brand ">
                    <div>
                        <asp:Label ID="Label8" runat="server" Text="WELCOME"></asp:Label>
                        <asp:Label ID="Label10" runat="server" Text=""></asp:Label>
                    </div>
                </li>
                <li class="dropdown">
                    <a class="dropdown-toggle" data-toggle="dropdown" href="#">
                        <i class="fa fa-user fa-fw">
                    
                    </i> <i class="fa fa-caret-down"></i>
                    </a>

                    <ul class="dropdown-menu dropdown-user">

                        <li class="divider"></li>
                        <li>
                            
                          <a href='Login.aspx' runat="server" ><i class="fa fa-sign-out fa-fw"></i> Logout</a>
                        </li>
                    </ul>
                    <!-- /.dropdown-user -->
                </li>
                <!-- /.dropdown -->
            </ul>
            <!-- /.navbar-top-links -->

         

            <div class="navbar-default sidebar" role="navigation">
                <div class="sidebar-nav navbar-collapse">
                    <ul class="nav" id="side-menu">
                        <li class="sidebar-search">
                            <div id="autocomplete" class="input-group custom-search-form">
                               
                                <asp:TextBox ID="TextBox7" class="form-control" runat="server"></asp:TextBox>
                                <span class="input-group-btn">                                       
                                   <asp:LinkButton runat="server" ID="btnRun" Text="<i class='btn btn-default fa fa-search'></i> "  ValidationGroup="edt"  CssClass="greenButton" />
                                </span>
                            </div>
                            <!-- /input-group -->
                        </li>
                        <li>
                            <a id="4"><i class="fa fa-dashboard fa-fw"></i> Dashboard</a>
                        </li>
                        <li>
                            <a href="#" id="1"><i class="glyphicon glyphicon-user" ></i> ACCOUNTS / CARDS<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                              <%--  <li>
                               
                                    <a href='Search_Account_Pan.aspx'>NORMAL ACCOUNTS</a>
                                </li>--%>
                                <li>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Search_Account_Pan.aspx" >NORMAL ACCOUNTS</asp:HyperLink>

                                </li>
                                <li>
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="Instant_Search_Account.aspx" >INSTANT ACCOUNTS</asp:HyperLink>

                                </li>
                               <%-- <li>
                                    <a href='Instant_Search_Account.aspx'>INSTANT ACCOUNTS</a>
                                </li>--%>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>
                            <li>
                            <a href="#" id="5"><i class="glyphicon glyphicon-user" ></i> RETAIL CUSTOMERS<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                              <%--  <li>
                                    <a href='Retail.aspx'>INSTANT CUSTOMER</a>
                                </li>
                                <li>
                                    <a href='Retail.aspx'>NORMAL ACCOUNTS CUSTOMER</a>
                                </li>--%>
                                <li>
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="Retail_instant.aspx" >INSTANT CUSTOMER</asp:HyperLink>

                                </li>
                                <li>
                                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="Retail.aspx" >NORMAL ACCOUNTS CUSTOMER</asp:HyperLink>

                                </li>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>


                    <%--    <li>
                            <a href="#" id="2"><i class="glyphicon glyphicon-folder-open"></i> REPORTS<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li>
                                <a href='Report_by_period.aspx'>CHANGES BY PERIOD</a>
                                </li>
                                <li>
                                <a href='report_change_user.aspx'>CHANGE BY USER</a>
                                </li>
                                  <li>
                                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="Report_by_period.aspx" >CHANGES BY PERIOD</asp:HyperLink>

                                </li>
                                <li>
                                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="report_change_user.aspx" >CHANGE BY USER</asp:HyperLink>

                                </li>
                            </ul>
                            <!-- /.nav-second-level -->
                        </li>--%>

             
                      
                        <li >
                           
                           <%-- <a href='Authorise.aspx' id="click_point"><i class="glyphicon glyphicon-pencil"></i> AUTHOURISE </a>--%>
                      <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="Authorise.aspx" ><i class='glyphicon glyphicon-pencil'></i> AUTHORISE</asp:HyperLink>

                          <%--  <asp:LinkButton runat="server"  href="Authorise.aspx" ID="LinkButton1" Text=" <i class='glyphicon glyphicon-pencil'></i> AUTHOURISE"  ValidationGroup="edt"  CssClass="greenButton" Enabled="False" />
                           --%> </li>

                    </ul>
                </div>
                <!-- /.sidebar-collapse -->
            </div>
            <!-- /.navbar-static-side -->
        </nav>

        <div id="page-wrapper">
       
       <div class="form-horizontal">
        <h4>Normal Accounts</h4>
        <hr />
<div class="container">
    <div style="margin-top : 5%;" id="editors">
        <div class="row">
        <div class="form-group col-md-5">
            <asp:Label ID="Label1" runat="server" Text="CARD NUMBER" class = "control-label col-md-5"></asp:Label>
          <div class="col-md-7">
              <asp:TextBox ID="TextBox1" runat="server" class = "form-control" ReadOnly="True" MaxLength="16" ></asp:TextBox>
       
          </div>
        </div>

        <div class="form-group col-md-7">
          
            <asp:Label ID="Label2" runat="server" Text="CARD SEQUENCE NUMBER" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:TextBox ID="TextBox2" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
          </div>
        </div>
          </div>  
        <div class="row">
        <div class="form-group col-md-5">
         
            <asp:Label ID="Label12" runat="server" Text="COMPANY CARD" class = "control-label col-md-5" Enabled="False" Visible="False"></asp:Label>
            <div class="col-md-7">
                <asp:CheckBox ID="CheckBox2" runat="server" Enabled="False" Visible="False"/>
                </div>
        </div>
                <div class="form-group col-md-7">
           
            <asp:Label ID="Label16" runat="server" Text="COMPANY NAME" class = "control-label col-md-5" Visible="False"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox12" runat="server" class = "form-control" EnableTheming="True" ReadOnly="True" Enabled="False" Visible="False"></asp:TextBox>
          
            </div>
        </div>
            </div>
         <div class="row">
        <div class="form-group col-md-5">
           
            <asp:Label ID="Label3" runat="server" Text="CARD STATUS" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox3" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
          
            </div>
        </div>
            
        <div class="form-group col-md-7">
           
            <asp:Label ID="Label13" runat="server" Text="CARD ISSUED :" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox9" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
          
            </div>
        </div>
             </div>

             <div class="row">

        <div class="form-group col-md-5">
           
            <asp:Label ID="Label14" runat="server" Text="BRANCH CODE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox10" runat="server" class = "form-control" ReadOnly="True" Visible="False"></asp:TextBox>
                <asp:DropDownList ID="DropDownList2" runat="server" class = "form-control" Enabled="False">
                      </asp:DropDownList>
              </div>
        </div>
        <div class="form-group col-md-7">
           
            <asp:Label ID="Label15" runat="server" Text="CARD PROGRAM" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                 <asp:TextBox ID="TextBox11" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
          
            </div>
        </div>
    </div>
         <div class="row">
        <div class="form-group col-md-5">
         
            <asp:Label ID="Label4" runat="server" Text="HOLD RESPONSE CODE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
              
           
          </div>
        </div>
        <div class="form-group col-md-7">
       
            <asp:Label ID="Label5" runat="server" Text="CARD ACTIVATED" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:TextBox ID="TextBox4" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
           </div>
        </div>
             </div>

         <div class="row">
        <div class="form-group col-md-5">
         
            <asp:Label ID="Label6" runat="server" Text="LAST UPDATED USER" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:TextBox ID="TextBox5" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
         </div>
        </div>
   
        <div class="form-group col-md-7">
          
            <asp:Label ID="Label9" runat="server" Text="LAST UPDATED DATE" class = "control-label col-md-5"></asp:Label>
            <div class="col-md-7">
                <asp:TextBox ID="TextBox6" runat="server" class = "form-control" ReadOnly="True"></asp:TextBox>
           </div>
        </div>
             </div>

       <div>
           <hr />
        </div>
        
         <h2> CUSTOMER </h2>
 
        <div>
           
        </div>
        <div>
           <hr />
        </div>
        
         <h2> LINKED ACCOUNTS </h2>
 
        <div>
        
        </div>
             <!-- Modal reason -->
            <div id="myModal" class="modal fade" role="dialog">
    <div class="modal-dialog">

        <!-- Modal content-->
        <div class="modal-content">
            <div class="modal-header">               

                <h4 class="modal-title">ENTER REASON</h4>
            </div>
            <div class="modal-body">

                  <asp:TextBox ID="phone_number" runat="server" class="form-control p-0 border-0" placeholder ="Phone Number" TextMode="Phone" ></asp:TextBox>
		              
            </div>
            <div class="modal-footer">
                <asp:Button ID="Button6" runat="server" Text="SAVE" class="btn btn-default"  OnClick="Button1_Click" />
            </div>
        </div>
    </div>
</div> <!--End Modal reason --> 

        <div class="container">
            <div class="">
                <div class="row">
                    <div class="col-md-10">
                           <asp:Button ID="Button7" runat="server" Text="PLACE / REMOVE HOLD" class="btn btn-danger" data-toggle="modal" data-target="#myModal" OnClientClick="return false;"  Visible="False" />
                          <asp:Button ID="Button1" runat="server" Text="EDIT" class="btn btn-info"   />
                          <asp:Button ID="Button2" runat="server" Text="ACTIVATE / DEACTIVATE" CssClass="btn btn-primary" data-toggle="modal" data-target="#myModal" OnClientClick="return false;" />
                         <asp:Button ID="Button3" runat="server" Text="LINK ACCOUNT" class="btn btn-info"  />
                    </div>
                </div>
                <div> <hr /></div>
                <div class="row">
                    <div class="col-md-10">
                        <asp:Button ID="Button9" runat="server" Text="ADD EXISTING CUSTOMER" class="btn btn-success"  />
                 <asp:Button ID="Button10" runat="server" Text="ADD NEW CUSTOMER" class="btn btn-success" />
               
               <asp:Button ID="Button4" runat="server" Text="SAVE" class="btn btn-success" />
                      <div class="btn btn-danger" ><a href='Search_Account_Pan.aspx' style="color: #FFFFFF"> BACK</a></div>  
           
                        </div>
                </div>

                <asp:TextBox ID="customer_id_text" runat="server" Visible="False"></asp:TextBox> 
                 
             
            </div>
        </div>
    </div>
    </div>
           </div>



    <script src="../vendor/jquery/jquery.min.js"></script>
    <script src="Content/vendor/jquery/jquery.min.js"></script>
         <script src="Content/vendor/jquery/jquery.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="../vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="Content/vendor/bootstrap/js/bootstrap.min.js"></script>
    <!-- Metis Menu Plugin JavaScript -->
    <script src="Content/vendor/metisMenu/metisMenu.min.js"></script>

    <!-- Morris Charts JavaScript -->
    <script src="Content/vendor/raphael/raphael.min.js"></script>
    <script src="Content/vendor/morrisjs/morris.min.js"></script>
    <script src="Content/data/morris-data.js"></script>

    <!-- Custom Theme JavaScript -->
    <script src="Content/dist/js/sb-admin-2.js"></script>
    </form>
</body>
</html>
