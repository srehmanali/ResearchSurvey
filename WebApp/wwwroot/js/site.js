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

    


//function initMap() {
//    var macc = { lat: 42.1382114, lng: -71.5212585 };
//    var map = new google.maps.Map(
//        document.getElementById('map'), { zoom: 15, center: macc });
//    var marker = new google.maps.Marker({ position: macc, map: map });
//}