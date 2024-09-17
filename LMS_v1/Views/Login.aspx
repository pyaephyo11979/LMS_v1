<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LMS_v1.Views.Login" %>
<asp:Content ID="ct2" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
        .btnlg{
             background-color:#d4ba91;
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
         .btnlg:hover {
     background-color: #ece3d4;
     color: maroon;
     box-shadow: 0 4px 15px rgba(0, 0, 0, 0.3);
 }

        .cbd {
            background-color: #f9f2ea;
        }
    </style>
    
    <main>
        <div class="container" runat="server">
            <div class="mb-2">
                <h2 style="text-align:center; color:maroon;">Login</h2>
                <h5 style="text-align:center; color:maroon;">Please Login to access books on this site</h5>
                
            </div>

            <div class="card m-auto" aria-flowto="center" style="width:350px; height:400px;">
                <div class="card-body p-auto cbd">
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
                        <asp:RequiredFieldValidator ID="reqfv1" runat="server" ErrorMessage="Please Enter Your Password" ControlToValidate="txtPsw" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                    <hr />
                    <div class="mt-3">
                        <asp:Button ID="btnLogin"  CssClass="btnlg" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    </div>
                        <div class="mt-2">
                            <p>If you didn't have an account yet, </p><a runat="server" class=" d-inline btnrg" style="color:maroon; font-weight:bold;" href="~/register">Register Here</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
