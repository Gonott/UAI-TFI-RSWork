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
            <asp:Button ID="CerrarSesionBtn" runat="server" Text="Cerrar Sesion" OnClick="CerrarSesionBtn_Click" />
            <asp:Button ID="ModificarBtn"  runat="server" Text="Modificar" OnClick="ModificarBtn_Click" /> 
        </div>
    </article>


    <article class="contenedor" id="elementos">
        <h2>Mis elementos:</h2>
        <div id="div4">
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
            <br />
            <br />
        </div>



        <div id="div5">

            <label>Nombre: </label>
            <asp:TextBox ID="TextBoxNombre" runat="server"></asp:TextBox>
            <label>Descripción: </label>
            <asp:TextBox ID="TextBoxDescripcion" runat="server" Width="325px"></asp:TextBox>
            <label>Precio: </label><asp:TextBox ID="TextBoxPrecio" runat="server"></asp:TextBox>


            <div id="div6">
                <label>Tipo:</label>
                <asp:DropDownList ID="DropDownTipo" runat="server">
                <asp:ListItem Text="Notebook" />
                    <asp:ListItem Text="Desktop" />
                    <asp:ListItem Text="Monitor" />
                    <asp:ListItem Text="Periferico" />
                    <asp:ListItem Text="Escritorio" />
                    <asp:ListItem Text="Silla" />
                </asp:DropDownList>
                <label>Condición:</label>
                <asp:DropDownList ID="DropDownCondicion" runat="server">
                    <asp:ListItem Text="Nuevo" />
                    <asp:ListItem Text="Usado" />
                </asp:DropDownList>
                <label>Características:</label>
                <asp:TextBox ID="TextBoxCaracteristicas" runat="server" Height="70px" Rows="10" Width="503px"></asp:TextBox>

            </div>
            


        </div>


        <div id="div7">
            <asp:Button ID="BtnAltaElemento" CssClass="tresbotones" runat="server" Text="Alta" OnClick="BtnAlta_Click" />
            <asp:Button ID="BtnModificarElemento" CssClass="tresbotones" runat="server" Text="Modificar" OnClick="BtnModificar_Click" />
            <asp:Button ID="BtnBajaElemento" CssClass="tresbotones" runat="server" Text="Baja" OnClick="BtnBaja_Click"  />
        </div>


    </article>


    <article class ="contenedor" id="publicaciones">
        
        <h2>Mis Publicaciones:</h2>
        <div id="div8">
            <asp:GridView ID="grillaPublicaciones"  runat="server" OnRowCommand="GrillaPublicaciones_RowCommand" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id"  />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:BoundField DataField="Resumen" HeaderText="Resumen" />
                    <asp:ButtonField CommandName="btnSeleccionarPublicacion" Text="Seleccionar" />
                </Columns>
            </asp:GridView>
        </div>


        <div id="div9">
            <label>Imagen </label>
            <asp:Image ID="ImagenPublicacion" runat="server" /><br />
            <label>Cambiar Imagen</label>
            
            <asp:FileUpload ID="FileUploadImagen" runat="server" />
            <br />
            <asp:Label ID="LabelIDPub" runat="server" Text="" Enabled ="false"></asp:Label>
            <label>Nombre de la Publicacion</label>
            <asp:TextBox ID="TextBoxNomPub" runat="server"></asp:TextBox>
            <label>Cantidad en la publicacion</label>
            <asp:TextBox ID="TextBoxCantPub" runat="server"></asp:TextBox>
            <br />
            <label>Resumen</label>
            <asp:TextBox ID="TextBoxResumenPub" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
            <label>Elemento Asignado</label>
            <asp:DropDownList Id="DropDownElementos" runat="server" Height="18px" Width="231px">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            


       </div>


        <div id="div10">
            <asp:Button ID="BtnAltaPublicacion" CssClass="tresbotones" runat="server" Text="Alta" OnClick="BtnAltaPub_Click" />
            <asp:Button ID="BtnModificarPublicacion" CssClass="tresbotones" runat="server" Text="Modificar" OnClick="BtnModificarPub_Click" />
            <asp:Button ID="BtnBajaPublicacion" CssClass="tresbotones" runat="server" Text="Baja" OnClick="BtnBajaPub_Click"  />
        </div>





    </article>

    <article class="contenedor" id="contractcontainer">

        <div id="div11">
            <h2>Mis Contratos</h2>
            <asp:GridView ID="GrillaContratos" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundField DataField="NroContrato" HeaderText="Nro Contrato" />
                    <%--<asp:BoundField DataField="CodProveedor" HeaderText="Cod Proveedor" />--%>
                    <asp:BoundField DataField="FechaContrato" HeaderText="Fecha Contrato" />
                    <asp:BoundField DataField="FechaInicio" HeaderText="Fecha Inicio" />
                    <asp:BoundField DataField="FechaFin" HeaderText="Fecha Fin" />
                    <asp:BoundField DataField="Monto" HeaderText="Monto" />
                    <%--<asp:ButtonField CommandName="btnVerContrato" Text="Ver" />--%>
                </Columns>
            </asp:GridView>
            <br />
        </div>
       

    </article>


</asp:Content>
