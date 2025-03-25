using Drako_FacturacionWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Drako_FacturacionWeb.Models.Filters
{
    public class VerifySession:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (USERS)HttpContext.Current.Session["Users"];
            if(oUser == null)
            {
                if(filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("/Access/Login");
                }
            }
            else
            {
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}