<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default2.aspx.cs" Inherits="_01_WebForms_Intro.Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        #result {
            min-height: 50px;
            background-color: lightgray;
            border: 1px solid gray;
            font-size: 20px;
            font-weight: bold;
            text-align: center;
            border-radius: 5px;
        }
        #area{
            width:60%;
            margin:auto;
            padding:5%;
            box-sizing:border-box;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="area">

            <label>Listelenecek ürünlerin stok aralığını giriniz: </label>
            <input id="firstNumber" runat="server" class="form-control" type="text" value="" placeholder="İlk sayı..." /><br />
            <input id="secondNumber" runat="server" class="form-control" type="text" value="" placeholder="İkinci sayı..."/><br />
              <select id="categoryList" runat="server" class="form-control"></select>
            <button type="button" id="btnRun" runat="server" class="btn btn-primary center-block" onserverclick="btnRunClick">Üret</button><br />
            <br />
            <div id="result" runat="server">

            </div>

<%--            <div id="result" runat="server">
                <div class="col-md-6">
                    Sayı adedi: <span runat="server" id="count"></span>
                </div>
                <div class="col-md-6">
                    Random Sayı: <span runat="server" id="newResult"></span>
                </div>

            </div>--%>
        </div>
    </form>


    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</body>
</html>
