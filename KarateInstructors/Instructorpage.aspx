<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Instructorpage.aspx.cs" Inherits="CSCI213Assignment4.Instructor1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        Hello
        <asp:Label ID="firstNameLabel" runat="server" Text="Label"></asp:Label>
        &nbsp;<asp:Label ID="lastNameLabel" runat="server" Text="Label"></asp:Label>
    </p>
    <p>
        <asp:GridView ID="sectionAndMembersGridView" runat="server">
        </asp:GridView>
    </p>
</asp:Content>
