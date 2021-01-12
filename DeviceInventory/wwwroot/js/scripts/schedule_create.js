$(document).ready(function () {
    var $txtExpectedTime = $("#txtExpectedTime");
    var $txtExpectedDate = $("#txtExpectedDate");
    var $txtPhoneNumber = $("#txtPhoneNumber");
    var $txtFullName = $("#txtFullName");
    var $txtEmail = $("#txtEmail");
    var $taReason = $("#taReason");
    var $gender = $("input[name=gender]:checked");
    var $createScheduleForm = $("#createScheduleForm");


    function scheduleData() {
        return {
            Email: $txtEmail.val(),
            FullName: $txtFullName.val(),
            PhoneNumber: $txtPhoneNumber.val(),
            ExpectedTime: $txtExpectedTime.val(),
            Date: $txtExpectedDate.val(),
            UserID: localStorage.userId,
            Reason: $taReason.val(),
            Gender: $("input[name=gender]:checked").val()
        };
    }

    $createScheduleForm.on("submit", function (e) {
        e.preventDefault();
        console.log(scheduleData());
            axios({
                method: "post",
                url: "/api/visitor",
                data: scheduleData()
            })
            .then(function (res) {


                console.log(res.data);

            })
            .catch(function (err) {

                console.log(err);
            });
    });

    $txtExpectedDate.datepicker();

    $txtExpectedTime.timepicker({
        timeFormat: 'HH:mm:ss',
        interval: 15,
        minTime: '7',
        maxTime: '6:00pm',
        defaultTime: '8',
        startTime: '7:00',
        dynamic: false,
        dropdown: true,
        scrollbar: true
    });
    console.log("working");
});