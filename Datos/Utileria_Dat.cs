using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Modelo;

namespace Datos
{   
    public class Utileria_Dat
    {
        #region Constantes/Configuracion
        private string cadenaConexion = System.Configuration.ConfigurationManager.ConnectionStrings["ConexCasaEmpenio"].ConnectionString;
        private SqlConnection Conexion;
        #endregion
        #region Métodos públicos        
        public Respuesta_StoredProcGenerico_Mod Exec_StoredProcGenerico(SP nombreSP, List<SqlParameter> parametros)
        {            
            var oResult = new Respuesta_StoredProcGenerico_Mod();
            try
            {
                using (Conexion = new SqlConnection(cadenaConexion))
                {
                    Conexion.Open();
                    using (var oComando = new SqlCommand(nombreSP.ToString(), Conexion))
                    {
                        oComando.CommandType = System.Data.CommandType.StoredProcedure;
                        oComando.Parameters.Clear();
                        oComando.Parameters.AddRange(parametros.ToArray());

                        using (var oLector = oComando.ExecuteReader())
                        {
                            if (oLector.HasRows)
                                oResult.oDataTable.Load(oLector);
                        }
                        var res = oComando.Parameters["@Codigo"].Value.ToString();
                        oResult.OperacionId = (OperacionEnum)Enum.Parse(typeof(OperacionEnum), oComando.Parameters["@Codigo"].Value.ToString());
                        oResult.OperacionDes = oComando.Parameters["@Descripcion"].Value.ToString();
                        oComando.Parameters.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Datos.Utileria_Dat.Exec_StoredProcGenerico() |Error:" + ex.ToString());
            }
            return oResult;
        }
        public Respuesta_StoredProcGenerico_MultipleResult_Mod Exec_StoredProcGenerico_MultipleResult(SP nombreSP, List<SqlParameter> parametros)
        {
            var oResult = new Respuesta_StoredProcGenerico_MultipleResult_Mod();
            try
            {
                using (Conexion = new SqlConnection(cadenaConexion))
                {
                    Conexion.Open();
                    using (var oComando = new SqlCommand(nombreSP.ToString(), Conexion))
                    {
                        oComando.CommandType = System.Data.CommandType.StoredProcedure;
                        oComando.Parameters.Clear();
                        oComando.Parameters.AddRange(parametros.ToArray());
                        SqlDataAdapter oAdaptaptador = new SqlDataAdapter(oComando);

                        oAdaptaptador.Fill(oResult.dsTables);

                        var res = oComando.Parameters["@Codigo"].Value.ToString();
                        oResult.OperacionId = (OperacionEnum)Enum.Parse(typeof(OperacionEnum), oComando.Parameters["@Codigo"].Value.ToString());
                        oResult.OperacionDes = oComando.Parameters["@Descripcion"].Value.ToString();
                        oComando.Parameters.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Datos.Utileria_Dat.Exec_StoredProcGenerico_MultipleResult() |Error:" + ex.ToString());
            }
            return oResult;
        }
        #endregion
    }
}
