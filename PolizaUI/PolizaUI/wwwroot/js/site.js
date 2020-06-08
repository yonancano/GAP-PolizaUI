function AjaxAgregar(datos) {
    $.ajax({
        url: "/Polizas/Agregar",
        async: false,
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: datos,
        success: function (resultado) {
            funcionRetorno(resultado);
        },
        error: function (request, status, error) {
            try {
                manejarErrorJson(request, status, error);
            } catch (e) {
                $("html").empty();
                $("html").html(request.responseText);
            }
        }
    });
}