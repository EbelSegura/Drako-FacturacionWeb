using Drako_FacturacionWeb.Models.Filters;
using System.Web;
using System.Web.Mvc;

namespace Drako_FacturacionWeb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new VerifySession());
        }
    }
}
