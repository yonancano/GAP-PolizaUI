//ToDo: cambiar action links
function editar(poliza) {
    debugger;
    $.ajax({
        url: "/Polizas/Editar/",
        async: false,
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: poliza,
        success: function (data) {
            window.location.href = data;
        }
    });
}
