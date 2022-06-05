
$(document).ready(function () {

    ControlScript.init();

});

var ControlScript = ControlScript ||
{
    init: function () {

        $("#Name").autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "http://localhost/CRMSMVCAPP/Home/GetCityDetails",
                    type: "POST",
                    dataType: "json",
                    data: { Prefix: request.term },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return { label: item.Name, value: item.Name };
                        }))

                        //var results;
                        //var aData = $.map(data, function (value, key) {
                        //    return {
                        //        label: value.first_name,
                        //        value: value.id
                        //    }
                        //});
                        //results = $.ui.autocomplete.filter(aData, request.term);
                        //response(results);

                    }
                })
            },
            messages: {
                noResults: "", results: ""
            }
        });


    },


};