<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Studs.aspx.cs" Inherits="IT123P___Course_Management_Systemm.Admin_AddStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/admin.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Add Student</h1>

        <h3>Student ID</h3>
            <asp:TextBox ID="studID" runat="server" Enabled="false"/>
        <h3>Student First Name</h3>
            <asp:TextBox ID="fname" runat="server" />
        <h3>Student Last Name</h3>
            <asp:TextBox ID="lname" runat="server" />
        <h3>Student Email</h3>
            <asp:TextBox ID="email" runat="server" /><br />
        <asp:Button ID="confirm" runat="server" Width="100px" Text="Confirm" OnClick="confirm_Click"/>
        <asp:Button ID="clear" runat="server" Width="100px" Text="Clear" OnClick="clear_Click"/>
        <asp:Button ID="delete" runat="server" Width="100px" Text="Delete" OnClick="delete_Click" Enabled="false"/>
    </div>

    <div>
        <asp:GridView ID="studentTable" runat="server" AutoGenerateColumns="false" 
            OnSelectedIndexChanged="studentTable_SelectedIndexChanged" AutoPostBack="true">
            <Columns>
                <asp:CommandField ShowSelectButton="true" />
                <asp:BoundField DataField="StudID" HeaderText="ID" />
                <asp:BoundField DataField="Stud_fname" HeaderText="First Name" />
                <asp:BoundField DataField="Stud_lname" HeaderText="Last Name" />
                <asp:BoundField DataField="Email" HeaderText="email" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
