<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="DE_P1.Result" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid bg-gradient-success" style="">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-9 mt-5">
                    <div class="card mb-5">
                        <div class="card-header bg-gradient-primary text-bg-primary"> </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="form-label">Class</label>
                                    <asp:DropDownList ID="ddlClass" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnresult" runat="server" Text="View Result" OnClick="btnresult_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="card">
        <div class="card-header bg-gradient-primary text-bg-primary">Student Result Information </div>
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
