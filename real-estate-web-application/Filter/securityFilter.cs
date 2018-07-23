using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace real_estate_web_application.Filter
{
    public class _SecurityFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Kullanici"] == null && !(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Login" || filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Home"))
            {
                filterContext.Result = new RedirectResult("/Login/Index");
                return;
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}