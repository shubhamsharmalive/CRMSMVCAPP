var UserDetailsList = [];
var IsEditablePVItem = false;

$(document).ready(function () {

    GetUserDetails.GetEmployeeDetails();
    GetUserDetails.init();

});

var GetUserDetails = GetUserDetails ||
{
    init: function () {
    },

};


GetUserDetails.GetEmployeeDetails = function (data) {
    $("#div-getuserdetails").html("Please wait employee data is loading.....");

    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: $("#div-getuserdetails").attr('data-ajax-url'),

        success: function (result) {
            if (result.length > 0) {

                GetUserDetails.BindEmployeeDetails(result);
                GetUserDetails.CreateArrayList(result);
            }
        },

        error: function () {
            alert("Please reload page.");
        }
    });

}

GetUserDetails.BindEmployeeDetails = function (data) {
    $("#div-getuserdetails").html("");
    if (data.length > 0) {

        var html = '<table id="example" class="display table" style="width:100%">';
        html += ' <thead> < tr ><th>User ID</th> <th>Package ID</th> <th>First Name</th> <th>Last Name</th> <th>Mobile</th> <th>Email</th><th>Action</th> </tr > </thead >'
        $.each(data, function (index, value) {
            html += '<tr><td class="td-userid">' + value.UserId + '</td>';
            html += '<td class="td-packageid">' + value.PackageId + '</td>';
            html += '<td class="td-firstname">' + value.FirstName + '</td>';
            html += '<td class="td-lastname">' + value.LastName + '</td>';
            html += '<td class="td-mobile">' + value.Mobile + '</td>';
            html += '<td class="td-email">' + value.Email + '</td>';
            html += '<td width="30px" class="td-image" > <img id="EditPVRow' + value.UserId + '" style=" width:48%; float: left; border-right: 1px solid #449c3d;" class="" src="../Content/images/edit_green.png" title="Edit" onclick="EditPVItem(' + value.UserId + ')"/>'; /*<img id="SavePVRow" class="hidden" src="../Content/images/save_green.png" title="Save" onclick="SavePVItem(' + value.ViolationNumber + ')" style="width:50%"/>';*/
            html += '<img class="" src="../Content/images/delete_green.png" title="Delete" style="float: right; width:48%;" onclick="DeletePVItem(' + value.UserId + ');" /></td></tr>'; /*<img id="CancelPVRow" class="hidden" src="../Content/images/cancel_green.png" title="Cancel" onclick="CancelPVItem(' + value.ViolationNumber + ')" style="width:50%"/>*/

        });
        html += ' <tfoot> < tr ><th>Name</th> <th>Position</th> <th>Office</th> <th>Age</th> <th>Start date</th> <th>Salary</th><th>Action</th> </tr > </tfoot >'
        html += '</table>';
        $("#div-getuserdetails").append(html);

        var table = $('#example').DataTable({

            lengthChange: false,
            buttons: ['copy', 'excel', 'pdf', 'colvis']
        });

        table.buttons().container()
            .insertBefore('#example_filter');

    }

}

GetUserDetails.CreateArrayList = function (data) {
    var UserDetailsArray = {};

    $.each(data, function (index, value) {
        UserDetailsArray.UserId = value.UserId;
        UserDetailsArray.PackageId = value.PackageId;
        UserDetailsArray.FirstName = value.FirstName;
        UserDetailsArray.LastName = value.LastName;
        UserDetailsArray.Mobile = value.Mobile;
        UserDetailsArray.Email = value.Email;

        UserDetailsList.push(UserDetailsArray);
        UserDetailsArray = {};
    });
}

