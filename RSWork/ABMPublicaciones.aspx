<%@ Page Title="ABM Publicaciones" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ABMPublicaciones.aspx.cs" Inherits="RSWork.ABMPublicaciones" %>



<asp:Content ID="ABMPublicaciones" ContentPlaceHolderID="MainContent" runat="server" method="post">

    <article>
        <h2>Publicación</h2>
        <p>Nombre de la Publicación  <asp:TextBox ID="TextBoxNombrePub" runat="server">Nombre</asp:TextBox>  </p>

        <div>
            <p>Seleccione un Elemento para la Publicación</p>
            <asp:ListBox runat="server">
                <asp:ListItem Text="text1" />
                <asp:ListItem Text="text2" />
            </asp:ListBox>
            <p>Cantidad Publicada: <asp:TextBox ID="TextBoxCantidad" runat="server">Cantidad</asp:TextBox></p>
        </div>

        <div>
            <div>
                <asp:Image ImageUrl="imageurl" runat="server" />
                <br />
                <asp:TextBox ID="TextBoxResumen" runat="server">Agregue un Resumen para mostrar</asp:TextBox>
            </div>
            <asp:FileUpload ID="FileUploadImgPub" runat="server" />
        </div>
        
        <asp:Button ID="ButtonPublicar" runat="server" Text="Publicar" />
        <asp:Button Text="Modificar" runat="server" ID ="ButtonModificar" />
        <asp:Button Text="Eliminar" runat="server" ID="ButtonEliminar" />

    </article>


</asp:Content>