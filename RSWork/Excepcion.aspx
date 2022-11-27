<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="Excepcion.aspx.cs" Title="Excepcion" Inherits="RSWork.Excepcion" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Excepcion" ContentPlaceHolderID ="MainContent" runat="server">

    
    <article class="contenedor">

        <asp:Image runat="server" id="logoOops" src="/img/logo/Oops.png" alt="Oops Image" style="width: 40%; height: 20%" />
        <p>Ha habido un problema, por favor contacta al administrador y muestrale el siguiente error.</p>

        <asp:Label id="TipoLabel" runat="server" Text=""></asp:Label>
        <p></p>
        <asp:Label id="TimeStampLabel" runat="server" Text=""></asp:Label>
        <p></p>
        <asp:Label id="MessageLabel" runat="server" Text=""></asp:Label>
        <p></p>
        <asp:Label id="StackTraceLabel" runat="server" Text=""></asp:Label>
        <p></p>
        <asp:Label id="SourceLabel" runat="server" Text=""></asp:Label>
      

    </article>



</asp:Content>