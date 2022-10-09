<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="RealProjectB2.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- Custom fonts for this template-->
    <link href="../assets/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" />
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="../assets/css/sb-admin-2.min.css" rel="stylesheet">

    <!--Our Custom styles-->
    <link href="../assets/css/custom-style.css" rel="stylesheet" />
    <style>
        .input-group-text,.form-control{
            border-radius:0px !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid bg-gradient-success vh-100">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-4 mt-5">
                        <div class="site_logo text-center">
                            <img class="img-fluid w-50" alt="Site Logo" src="assets/img/logo-2.png" />
                        </div>

                        <div id="divMsg" runat="server" class="alert alert-danger" >
                            <asp:Label ID="lblMsg" runat="server" CssClass="text-danger" Text=""></asp:Label>
                        </div>
                        <div class="card mt-1">
                            <div class="card-body">
                                <div class="input-group flex-nowrap mt-4">
                                    <span class="input-group-text" id="">
                                        <i class="fas fa-user"></i>
                                    </span>
                                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                                </div>

                                <div class="input-group flex-nowrap mt-4 mb-2">
                                    <span class="input-group-text" id="">
                                        <i class="fas fa-lock"></i>
                                    </span>
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Pasword" TextMode="Password"></asp:TextBox>
                                </div>
                                <asp:CheckBox ID="cbRemember" runat="server" Text="Remember"/>
                                <div class="input-group flex-nowrap mt-4">
                                    <span class="input-group-text" id="">
                                        <i class="fas fa-paper-plane"></i>
                                    </span>
                                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="form-control btn btn-success" OnClick="btnLogin_Click"/>
                                </div>
                                <div class="login_links mt-4">
                                    <a href="#">Forgot Password</a>
                                    <a href="auth/register.aspx" class="float-right">Register</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!-- Bootstrap core JavaScript-->
    <script src="../assets/vendor/jquery/jquery.min.js"></script>
    <script src="../assets/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="../assets/vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="../assets/js/sb-admin-2.min.js"></script>

    <!-- Page level plugins -->
    <script src="../assets/vendor/chart.js/Chart.min.js"></script>

    <!-- Page level custom scripts -->
    <script src="../assets/js/demo/chart-area-demo.js"></script>
    <script src="../assets/js/demo/chart-pie-demo.js"></script>
</body>
</html>
