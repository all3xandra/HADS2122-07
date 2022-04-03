<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="Presentacion.Profesor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="Tareas" runat="server" NavigateUrl="~/GestionTareas.aspx">Tareas</asp:HyperLink>
        </div>
        <div>
            <p style="border-style: solid; border-width: thin; margin-left: 40px; background-color: #669999;">
                <br />
&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="http://hads22-07.azurewebsites.net/VerEstadisticas.aspx">Ver Estadísticas</asp:HyperLink>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Importar XML</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Exportar.aspx.cs">Exportar</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton3" runat="server">Importar DS</asp:LinkButton>
            </p>
            <p style="border-style: solid; border-width: thin; margin-left: 40px; background-color: #999999; font-weight: bold;">
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                Gestión Web de Tareas - Dedicación<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Profesores</p>
            <p style="margin-left: 40px">
                &nbsp;</p>
        </div>
    </form>
</body>
</html>
