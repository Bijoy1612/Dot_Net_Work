<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout/AdminMain.Master" AutoEventWireup="true" CodeBehind="~/Student/StudentRegistration.aspx.cs" Inherits="RealProjectB2.Student.StudentRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-control {
            border-radius: 0px !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page Heading -->
    <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <asp:Label ID="lblHeading" CssClass="h3 mb-0 text-gray-800" runat="server" Text="Student Registration Info"></asp:Label>
        <%-- <h1 class="h3 mb-0 text-gray-800">Dashboard</h1>--%>
        <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fas fa-download fa-sm text-white-50"></i>Generate Report</a>
    </div>
    <div class="card">
        <div class="card-header bg-gradient-primary text-light">
            Personal Details
        </div>


        <div class="card-body">
            <div class="row">
                <div class="col-md-6">
                    <label class="form-label">First Name</label>
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label class="form-label">Last Name</label>
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <label class="form-label">Father's Name</label>
                    <asp:TextBox ID="txtFathersName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label class="form-label">Mother's Name</label>
                    <asp:TextBox ID="txtMothersName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-3">
                    <label class="form-label">Contact Number</label>
                    <asp:TextBox ID="txtContact1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label class="form-label">Secondery Contact</label>
                    <asp:TextBox ID="txtContact2" runat="server" CssClass="form-control"></asp:TextBox>
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
                    <label class="form-label">Student Type</label>
                    <asp:DropDownList ID="ddlStudentType" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Select --</asp:ListItem>
                        <asp:ListItem Value="1">New</asp:ListItem>
                        <asp:ListItem Value="2">Old</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <label class="form-label">Post Code</label>
                    <asp:TextBox ID="txtPostCode" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <label class="form-label">Address</label>
                    <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

            </div>
        </div>
    </div>

    <div class="card mt-3">
        <div class="card-header bg-gradient-primary text-light">
            Parents Info
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-4">
                    <label class="form-label">Father's Name</label>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-8">
                    <label class="form-label">Occupation</label>
                    <asp:RadioButtonList ID="rblOccupation" CssClass="mr-2" runat="server" RepeatDirection="Horizontal" CellPadding="6" CellSpacing="4">
                        <asp:ListItem Value="1"> Private Service</asp:ListItem>
                        <asp:ListItem Value="2"> Govt. Service</asp:ListItem>
                        <asp:ListItem Value="3"> Business</asp:ListItem>
                        <asp:ListItem Value="0"> Farmer</asp:ListItem>
                        <asp:ListItem Value="5"> Ohters</asp:ListItem>
                    </asp:RadioButtonList>
                    
                
                </div>
            </div>
        <div class="row"> 
                 <div class="col-md-6">
                    <label class="form-label">Contact Number</label>
                    <asp:TextBox ID="txtFatherContactNo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label class="form-label">Father Email</label>
                    <asp:TextBox ID="txtFatherEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

            </div>

            <div class="row">
                <div class="col-md-3">
                    <label class="form-label">Contact Number</label>
                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label class="form-label">Secondery Contact</label>
                    <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label class="form-label">Email</label>
                    <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <label class="form-label">Date Of Birth</label>
                    <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label class="form-label">Gender</label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Select --</asp:ListItem>
                        <asp:ListItem Value="1">Male</asp:ListItem>
                        <asp:ListItem Value="2">Female</asp:ListItem>
                        <asp:ListItem Value="3">Others</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <label class="form-label">Student Type</label>
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Select --</asp:ListItem>
                        <asp:ListItem Value="1">New</asp:ListItem>
                        <asp:ListItem Value="2">Old</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <label class="form-label">Post Code</label>
                    <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-12">
                    <label class="form-label">Address</label>
                    <asp:TextBox ID="TextBox10" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

            </div>
        </div>
    </div>

    <div class="card mt-3">
        <div class="card-header bg-gradient-primary text-light">
            Educational Details
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-3">
                    <label class="form-label">Level/Cirtiuficate</label>
                    <asp:DropDownList ID="ddlLevelCirtificate" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Select --</asp:ListItem>
                        <asp:ListItem Value="1">SSC</asp:ListItem>
                        <asp:ListItem Value="2">HSC</asp:ListItem>
                        <asp:ListItem Value="3">Graduation</asp:ListItem>
                        <asp:ListItem Value="4">Masters</asp:ListItem>
                        <asp:ListItem Value="5">Others</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-3">
                    <label class="form-label">Passing Year</label>
                    <asp:TextBox ID="txtPassingYear" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label class="form-label">Result</label>
                    <asp:TextBox ID="txtResult" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label class="form-label">Board Name</label>
                    <asp:DropDownList ID="ddlBoardName" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Select --</asp:ListItem>
                        <asp:ListItem Value="1">Dhaka</asp:ListItem>
                        <asp:ListItem Value="2">Chittagong</asp:ListItem>
                        <asp:ListItem Value="3">Khulna</asp:ListItem>
                        <asp:ListItem Value="4">Comilla</asp:ListItem>
                        <asp:ListItem Value="5">Barishal</asp:ListItem>
                        <asp:ListItem Value="6">Rajshahi</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <div class="row">
                <div class="col-md-6">
                    <label class="form-label">Photo</label>
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control"/>
                </div>
                <div class="col-md-6">
                    <br />
                    <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btn btn-primary form-control mt-2"/>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
