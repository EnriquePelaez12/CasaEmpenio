using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Respuesta_StoredProcGenerico_Mod: Respuesta_Operacion_Mod
    {
        public System.Data.DataTable oDataTable { get; set; }
        public Respuesta_StoredProcGenerico_Mod()
        {
            oDataTable = new System.Data.DataTable("dtGenerico");
        }
    }
}
