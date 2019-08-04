function ajaxRequest(pUrl, pTipoPeticion, pParametros, pFuncionRespuesta) {
    //mostrarProgreso("Espere por favor");
    $.ajax({
        url: pUrl,
        type: pTipoPeticion,
        data: (pParametros) ? JSON.stringify(pParametros) : '',
        contentType: oConstantes.getReq_contenType(),
        dataType: "json",
        success: pFuncionRespuesta,
        timeout: oConstantes.getTimeOut(),
        error: function (response) {            
            if (typeof (response.responseJSON) !== "undefined")
                alert("Error: " + response.responseJSON.desc, false);
            else
                alert("Error: " + response.statusText, false);
        }
    });
}