<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LMS_v1.Views.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <div class="mb-2">
                <h2>Login</h2>
                <h5>Please Login to access books on this site</h5>
            </div>
            <div class="card m-auto" aria-flowto="center" style="width:300px; height:280px;">
                <div class="card-body p-auto">
                    <div class="container-fluid">
                    <div class="mt-2">
                        <label class="form-label">Enter Your Email</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" ></asp:TextBox>
                        <asp:RegularExpressionValidator ControlToValidate="txtEmail" ID="regValidatorEmailLogin" ErrorMessage="Please Enter valid Email" ForeColor="Red" runat="server" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>
                    <div class="mt-2">
                        <label class="form-label">Enter Password</label>
                        <asp:TextBox runat="server"  Width="" CssClass="form-control" ID="txtPsw" ></asp:TextBox>
                    </div>
                    <div class="mt-3">
                        <asp:Button ID="btnLogin"  CssClass="btn btn-outline-dark" runat="server" Text="Login" />
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
