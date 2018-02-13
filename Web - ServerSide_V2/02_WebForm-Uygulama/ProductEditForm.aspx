<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Site1.Master"
    AutoEventWireup="true"
    CodeBehind="ProductEditForm.aspx.cs"
    Inherits="_02_WebForm_Uygulama.ProductEditForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-10 col-md-offset-2">
        <h2>Yeni Ürün</h2>
        <div class="form-group">

            <asp:Label AssociatedControlID="txtProductName" ID="lblProductName" runat="server" Text="Ürün Adı : "></asp:Label>
            <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:Label AssociatedControlID="DropListCategoryName" Text="Kategori Adı:" runat="server" />
            <asp:DropDownList ID="DropListCategoryName" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>

            <asp:Label AssociatedControlID="txtQuantityPerUnit" ID="lblQuantityPerUnit" runat="server" Text="Birim miktarı : "></asp:Label>
            <asp:TextBox ID="txtQuantityPerUnit" CssClass="form-control" runat="server" />


            <asp:Label AssociatedControlID="txtUnitPrice" ID="lblUnitPrice" Text="Fiyatı : " runat="server"></asp:Label>
            <asp:TextBox ID="txtUnitPrice" CssClass="form-control" runat="server" />


            <asp:Label AssociatedControlID="txtUnitsInStock" ID="lblUnitsInStock" Text="Ürün Sayısı:" runat="server" />
            <asp:TextBox ID="txtUnitsInStock" CssClass="form-control" runat="server" />


            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" Text="Kaydet" CssClass="btn btn-primary" />

        </div>
    </div>
</asp:Content>
