using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Drako_FacturacionWeb.Models.TableViewModels
{
    public class UserTableViewModel
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public string clave { get; set; }
        public int idState { get; set; }
        public DateTime fechaRegistro { get; set; }

        //PROPIEDADES ADICIONALES
        public string tipoEstatus { get; set; }
        public string mensajeError { get; set; }
    }
}