<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertarTareaGenerica.aspx.cs" Inherits="Presentacion.InsertarTareaGenerica" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="PROFESOR"></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="GESTIÓN DE TAREAS GENÉRICAS"></asp:Label>
            </asp:Panel>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Código:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox_Cod" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_Cod" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Descripción:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox_Descripcion" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_Descripcion" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Asignatura:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="DropDownList3" runat="server" DataSourceID="SqlDataSource1" DataTextField="codigoAsig" DataValueField="codigoAsig" style="margin-left: 0px">
            </asp:DropDownList>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="DropDownList3" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-07ConnectionString %>" SelectCommand="SELECT DISTINCT GrupoClase.codigoAsig FROM ProfesorGrupo INNER JOIN GrupoClase ON ProfesorGrupo.codigoGrupo = GrupoClase.codigo AND ProfesorGrupo.email = @email">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
&nbsp;<br />
            <asp:Label ID="Label6" runat="server" Text="Horas Estimadas:"></asp:Label>
&nbsp;&nbsp;
            <asp:TextBox ID="TextBox_horasEstimada" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox_horasEstimada" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox_horasEstimada" ErrorMessage="¡Formato dígito!" ForeColor="Red" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="Label7" runat="server" Text="Tipo Tarea:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList2" runat="server" DataSourceID="SqlDataSource2" DataTextField="tipoTarea" DataValueField="tipoTarea" AutoPostBack="True">
            </asp:DropDownList>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="DropDownList2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-07ConnectionString %>" SelectCommand="SELECT DISTINCT [tipoTarea] FROM [TareaGenerica]"></asp:SqlDataSource>
            <br />
            <br />
            <br />
            <asp:Label ID="agregar" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button_addTarea" runat="server" Text="Añadir Tarea" Width="182px" OnClick="Button_addTarea_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink_VerTarea" runat="server" NavigateUrl="~/GestionTareas.aspx">Ver Tareas</asp:HyperLink>
            <br />
        </div>
    </form>
</body>
</html>
