$(document).ready(function () {

    getlistcombobox();
    getlistusuarios(false);
});

var getlistcombobox = function () {
    $.ajax({
        url: "/TAsistencias/GetComboBox",
        type: "GET",
        //data: { id: id },
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var selectnivel = $('#nnivel'); // va buscar en todo el doc algun elemento que tenga el id 
            selectnivel.find('option').remove(); // son los elementos
            selectnivel.append('<option value= 0>' + 'Seleccione' + '</option>');
            $.each(response.nivel, function (key, value) { //temp es la lista que va recorrer 
                selectnivel.append('<option value=' + value.pkInCod + '>' + value.vnNombreNivel + '</option>');
            });
            var selecttnivel = $('#tnivel');
            selecttnivel.find('option').remove();
            selecttnivel.append('<option value= 0>' + 'Seleccione' + '</option>');
            $.each(response.tiponivel, function (key, value) {
                selecttnivel.append('<option value=' + value.pkItnCod + '>' + value.itnNombreTipoNivel + '</option>');
            });
        },
        error: function (response) {

        }
    });
};

var getlistusuarios = function (flag) {
    var nivel = 0;
    var tiponivel = 0;
    if (flag) {
        nivel = $("#nnivel").val();
        tiponivel = $("#tnivel").val();
    }
    $.ajax({
        url: "/TAsistencias/GetUsersPagination",
        type: "GET",
        data: { idnivel: nivel, idtiponivel: tiponivel },
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (flag) {//la primera ves que entre sera para listar y el flag sera false , por ende lo redireccionará a tableAsistencia y si agrega o elimina reutilizaremos esta funcionon para no crear mas y no tener mas codigo en vano por ende el flag sera true cuando creemos o eliminemos.
                $('#table-listar-usuarios').jqGrid('clearGridData');
                $('#table-listar-usuarios').jqGrid('setGridParam', { data: response.usuarios });
                $('#table-listar-usuarios').trigger('reloadGrid');
                $('#table-listar-usuarios').trigger('reloadGrid', { page: 1 });
            } else {
                tableUsuarios(response);
            }
        },
        error: function (response) {
        }
    });
};
refreshPager = function (selectorTable, selectorPager) {
    $(selectorTable).navGrid(selectorPager, { add: false, edit: false, del: false, search: false, refresh: true });
};
var tableUsuarios = function (response) {
    $("#table-listar-usuarios").jqGrid({ 
        data: response.usuarios,
        datatype: "local",
        rowNum: 10,
        rowList: [10, 20, 30],
        colModel: [
            { label: 'DNI', name: 'dni', key: true},
            { label: 'Nombre', name: 'nombre'},
            { label: 'Apellido Paterno', name: 'apellidoP' },
            { label: 'Apellido Materno', name: 'apellidoM' },
            { label: 'Nivel', name: 'nivel' },
            { label: 'Tipo de Nivel', name: 'tnivel' },
            {
                label: 'Opciones', name: 'Opciones', formatter: function (cellvalue, options, rowObject) {
                    var norma = '<button onclick="crear(' + options.rowId +')", <a href="#" class="btn btn-primary btn-default"><span class="glyphicon glyphicon-circle-arrow-right"></span> Administrar</a></button>';
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
        pager: "#pager-listar-usuarios"
    });

    refreshPager("#table-listar-usuarios", "#pager-listar-usuarios");

};

var crear = function (iddni) {
    window.location.href = url.CreateAsistencia + '?iddni=' + iddni;
};

