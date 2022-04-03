<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CambiarPassword.aspx.cs" Inherits="Presentacion.CambiarPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Email:
            <asp:TextBox ID="correo_text" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="correo_text" ErrorMessage="¡Correo no válido!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br />
            <br />
            <asp:Button ID="solicitar" runat="server" OnClick="Button1_Click" Text="Solicitar cambio contraseña" />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Introduce la clave recibida:"></asp:Label>
&nbsp;<asp:TextBox ID="clave_text" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="prueba3" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="confirmar" runat="server" OnClick="confirmar_Click" Text="Confirmar" />
            &nbsp;&nbsp;&nbsp;
            <asp:Label ID="prueba" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Introduce nueva contraseña:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="nueva" runat="server" ReadOnly="True" style="margin-left: 0px" OnTextChanged="nueva_TextChanged" TextMode="Password"></asp:TextBox>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nueva" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Repite nueva contraseña:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="nueva2" runat="server" ReadOnly="True" style="margin-left: 3px" Width="122px" TextMode="Password"></asp:TextBox>
&nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="nueva2" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="nueva" ControlToValidate="nueva2" ErrorMessage="¡Las contraseñas no coinciden!"></asp:CompareValidator>
            <br />
            <br />
            <asp:Button ID="cambiar" runat="server" OnClick="cambiar_Click" Text="Cambiar contraseña" />
&nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Volver" Width="188px" />
            <br />
&nbsp;<asp:Label ID="prueba2" runat="server"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
