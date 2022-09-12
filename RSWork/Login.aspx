<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RSWork.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>RS Work - Login</title>
    <link href="css/base.css" rel="stylesheet" />
</head>
<body>
    <form id="formLogin" method="post" runat="server">
        <div>
            <img id="logohome" src="img/logo/7475095913_5857cb8d-0fb5-4261-807a-3c597f89a1b2.png" alt="RSWork Logo" style="width: 200px; height: 100px" />
            <asp:TextBox ID="txtUsuario" runat="server">Nombre de Usuario</asp:TextBox>
            <asp:TextBox ID="txtContraseña" runat="server">Contraseña</asp:TextBox>
            <div>
                <asp:CheckBox ID="CheckBoxRecordarme" runat="server" /><p>Recordarme en este equipo</p>
                
            </div>
            <asp:Button ID="BtnLogin" Text="Login" runat="server" />
        </div>
    </form>
</body>
</html>
