<%@ Page Title=""
    Language="C#"
    MasterPageFile="~/Site1.Master"
    AutoEventWireup="true"
    CodeBehind="EmployeeListForm.aspx.cs"
    Inherits="_02_WebForm_Uygulama.EmployeeListForm" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .table {
            width: 700px;
        }

        .btn-group-sm {
            width: 50px;
            height: 50px;
            border-radius: 50%;
        }
    </style>

    <h4>Çalışan Listesi</h4>
    <div class="row">
        <div class="col-md-12">
            <div class="pull-right">
                <a href="EmployeeEditForm.aspx" class="btn btn-primary">çalışan ekle</a>
            </div>
            <table class="table table-bordered">

                <tr>

                    <td><b>Employee</b></td>
                    <td><b>LastName</b></td>
                    <td><b>FirstName</b></td>
                    <td><b>Düzenleme</b></td>
                </tr>
                <asp:Repeater ID="rptEmployee" runat="server">
                    <ItemTemplate>
                        <tr>

                            <td><%# Eval("EmployeeID") %></td>
                            <td><%# Eval("LastName") %></td>
                            <td><%# Eval("FirstName") %></td>
                            <td>
                                <asp:Button CssClass="btn btn-group-sm" ID="btnDelete" runat="server" Text="Sil" data-id='<%# Eval("EmployeeID") %>' OnClick="btnDelete_Click" />
                                <a class="btn btn-danger" href="EmployeeEditForm.aspx?id=<%# Eval("EmployeeID") %>">Düzenle</a>
                            </td>

                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </div>
    </div>

</asp:Content>
