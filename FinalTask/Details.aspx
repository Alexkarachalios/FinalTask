<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="FinalTask.Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        #add_button {
            margin-left: 96px;
        }
    </style>
</head>
<body style="background-image: url('Content/Themes/car.png')">
    <form id="form1" runat="server">
        <div style="height: 42px">
            <h4 align="center" style="font-size:300%; height: 69px;">Details</h4>
        </div>
        <p>
            &nbsp;</p>
    <div style="height: 287px; width: 246px; float:left;">
        <asp:Label ID="Label1" runat="server" Text="Car information:" Font-Bold="true" Font-Size="Large"></asp:Label>
    <p>
        Car model : 
        <asp:TextBox ID="model_text" runat="server" style="margin-left: 22px" Width="120px" Enabled="False"></asp:TextBox>
        </p>
    <p>
        Cc : 
        <asp:TextBox ID="cc_text" runat="server" style="margin-left: 71px" Width="120px" Enabled="False"></asp:TextBox>
        </p>
    <p>
        Total km : 
        <asp:TextBox ID="km_text" runat="server" style="margin-left: 31px" Width="120px" Enabled="False"></asp:TextBox>
        </p>
    <p>
        Year : 
        <asp:TextBox ID="year_text" runat="server" style="margin-left: 59px" Width="120px" Enabled="False"></asp:TextBox>
        </p>
    <p>
        Price per day : 
        <asp:TextBox ID="price_text" runat="server" Width="120px" Enabled="False"></asp:TextBox>
    </p>
    <br />
        
        <asp:Button ID="add_button" runat="server" OnClick="contact_button_Click" Text="Contact owner" Width="127px" />
    </div>



        <div style="height: 287px; width: 270px; float:right;">

            <asp:Label ID="owner" runat="server" Font-Bold="true" Font-Size="Large" ></asp:Label>

            <br />
            <br />
            <br />
            <br />

            <p style="float:right;">
        Owner name : 
        <asp:TextBox ID="oname" runat="server" style="margin-right: 25px" Width="120px" Enabled="False"></asp:TextBox>
        </p>            

            <br />
            <br />
            <br />

    <p style="float:right;">
        Owner lastname : 
        <asp:TextBox ID="olastname" runat="server" style="margin-right: 25px" Width="120px" Enabled="False"></asp:TextBox>
        </p>

            <br />
            <br />
            <br />

    <p style="float:right;">
        Owner rating : 
        <asp:TextBox ID="oarating" runat="server" style="margin-right: 25px" Width="120px" Enabled="False"></asp:TextBox>
        </p>

        </div>
        
        <p style="float: right">
        
        <asp:Image ID="Image1" runat="server" Width="274px" align="Right" />
        </p>
    </form>
    </body>
</html>
