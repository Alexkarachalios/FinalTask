<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create_account.aspx.cs" Inherits="FinalTask.create_account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        create_button {float:right;}
    </style>
</head>
<body style="height: 608px">
    <form id="form1" runat="server">
        <div style ="background-color:#077390; width:100%; height:71px">
        <h4 align="center" style="font-size:300%; height: 69px;">RENT-A-CAR </h4>
    </div>
            <h4 align="center" align="top" style="font-size:100%;">ΔΗΜΙΟΥΡΓΙΑ ΛΟΓΑΡΙΑΣΜΟΥ</h4>

            <asp:Label ID="first_name_label" runat="server" Text="First name :"></asp:Label>
            <asp:TextBox ID="first_text" float="right" runat="server" style="margin-left: 53px" OnTextChanged="first_text_TextChanged" Height="19px"></asp:TextBox><br>

           <asp:Label ID="last_name_label" runat="server" Text="Last name :"></asp:Label>
            <asp:TextBox ID="last_text" float="right" runat="server" style="margin-left: 53px; margin-top: 15px;" OnTextChanged="last_text_TextChanged" Height="19px" ></asp:TextBox><br>


           <asp:Label ID="username_label" runat="server" Text="Username :"></asp:Label>
            <asp:TextBox ID="username_text" float="right" runat="server" style="margin-left: 53px; margin-top: 15px;" OnTextChanged="username_text_TextChanged" Height="19px"></asp:TextBox><br>

           <asp:Label ID="password_label" runat="server" Text="Password :"></asp:Label>
            <asp:TextBox ID="password_text" float="right" runat="server" style="margin-left: 53px; margin-top: 15px;" OnTextChanged="password_text_TextChanged" Height="19px"></asp:TextBox>
        <p>
            &nbsp;</p>



            <p>



            <asp:Button ID="create_button" float="right" runat="server" Text="CREATE ACCOUNT" Width="132px" OnClick="create_button_Click" />
        </p>
        <p>
            &nbsp;</p>



    </form>
</body>
</html>
