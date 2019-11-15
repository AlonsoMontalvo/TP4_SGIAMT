
$(document).ready(function () {
    getlistcombobox();
    $("#btnbuscar").click(getupdateAlumno);

});

//var getupdateAlumno = function () {
//    var dni = document.getElementById('dni').value;
   
//    $.ajax({
//        url: "/TUsuarios/Edit",
//        type: "GET",
//        data: { id: dni},
//        contentType: "application/json; charset=utf-8",
//        success: function () {
//            //data is your result from controller
//            if (data.success) {
//                alert(data.message);
//            }
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
        data: { dni: dni},
        contentType: "application/json; charset=utf-8",
        success: function () {
            //data is your result from controller
            if (data.success) {
                alert(data.message);
            }
        },
        error: function (xhr) {
            alert('error');
        }
    });
};


var getlistcombobox = function () {
    $.ajax({
        url: "/Alumnohome/Alumnoget",
        type: "GET",
        data: { dni1: dni },
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var selectnivel = $('#dni2'); // va buscar en todo el doc algun elemento que tenga el id 
            document.getElementById("#prueba").innerHTML = "Resultado es: " + selectnivel;
        },
        error: function (response) {
            alert('error');
         }
    });
};