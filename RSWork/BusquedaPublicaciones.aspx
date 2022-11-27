<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BusquedaPublicaciones.aspx.cs" Title="Busqueda de Elementos" Inherits="RSWork.BusquedaPublicaciones" MaintainScrollPositionOnPostback="true"%>


<asp:Content ID="BusquedaElementos" ContentPlaceHolderID ="MainContent" runat="server">

    <link href="Content/BusquedaElementos.css" rel="stylesheet" />

    <article class="contenedor">

        <div id="publicaciones">
        <asp:DataList ID="DataListPublicaciones"  runat="server" RepeatDirection="Horizontal" Width="500px" RepeatColumns="3" OnSelectedIndexChanged="DataListPublicaciones_SelectedIndexChanged">
            <ItemTemplate >
                <table class="itempub">
                    <tr>
                        <td>
                            <asp:Label ID="LabelNombre" runat="server" Text='<%# Eval("Nombre")%>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="ImagenPublicacion" Width="300px" Height="220px" runat="server" ImageUrl='<%# Eval("Imagen") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelResumen" runat="server" Text='<%# Eval("Resumen")%>'></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID ="VerAside" Text="Ver"  OnClick="VerAsideButton_Click" runat="server" CommandArgument='<%# Eval("Id")%>'/>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        </div>


        
    <div id="detallepublicacion">
        <asp:DataList runat="server" ID="AsideDataList" RepeatDirection="Vertical" Width="149px" >
            <ItemTemplate>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAsideNro" Text='<%# Eval("Id")%>' runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                             <asp:Label ID="LabelAsideNombre" Text='<%# Eval("Nombre")%>' runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Image ID="ImageAsidePublicacion" Width="230px" Height="200px" runat="server" ImageUrl='<%# Eval("Imagen") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAsideResumen" Text='<%# Eval("Resumen")%>' runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAsideCantidad" Text='<%# Eval("Cantidad")%>' runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAsideTipo" Text='<%# Eval("Tipo")%>' runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAsideCaracteristicas" Text='<%# Eval("Caracteristicas")%>' runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAsideCondición" Text='<%# Eval("Condición")%>' runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelAsidePrecio" Text='<%# Eval("Precio")%>' runat="server" OnClick=""  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="ContratarButton" Text="Contratar" runat="server" OnClick="ContratarButton_Click" CommandArgument='<%# Eval("Id")%>' />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
    </div>


    </article>





</asp:Content>
