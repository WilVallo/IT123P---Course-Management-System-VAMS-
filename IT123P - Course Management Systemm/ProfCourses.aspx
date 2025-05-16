<%@ Page Title="" Language="C#" MasterPageFile="~/Prof.Master" AutoEventWireup="true" CodeBehind="ProfCourses.aspx.cs" Inherits="IT123P___Course_Management_Systemm.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="CourseTitleLabel" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#8d7b68" />
    <br /><br />

    <asp:PlaceHolder ID="CourseButtonHolder" runat="server" />
    <br />

    <asp:PlaceHolder ID="StudentsTableHolder" runat="server" />
    <br />

    <asp:Button ID="SubmitGradesButton" runat="server" Text="Submit Grades" CssClass="submit-button" OnClick="SubmitGradesButton_Click" />
</asp:Content>
