$(document).ready(function () {
    var $subsidiaryForm = $("#subsidiaryForm");
    var $txtSubsidiary = $("#txtSubsidiary");
    var $taDescription = $("#taDescription");

    var $subsidiaryTBody = $("#subsidiaryTBody");
    var $subsidiaryTemplate = $("#subsidiaryTemplate");

    // get subsidiary data
    function subsidiaryData() {
        return {
            Name: $txtSubsidiary.val(),
            Description: $taDescription.val().trim()
        };
    }

    //submit subsidiary form
    $subsidiaryForm.on("submit", function (e) {
        e.preventDefault();

        console.log(subsidiaryData());
        axios({
            method: 'post',
            url: "/api/subsidiary",
            data: subsidiaryData()
            })
            .then(function (res) {
                console.log(res.data);


            })
            .catch(function (err) {

                console.log(err);
            });
    });


    //get all subsidiaries
    getSubsidiaries().then(subsidiaries => {
        var template = $subsidiaryTemplate.html();
        var rendered = Mustache.render(template, { subsidiaries: subsidiaries });

        $subsidiaryTBody.html(rendered);
      
    });


    //delete subsidiaries
    $(document).on("click", ".delete", function () {
        var tr = $(this).closest("tr");
        var id = tr.data("id");
        var name = tr.find("td.name").text();

        deleteItemInTable(id, "api/user", name, tr);

    });

})