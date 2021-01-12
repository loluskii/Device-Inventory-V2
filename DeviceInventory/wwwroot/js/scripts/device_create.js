$(document).ready(function () {
    var $employeeIdTemplate = $("#employeeIdTemplate");
    var $ddlEmployeeId = $("#ddlEmployeeId");
    var $txtEmail = $("#txtEmail");
    var $txtSerialNumber = $("#txtSerialNumber");
    var $createDeviceForm = $("#createDeviceForm");
    var $createDeviceTile = $("#createDeviceTile");
    var $barcodeDiv = $("#barcodeDiv");

    //device type
    var $deviceTypeTemplate = $("#deviceTypeTemplate");
    var $ddlDeviceType = $("#ddlDeviceType");

    //device model
    var $deviceModelTemplate = $("#deviceModelTemplate");
    var $ddlDeviceModel = $("#ddlDeviceModel");

    //Property types
    var $devicePropertyTypeTemplate = $("#devicePropertyTypeTemplate");
    var $ddlDevicePropertyType = $("#ddlDevicePropertyType");

    //Property color
    var $ddlDeviceColor = $("#ddlDeviceColor");
    var $deviceColorTemplate = $("#deviceColorTemplate");


    let employeeDetails = [];
    let selectedUser;

    function deviceData() {
        return {
            ProfileId: $ddlEmployeeId.val(),
            EmployeeId: selectedUser[0].employeeId,
            Email: $txtEmail.val(),
            SerialNumber: $txtSerialNumber.val(),
            DeviceTypeId: $ddlDeviceType.val(),
            DeviceModelId: $ddlDeviceModel.val(),
            DeviceColorId: $ddlDeviceColor.val(),
            PropertyTypeId: $ddlDevicePropertyType.val()
        };
    }


    $createDeviceForm.on("submit", function (e) {
        e.preventDefault();
        axios({
            method: 'post',
            url: "/api/device",
            data: deviceData()
        })
            .then(function (res) {
                $createDeviceTile.addClass("d-none");
                $barcodeDiv.removeClass("d-none");

                console.log(res.data);


            })
            .catch(function (err) {

                console.log(err);
            });
    });

    getDevicePropertyType().then(propertytypes => {
       
        var template = $devicePropertyTypeTemplate.html();
        var rendered = Mustache.render(template, { propertytypes: propertytypes });
        $ddlDevicePropertyType.html(rendered);

    });

    getUsers().then(employeeids => {
        employeeDetails = employeeids;
        var template = $employeeIdTemplate.html();
        var rendered = Mustache.render(template, { employeeids: employeeids });
        $ddlEmployeeId.html(rendered);

    });

    $ddlEmployeeId.on("change", function () {

         selectedUser = employeeDetails.filter(i => i.id === parseInt($(this).val()));
        if ($(this).val() !== "-1") {
            $txtEmail.val(selectedUser[0].email);

        } else {
            $txtEmail.val(" ");
            
        }
      
    });

    getDeviceType().then(devicetypes => {
        var template = $deviceTypeTemplate.html();
        var rendered = Mustache.render(template, { devicetypes: devicetypes });
        $ddlDeviceType.html(rendered);
    });

    getDeviceModel().then(devicemodels => {
        var template = $deviceModelTemplate.html();
        var rendered = Mustache.render(template, { devicemodels: devicemodels });
        $ddlDeviceModel.html(rendered);
    });
    getDeviceColor().then(devicecolors => {
        var template = $deviceColorTemplate.html();
        var rendered = Mustache.render(template, { devicecolors: devicecolors });
        $ddlDeviceColor.html(rendered);
    });

});