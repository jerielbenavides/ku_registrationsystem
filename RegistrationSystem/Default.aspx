<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="RegistrationSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
        <table >
            <tbody>
            <tr >
                <td style="height: 50px" >
                    <div align="center">
                        <asp:Label ID="choose_courses_label" runat="server" Text="Choose your courses" Font-Size="15pt"></asp:Label>
                    </div>

                </td>
                <td style="height: 50px" >
                    <div align="center">
                        <asp:Label ID="selected_courses_label" runat="server" Text="Selected courses" Font-Size="15pt"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr >
                <td colspan="2">
                    <div align="center">
                        <asp:Label ID="MessageLabel" runat="server" align="center" Text="Label"></asp:Label>
                    </div>
                
                </td>
                <td>&nbsp;</td>
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
    <div >
    </div>
    <div align="center">
        <asp:Button ID="Printbttn" BorderWidth="2px"  runat="server" Text="Print Schedule" ForeColor="white" BackColor="#032e66" OnClick="Printbttn_OnClick" />
    </div>
    <div align="center">
        <asp:PlaceHolder ID = "PlaceHolder1" runat="server" />
    </div>
    


</asp:Content>