<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="CSCI213Assignment4.Administrator" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <br />
    </p>
    <table style="width:100%;">
        <tr>
            <td>
                <h1>Members</h1>
                <br />
                <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="259px">
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
                <br />
            </td>
            <td>
                <asp:Label ID="memberUserNameLabel" runat="server" Text="Username:"></asp:Label>
                <asp:TextBox ID="memberUserNameTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="memberPasswordLabel" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="memberPasswordTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="firstNameLabel" runat="server" Text="First Name:"></asp:Label>
                <asp:TextBox ID="firstNameTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="lastNameLabel" runat="server" Text="Last name:"></asp:Label>
                <asp:TextBox ID="lastNameTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="phoneLabel" runat="server" Text="Phone Number:"></asp:Label>
                <asp:TextBox ID="phoneTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="emailLabel" runat="server" Text="Email:"></asp:Label>
                <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="addMemberButton" runat="server" OnClick="addMemberButton_Click" Text="Add New Member" />
                <br />
                <asp:Label ID="deleteMemberLabel" runat="server" Text="Selected Member ID:"></asp:Label>
                <asp:TextBox ID="deleteMemberTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="deleteMemberButton" runat="server" OnClick="deleteMemberButton_Click" Text="Delete Selected Member" />
            </td>
        </tr>
        <tr>
            <td>
                <h1>Instructors</h1>
                <br />
                <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="256px">
                    <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                    <RowStyle BackColor="White" ForeColor="#003399" />
                    <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SortedAscendingCellStyle BackColor="#EDF6F6" />
                    <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                    <SortedDescendingCellStyle BackColor="#D6DFDF" />
                    <SortedDescendingHeaderStyle BackColor="#002876" />
                </asp:GridView>
                <br />
            </td>
            <td>
                <asp:Label ID="instructorUserNameLabel" runat="server" Text="Username:"></asp:Label>
                <asp:TextBox ID="instructorUsernameTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="instructorPasswordLabel" runat="server" Text="Password:"></asp:Label>
                <asp:TextBox ID="instructorPasswordTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="instructorFNameLabel" runat="server" Text="First Name:"></asp:Label>
                <asp:TextBox ID="instructorFNameTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="instructorLNameLabel" runat="server" Text="Last Name:"></asp:Label>
                <asp:TextBox ID="instructorLNameTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Label ID="instructorPhoneLabel" runat="server" Text="Phone:"></asp:Label>
                <asp:TextBox ID="instructorPhoneTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="addInstructorButton" runat="server" OnClick="addInstructorButton_Click" Text="Add New Instructor" />
                <br />
                <asp:Label ID="deleteInstructorLabel" runat="server" Text="Selected Instructor ID:"></asp:Label>
                <asp:TextBox ID="deleteInstructorTextBox" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="deleteInstructorButton" runat="server" OnClick="deleteInstructorButton_Click" Text="Delete Selected Instructor" />
            </td>
        </tr>
    </table>
    <h1>Assign member to section</h1>
    <p>
        <table style="width:100%;">
            <tr>
                <td>
                    <asp:GridView ID="GridView3" runat="server">
                    </asp:GridView>
                </td>
                <td>Assign<br />
                    <asp:Label ID="assignMemberIDLabel" runat="server" Text="Member ID:"></asp:Label>
                    <asp:TextBox ID="assignMemberIDTextBox" runat="server"></asp:TextBox>
                    <br />
                    To<br />
                    <asp:Label ID="sectionIDLabel" runat="server" Text="Section ID:"></asp:Label>
                    <asp:TextBox ID="sectionIDTextBox" runat="server"></asp:TextBox>
                    <br />
                    <asp:Button ID="assignSessionButton" runat="server" OnClick="assignSessionButton_Click" Text="Assign" />
                </td>
            </tr>
        </table>
    </p>
    <p>
    </p>
</asp:Content>
