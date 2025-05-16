<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Admin_Cors.aspx.cs" Inherits="IT123P___Course_Management_Systemm.Admin_Cors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/adminCors.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="section">
        <h1>Course Dashboard</h1>

        <h3>Create Course</h3>
        <asp:Button ID="newCourse" runat="server" Text="New" CssClass="btn" />
        
        <div class="form-group">
            <h3>Create Code</h3>
            <asp:TextBox ID="corsCode" runat="server" CssClass="input" MaxLength="9" placeholder="AAAA-0123"></asp:TextBox>
        </div>

        <div class="form-group">
            <h3>Course Title</h3>
            <asp:TextBox ID="corsTitle" runat="server" CssClass="input" MaxLength="50"></asp:TextBox>
        </div>

        <div class="form-group">
            <h3>Course Units</h3>
            <asp:TextBox ID="corsUnits" runat="server" TextMode="Number" CssClass="input" MaxLength="1"></asp:TextBox>
        </div>

        <asp:Button ID="addCors" runat="server" Text="Add" CssClass="btn" OnClick="addCors_Click"/>
        <asp:Button ID="delCors" runat="server" Text="Delete" CssClass="btn danger" />

        <asp:GridView ID="courseGV" runat="server" CssClass="gridview"></asp:GridView>
    </div>

    <div class="section">
        <h1>Create a Section</h1>

        <div class="form-group">
            <h3>Course</h3>
            <asp:DropDownList ID="courseDDL1" runat="server" CssClass="dropdown"></asp:DropDownList>
        </div>

        <div class="form-group">
            <h3>Section Name</h3>
            <asp:TextBox ID="secName" runat="server" CssClass="input" MaxLength="9" placeholder="DEPT-0123"></asp:TextBox>
        </div>

        <asp:Button ID="saveSec" runat="server" Text="Save" CssClass="btn" />
        <asp:Button ID="delSec" runat="server" Text="Delete" CssClass="btn danger" />
    </div>

    <div class="section">
        <h1>Assign Professor to a Course</h1>

        <div class="form-group">
            <h3>Course</h3>
            <asp:DropDownList ID="courseDDL2" runat="server" CssClass="dropdown"></asp:DropDownList>
        </div>

        <div class="form-group">
            <h3>Section</h3>
            <asp:DropDownList ID="secDDL" runat="server" CssClass="dropdown"></asp:DropDownList>
        </div>

        <div class="form-group">
            <h3>Professor</h3>
            <asp:DropDownList ID="profDDL" runat="server" CssClass="dropdown"></asp:DropDownList>
        </div>

        <asp:Button ID="Button4" runat="server" Text="Save" CssClass="btn" />
    </div>

</asp:Content>