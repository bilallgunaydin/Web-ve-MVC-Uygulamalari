<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Site1.Master"
    AutoEventWireup="true"
    CodeBehind="CategoryEditForm.aspx.cs"
    Inherits="_02_WebForm_Uygulama.CategoryEditForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-10 col-md-offset-1">
        <h2>Yeni Kategori</h2>
        <div class="form-group">
            <asp:Label AssociatedControlID="txtCategoryName" ID="lblCategoryName" Text="Kategori Adı : " runat="server"></asp:Label>
            <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Label AssociatedControlID="txtDescription" ID="lblDescription" Text="Kategori Adı : " runat="server"></asp:Label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div class="form-group">
            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Kaydet" CssClass="btn btn-primary" />
        </div>
    </div>
</asp:Content>
