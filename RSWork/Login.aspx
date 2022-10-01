<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RSWork.Login" %>




<asp:Content ID="formLogin" ContentPlaceHolderID="MainContent" runat="server" >

<link href="Content/Login.css" rel="stylesheet" />

    <div class="contenedor" id ="login">
        <asp:Image runat="server" id="logohome" src="/img/logo/7475095913_5857cb8d-0fb5-4261-807a-3c597f89a1b2.png" alt="RSWork Logo" style="width: 200px; height: 100px" />
        <input type="text" name="txtUsuario" value="Usuario" />
        <input type="text" name="txtContraseña" value="Contraseña" />
        <div>
            <input type="checkbox"  name="CheckboxRecordarme" value="" /><p>Recordarme en este equipo</p>
        </div>
        <asp:Button Class= "button" ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />
    </div>
    <%--  --%>
</asp:Content>
