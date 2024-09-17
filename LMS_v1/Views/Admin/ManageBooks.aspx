<%@ Page Title="ManageBooks" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ManageBooks.aspx.cs" Inherits="LMS_v1.Views.Admin.ManageBooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .cbd{
            background-color:#b3b3b3; 
        }
    </style>
    
    <div calss="container ">
        <div class="row">
            <div class="col-4">
                <h4>Manage Books</h4>
            </div>
            <div class="col-8 row ">
                <div class="col-9">
                <div class="input-group ">
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search Books"></asp:TextBox>
                    <asp:LinkButton ID="btnsearch" runat="server" CssClass="btn btn-info" Text="" OnClick="searchBook" ><i class='fas fa-search'></i></asp:LinkButton>
                </div>
                    </div>
                <div class="col-3">
                <a href="~/admin/addbook" runat="server" class=" btn btn-dark">AddBook <i class="fas fa-plus"></i></a></div>
            </div>
            <div class="col-12 mt-2">
                <div class="card cbd  m-1">
                    <div class="card-body ">
                        <asp:Table CssClass="table table-bordered" runat="server" ID="bookTable">
                            <asp:TableHeaderRow>
                                <asp:TableHeaderCell></asp:TableHeaderCell>
                                <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                                <asp:TableHeaderCell>AuthorName</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Category</asp:TableHeaderCell>
                                <asp:TableHeaderCell></asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
