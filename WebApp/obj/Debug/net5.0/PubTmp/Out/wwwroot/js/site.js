// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//$('.map').each(function (index, Element) {
//    var coords = $(Element).text().split(",");
//    if (coords.length !== 3) {
//        $(this).display = "none";
//        return;
//    }
//    var latlng = new google.maps.LatLng(parseFloat(coords[0]), parseFloat(coords[1]));
//    var myOptions = {
//        zoom: parseFloat(coords[2]),
//        center: latlng,
//        mapTypeId: google.maps.MapTypeId.ROADMAP,
//        disableDefaultUI: false,
//        mapTypeControl: true,
//        zoomControl: true,
//        zoomControlOptions: {
//            style: google.maps.ZoomControlStyle.SMALL
//        }
//    };
//    var map = new google.maps.Map(Element, myOptions);

//    var marker = new google.maps.Marker({
//        position: latlng,
//        map: map
//    });
//});

    function initMap() {
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(
                (position) => {
                    pos = {
                        lat: position.coords.latitude,
                        lng: position.coords.longitude,
                    };
                    const myLatlng = { lat: pos.lat, lng: pos.lng };
                    $('#LatLong').val(myLatlng.lat + ", " + myLatlng.lng)
                    $('.map').each(function (index, Element) {
                        //const map_dom = document.getElementsByClassName(Element);
                        const map = new google.maps.Map(Element, {
                            zoom: 17,
                            center: myLatlng,
                        });
                        // Create the initial InfoWindow.
                        let infoWindow = new google.maps.InfoWindow({
                            content: "Click the map to get Lat/Lng!",
                            position: myLatlng,
                        });

                        infoWindow.open(map);
                        // Configure the click listener.
                        map.addListener("click", (mapsMouseEvent) => {
                            // Close the current InfoWindow.
                            infoWindow.close();
                            // Create a new InfoWindow.
                            infoWindow = new google.maps.InfoWindow({
                                position: mapsMouseEvent.latLng,
                            });
                            const position = mapsMouseEvent.latLng.toJSON()
                            infoWindow.setContent(
                                JSON.stringify(position, null, 2)
                            );
                            $(this).siblings('input').val(position.lat + ", " + position.lng)
                            //mapTextbox.value(mapsMouseEvent.latLng.toJSON())
                            infoWindow.open(map);

                        });
                    });
                });
        } else {
            alert("Geolocation is not supported by this browser.");
        }

    }


//function initMap() {
//    var macc = { lat: 42.1382114, lng: -71.5212585 };
//    var map = new google.maps.Map(
//        document.getElementById('map'), { zoom: 15, center: macc });
//    var marker = new google.maps.Marker({ position: macc, map: map });
//}