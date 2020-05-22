$(document).ready(function () {
    $('#btnNotificacion').hide();
    loadDataTable();

    $.ajax({
        url: '/Producto/GetTienda/',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            var clasificacion = $("#cbxTienda");
            var datos = data.data;
            $(datos).each(function (i, v) {
                clasificacion.append('<option value="' + v.Id + '">' + v.Nombre + '</option>');
            });
        },
        error: function () {
            console.log('error');
        }
    });

    function loadDataTable() {
        var table = $('#datatable').DataTable({
            "processing": true,
            "ajax": {
                "url": "/Producto/GetProducto",
                "type": "GET"
            },
            "columns": [
                { "data": "SKU" },
                { "data": "NOMBRE" },
                { "data": "DESCRIPCION" },
                { "data": "VALOR" },
                { "data": "NOMBRE_TIENDA" },
                { "defaultContent": " <button class='btn btn-info' id='btnEditar'><span class='glyphicon glyphicon-pencil'></span></button> <button class='btn btn-danger' id='btnEliminar'><span class='glyphicon  glyphicon-trash'></span></button>" }
            ]
        });
        GetData("#datatable", table);
    }

    function GetData(tbody, table) {
        $(tbody).on('click', '#btnEditar', function () {
            var objDatos = table.row($(this).parents('tr')).data();
            $('#Sku').val(objDatos.SKU);
            $('#Nombre').val(objDatos.NOMBRE);
            $('#Descripcion').val(objDatos.DESCRIPCION);
            $('#valor').val(objDatos.VALOR);
            $('#cbxTienda').val(objDatos.IdTienda);
            $("#Sku").attr("readonly", "readonly");
        });

        $(tbody).on('click', '#btnEliminar', function () {
            var objDatos = table.row($(this).parents('tr')).data();
            var sku = objDatos.SKU;
            $.ajax({
                url: '/Producto/EliminarProducto/',
                type: 'POST',
                dataType: 'json',
                data: { Sku: sku },
                success: function (data) {
                    var result = data.data;
                    if (result.Succes) {
                        $('#lblmensaje').text('' + result.Mensaje);
                        $('#divmensaje').addClass('alert alert-success');
                        $('#divmensaje').show();
                        setTimeout(function () {
                            $('#divmensaje').fadeOut(1000);
                        }, 2000);
                        $('#datatable').DataTable().ajax.reload();
                    } else {
                       var texto = "No se eliminó el registro";
                        $('#lblmensaje').text(texto);
                        $('#divmensaje').addClass('alert alert-danger');
                        $('#divmensaje').show();
                        setTimeout(function () {
                            $('#divmensaje').fadeOut(1000);
                        }, 2000);
                    }
                },
                error: function () {
                    console.log('error');
                }
            });

        });
    }

    $('#btnGuardar').click(function () {
        //declarar objeto
        nuevoProducto = {};
        nuevoProducto.Sku = $('#Sku').val();
        nuevoProducto.Nombre = $('#Nombre').val();
        nuevoProducto.Descripcion = $('#Descripcion').val();
        nuevoProducto.Valor = $('#valor').val();
        nuevoProducto.IdTienda = $('#cbxTienda').val();

        $.ajax({
            url: '/Producto/GuardarProducto/',
            type: 'POST',
            dataType: 'json',
            data: nuevoProducto,
            success: function (data) {
                var result = data.data;
                if (result.Succes) {
                    $('#lblmensaje').text('' + result.Mensaje);
                    $('#divmensaje').addClass('alert alert-success');
                    $('#divmensaje').show();
                    setTimeout(function () {
                        $('#divmensaje').fadeOut(1000);
                    }, 2000);
                    $('#datatable').DataTable().ajax.reload();
                } else {
                    var texto = "No se guardo el registro";
                    $('#lblmensaje').text(texto);
                    $('#divmensaje').addClass('alert alert-danger');
                    $('#divmensaje').show();
                    setTimeout(function () {
                        $('#divmensaje').fadeOut(1000);
                    }, 2000);
                }

                $('#Sku').val('');
                $('#Nombre').val('');
                $('#Descripcion').val('');
                $('#valor').val('');
                $('#cbxTienda').val('');
                $("#Sku").removeAttr("readonly");
            },
            error: function () {
                console.log('error');
            }
        });
    });
}); 