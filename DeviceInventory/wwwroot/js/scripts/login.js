$(document).ready(function () {
    var $txtEmail = $("#txtEmail");
    var $txtPassword = $("#txtPassword");
    var $txtResetPasswordEmail = $("#txtresetPasswordEmail");
    var $LoginForm = $("#loginForm");
    var $resetPasswordForm = $("#resetPasswordForm");


    //package login data
    function loginData() {
        return {
            Username: $txtEmail.val().split("@")[0],
            Password: $txtPassword.val()
        };
    }

    $LoginForm.on("submit", function (e) {
        e.preventDefault();
        console.log(loginData());
        axios({
            method: 'post',
            url: "/api/auth/login",
            data: loginData()
        })
            .then(function (userData) {
                const { token, user, roles } = userData.data;
                localStorage.DeviceInventoryJWT = token;
                localStorage.userId = user;


                $txtEmail.val("");
                $txtPassword.val("");
                location.href = "/Dashboard";

            })
            .catch(function (err) {

                console.log(err);
            });


    });

});