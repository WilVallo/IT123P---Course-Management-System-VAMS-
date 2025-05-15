<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Studs.aspx.cs" Inherits="IT123P___Course_Management_Systemm.Admin_AddStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <link rel="stylesheet" href="CSS/admin.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Add Student</h1>

    <h3>Student ID</h3>
        <asp:TextBox ID="studID" runat="server" Enabled="false"/>
    <h3>Student First Name</h3>
        <asp:TextBox ID="fname" runat="server" />
    <h3>Student Last Name</h3>
        <asp:TextBox ID="lname" runat="server" />
    <h3>Student Email</h3>
        <asp:TextBox ID="email" runat="server" /><br />

    <asp:Button ID="confirm" runat="server" Width="100px" Text="Confirm"/>
</asp:Content>
