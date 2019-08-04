using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Catalogo_Neg
    {
        public Modelo.Catalogo_Mod Catalogos_Obtener()
        {
            var oCatalogo = new Modelo.Catalogo_Mod();

            oCatalogo.List_Estado.Add(new Modelo.Catalogo_Generico() { Id = 21, Nombre = "Puebla" });

            oCatalogo.List_Municipio.Add(new Modelo.Municipio_Mod() { Id = 62, Estado_Id = 21, Nombre = "Tehuacán" });
            oCatalogo.List_Colonia.Add(new Modelo.Colonia_Mod() { Id = 12, Estado_Id = 21, Municipio_Id = 62, Nombre = "Agua Santa" });

            oCatalogo.List_Municipio.Add(new Modelo.Municipio_Mod() { Id = 64, Estado_Id = 21, Nombre = "Tecamachalco" });
            oCatalogo.List_Colonia.Add(new Modelo.Colonia_Mod() { Id = 1, Estado_Id = 21, Municipio_Id = 64, Nombre = "Avitec" });

            return oCatalogo;
        }
    }
}
