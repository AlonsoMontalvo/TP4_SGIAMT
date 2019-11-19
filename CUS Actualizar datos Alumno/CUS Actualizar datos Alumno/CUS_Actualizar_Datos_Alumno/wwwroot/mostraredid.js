
$(document).ready(function () {
    $("#btn").click(getupdate);
    //getupdateAlumno();

});


var getupdate = function () {
    var dni = document.getElementById('dni').value;

    $.ajax({
        url: "/TUsuarios/Edit",
        type: "GET",
        data: { dni: dni },
        contentType: "application/json; charset=utf-8",
        success: function () {
            //data is your result from controller
            if (data.success) {
                //localStorage.setItem('dni', data.dni);
            }
        },
        error: function (xhr) {
            alert('error');
        }
    });
};

