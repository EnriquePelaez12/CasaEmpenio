using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{    
    public class Usuario_Mod: Respuesta_Operacion_Mod
    {        
        public int Usuario_Id { get; set; }
        public string Usuario_Nombre { get; set; }

        [Required(ErrorMessage = Mensaje_Validacion_Mod.Requerido)]
        [StringLength(20)]
        public string Usuario_Login { get; set; }

        [Required(ErrorMessage = Mensaje_Validacion_Mod.Requerido)]
        [StringLength(20)]
        public string Contrasenia { get; set; }
        public int Rol_Id { get; set; }
    }
}
