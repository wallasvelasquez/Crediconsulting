function loadHide() {
    $('#loader').hide();
}

function loadShow() {
    $('#loader').show();
}


$(document).ready(function () {
    loadShow();
    setTimeout(function () {
        loadHide();
    }, 3000);
});