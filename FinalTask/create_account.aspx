<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create_account.aspx.cs" Inherits="FinalTask.create_account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        create_button {float:right;}
    </style>
</head>
<body style="background-image:url('Content/Themes/car.png'); background-repeat:no-repeat; background-size:100% 120%;">
   
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
            <asp:TextBox ID="password_text" float="right" runat="server" style="margin-left: 53px; margin-top: 15px;" OnTextChanged="password_text_TextChanged" Height="19px"></asp:TextBox><br>
                   
        <asp:Label ID="birth_label" runat="server" Text="Year of birth :"></asp:Label>
            <asp:TextBox ID="birth_text" float="right" runat="server" style="margin-left: 53px; margin-top: 15px;" Height="19px" ></asp:TextBox><br>

           <asp:Label ID="exp_label" runat="server" Text="Driving since :"></asp:Label>
            <asp:TextBox ID="exp_text" float="right" runat="server" style="margin-left: 53px; margin-top: 15px;" Height="19px"></asp:TextBox>
<p>
            &nbsp;</p>

        <div>Select your location in the map:
            <asp:HiddenField ID="location" runat="server" Value="" />
        </div>

        <div id="map" class="center" style="width:1000px;height:500px;background:grey"></div>


    <script>
        function myMap() {

            var myloc;
            var mylat = 37.9415841;
            var mylng = 23.6530173;
            myloc = { lat: mylat, lng: mylng };


            if (location.Value != "")
            {
                var loc = document.getElementById('location').value;
                var LatLng = loc.replace("(", "").replace(")", "").split(", ")
                mylat = parseFloat(LatLng[0]);
                mylng = parseFloat(LatLng[1]);
                myloc = {
                    lat: mylat,
                    lng: mylng
                };

            }
            else
            {
                document.getElementById('location').value = "(" + mylat + ", " + mylng + ")";
                
                if (navigator.geolocation) {
                    navigator.geolocation.getCurrentPosition(function (position) {
                        myloc = {
                            lat: position.coords.lattitude,
                            lng: position.coords.longitude
                        };

                        document.getElementById('location').value = "(" + position.coords.lattitude + ", " + position.coords.longitude + ")";
                        

                        marker.setPosition(myloc);
                        map.setCenter(marker.getPosition());
                    }, function () {
                        handleLocationError(true, infoWindow, map.getCenter());
                    });
                } else {
                    // Browser doesn't support Geolocation
                    handleLocationError(false, infoWindow, map.getCenter());
                }
            }
            var mapOptions =
            {
                center: new google.maps.LatLng(myloc),
                zoom: 15,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };

            var map = new google.maps.Map(document.getElementById("map"), mapOptions);


            var home = { lat: mylat, lng: mylng };


            var marker = new google.maps.Marker({
                position: home,
                map: map,
                animation: google.maps.Animation.DROP,
                icon: 'mypin.png'
            });

            var infowindow = new google.maps.InfoWindow();
            infowindow.open(map, marker);
            infowindow.close();

            google.maps.event.addListener(map, 'click', function (event) {
                document.getElementById('location').value = event.latLng;
                marker.setPosition(event.latLng);
                map.setCenter(marker.getPosition());

            });

        }
        


        
    </script>

    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDfm8O7RUSMRzdZK75-XKLtpU5DYvDObJ4&callback=myMap">
    </script>



            <p>



            <asp:Button ID="create_button" float="right" runat="server" Text="CREATE ACCOUNT" Width="132px" OnClick="create_button_Click" />
            <asp:Button ID="update_button" float="right" runat="server" Text="UPDATE ACCOUNT" Width="132px" OnClick="update_button_Click" Visible="False" />
        </p>
        <p>



            <asp:Button ID="back" float="right" runat="server" Text="BACK" Width="132px" OnClick="back_button_Click" />



            <asp:Button ID="backtochoice" float="right" runat="server" Text="BACK" Width="132px" OnClick="backtochoice_button_Click" Visible="False" />
            </p>



    </form>
        
</body>
</html>
