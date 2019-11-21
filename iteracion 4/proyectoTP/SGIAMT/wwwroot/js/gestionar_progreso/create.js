
var count = 0;
$(document).ready(function () {
    getComboSemana();
    changeselect();
    $("#createProgreso").click(create);
    getlistaprogresoxusuario(false);
});

var getComboSemana = function () {
    var dni = document.getElementById('dni').value;
    $.ajax({
        url: "/TProgresoes/GetComboSemana",
        type: "GET",
        data: { iddni: dni },
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var selectSemana = $('#PkIsSemana'); // va buscar en todo el doc algun elemento que tenga el id 
            selectSemana.find('option').remove(); // son los elementos
            if (count === 0)//cambie 
                selectSemana.append('<option value="0" selected>--Seleccione</option>');
            $.each(response.semanas, function (key, value) { //temp es la lista que va recorrer 
                selectSemana.append('<option value=' + value.id + '>' + value.value + '</option>');
            });
        },
        error: function (response) {

        }
    });
};

var getComboDia = function (idSemana) {
    var dni = document.getElementById('dni').value;
    $.ajax({
        url: "/TProgresoes/GetComboDia",
        type: "GET",
        data: { iddni: dni, idsemana: idSemana },
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var selectDia = $('#PkIdDia'); // va buscar en todo el doc algun elemento que tenga el id 
            selectDia.find('option').remove(); // son los elementos
            $.each(response.dias, function (key, value) { //temp es la lista que va recorrer 
                selectDia.append('<option value=' + value.id + '>' + value.value + '</option>');
            });
        },
        error: function (response) {

        }
    });
};

var changeselect = function () {
    $('#PkIsSemana').on('change', function () {
        count++;
        var selectSemana = $('#PkIsSemana'); // va buscar en todo el doc algun elemento que tenga el id 
        selectSemana.find('option[value=0]').remove();
        getComboDia(this.value);
    });
};


var eliminar = function (id) {
    var model = {
        idProgreso: id
    };
    $.ajax({
        url: "/TProgresoes/Delete",
        type: "DELETE",
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            getlistaprogresoxusuario(true);
        },
        error: function (response) {

        }
    });
};
var create = function () {

    var dni = document.getElementById('dni').value;

    //var hora = date.getHours() + ':' + date.getMinutes();
    var model = {
        Nombre: $("#nombreP").val(),
        NotaPasos: $("#DpNotaPasos").val(),
        NotaTecnica: $("#DpNotaTecnica").val(),
        NotaInteres: $("#DpNotaInteres").val(),
        NotaHabilidad: $("#DpNotaHabilidad").val(),
        Total: $("#DpTotalNota").val(),
        Observacion: $("#VpObservacion").val(),
        DNI: dni,
        IdSemanaDia: 0,
        IdDia: $("#PkIdDia").val(),
        IdSemana: $("#PkIsSemana").val()
    };
    $.ajax({
        url: "/TProgresoes/Create",
        type: "POST",
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            getlistaprogresoxusuario(true, true);
        },
        error: function (response) {

        }
    });
};

var getlistaprogresoxusuario = function (flag, isCreate = false) {
    var dni = document.getElementById('dni').value;
    $.ajax({
        url: "/TProgresoes/GetProgresoxUsuario",
        type: "GET",
        data: { iddni: dni },
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (flag) {//la primera ves que entre sera para listar y el flag sera false , por ende lo redireccionará a tableAsistencia y si agrega o elimina reutilizaremos esta funcionon para no crear mas y no tener mas codigo en vano por ende el flag sera true cuando creemos o eliminemos.
                var numberPage;
                if (isCreate)
                    numberPage = $("#table-listar-usuarios").getGridParam('lastpage');
                $('#table-listar-usuarios').jqGrid('clearGridData');
                $('#table-listar-usuarios').jqGrid('setGridParam', { data: response.progresos });
                $('#table-listar-usuarios').trigger('reloadGrid');
                $('#table-listar-usuarios').trigger('reloadGrid', { page: numberPage });
            } else {
                tableProgresos(response);
            }
        },
        error: function (response) {
        }
    });
};
refreshPager = function (selectorTable, selectorPager) {
    $(selectorTable).navGrid(selectorPager, { add: false, edit: false, del: false, search: false, refresh: true });
};
var tableProgresos = function (response) {
    $("#table-listar-usuarios").jqGrid({
        data: response.progresos,
        datatype: "local",
        rowNum: 5,
        rowList: [5, 10, 20],
        colModel: [
            { label: 'ID', name: 'idprogreso', key: true },
            { label: 'Nombre', name: 'nombre' },
            { label: 'Nota Pasos', name: 'notaPasos' },
            { label: 'Nota Tecnica', name: 'notaTecnica' },
            { label: 'Nota Interes', name: 'notaInteres' },
            { label: 'Nota Habilidad', name: 'notaHabilidad' },
            { label: 'Total', name: 'totalNota' },
            { label: 'Observacion', name: 'observacion' },

            {
                label: 'Opciones', name: 'Opciones', formatter: function (cellvalue, options, rowObject) {
                    var norma = '<button onclick="eliminar(' + options.rowId + ')", <a href="#" class="btn btn-danger"><span class="glyphicon glyphicon-trash"></span> Eliminar</a></button>';
                    return norma;
                }
            }
        ],
        onSelectRow: function () {

        },
        loadComplete: function () {

        },
        cmTemplate: { sortable: false },
        pager: "#pager-listar-usuarios"
    });

    refreshPager("#table-listar-usuarios", "#pager-listar-usuarios");

};