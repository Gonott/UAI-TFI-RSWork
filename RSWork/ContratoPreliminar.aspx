<%@ Page Title="Contrato Preliminar" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ContratoPreliminar.aspx.cs" Inherits="RSWork.ContratoPreliminar" %>



<asp:Content ID="ParametrosDelAlquiler" ContentPlaceHolderID="MainContent" runat="server" method="post">

    <article>

        <div>Datos del Contrato
            <asp:ListBox runat="server">
                <asp:ListItem Text="text1" />
                <asp:ListItem Text="text2" />
            </asp:ListBox>
        </div>

        <div>Contrato de Alquiler de elementos.</div>

    </article>


</asp:Content>