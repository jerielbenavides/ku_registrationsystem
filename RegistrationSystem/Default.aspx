<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="RegistrationSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
        <table >
            <tbody>
            <tr >
                <td >
                    <div align="center">
                        <asp:Label ID="choose_courses_label" runat="server" Text="Choose your courses" Font-Size="15pt"></asp:Label>
                    </div>

                </td>
                <td >
                    <div align="center">
                        <asp:Label ID="selected_courses_label" runat="server" Text="Selected courses" Font-Size="15pt"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr >
                <td >
                    <asp:Panel ID="AvailableCourses_Panel" runat="server" BackColor="white" Height="600px" ScrollBars="Auto">
                    </asp:Panel>
                </td>
                <td >
                    <asp:Panel ID="ChosenCourses_Panel" runat="server" BackColor="white" Height="600px" ScrollBars="Auto">

                    </asp:Panel>
                </td>
            </tr>
            </tbody>
        </table>

    </div>

</asp:Content>