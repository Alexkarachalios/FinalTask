﻿
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="choice.aspx.cs" Inherits="FinalTask.choice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-image:url('Content/Themes/car.png'); background-repeat:no-repeat; background-size:100% 210%;">
    <form id="form1" runat="server">
         <div style ="background-color:#077390; width:100%; height:71px">
        <h4 align="center" style="font-size:300%; height: 69px;">RENT-A-CAR </h4>
    </div>
         <p>
             <asp:Label style="background-color:#077390; font-size:110%" ID="Label1" runat="server" Text="Label"></asp:Label>
         </p>
         <p align="center">
             <asp:Button  ID="Search" runat="server" OnClick="Search_Click" style="margin-left: 0px" Text="Search a Car" Width="202px" Height="48px" />
         </p>
         <p>
             &nbsp;</p>
         <p align="center">
             <asp:Button  ID="NewEntry" runat="server" OnClick="NewEntry_Click" style="margin-left: 0px" Text="My Car" Width="202px" Height="48px" />
         </p>
         <p align="center">
             &nbsp;</p>
         <p align="center">
             <asp:Button  ID="MyAccount" runat="server" OnClick="MyAccount_Click" style="margin-left: 0px" Text="My Account" Width="202px" Height="48px" />
         </p>
         <p align="center">
             <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Logout" />
         </p>
    </form>
</body>
</html>
