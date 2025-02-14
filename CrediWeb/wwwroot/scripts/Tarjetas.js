let tablatarjetas;

$(document).ready(function () {
    loadShow();
    tablatarjetas = $('#tabla-tarjetas').DataTable({
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
            "url": urlGetTarjetas,
            "type": 'get',
            "datatype": "json",
            "dataSrc": "data"
        },
        "columns": [
            { "data": "tarjetaID", "title": "ID", "width": "5%", "className": "text-center" },
            { "data": "titularID", "title": "titularID", "width": "0%", "className": "text-center", "className": "d-none" },
            { "data": "numeroTarjeta", "title": "Numero Tarjeta", "className": "text-center" },
            {
                "data": "fechaExpiracion", "title": "Fecha Expiracion", "width": "10%", "className": "text-center" , render: function (d) {
                    return (d == null) ? " " : moment(d).format("YYYY-MM-DD");
                }
            },
            { "data": "cvv", "title": "CVV", "width": "5%", "className": "text-center" },
            {
                "data": "limiteCredito", "title": "Limite Credito", "width": "15%", "className": "text-center", render: function (d) {
                    return (d == null) ? " " : "$"+d;
                }
            },
            {
                "data": "porcentajeInteresConfigurable", "title": "% Interes Configurable", "width": "15%", "className": "text-center", render: function (d) {
                    return (d == null) ? " " : d+"%";
                }
            },
            {
                "data": "porcentajeConfigurableSaldoMinimo", "title": "% Saldo Minimo", "className": "text-center", render: function (d) {
                    return (d == null) ? " " : d + "%";
                }
            }
        ]
    });
    loadHide();
});

$(document).on("submit", "#form-nueva-tarjeta", function (e) {
    e.preventDefault();
    loadShow();
    var form = this;   
    var titularID = $('#Titular').val();
    var formularioTarjeta = document.getElementById("form-nueva-tarjeta");
    if (titularID === "0" || parseInt(titularID, 10) === 0) {
        swal.fire("Info", "Por favor elija un titular de la lista", "info");
        loadHide();
        return;
    }
    var formData = new FormData(form);
    formData.append('TitularID', titularID);
    $.ajax({
        url: urlNewTarjeta,
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        cache: false,
        success: function (data) {
            if (data.e === 1) {
                $('#ModalTarjeta').modal('hide');
                $('.modal-backdrop').remove();
                formularioTarjeta.reset();
                swal.fire('Success', data.msg, 'success');
                tablatarjetas.ajax.reload();
                loadHide();
            }
        },
        error: function (data) {
            swal.fire('Error', data.msg, 'error');
            loadHide();
        }
    });
});

$(document).on("click", "#btn-nueva-tarjeta", function (e) {
    e.preventDefault();
    var formularioTarjeta = document.getElementById("form-nueva-tarjeta");
    formularioTarjeta.reset();
})