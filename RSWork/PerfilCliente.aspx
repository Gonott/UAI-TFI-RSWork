<%@ Page Title="Perfil de Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilCLiente.aspx.cs" Inherits="RSWork.PerfilCliente" %>


<asp:Content ID="PerfilProveedor" ContentPlaceHolderID="MainContent" runat="server" method="post">


    <article class="contenedor">



        <div>
            <h2>Datos de Empresa</h2>
            <label id="LabelCod" runat="server" text="Codigo1234">Codigo123456</label><br />
            <label id="LabelCUIT" runat="server" text="CUIT">CUIT123456</label><br />
            <label>Teléfono </label>
            <input type="text" name="TxtBoxTelefono" value="Telefono" /><label> Dirección </label>
            <input type="text" name="TextBoxDireccion" value="" />
        </div>


        <div>
            <label id="LabelCat" runat="server" text="Categoria">Categoria 1</label><br />
            <label id="LabelNombreEmp" runat="server" text="Nombre Empresa S.A.">Nombre de Emporesa SA</label>
            <br />
            <label> Correo Electrónico</label>
            <input type="text" name="TxtBoxEmail" value="Correo" /><br />
            <asp:Button Class="button" ID="ModificarBtn" runat="server" Text="Modificar" />
        </div>
    </article>



    <article class="contenedor">
        
        <article>
            <div>
                <h2>Mis Empleados</h2>
                <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>

            </div>
            <div>
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
        </article>



        <article>

            <asp:Button class="button" ID="BtnCrear" runat="server" Text="Crear" />
            <asp:Button class="button" ID="BtnModificar" runat="server" Text="Modificar" />
            <asp:Button class="button" ID="BtnEliminar" runat="server" Text="Eliminar" />

        </article>
          
    </article>



    <article class="contenedor" >
        
        <div><h2>Mis Contratos</h2>
            <label>Mis Contratos Activos</label><br />
            <asp:ListBox ID="ListBoxContratos" runat="server">

            </asp:ListBox>                                             
        </div>
        <div>
            <label>Contrato</label>

        </div>


    </article>


</asp:Content>
