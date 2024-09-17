<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="LMS_v1.Views.Admin.ManageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <style>
       .mgm{
           background-color:#b3b3b3; 
       }
   </style>   
    
    <div calss="container">
        <div class="row">
            <div class="col-4">
                <h4>Manage Members</h4>
            </div>
            <div class="col-8 row ">
                <div class="col-9">
                <div class="input-group ">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search User"></asp:TextBox>
                    <asp:LinkButton ID="btnsearch" OnClick="SearchUser" runat="server" CssClass="btn btn-info" Text="" ><i class='fas fa-search'></i></asp:LinkButton>
                </div>
                    </div>
            </div>
            <div class="col-11 container ms-2 mt-2 ">
                        <asp:Table CssClass="table table-bordered mgm" runat="server" ID="userTable">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell>Username</asp:TableHeaderCell>
                                <asp:TableHeaderCell>FullName</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Email</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Stauts</asp:TableHeaderCell>
                                <asp:TableHeaderCell>PlanID</asp:TableHeaderCell>
                                <asp:TableHeaderCell>ExpireDate</asp:TableHeaderCell>
                                <asp:TableHeaderCell>LastActive</asp:TableHeaderCell>
                                <asp:TableHeaderCell ColumnSpan="2">Actions</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
        </div>
    </div>
</asp:Content>
