using Drako_FacturacionWeb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Drako_FacturacionWeb.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        public ActionResult Companies()
        {

            return View();
        }



        public ActionResult Clients()
        {

            return View();
        }



        public ActionResult Concepts()
        {

            return View();
        }



        public ActionResult Invoices()
        {
            //FacturaViewModel model = new FacturaViewModel();
            return View();
        }


        [RequireHttps]
        public ActionResult Save (FacturaViewModel model)
        {
            try
            {
                return Content("1");
            }
            catch (Exception ex)
            {

            }
            return Content("0");
        }
    }
}