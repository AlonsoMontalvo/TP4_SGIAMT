$(document).ready(function () {

    getlistcombobox2();
    getlistusuariosxprogres(false);
});

var getlistcombobox2 = function () {
    $.ajax({
        url: "/TUsuarioxProgresoes/GetComboBox",
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

var eliminar = function (id) {
    var model = {
        idAsistencia: id
    };
    $.ajax({
        url: "/TUsuarioxProgresoes/Delete",
        type: "DELETE",
        data: JSON.stringify(model),
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            getlistusuariosxprogres(true);
        },
        error: function (response) {

        }
    });
};


var getlistusuariosxprogres = function (flag) {
    var nivel = 0;
    var tiponivel = 0;
    if (flag) {
        nivel = $("#nnivel").val();
        tiponivel = $("#tnivel").val();
    }
    $.ajax({
        url: "/TUsuarioxProgresoes/GetUsersPagination2",
        type: "GET",
        data: { idnivel: nivel, idtiponivel: tiponivel },
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (flag) {//la primera ves que entre sera para listar y el flag sera false , por ende lo redireccionará a tableAsistencia y si agrega o elimina reutilizaremos esta funcionon para no crear mas y no tener mas codigo en vano por ende el flag sera true cuando creemos o eliminemos.
                $('#table-listar-usuarios').jqGrid('clearGridData');
                $('#table-listar-usuarios').jqGrid('setGridParam', { data: response.usuarioXprogreso });
                $('#table-listar-usuarios').trigger('reloadGrid');
                $('#table-listar-usuarios').trigger('reloadGrid', { page: 1 });
            } else {
                tableUsuariosxProgreso(response);
            }
        },
        error: function (response) {
        }
    });
};
refreshPager = function (selectorTable, selectorPager) {
    $(selectorTable).navGrid(selectorPager, { add: false, edit: false, del: false, search: false, refresh: true });
};
var tableUsuariosxProgreso = function (response) {
    $("#table-listar-usuarios").jqGrid({
        data: response.usuarioXprogreso,
        datatype: "local",
        rowNum: 10,
        rowList: [10, 20, 30],
        colModel: [
            { label: 'DNI', name: 'dni', key: true },
            { label: 'Nombre', name: 'nombre' },
            { label: 'Apellido Paterno', name: 'apellidoP' },
            { label: 'Apellido Materno', name: 'apellidoM' },
            { label: 'Nivel', name: 'nivel' },
            { label: 'Tipo de Nivel', name: 'tnivel' },
            { label: 'Nombre de Profesor', name: 'nombrep' },
            { label: 'Nombre de Progreso', name: 'codigop' },
            { label: 'Semana', name: 'semana' },
            {
                label: 'Opciones', name: 'Opciones', formatter: function (cellvalue, options, rowObject) {
                    var norma = '<button onclick="eliminar(' + options.rowId + ')", <a href="#" class="btn btn-primary btn-default"><span class="glyphicon glyphicon-circle-arrow-right"></span>Eliminar</a></button>';
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