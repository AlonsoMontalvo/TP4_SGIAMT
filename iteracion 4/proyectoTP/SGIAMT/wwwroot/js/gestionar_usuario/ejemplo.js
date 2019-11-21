$(document).ready(function () {
    getlistcomboboxdni();
    getlistcomboboxdninactivo();
    getlistusuariosactivo(false);
    getlistusuariosinactivo(false);
});

var getlistcomboboxdni = function () {
    $.ajax({
        url: "/TUsuarios/GetComboBoxDni",
        type: "GET",
        //data: { id: id },
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var selectdni = $('#ddni'); // va buscar en todo el doc algun elemento que tenga el id 
            //selectdni.find('option').remove(); // son los elementos
            //selectdni.append('<option value= 0>' + 'Seleccione' + '</option>');
            $.each(response.dni, function (key, value) { //temp es la lista que va recorrer 
                selectdni.append('<option value=' + value.idDni + '>' + value.idDni + '</option>');
            });
        },
        error: function (response) {

        }
    });
};
var getlistusuariosactivo = function (flag) {
    var dni = 0;
    if (flag) {
        dni = $("#ddni").val();
    }
    $.ajax({
        url: "/TUsuarios/UsuarioActivo",
        type: "GET",
        data: { iddni: dni },
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (flag) {
                $('#table-listar-usuario-activo').jqGrid('clearGridData');
                $('#table-listar-usuario-activo').jqGrid('setGridParam', { data: response.listusuarioactivo });
                $('#table-listar-usuario-activo').trigger('reloadGrid');
                $('#table-listar-usuario-activo').trigger('reloadGrid', { page: 1 });
            } else {
                tableUsuariosActivo(response);
            }
        },
        error: function (response) {
        }
    });
};
refreshPager = function (selectorTable, selectorPager) {
    $(selectorTable).navGrid(selectorPager, { add: false, edit: false, del: false, search: false, refresh: true });
};

var tableUsuariosActivo = function (response) {
    $("#table-listar-usuario-activo").jqGrid({
        data: response.listusuarioactivo,
        datatype: "local",
        rowNum: 10,
        rowList: [10, 20, 30],
        colModel: [
            { label: 'DNI', name: 'dni', key: true },
            { label: 'Nombre', name: 'nombre' },
            { label: 'Apellido Paterno', name: 'apellidoP' },
            { label: 'Apellido Materno', name: 'apellidoM' },
            { label: 'Estado', name: 'estado' },
            { label: 'Tipo de Usuario', name: 'tipousu' },
        ],
        onSelectRow: function () {
        },
        loadComplete: function () {
        },
        cmTemplate: { sortable: false },
        pager: "#pager-listar-usuario-activo"
    });

    refreshPager("#table-listar-usuario-activo", "#pager-listar-usuario-activo");

};


var getlistcomboboxdninactivo = function () {
    $.ajax({
        url: "/TUsuarios/GetComboBoxDniInactivo",
        type: "GET",
        //data: { id: id },
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            var selectdninac = $('#ddninac'); // va buscar en todo el doc algun elemento que tenga el id 
            //selectdni.find('option').remove(); // son los elementos
            //selectdni.append('<option value= 0>' + 'Seleccione' + '</option>');
            $.each(response.dni1, function (key, value) { //temp es la lista que va recorrer 
                selectdninac.append('<option value=' + value.idDni2 + '>' + value.idDni2 + '</option>');
            });
        },
        error: function (response) {

        }
    });
};
var getlistusuariosinactivo = function (flag) {
    var dni = 0;
    if (flag) {
        dni = $("#ddninac").val();
    }
    $.ajax({
        url: "/TUsuarios/UsuarioInactivo",
        type: "GET",
        data: { iddni: dni },
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            if (flag) {
                $('#table-listar-usuario-inactivo').jqGrid('clearGridData');
                $('#table-listar-usuario-inactivo').jqGrid('setGridParam', { data: response.listusuarioinactivo });
                $('#table-listar-usuario-inactivo').trigger('reloadGrid');
                $('#table-listar-usuario-inactivo').trigger('reloadGrid', { page: 1 });
            } else {
                tableUsuariosInactivo(response);
            }
        },
        error: function (response) {
        }
    });
};
refreshPager = function (selectorTable, selectorPager) {
    $(selectorTable).navGrid(selectorPager, { add: false, edit: false, del: false, search: false, refresh: true });
};

var tableUsuariosInactivo = function (response) {
    $("#table-listar-usuario-inactivo").jqGrid({
        data: response.listusuarioinactivo,
        datatype: "local",
        rowNum: 10,
        rowList: [10, 20, 30],
        colModel: [
            { label: 'DNI', name: 'dni', key: true },
            { label: 'Nombre', name: 'nombre' },
            { label: 'Apellido Paterno', name: 'apellidoP' },
            { label: 'Apellido Materno', name: 'apellidoM' },
            { label: 'Estado', name: 'estado' },
            { label: 'Tipo de Usuario', name: 'tipousu' }
        ],
        onSelectRow: function () {
        },
        loadComplete: function () {
        },
        cmTemplate: { sortable: false },
        pager: "#pager-listar-usuario-inactivo"
    });

    refreshPager("#table-listar-usuario-inactivo", "#pager-listar-usuario-inactivo");

};