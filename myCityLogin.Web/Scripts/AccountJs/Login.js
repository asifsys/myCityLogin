

// GLOBAL FUNCTIONS

function showRegister() {

    $("#loginSection").hide();

    $("#registerSection").show();

    $("#modalTitle").text("Create Account");
}

function cancelRegister() {

    $("#fullName").val("");

    $("#registerEmail").val("");

    $("#registerPassword").val("");

    $("#registerSection").hide();

    $("#loginSection").show();

    $("#modalTitle").text("User Login");
}

//async function login() {

//    if ($("#loginEmail").val().trim() === "") {

//        alert("Email is required");

//        return;
//    }

//    alert("Login Working");
//}

async function register() {

    alert("Register Working");
}

// DOCUMENT READY

$(document).ready(function () {

    $("#loginModal").on("hidden.bs.modal", function () {

        cancelRegister();

        $("#loginEmail").val("");

        $("#loginPassword").val("");
    });

});

         // REGISTER
             async function register()
            {
                // VALIDATION
                if ($("#fullName").val().trim() === "") {
                    alert("Full Name is required");
                    $("#fullName").focus();
                    return;
                }

                if ($("#registerEmail").val().trim() === "") {
                    alert("Email is required");
                    $("#registerEmail").focus();
                    return;
                }

                if ($("#registerPassword").val().trim() === "") {
                    alert("Password is required");
                    $("#registerPassword").focus();
                    return;
                }

                let user = {

                    FullName: $("#fullName").val(),

                    Email: $("#registerEmail").val(),

                    Password: $("#registerPassword").val()
                };

                 $.ajax({
                     url: '/User/RegisterUser',
                     type: 'POST',
                     contentType: 'application/json',
                     data: JSON.stringify(user),

                     success: function (response) {

                         alert(response.message);

                         if (response.success) {
                             cancelRegister();
                         }
                     },

                     error: function (xhr) {
                         alert("Registration failed");
                     }
                 });

                //let response = await fetch(
                //    "https://localhost:7260/api/auth/register",
                //    {
                //        method: "POST",

                //        headers: {
                //            "Content-Type": "application/json"
                //        },

                //        body: JSON.stringify(user)
                //    });

                //let result = await response.json();

                //alert(result.message);

                //if (response.ok) {

                //    cancelRegister();
                //}
            };


// LOGIN
async function login() {

    // Validation
    const email = $("#loginEmail").val().trim();
    const password = $("#loginPassword").val().trim();

    if (!email) {
        alert("Email is required");
        $("#loginEmail").focus();
        return;
    }

    if (!password) {
        alert("Password is required");
        $("#loginPassword").focus();
        return;
    }

    const user = {
        email: email,
        password: password
    };

    $.ajax({
        url: '/User/Login',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(user),

        success: function (response) {

            if (response.success) {
                alert("You are logged in successfully.");
                // Store JWT token for current browser session
                sessionStorage.setItem("jwtToken", response.token);

                $("#btnLoginRegister").hide();
                $("#btnLogout").show();

                //  window.location.href = "/Dashboard/Dashboard";
                window.location.href = "/Provider/Provider";
            }
            else {
                alert(response.message || "Invalid credentials");
            }
        },

        error: function (xhr) {

            let errorMessage = "Login failed";

            if (xhr.responseJSON && xhr.responseJSON.message) {
                errorMessage = xhr.responseJSON.message;
            }

            alert(errorMessage);
        }
    });
}


//window.loginTest = async function ()
async function loginTest() {
                // VALIDATION
                if ($("#loginEmail").val().trim() === "") {

                    alert("Email is required");

                    $("#loginEmail").focus();

                    return;
                }

                if ($("#loginPassword").val().trim() === "") {

                    alert("Password is required");

                    $("#loginPassword").focus();

                    return;
                }

                let user = {

                    email: $("#loginEmail").val(),

                    password: $("#loginPassword").val()
                };

                let response = await fetch(
                    "https://localhost:7260/api/auth/login",
                    {
                        method: "POST",

                        headers: {
                            "Content-Type": "application/json"
                        },

                        body: JSON.stringify(user)
                    });

                if (response.ok) {

                    let result = await response.json();

                    // localStorage.setItem("jwtToken", result.token);  --- localStorage persists permanently in browser even if:

                                                                            // * you stop Visual Studio
                                                                            // * rerun application
                                                                            // * restart browser
                                                                            // * refresh page
                                                                            // * So application still thinks user is logged in.
                    sessionStorage.setItem("jwtToken", result.token);
                    $("#btnLoginRegister").hide();

                    $("#btnLogout").show();

                    window.location.href = "/Dashboard/Dashboard";
                }
                else {

                    let error = await response.json();

                    alert(error.message ?? "Invalid credentials");
                }
            };


        // Search Field
            function search() {
        let location = document.getElementById("searchLocation").value.trim();
        let keyword  = document.getElementById("searchKeyword").value;

        if (!location && !keyword) {
            alert("Please enter a location or select a category.");
            return;
        }

        let msg = "";
        if (location && keyword)
            msg = `Searching for <strong>${keyword}</strong> in <strong>${location}</strong>...`;
        else if (location)
            msg = `Searching in <strong>${location}</strong>...`;
        else
            msg = `Searching for <strong>${keyword}</strong>...`;

        document.getElementById("searchResults").innerHTML =
            `<div class="alert alert-info">${msg}</div>`;
    }
