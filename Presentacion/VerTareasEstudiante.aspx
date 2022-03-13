<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerTareasEstudiante.aspx.cs" Inherits="Presentacion.VerTareasEstudiante" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Inicio.aspx">Cerrar Sesión</asp:HyperLink>
&nbsp;&nbsp;&nbsp; 
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ALUMNOS<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; GESTIÓN DE TAREAS GENÉRICAS<br />
        </div>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Seleccionar Asignatura. Sólo se muestran aquellas en las que está matriculado:"></asp:Label>
        <br />
        <br />
        <asp:DropDownList ID="asignaturas_ddl" runat="server" Height="16px" OnSelectedIndexChanged="asignaturas_ddl_SelectedIndexChanged" Width="104px" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
        <br />
        <br />
    </form>
</body>
</html>
