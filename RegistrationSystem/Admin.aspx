<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.vb" Inherits="RegistrationSystem.Contact" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=17.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=17.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <table style="width: 100%;" >
                <tr>
                    <td style="width: 283px"><asp:Label ID="AddStudent" runat="server" Text="Add Student" ForeColor="White" Font-Size="15pt"></asp:Label> </td>
                    <td style="width: 663px"><asp:Label ID="MessageLabel" runat="server" Text="" ForeColor="Black" BackColor="white" Font-Size="9pt"></asp:Label></td>
                    <td style="width: 308px"><asp:Label ID="DeleteStudent" runat="server" Text="Delete Student" ForeColor="White" Font-Size="15pt"></asp:Label></td>
                    <td style="width: 472px"><asp:Label ID="MessageLabel2" runat="server" Text="" ForeColor="Black" BackColor="white" Font-Size="9pt"></asp:Label></td>            
                </tr>
                <tr>
                    <td style="width: 283px"> <asp:Label ID="ID_lb" runat="server" Text="ID" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 663px">
                        <asp:TextBox ID="id_tb" runat="server" MaxLength="7"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="id_tb_FilteredTextBoxExtender" runat="server"
                                                     Enabled="True" TargetControlID="id_tb" FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td style="width: 308px"> <asp:Label ID="ID_lb2" runat="server" Text="ID" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                     <td style="width: 120px">  
                        <asp:TextBox ID="id_tb0" runat="server" MaxLength="7"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="id_tb0_FilteredTextBoxExtender" runat="server"
                                                     Enabled="True" TargetControlID="id_tb0" FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td style="width: 472px"></td>
                    <td style="width: 300px">  </td>
                   
                </tr>
                <tr>
                    <td style="width: 283px"> <asp:Label ID="Username_lb" runat="server" Text="Username" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 663px">
                        <asp:TextBox ID="username_tb" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td style="width: 308px"> <asp:Label ID="Username_lb2" runat="server" Text="Username" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 300px">  
                        <asp:TextBox ID="username_tb0" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td style="width: 472px">  </td>
                </tr>
                <tr>
                    <td style="width: 283px"> <asp:Label ID="First_lb" runat="server" Text="First Name" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 663px">
                        <asp:TextBox ID="first_tb" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td style="width: 308px">  
                        <asp:Button ID="DeleteStudent_bttn" runat="server" BackColor="#032e66" ForeColor="White" BorderColor="White" Text="Delete Student" OnClick="DeleteStudent_OnClickStudent_bttn_OnClick"/>
                    </td>
                    <td style="width: 472px">  </td>
                   
                </tr>
                <tr>
                    <td style="width: 283px"> <asp:Label ID="Middle_lb" runat="server" Text="Middle Name" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 663px">
                        <asp:TextBox ID="middle_tb" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td style="width: 308px">  </td>
                    <td style="width: 472px">  </td>
                </tr>
                <tr>
                    <td style="width: 283px"> <asp:Label ID="Last_lb" runat="server" Text="Last Name" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 663px">
                        <asp:TextBox ID="last_tb" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td style="width: 308px">  </td>
                    <td style="width: 472px">  </td>
                </tr>
                <tr>
                    <td style="width: 283px"> <asp:Label ID="Address_lb" runat="server" Text="Address" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 663px">
                        <asp:TextBox ID="address_tb" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td style="width: 308px">  </td>
                    <td style="width: 472px">  </td>
                    </tr>
                <tr>
                    <td style="width: 283px"> <asp:Label ID="Phone_lb" runat="server" Text="Phone" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 663px">
                        <asp:TextBox ID="phone_tb" runat="server" Width="150" MaxLength="20"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                     Enabled="True" TargetControlID="phone_tb" FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td style="width: 308px">  </td>
                    <td style="width: 472px">  </td>
                </tr>
                <tr>
                    <td style="width: 283px"> <asp:Label ID="country_lb" runat="server" Text="Country" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 663px">
                        <asp:TextBox ID="country_tb" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td style="width: 308px">  </td>
                    <td style="width: 472px">  </td>
                    </tr>
                <tr>
                    <td style="width: 283px"> <asp:Label ID="City_lb" runat="server" Text="City" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 663px">
                        <asp:TextBox ID="city_tb" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td style="width: 308px">  </td>
                    <td style="width: 472px">  </td>
                </tr>
                <tr>
                    <td style="width: 283px"> <asp:Label ID="State_lb" runat="server" Text="State" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 663px">
                        <asp:TextBox ID="state_tb" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td style="width: 308px">  </td>
                    <td style="width: 472px">  </td>
                </tr>
                <tr>
                    <td style="width: 283px"> <asp:Label ID="ZIP_lb" runat="server" Text="ZIP" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 663px">
                        <asp:TextBox ID="ZIP_tb" runat="server" Width="150"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                     Enabled="True" TargetControlID="ZIP_tb" FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td style="width: 308px">  </td>
                    <td style="width: 472px">  </td>
                </tr>
                <tr>
                    <td style="width: 283px"> <asp:Label ID="BD_lb" runat="server" Text="Birthdate" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 663px">
                        <asp:TextBox ID="BirthDate_tb" runat="server" Width="150"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="BirthDate_tb"/>
                    </td>
                    <td style="width: 308px">  </td>
                    <td style="width: 472px">  </td>
                </tr>
                <tr>
                    <td style="width: 283px"> <asp:Label ID="Major_lb" runat="server" Text="Major" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 663px">
                        <ajaxToolkit:ComboBox ID="major_tb" runat="server">
                            <asp:ListItem Text="Business Administration"/>
                            <asp:ListItem Text="Interdisciplinary Studies"/>
                            <asp:ListItem Text="Management Information Systems"/>  
                            <asp:ListItem Text="Political Science"/>
                            <asp:ListItem Text="Psychology"/>
                            <asp:ListItem Text="Software Engineering"/>
                        </ajaxToolkit:ComboBox>
                    </td>
                    <td style="width: 308px">  </td>
                    <td style="width: 472px">  </td>
                </tr>
                <tr>
                    <td style="width: 283px">
                        <br/>
                        <asp:Button ID="AddStudent_bttn" runat="server" BackColor="#032e66" ForeColor="White" BorderColor="White" Text="Add Student" OnClick="AddStudent_bttn_OnClick"/>
                    </td>
                    <td style="width: 663px">&nbsp;</td>
                    <td style="width: 308px">  </td>
                    <td style="width: 472px">  </td>
                </tr>

            </table>
        </div>
    
    <div>
            
    </div>
</asp:Content>