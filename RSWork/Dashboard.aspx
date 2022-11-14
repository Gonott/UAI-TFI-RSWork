<%@ Page Language="C#" MasterPageFile="~/Site.Master" Title="Dashboard" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="RSWork.Dashboard" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BusquedaElementos" ContentPlaceHolderID ="MainContent" runat="server">


    <article class="contenedor">


        <div>
            <h3>Cantidad de Publicaciones por Tipo de Elemento</h3>
            <p>
                Muestra cuantas publicaciones hay activas para cada uno de nuestros elementos:
                <br />
                -Notebook
                <br />
                -Desktop (PC de Escritorio)
                <br />
                -Monitor
                <br />
                -Periferico (Teclados, Mouses, Auriculares, Webcams)
                <br />
                -Escritorio.
                <br />
                -Silla
            </p>
            <asp:Chart runat="server" ID="ctl00" DataSourceID="SqlDataSource1">
                <Series>
                    <asp:Series Name="Series1" XValueMember="Tipo de Elemento" YValueMembers="Cantidad"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

        </div>


        <div> 
             <h3>Cantidad de Elementos han sido alquilados por Tipo </h3>
            <p>
                Muestra la cantidad de elementos que han sido alquilados por tipo:
                <br />
                -Notebook
                <br />
                -Desktop (PC de Escritorio)
                <br />
                -Monitor
                <br />
                -Periferico (Teclados, Mouses, Auriculares, Webcams)
                <br />
                -Escritorio.
                <br />
                -Silla
            </p>
           
        
<asp:Chart ID="Chart1" runat="server" DataSourceID="ElementosAlquiladosTipo" >
                <Series>
                    <asp:Series Name="Series1" XValueMember="Tipo" YValueMembers="cantidad" ChartType="Pie" YValuesPerPoint="2"></asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                </ChartAreas>
            </asp:Chart>


        </div>


        <div>

            <h3>Historico de Cantidad de alquileres por mes.</h3>
            
            <asp:Chart ID="Chart2" runat="server" DataSourceID="CantAlquilTemporal">
                <Series>
                    <asp:Series ChartType="Line" Name="Series1" XValueMember="Mes" YValueMembers="Cantidad">
                    </asp:Series>
                </Series>
                <ChartAreas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
            </asp:Chart>

        </div>





   

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:RSWorkConnectionString %>" SelectCommand="SELECT COUNT(Tipo) AS Cantidad, Tipo AS [Tipo de Elemento] FROM (SELECT Elemento.Tipo FROM Publicacion INNER JOIN Elemento ON Elemento.Codigo = Publicacion.codElemento) AS T1 GROUP BY Tipo"></asp:SqlDataSource>
        
            <asp:SqlDataSource ID="ElementosAlquiladosTipo" runat="server" ConnectionString="<%$ ConnectionStrings:RSWorkConnectionString %>" SelectCommand="Select Sum(Cantidad) as cantidad, Tipo from ContratoDetalle inner join Elemento on
elemento.Codigo = ContratoDetalle.NroElemento
group by Tipo"></asp:SqlDataSource>

                    <asp:SqlDataSource ID="CantAlquilTemporal" runat="server" ConnectionString="<%$ ConnectionStrings:RSWorkConnectionString %>" SelectCommand="Select Count( convert(varchar(7), FechaContrato, 126)) as Cantidad, convert(varchar(7), FechaContrato, 126)  as Mes  FROM ContratoCabecera
group by convert(varchar(7), FechaContrato, 126)
"></asp:SqlDataSource>

    </article>





</asp:Content>





