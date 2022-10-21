<%@ Page Title="Perfil de Proveedor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilProveedor.aspx.cs" Inherits="RSWork.PerfilProveedor" %>


<asp:Content ID="PerfilProveedor" ContentPlaceHolderID="MainContent" runat="server">
    
    <link href="Content/PerfilProveedor.css" rel="stylesheet" />

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


    <article class="contenedor" id="elementos">
        <h2>Mis elementos:</h2>
        <div id="4">
            <asp:GridView ID="grillaElementos"  runat="server" OnRowCommand="Grilla_RowCommand" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundField DataField="Codigo" HeaderText="Codigo"  />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:ButtonField CommandName="btnSeleccionarElemento" Text="Seleccionar" />
                </Columns>
            </asp:GridView>
        </div>


        <div id="5">

            <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBoxDescripcion" runat="server"></asp:TextBox>.
            <asp:TextBox ID="TextBoxPrecio" runat="server"></asp:TextBox>
            <asp:ListBox ID="ListBoxTipo" runat="server">
                <asp:ListItem Text="text" />
            </asp:ListBox>
            <asp:TextBox ID="TextBoxCaracteristicas" runat="server"></asp:TextBox>
            <asp:ListBox ID="ListBoxCondicion" runat="server">
                <asp:ListItem Text="Nuevo" />
                <asp:ListItem Text="Usado" />
            </asp:ListBox>
        </div>


        <div id="6">
            <asp:Button ID="BtnAlta" CssClass="tresbotones" runat="server" Text="Alta" OnClick="BtnAlta_Click" />
            <asp:Button ID="BtnModificar" CssClass="tresbotones" runat="server" Text="Modificar" OnClick="BtnModificar_Click" />
            <asp:Button ID="BtnBaja" CssClass="tresbotones" runat="server" Text="Baja" OnClick="BtnBaja_Click"  />
        </div>


    </article>


    <article class ="contenedor" id="publicaciones">


        <div id="7">
            <asp:GridView ID="grillaPublicaciones"  runat="server" OnRowCommand="GrillaPublicaciones_RowCommand" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id"  />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:ButtonField CommandName="btnSeleccionarPublicacion" Text="Seleccionar" />
                </Columns>
            </asp:GridView>
        </div>


        <div id="8">
            <asp:Image ID="ImagenPublicacion" runat="server" />
            <asp:TextBox ID="TextBoxNomPub" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBoxCantPub" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBoxResumenPub" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
            <asp:TextBox runat="server" ID="TextBoxElemento"></asp:TextBox>
            <asp:FileUpload ID="FileUpload1" runat="server" />


       </div>


        <div id="9">
            <asp:Button ID="BtnAltaPublicacion" CssClass="tresbotones" runat="server" Text="Alta" OnClick="BtnAltaPub_Click" />
            <asp:Button ID="BtnModificarPublicacion" CssClass="tresbotones" runat="server" Text="Modificar" OnClick="BtnModificarPub_Click" />
            <asp:Button ID="BtnBajaPublicacion" CssClass="tresbotones" runat="server" Text="Baja" OnClick="BtnBajaPub_Click"  />


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
