$(document).ready(function () {
    var $employeetypeTbody = $("#employeetypeTbody");
    var $employeetypeTemplate = $("#employeetypeTemplate");
    var $taDescription = $("#taDescription");


    var $employeeTypeForm = $("#employeeTypeForm");
    var $txtEmployeeType = $("#txtEmployeeType");

    //get employee type data
    function employeetypeData() {
        return {
            Name: $txtEmployeeType.val(),
            Description: $taDescription.val().trim()
        };
    }

    $employeeTypeForm.on("submit", function (e) {
        e.preventDefault();
        console.log(employeetypeData());
        axios({
            method: 'post',
            url: "/api/employeetype",
            data: employeetypeData()
        })
            .then(function (res) {
                console.log(res.data);


            })
            .catch(function (err) {

                console.log(err);
            });
    });

    getEmployeeTypes().then(types => {
        var template = $employeetypeTemplate.html();
        var render = Mustache.render(template, { types: types });
        $employeetypeTbody.html(render);
        
        console.log(types);
    });

    //delete employeee type
    $(document).on("click", ".delete", function () {
        var tr = $(this).closest("tr");
        var id = tr.data("id");
        var name = tr.find("td.name").text();

        console.log(id + " " + name);
        deleteItemInTable(id, "api/user", name, tr);

    });
})