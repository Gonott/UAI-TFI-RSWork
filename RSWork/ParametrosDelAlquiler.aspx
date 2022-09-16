<%@ Page Title="ParametrosDelAlquiler" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ParametrosDelAlquiler.aspx.cs" Inherits="RSWork.ParametrosDelAlquiler" %>


<asp:Content ID="ParametrosDelAlquiler" ContentPlaceHolderID="MainContent" runat="server" method="post">
    
    <article>
        <div>
            <p>Seleccione los Empleados para los que desea los elementos.</p>
            <asp:ListBox runat="server"></asp:ListBox>
        </div>

        <div>
            <p>Fecha de inicio del alquiler.</p>
            <asp:Calendar class="datepicker" ID="CalendarioInicio" runat="server"></asp:Calendar>
            <p>Tiempo de Alquiler: <asp:TextBox runat="server"/> 
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem Text="Días" />
                    <asp:ListItem Text="Semanas" />
                    <asp:ListItem Text="Meses"/>
                    <asp:ListItem Text="Años" />
                 </asp:RadioButtonList>
            </p>
        </div>
        <asp:Button Text="Continuar" ID="BtnContinuar" runat="server" />

    </article>





</asp:Content>
