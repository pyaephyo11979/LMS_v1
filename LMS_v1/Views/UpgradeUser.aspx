<%@ Page Title="Upgrade Subscription" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpgradeUser.aspx.cs" Inherits="LMS_v1.Views.UpgradeUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% var user = (LMS_v1.Models.User)Session["user"]; %>
    <div class="container-fluid">
        <div class="card m-auto">
            <div class="card-header">
                <h4 style="color:maroon;">Choose Your Payment Method</h4>
            </div>
            <div class="card-body">
                <div class="mt-1">
                    <label class="form-label">Enter Your Name</label>
                    <asp:TextBox ID="txtName" placeholder="Enter Your Name"  runat="server" Text="" CssClass="form-control"></asp:TextBox>
                </div>
                <a class="text-decoration-none d-block text-dark mt-1" data-bs-toggle="collapse" href="#colCard">Visa/Master <i class="fas fa-credit-card"></i></a>
                <div class="collapse" id="colCard">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                            <div class="col-6">
                            <div class="mt-1">
                                <label class="form-label">Enter Card Number</label>
                                <asp:TextBox ID="txtCardNumber"  placeholder="1234 5678 8765 0443"  runat="server"  CssClass="form-control"></asp:TextBox>
                            </div>
                            </div>
                            <div class="col-6">
                            <div class="mt-1">
                                <label class="form-label">Enter Name on the Card</label>
                                <asp:TextBox ID="txtNameOnCard" placeholder="Ex. Joe Septh"  runat="server"  CssClass="form-control"></asp:TextBox>
                            </div>
                            </div>
                                <div class="col-6">
                                    <div class="mt-1">
                                        <label class="form-label">Enter CVV </label>
                                        <asp:TextBox ID="txtCVV" placeholder="৹ ৹ ৹"  runat="server"  CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-6">
                                    <div class="mt-1">
                                        <label class="form-label">Choose Expire Date </label>
                                        <%--<input type="date" class="form-control" id="expDate" />--%>
                                        <asp:TextBox ID="txtDate" runat="server" TextMode="Date" CssClass="form-control" ></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-12">
                                    <div class="mt-2">
                                        <asp:LinkButton ID="btnProceed1" CssClass="btn btn-success" OnClick="Upgrade" runat="server">
                                            Procceed Payment <i class="fas fa-credit-card"></i>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                       </div>
                    </div>
                </div>
                <a class="text-decoration-none d-block text-dark mt-1" data-bs-toggle="collapse" href="#colMobile">Mobile Payment <i class="fas fa-mobile-phone"></i></a>
                <div class="collapse" id="colMobile">
                    <div class="card">
                        <div class="card-body">
                        <div class="mt-1">
                            <h4>Choose Your Payment Method</h4>
                            <asp:RadioButtonList ID="rdbPayment"  CssClass="" runat="server">
                                <asp:ListItem>Kpay</asp:ListItem>
                                <asp:ListItem>Wave</asp:ListItem>
                                <asp:ListItem>AYA Pay</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="mt-1">
                            <label class="form-label">Enter Your Phone Number</label>
                            <asp:TextBox runat="server" ID="txtPh" placeholder="09XXXXXXXXX" TextMode="Phone" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mt-2">
                            <asp:LinkButton ID="btnOne" CssClass="btn btn-success" OnClick="Upgrade" runat="server">
                                 Procceed Payment <i class="fas fa-credit-card"></i>
                            </asp:LinkButton>                            
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        </div>
</asp:Content>
