<%@ Page Title="Perfil de Proveedor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilProveedor.aspx.cs" Inherits="RSWork.PerfilProveedor" %>


<asp:Content ID="PerfilProveedor" ContentPlaceHolderID="MainContent" runat="server">
    
    <link href="Content/PerfilProveedor.css" rel="stylesheet" />

     <article id="datosemp" class="contenedor">
        <div id="div1">
            <h2>Datos de Empresa</h2>
            <label id="LabelCod" runat="server" text="Codigo1234">Codigo123456</label><br />
            <label id="LabelCUIT" runat="server" text="CUIT">CUIT123456</label><br />
            <label>Teléfono </label>
            <input type="text" name="TxtBoxTelefono" value="Telefono" />
            <br />
            <label> Dirección </label>
            <input type="text" name="TextBoxDireccion" value="" />
        </div>


        <div id="div2">
            <label id="LabelTipo" runat="server" text="Tipo de Proveedor">Fabricante</label><br />
            <label id="LabelNombreEmp" runat="server" text="Nombre Empresa S.A.">Nombre de Emporesa SA</label>
            <br />
            <label>Correo Electrónico</label>
            <input type="text" name="TxtBoxEmail" value="Correo" /><br />
             </div>

        <div id="div3">
            <asp:Button ID="ModificarBtn"  runat="server" Text="Modificar" /> 
        </div>
    </article>


    <article class="contenedor" id="contractcontainer">
        
        <div id="div4">
            <h2>Mis Contratos</h2>
            <label>Mis Contratos Activos</label><br />
                                               
        </div>
        <div id="div5">
            <label>Contrato</label>
        </div>


    </article>


</asp:Content>
