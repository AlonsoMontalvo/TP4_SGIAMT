var count = 0;
$(document).ready(function () {
    getComboSemana();
    changeselect();
    $("#createAsistencia").click(create);
    getlistasistenciaxusuario(false);
});



var getComboSemana = function () {
    var dni = document.getElementById('dni').value;
    $.ajax({
        url: "/TAsistencias/GetComboSemana",
        type: "GET",
        data: { iddni: dni},
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var selectSemana = $('#PkIsSemana'); // va buscar en todo el doc algun elemento que tenga el id 
            selectSemana.find('option').remove(); // son los elementos
            if (count == 0)//cambie 
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
        url: "/TAsistencias/GetComboDia",
        type: "GET",
        data: { iddni: dni, idsemana: idSemana},
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var selectDia= $('#PkIdDia'); // va buscar en todo el doc algun elemento que tenga el id 
            selectDia.find('option').remove(); // son los elementos
            $.each(response.dias, function (key, value) { //temp es la lista que va recorrer 
                selectDia.append('<option value=' + value.id + '>' + value.value + '</option>');
            });
        },
        error: function (response) {

        }
    });
};

var changeselect = function (){
    $('#PkIsSemana').on('change', function () {
        count++;
        var selectSemana = $('#PkIsSemana'); // va buscar en todo el doc algun elemento que tenga el id 
        selectSemana.find('option[value=0]').remove(); 
        getComboDia(this.value);
    });
};
var eliminar = function (id) {
    var model = {
        idAsistencia: id
    };
    $.ajax({
        url: "/TAsistencias/Delete",
        type: "DELETE",
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            getlistasistenciaxusuario(true);
        },
        error: function (response) {

        }
    });
};
var create = function () {
    var dni = document.getElementById('dni').value;
    var date = new Date();
    var hora = date.getHours() + ':' + date.getMinutes();
    var model = {
        Hora: hora,
        EstadoAsistencia: $("#estadoasistencia").val(),
        DNI: dni,
        IdSemanaDia: 0,
        IdDia: $("#PkIdDia").val(),
        IdSemana: $("#PkIsSemana").val()
    };
    $.ajax({
        url: "/TAsistencias/Create",
        type: "POST",
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            getlistasistenciaxusuario(true,true);
        },
        error: function (response) {

        }
    });
};

var getlistasistenciaxusuario = function (flag, isCreate = false) {
    var dni = document.getElementById('dni').value;
    $.ajax({
        url: "/TAsistencias/GetAsistenciaxUsuario",
        type: "GET",
        data: { iddni: dni },
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (flag) {//la primera ves que entre sera para listar y el flag sera false , por ende lo redireccionará a tableAsistencia y si agrega o elimina reutilizaremos esta funcionon para no crear mas y no tener mas codigo en vano por ende el flag sera true cuando creemos o eliminemos.
                var numberPage;
                if (isCreate)
                    numberPage = $("#table-listar-asistencias").getGridParam('lastpage');
                $('#table-listar-asistencias').jqGrid('clearGridData');
                $('#table-listar-asistencias').jqGrid('setGridParam', { data: response.asistencias });
                $('#table-listar-asistencias').trigger('reloadGrid');
                $('#table-listar-asistencias').trigger('reloadGrid', { page: numberPage });
            } else {
                tableAsistencias(response);
            }
        },
        error: function (response) {
        }
    });
};
refreshPager = function (selectorTable, selectorPager) {
    $(selectorTable).navGrid(selectorPager, { add: false, edit: false, del: false, search: false, refresh: true });
};
var tableAsistencias = function (response) {
    $("#table-listar-asistencias").jqGrid({
        data: response.asistencias,
        datatype: "local",
        rowNum: 5,
        rowList: [5, 10, 20],
        colModel: [
            { label: 'ID', name: 'idasistencia', key: true },
            { label: 'Semana', name: 'semana' },
            { label: 'Día', name: 'dia' },
            { label: 'Hora', name: 'hora' },
            { label: 'Estado de Asistencia', name: 'estadoAsistencia' },
            {
                label: 'Opciones', name: 'Opciones', formatter: function (cellvalue, options, rowObject) {
                    var norma = '<button onclick="eliminar(' +options.rowId+')", <a href="#" class="btn btn-warning btn-default"><span class="glyphicon glyphicon-trash"></span> Eliminar</a></button>';
                    return norma;
                }
            }
        ],
        onSelectRow: function () {
            //var rowKey = $("#table-listar-norma").jqGrid('getGridParam', "selrow");
            //$("#radio-grid-norma-item-" + rowKey).prop("checked", true);
            //selectedNormaId = rowKey;
        },
        loadComplete: function () {
            //if (selectedNormaId > 0) {
            //    var grid = $("#table-listar-norma");
            //    grid.setSelection(selectedNormaId);
            //    $('#radio-grid-norma-item-' + selectedNormaId).attr('checked', true);
            //}

            //$('.ui-pg-input').keydown(function (event) { onlyNumbersWithEnterKeycode(event) });
            //$('.ui-pg-input').keyup(function (event) {
            //    validarNumeroMaximoPaginacion(event, 'sp_1_pager-listar-norma');
            //});
        },
        cmTemplate: { sortable: false },
        pager: "#pager-listar-asistencias"
    });

    refreshPager("#table-listar-asistencias", "#pager-listar-asistencias");

};


//var eliminar = function () {
//    var id = document.getElementById('id').value;
//    $.ajax({
//        // la URL para la petición
//        url: '/TAsistencias/Delete/5',
//        data: { id: id },
//        type: 'POST',
//        contentType: "application/json; charset=utf-8",
//        success: function (response) {
//        },
//        error: function (response) {
//        }
//    });
//};

//$(function () {
//    $(document).on('click', '.eliminar', function (event) {
//        event.preventDefault();
//        $(this).closest('rowId').remove();
//    });
//});
