<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new_entry.aspx.cs" Inherits="FinalTask.new_entry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Text1 {
            width: 150px;
            margin-left: 28px;
        }
        #Text2 {
            margin-left: 77px;
            width: 149px;
        }
        #Text3 {
            margin-left: 36px;
            width: 150px;
        }
        #Text4 {
            margin-left: 62px;
            width: 150px;
        }
        #Text5 {
            margin-left: 8px;
            width: 150px;
        }
        #Button1 {
            margin-left: 0px;
        }
        #add_button {
            margin-left: 96px;
        }
        #Button2 {
            margin-left: 77px;
        }
        #add_button0 {
            margin-left: 96px;
        }
        </style>
</head>
<body style="background-image:url('Content/Themes/car.png'); background-size:100% 100%;">
    <form id="form1" runat="server">
        <div style="height: 42px">
            <h4 align="center" style="font-size:300%; height: 69px;">ADD A CAR FOR RENTAL</h4>
        </div>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    <div style="height: 395px; width: 313px; float:left">
    <p>
        Car model : 
        <asp:TextBox ID="model_text" runat="server" style="margin-left: 22px" Width="120px"></asp:TextBox>
        </p>
    <p>
        Cc : 
        <asp:TextBox ID="cc_text" runat="server" style="margin-left: 71px" Width="120px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </p>
    <p>
        Total km : 
        <asp:TextBox ID="km_text" runat="server" style="margin-left: 31px" Width="120px"></asp:TextBox>
        </p>
    <p>
        Year : 
        <asp:TextBox ID="year_text" runat="server" style="margin-left: 59px" Width="120px"></asp:TextBox>
        </p>
    <p>
        Price per day : 
        <asp:TextBox ID="price_text" runat="server" Width="120px"></asp:TextBox>
    </p>
    <p>
        Availability:
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="true">Available</asp:ListItem>
            <asp:ListItem Value="false">Not available</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Add image : <asp:FileUpload ID="FileUpload1" runat="server" Height="19px" style="margin-left: 14px" Width="222px" />
    </p>
    <p>
       <asp:Button ID="add_button" runat="server" OnClick="add_button_Click" Text="ADD CAR" Width="91px" />
        <asp:Button ID="updatebutton" runat="server" OnClick="UpdateButton_click" Text="UPDATE INFO" Visible="False" Width="106px" />
       <asp:Button ID="add_button0" runat="server" OnClick="back_button_Click" Text="BACK" Width="91px" />
    </p>

    </div>



        <div id="dibs_div" runat="server" style="height: 345px; width:700px; float:right; margin-left: 0px;">

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="dibs1_label" runat="server" Text="NO DIBS YET"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="dibs1_button" runat="server" OnClick="dibs1_button_Click" Text="ACCEPT RENTAL" Visible="False" />
        <asp:Button ID="decline_button" runat="server" OnClick="decline_button_Click" style="margin-left: 62px" Text="DECLINE RENTAL" Visible="False" />

            <br />
            <br />
            <br />
            <br />

            <p style="float:right;">
        <asp:label id="rname_lab" runat="server" Visible="False">Renter name : </asp:label>
        <asp:TextBox ID="rname" runat="server" style="margin-right: 25px" Width="120px" Enabled="False" Visible="False"></asp:TextBox>
        </p>            

            <br />
            <br />
            <br />

    <p style="float:right;">
        <asp:label id="rlast_lab" runat="server" Visible="False" >Renter lastname : </asp:label>
        <asp:TextBox ID="rlastname" runat="server" style="margin-right: 25px" Width="120px" Enabled="False" Visible="False"></asp:TextBox>
        </p>

            <br />
            <br />
            <br />

    <p style="float:right;">
        <asp:label id="rrate_lab" runat="server" Visible="False">Renter rating : </asp:label>
        <asp:TextBox ID="rrating" runat="server" style="margin-right: 25px" Width="120px" Visible="False" Enabled="False"></asp:TextBox>
        </p>

        </div>
        
    </form>
    </body>
</html>
