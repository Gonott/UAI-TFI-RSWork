<%@ Page Title="ParametrosDelAlquiler" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ParametrosDelAlquiler.aspx.cs" Inherits="RSWork.ParametrosDelAlquiler" %>


<asp:Content ID="ParametrosDelAlquiler" ContentPlaceHolderID="MainContent" runat="server">
    
    <article class="contenedor">
        <div>
            <h2>Elementos seleccionados para el alquiler.</h2>


        </div>


        <div>
            <p>Seleccione los Empleados para los que desea los elementos.</p>
            
            <asp:GridView ID="GrillaEmpleados"  runat="server" OnRowCommand="GrillaEmpleados_RowCommand" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundField DataField="DNI" HeaderText="DNI"  />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:ButtonField CommandName="btnSeleccionarEmpleado" Text="Seleccionar" />

                </Columns>
            </asp:GridView>

            <asp:GridView ID="GrillaEmpleadosSeleccionados"  runat="server" OnRowCommand="GrillaEmpleadosSeleccionados_RowCommand" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundField DataField="DNI" HeaderText="DNI"  />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:ButtonField CommandName="btnQuitarEmpleado" Text="Quitar de Lista" />
                </Columns>
            </asp:GridView>

        </div>

        <div>
            <p>Fecha de inicio del alquiler.</p>
            <asp:Calendar class="datepicker" ID="CalendarioInicio" runat="server"></asp:Calendar>
            <p>Tiempo de Alquiler: <asp:TextBox runat="server" /> 
                <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                    <asp:ListItem Text="Días" />
                    <asp:ListItem Text="Semanas" />
                    <asp:ListItem Text="Meses"/>
                    <asp:ListItem Text="Años" />
                 </asp:RadioButtonList>
            </p>
        </div>
        <asp:Button Text="Continuar" ID="BtnContinuar" runat="server" /> 
        <%-- ACA SE TIENE QUE HACER EL CALCULO --%>

    </article>





</asp:Content>
