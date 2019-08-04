using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Utilerias
{
    public class Bitacora_Uti
    {
        public Bitacora_Uti()
        {
            if (!LogManager.GetRepository().Configured)
                XmlConfigurator.Configure();
        }

        private static readonly ILog log = LogManager.GetLogger(typeof(Bitacora_Uti));
        /// <summary>
        /// Registra información en la bitácora
        /// </summary>
        /// <param name="mensaje"></param>
        public static void Reg_Info(string mensaje)
        {
            log.Info(mensaje);
        }
        /// <summary>
        /// Registra error en la bitácora
        /// </summary>
        /// <param name="mensaje"></param>
        public static void Reg_Error(string mensaje)
        {
            log.Error(mensaje);
        }
    }
}
