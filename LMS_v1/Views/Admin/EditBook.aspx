<%@ Page Title="EditBook" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EditBook.aspx.cs" Inherits="LMS_v1.Views.Admin.EditBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-12">
                <h4>Edit Book</h4>
            </div>
            <div class="col-5">
                <asp:Image runat="server" ID="imgBookCover"  CssClass="img-fluid"/>
                <div class="input-group mt-1">
                    <asp:FileUpload ID="fileImg" runat="server" CssClass="form-control" />
                    <asp:Button ID="btnChangeImage" OnClick="UpdateCover" runat="server" CssClass=" btn btn-primary input-group-text"  Text="Change"/>
                </div> 
            </div>
            <div class="col-7">
                <h4>Title: <asp:Label runat="server" ID="lblTitle"></asp:Label></h4>
                <div class="input-group">
                    <asp:TextBox runat="server" ID="txtTitle" placeholer="Enter Book Title" CssClass="form-control" />
                    <asp:Button runat="server" OnClick="UpdateTitle" ID="btnUpdateTitle"  CssClass="btn btn-primary input-group-text" Text="UpdateTitle"/>
                </div>
                <h4>Author: <asp:Label runat="server" ID="lblAuthor"></asp:Label></h4>
                <div class="input-group">
                    <asp:TextBox runat="server" ID="txtAuthor" placeholer="Enter Author Name" CssClass="form-control" />
                    <asp:Button runat="server" OnClick="UpdateAuthor" ID="btnUpdateAuthor" CssClass="btn btn-primary input-group-text" Text="UpdateAuthor"/>
                    </div>
                <h4>Category: <asp:Label runat="server" ID="lblCategory"></asp:Label></h4>
                <div class="input-group">
                    <asp:DropDownList ID="ddlCtg" CssClass="form-control" runat="server"></asp:DropDownList>
                    <asp:Button runat="server" OnClick="UpdateCategory" ID="btnUpdateCategory" CssClass="btn btn-primary input-group-text" Text="UpdateCategory"/>
                    </div>
                <h5>Description: <asp:Label runat="server" ID="lblDescription"></asp:Label></h5>
                <div class="input-group">
                    <asp:TextBox runat="server" ID="txtDescription" placeholer="Enter Description" CssClass="form-control" TextMode="MultiLine" Rows="5" />
                    <asp:Button runat="server" OnClick="UpdateDescription" ID="btnUpdateDescription" CssClass="btn btn-primary input-group-text" Text="UpdateDescription"/>
                    </div>
            </div>
        </div>
    </div>
</asp:Content>
