var la;
var ln;


if (document.getElementById("__Latitude") !== null &&
    document.getElementById("__Longitude") !== null) {
    la = document.getElementById("__Latitude").value;
    ln = document.getElementById("__Longitude").value;
}





//create map
var map = L.map('map').setView([57.72, 14.21], 6);



//map provider
L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);


var marker = L.marker([57.7222, 14.2123], { draggable: true });


//window.onload = function () {
//    if (la !== "") {
//        marker.addTo(map);
//    }
//}

//Function get lat and lng onClick
function GetLatLng(e) {
    console.log(la, ln)
    la = e.latlng.lat.toString();
    ln = e.latlng.lng.toString();
    console.log(la, ln);
    
    document.getElementById("__Latitude").value = la;
    document.getElementById("__Longitude").value = ln;


}

function UpdateMarker(e) {

    //Update marker position if click != position of button
    if (e.containerPoint.x < 467 && e.containerPoint.y > 50 || e.containerPoint.y > 50 || e.containerPoint.x < 467) {
        marker.addTo(map);
        marker.setLatLng(e.latlng).update();
        
    }
    
}

//Get lat and lng on map click
map.on('click', GetLatLng);
map.on('click', UpdateMarker);
map.on('load', UpdateMarker);