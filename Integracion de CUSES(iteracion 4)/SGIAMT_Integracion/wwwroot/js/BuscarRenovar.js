
$(document).ready(function () {

    $("#btnbuscar").click(getupdateAlumno);

});

//var getupdateAlumno = function () {
//    var dni = document.getElementById('dni').value;
//    var inputModel = JSON.stringify(dni);
//    $.ajax({
//        type: "POST",
//        contentType: "application/json",
//        /*; charset=utf-8"*/
//        url: "/Alumnohome/Alumno",
//        data: inputModel,

//        success: function (data) {
//            //data is your result from controller

//            //alert(data.message);
//            localStorage.setItem('dni', dni);
//                window.location.href = "/TUsuarios/Edit";

//        },
//        error: function (xhr) {
//            alert('error');
//        }
//    });
//};


var getupdateAlumno = function () {
    var dni = document.getElementById('dni').value;

    $.ajax({
        url: "/Alumnohome/Alumno",
        type: "GET",
        data: { dni: dni },
        contentType: "application/json; charset=utf-8",
        success: function () {
            //data is your result from controller

        },
        error: function (xhr) {
            alert('error');
        }
    });
};