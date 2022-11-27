<%@ Page Title="ParametrosDelAlquiler" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ParametrosDelAlquiler.aspx.cs" Inherits="RSWork.ParametrosDelAlquiler" MaintainScrollPositionOnPostback="true"%>


<asp:Content ID="ParametrosDelAlquiler" ContentPlaceHolderID="MainContent" runat="server">
    
    <article class="contenedor">
        <div>
            <h2>Elementos seleccionados para el alquiler.</h2>
            <br />
            <br />
            <asp:Image ID="ImagenPublicacion" runat="server"/><br />
            <label>Publicación Nro: </label>
            <asp:Label ID="LabelNumeroPub" Text="" runat="server" /><br />
            <label>Tipo Elemento</label>
            <asp:Label ID="LabelTipo" Text="" runat="server"/><br />
            <label>Nombre: </label>
            <asp:Label ID="LabelNombrePub" Text="" runat="server" /><br />
            <label>Resumen: </label>
            <asp:Label ID="LabelResumenPub" Text="" runat="server" /><br />
            <label>Características: </label>
            <br />
            <asp:Label ID="LabelCaracteristicas" Text="" runat="server"/><br />
            <label>Condición: </label>
            <asp:Label ID="LabelCondicion" Text="" runat="server"/><br />
            <label>Precio del Alquiler / Mes: </label>
            <asp:Label ID="LabelPrecio" Text="" runat="server"/>
        </div>


        <div>
            <p></p>
            <h3>Seleccione los Empleados para los que desea los elementos.</h3>
            
            <asp:GridView ID="GrillaEmpleados"  runat="server" OnRowCommand="GrillaEmpleados_RowCommand" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundField DataField="DNI" HeaderText="DNI"  />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:ButtonField CommandName="btnSeleccionarEmpleado" Text="Seleccionar"  />

                </Columns>
            </asp:GridView>
            <p></p>
            <h3>Empleados seleccionados para el alquiler</h3>
            <asp:GridView ID="GrillaEmpleadosSeleccionados"  runat="server" OnRowCommand="GrillaEmpleadosSeleccionados_RowCommand" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundField DataField="DNI" HeaderText="DNI"  />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:ButtonField CommandName="btnQuitarEmpleado" Text="Quitar de Lista" />
                </Columns>
            </asp:GridView>
            <p></p>

        </div>

        <div>
            <h3>Fecha de inicio del alquiler.</h3>
            <asp:Calendar class="datepicker" ID="CalendarioInicio" runat="server"></asp:Calendar>
            <p></p>
            <p>Tiempo de Alquiler:</p>
            <asp:TextBox TextMode="Number" runat="server" min="1" max="25" step="1" Width="44px" ID="TxtBoxCantidadTiempo"/>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Días" />
                    <asp:ListItem Text="Meses"/>
                    <asp:ListItem Text="Años" />
                 </asp:RadioButtonList>
            </p>
        </div>
        <asp:Button Text="Calcular" ID="BtnCalcular" runat="server" OnClick="BtnCalcular_Click"/>
        
        
      

    </article>


    <article class="contenedor">

        <h2>Datos del Contrato</h2>

        <label>Fecha de Contrato: </label> <asp:Label ID="lblfecha" Text="" runat="server" /><br />
        <label>Fecha de inicio del alquiler: </label> <asp:Label ID="lblfinicio" Text="" runat="server" /> <br />
        <label>Fecha de Finalizacion del alquier: </label> <asp:Label ID="lblffin" Text="" runat="server" /><br />
        <label>Monto total del alquiler: </label> <asp:Label ID="lblmonto" Text="" runat="server" /><br />
        <label>Elementos: </label> <asp:Label ID="lblcantelem" Text="" runat="server" /> <asp:Label ID="lbldescelemento" Text="" runat="server" /><br />
        <p> </p>
        <h3>Plan de pagos para el alquiler: </h3>

        <asp:GridView ID="GridViewPagos"  runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundField DataField="fecha" HeaderText="Fecha"  />
                    <asp:BoundField DataField="monto" HeaderText="Monto" />
                </Columns>
            </asp:GridView>
        <p></p>
        <p></p>
        <asp:Button Text="Continuar" ID="BtnContinuar" runat="server" OnClick="BtnContinuar_Click"  /> 


    </article>


</asp:Content>
