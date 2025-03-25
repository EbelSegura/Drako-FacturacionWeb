using Drako_FacturacionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Drako_FacturacionWeb.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Ingreso(string users, string passwords)
        {
            try
            {
                using (var bd = new FacturacionWebEntities())
                {
                    var lst = from d in bd.USERS
                              where d.usuario == users && d.clave == passwords && d.idState == 1
                              select d;
                    if (lst.Count() > 0)
                    {
                        USERS oUser = lst.First();
                        Session["Users"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario Invalido");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error " + ex.Message);
            }
        }
    }
}