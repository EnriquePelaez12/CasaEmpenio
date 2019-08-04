using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Usuario_Dat
    {
        Utileria_Dat _UtileriaDat = new Utileria_Dat();

        public Modelo.Usuario_Mod Usuario_Login(string pUsuario, string pContrasenia)
        {
            var oUsuario = new Modelo.Usuario_Mod();
            try
            {
                var listParametros = new List<SqlParameter>();
                listParametros.Add(new SqlParameter("@Usuario", SqlDbType.VarChar, 200) { Value = pUsuario });
                listParametros.Add(new SqlParameter("@Password", SqlDbType.VarChar, 200) { Value = pContrasenia });

                // Parametros de salida                
                listParametros.Add(new SqlParameter("@Codigo", SqlDbType.Int) { Value = 0, Direction = ParameterDirection.Output });
                listParametros.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar, 250) { Value = "", Direction = ParameterDirection.Output });

                var oDataResult = _UtileriaDat.Exec_StoredProcGenerico(SP.SP_USUARIO_LOGIN, listParametros);
                oUsuario.OperacionId = oDataResult.OperacionId; oUsuario.OperacionDes = oDataResult.OperacionDes;
                foreach (DataRow fila in oDataResult.oDataTable.Rows)
                {
                    oUsuario.Usuario_Id = int.Parse(fila["Usuario_Id"].ToString());
                    oUsuario.Usuario_Nombre = fila["Usuario_Nombre"].ToString();
                    oUsuario.Usuario_Login = fila["Usuario_Login"].ToString();
                    oUsuario.Rol_Id = int.Parse(fila["Rol_Id"].ToString());
                }
            }
            catch (Exception ex)
            {
                //Registrar en Log
            }
            return oUsuario;
        }
    }
}
