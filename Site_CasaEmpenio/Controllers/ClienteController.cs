using Site_CasaEmpenio.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site_CasaEmpenio.Controllers
{
    [SessionTimeout_Attribute]
    public class ClienteController : Controller
    {
        // GET: Cliente
        [HttpGet]
        public ActionResult Index()
        {            
            return View();
        }
        public ActionResult Agregar()
        {
            return View();
        }

        public ActionResult Modificar(int pCliente_Id)
        {             
            return View(new Negocio.Cliente_Neg().Cliente_Busqueda(pCliente_Id, string.Empty).FirstOrDefault());
        }

        #region Peticiones Ajax
        [HttpPost]
        public JsonResult Cliente_Busqueda(int pCliente_Id, string pCliente_Nombre)
        {            
            return Json(new Negocio.Cliente_Neg().Cliente_Busqueda(pCliente_Id, pCliente_Nombre));            
        }
        #endregion
    }
}