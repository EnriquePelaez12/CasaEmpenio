using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Cliente_Dat
    {
        Utileria_Dat _UtileriaDat = new Utileria_Dat();
        public Modelo.Respuesta_Operacion_Mod Cliente_Insertar(Modelo.Cliente_Mod oCliente)
        {
            var oRespuesta = new Modelo.Respuesta_Operacion_Mod();
            try
            {
                var listParametros = new List<SqlParameter>();
                listParametros.Add(new SqlParameter("@Cliente_Id", SqlDbType.Int) { Value = oCliente.Cliente_Id });
                listParametros.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 30) { Value = oCliente.Cliente_Nombre });
                listParametros.Add(new SqlParameter("@Apellido_Paterno", SqlDbType.VarChar, 30) { Value = oCliente.Cliente_Apellido_Paterno });
                listParametros.Add(new SqlParameter("@Apellido_Materno", SqlDbType.VarChar, 30) { Value = oCliente.Cliente_Apellido_Materno });
                listParametros.Add(new SqlParameter("@Ocupacion_Id", SqlDbType.Int) { Value = oCliente.Ocupacion_Id });

                listParametros.Add(new SqlParameter("@Direccion", SqlDbType.VarChar, 80) { Value = oCliente.Cliente_Direccion });
                listParametros.Add(new SqlParameter("@Telefono", SqlDbType.VarChar, 20) { Value = oCliente.Cliente_Telefono });
                listParametros.Add(new SqlParameter("@Sexo_Id", SqlDbType.Int) { Value = oCliente.Sexo_Id });
                listParametros.Add(new SqlParameter("@Estado_Civil_Id", SqlDbType.Int) { Value = oCliente.Estado_Civil_Id });
                listParametros.Add(new SqlParameter("@Colonia_Id", SqlDbType.Int) { Value = oCliente.Colonia_Id });

                listParametros.Add(new SqlParameter("@Estado_Id", SqlDbType.Int) { Value = oCliente.Estado_Id });
                listParametros.Add(new SqlParameter("@Municipio_Id", SqlDbType.Int) { Value = oCliente.Municipio_Id });
                listParametros.Add(new SqlParameter("@Cliente_Celular", SqlDbType.VarChar, 15) { Value = oCliente.Cliente_Celular });
                listParametros.Add(new SqlParameter("@Cliente_Email", SqlDbType.VarChar, 50) { Value = oCliente.Cliente_Email });
                listParametros.Add(new SqlParameter("@Cliente_CP", SqlDbType.VarChar, 10) { Value = oCliente.Cliente_Cp });
                listParametros.Add(new SqlParameter("@Cotitular", SqlDbType.VarChar, 50) { Value = oCliente.Cotitular });

                // Parametros de salida                
                listParametros.Add(new SqlParameter("@Codigo", SqlDbType.SmallInt) { Value = 0, Direction = ParameterDirection.Output });
                listParametros.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 250) { Value = "", Direction = ParameterDirection.Output });

                var oDataResult = _UtileriaDat.Exec_StoredProcGenerico(SP.SP_CLIENTE_INSERTAR, listParametros);
                oRespuesta.OperacionId = oDataResult.OperacionId; oRespuesta.OperacionDes = oDataResult.OperacionDes;              
            }
            catch (Exception ex)
            {
                //Registrar en Log
            }
            return oRespuesta;
        }
        public List<Modelo.Cliente_Mod> Cliente_Busqueda(Modelo.Cliente_Mod oCliente)
        {
            var oLista = new List<Modelo.Cliente_Mod>();
            try
            {
                var listParametros = new List<SqlParameter>();
                listParametros.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = oCliente.Cliente_Id });
                listParametros.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 250) { Value = oCliente.Cliente_Nombre });

                // Parametros de salida                
                listParametros.Add(new SqlParameter("@Codigo", SqlDbType.SmallInt) { Value = 0, Direction = ParameterDirection.Output });
                listParametros.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 250) { Value = "", Direction = ParameterDirection.Output });

                var oDataResult = _UtileriaDat.Exec_StoredProcGenerico(SP.SP_CLIENTE_BUSQUEDA, listParametros);
                //oRespuesta.OperacionId = oDataResult.OperacionId; oRespuesta.OperacionDes = oDataResult.OperacionDes;
                foreach (DataRow item in oDataResult.oDataTable.Rows)
                {
                    oLista.Add(new Modelo.Cliente_Mod()
                    {
                        Cliente_Id = int.Parse(item["Id"].ToString()),
                        Cliente_Nombre = item["Nombre"].ToString(),
                        Cliente_Apellido_Paterno = item["Apellido_Paterno"].ToString(),
                        Cliente_Apellido_Materno = item["Apellido_Materno"].ToString(),
                        Cliente_Direccion = item["Direccion"].ToString(),
                        Cliente_Email = item["Email"].ToString(),
                        Cliente_Celular = item["Celular"].ToString(),
                        Cliente_Telefono = item["Telefono"].ToString(),
                        Cotitular = item["Cotitular"].ToString(),
                        Estado_Id = int.Parse(item["Estado_Id"].ToString()),
                        Estado_Descripcion = item["Estado"].ToString(),
                        Municipio_Id = int.Parse(item["Municipio_Id"].ToString()),
                        Municipio_Descripcion = item["Municipio"].ToString(),
                        Colonia_Id = int.Parse(item["Colonia_Id"].ToString()),
                        Colonia_Descripcion = item["Colonia"].ToString(),
                        Ocupacion_Id = int.Parse(item["Ocupacion_Id"].ToString()),
                        Ocupacion_Descripcion = item["Ocupacion"].ToString(),
                        Sexo_Id = int.Parse(item["Sexo_Id"].ToString()),
                        Sexo_Descripcion = item["Sexo"].ToString(),
                        Estado_Civil_Id = int.Parse(item["Estado_Civil_Id"].ToString()),
                        EstadoCivil_Descripcion = item["Estado_Civil"].ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                //TODO: Registrar en Log
            }
            return oLista;
        }
    }
}
