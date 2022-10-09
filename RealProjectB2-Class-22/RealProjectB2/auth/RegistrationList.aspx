<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout/AdminMain.Master" AutoEventWireup="true" CodeBehind="RegistrationList.aspx.cs" Inherits="RealProjectB2.auth.RegistrationList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <asp:Label ID="lblHeading" CssClass="h3 mb-0 text-gray-800" runat="server" Text="User Registration Info"></asp:Label>
        <%-- <h1 class="h3 mb-0 text-gray-800">Dashboard</h1>--%>
        <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fas fa-download fa-sm text-white-50"></i></a>
    </div>
    <div class="card">
        <div class="card-body">
            <div class="row">
                <div class="col-md-5">
                    <label class="form-label">Religion</label>
                    <asp:DropDownList ID="ddlReligion" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Select --</asp:ListItem>
                        <asp:ListItem Value="1">Islam</asp:ListItem>
                        <asp:ListItem Value="2">Hindu</asp:ListItem>
                        <asp:ListItem Value="3">Christian</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-5">
                    <label class="form-label">Gender</label>
                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">Select --</asp:ListItem>
                        <asp:ListItem Value="1">Male</asp:ListItem>
                        <asp:ListItem Value="2">Female</asp:ListItem>
                        <asp:ListItem Value="3">Others</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2" style="margin-top:33px">
                    <asp:Button ID="btnSearch" runat="server"  CssClass="btn btn-success" Text="Search" OnClick="btnSearch_Click" />
                </div>
            </div>
        </div>
        <div class="card-header bg-gradient-primary text-light">
            User Registration Info
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-12">

                    <asp:GridView ID="gvRegList" runat="server" CssClass="table table-bordered table-striped" >
                    </asp:GridView>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
