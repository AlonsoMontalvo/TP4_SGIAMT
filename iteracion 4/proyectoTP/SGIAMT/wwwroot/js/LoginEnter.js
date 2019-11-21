
$(document).ready(function () {

    $("#btnusu").click(getupdate);

});


var getupdate = function () {
    var Dni = document.getElementById('Dni').value;
    var Contra = document.getElementById('Contra').value;
    $.ajax({
        url: "/Account/Login",
        type: "GET",
        data: { Dni: Dni, Contra: Contra },
        contentType: "application/json; charset=utf-8",
        success: function () {
            //data is your result from controller
            if (data.success) {
                localStorage.setItem('Dni', "72223546");
            }
        },
        error: function (xhr) {
            alert('error');
        }
    });
};