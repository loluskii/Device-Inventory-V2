$(document).ready(function () {
    var $deviceTable = $("#deviceTable");
    var $deviceTableTemplate = $("#deviceTableTemplate");
    var $deviceTbody = $("#deviceTableBody");




    getDevices().then(devices => {
     
        var template = $deviceTableTemplate.html();
        var rendered = Mustache.render(template, { devices: devices });
        $deviceTbody.html(rendered);
        $deviceTable.DataTable({
            ordering: false
        });


    });
    //console.log("working");
});