<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DE_P1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid bg-gradient-success" style="">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-9 mt-5">
                    <div class="card mb-5">
                        <div class="card-header bg-gradient-primary text-bg-primary">Student Entry Form </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="form-label">Class</label>
                                    <asp:DropDownList ID="ddlClass" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label">Subject</label>
                                    <asp:DropDownList ID="ddlSubject" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="form-label">Student Name</label>
                                    <asp:TextBox ID="txtName" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label">Mark</label>
                                    <asp:TextBox ID="txtMark" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                
                            </div>
                            <div class="col-md-10" align="right">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
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
