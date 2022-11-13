<%@ Page Language="C#" MasterPageFile="~/Site.Master" Title="Dashboard" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="RSWork.Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BusquedaElementos" ContentPlaceHolderID ="MainContent" runat="server">


    <article class="contenedor">   

    <asp:Chart runat="server">
        <series>
            <asp:Series Name="Series1"></asp:Series>
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
        </chartareas>
    </asp:Chart>


    </article>





</asp:Content>





