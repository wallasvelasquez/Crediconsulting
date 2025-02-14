$(document).on("submit", "#form-consultar-tarjeta", function (e) {
    e.preventDefault();
    loadShow();
    var tarjetaID = $('#Tarjeta').val();
    if (tarjetaID == 0) {
        swal.fire('Info', 'Por favor elige una tarjeta de la lista', 'info');
        return;
    }
    else {
        $.ajax({
            url: urlGetTransaccionesTarjeta,
            type: 'POST',
            data: { TarjetaID: tarjetaID },
            cache: false,
            success: function (data) {
                if (data.e === 1) {
                    getTransacciones(data.data);
                    loadHide();
                }
            },
            error: function (data) {
                swal.fire('Error', data.msg, 'error');
                loadHide();
            }
        });
    }
});

function getTransacciones(data) {
    if ($.fn.DataTable.isDataTable('#tabla-transacciones')) {
        $('#tabla-transacciones').DataTable().destroy();
    }
    tablatarjetas = $('#tabla-transacciones').DataTable({
        "responsive": true,
        "processing": true,
        "autoWidth": false,
        "ordering": false,
        "language": {
            "paginate": {
                "previous": "<<",
                "next": ">>"
            },
            "info": "Page _PAGE_ to _PAGES_",
            "emptyTable": "No hay transacciones para mostrar"
        },
       "data": data,
       "columns": [
            { "data": "transaccionID", "title": "ID", "width": "5%", "className": "text-center" },
            { "data": "numeroTarjeta", "title": "Numero Tarjeta", "className": "text-center" },
            { "data": "tipoTransaccion", "title": "Tipo Transaccion", "width": "18%", "className": "text-center" },
            {
                "data": "fecha", "title": "Fecha", "width": "10%", "className": "text-center", render: function (d) {
                    return (d == null) ? " " : moment(d).format("YYYY-MM-DD");
                }
            },
            
            {
                "data": "monto", "title": "Monto", "width": "10%", "className": "text-center", render: function (d) {
                    return (d == null) ? " " : "$" + d;
                }
            }
        ]
    });   
}

$(document).on("submit", "#form-consultar-estado-cuenta", function (e) {
    e.preventDefault();
    loadShow();
    var tarjetaID = $('#Tarjeta').val();
    if (tarjetaID == 0) {
        swal.fire('Info', 'Por favor elige una tarjeta de la lista', 'info');
        return;
    }
    else {
        $.ajax({
            url: urlGetEstadoCuentaByTarjeta,
            type: 'GET',
            data: { TarjetaID: tarjetaID },
            cache: false,
            success: function (data) {
                $("#div-estado-cuenta").html("");
                $("#div-estado-cuenta").html(data);
            },
            error: function (data) {
                swal.fire('Error', data.msg, 'error');
                loadHide();
            }
        });
    }
});