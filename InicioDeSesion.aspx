<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InicioDeSesion.aspx.cs" Inherits="ProyectoSO2ADDS.InicioDeSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id ="controles">
        <div style="float:left; text-align:right">
            <asp:Label ID="Label1" runat="server" style="font-weight: 700; color: #000000; font-size: large;" Text="Dominio:"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" style="font-weight: 700; color: #000000; font-size: large;" Text="Usuario:"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" style="font-weight: 700; color: #000000; font-size: large;" Text="Contraseña:"></asp:Label>
        </div>
        <div>
            <asp:TextBox ID="TextBoxDominio" runat="server" Width="280px"></asp:TextBox>
            <br />
            <asp:TextBox ID="TextBoxUsuario" runat="server" Width="280px"></asp:TextBox>
            <br />
            <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" Width="280px"></asp:TextBox>
            <br />
        </div>
        <div>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Iniciar Sesión" Width="391px" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label ID="permitido" runat="server" Text="Label" Font-Bold="True" Font-Size="Medium" Visible="False"></asp:Label>
        </div>
    </div>
</asp:Content>
