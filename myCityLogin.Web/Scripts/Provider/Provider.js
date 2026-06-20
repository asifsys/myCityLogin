
$("#chkCertification").change(function () {

    if ($(this).is(":checked")) {

        $("#certificationDiv").show();

    }
    else {

        $("#certificationDiv").hide();

    }

});


function addCertification() {

    var index = $("#certBody tr").length;

    var html = "";

    html += "<tr>";

    html += "<td><input class='form-control' ";
    html += "name='Certifications[" + index + "].CertificationName'></td>";

    html += "<td><input class='form-control' ";
    html += "name='Certifications[" + index + "].CertificateNumber'></td>";

    html += "<td><input class='form-control' ";
    html += "name='Certifications[" + index + "].Year'></td>";

    html += "<td><input class='form-control' ";
    html += "name='Certifications[" + index + "].Provider'></td>";

    html += "<td>";

    html += "<button type='button' ";

    html += "class='btn btn-danger remove'>X</button>";

    html += "</td>";

    html += "</tr>";

    $("#certBody").append(html);

}

$(document).on("click", ".remove", function () {

    $(this).closest("tr").remove();

});

function saveProvider() {

    var modelval = {

        providerType: $("#ProviderType").val(),

        firstName: $("#FirstName").val(),

        lastName: $("#LastName").val(),

        gender: $("#Gender").val(),

        dob: $("#DOB").val(),

        contactNumber: $("#ContactNumber").val(),

        userName: $("#UserName").val(),

        password: $("#Password").val(),

        email: $("#Email").val(),

        speciality: $("#Speciality").val(),

        qualification: $("#Qualification").val(),

        registrationNumber: $("#RegistrationNumber").val(),

        status: $("#Status").val(),

        experience: $("#Experience").val(),

        isActive: $("#IsActive").is(":checked"),

        address: {
            address1: $("#addressid").val(),
            address2: $("#address2id").val(),
            city: $("#cityid").val(),
            state: $("#stateid").val(),
            pinCode: $("#pincodeid").val(),
            country: $("#countryid").val()
        },
        certifications: []

    };

    $("#certBody tr").each(function () {

        modelval.certifications.push({

            certificationName: $(this).find("td:eq(0) input").val(),

            certificateNumber: $(this).find("td:eq(1) input").val(),

            year: $(this).find("td:eq(2) input").val(),

            provider: $(this).find("td:eq(3) input").val()

        });

    });
    $.ajax({
        url: "/Provider/CreateProvider",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: JSON.stringify(modelval),

        success: function (response) {
           // console.log("response", response);
        },

        error: function (xhr) {
           // console.log("responseText", xhr.responseText);
        }
    });

}