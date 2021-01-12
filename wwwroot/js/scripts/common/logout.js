$(document).ready(function () {

    var $btnLogout = $("#btnLogout");
    $btnLogout.on("click", function () {
        localStorage.removeItem("DeviceInventoryJWT");
        localStorage.removeItem("userId");


        window.location = "/";
    });


})