<%@ Page Title="Perfil de Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilCLiente.aspx.cs" Inherits="RSWork.PerfilCliente" %>


<asp:Content ID="PerfilProveedor" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Content/PerfilCliente.css" rel="stylesheet" />

    <article id="datosemp" class="contenedor">
        <div id="div1">
            <h2>Datos de Empresa</h2>
            <label id="LabelCod" runat="server" text="Codigo1234"></label><br />
            <label id="LabelCUIT" runat="server" text="CUIT"></label><br />
            <label>Teléfono </label>
            <asp:TextBox ID="txtBoxTelefono" runat="server" value =" "></asp:TextBox>
            <br />
            <label> Dirección </label>
            <asp:TextBox ID="txtBoxDireccion" runat="server"></asp:TextBox>
        </div>


        <div id="div2">
            
            <label id="LabelCat" runat="server" text="Categoria">Categoria 1</label><br />
            <label id="LabelNombreEmp" runat="server" text="Nombre Empresa S.A.">Nombre de Emporesa SA</label>
            <br />
            <label>Correo Electrónico</label>
            <asp:TextBox ID="txtboxEmail" runat="server"></asp:TextBox>
             </div>

        <div id="div3">
            <asp:Button ID="ModificarBtn"  runat="server" Text="Modificar" OnClick="ModificarBtn_Click" /> 
        </div>
    </article>



    <article class="contenedor" id="empleados">


        <div id="div4">
            <h2>Mis Empleados</h2>

            <asp:GridView ID="grillaEmpleados"  runat="server" OnRowCommand="Grilla_RowCommand" AutoGenerateColumns="False" Width="100%">
                        <Columns>
                            <asp:BoundField DataField="DNI" HeaderText="DNI"  />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:ButtonField CommandName="btnSeleccionarEmpleado" Text="Seleccionar" />
                        </Columns>
                    </asp:GridView>

        </div>
        <div id="div5">
            <p>
                DNI:<asp:TextBox ID="TextBoxDNI" runat="server"></asp:TextBox>
            </p>
            <p>
                Nombre:
                    <asp:TextBox ID="TextBoxNombreEmp" runat="server"></asp:TextBox>
            </p>
            <p>
                Dirección:<asp:TextBox ID="TextBoxDireccionEmp" runat="server"></asp:TextBox>
            </p>
            <p>
                Correo Electrónico
                    <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
            </p>

        </div>
        <div id="div6">
            <asp:Button ID="BtnAlta" CssClass="tresbotones" runat="server" Text="Alta" OnClick="BtnAlta_Click" />
            <asp:Button ID="BtnModificar" CssClass="tresbotones" runat="server" Text="Modificar" OnClick="BtnModificar_Click" />
            <asp:Button ID="BtnBaja" CssClass="tresbotones" runat="server" Text="Baja" OnClick="BtnBaja_Click"  />
            

        </div>
    </article>

    <article class="contenedor" id="contractcontainer">

        <div id="div7">
            <h2>Mis Contratos</h2>
            <label>Mis Contratos Activos</label><br />
            <asp:ListBox ID="ListBoxContratos" runat="server"></asp:ListBox>
        </div>
        <div id="div8">
            <label>Contrato</label>

        </div>


    </article>


</asp:Content>
