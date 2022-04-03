<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Presentacion.Inicio1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Inicio</title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label4" runat="server" Text="HADS22-07"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Italic="False" Text="Iniciar sesión"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="correo_text" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="correo_text" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="psw_text" runat="server" TextMode="Password"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="psw_text" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="invalidpw" runat="server"></asp:Label>
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Height="42px" Text="Login" Width="114px" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:LinkButton ID="quieroRegistrarme_link" runat="server" PostBackUrl="Registro.aspx">Quiero Registrarme</asp:LinkButton>
            <br />
            <asp:LinkButton ID="modPass_link" runat="server" PostBackUrl="CambiarPassword.aspx">Modificar Contraseña</asp:LinkButton>
            <br />
            <br />
            <asp:Label ID="error_login" runat="server"></asp:Label>
            <br />
            <asp:Button ID="enlace" runat="server" OnClick="enlace_Click" Text="Obtener enlace confirmación" Visible="False" />
            <br />
            <asp:Label ID="correo_enviado" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
