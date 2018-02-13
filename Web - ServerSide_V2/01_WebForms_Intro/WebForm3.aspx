<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="_01_WebForms_Intro.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 377px">
    
        <asp:TextBox ID="TextBox1" runat="server" Height="30px" OnTextChanged="TextBox1_TextChanged" style="margin-left: 368px; margin-right: 2px; margin-top: 161px" Width="216px"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Height="26px" OnTextChanged="TextBox2_TextChanged" style="margin-left: 368px; margin-right: 0px; margin-top: 0px; margin-bottom: 5px" Width="213px"></asp:TextBox>
        <br />
        <br />
        <asp:TextBox ID="TextBox3" runat="server" Height="30px" style="margin-left: 370px" Width="210px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" style="margin-left: 455px" Text="Button" />
        
        <asp:Button ID="Button2" runat="server" Text="Button" />
        <button id="Button_html" runat="server"></button>
        <input type="button" id="Button_input" runat="server"/>

        <script src="Scripts/jquery-1.9.1.js"></script>
        <script src="Scripts/jquery-1.9.1.min.js"></script>
    </div>
    </form>
</body>
</html>
