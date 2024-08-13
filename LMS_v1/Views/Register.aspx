<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LMS_v1.Views.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <div class="container">
            <div class="mb-2">
                <h2>Register</h2>
                <h5>Please Register to access books on this site</h5>
            </div>
            <div class="card m-auto" aria-flowto="center" style="width:350px; height:auto;">
                <div class="card-body p-auto">
                    <div class="container-fluid">
                     <div class="mt-2">
                        <label class="form-label">Enter Your UserName</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtUserName" ></asp:TextBox>
                         <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ID="valUSName" ErrorMessage="Please Enter Username" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                    </div>
                     <div class="mt-2">
                        <label class="form-label">Enter Your Name</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtName" ></asp:TextBox>
                         <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ID="valName" ErrorMessage="Please Enter Your Full Name" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                    </div>
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
                        <hr />
                        <asp:Button ID="btnRegister"  CssClass="btn btn-outline-dark" runat="server" Text="Registers" />
                    </div>
                    <div class="mt-2">
                       <p>Already have an account, <a runat="server" class="text-decoration-none text-black d-inline" href="~/login">Login Here</a></p>
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
