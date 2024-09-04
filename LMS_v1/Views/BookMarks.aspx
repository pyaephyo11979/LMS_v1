<%@ Page Title="BookMark" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookMarks.aspx.cs" Inherits="LMS_v1.Views.BookMarks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="header" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="conatiner">
        <div class="row">
            <div class="col-5">
                <h4>BookMarks <i class="fas fa-bookmark"></i></h4>
            </div>
            <div class="col-12 mt-1">
                <asp:Table ID="tbBookMarks" runat="server" CssClass="table table-striped-columns">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell></asp:TableHeaderCell>
                        <asp:TableHeaderCell>Title</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Author</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Category</asp:TableHeaderCell>
                        <asp:TableHeaderCell ColumnSpan="2">Actions</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
    </div>
</asp:Content>
