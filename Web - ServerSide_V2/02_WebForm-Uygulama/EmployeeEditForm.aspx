<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmployeeEditForm.aspx.cs" Inherits="_02_WebForm_Uygulama.EmployeeEditForm" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .btn {
            margin-top: 12px;
        }
    </style>
    <div class="col-md-12">
        <h2>Yeni Çalışan</h2>
        <div class="form-group">
            <asp:Label AssociatedControlID="txtFirstName" Text="Adı:" ID="lblFirstName" runat="server" />
            <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server" />
            <asp:Label AssociatedControlID="txtLastName" ID="lblLastName" Text="Soyadı:" runat="server" />
            <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server" />
            <asp:Button ID="btnSave" Text="Kaydet" CssClass="btn btn-danger " runat="server" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>
