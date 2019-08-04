using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public enum OperacionEnum { NOEJECUTADO = 0, EXITO, ERROR }
    public class Respuesta_Operacion_Mod
    {
        public OperacionEnum OperacionId { get; set; }
        public string OperacionDes { get; set; }
        public Respuesta_Operacion_Mod()
        {
            OperacionId = OperacionEnum.NOEJECUTADO;
        }
        public override string ToString()
        {
            return "|OperacionId:" + OperacionId + "|OperacionDes:" + OperacionDes;
        }
    }
}
