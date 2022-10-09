<%@ Page Title="" Language="C#" MasterPageFile="~/AdminLayout/AdminMain.Master" AutoEventWireup="true" CodeBehind="ContactInfo.aspx.cs" Inherits="RealProjectB2.auth.ContactInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" >
        function chkNumber(cntId) {
            var val = document.getElementById(cntId).value;
            var mainC = document.getElementById(cntId);
            var chkDigit = /^\d*$/;
            if (chkDigit.test(val)) {
                mainC.style.backgroundColor = "white";
            }
            else {
                alert("Invalid Number");
                mainC.value = "";
                mainC.style.backgroundColor = "red";
            }
        }
    </script>


    <script type="text/javascript">
        
        function Numberchk(cntId) {
            var val = document.getElementById(cntId).value;
            var MainC = document.getElementById(cntId);
            var expDigit = /^\d*$/;
            if (expDigit.test(val)) {
                MainC.style.backgroundColor = "white";
            }
            else {
                
                MainC.style.backgroundColor = "#E6A0A0";
                alert("Invalid Numbe r.");
                MainC.value = "";

            }
        }
    </script>

   <script type="text/javascript">
       function chkInt(cntId) {
           var val = document.getElementById(cntId).value;
           var mainC = document.getElementById(cntId);
           var digit = /^\d*$/;
           if (digit.test(val)) {
               mainC.style.backgroundColor = "white";
           }
           else {
               mainC.style.backgroundColor = "#E6A0A0";
               alert("Input valid Number");
               mainC.value = "";
           }

       }
   </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
     <div class="d-sm-flex align-items-center justify-content-between mb-4">
        <asp:Label ID="lblHeading" CssClass="h3 mb-0 text-gray-800" runat="server" Text="Contact Info"></asp:Label>
        <%-- <h1 class="h3 mb-0 text-gray-800">Dashboard</h1>--%>
        <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary shadow-sm"><i
            class="fas fa-download fa-sm text-white-50"></i></a>
    </div>

    <div class="card">
        <div class="card-header bg-gradient-primary text-light">
            Add New Contact
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-6">
                    <label class="form-label">Name</label>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-6">
                    <label class="form-label">Contact No</label>
                    <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control"></asp:TextBox>
<asp:RegularExpressionValidator ID="revContact" runat="server" ControlToValidate="txtContactNo" CssClass="text-danger" ValidationExpression="(^([+]{1}[8]{2}|0088)?(01){1}[3-9]{1}\d{8})$" ErrorMessage="Invalid Contact No"></asp:RegularExpressionValidator>

                   <%-- <asp:RegularExpressionValidator ID="revContact" runat="server" ValidationExpression="(^([+]{1}[8]{2}|0088)?(01){1}[3-9]{1}\d{8})$" ControlToValidate="txtContactNo"  ErrorMessage="Number Formate Invalid"></asp:RegularExpressionValidator>--%>
                </div>
            </div>
             <div class="row">
                <div class="col-md-6">
                    <label class="form-label">Email</label>

                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>

<asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"  ErrorMessage="Invalid Email Format." CssClass="text-danger" ></asp:RegularExpressionValidator>

                    <%--<asp:RegularExpressionValidator ID="revEmal" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>--%>


                
                    </div>
                <div class="col-md-6">
                    <label class="form-label">Social</label>
                    <asp:TextBox ID="txtSocial" runat="server" CssClass="form-control"></asp:TextBox>

                </div>
            </div>
             <div class="row pt-3">
                <div class="col-md-10">
                   
                </div>
                <div class="col-md-2">

                    <asp:HiddenField ID="hdnEditCid" runat="server" />
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-success form-control" />
                </div>
            </div>

             <div class="row pt-3">
                <div class="col-md-12">
                    <asp:GridView ID="gvCon" runat="server" CssClass="table table-borderd table-striped" AutoGenerateColumns="False" OnRowCommand="gvCon_RowCommand">
                        <Columns>
                          
                            <asp:BoundField HeaderText="Name" DataField="Name"  />
                            <asp:BoundField HeaderText="Contact No" DataField="ContactNo" />
                            <asp:BoundField HeaderText="Email" DataField="Email" />
                            <asp:BoundField HeaderText="Social" DataField="Social" />
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    Action
                                </HeaderTemplate>
                                <ItemTemplate>
                                     <asp:HiddenField ID="hdncid" runat="server" Value='<%# Eval("Cid") %>' />

                                    <asp:ImageButton ID="imgEdit" runat="server" CommandName="editc" CommandArgument='<%#Container.DataItemIndex %>' ImageUrl="~/assets/img/R.png" Width="10px"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                
            </div>
        </div>
    </div>

</asp:Content>
