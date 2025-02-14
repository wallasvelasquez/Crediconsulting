let tablapagos;

$(document).ready(function () {
    loadShow();
    tablapagos = $('#tabla-pagos').DataTable({
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
            "url": urlGetPagos,
            "type": 'get',
            "datatype": "json",
            "dataSrc": "data"
        },
        "columns": [
            { "data": "pagoID", "title": "ID", "width": "5%", "className": "text-center" },
            { "data": "tarjetaID", "title": "tarjetaID", "width": "0%", "className": "text-center", "className": "d-none" },
            {
                "data": "fechaPago", "title": "Fecha Pago", "className": "text-center", render: function (d) {
                    return (d == null) ? " " : moment(d).format("YYYY-MM-DD");
                }
            },           
            {
                "data": "monto", "title": "Monto Compra", "className": "text-center", render: function (d) {
                    return (d == null) ? " " : "$" + d;
                }
            },
            { "data": "metodoPago", "title": "Metodo Pago", "className": "text-center" },

        ]
    });
    loadHide();
});

$(document).on("submit", "#form-nuevo-pago", function (e) {
    e.preventDefault();
    loadShow();
    var form = this;
    var formularioPago = document.getElementById("form-nuevo-pago");
    var tarjetaID = $("#Tarjeta").val();
    var metodo = $("#MetodoPago").val();
    if (tarjetaID === "0" || parseInt(tarjetaID, 10) === 0){
        swal.fire("Info", "Por favor elija una tarjeta de la lista", "info");
        loadHide();
        return;
    }
    if (metodo === "0") {
        swal.fire("Info", "Por favor elija un metodo de pago de la lista", "info");
        loadHide();
        return;
    }
    var formData = new FormData(form);
    formData.append("TarjetaID", tarjetaID);
    formData.append("MetodoPago", metodo);
    $.ajax({
        url: urlNewPago,
        type: "POST",
        data: formData,
        processData: false,
        contentType: false,
        cache: false,
        success: function (data) {
            if (data.e === 1) {
                formularioPago.reset();
                $("#ModalPago").modal("hide");
                $(".modal-backdrop").remove();
                swal.fire("Success", data.msg, "success");
                tablapagos.ajax.reload();
                loadHide();
            }
        },
        error: function (data) {
            swal.fire('Error', data.msg, 'error');
            loadHide();
        }
    });
});

$(document).on("click", "#btn-new-pago", function (e) {
    e.preventDefault();
    var formularioPago = document.getElementById("form-nuevo-pago");
    formularioPago.reset();
})