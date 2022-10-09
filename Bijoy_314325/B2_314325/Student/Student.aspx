<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site1.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="B2_314325.Student.Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid bg-gradient-success" style="">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-9 mt-5">
                    <div id="divMsg" runat="server" class="alert alert-danger">
                        <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="card mb-5">
                        <div class="card-header bg-gradient-primary text-bg-primary">
                            Personal Details      
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="form-label">First Name</label>
                                    <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label">Last Name</label>
                                    <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="form-label">Father's Name</label>
                                    <asp:TextBox ID="txtFatherName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label">Mother's Name</label>
                                    <asp:TextBox ID="txtMotherName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <label class="form-label">Contact Number</label>
                                    <asp:TextBox ID="txtContact1" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <label class="form-label">Secondery Contact</label>
                                    <asp:TextBox ID="txtContact2" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>

                                <div class="col-md-6">
                                    <label class="form-label">Email</label>
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <label class="form-label">Date Of Birth</label>
                                    <asp:TextBox ID="txtDOB" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <label class="form-label">Gender</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlGender" runat="server">
                                        <asp:ListItem Value="0">Select...</asp:ListItem>
                                        <asp:ListItem Value="1">Male</asp:ListItem>
                                        <asp:ListItem Value="2">Female</asp:ListItem>
                                        <asp:ListItem Value="3">Others</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <label class="form-label">Student Type</label>
                                    <asp:DropDownList ID="ddlstype" CssClass="form-control" runat="server">
                                        <asp:ListItem Value="0">Select...</asp:ListItem>
                                        <asp:ListItem Value="1">SSC</asp:ListItem>
                                        <asp:ListItem Value="2">HSC</asp:ListItem>
                                        <asp:ListItem Value="3">Under Graduate</asp:ListItem>
                                        <asp:ListItem Value="4">Post Graduate</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-3">
                                    <label class="form-label">Post Code</label>
                                    <asp:TextBox ID="txtPostCode" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <label class="form-label">Address</label>
                                        <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                    <div class="col-md-6 mt-5" align="right">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>
    <div class="card">
        <div class="card-header bg-gradient-primary text-bg-primary">Student Information </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="gvUserInfo" CssClass="table table-bordered table-striped" runat="server">
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
