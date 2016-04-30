using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.Drawing;

namespace ProyectoSO2ADDS
{
    public partial class InicioDeSesion: System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {
        }

        private bool AutenticaUsuario( String path, String user, String pass )
        {
            //Los datos que hemos pasado los 'convertimos' en una entrada de Active Directory para hacer la consulta
            DirectoryEntry de = new DirectoryEntry( path, user, pass, AuthenticationTypes.Secure );
            try
            {
                //Inicia el chequeo con las credenciales que le hemos pasado
                //Si devuelve algo significa que ha autenticado las credenciales
                DirectorySearcher ds = new DirectorySearcher( de );
                ds.FindOne();
                return true;
            }
            catch
            {
                //Si no devuelve nada es que no ha podido autenticar las credenciales
                //ya sea porque no existe el usuario o por que no son correctas
                return false;
            }
        }

        protected void Button1_Click( object sender, EventArgs e )
        {
            string path = @"LDAP://ANDRESPC.miempresa.com";       //CAMBIAR POR VUESTRO PATH (URL DEL SERVICIO DE DIRECTORIO LDAP)
                           
                                                 //Por ejemplo: 'LDAP://ejemplo.lan.es'
            string dominio = @TextBoxDominio.Text.Trim();             //CAMBIAR POR VUESTRO DOMINIO
            string usu = TextBoxUsuario.Text.Trim();                   //USUARIO DEL DOMINIO
            string pass = TextBoxPassword.Text.Trim();                    //PASSWORD DEL USUARIO
            string domUsu = dominio + @"\" + usu;               //CADENA DE DOMINIO + USUARIO A COMPROBAR

            bool permiso = AutenticaUsuario( path, domUsu, pass );

            if( permiso )
            {
                Session[ "field1" ] = usu;
                Response.Redirect( "~/DatosUsuario.aspx" );          
            }
            else
            {
                permitido.Visible = true;
                permitido.BackColor = Color.Red;
                permitido.ForeColor = Color.White;
                permitido.Text = "Acceso denegado";
            }
        }
    }
}