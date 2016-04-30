using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;

namespace ProyectoSO2ADDS
{
    public partial class DatosUsuario: System.Web.UI.Page
    {
        private DirectoryEntry entry;
        private string Name;

        public DatosUsuario()
        {
            entry = new DirectoryEntry( @"LDAP://ANDRESPC.miempresa.com" );
        }

        protected void Page_Load( object sender, EventArgs e )
        {
            div_administracion.Visible = false;
            //Name = Request.QueryString[ "param" ].ToString();
            Name = (string)(Session[ "field1" ]);
            DirectorySearcher dSearch = new DirectorySearcher( entry );
            dSearch.Filter = "(&(objectCategory=person)(objectClass=user)(sAMAccountName=" + Name + "))";
            SearchResult sResultSet = dSearch.FindOne();
            // Login Name
            TextBoxDisplayName.Text = GetProperty( sResultSet, "cn" );
            // First Name
            TextBoxFirstName.Text = GetProperty( sResultSet, "givenName" );
            // Last Name
            TextBoxLastName.Text = GetProperty( sResultSet, "sn" );

            dSearch.PropertiesToLoad.Add( "memberof" );

            foreach( string str in sResultSet.Properties[ "memberof" ] )
            {
                string str2 = str.Substring( str.IndexOf( "=" ) + 1, str.IndexOf( "," ) - str.IndexOf( "=" ) - 1 );

                if( str2.Equals( "Administrators" ) )
                    div_administracion.Visible = true;

                ListBoxGrupos.Items.Add( str2 );
            }
       
            if( div_administracion.Visible )
            {
                DirectorySearcher dSearch2 = new DirectorySearcher( entry );
                dSearch2.Filter = "(&(objectCategory=person)(objectClass=user))";

                SearchResultCollection resultados = dSearch2.FindAll();

                foreach( SearchResult x in resultados )
                {
                    ListBoxUsuarios.Items.Add( GetProperty( x, "cn" ) );
                }
            }
        }

        public string GetProperty( SearchResult searchResult, string PropertyName )
        {
            if( searchResult.Properties.Contains( PropertyName ) )
            {
                return searchResult.Properties[ PropertyName ][ 0 ].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        protected void ButtonVerInformacion_Click( object sender, EventArgs e )
        {
            int indiceSeleccionado = ListBoxUsuarios.SelectedIndex;

            if( indiceSeleccionado != -1 )
            {
                string usu = ListBoxUsuarios.Items[ indiceSeleccionado ].ToString();
                Session[ "field1" ] = usu;
                Response.Redirect( "~/DatosUsuario.aspx" );
            }
        }

        public string GetLoginName( string userName )
        {
            // set up domain context
            PrincipalContext ctx = new PrincipalContext( ContextType.Domain );

            // find user by name
            UserPrincipal user = UserPrincipal.FindByIdentity( ctx, userName );

            if( user != null )
                return user.SamAccountName;
            else
                return string.Empty;
        }

        protected void ButtonCambiarContrasenia_Click( object sender, EventArgs e )
        {
            //ResetPassword( TextBoxCambiarContrasenia.Text.Trim() );
        }

        public void ResetPassword( string password )
        {
            DirectoryEntry uEntry = new DirectoryEntry( GetUserDistinguishedName( Name ) );
            uEntry.Invoke( "SetPassword", new object[] { password } );
            uEntry.Properties[ "LockOutTime" ].Value = 0; //unlock account

            uEntry.Close();
        }

        private string GetUserDistinguishedName( string userName )
        {
            var domain = new PrincipalContext( ContextType.Domain );
            var user = UserPrincipal.FindByIdentity( domain, userName );
            return user != null ? user.DistinguishedName : null;
        }

        protected void ButtonCerrarSesion_Click( object sender, EventArgs e )
        {
            Response.Redirect( "~/Default.aspx" );
        }
    }
}