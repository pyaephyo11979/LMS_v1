<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LMS_v1.Views.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container" runat="server">
            <div class="mb-2">
                <h2>Login</h2>
                <h5>Please Login to access books on this site</h5>
            </div>
            <div class="card m-auto" aria-flowto="center" style="width:350px; height:330px;">
                <div class="card-body p-auto">
                    <div class="container-fluid">
                    <div class="mt-2">
                        <label class="form-label">Enter Your Email</label>
                        <asp:TextBox ID="txtEmail"  runat="server" TextMode="Email" CssClass="form-control" ToolTip="Enter yor email address" ></asp:TextBox>
                        <asp:RegularExpressionValidator ControlToValidate="txtEmail" ID="regValidatorEmailLogin" ErrorMessage="Please Enter valid Email" ForeColor="Red" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                    <div class="mt-2">
                        <label class="form-label">Enter Password</label>
                        <asp:TextBox ID="txtPsw" runat="server" TextMode="Password" CssClass="form-control" ></asp:TextBox>
                    </div>
                    <div class="mt-3">
                        <asp:Button ID="btnLogin"  CssClass="btn btn-outline-dark" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    </div>
                        <div class="mt-2">
                            <p>If you didn't have an account yet, <a runat="server" class="text-decoration-none text-black d-inline" href="~/register">Register Here</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
