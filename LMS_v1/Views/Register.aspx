<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LMS_v1.Views.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <style>
                   .btnrg{
            background-color: #d4ba91;
color: maroon;
border-radius: 5px;
width: 80px;
height: 40px;
text-decoration: none;
font-size: 15px;
padding: 7px;
text-align: center;
margin: 2px;
border: 0px;
margin-left: 100px;
       }
        .btnrg:hover {
     background-color: #ece3d4;
 color: maroon;
 box-shadow: 0 4px 15px rgba(0, 0, 0, 0.3);
}
            .cccbd {
                background-color: #f9f2ea;
            }
        </style>
        <div class="container">
            <div class="mb-2">
                <h2 style="text-align:center; color:maroon;">Register</h2>
                <h5 style="text-align:center; color:maroon;">Please Register to access books on this site</h5>
            </div>
            <div class="card m-auto align-content-center" aria-flowto="center" style="width:350px; height:auto">
                <div class="card-body p-auto cccbd">
                    <div class="container-fluid">
                     <div class="mt-2">
                        <label class="form-label">Enter Your UserName</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtUserName" ></asp:TextBox>
                         <asp:RequiredFieldValidator runat="server" CssClass="text-danger" ID="valUSName" ErrorMessage="Please Enter Username" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                    </div>
                      <div class="mt-2">
                        <label class="form-label">Enter Your Full Name</label>
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
                        <asp:TextBox runat="server"  Width="" CssClass="form-control" TextMode="Password" ID="txtPsw" ></asp:TextBox>
                    </div>
                    <div class="mt-3">
                        <hr />
                        <asp:Button ID="btnRegister" OnClick="SignUp"  CssClass="btn btnrg" runat="server" Text="Register" />
                    </div>
                    <div class="mt-2">
                       <p>Already have an account? <a runat="server" class="d-inline" style="color:maroon; font-weight:bold;" href="~/login">Login Here</a></p>
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
