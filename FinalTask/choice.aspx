<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="choice.aspx.cs" Inherits="FinalTask.choice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-image:url('Content/Themes/car.png');">
    <form id="form1" runat="server">
         <div style ="background-color:#077390; width:100%; height:71px">
        <h4 align="center" style="font-size:300%; height: 69px;">RENT-A-CAR </h4>
    </div>
         <p>
             &nbsp;</p>
         <p>
             &nbsp;</p>
         <p align="center">
             <asp:Button  ID="Search" runat="server" OnClick="Button1_Click" style="margin-left: 0px" Text="Search" Width="202px" Height="48px" />
         </p>
         <p>
             &nbsp;</p>
         <p align="center">
             <asp:Button  ID="NewEntry" runat="server" OnClick="Button1_Click" style="margin-left: 0px" Text="New Entry" Width="202px" Height="48px" />
         </p>
    </form>
</body>
</html>
