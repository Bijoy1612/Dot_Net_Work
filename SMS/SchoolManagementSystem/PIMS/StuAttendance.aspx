<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StuAttendance.aspx.cs" Inherits="SchoolManagementSystem.PIMS.StuAttendance" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField id="hdnStuId" runat="server"></asp:HiddenField>
    <uc1:ResponseMessage runat="server" ID="rmmsg" />
    <div class="content-wrapper">
    <div class="container">
        <div class="card card-primary">
            <h3 class="text-center">Student Attendance</h3>
            <uc1:ResponseMessage runat="server" ID="ResponseMessage" />
             <div class="card-body">
            <div class="row">
                <div class="col-md-3">
                    <label class="form-label">Shift</label>
                    <asp:DropDownList ID="ddlShift" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                 <div class="col-md-3">
                    <label class="form-label">Class Name</label>
                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
                 <div class="col-md-3">
                    <label class="form-label">Attendance Date</label>
                     <asp:TextBox ID="txtAttDate" runat="server" TextMode="Time" CssClass="form-control"></asp:TextBox>
                </div>
               
                <div class="col-md-12 mt-1">
                    <label>Student List</label>
                    <asp:GridView ID="gvClassShedule" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False">
                        <Columns>
                            
                             <asp:TemplateField>
                                <HeaderTemplate>Roll No</HeaderTemplate>
                                <ItemTemplate>

                <asp:Label ID="lblRollNo" runat="server" Text='<%# Eval("RollNo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <HeaderTemplate>Student Name</HeaderTemplate>
                                <ItemTemplate>
                <asp:Label ID="lblStuName" runat="server" Text='<%# Eval("StuName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>Present or Absent</HeaderTemplate>
                                <ItemTemplate>
                <asp:HiddenField ID="hdnStudentId" runat="server" Value='<%# Eval("StudentId") %>' />
                                    <asp:CheckBox ID="chkIsAttend" runat="server" Checked="True" />
                                </ItemTemplate>
                            </asp:TemplateField>

                          </Columns>
                    </asp:GridView>
                </div>
                 <div class="col-md-2 mt-1">
                    <label>&nbsp;</label>
                    <asp:Button ID="btnSave" CssClass="btn btn-primary form-control" runat="server" Text="Submit" OnClick="btnSubmit_Click"  />
                </div>

            </div>
        </div>
        </div>
        </div>
    </div>
</asp:Content>
