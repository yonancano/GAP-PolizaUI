//ToDo: cambiar action links
function editar(IdPoliza) {
    $.ajax({
        url: "/Polizas/Editar/" + IdPoliza,
        async: false,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: IdPoliza
    });
}

function getAsociar(Cliente) {
    $.get("/Clientes/Asociar", { Cliente: ModeloCliente(Cliente) });
}


function asociar(IdCliente, Poliza) {
    $.post("Clientes/Asociar", { IdCliente: IdCliente, Poliza: ModeloPoliza(Poliza)});
}

function cancelar(IdCliente,IdPoliza) {
    $.post("Clientes/Cancelar", { IdCliente: IdCliente, IdPoliza: IdPoliza});
}

function ModeloPoliza(poliza) {
    return {
        IdPoliza: poliza.IdPoliza,
        IdCliente: poliza.IdCliente,
        Nombre: poliza.Nombre,
        Descripcion: poliza.Descripcion,
        TipoCubrimiento: poliza.TipoCubrimiento,
        PorcentajeCobertura: poliza.PorcentajeCobertura,
        InicioVigencia: poliza.InicioVigencia,
        PeriodoCobertura: poliza.PeriodoCobertura,
        Precio: poliza.Precio,
        TipoRiesgo: poliza.TipoRiesgo
    }
}

function ModeloCliente(cliente) {
    return {
        IdCliente: cliente.IdCliente,
        Nombre: cliente.Nombre,
        Email: cliente.Email
    }
}