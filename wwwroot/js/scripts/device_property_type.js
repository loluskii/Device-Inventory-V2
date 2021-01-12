$(document).ready(function () {
    var $devicePropertyTypeTbody = $("#devicePropertyTypeTbody");
    var $devicePropertyTypeTemplate = $("#devicePropertyTypeTemplate");
    var $taDescription = $("#taDescription");


    var $devicePropertyTypeForm = $("#devicePropertyTypeForm");
    var $txtDevicePropertyType = $("#txtDevicePropertyType");

    //get employee PropertyType data
    function devicePropertyTypeData() {
        return {
            Name: $txtDevicePropertyType.val(),
            Description: $taDescription.val().trim()
        };
    }

    $devicePropertyTypeForm.on("submit", function (e) {
        e.preventDefault();
        console.log(devicePropertyTypeData());
        axios({
            method: 'post',
            url: "/api/devicePropertyType",
            data: devicePropertyTypeData()
        })
            .then(function (res) {
                console.log(res.data);


            })
            .catch(function (err) {

                console.log(err);
            });
    });

    getDevicePropertyType().then(propertyTypes => {
        var template = $devicePropertyTypeTemplate.html();
        var render = Mustache.render(template, { propertyTypes: propertyTypes });
        $devicePropertyTypeTbody.html(render);

        console.log(propertyTypes);
    });
})