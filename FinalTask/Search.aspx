<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="FinalTask.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 458px">
    <form id="form1" runat="server">

     <div style ="background-color:#077390; width:100%; height:71px">
        <h4  align="center" style="font-size:300%; height: 69px;">RENT-A-CAR </h4>

         <div id="map" class="center" style="width:1000px;height:500px;background:grey"></div>
    </div>
        <asp:HiddenField ID="location" runat="server" />
        <asp:HiddenField ID="cars_loc" runat="server" />
    </form>

    <script>
        function myMap() {

            var loc = document.getElementById('location').value;
            var LatLng = loc.replace("(", "").replace(")", "").split(", ")
            var Lat = parseFloat(LatLng[0]);
            var Lng = parseFloat(LatLng[1]);
            var myloc = {
                lat: Lat,
                lng: Lng
            }

            var mapOptions =
            {
                center: new google.maps.LatLng(myloc),
                zoom: 15,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            }


            var map = new google.maps.Map(document.getElementById("map"), mapOptions);


            var marker = new google.maps.Marker({
                position: myloc,
                map: map,
                animation: google.maps.Animation.DROP,
                icon: 'mypin.png'
            });

            var infowindow = new google.maps.InfoWindow();
            infowindow.open(map, marker);
            infowindow.close();


                var cars = (document.getElementById("cars_loc").value).split("/");

                for (i = 1; i < cars.length; i++) {
                    var LatLng = cars[i].replace("(", "").replace(")", "").split(", ")
                    var Lat = parseFloat(LatLng[0]);
                    var Lng = parseFloat(LatLng[1]);
                    var carloc = { lat: Lat, lng: Lng };

                    var marker = new google.maps.Marker({
                        position: carloc,
                        map: map,
                        animation: google.maps.Animation.DROP,
                        icon: 'carpin.png'
                    })
                }

        }
        


        
    </script>

    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDfm8O7RUSMRzdZK75-XKLtpU5DYvDObJ4&callback=myMap"></script>
        <!--//AIzaSyDZshf2Fnk5DwgJ5dlbaLZM8E_Rp4UyEJQ
        //AIzaSyC5klOa3rIUOx98PRn3B_DWS60UjRUy1gM
        //AIzaSyDfm8O7RUSMRzdZK75-XKLtpU5DYvDObJ4-->
        </body>
</html>
