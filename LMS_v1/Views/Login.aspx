<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LMS_v1.Views.Login" %>
<asp:Content ID="ct2" ContentPlaceHolderID="header" runat="server">

</asp:Content>
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
                                <% if(errmsg != null) {  %>
                                <div class="alert alert-danger" role="alert">
                                        <%= errmsg %>
                                    <button class="btn btn-close" data-bs-dismiss="alert"></button>
                                    </div>
                                <% } %>
                        </div>
                    <div class="mt-2">
                        <label class="form-label">Enter Your Username or Email</label>
                        <asp:TextBox ID="txtEmail" placeholder="Username or Email" runat="server"  CssClass="form-control" ToolTip="Enter your username or email address" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqfv" runat="server" ErrorMessage="Please Enter Your username or Email" ControlToValidate="txtEmail" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <div class="mt-2">
                        <label class="form-label">Enter Password</label>
                        <asp:TextBox ID="txtPsw" placeholder="Password" runat="server" TextMode="Password" CssClass="form-control" ></asp:TextBox>
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
