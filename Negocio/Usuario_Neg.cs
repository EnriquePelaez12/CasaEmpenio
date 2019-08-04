using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Usuario_Neg
    {
        Datos.Usuario_Dat oUsuarioDat = new Datos.Usuario_Dat();
        public Modelo.Usuario_Mod Usuario_Login(string pUsuario, string pContrasenia)
        {
            return oUsuarioDat.Usuario_Login(pUsuario, pContrasenia);
        }
    }
}
