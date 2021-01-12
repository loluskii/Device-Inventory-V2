$(document).ready(function () {
    var $deviceColorTbody = $("#deviceColorTbody");
    var $deviceColorTemplate = $("#deviceColorTemplate");
    var $taDescription = $("#taDescription");


    var $deviceColorForm = $("#deviceColorForm");
    var $txtDeviceColor = $("#txtDeviceColor");

    //get employee type data
    function deviceColorData() {
        return {
            Name: $txtDeviceColor.val(),
            Description: $taDescription.val().trim()
        };
    }

    $deviceColorForm.on("submit", function (e) {
        e.preventDefault();
        console.log(deviceColorData());
        axios({
            method: 'post',
            url: "/api/devicecolor",
            data: deviceColorData()
        })
            .then(function (res) {
                console.log(res.data);
                
            })
            .catch(function (err) {

                console.log(err);
            });
    });

    getDeviceColor().then(colors => {
        var template = $deviceColorTemplate.html();
        var render = Mustache.render(template, { colors: colors });
        $deviceColorTbody.html(render);

        console.log(colors);
    });
})