<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="RealProjectB2.auth.register" %>

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
        .input-group-text, .form-control {
            border-radius: 0px !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid bg-gradient-success">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-md-4 mt-5">
                        <div class="site_logo text-center">
                            <img class="img-fluid w-50" alt="Site Logo" src="../assets/img/logo-2.png" />
                        </div>
                    </div>
                    <div class="col-md-10 mb-5">
                        <div id="divMsg" runat="server" class="alert alert-danger">
                            <asp:Label ID="lblMsg" runat="server" CssClass="text-danger" Text=""></asp:Label>
                        </div>
                        <div class="card">
                            <div class="card-header bg-gradient-primary text-light">
                                Register
                            </div>


                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-3">
                                        <label class="form-label">Userame</label>
                                        <asp:TextBox ID="txtuserName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="form-label">First Name</label>
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="form-label">Mid Name</label>
                                        <asp:TextBox ID="txtMidName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="form-label">Last Name</label>
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <label class="form-label">Contact Number</label>
                                        <asp:TextBox ID="txtContact" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-label">Email</label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-3">
                                        <label class="form-label">Date Of Birth</label>
                                        <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="form-label">Gender</label>
                                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">Select --</asp:ListItem>
                                            <asp:ListItem Value="1">Male</asp:ListItem>
                                            <asp:ListItem Value="2">Female</asp:ListItem>
                                            <asp:ListItem Value="3">Others</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="form-label">Religion</label>
                                        <asp:DropDownList ID="ddlReligion" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0">Select --</asp:ListItem>
                                            <asp:ListItem Value="1">Islam</asp:ListItem>
                                            <asp:ListItem Value="2">Hindu</asp:ListItem>
                                            <asp:ListItem Value="3">Christian</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="form-label">User Image</label>
                                        <asp:FileUpload ID="flUserImage" runat="server" CssClass="form-control" />
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <label class="form-label">Address</label>
                                        <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <label class="form-label"></label>
                                        
                                    </div>
                                    <div class="col-md-6">
                                        <br />
                                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-success form-control mt-2" OnClick="btnAdd_Click" />
                                    </div>
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
