let tablatitulares;

$(document).ready(function () {
    loadShow();
    tablatitulares = $('#tabla-titulares').DataTable({
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
            "url": urlGetTitulares,
            "type": 'get',
            "datatype": "json",
            "dataSrc": "data" 
        },
        "columns": [
            { "data": "titularID", "title": "ID", "width": "5%", "className": "text-center" },
            { "data": "nombres", "title": "Nombres", "className": "text-center" },
            { "data": "apellidos", "title": "Apellidos", "className": "text-center" },
            { "data": "correo", "title": "Correo", "width": "20%", "className": "text-center"}
        ]
    });
    loadHide();
});

$(document).on("submit", "#form-nuevo-titular", function (e) {
    e.preventDefault();
    loadShow();
    var form = this;
    var formularioTitular = document.getElementById("form-nuevo-titular");
    var formData = new FormData(form);
    $.ajax({
        url: urlNewTitular,
        type: 'POST',
        data: formData,
        processData: false,
        contentType: false,
        cache: false,
        success: function (data) {
            if (data.e === 1) {
                $('#ModalTitular').modal('hide');
                $('.modal-backdrop').remove();
                formularioTitular.reset();
                swal.fire('Success', data.msg, 'success');
                tablatitulares.ajax.reload();
                loadHide();
            }
        },
        error: function (data) {
            swal.fire('Error', data.msg, 'error');
            loadHide();
        }
    });
});

$(document).on("click", "#btn-new-titular", function (e) {
    e.preventDefault();
    var formularioTitular = document.getElementById("form-nuevo-titular");
    formularioTitular.reset();
})