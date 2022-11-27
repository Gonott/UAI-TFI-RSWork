<%@ Page Title="Contrato Preliminar" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ContratoPreliminar.aspx.cs" Inherits="RSWork.ContratoPreliminar" MaintainScrollPositionOnPostback="true"%>



<asp:Content ID="ParametrosDelAlquiler" ContentPlaceHolderID="MainContent" runat="server">

    <article class="contenedor">

        <div>
            <h3>Datos del Contrato</h3>


            <label>Fecha de Contrato: </label>
            <asp:Label ID="lblfecha" Text="" runat="server" /><br />
            <label>Fecha de inicio del alquiler: </label>
            <asp:Label ID="lblfinicio" Text="" runat="server" />
            <br />
            <label>Fecha de Finalizacion del alquier: </label>
            <asp:Label ID="lblffin" Text="" runat="server" /><br />
            <label>Monto total del alquiler: </label>
            <asp:Label ID="lblmonto" Text="" runat="server" /><br />
            <label>Elementos: </label>
            <asp:Label ID="lblcantelem" Text="" runat="server" />
            <asp:Label ID="lbldescelemento" Text="" runat="server" /><br />
            <p></p>



            <h3>Los elementos serán entregados a los siguientes usuarios</h3>
            <asp:GridView ID="GrillaEmpleadosSeleccionados" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundField DataField="DNI" HeaderText="DNI" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Dirección" HeaderText="Dirección" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                </Columns>
            </asp:GridView>
            <p></p>

        </div>


        <div>
            <h3>Plan de pagos para el alquiler: </h3>

            <asp:GridView ID="GridViewPagos" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundField DataField="fecha" HeaderText="Fecha" />
                    <asp:BoundField DataField="monto" HeaderText="Monto" />
                </Columns>
            </asp:GridView>
            <p></p>
            <p></p>
        </div>



        <div>
            <h3>¿Desea confirmar el contrato de alquiler de elementos?</h3>

            <p>El contrato aparecerá en su perfil.</p>

            <asp:Button Text="Confirmar" runat="server" OnClick="Unnamed1_Click" />
        </div>
    </article>

</asp:Content>
