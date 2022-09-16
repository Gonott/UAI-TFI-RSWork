<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RSWork.Login" %>


<asp:Content ID="formLogin" ContentPlaceHolderID="MainContent" runat="server" method="post">

    <Article>
        <asp:Image runat="server" id="logohome" src="/img/logo/7475095913_5857cb8d-0fb5-4261-807a-3c597f89a1b2.png" alt="RSWork Logo" style="width: 200px; height: 100px" />
        <input type="text" name="txtUsuario" value="Usuario" />
        <input type="text" name="txtContraseña" value="Contraseña" />
        <div>
            <input type="checkbox"  name="CheckboxRecordarme" value="" /><p>Recordarme en este equipo</p>
        </div>
        <input type="button"  name="BtnLogin" value="Login" />
    </Article>

  
</asp:Content>
