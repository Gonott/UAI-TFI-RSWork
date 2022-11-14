<%@ Page Title="Pagina Principal" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RSWork._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   
        <article class="contenedor">
            <h2>Acerca de Nosotros</h2>
            <p>Somos una empresa joven que con experiencia desarrollando sistemas de stock y logística, con soluciones creadas para empresas por lo que conocemos las necesidades del sector. Anteriormente hemos desarrollado un sistema que se encarga de manejar equipos internos de una empresa y estamos preparados para llevarlo al siguiente nivel. Quien lidera la empresa es una persona experimentada en el área técnica con que conoce los procesos internos de las empresas en cuanto al manejo de insumos y equipos se refiere. </p>
           

        
        </article>
        <article class="contenedor">
            <h2>Nuestra Historia</h2>
            <p>La empresa ve sus inicios en el año 2021  cuando un grupo de emprendedores ve la oportunidad de desarrollar este modelo de 
                mercado que se evidenció durante la pandemia del Covid19, tras finalizar ésta, deciden crear Remote Smart Work para dar una solución a 
                todas aquellas empresas que no puden darse el lujo de comprar, mantenerlos y almacenar elementos de teletrabajo para sus empleados.
            </p>
        </article>
        <article class="contenedor">
            <div>
                <h2>Nuestras Oficinas</h2>
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d13138.135754644543!2d-58.42201294095459!3d-34.590657569052716!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x95bcb58041c7fc63%3A0x8f12587c0bce974e!2sRa%C3%BAl%20Scalabrini%20Ortiz%202296%2C%20C1425DBQ%20CABA!5e0!3m2!1ses-419!2sar!4v1662923387918!5m2!1ses-419!2sar" width="400" height="300" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
            </div>
            <p></p>
            <div>
                <h2>Nuestras métricas</h2>
                <p>Dashboard actualizado sobre los tipos de elementos y demás que tiene la plataforma</p>
                <asp:Button Text="Ingresar al Dashboard" ID="DashboardBtn" runat="server"  OnClick="DashboardBtn_Click"/>

            </div>
        </article>
  
       

 
  
</asp:Content>
