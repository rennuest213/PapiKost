function regist() {
    //e.preventDefault();
    var name = $("#inputName").val();
    var email = $("#inputEmail").val();
    var tanggal_lahir = $("#inputBirthDate").val();
    var no_hp = $("#inputPhoneNumber").val();
    var alamat = $("#inputAddress").val();
    var password = $("#inputPassword").val();
    //var change = tanggal_lahir.toLocaleDateString();
    var res = { name, email, tanggal_lahir, no_hp, alamat, password };
    console.log(res);

    $.ajax({
        url: `https://localhost:7073/api/Account/Register`,
        type: 'POST',
        dataType: 'json',
        data: JSON.stringify(res),
        contentType: 'application/json',
        success: function (data) {
            console.log("berhasil");
            //sessionStorage.setItem("token", data);
            console.log(data);
            //console.log(sessionStorage.getItem("token"));
            window.location.replace("../Account/Login")
        },
        error: function (data) {
            console.log(data)
        }
    });
    /*    console.log(login)*/
}
