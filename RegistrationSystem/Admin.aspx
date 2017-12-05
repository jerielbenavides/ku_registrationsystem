<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.vb" Inherits="RegistrationSystem.Contact" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=17.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=17.1.1.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <table style="width: 100%;" >
                <tr>
                    <td style="width: 283px">
                        <asp:Button ID="AddStudent_Label" runat="server" Font-Size="12" BackColor="#032e66" ForeColor="White" BorderColor="#032e66" Text="Add Student" OnClick="AddStudent_Label_OnClick" BorderStyle="None" Width="111px"/>
                    </td>
                    <td style="width: 419px"><asp:Label ID="MessageLabel" runat="server" Text="" ForeColor="Black" BackColor="white" Font-Size="9pt"></asp:Label></td>
                    <td style="width: 289px" class="modal-sm">
                        <asp:Button ID="DeleteStudent_Label" runat="server" BackColor="#032e66" BorderColor="#032e66" BorderStyle="None" Font-Size="12" ForeColor="White" OnClick="DeleteStudent_Label_OnClick" Text="Delete Student" Width="133px" />
                    </td>
                    <td style="width: 278px" class="modal-sm"></td>  
                    <td style="width: 341px">
                        <asp:Button ID="DisplayTables_lb" runat="server" BackColor="#032e66" BorderColor="#032e66" BorderStyle="None" Font-Size="12" ForeColor="White" OnClick="DisplayTables_lb_OnClick" Text="Display Tables" Width="130px" />
                    </td>

                </tr>
                <tr>
                    <td style="width: 283px"> <asp:Label ID="ID_lb" runat="server" Text="ID" ForeColor="White" Font-Size="10pt" Visible="False"></asp:Label> </td>
                    <td style="width: 419px">
                        <asp:TextBox ID="id_tb" runat="server" MaxLength="7" Visible="False"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="id_tb_FilteredTextBoxExtender" runat="server"
                                                     Enabled="True" TargetControlID="id_tb" FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td style="width: 289px" class="modal-sm"> <asp:Label ID="ID_lb2" Visible="False" runat="server" Text="ID" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                     <td style="width: 278px" class="modal-sm">  
                        <asp:TextBox ID="id_tb0" runat="server" MaxLength="7" Visible="False"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="id_tb0_FilteredTextBoxExtender" runat="server"
                                                     Enabled="True" TargetControlID="id_tb0" FilterType="Numbers">
                        </asp:FilteredTextBoxExtender>
                    </td>
                    <td style="width: 341px"> <asp:Label ID="ID_lb3" Visible="False" runat="server" Text="Choose Table" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 300px">  
                        <ajaxToolkit:ComboBox ID="TableComboBox" Visible="False" runat="server" AutoCompleteMode="Suggest">
                            <asp:ListItem Value="student_information">Student Information</asp:ListItem>
                            <asp:ListItem Value="courses_spring_2018">Courses Spring 2018</asp:ListItem>
                            <asp:ListItem Value="all_courses">All Courses</asp:ListItem>
                        </ajaxToolkit:ComboBox>
                    </td>
                    
                   
                </tr>
                <tr>
                    <td style="width: 283px"> <asp:Label ID="Username_lb" Visible="False" runat="server" Text="Username" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 419px">
                        <asp:TextBox ID="username_tb" Visible="False" runat="server" Width="150"></asp:TextBox>
                    </td>
                    <td style="width: 289px" class="modal-sm"> <asp:Label ID="Username_lb2" Visible="False" runat="server" Text="Username" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 278px" class="modal-sm">  
                        <asp:TextBox ID="username_tb0" runat="server" Width="150" Visible="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 341px">
                    </td>
                    <td style="width: 300px">
                        <asp:PlaceHolder ID="PlaceHolder2" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 283px">
                        <asp:Label ID="First_lb" runat="server" Font-Size="10pt" ForeColor="White" Text="First Name" Visible="False"></asp:Label>
                    </td>
                    <td style="width: 419px">
                        <asp:TextBox ID="first_tb" runat="server" Visible="False" Width="150"></asp:TextBox>
                    </td>
                    <td style="width: 341px">
                        <asp:Button ID="DeleteStudent_bttn" Visible="False" runat="server" BackColor="#032e66" BorderColor="White" ForeColor="White" OnClick="DeleteStudent_OnClickStudent_bttn_OnClick" Text="Delete Student" />                        
                    </td>
                    <td style="width: 300px"></td>
                    <td class="modal-sm" style="width: 289px">
                    <asp:Button ID="Print_bttn" Visible="False" runat="server" BackColor="#032e66" BorderColor="White" ForeColor="White" OnClick="Print_bttn_OnClick" Text="Print Table" />
                        
                    </td>

                    <caption>
                        &nbsp;<tr>
                            <td class="modal-sm" style="width: 278px"></td>
                            <td style="width: 341px"></td>
                            <td class="modal-sm" style="width: 289px"></td>
                            <td style="width: 341px"></td>
                            <td style="width: 300px"></td>
                        </tr>
                        <tr>
                            <td style="width: 283px">
                                <asp:Label ID="Middle_lb" runat="server" Font-Size="10pt" ForeColor="White" Text="Middle Name" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 419px">
                                <asp:TextBox ID="middle_tb" runat="server" Visible="False" Width="150"></asp:TextBox>
                            </td>
                            <td colspan="2" style="width: 308px"></td>
                            <td class="modal-sm" colspan="2" style="width: 278px"></td>
                            <td style="width: 341px"></td>
                            <td style="width: 300px"></td>
                        </tr>
                        <tr>
                            <td style="width: 283px">
                                <asp:Label ID="Last_lb" runat="server" Font-Size="10pt" ForeColor="White" Text="Last Name" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 419px">
                                <asp:TextBox ID="last_tb" runat="server" Visible="False" Width="150"></asp:TextBox>
                            </td>
                            <td class="modal-sm" style="width: 289px"></td>
                            <td class="modal-sm" style="width: 278px"></td>
                            <td style="width: 341px"></td>
                            <td style="width: 300px"></td>
                        </tr>
                        <tr>
                            <td style="width: 283px">
                                <asp:Label ID="Address_lb" runat="server" Font-Size="10pt" ForeColor="White" Text="Address" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 419px">
                                <asp:TextBox ID="address_tb" runat="server" Visible="False" Width="150"></asp:TextBox>
                            </td>
                            <td class="modal-sm" style="width: 289px"></td>
                            <td class="modal-sm" style="width: 278px"></td>
                            <td style="width: 341px"></td>
                            <td style="width: 300px"></td>
                        </tr>
                        <tr>
                            <td style="width: 283px">
                                <asp:Label ID="Phone_lb" runat="server" Font-Size="10pt" ForeColor="White" Text="Phone" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 419px">
                                <asp:TextBox ID="phone_tb" runat="server" MaxLength="20" Visible="False" Width="150"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="phone_tb" />
                            </td>
                            <td colspan="2" style="width: 308px">
                                <asp:Label ID="MessageLabel2" runat="server" BackColor="white" Font-Size="9pt" ForeColor="Black" Text=""></asp:Label>
                            </td>
                            <td class="modal-sm" colspan="2" style="width: 278px">
                                <asp:Label ID="MessageLabel3" runat="server" BackColor="white" Font-Size="9pt" ForeColor="Black" Text=""></asp:Label>
                            </td>
                            <td style="width: 341px"></td>
                            <td style="width: 300px"></td>
                        </tr>
                        <tr>
                            <td style="width: 283px">
                                <asp:Label ID="country_lb" runat="server" Font-Size="10pt" ForeColor="White" Text="Country" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 419px">
                                <asp:TextBox ID="country_tb" runat="server" Visible="False" Width="150"></asp:TextBox>
                            </td>
                            <td class="modal-sm" style="width: 289px"></td>
                            <td class="modal-sm" style="width: 278px"></td>
                            <td style="width: 341px"></td>
                            <td style="width: 300px"></td>
                        </tr>
                        <tr>
                            <td style="width: 283px">
                                <asp:Label ID="City_lb" runat="server" Font-Size="10pt" ForeColor="White" Text="City" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 419px">
                                <asp:TextBox ID="city_tb" runat="server" Visible="False" Width="150"></asp:TextBox>
                            </td>
                            <td class="modal-sm" style="width: 289px"></td>
                            <td class="modal-sm" style="width: 278px"></td>
                            <td style="width: 341px"></td>
                            <td style="width: 300px"></td>
                        </tr>
                        <tr>
                            <td style="width: 283px; height: 24px;">
                                <asp:Label ID="State_lb" runat="server" Font-Size="10pt" ForeColor="White" Text="State" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 419px; height: 24px;">
                                <asp:TextBox ID="state_tb" runat="server" Visible="False" Width="150"></asp:TextBox>
                            </td>
                            <td style="width: 289px; height: 24px;"></td>
                            <td class="modal-sm" style="width: 278px; height: 24px;"></td>
                            <td style="width: 341px; height: 24px;"></td>
                            <td style="width: 300px; height: 24px;"></td>
                        </tr>
                        <tr>
                            <td style="width: 283px">
                                <asp:Label ID="ZIP_lb" runat="server" Font-Size="10pt" ForeColor="White" Text="ZIP" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 419px">
                                <asp:TextBox ID="ZIP_tb" runat="server" Visible="False" Width="150"></asp:TextBox>
                                <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="ZIP_tb" />
                            </td>
                            <td class="modal-sm" style="width: 289px"></td>
                            <td class="modal-sm" style="width: 278px"></td>
                            <td style="width: 341px"></td>
                            <td style="width: 300px"></td>
                        </tr>
                        <tr>
                            <td style="width: 283px">
                                <asp:Label ID="BD_lb" runat="server" Font-Size="10pt" ForeColor="White" Text="Birthdate" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 419px">
                                <asp:TextBox ID="BirthDate_tb" runat="server" Visible="False" Width="150"></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="BirthDate_tb" />
                            </td>
                            <td class="modal-sm" style="width: 289px"></td>
                            <td class="modal-sm" style="width: 278px"></td>
                            <td style="width: 341px"></td>
                            <td style="width: 300px"></td>
                        </tr>
                        <tr>
                            <td style="width: 283px">
                                <asp:Label ID="Major_lb" runat="server" Font-Size="10pt" ForeColor="White" Text="Major" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 419px">
                                <cc1:ComboBox ID="major_tb" runat="server" AutoCompleteMode="Suggest" Visible="False">
                                    <asp:ListItem Text="Business Administration" />
                                    <asp:ListItem Text="Interdisciplinary Studies" />
                                    <asp:ListItem Text="Management Information Systems" />
                                    <asp:ListItem Text="Political Science" />
                                    <asp:ListItem Text="Psychology" />
                                    <asp:ListItem Text="Software Engineering" />
                                </cc1:ComboBox>
                            </td>
                            <td class="modal-sm" style="width: 289px"></td>
                            <td class="modal-sm" style="width: 278px"></td>
                            <td style="width: 341px"></td>
                            <td style="width: 300px"></td>
                        </tr>
                        <tr>
                            <td style="width: 283px">
                                <br/>
                                <asp:Button ID="AddStudent_bttn" runat="server" BackColor="#032e66" BorderColor="White" ForeColor="White" OnClick="AddStudent_bttn_OnClick" Text="Add Student" Visible="False" />
                            </td>
                            <td style="width: 419px">&nbsp;</td>
                            <td class="modal-sm" style="width: 289px"></td>
                            <td class="modal-sm" style="width: 278px"></td>
                            <td style="width: 341px"></td>
                            <td style="width: 300px"></td>
                        </tr>
                    </caption>
                </tr>

            </table>
        </div>
    
    <div>
            
    </div>
</asp:Content>

