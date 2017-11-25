<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="RegistrationSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="<%=ResolveUrl("~/Content/footer.css")%>" rel="stylesheet" type="text/css"/>
</head>
<body style="background-color: #1F67A6">
<form runat="server">
    <asp:Panel ID="TopPanel" BackColor="#1F67A6" runat="server">
        <br/>
        <br/>

        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/index.png"/>

        <br/>
        <br/>
    </asp:Panel>
    <asp:Panel ID="Panel1" BackImageUrl="http://v.fastcdn.co/u/7051b178/18412031-0-Grad-School-Instapag.jpg" runat="server">
        <br/>
        <br/>
        &nbsp;
        <asp:Panel runat="server" ForeColor="White" Height="277px" style="margin-left: 793px; margin-top: 0px" Width="464px">
            <asp:Panel ID="Panel2" runat="server" Font-Size="20pt">
                WELCOME TO THE REGISTRATION PORTAL
            </asp:Panel>
            <br/>
            Username:<br/>
            <asp:TextBox ID="usernametb" runat="server"></asp:TextBox>
            <br/>
            <br/>
            Password (ID):<br/>
            <asp:TextBox ID="passwordtb" type="password" runat="server"></asp:TextBox>
            <br/>
            <br/>
            <asp:Button ID="Button1" runat="server" Text="Login"/>
            <br/>
            <br/>
            <asp:Label ID="login_result" runat="server"></asp:Label>
            <br/>
            <br/>
            <br/>
        </asp:Panel>
        <br/>
        <br/>
        <br/>
    </asp:Panel>
</form>
<div id="Footer">Version 1.0</div>
</body>
</html>