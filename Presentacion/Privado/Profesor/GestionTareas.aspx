<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionTareas.aspx.cs" Inherits="Presentacion.GestionTareas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 433px">
    <form id="form1" runat="server">
        <div style="height: 425px">
            <br />
            <asp:Panel ID="Panel1" runat="server">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="PROFESOR"></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server" Text="GESTIÓN DE TAREAS GENERICAS"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click" PostBackUrl="http://hads22-07.azurewebsites.net/Inicio.aspx">Cerrar Sesión</asp:LinkButton>
            </asp:Panel>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Seleccionar Asignatura:"></asp:Label>
            <br />
            <asp:DropDownList ID="listAsignaturas" runat="server" Height="16px" Width="134px" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="codigoAsig" DataValueField="codigoAsig">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HADS22-07ConnectionString %>" SelectCommand="SELECT DISTINCT GrupoClase.codigoAsig FROM ProfesorGrupo INNER JOIN GrupoClase ON ProfesorGrupo.codigoGrupo = GrupoClase.codigo AND ProfesorGrupo.email = @email">
                <SelectParameters>
                    <asp:SessionParameter Name="email" SessionField="email" />
                </SelectParameters>
            </asp:SqlDataSource>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Insertar Nueva Tarea" Width="299px" PostBackUrl="http://hads22-07.azurewebsites.net/InsertarTareaGenerica.aspx" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Height="62px" DataKeyNames="codigo" DataSourceID="SqlDataSource2">
                <Columns>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:BoundField HeaderText="Codigo" ReadOnly="True" DataField="codigo" SortExpression="codigo" />
                    <asp:BoundField HeaderText="Descripcion" DataField="descripcion" SortExpression="descripcion" />
                    <asp:BoundField HeaderText="CodAsig" DataField="codAsig" SortExpression="codAsig" />
                    <asp:BoundField HeaderText="HEstimadas" DataField="hEstimadas" SortExpression="hEstimadas" />
                    <asp:CheckBoxField HeaderText="Explotacion" DataField="explotacion" SortExpression="explotacion" />
                    <asp:BoundField HeaderText="TipoTarea" DataField="tipoTarea" SortExpression="tipoTarea" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:HADS22-07ConnectionString %>" DeleteCommand="DELETE FROM [TareaGenerica] WHERE [codigo] = @original_codigo AND (([descripcion] = @original_descripcion) OR ([descripcion] IS NULL AND @original_descripcion IS NULL)) AND (([codAsig] = @original_codAsig) OR ([codAsig] IS NULL AND @original_codAsig IS NULL)) AND (([hEstimadas] = @original_hEstimadas) OR ([hEstimadas] IS NULL AND @original_hEstimadas IS NULL)) AND (([explotacion] = @original_explotacion) OR ([explotacion] IS NULL AND @original_explotacion IS NULL)) AND (([tipoTarea] = @original_tipoTarea) OR ([tipoTarea] IS NULL AND @original_tipoTarea IS NULL))" InsertCommand="INSERT INTO [TareaGenerica] ([codigo], [descripcion], [codAsig], [hEstimadas], [explotacion], [tipoTarea]) VALUES (@codigo, @descripcion, @codAsig, @hEstimadas, @explotacion, @tipoTarea)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [TareaGenerica] WHERE ([codAsig] = @codAsig)" UpdateCommand="UPDATE [TareaGenerica] SET [descripcion] = @descripcion, [codAsig] = @codAsig, [hEstimadas] = @hEstimadas, [explotacion] = @explotacion, [tipoTarea] = @tipoTarea WHERE [codigo] = @original_codigo AND (([descripcion] = @original_descripcion) OR ([descripcion] IS NULL AND @original_descripcion IS NULL)) AND (([codAsig] = @original_codAsig) OR ([codAsig] IS NULL AND @original_codAsig IS NULL)) AND (([hEstimadas] = @original_hEstimadas) OR ([hEstimadas] IS NULL AND @original_hEstimadas IS NULL)) AND (([explotacion] = @original_explotacion) OR ([explotacion] IS NULL AND @original_explotacion IS NULL)) AND (([tipoTarea] = @original_tipoTarea) OR ([tipoTarea] IS NULL AND @original_tipoTarea IS NULL))">
                <DeleteParameters>
                    <asp:Parameter Name="original_codigo" Type="String" />
                    <asp:Parameter Name="original_descripcion" Type="String" />
                    <asp:Parameter Name="original_codAsig" Type="String" />
                    <asp:Parameter Name="original_hEstimadas" Type="Int32" />
                    <asp:Parameter Name="original_explotacion" Type="Boolean" />
                    <asp:Parameter Name="original_tipoTarea" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="codigo" Type="String" />
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="codAsig" Type="String" />
                    <asp:Parameter Name="hEstimadas" Type="Int32" />
                    <asp:Parameter Name="explotacion" Type="Boolean" />
                    <asp:Parameter Name="tipoTarea" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="listAsignaturas" Name="codAsig" PropertyName="SelectedValue" Type="String" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="descripcion" Type="String" />
                    <asp:Parameter Name="codAsig" Type="String" />
                    <asp:Parameter Name="hEstimadas" Type="Int32" />
                    <asp:Parameter Name="explotacion" Type="Boolean" />
                    <asp:Parameter Name="tipoTarea" Type="String" />
                    <asp:Parameter Name="original_codigo" Type="String" />
                    <asp:Parameter Name="original_descripcion" Type="String" />
                    <asp:Parameter Name="original_codAsig" Type="String" />
                    <asp:Parameter Name="original_hEstimadas" Type="Int32" />
                    <asp:Parameter Name="original_explotacion" Type="Boolean" />
                    <asp:Parameter Name="original_tipoTarea" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Volver" />
            <br />
        </div>
    </form>
</body>
</html>
