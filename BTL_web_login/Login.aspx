<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BTL_web_login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login</title>
    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            font-family: Arial, sans-serif;
            background-color: #f8f8f8;
        }
        .container {
            display: flex;
            width: 800px;
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
            overflow: hidden;
        }
        .left-panel {
            background-image: url('https://source.unsplash.com/random/400x600');
            background-size: cover;
            background-position: center;
            width: 50%;
        }
        .right-panel {
            padding: 40px;
            width: 50%;
            display: flex;
            flex-direction: column;
            justify-content: center;
        }
        .right-panel h2 {
            margin-bottom: 10px;
            color: #333;
            font-size: 36px;
            text-align: center;
        }
        .right-panel p {
            margin-bottom: 10px;
            color: #777;
            font-size: 14px;
            text-align: center;
        }
        .right-panel .subtitle {
            margin-bottom: 20px;
            color: #333;
            font-size: 18px;
            font-weight: bold;
            text-align: center;
        }
        .form-group {
            margin-bottom: 20px;
            width: 100%;
        }
        .form-group label {
            display: block;
            margin-bottom: 5px;
            color: #555;
        }
        .form-group input {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ddd;
            border-radius: 5px;
        }
        .form-group input[type="submit"] {
            background-color: #7b69ee;
            color: #fff;
            border: none;
            cursor: pointer;
        }
        .form-group input[type="submit"]:hover {
            background-color: #684ce1;
        }
        .link {
            text-align: center;
            margin-top: 10px;
        }
        .link a {
            color: #7b69ee;
            text-decoration: none;
        }
        .link a:hover {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="formLogin" runat="server">
        <div class="container">
            <div class="left-panel"></div>
            <div class="right-panel">
                <h2>BookHub</h2>
                <p class="subtitle">Welcome back! Login to your account</p>
                <div class="form-group">
                    <label for="email">E-mail</label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="john@mail.com" Required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="password">Password</label>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="btnLogin_Click" />
                </div>
                <div class="link">
                    <a href="Register.aspx">Create an account</a>
                </div>
                <asp:Literal ID="litMessage" runat="server"></asp:Literal>
            </div>
        </div>
    </form>
</body>
</html>
