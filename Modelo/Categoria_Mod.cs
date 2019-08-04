using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Categoria_Mod
    {
        public int Categoria_Id { get; set; }
        public int Empresa_Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Fec_Actualizacion { get; set; }
    }
}
