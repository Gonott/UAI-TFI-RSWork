<%@ Page Title="Perfil de Proveedor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilProveedor.aspx.cs" Inherits="RSWork.PerfilProveedor" %>


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
        <h2>Mis Contratos</h2>
        <div>
            <label>Mis Contratos Activos</label><br />
                                               
        </div>
        <div>
            <label>Contrato</label>
        </div>


    </article>


</asp:Content>
