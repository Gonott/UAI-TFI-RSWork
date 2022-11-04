<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BusquedaPublicaciones.aspx.cs" Title="Busqueda de Elementos" Inherits="RSWork.BusquedaPublicaciones" %>


<asp:Content ID="BusquedaElementos" ContentPlaceHolderID ="MainContent" runat="server">

    <link href="Content/BusquedaElementos.css" rel="stylesheet" />

    <div class="contenedor">
        <asp:DataList ID="DataListPublicaciones" runat="server" RepeatDirection="Horizontal" Width="378px">
            <ItemTemplate >
                <table class="itempub">
                    <tr>
                        <td>
                            <asp:Label ID="LabelNombre" runat="server" Text='<%# Eval("Nombre")%>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="ImagenPublicacion" runat="server" ImageUrl='<%# Eval("Imagen") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelResumen" runat="server" Text='<%# Eval("Resumen")%>'></asp:Label>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>


    </div>





</asp:Content>
