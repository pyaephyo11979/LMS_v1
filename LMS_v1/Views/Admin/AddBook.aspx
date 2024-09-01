<%@ Page Title="AddBook" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddBook.aspx.cs" Inherits="LMS_v1.Views.Admin.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div>
            <h2>Add Book</h2>
            <div class="container">
                <div>
                    <h4>Enter Book Name</h4>
                    <asp:TextBox ID="txtBookName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div>
                    <h4>Enter Book's Description</h4>
                    <asp:TextBox ID="txtBookDescription" TextMode="MultiLine" Rows="5" ToolTip="Enter Book Description" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div>
                    <h4>Enter Author Name</h4>
                    <asp:TextBox ID="txtAuthorName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div>
                    <h4>Choose Cateogry</h4>
                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div>
                    <h4>Choose Book Cover</h4>
                    <asp:FileUpload ID="fuBookCover" accept=".jpg,.jepg,.png"  runat="server" CssClass="form-control" />
                </div>
                <div>
                    <h4>Choose Book File</h4>
                    <asp:FileUpload ID="fuBookFile" runat="server" accept=".pdf,.epub" CssClass="form-control" />
                </div>
                <div class="mt-2">
                    <asp:Button ID="btnAddBook" runat="server" Text="Add Book" CssClass="btn btn-primary" OnClick="Add" />
                </div>
            </div>
        </div>
</asp:Content>
