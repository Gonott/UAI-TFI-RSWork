<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="RSWork.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>RS Work</title>
    <link href="css/base.css" rel="stylesheet" />
</head>
<body>
    <header>
        <nav id="navgeneral">
         <img id="logohome" src="img/logo/7475095913_5857cb8d-0fb5-4261-807a-3c597f89a1b2.png" alt="RSWork Logo" style="width: 75px; height: 31px" />
        <input id="TxtBuscar" type="text" />
        <input id="BtnBuscar" type="button" value="Buscar Elementos" />
        <input id="BtnPerfil" type="button" value="Perfil" />
        <input id="BtnContacto" type="button" value="Contactanos" />
    </nav>
    </header>

        <article>
            <h2>Acerca de Nosotros</h2>
            <p>Aca va el texto acerca de nosotros</p>
        </article>
        <article>
            <h2>Nuestra Historia</h2>
            <p>Aca va el texto de nuestra historia</p>
        </article>
        <article>
            <div>
                <h2>Nuestras Oficinas</h2>
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d13138.135754644543!2d-58.42201294095459!3d-34.590657569052716!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x95bcb58041c7fc63%3A0x8f12587c0bce974e!2sRa%C3%BAl%20Scalabrini%20Ortiz%202296%2C%20C1425DBQ%20CABA!5e0!3m2!1ses-419!2sar!4v1662923387918!5m2!1ses-419!2sar" width="400" height="300" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
            </div>
        </article>

        <h2></h2>   

</body>
</html>
