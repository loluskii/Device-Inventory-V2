$(document).ready(function () {
    var $deviceModelTbody = $("#deviceModelTbody");
    var $deviceModelTemplate = $("#deviceModelTemplate");
    var $taDescription = $("#taDescription");


    var $deviceModelForm = $("#deviceModelForm");
    var $txtDeviceModel = $("#txtDeviceModel");

    //get employee type data
    function deviceModelData() {
        return {
            Name: $txtDeviceModel.val(),
            Description: $taDescription.val().trim()
        };
    }

    $deviceModelForm.on("submit", function (e) {
        e.preventDefault();
        console.log(deviceModelData());
        axios({
            method: 'post',
            url: "/api/deviceModel",
            data: deviceModelData()
        })
            .then(function (res) {
                console.log(res.data);


            })
            .catch(function (err) {

                console.log(err);
            });
    });

    getDeviceModel().then(Models => {
        var template = $deviceModelTemplate.html();
        var render = Mustache.render(template, { Models: Models });
        $deviceModelTbody.html(render);

        console.log(Models);
    });
})