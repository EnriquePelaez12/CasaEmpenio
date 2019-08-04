using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Site_CasaEmpenio.Controllers
{   
    public class LoginController : Controller
    {
        #region Propiedades        
        public Modelo.Catalogo_Mod _Catalogo
        {
            set
            {
                System.Web.HttpContext.Current.Session.Add("List_Catalogos", value);
            }
        }
        #endregion
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Modelo.Usuario_Mod oUsuario)
        {
            if (ModelState.IsValid)
            {
                var oNegocio = new Negocio.Usuario_Neg();
                var oResult = oNegocio.Usuario_Login(oUsuario.Usuario_Login, oUsuario.Contrasenia);
                oUsuario.OperacionId = oResult.OperacionId;
                oUsuario.OperacionDes = oResult.OperacionDes;
                if (oResult.OperacionId == Modelo.OperacionEnum.EXITO)
                {
                    //Forma 1
                    var timeOut = int.Parse(System.Configuration.ConfigurationManager.AppSettings["SesionTimeOut"]);
                    var cookie = FormsAuthentication.GetAuthCookie("usuario", true);
                    cookie.Name = FormsAuthentication.FormsCookieName;
                    //cookie.Expires = DateTime.Now.AddMonths(3);

                    var ticket = FormsAuthentication.Decrypt(cookie.Value);                    
                    var newTicket = new FormsAuthenticationTicket(oResult.Usuario_Id + "|" + oResult.Usuario_Nombre + "|" + oResult.Rol_Id, false, timeOut);
                    cookie.Value = FormsAuthentication.Encrypt(newTicket);                    
                    HttpContext.Response.Cookies.Add(cookie);
                    //Forma 2
                    //FormsAuthentication.SetAuthCookie(oResult.Usuario_Id + "|" + oResult.Usuario_Nombre + "|" + oResult.Rol_Id, false);
                    _Catalogo = new Negocio.Catalogo_Neg().Catalogos_Obtener();
                    return RedirectToAction("Index", "Home", null);
                }
            }
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult Salir()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}