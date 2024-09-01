<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="LMS_v1.Views.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% var user = (LMS_v1.Models.User)Session["user"]; %>
    <div class="row container-fluid">
        <div class="col-12">
            <h2>Profile</h2>
        </div>
        <div class="col-12 ">
            <div class="card">
                <div class="card-body row">
                    <div class="col-4">
                        <% if(user.profileUrl != "") {  %>
                        <img src="/uploads/profiles/<%= user.profileUrl %>" class="card-img" alt="Profile Picture" />
                        <div class="input-group mt-1">
                            <asp:FileUpload ID="filePP" accept=".jpg,.jepg,.png" runat="server" CssClass="form-control" />
                            <asp:Button ID="btnChangePP" runat="server" Text="ChangeProfile" OnClick="ChangeProfile" CssClass="btn btn-primary input-group-text" />
                        </div>
                        <% } else { %>
                        <img src="https://via.placeholder.com/150" class="img-fluid" alt="Profile Picture" />
                        <div class="input-group mt-1">
                            <asp:FileUpload ID="fileProfile" accept=".jpg,.jepg,.png" runat="server" CssClass="form-control" />
                            <asp:Button ID="btnUploadProfile" runat="server" Text="Upload" OnClick="UpdateProfile" CssClass="btn btn-primary input-group-text" />
                        </div>
                        <% } %>
                    </div>
                    <div class="col-8">
                        <div class="row">
                            <div class="col-12">
                                <h5>Personal Information</h5>
                            </div>
                            <div class="col-12">
                                <p>Name: <%= user.fullname %></p>
                            </div>
                            <div class="col-12">
                                <p>Email: <%= user.email %></p>
                            </div>
                            <div class="col-12">
                                <% if(user.phone == "") { %>
                                <p>Phone: Not Provided</p>
                                <div class="input-group">
                                    <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" TextMode="Phone" placeholder="Enter Phone Number"></asp:TextBox>
                                    <asp:Button ID="btnUpdatePhone" runat="server" Text="Update" OnClick="AddPhone" CssClass="btn btn-primary" />
                                </div>
                                <% } else { %>
                                <p>Phone: <%= user.phone %></p>
                                <% } %>
                            </div>
                            <div class="col-12">
                                <% int level = Convert.ToInt32(user.planID); switch(level) {  %>
                                <% case 1: %>
                                <p>Plan: <span class="text-secondary">Free</span></p>
                                <button class="btn btn-primary" type="button" data-bs-toggle="modal" data-bs-target="#upgradeModel">Upgrade</button>
                                <% break; %>
                                <% case 2: %>
                                <p>Plan: <span style="color:lightblue">Basic</span></p>
                                <button class="btn btn-primary" type="button" data-bs-toggle="modal" data-bs-target="#upgradeModel">Upgrade</button>
                                <% break; %>
                                <% case 3: %>
                                <p>Plan: <span style="color:silver">Standard</span></p>
                                <button class="btn btn-primary" type="button" data-bs-toggle="modal" data-bs-target="#upgradeModel">Upgrade</button>
                                <% break; %>
                                <% case 4: %>
                                <p>Plan: <span style="color:goldenrod">Premium</span></p>
                                <button class="btn btn-primary" type="button" data-bs-toggle="modal" data-bs-target="#upgradeModel">Upgrade</button>
                                <% break; %>
                                <% case 5: %>
                                <p>Plan: <span style="color:gold">Unlimited</span></p>
                                <% break; %>
                                <% default: %>
                                <p>Plan: <span class="text-secondary">Free</span></p>
                                <button class="btn btn-primary" type="button" data-bs-toggle="modal" data-bs-target="#upgradeModel">Upgrade</button>
                                <% break; %>
                                <% } %>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-12">
            <div class="card">
                <div class="card-body">
                    <asp:Label ID="lblError" CssClass="text-danger" runat="server"></asp:Label>
                    <div class="input-group">
                        <asp:TextBox ID="txtOldPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Old Password"></asp:TextBox>
                        <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="New Password"></asp:TextBox>
                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
                        <asp:Button ID="btnChangePassword" runat="server" Text="Change Password"  CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
