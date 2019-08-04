using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Tipo_Catalogo_Mod
    {
        public Tipo_Catalogo_Enum  Tipo_Catalogo { get; set; }
        public Tipo_Catalogo_Mod(Tipo_Catalogo_Enum pTipo)
        {
            Tipo_Catalogo = pTipo;
        }
    }
}
