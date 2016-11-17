<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Project5.Account.NewLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
    <div>
        &nbsp;
    </div>
    <p>
        <asp:Label ID="username_lbl" runat="server" Text="Username"></asp:Label>
        <asp:TextBox ID="userName_txt" runat="server"></asp:TextBox>
        </p>
    <p>
        <asp:Label ID="password_lbl" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="passWord_txt" runat="server"></asp:TextBox>
        </p>
    <p>
        <asp:Label ID="result_lbl" runat="server"></asp:Label>
        </p>
        <asp:Button ID="login_btn" runat="server" Text="Sign in" />
    </form>
    </body>
</html>
