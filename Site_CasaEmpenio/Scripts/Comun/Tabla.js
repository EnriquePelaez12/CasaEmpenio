var oConstantes = Constantes();

class Tabla {

    constructor(nombre, nombreFicha, ) {
        this.nombre = nombre;
        this.nombreFicha = nombreFicha;

        var tabla = `<div class="card">
                                    <div class="card-header card-header-icon" data-background-color="purple">
                                        <i class="material-icons">assignment</i>
                                    </div>
                                    <div class="card-content">
                                        <h4 class="card-title">` + nombreFicha + `</h4>
                                        <div class="toolbar">
                                            <div class="row">
                                                <form class="navbar-form navbar-left" role="search">
                                                <!--        Here you can write extra buttons/actions for the toolbar-->
                                                <div class="form-group form-search is-empty">
                                                <input id="txtIdDescripcion" type="text" class="form-control" placeholder="Id/Nombre">
                                                <span class="material-input"></span>
                                                <span class="material-input"></span></div>
                                                <button id="btnIdDescripcion" type="button" class="btn btn-white btn-round btn-just-icon">
                                                    <i class="material-icons">search</i>
                                                    <div class="ripple-container"></div>
                                                </button>
                                                </form>
                                            </div>
                                        </div>
                                        <div class="material-datatables">
                                            <table id="datatables" class="table table-striped table-no-bordered table-hover dt-responsive nowrap" style="width:100%">
                                                <thead>
                                                </thead>
                                                <tfoot></tfoot>
                                                <tbody></tbody>
                                            </table>
                                       </div>
                                    </div>
                                </div>`;
        $("#tablaGenerica").append(tabla);

        switch (nombre) {
            case "CLIENTE":
                this.cliente_CargarEncabezado();                
                break;
            default:
        }               
    }

    

    //****************************************  CLIENTE
    cliente_CargarEncabezado() {       
        $('#datatables').DataTable({            
            "pagingType": "full_numbers",
            "lengthMenu": [
                [10, 25, 50, -1],
                [10, 25, 50, "All"]
            ],
            responsive: true,
            "ordering": false,
            language: {
                lengthMenu: "Mostrar _MENU_ registros por página",
                search: "_INPUT_",
                searchPlaceholder: "Buscar en tabla",
                zeroRecords: "Sin registros",
                info: "Página _PAGE_ de _PAGES_",
            },         
            columns: [                
                { title: "Id" },
                { title: "Nombre" },
                { title: "A. Paterno" },
                { title: "A. Materno" },
                { title: "Dirección" },
                { title: "Email" },
                { title: "Celular" },
                { title: "Teléfono" },
                { title: "Cotitular" },
                { title: "Estado" },
                { title: "Municipio" },
                { title: "Colonia" },
                { title: "Ocupación" },
                { title: "Sexo" },
                { title: "Estado Civil" },
                { title: "Acciones" }
            ]            
        });        
    }

    cliente_Busqueda(parametros) {
        ajaxRequest(UrlSettings.url_Cliente_Busqueda, "POST", parametros, function (response) {
            console.log("cliente_Busqueda: ", response);

            $('#datatables').DataTable().destroy();            
            $('#datatables').DataTable({
                "pagingType": "full_numbers",
                "lengthMenu": [
                    [10, 25, 50, -1],
                    [10, 25, 50, "All"]
                ],
                responsive: true,
                "ordering": false,
                language: {
                    lengthMenu: "Mostrar _MENU_ registros por página",
                    search: "_INPUT_",
                    searchPlaceholder: "Buscar en tabla",
                    zeroRecords: "Sin registros",
                    info: "Página _PAGE_ de _PAGES_",
                },
                data: response,                
                columns: [
                    { title: "Id", data: "Cliente_Id", width: "70px", className: 'dt-head-right text-right' },
                    { title: "Nombre", data: "Cliente_Nombre" },
                    { title: "A. Paterno", data: "Cliente_Apellido_Paterno" },
                    { title: "A. Materno", data: "Cliente_Apellido_Materno" },
                    { title: "Dirección", data: "Cliente_Direccion" },
                    { title: "Email", data: "Cliente_Email" },
                    { title: "Celular", data: "Cliente_Celular" },
                    { title: "Teléfono", data: "Cliente_Telefono" },
                    { title: "Cotitular", data: "Cotitular" },
                    { title: "Estado", data: "Estado_Descripcion" },
                    { title: "Municipio", data: "Municipio_Descripcion" },
                    { title: "Colonia", data: "Colonia_Descripcion" },
                    { title: "Ocupación", data: "Ocupacion_Descripcion" },
                    { title: "Sexo", data: "Sexo_Descripcion" },
                    { title: "Estado Civil", data: "EstadoCivil_Descripcion" },
                    {                        
                        //title: "Acciones", className: '', orderable: false,                        
                        title: "Acciones", orderable: false, data: null, render: function (data, type, row) {
                            return '<a href="' + UrlSettings.url_Cliente_Modificar + '?pCliente_Id=' + data.Cliente_Id + '" class="btn btn-simple btn-warning btn-icon edit"><i class="material-icons">edit</i></a>'
                        }
                    }
                ]               
            });            
        });       
    }
    //****************************************
};