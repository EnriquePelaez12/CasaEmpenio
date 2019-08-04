using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{    
    public enum Tipo_Catalogo_Enum { ESTADO = 0, MUNICIPIO, COLONIA, CLIENTE }
    public class Catalogo_Mod: Respuesta_Operacion_Mod
    {
        public List<Catalogo_Generico> List_Estado { get; set; }
        public List<Municipio_Mod> List_Municipio { get; set; }
        public List<Colonia_Mod> List_Colonia { get; set; }
        public Catalogo_Mod()
        {
            List_Estado = new List<Catalogo_Generico>();
            List_Municipio = new List<Municipio_Mod>();
            List_Colonia = new List<Colonia_Mod>();
        }
    }

    #region Tipos de Catalogos
    public class Catalogo_Generico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class Municipio_Mod : Catalogo_Generico
    {
        public int Estado_Id { get; set; }        
    }
    public class Colonia_Mod: Catalogo_Generico
    {
        public int Estado_Id { get; set; }
        public int Municipio_Id { get; set; }     
    }
    #endregion
}
