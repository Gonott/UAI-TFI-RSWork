using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SERVICIOS;
using BE;
using BLL;


namespace RSWork
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();
            EmpresaBLL empbll = new EmpresaBLL(); 


            Criptografo encriptador = new Criptografo();
            usu.Nombre = txtUsuario.Text;
            usu.Contraseña = encriptador.GetSHA256(txtContraseña.Text);
            UsuarioBLL usuariobll = new UsuarioBLL();
            if(usuariobll.ComprobarUsuario(usu) == true)
            {
                //El usuario sí existe en BD. 
                usu = usuariobll.LlenarUsuario(usu);

                Session["IdUsuario"] = usu.IdUsuario;
                Session["Usuario"] = usu.Nombre;
                Session["IdEmpresa"] = usu.idempresa;
                //ahora a redireccionar segun el cliente, para ello hay que validar que tipo de cliente es.
                usu.empresa = empbll.CargarEmpresa(usu.idempresa);
                if (usu.empresa.GetType() == typeof(Cliente))
                {
                    //HttpCookie cookieUsuario = new HttpCookie("Usuario", usu.Nombre);
                   
                    //llevar perfil cliente
                }
                if (usu.empresa.GetType() == typeof(Proveedor))
                {
                    //llevar perfil proveedor
                    Response.Redirect("PerfilProveedor.aspx");
                }



            }
            else
            {
               
            }
            




        }
    
    }
}