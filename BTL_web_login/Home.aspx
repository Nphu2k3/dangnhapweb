<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BTL_web_login.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Welcome to BookHub!</h1>
            <p>This is the home page.</p>
            <asp:Literal ID="lblUserInfo" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
