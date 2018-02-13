<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmployeeListForm(image).aspx.cs" Inherits="_02_WebForm_Uygulama.EmployeeListForm_image_" %>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
     <style>
        .EmployeeInfo {
            border: 1px solid black;
            padding: 5px;
            box-sizing: border-box;
            margin: 5px;
            width: 250px;
            min-height: 100px;
            text-align: center;
            line-height: 15px;
            float: left;
        }

            .EmployeeInfo:hover {
                box-shadow: 0 0 5px 5px silver;
                border-color: silver;
                cursor: pointer;
            }
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%for (int i = 0; i < _employeeList.Count; i++)
     {%>
    <div class="EmployeeInfo"></div>
          <%--<img src="/image.aspx?id=<%= _employeeList[i].EmployeeID %>" /><br />--%>
     <img src="<%= _employeeList[i].Photo == null ? "" : "data:Image/png;base64,"+Convert.ToBase64String(_employeeList[i].Photo.Skip(78).ToArray()) %>" /><br />

                Ad : <strong><%= _employeeList[i].FirstName %></strong><br />
                Soyad : <strong><%= _employeeList[i].LastName %></strong><br />
                Ünvan : <strong><%= _employeeList[i].Title %></strong><br />
                DT : <strong><%= _employeeList[i].BirthDate.HasValue ? _employeeList[i].BirthDate.Value.ToShortDateString() : "<data yok>" %></strong>
    <% } %>
</asp:Content>
