using Drako_FacturacionWeb.Models;
using Drako_FacturacionWeb.Models.TableViewModels;
using Drako_FacturacionWeb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Drako_FacturacionWeb.Controllers
{
    public class ControlController : Controller
    {
        // GET: Control
        public ActionResult Users()
        {
            List<UserTableViewModel> lstusuario = null;
            using(var bd = new FacturacionWebEntities())
            {
                lstusuario = (from user in bd.USERS
                              join estatus in bd.CSTATE
                              on user.idState equals estatus.id
                              where user.idState == 1
                              select new UserTableViewModel
                              {
                                  id = user.id,
                                  usuario = user.usuario,
                                  nombres = user.nombres,
                                  apellidos = user.apellidos,
                                  correo = user.correo,
                                  tipoEstatus = estatus.descripcion,
                                  //idState = (int)user.idState,
                                  fechaRegistro = (DateTime)user.fechaRegistro
                              }).ToList();
            }
            return View(lstusuario);
        }

        //LLENADO DE LOS COMBO BOX 
        private void listaEstatus()
        {
            List<SelectListItem> listaEstatus;
            using (var bd = new FacturacionWebEntities())
            {
                listaEstatus = (from estatus in bd.CSTATE
                         select new SelectListItem
                         {
                             Text = estatus.descripcion,
                             Value = estatus.id.ToString()
                         }).ToList();
                listaEstatus.Insert(0, new SelectListItem { Text = "--Seleccione--", Value = "" });
                ViewBag.listaEstatus = listaEstatus;
            }
        }


        public ActionResult AddUsers()
        {
            listaEstatus();
            return View();
        }

        [HttpPost]
        public ActionResult AddUsers(UserViewModels oCLSUser)
        {
            int nregistro = 0;
            string usuario = oCLSUser.usuario;
            using(var bd = new FacturacionWebEntities())
            {
                nregistro = bd.USERS.Where(p=>p.usuario.Equals(usuario)).Count();
            }
            if(!ModelState.IsValid || nregistro >= 1)
            {
                if (nregistro >= 1) oCLSUser.mensajeError = "El usuario ya esta registrado";
                return View(oCLSUser);
            }
            else
            {
                using(var bd = new FacturacionWebEntities())
                {
                    USERS oUser = new USERS();
                    oUser.usuario = oCLSUser.usuario;
                    oUser.nombres = oCLSUser.nombres;
                    oUser.apellidos = oCLSUser.apellidos;
                    oUser.correo = oCLSUser.correo;
                    oUser.clave = oCLSUser.clave;
                    oUser.idState = 1;
                    oUser.fechaRegistro = DateTime.Now;
                    bd.USERS.Add(oUser);
                    bd.SaveChanges();
                }
            }
            return RedirectToAction("Users");
        }



        public ActionResult EditUsers(int id)
        {
            EditUserViewModels oCLSUsers = new EditUserViewModels();
            using(var bd = new FacturacionWebEntities())
            {
                listaEstatus();
                USERS oUsers = bd.USERS.Where(p=>p.id.Equals(id)).First();
                oCLSUsers.id = oUsers.id;
                oCLSUsers.usuario = oUsers.usuario;
                oCLSUsers.nombres = oUsers.nombres;
                oCLSUsers.apellidos = oUsers.apellidos;
                oCLSUsers.correo = oUsers.correo;
                oCLSUsers.clave = oUsers.clave;
                oCLSUsers.idState = (int)oUsers.idState;
                oCLSUsers.fechaRegistro = (DateTime)oUsers.fechaRegistro;
            }
            return View(oCLSUsers);
        }


        [HttpPost]
        public ActionResult EditUsers(EditUserViewModels oCLSUsers)
        {
            int nregistrado = 0;
            string ousuario = oCLSUsers.usuario;
            int oid = oCLSUsers.id;
            using(var bd = new FacturacionWebEntities())
            {
                nregistrado = bd.USERS.Where(p => p.usuario.Equals(ousuario) && !p.id.Equals(oid)).Count();
            }
            if(!ModelState.IsValid || nregistrado >= 1)
            {
                if (nregistrado >= 1) oCLSUsers.mensajeError = "El usuario ya se encuentra registrado";
                return View(oCLSUsers);
            }
            int id = oCLSUsers.id;
            using (var bd = new FacturacionWebEntities())
            {
                USERS oUsers = bd.USERS.Where(p=>p.id.Equals(id)).First();
                oUsers.id = oCLSUsers.id;
                oUsers.usuario = oCLSUsers.usuario;
                oUsers.nombres = oCLSUsers.nombres;
                oUsers.apellidos = oCLSUsers.apellidos;
                oUsers.correo = oCLSUsers.correo;
                if(oCLSUsers.clave != null && oCLSUsers.clave.Trim() != "")
                {
                    oUsers.clave = oCLSUsers.clave;
                }
                oUsers.idState = oCLSUsers.idState;
                oUsers.fechaRegistro = oCLSUsers.fechaRegistro;
                bd.SaveChanges();
            }
            return RedirectToAction("Users");
        }
    }
}