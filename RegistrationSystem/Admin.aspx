<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.vb" Inherits="RegistrationSystem.Contact" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=17.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=17.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <asp:Label ID="AddStudent" runat="server" Text="Add Student" ForeColor="White" Font-Size="15pt"></asp:Label>
            <table style="width: 100%;" >
                <tr>
                    <td style="width: 250px"> <asp:Label ID="ID_lb" runat="server" Text="ID" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px">
                        <asp:TextBox ID="id_tb" runat="server" MaxLength="7"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="id_tb_FilteredTextBoxExtender" runat="server"
                                                     Enabled="True" TargetControlID="id_tb" FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                    </td>
                   
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="Username_lb" runat="server" Text="Username" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px">
                        <asp:TextBox ID="username_tb" runat="server" Width="150"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="First_lb" runat="server" Text="First Name" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px">
                        <asp:TextBox ID="first_tb" runat="server" Width="150"></asp:TextBox>
                    </td>

                   
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="Middle_lb" runat="server" Text="Middle Name" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px">
                        <asp:TextBox ID="middle_tb" runat="server" Width="150"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="Last_lb" runat="server" Text="Last Name" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px">
                        <asp:TextBox ID="last_tb" runat="server" Width="150"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="Address_lb" runat="server" Text="Address" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px">
                        <asp:TextBox ID="address_tb" runat="server" Width="150"></asp:TextBox>
                    </td>
                    </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="Phone_lb" runat="server" Text="Phone" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px">
                        <asp:TextBox ID="phone_tb" runat="server" Width="150" MaxLength="20"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                     Enabled="True" TargetControlID="phone_tb" FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                    </td>
                   
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="country_lb" runat="server" Text="Country" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px">
                        <asp:TextBox ID="country_tb" runat="server" Width="150"></asp:TextBox>
                    </td>
                    </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="City_lb" runat="server" Text="City" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px">
                        <asp:TextBox ID="city_tb" runat="server" Width="150"></asp:TextBox>
                    </td>
                   
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="State_lb" runat="server" Text="State" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px">
                        <asp:TextBox ID="state_tb" runat="server" Width="150"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="ZIP_lb" runat="server" Text="ZIP" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px">
                        <asp:TextBox ID="ZIP_tb" runat="server" Width="150"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                     Enabled="True" TargetControlID="ZIP_tb" FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                    </td>
                   
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="BD_lb" runat="server" Text="Birthdate" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px">
                        <asp:TextBox ID="BirthDate_tb" runat="server" Width="150"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="BirthDate_tb"/>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="Major_lb" runat="server" Text="Major" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px">
                        <ajaxToolkit:ComboBox ID="major_tb" runat="server">
                            <asp:ListItem Text="Business Administration"/>
                            <asp:ListItem Text="Interdisciplinary Studies"/>
                            <asp:ListItem Text="Management Information Systems"/>  
                            <asp:ListItem Text="Political Science"/>
                            <asp:ListItem Text="Psychology"/>
                            <asp:ListItem Text="Software Engineering"/>
                        </ajaxToolkit:ComboBox>
                    </td>
                   
                </tr>
                <tr>
                    <td style="width: 250px">
                        <br/>
                        <asp:Button ID="AddStudent_bttn" runat="server" BackColor="#032e66" ForeColor="White" BorderColor="White" Text="Add Student" OnClick="AddStudent_bttn_OnClick"/>
                    </td>
                    <td style="width: 670px">&nbsp;</td>
                </tr>
            </table>
        </div>
    
    <div>
            
    </div>
</asp:Content>