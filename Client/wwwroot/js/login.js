function akun() {
    //e.preventDefault();
    let login = new Object();

    login.Email = $("#inputEmail").val();
    login.Password = $("#inputPassword").val();
    console.log("test");
    console.log(login);

    $.ajax({
        url: `https://localhost:7073/api/Account/Login`,
        type: 'POST',
        data: JSON.stringify(login),
        dataType: 'text',
        headers: {
            'Content-Type': 'application/json'
        },
        success: function (data) {
            console.log("berhasil");
            sessionStorage.setItem("token", data);
            console.log(data);
            let jwtData = data.split('.')[1]
            let decodedJwtJsonData = window.atob(jwtData)
            let decodedJwtData = JSON.parse(decodedJwtJsonData)
            let roles = decodedJwtData.role;
            /*console.log(jwtData);
            console.log(decodedJwtJsonData);
            console.log(decodedJwtData);
            console.log(roles);*/
            if (roles === "Admin") {
                window.location.replace("../Kost/Index");
            } else {
                window.location.replace("../User/Index")
            }
            //console.log(sessionStorage.getItem("token"));
            //window.location.replace("../Kost/Index")
        },
        error: function (jqXHR, exception, errorMessage) {
            console.log(jqXHR);
        }
    })
    /*    console.log(login)*/
}

//function akun() {
//    e.preventDefault();
//    let login = new Object();

//    login.Email = $("input[name='email']").val();
//    login.Password = $("input[name='password']").val();

//    $.ajax({
//        type: "POST",
//        
//        data: login,
//        success: function (result) {
//            console.log("Success", JSON.stringify(login))
//            console.log(result)
//            switch (result.status) {
//                case 200:
//                    window.location.replace("../Department/")
//                    break;
//                default:
//                    Swal.fire({
//                        icon: 'error',
//                        title: 'Oops...',
//                        text: 'Wrong Email or Password',
//                    })
//            }
//        },
//        error: function (XMLHttpRequest, textStatus, errorThrown) {
//            console.log("Failed", JSON.stringify(login))
//            console.log("Failed", XMLHttpRequest, textStatus, errorThrown)
//        }
//    });
//    console.log(login)
//});



//$(document).ready(function () {
//    $('#btn-login').click(function () {
//        var email = $('#email').val().trim();
//        var password = $('#password').val().trim();
//        var res = { email, password };
//        $.ajax({
//           
//            type: "POST",
//            contentType: "application/json",
//            dataType: "json",
//            data: JSON.stringify(res),
//            success: function (data) {
//                if (data.Message == "Login gagal") {
//                    Swal.fire("Error!", `${data.Message}`, "error")
//                } else {
//                    Swal.fire("Success!", `${data.Message}`, "success")
//                    console.log(data.Token)
//                }

//            }, error: function () {
//            }

//        })

//    });
//});
