<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FinalTask.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="height: 458px">
    <form id="form1" runat="server">
        </form>
         <div id="map" class="center" style="width:1000px;height:500px;background:grey"></div>

    <script>
        function myMap() {
            var mylat = 37.9415841;
            var mylng = 23.6530173;

            var myloc = { lat: mylat, lng: mylng };

        if (navigator.geolocation) {
          navigator.geolocation.getCurrentPosition(function(position) {
            var pos = {
              lat: position.coords.latitude,
              lng: position.coords.longitude
            };

            marker.setPosition(pos);
            map.setCenter(marker.getPosition());
          }, function() {
            handleLocationError(true, infoWindow, map.getCenter());
          });
        } else {
          // Browser doesn't support Geolocation
          handleLocationError(false, infoWindow, map.getCenter());
        }


            var myloc = { lat: mylat, lng: mylng };

            var mapOptions =
            {
                center: new google.maps.LatLng(myloc),
                zoom: 15,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            }


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
                 marker.setPosition(event.latLng);
                 map.setCenter(marker.getPosition());
            }); 

            /*
            //circle
            var cc = new google.maps.LatLng(mylat, mylng);
            var circle = new google.maps.Circle({
                center: cc,
                radius: 1000,
                strokeColor: "blue",
                strokeOpacity: 0.8,
                strokeWeight: 5,
                fillColor: "white",
                fillOpacity: 0.4,
                map: map
            });
            /*polygon
            var p1 = new google.maps.LatLng(38.00154,23.705381);
            var p2 = new google.maps.LatLng(37.997935,23.696693);
            var p3 = new google.maps.LatLng(37.996288,23.694325);
            var p4 = new google.maps.LatLng(37.985295,23.710693);
            var p5 = new google.maps.LatLng(37.984265,23.714442);
            var p6 = new google.maps.LatLng(37.98729,23.717887);
            var p7 = new google.maps.LatLng(37.996168,23.71195);
            var p8 = new google.maps.LatLng(38.00154,23.705381);
            var myPath =  [p1,p2,p3,p4,p5,p6,p7,p8];
            var polygon = new google.maps.Polygon({
                path: myPath,
                strokeColor: "yellow",
                strokeOpacity: 0.8,
                strokeWeight: 3,
                fillColor: "red",
                fillOpacity: 0.4,
                map: map
            });
            //line
            var l1 = new google.maps.LatLng(37.948709,23.655632);
            var l2 = new google.maps.LatLng(37.95972,23.688652);
            var l3 = new google.maps.LatLng(37.966491,23.695314);
            var l4 = new google.maps.LatLng(37.968855,23.699419);
            var l5 = new google.maps.LatLng(37.969873,23.702185);
            var l6 = new google.maps.LatLng(37.975902,23.71109);
            var flightPath = new google.maps.Polyline({
                path: [l1,l2,l3,l4,l5,l6],
                strokeColor: "#0000FF",
                strokeOpacity: 0.8,
                strokeWeight: 5,
                map: map
          });
          var infowindow = new google.maps.InfoWindow({
                content: "Home"
            });
            infowindow.open(map, marker);

            google.maps.event.addListener(map, 'click', function (event) {
                //window.alert(event.latLng);
                
                var marker = new google.maps.Marker({
                    position: event.latLng,
                    map: map,
                    animation: google.maps.Animation.DROP,
                    icon: 'pin.png'
                });
                 map.setCenter(marker.getPosition());
            }); */

        }
        


        
    </script>

    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDfm8O7RUSMRzdZK75-XKLtpU5DYvDObJ4&callback=myMap"></script>
        <!--//AIzaSyDZshf2Fnk5DwgJ5dlbaLZM8E_Rp4UyEJQ
        //AIzaSyC5klOa3rIUOx98PRn3B_DWS60UjRUy1gM
        //AIzaSyDfm8O7RUSMRzdZK75-XKLtpU5DYvDObJ4-->
        </body>
</html>
