//$(document).ready(function () {
//    $.ajax({
//        url: 'https://localhost:7073/api/Kost',
//        headers: {
//            'Authorization': "Bearer " + sessionStorage.getItem("token"),
//        }
//    }).done((res) => {
//        let kost = "";
//        $.each(res.data, function (key, val) {
//            kost += `<option value="${val.Id}"> ${val.Name} </option>`
//        });
//        console.log(kost);

//        //$("#InputDivisionIdDepartement").html(divisions);
//    });
//})
