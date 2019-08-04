using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Respuesta_StoredProcGenerico_MultipleResult_Mod: Respuesta_Operacion_Mod
    {
        public System.Data.DataSet dsTables { get; set; }
        public Respuesta_StoredProcGenerico_MultipleResult_Mod()
        {
            dsTables = new System.Data.DataSet();
        }
    }
}
