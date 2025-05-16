<%@ Page Title="" Language="C#" MasterPageFile="~/Login_Portal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IT123P___Course_Management_Systemm.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/default.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-container">
        <h1>Login Page</h1>

        <h3>Username</h3>
        <asp:TextBox ID="unameTB" runat="server" CssClass="input-field" placeholder="Student Number"></asp:TextBox>

        <h3>Password</h3>
        <asp:TextBox ID="pwordTB" runat="server" TextMode="Password" CssClass="input-field" placeholder="Default: school@2025"></asp:TextBox>

        <asp:Button ID="login_id" runat="server" Text="Login" CssClass="login-button" OnClick="login_id_Click" />
    </div>
</asp:Content>