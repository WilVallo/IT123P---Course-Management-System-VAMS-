<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Studs.aspx.cs" Inherits="IT123P___Course_Management_Systemm.Admin_AddStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/adminStuds.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <h1>Add Student</h1>

        <div class="form-group">
            <h3>Student ID</h3>
            <asp:TextBox ID="studID" runat="server" CssClass="input" Enabled="false" />
        </div>

        <div class="form-group">
            <h3>Student First Name</h3>
            <asp:TextBox ID="fname" runat="server" CssClass="input" />
        </div>

        <div class="form-group">
            <h3>Student Last Name</h3>
            <asp:TextBox ID="lname" runat="server" CssClass="input" />
        </div>

        <div class="form-group">
            <h3>Student Email</h3>
            <asp:TextBox ID="email" runat="server" CssClass="input" />
        </div>

        <asp:Button ID="confirm" runat="server" Text="Confirm" CssClass="btn" OnClick="confirm_Click" />
        <asp:Button ID="clear" runat="server" Text="Clear" CssClass="btn" OnClick="clear_Click" />
        <asp:Button ID="delete" runat="server" Text="Delete" CssClass="btn danger" OnClick="delete_Click" Enabled="false" />
    </div>

    <div class="section">
        <h1>Student List</h1>
        <asp:GridView ID="studentTable" runat="server" CssClass="gridview"
            AutoGenerateColumns="false"
            DataKeyNames="StudID,Stud_fname,Stud_lname,Email"
            OnSelectedIndexChanged="studentTable_SelectedIndexChanged">
            <Columns>
                <asp:CommandField ShowSelectButton="true" />
                <asp:BoundField DataField="StudID" HeaderText="ID" />
                <asp:BoundField DataField="Stud_fname" HeaderText="First Name" />
                <asp:BoundField DataField="Stud_lname" HeaderText="Last Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>