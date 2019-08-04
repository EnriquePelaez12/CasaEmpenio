using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente_Mod
    {       
        public int Cliente_Id { get; set; }

        [Required(ErrorMessage = Mensaje_Validacion_Mod.Requerido)]
        public string Cliente_Nombre { get; set; }

        [Required(ErrorMessage = Mensaje_Validacion_Mod.Requerido)]
        public string Cliente_Apellido_Paterno { get; set; }

        [Required(ErrorMessage = Mensaje_Validacion_Mod.Requerido)]
        public string Cliente_Apellido_Materno { get; set; }

        [Required(ErrorMessage = Mensaje_Validacion_Mod.Requerido)]
        public int Ocupacion_Id { get; set; }

        [Required(ErrorMessage = Mensaje_Validacion_Mod.Requerido)]
        public string Cliente_Direccion { get; set; }
        public string Cliente_Telefono { get; set; }

        [Required(ErrorMessage = Mensaje_Validacion_Mod.Requerido)]
        public int Sexo_Id { get; set; }        

        [Required(ErrorMessage = Mensaje_Validacion_Mod.Requerido)]
        public int Estado_Civil_Id { get; set; }

        [Required(ErrorMessage = Mensaje_Validacion_Mod.Requerido)]
        public int Colonia_Id { get; set; }

        [Required(ErrorMessage = Mensaje_Validacion_Mod.Requerido)]
        public int Estado_Id { get; set; }

        [Required(ErrorMessage = Mensaje_Validacion_Mod.Requerido)]
        public int Municipio_Id { get; set; }

        public string Cliente_Celular { get; set; }

        public string Cliente_Email { get; set; }
        [Required(ErrorMessage = Mensaje_Validacion_Mod.Requerido)]
        public string Cliente_Cp { get; set; }
        [Required(ErrorMessage = Mensaje_Validacion_Mod.Requerido)]
        public string Cotitular { get; set; }                     
        public DateTime Cliente_Fec_Actualizacion { get; set; }
        //public byte[] Imagen { get; set; }

        //public int Emp_Id { get; set; }
        #region Propiedades adicionales
        public string Ocupacion_Descripcion { get; set; }
        public string Sexo_Descripcion { get; set; }
        public string EstadoCivil_Descripcion { get; set; }
        public string Estado_Descripcion { get; set; }
        public string Municipio_Descripcion { get; set; }
        public string Colonia_Descripcion { get; set; }

        #endregion
    }
}
