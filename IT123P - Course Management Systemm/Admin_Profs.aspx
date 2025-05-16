<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Profs.aspx.cs" Inherits="IT123P___Course_Management_Systemm.Admin_Profs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/admin.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>My Professors</h1>

    <h3>ID</h3>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <h3>Name</h3>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    <h3>Email</h3>
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>

    <asp:Button ID="confirm" runat="server" Width="100px" Text="Confirm" OnClick="confirm_Click" />
    <asp:Button ID="clear" runat="server" Width="100px" Text="Clear" OnClick="clear_Click" />
    <asp:Button ID="delete" runat="server" Width="100px" Text="Delete" OnClick="delete_Click" Enabled="false" />

    <div class="table-section">
        <asp:GridView ID="profTable" runat="server" AutoGenerateColumns="false"
            OnSelectedIndexChanged="studentTable_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="true" />
                <asp:BoundField DataField="ProfID" HeaderText="ID" />
                <asp:BoundField DataField="Prof_fname" HeaderText="First Name" />
                <asp:BoundField DataField="Prof_lname" HeaderText="Last Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
