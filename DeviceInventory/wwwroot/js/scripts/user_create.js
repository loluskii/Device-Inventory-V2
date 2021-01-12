$(document).ready(function () {
    var $subsidiaryTemplate = $("#subsidiaryTemplate");
    var $ddlSubsidiary = $("#ddlSubsidiary");

    //Employee type
    var $ddlEmployeetype = $("#ddlEmployeetype");
    var $employeetypeTemplate = $("#employeetypeTemplate");

    //roles
    var $ddlRole = $("#ddlRole");
    var $roleTemplate = $("#roleTemplate");

    //create user form
    var $txtEmployeeId = $("#txtEmployeeId");
    var $txtFullname = $("#txtFullname");
    var $txtEmail = $("#txtEmail");
    var $createUserForm = $("#createUserForm");

    //sample notification
    notify("success", "this is just a test");

    function createUserData() {
        return {
            EmployeeId: $txtEmployeeId.val(),
            FullName: $txtFullname.val(),
            Email: $txtEmail.val(),
            Password: "123456",
            RoleName: $ddlRole.val(),
            Gender: $("input[name=gender]:checked").val(),
            SubsidiaryId: $ddlSubsidiary.val(),
            EmployeeTypeId: $ddlEmployeetype.val()
        };
    }

    $createUserForm.on("submit", function (e) {
        e.preventDefault();

        var userFormData = new FormData();
        userFormData.set("EmployeeId", $txtEmployeeId.val());
        userFormData.set("FullName", $txtFullname.val());
        userFormData.set("Email", $txtEmail.val());
        userFormData.set("Password", "123456");
        userFormData.set("RoleName", $ddlRole.val());
        userFormData.set("Gender", $("input[name=gender]:checked").val());
        userFormData.set("SubsidiaryId", $ddlSubsidiary.val());
        userFormData.set("EmployeeTypeId", $ddlEmployeetype.val());
        userFormData.set("File", $("input[type=file]")[0].files[0]);

        axios({
            method: "post",
            url: "/api/auth/register",
            data: userFormData
        })
            .then(function (res) {


                console.log(res.data);
              
            })
            .catch(function (err) {

                console.log(err);
            });




        console.log(createUserData());
    });


    //populate subsidiary drop down list
    getSubsidiaries().then(subsidiaries => {
        var template = $subsidiaryTemplate.html();
        var rendered = Mustache.render(template, { subsidiaries: subsidiaries });
        $ddlSubsidiary.html(rendered);
        console.log(subsidiaries);
    });

    //populate employee type drop down list
    getEmployeeTypes().then(employeetypes => {
        var template = $employeetypeTemplate.html();
        var rendered = Mustache.render(template, { employeetypes: employeetypes });

        $ddlEmployeetype.html(rendered);
    });

    //populate roles drop down list
    getRoles().then(roles => {
        var template = $roleTemplate.html();
        var rendered = Mustache.render(template, { roles: roles });

        $ddlRole.html(rendered);
    });


})