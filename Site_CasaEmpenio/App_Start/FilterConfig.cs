using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Site_CasaEmpenio.App_Start
{
    public class FilterConfig
    {
    }
    public class SessionTimeout_Attribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.RouteData.Values["Controller"].Equals("Login"))
            {
                if (!HttpContext.Current.Request.IsAuthenticated)
                {
                    filterContext.Result = new RedirectResult("~/Login/Index");
                    return;
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}