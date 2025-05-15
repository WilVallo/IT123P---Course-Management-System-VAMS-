<%@ Page Title="" Language="C#" MasterPageFile="~/Login_Portal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IT123P___Course_Management_Systemm.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Login Page</h1>
        <h3>Username</h3>
        <asp:TextBox ID="unameTB" runat="server"></asp:TextBox><br />
        <h3>Password</h3>
        <asp:TextBox ID="pwordTB" runat="server" TextMode="Password"></asp:TextBox><br />

        <asp:Button id="login_id" runat="server" Text="Login" OnClick="login_id_Click"/>
    </div>
</asp:Content>
