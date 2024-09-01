<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="LMS_v1.Views.Admin.ManageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div calss="container-fluid">
        <div class="row">
            <div class="col-4">
                <h4>Manage User</h4>
            </div>
            <div class="col-8 row ">
                <div class="col-9">
                <div class="input-group ">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search Books"></asp:TextBox>
                    <asp:LinkButton ID="btnsearch" runat="server" CssClass="btn btn-info" Text="" OnClick="searchBook" ><i class='fas fa-search'></i></asp:LinkButton>
                </div>
                    </div>
            </div>
            <div class="col-12 mt-2">
                <div class="card">
                    <div class="card-body">
                        <asp:Table CssClass="table table-bordered" runat="server" ID="userTable">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell>Username</asp:TableHeaderCell>
                                <asp:TableHeaderCell>FullName</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Phone</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Subscription Level</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Stauts</asp:TableHeaderCell>
                                <asp:TableHeaderCell>PlanID</asp:TableHeaderCell>
                                <asp:TableHeaderCell>SubscriptionEndDate</asp:TableHeaderCell>
                                <asp:TableHeaderCell>LastActive</asp:TableHeaderCell>
                                <asp:TableHeaderCell ColumnSpan="2">Actions</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