function EditPVItem(data) {
	if (IsEditablePVItem) { return; }
	var tr = document.getElementById('EditPVRow' + data);
	tr = tr.closest('tr');
	var Tds = tr.getElementsByTagName('td');
	var selectedValue;
	IsEditablePVItem = true;
	$(Tds).each(function () {
		if ($(this).hasClass("td-userid")) {
			$(this).replaceWith(function () {
				return '<td width="20x" class="td-userid" style="max-width:20px; word-break:break-word;"><label style="display:none;">' + $(this).text() + '</label><input type="text" id="txtuserid_" class="highlightedProfileTd"  maxlength="50"  style="width:-webkit-fill-available;" value="' + $(this).text() + '" disabled> </input></td>';

			});


		}
		else
			if ($(this).hasClass("td-packageid")) {
				$(this).replaceWith(function () {
					return '<td class="td-description" style="max-width:30px; word-break:break-word;"><label style="display:none;">' + $(this).text() + '</label><input type="text" id="txtpackageid_" class="highlightedProfileTd"  maxlength="200"  style="width:-webkit-fill-available;" value="' + $(this).text() + '"> </input></td>';

				});
			}
			else
				if ($(this).hasClass("td-firstname")) {
					$(this).replaceWith(function () {
						return '<td class="td-description" style="max-width:30px; word-break:break-word;"><label style="display:none;">' + $(this).text() + '</label><input type="text" id="txtfirstname_" class="highlightedProfileTd"  maxlength="200"  style="width:-webkit-fill-available;" value="' + $(this).text() + '"> </input></td>';

					});
				}

				else {
					if ($(this).hasClass("td-lastname")) {

						$(this).replaceWith(function () {
							return '<td class="td-categories" style="max-width:25px; word-break:break-word;"><label style="display:none;">' + $(this).text() + '</label><input type="text" id="txtlastname_" class="highlightedProfileTd"  maxlength="100"  style="width:-webkit-fill-available;" value="' + $(this).text() + '"> </input></td>';

						});
					}
					else {
						if ($(this).hasClass("td-mobile")) {

							$(this).replaceWith(function () {
								return '<td class="td-charge" style="max-width:8px; word-break:break-word;"><label style="display:none;">' + $(this).text() + '</label><input type="text" class="highlightedProfileTd" id="txtmobile_"  maxlength="8"  style="width:-webkit-fill-available;" value="' + $(this).text() + '"> </input></td>';

							});
						}

						else {
							if ($(this).hasClass("td-email")) {

								$(this).replaceWith(function () {
									return '<td class="td-email" style="max-width:8px; word-break:break-word;"><label style="display:none;">' + $(this).text() + '</label><input type="text" class="highlightedProfileTd" id="txtemail_"  maxlength="8"  style="width:-webkit-fill-available;" value="' + $(this).text() + '"> </input></td>';

								});
							}

							else {
								if ($(this).hasClass("td-image")) {

									$(this).replaceWith(function () {
										return '<td class="td-image" width="20px"><img id="SavePVRow" class="" src="../Content/images/save_green.png" onclick="SavePVItem(' + data + ')" title="Save" style="width:46%; float: left;"/> <img id="CancelPVRow" class="" src="../Content/images/cancel_green.png" title="Cancel" onclick="CancelPVItem(' + data + ')"  style="width:51%"/></td>';

									});
								}
							}
						}
					}
				}
	});


}

function DeletePVItem(data) {

	var PVArrList = [];

	UserDetailsList = jQuery.grep(UserDetailsList, function (value) {
		return value.UserId != data
	});

	GetUserDetails.BindEmployeeDetails(UserDetailsList);

}

function CancelPVItem(data) {
	IsEditablePVItem = false;
	GetUserDetails.BindEmployeeDetails(UserDetailsList);


}

function SavePVItem(data) {

	var PViolationArr = new Array();
	var userid = document.getElementById('txtuserid_');
	var packageid = document.getElementById('txtpackageid_');
	var firstname = document.getElementById('txtfirstname_');
	var lastname = document.getElementById('txtlastname_');
	var mobile = document.getElementById('txtmobile_');
	var email = document.getElementById('txtemail_');

	objIndex = UserDetailsList.findIndex((obj => obj.UserId == data));

	UserDetailsList[objIndex].UserId = userid.value;
	UserDetailsList[objIndex].PackageId = packageid.value;
	UserDetailsList[objIndex].FirstName = firstname.value;
	UserDetailsList[objIndex].LastName = lastname.value;
	UserDetailsList[objIndex].Mobile = mobile.value;
	UserDetailsList[objIndex].Email = email.value;

	GetUserDetails.BindEmployeeDetails(UserDetailsList);
	IsEditablePVItem = false;
}