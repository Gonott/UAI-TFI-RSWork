<%@ Page Title="Perfil de Cliente" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilCLiente.aspx.cs" Inherits="RSWork.PerfilCliente" %>


<asp:Content ID="PerfilProveedor" ContentPlaceHolderID="MainContent" runat="server" method="post">
    

    <article>
        <h2> Datos de Empresa</h2>
        <label ID="LabelCUIT" runat="server" Text="CUIT"></Label>
        <label ID="LabelNombreEmp" runat="server" Text="Nombre Empresa S.A."></Label>
        <label ID="LabelCat" runat="server" Text="Categoria"></Label>
        <label ID="LabelCod" runat="server" Text="Codigo1234"></Label>
        <br />
        <label> Teléfono </label> <input type="text" name="TxtBoxTelefono" value="Telefono" />
        <label> Correo Electrónico</label> <input type="text" name="TxtBoxEmail" value="Correo" /> 
        <br />
        <label> Dirección </label> <input type="text" name="TextBoxDireccion" value="" />
        <asp:Button ID="ModificarBtn" runat="server" Text="Button" />
    </article>

    <article>
        <div><h2>Mis Empleados</h2>
            <asp:ListBox ID="ListBox1" runat="server">
            </asp:ListBox>  

        </div>
        <div>
            <p>DNI:<asp:TextBox ID="TextBoxDNI" runat="server"></asp:TextBox> </p>
            <p>Nombre: <asp:TextBox ID="TextBoxNombreEmp" runat="server"></asp:TextBox></p>
            <p>Dirección:<asp:TextBox ID="TextBoxDireccionEmp" runat="server"></asp:TextBox> </p>
            <p>Correo Electrónico <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox></p>
        </div>
        
        <asp:Button ID="BtnCrear" runat="server" Text="Crear" />
        <asp:Button ID="BtnModificar" runat="server" Text="Modificar" />
        <asp:Button ID="BtnEliminar" runat="server" Text="Eliminar" />

    </article>


    <article>
        <h2>Mis Contratos</h2>
        <div>
            <label>Mis Contratos Activos</label><br />
            <asp:ListBox ID="ListBoxContratos" runat="server">

            </asp:ListBox>                                             
        </div>
        <div>
            <label>Contrato</label>

        </div>


    </article>


</asp:Content>
