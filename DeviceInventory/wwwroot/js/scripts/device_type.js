$(document).ready(function () {
    var $deviceTypeTbody = $("#deviceTypeTbody");
    var $deviceTypeTemplate = $("#deviceTypeTemplate");
    var $taDescription = $("#taDescription");


    var $deviceTypeForm = $("#deviceTypeForm");
    var $txtDeviceType = $("#txtDeviceType");

    //get employee type data
    function deviceTypeData() {
        return {
            Name: $txtDeviceType.val(),
            Description: $taDescription.val().trim()
        };
    }

    $deviceTypeForm.on("submit", function (e) {
        e.preventDefault();
        console.log(deviceTypeData());
        axios({
            method: 'post',
            url: "/api/deviceType",
            data: deviceTypeData()
        })
            .then(function (res) {
                console.log(res.data);


            })
            .catch(function (err) {

                console.log(err);
            });
    });

    getDeviceType().then(types => {
        var template = $deviceTypeTemplate.html();
        var render = Mustache.render(template, { types: types });
        $deviceTypeTbody.html(render);

        console.log(types);
    });
})