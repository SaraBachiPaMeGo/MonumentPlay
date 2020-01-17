using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MonumentPlay.Authentication
{
    public class AutorizacionAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            if (filterContext == null)
            {
                //Capturamos el action y el controller que se haya activado
                String action = filterContext.RouteData.Values["action"].ToString();
                String controller = filterContext.RouteData.Values["controller"].ToString();

                //Se lo pasamos al controller con TempData
                filterContext.Controller.TempData["action"] = action;
                filterContext.Controller.TempData["controller"] = controller;

                filterContext.Result =GetRoute("Login", "Manage");
            }
        }

        public RedirectToRouteResult GetRoute(String action, String controller) 
        {
            RouteValueDictionary ruta = new RouteValueDictionary(new
            {                
                action = action,
                controller = controller
            });
            return new RedirectToRouteResult(ruta);
        }
    }
}