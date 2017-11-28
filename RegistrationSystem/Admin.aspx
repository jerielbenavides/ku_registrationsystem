<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.vb" Inherits="RegistrationSystem.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <asp:Label ID="AddStudent" runat="server" Text="Add Student" ForeColor="White" Font-Size="15pt"></asp:Label>
            <table style="width: 100%;" >
                <tr>
                    <td style="width: 250px"> <asp:Label ID="ID_lb" runat="server" Text="ID" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px"><input type="number" name="id_tb" maxlength="7"  /></td>
                   
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="Username_lb" runat="server" Text="Username" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px"><input name="username_tb" style="width: 150px"/></td>
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="First_lb" runat="server" Text="First Name" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px"><input name="first_tb" style="width: 150px"/></td>
                   
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="Middle_lb" runat="server" Text="Middle Name" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px"><input name="middle_tb" style="width: 150px"/></td>
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="Last_lb" runat="server" Text="Last Name" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px"><input name="last_tb" style="width: 150px"/></td>
                   
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="Address_lb" runat="server" Text="Address" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px"><input name="address_tb" style="width: 150px"/></td>
                    </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="Phone_lb" runat="server" Text="Phone" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px"><input name="phone_tb" type="tel" style="width: 150px"/></td>
                   
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="Country_tb" runat="server" Text="Country" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px"><input name="country_tb" style="width: 150px"/></td>
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="City_tb" runat="server" Text="City" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px"><input name="city_tb" style="width: 150px"/></td>
                   
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="State_lb" runat="server" Text="State" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px"><input name="state_tb" style="width: 150px"/></td>
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="ZIP_lb" runat="server" Text="ZIP" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px; height: 20px;"> <input name="zip_tb" type="number" style="width: 150px"/></td>
                   
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="BD_lb" runat="server" Text="Birthdate" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px"><input name="bd_tb" type="date" style="width: 150px"/></td>
                </tr>
                <tr>
                    <td style="width: 250px"> <asp:Label ID="Major_lb" runat="server" Text="Major" ForeColor="White" Font-Size="10pt"></asp:Label> </td>
                    <td style="width: 670px">
                        <select id="major_select">
                            <option value="Business Administration">Business Administration</option>
                            <option value="Interdisciplinary Studies">Interdisciplinary Studies</option>
                            <option value="Management Information Systems">Management Information Systems</option>
                            <option value="Political Science">Political Science</option>
                            <option value="Psychology">Psychology</option>
                            <option value="Software Engineering">Software Engineering</option>
                        </select>
  
                    </td>
                   
                </tr>
                <tr>
                    <td style="width: 250px">
                        <br/>
                        <asp:Button ID="AddStudent_bttn" runat="server" BackColor="#032e66" ForeColor="White" BorderColor="White" Text="Add Student" />
                    </td>
                    <td style="width: 670px">&nbsp;</td>
                </tr>
            </table>
        </div>
    
    <div>
            
    </div>
</asp:Content>