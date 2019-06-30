<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FinalTask.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-image:url('Content/Themes/car.png'); background-repeat:no-repeat; background-size:100% 100%;">
    <form id="form1" runat="server">
       <div style="background-color:#077390; width:100%; height:71px" >
           <h4 align="center" align="top" style="font-size:400%;">RENT-A-CAR</h4>
       </div>
        
        <p style="width: 100px; font-size:130%; margin-bottom: 20px;">
            Username :<asp:TextBox ID="username_text" runat="server" style="margin-bottom: 4px" Width="128px" OnTextChanged="username_text_TextChanged"></asp:TextBox>
        </p>
        <p style="width: 100px; font-size:130%; height: 20px; margin-bottom: 38px;">
            Password :<asp:TextBox ID="password_text" runat="server" OnTextChanged="TextBox2_TextChanged" TextMode="Password" Width="140px" Height="16px" style="margin-left: 1px; margin-bottom: 0px;"></asp:TextBox>
        </p>
        <asp:Button ID="login_button" runat="server" Text="LOGIN" OnClick="login_button_Click" Height="31px" Width="67px" />

        <p>
            Νέος χρήστης?<asp:Button ID="create_account_button" runat="server" OnClick="create_account_button_Click" style="margin-left: 11px" Text="CREATE ACCOUNT" />
        </p>
    </form>
</body>
</html>
