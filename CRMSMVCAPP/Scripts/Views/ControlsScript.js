
$(document).ready(function () {

    ControlScript.init();

    $('#ddlCountry').multiselect({
        search: true,
        size: '6',
        includeSelectAllOption: true

    });

});

var ControlScript = ControlScript ||
{
    init: function () {

        //$("#Name").autocomplete({
        //    source: function (request, response) {
        //        $.ajax({
        //            url: "http://localhost/CRMSMVCAPP/Home/GetCityDetails",
        //            type: "POST",
        //            dataType: "json",
        //            data: { Prefix: request.term },
        //            success: function (data) {
        //                response($.map(data, function (item) {
        //                    return { label: item.Name, value: item.Name };
        //                }))

        //                //var results;
        //                //var aData = $.map(data, function (value, key) {
        //                //    return {
        //                //        label: value.first_name,
        //                //        value: value.id
        //                //    }
        //                //});
        //                //results = $.ui.autocomplete.filter(aData, request.term);
        //                //response(results);

        //            }
        //        })
        //    },
        //    messages: {
        //        noResults: "", results: ""
        //    }
        //});


    },


};

//Changes for Notification display

DisplayNotificationBar = function () {

    $('#loading').css('display', 'inline-block');
    $('#Process-Modal').show();

    ShowMessage("Internal exception Occured.", 'Error');

}

function ShowMessage(message, messagetype) {
    var cssclass;
    switch (messagetype) {
        case 'Success':
            cssclass = 'alert-success'
            break;
        case 'Error':
            cssclass = 'alert-danger'
            break;
        case 'Warning':
            cssclass = 'alert-warning'
            break;
        default:
            cssclass = 'alert-info'
    }

    $('#alert_container').append('<div id="alert_div" style="margin: 0 0.5%; -webkit-box-shadow: 3px 4px 6px #999;" class="alert fade in ' + cssclass + '"><a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a><strong>' + messagetype + '!</strong> <span>' + message + '</span></div>');

    setTimeout(function () {
        $("#alert_div").fadeTo(2000, 500).slideUp(500, function () {
            $("#alert_div").remove();
        });
    }, 5000);//5000=5 seconds
}

TextToSpeech = function () {

    let txt = document.getElementById("taText");
    let btn = document.getElementById("btnSpeech");

    btn.addEventListener("click", function () {

        let text = txt.value;
        let utterance = new SpeechSynthesisUtterance(text);
        utterance.lang = "tr";
        speechSynthesis.speak(utterance);
    });


}