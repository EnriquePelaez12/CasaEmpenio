using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Cliente_Neg
    {
        Datos.Cliente_Dat oClienteDat = new Datos.Cliente_Dat();
        public Modelo.Respuesta_Operacion_Mod Cliente_Insertar(Modelo.Cliente_Mod oCliente) {
            return oClienteDat.Cliente_Insertar(oCliente);
        }
        public List<Modelo.Cliente_Mod> Cliente_Busqueda(int pClienteId, string pCliente_Nombre)
        {
            var oCliente = new Modelo.Cliente_Mod()
            {
                Cliente_Id = pClienteId,
                Cliente_Nombre = pCliente_Nombre
            };
            return oClienteDat.Cliente_Busqueda(oCliente);
        }
    }
}
