<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerEstadisticas.aspx.cs" Inherits="Presentacion.VerEstadisticas" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-size: 20px; color: #0033CC">
            Estadísticas de horas estimadas/reales realizadas por estudiante</div>
        <br />
        Selecciona un estudiante:<br />
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="email" DataValueField="email">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-07ConnectionString %>" SelectCommand="SELECT DISTINCT [email] FROM [Usuarios] WHERE ([tipo] = @tipo)">
            <SelectParameters>
                <asp:Parameter DefaultValue="Alumno" Name="tipo" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Label ID="Label1" runat="server" ForeColor="#000066" Text="Horas estimadas:"></asp:Label>
        <br />
        <asp:Chart ID="Chart2" runat="server" DataSourceID="SqlDataSource2">
            <series>
                <asp:Series Name="Series1" XValueMember="codTarea" YValueMembers="hEstimadas">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-07ConnectionString %>" SelectCommand="SELECT DISTINCT [codTarea], [hEstimadas] FROM [EstudianteTarea] WHERE ([email] = @email)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="email" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Label ID="Label2" runat="server" ForeColor="#000066" Text="Horas reales:"></asp:Label>
        <br />
        <asp:Chart ID="Chart3" runat="server" DataSourceID="SqlDataSource3">
            <series>
                <asp:Series Name="Series1" XValueMember="codTarea" YValueMembers="hReales">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-07ConnectionString %>" SelectCommand="SELECT [codTarea], [hReales] FROM [EstudianteTarea] WHERE ([email] = @email)">
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="email" PropertyName="SelectedValue" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Volver" />
        <br />
    </form>
</body>
</html>
