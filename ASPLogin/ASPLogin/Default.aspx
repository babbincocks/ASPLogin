<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPLogin.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="main.css" rel="stylesheet" />
</head>
<body style="height: 213px">
    <form id="form1" runat="server">
        <div>
        <asp:Panel ID="Panel1" runat="server" BorderStyle="Solid" BorderWidth="1px" Height="263px">
            
                <p>
                    Login</p>
                <p>
                    <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox>
                </p>
                <br/>
                <p>
                    Password</p>
                <p>
                    <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
                </p>
            
                <p>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem>Desktop Window</asp:ListItem>
                        <asp:ListItem>Desktop Door</asp:ListItem>
                        <asp:ListItem>Laptop</asp:ListItem>
                    </asp:RadioButtonList>
                </p>
                <p>
                    &nbsp;</p>
                <p>
                    <asp:TextBox ID="txtLoginAttempts" runat="server"></asp:TextBox>
                    <asp:Label ID="Label1" runat="server" Text="# of Login Attempts"></asp:Label>
                </p>
            
        </asp:Panel>
            </div>
    </form>
</body>
</html>
