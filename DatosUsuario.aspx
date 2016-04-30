<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DatosUsuario.aspx.cs" Inherits="ProyectoSO2ADDS.DatosUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div id = "datos_personales">
            <h2>Datos Personales</h2>
            <div style="text-align: right; float:left; font-weight: 700; color: #000000; font-size: large;">          
                <asp:Label ID="Label1" runat="server" Text="First Name:"></asp:Label>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Last Name:"></asp:Label>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Display Name:"></asp:Label>
            </div>
            <div style="text-align: left">
                <asp:TextBox ID="TextBoxFirstName" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBoxLastName" runat="server"></asp:TextBox>
                <br />
                <asp:TextBox ID="TextBoxDisplayName" runat="server"></asp:TextBox>
                <br />
            </div>
        </div>
        <br />
        <div style="clear:left" id ="grupos">
            <h2>Grupos</h2>
            <asp:ListBox ID="ListBoxGrupos" runat="server" Width="403px"></asp:ListBox>
        </div>
        <br />
        <div style="clear:left" id ="cambiar_contrasenia">
            <h2>Cambiar Contraseña</h2>
            <div>
                <asp:Label ID="Label4" runat="server" style="font-size: large; font-weight: 700; color: #000000" Text="Nueva Contraseña:"></asp:Label>
                <asp:TextBox ID="TextBoxCambiarContrasenia" TextMode="Password" runat="server"></asp:TextBox>
                <asp:Button ID="ButtonCambiarContrasenia" runat="server" Text="Cambiar" Width="161px" OnClick="ButtonCambiarContrasenia_Click" />
            </div>
        </div>
        <br />
        <div id="div_administracion" runat ="server">
            <h2>Administración</h2>
            <p>Parece ser que usted es parte del grupo 'Administradores'; a continuación puede acceder a la información de todos los usuarios:</p>
            <div>
                <asp:ListBox ID="ListBoxUsuarios" runat="server" Height="198px" Width="423px"></asp:ListBox>
            </div>
            <div>
                <asp:Button ID="ButtonVerInformacion" runat="server" OnClick="ButtonVerInformacion_Click" Text="Ver Información" />
            </div>
        </div>
        <div style ="text-align:center"><asp:Button ID="ButtonCerrarSesion" runat="server" Text="Cerrar Sesión" OnClick="ButtonCerrarSesion_Click" />
</div>
</asp:Content>
