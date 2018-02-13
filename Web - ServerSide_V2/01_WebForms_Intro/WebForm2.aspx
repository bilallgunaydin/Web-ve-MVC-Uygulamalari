<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="_01_WebForms_Intro.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #clock{
            width:80%;
            margin:auto;
            text-align:center;
            height:200px;
            line-height:200px;
            color:red;
            background-color:darkturquoise;
            
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="clock">
    <%--İlk web Formum<br />
        <span> 10 Ekim 2016 08:05:59 </span><br />
        <% =DateTime.Now %>--%>
         <span> <%= DateTime.Now.ToString("G", System.Globalization.CultureInfo.GetCultureInfo("fr-FR")) %> </span>
    </div>
    </form>
</body>
</html>
