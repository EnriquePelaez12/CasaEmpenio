var Constantes = (function () {
    _req_contenType = 'application/json; charset=UTF-8';        
    _timeOut = 40000; // 5 segundos: 5000
    //_server = 'http://www.contoso.com/xxx/';
    _tiempoPantalla = 3000; // 3 segundos 

    return {
        getReq_contenType: function () { return _req_contenType; },        
        getTimeOut: function () { return _timeOut; },        
        getTiempoPantalla: function () { return _tiempoPantalla; },
    };
});