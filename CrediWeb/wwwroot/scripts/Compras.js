let tablacompras;

$(document).ready(function () {
    loadShow();
    tablacompras = $('#tabla-compras').DataTable({
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
            "emptyTable": "No hay registros para mostrar"
        },
        "ajax": {
            "url": urlGetCompras,
            "type": 'get',
            "datatype": "json",
            "dataSrc": "data"
        },
        "columns": [
            { "data": "movimientoID", "title": "ID", "width": "5%", "className": "text-center" },
            { "data": "tarjetaID", "title": "tarjetaID", "width": "0%", "className": "text-center", "className": "d-none" },
            {
                "data": "fechaMovimiento", "title": "Fecha Compra", "className": "text-center", render: function (d) {
                    return (d == null) ? " " : moment(d).format("YYYY-MM-DD");
                }
            },
            { "data": "descripcion", "title": "Descripcion", "className": "text-center" },
            {
                "data": "monto", "title": "Monto Compra", "className": "text-center", render: function (d) {
                    return (d == null) ? " " : "$" + d;
                }
            }
        ]
    });
    loadHide();
});

$(document).on("submit", "#form-nueva-compra", function (e) {
    e.preventDefault();
    loadShow();
    var form = this;
    var tarjetaID = $('#Tarjeta').val();
    var formularioCompra = document.getElementById("form-nueva-compra");
    if (tarjetaID === "0" || parseInt(tarjetaID, 10) === 0) {
        swal.fire("Info", "Por favor elija una tarjeta de la lista", "info");
        loadHide();
        return;
    }
    var formData = new FormData(form);
    formData.append('TarjetaID', tarjetaID);
    $.ajax({
        url: urlNewCompra,
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        cache: false,
        success: function (data) {
            if (data.e === 1) {
                $('#ModalCompra').modal('hide');
                $('.modal-backdrop').remove();
                formularioCompra.reset();
                swal.fire('Success', data.msg, 'success');
                tablacompras.ajax.reload();
                loadHide();
            }
        },
        error: function (data) {
            swal.fire('Error', data.msg, 'error');
            loadHide();
        }
    });
});

$(document).on("click", "#btn-new-compra", function (e) {
    e.preventDefault();
    var formularioCompra = document.getElementById("form-nueva-compra");
    formularioCompra.reset();
})